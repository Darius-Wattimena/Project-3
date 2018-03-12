namespace ProjectData
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
            this.mainLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.subLabel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.Color.Black;
            this.mainLabel.Location = new System.Drawing.Point(595, 270);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(89, 26);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Loading";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(520, 355);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 23);
            this.progressBar.TabIndex = 1;
            // 
            // subLabel
            // 
            this.subLabel.Enabled = false;
            this.subLabel.FlatAppearance.BorderSize = 0;
            this.subLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subLabel.ForeColor = System.Drawing.Color.Black;
            this.subLabel.Location = new System.Drawing.Point(520, 311);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(240, 23);
            this.subLabel.TabIndex = 2;
            this.subLabel.Text = "...";
            this.subLabel.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnBackgroundLoad);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.subLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.mainLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.OnShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button subLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

