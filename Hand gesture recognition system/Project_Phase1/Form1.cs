using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Emgu related libraries
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;

//Speech related libraries
using System.Speech;
using System.Speech.Synthesis;

//Our skin detection library
using HandGestureRecognition.SkinDetector;

namespace Project_Phase1
{
    public partial class Form1 : Form
    {
        Capture capwebcam = null;                           //to initiate image capture through webcam
        bool bmcapprocess = false;                          
        Image<Bgr, Byte> imgOriginal;                       //the actual RGB capture
        Image<Gray, Byte> imgProcessed;                     //the background-subtracted result
        Image<Bgr, Byte> currentFrame;
        SpeechSynthesizer ss = new SpeechSynthesizer();     //the object to produce speech 
        Seq<Point> hull;                                    //the convex hull
        Seq<Point> filteredHull;
        Seq<MCvConvexityDefect> defects;                    //to store the defects
        MCvConvexityDefect[] defectArray;                   
        String gesture;                                     //the names of gestures
        MCvBox2D box;
        double fingLen;
        Hsv hsv_min;                                        //hsv constraints on skin
        Hsv hsv_max;
        Ycc YCrCb_min;                                      //YCrCb constraints on skin
        Ycc YCrCb_max;
        IColorSkinDetector skinDetector;                    //instance of the detector
        PointF cogPt;
        private int contourAxisAngle;                       //angle of the contour 
        MCvMoments mv;                              
        
        public Form1()
        {
            InitializeComponent();
            hsv_min = new Hsv(0, 45, 0);                    //values of max and min skin color
            hsv_max = new Hsv(20, 255, 255);
            YCrCb_min = new Ycc(0, 131, 80);
            YCrCb_max = new Ycc(255, 185, 135);  
            mv = new MCvMoments();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                capwebcam = new Capture();                  //initiate capture
            }
            catch (NullReferenceException except)
            {
                tbGesture.Text = except.Message;            //exception to deal with bad webcam
                return;
            }

            Application.Idle += processFrameAndUpdateGUI;   //add the function to the process queue
            bmcapprocess = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capwebcam != null)
                capwebcam.Dispose();                        //garbage collection
        }

        void processFrameAndUpdateGUI(object sender, EventArgs e)
        {        
          imgOriginal = capwebcam.RetrieveBgrFrame();       //obtain one RGB frame
          currentFrame = capwebcam.QueryFrame();
          if (imgOriginal == null) return;
          skinDetector = new YCrCbSkinDetector();
          Image<Gray, Byte> skin = skinDetector.DetectSkin(currentFrame, YCrCb_min, YCrCb_max);    //put it through skin detection, retain only skin colored parts
          imgProcessed = skin.SmoothGaussian(9);            //Remove sharp edges
          ExtractContourAndHull(imgProcessed);              //contour and hull formation
          if(defects != null)
                DrawAndComputeFingersNum();                 //detect and compute fingers
          ibProcessed.Image = imgProcessed;
          ibOriginal.Image = currentFrame;                  //output
        }
     
        private void ExtractContourAndHull(Image<Gray, byte> skin)
        {
            using (MemStorage storage = new MemStorage())
            {

                Contour<Point> contours = skin.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); //use the library fuction to find the contours
                Contour<Point> biggestContour = null;
                Double Result1 = 0;
                Double Result2 = 0;
                while (contours != null)
                {
                    Result1 = contours.Area;
                    if (Result1 > Result2)
                    {
                        Result2 = Result1;
                        biggestContour = contours;      //loop to find the biggest contour
                    }
                    contours = contours.HNext;
                }

                if (biggestContour != null)
                {
                    //currentFrame.Draw(biggestContour, new Bgr(Color.DarkViolet), 2);
                    Contour<Point> currentContour = biggestContour.ApproxPoly(biggestContour.Perimeter * 0.0025, storage);
                    currentFrame.Draw(currentContour, new Bgr(Color.LimeGreen), 2);     //draw a polygon around the biggest contour 
                    biggestContour = currentContour;
                    hull = biggestContour.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);   //obtain the convex hull
                    box = biggestContour.GetMinAreaRect();   //and a min area rectangle to find the center of the hand               
                    PointF[] points = box.GetVertices();                                  
                    mv = biggestContour.GetMoments();       //moments to find the angle of hand 
                    CvInvoke.cvMoments(biggestContour,ref mv, 1);   
                    double m00 = CvInvoke.cvGetSpatialMoment(ref mv, 0, 0) ;  //obtain spatial moments = M(xord,yord) = sum{x,y} (I(x,y) * x^xord * y^yord)
                    double m10 = CvInvoke.cvGetSpatialMoment(ref mv, 1, 0) ;
                    double m01 = CvInvoke.cvGetSpatialMoment(ref mv, 0, 1) ;                  
                    if (m00 != 0)
                    { // calculate center
                        int xCenter = (int) Math.Round(m10/m00)*2;  //scale = 2
                        int yCenter = (int) Math.Round(m01/m00)*2;
                        cogPt.X =xCenter;                           //coordinates of gravity center
                        cogPt.Y =yCenter; 
                    }

                    double m11 = CvInvoke.cvGetCentralMoment(ref mv, 1, 1); //obtain central moment = mu{x,y} = sum{x,y} (I(x,y) * xCenter^xord * yCenter^yord)
                    double m20 = CvInvoke.cvGetCentralMoment(ref mv, 2, 0);
                    double m02 = CvInvoke.cvGetCentralMoment(ref mv, 0, 2);
                    contourAxisAngle = calculateTilt(m11, m20, m02);        //call the calculate tilt function
                    tbHandAngle.Text = contourAxisAngle.ToString();           
                    Point[] ps = new Point[points.Length];
                    for (int i = 0; i < points.Length; i++)
                        ps[i] = new Point((int)points[i].X, (int)points[i].Y);  //copy the box vertices into a point array 

                    currentFrame.DrawPolyline(hull.ToArray(), true, new Bgr(200, 125, 75), 2);  //draw the hull
                    currentFrame.Draw(new CircleF(new PointF(box.center.X, box.center.Y), 3), new Bgr(200, 125, 75), 2);     //draw the circle representing the center of the box               
                    filteredHull = new Seq<Point>(storage);
                    for (int i = 0; i < hull.Total; i++)
                    {
                        if (Math.Sqrt(Math.Pow(hull[i].X - hull[i + 1].X, 2) + Math.Pow(hull[i].Y - hull[i + 1].Y, 2)) > box.size.Width / 10)
                        {
                            filteredHull.Push(hull[i]);     //custom heuristic to filter small errors in hull
                        }
                    }

                    defects = biggestContour.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);   //find the convexity defects
                    defectArray = defects.ToArray();
                }
            }
        }

        private int calculateTilt(double m11, double m20, double m02)
        {
            double diff = m20-m02;
            if (diff == 0) 
            {
                if (m11 == 0)
                    return 0;
                else if (m11 > 0)
                    return 45;
                else // m11 < 0
                    return -45;
            }
            double theta = 0.5 * Math.Atan2(2*m11, diff);
            int tilt = (int) Math.Round( 57.2957795*theta);
            if ((diff > 0) && (m11 == 0))
                    return 0;
            else if ((diff < 0) && (m11 == 0))
                    return -90;
            else if ((diff > 0) && (m11 > 0)) // 0 to 45 degrees
                    return tilt;
            else if ((diff > 0) && (m11 < 0)) //-45 to 0
                return (180 + tilt); // change to counter-clockwise angle
            else if ((diff < 0) && (m11 > 0)) // 45 to 90
                    return tilt;
            else if ((diff < 0) && (m11 < 0)) //-90 to-45
                    return (180 + tilt); // change tocounter-clockwise angle
            tbGesture.Text= "Error in moments for tilt angle";
                return 0;
        } // end of calculateTilt()


        private void DrawAndComputeFingersNum()
        {
           
            int fingerNum = 0;
            fingLen = 0;      
            tbFingerPosition.Text = "";     
            #region defects drawing
            for (int i = 0; i < defects.Total; i++)
            {
                PointF startPoint = new PointF((float)defectArray[i].StartPoint.X,
                                                (float)defectArray[i].StartPoint.Y);            //start of a finger

                PointF depthPoint = new PointF((float)defectArray[i].DepthPoint.X,              //valley of a finger
                                                (float)defectArray[i].DepthPoint.Y);

                PointF endPoint = new PointF((float)defectArray[i].EndPoint.X,                  // start of next finger
                                                (float)defectArray[i].EndPoint.Y);
               
                LineSegment2D startDepthLine = new LineSegment2D(defectArray[i].StartPoint, defectArray[i].DepthPoint);

                LineSegment2D depthEndLine = new LineSegment2D(defectArray[i].DepthPoint, defectArray[i].EndPoint);             //draw lines to represent edges of fingers and circles to represent finger tips

                CircleF startCircle = new CircleF(startPoint, 5f);

                CircleF depthCircle = new CircleF(depthPoint, 5f);

                CircleF endCircle = new CircleF(endPoint, 5f);

                           
                if (/*(startCircle.Center.Y < box.center.Y || depthCircle.Center.Y < box.center.Y) &&*/ (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 6.5))
                {
                    fingerNum++;
                    currentFrame.Draw(startDepthLine, new Bgr(Color.Green), 2);
                    if (fingLen < Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)))
                        fingLen = Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2));   //to find the smallest finger length
                    //currentFrame.Draw(depthEndLine, new Bgr(Color.Magenta), 2);
                }             
                currentFrame.Draw(startCircle, new Bgr(Color.Red), 2);
                currentFrame.Draw(depthCircle, new Bgr(Color.Yellow), 5);
                //currentFrame.Draw(endCircle, new Bgr(Color.DarkBlue), 4);
            }
            #endregion
           
            for(int i=0; i< defects.Total; i++) 
            tbFingerPosition.Text += "(" + defectArray[i].StartPoint.X.ToString() + " , " + defectArray[i].StartPoint.Y.ToString() + ")\n";
          
            if (fingLen < 130)
            {
                fingerNum = 0;
            }

            tbNoFinger.Text = fingerNum.ToString();
            gestureRecog(fingerNum);

        }


        private void gestureRecog(int fingerNum)
        {   
            //definition of the gestures
            if(fingerNum == 0)
                gesture = tbGesture.Text = "Fist!";    
            else if (fingerNum == 1 && contourAxisAngle > 130 && contourAxisAngle < 165)
                gesture = tbGesture.Text = "Thumbs up!";
            else if (fingerNum == 2 && contourAxisAngle > 90 && contourAxisAngle < 125)
                gesture = tbGesture.Text = "Victory!";
            else if (fingerNum == 2 && contourAxisAngle > 130 && contourAxisAngle < 165)
                gesture = tbGesture.Text = "Go Left!";
            else if (fingerNum == 2 && contourAxisAngle > 60 && contourAxisAngle < 90)
                gesture = tbGesture.Text = "Go Right!";
            else if (fingerNum == 1 && contourAxisAngle > 25 && contourAxisAngle < 40)
                gesture = tbGesture.Text = "Thumbs Down!";
            else if (fingerNum == 5)
                gesture = tbGesture.Text = "Open palm!";
            else if (fingerNum == 4)
                gesture = tbGesture.Text = "Four fingers!";
            else if (fingerNum == 3)
                gesture = tbGesture.Text = "Three fingers!";
            else if (fingerNum == 1)
                gesture = tbGesture.Text = "Index finger!";
            else
                gesture = tbGesture.Text = "Unrecognized!";
        }



        // when pause or resume is clicked
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (bmcapprocess == true)
            {
                Application.Idle -= processFrameAndUpdateGUI;
                bmcapprocess = false;
                btnPause.Text = "resume";
            }
            else
            {
                Application.Idle += processFrameAndUpdateGUI;
                bmcapprocess = true;
                btnPause.Text = "pause";
            }

        }

        //when speak button is clicked
        private void btnSpeakGesture_Click(object sender, EventArgs e)
        {
            ss.Speak(gesture);
        }
    }
}
