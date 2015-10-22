namespace Project_Phase1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.ibProcessed = new Emgu.CV.UI.ImageBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.tbGesture = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSpeakGesture = new System.Windows.Forms.Button();
            this.tbHandAngle = new System.Windows.Forms.TextBox();
            this.tbNoFinger = new System.Windows.Forms.TextBox();
            this.tbFingerPosition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ibOriginal.Location = new System.Drawing.Point(33, 44);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(640, 480);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // ibProcessed
            // 
            this.ibProcessed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ibProcessed.Location = new System.Drawing.Point(679, 44);
            this.ibProcessed.Name = "ibProcessed";
            this.ibProcessed.Size = new System.Drawing.Size(640, 480);
            this.ibProcessed.TabIndex = 2;
            this.ibProcessed.TabStop = false;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.LightCoral;
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPause.Location = new System.Drawing.Point(12, 547);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(322, 207);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tbGesture
            // 
            this.tbGesture.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbGesture.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbGesture.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGesture.Location = new System.Drawing.Point(668, 573);
            this.tbGesture.Multiline = true;
            this.tbGesture.Name = "tbGesture";
            this.tbGesture.ReadOnly = true;
            this.tbGesture.Size = new System.Drawing.Size(676, 53);
            this.tbGesture.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(923, 547);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recognised Gesture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(290, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Original";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(935, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Processed";
            // 
            // btnSpeakGesture
            // 
            this.btnSpeakGesture.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSpeakGesture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSpeakGesture.BackgroundImage")));
            this.btnSpeakGesture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpeakGesture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpeakGesture.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeakGesture.Location = new System.Drawing.Point(340, 547);
            this.btnSpeakGesture.Name = "btnSpeakGesture";
            this.btnSpeakGesture.Size = new System.Drawing.Size(312, 207);
            this.btnSpeakGesture.TabIndex = 8;
            this.btnSpeakGesture.UseVisualStyleBackColor = false;
            this.btnSpeakGesture.Click += new System.EventHandler(this.btnSpeakGesture_Click);
            // 
            // tbHandAngle
            // 
            this.tbHandAngle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbHandAngle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbHandAngle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHandAngle.Location = new System.Drawing.Point(1202, 709);
            this.tbHandAngle.Multiline = true;
            this.tbHandAngle.Name = "tbHandAngle";
            this.tbHandAngle.ReadOnly = true;
            this.tbHandAngle.Size = new System.Drawing.Size(142, 45);
            this.tbHandAngle.TabIndex = 9;
            // 
            // tbNoFinger
            // 
            this.tbNoFinger.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbNoFinger.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbNoFinger.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoFinger.Location = new System.Drawing.Point(1202, 653);
            this.tbNoFinger.Multiline = true;
            this.tbNoFinger.Name = "tbNoFinger";
            this.tbNoFinger.ReadOnly = true;
            this.tbNoFinger.Size = new System.Drawing.Size(142, 42);
            this.tbNoFinger.TabIndex = 10;
            // 
            // tbFingerPosition
            // 
            this.tbFingerPosition.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbFingerPosition.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbFingerPosition.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFingerPosition.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbFingerPosition.Location = new System.Drawing.Point(668, 679);
            this.tbFingerPosition.Multiline = true;
            this.tbFingerPosition.Name = "tbFingerPosition";
            this.tbFingerPosition.ReadOnly = true;
            this.tbFingerPosition.Size = new System.Drawing.Size(376, 75);
            this.tbFingerPosition.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(760, 653);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Position of Key Points";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(1072, 663);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "No. of fingers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(1072, 719);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Angle of hand";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1358, 767);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFingerPosition);
            this.Controls.Add(this.tbNoFinger);
            this.Controls.Add(this.tbHandAngle);
            this.Controls.Add(this.btnSpeakGesture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGesture);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.ibProcessed);
            this.Controls.Add(this.ibOriginal);
            this.Font = new System.Drawing.Font("Baskerville Old Face", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hand Gesture Recognition System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibProcessed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private Emgu.CV.UI.ImageBox ibProcessed;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TextBox tbGesture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSpeakGesture;
        private System.Windows.Forms.TextBox tbHandAngle;
        private System.Windows.Forms.TextBox tbNoFinger;
        private System.Windows.Forms.TextBox tbFingerPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

