namespace DRecognition.Tests
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
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.picSource = new System.Windows.Forms.PictureBox();
            this.picTarge = new System.Windows.Forms.PictureBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecognizing = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGrayValue = new System.Windows.Forms.TextBox();
            this.txtMaxNearPoints = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkGray = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTarge)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 3);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(107, 23);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load Initial Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // picSource
            // 
            this.picSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSource.Location = new System.Drawing.Point(12, 33);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(200, 150);
            this.picSource.TabIndex = 1;
            this.picSource.TabStop = false;
            // 
            // picTarge
            // 
            this.picTarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTarge.Location = new System.Drawing.Point(218, 33);
            this.picTarge.Name = "picTarge";
            this.picTarge.Size = new System.Drawing.Size(200, 150);
            this.picTarge.TabIndex = 2;
            this.picTarge.TabStop = false;
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(112, 195);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(100, 20);
            this.txtThreshold.TabIndex = 3;
            this.txtThreshold.TextChanged += new System.EventHandler(this.txtThreshold_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Threshold";
            // 
            // txtRecognizing
            // 
            this.txtRecognizing.Location = new System.Drawing.Point(219, 6);
            this.txtRecognizing.Name = "txtRecognizing";
            this.txtRecognizing.Size = new System.Drawing.Size(199, 20);
            this.txtRecognizing.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Noise";
            // 
            // txtGrayValue
            // 
            this.txtGrayValue.Location = new System.Drawing.Point(112, 224);
            this.txtGrayValue.Name = "txtGrayValue";
            this.txtGrayValue.Size = new System.Drawing.Size(100, 20);
            this.txtGrayValue.TabIndex = 7;
            this.txtGrayValue.TextChanged += new System.EventHandler(this.txtGrayValue_TextChanged);
            // 
            // txtMaxNearPoints
            // 
            this.txtMaxNearPoints.Location = new System.Drawing.Point(218, 224);
            this.txtMaxNearPoints.Name = "txtMaxNearPoints";
            this.txtMaxNearPoints.Size = new System.Drawing.Size(100, 20);
            this.txtMaxNearPoints.TabIndex = 8;
            this.txtMaxNearPoints.TextChanged += new System.EventHandler(this.txtMaxNearPoints_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gray";
            // 
            // chkGray
            // 
            this.chkGray.AutoSize = true;
            this.chkGray.Location = new System.Drawing.Point(112, 252);
            this.chkGray.Name = "chkGray";
            this.chkGray.Size = new System.Drawing.Size(44, 17);
            this.chkGray.TabIndex = 10;
            this.chkGray.Text = "Yes";
            this.chkGray.UseVisualStyleBackColor = true;
            this.chkGray.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 323);
            this.Controls.Add(this.chkGray);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaxNearPoints);
            this.Controls.Add(this.txtGrayValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRecognizing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.picTarge);
            this.Controls.Add(this.picSource);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "DRecognition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTarge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.PictureBox picTarge;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecognizing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrayValue;
        private System.Windows.Forms.TextBox txtMaxNearPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkGray;
    }
}

