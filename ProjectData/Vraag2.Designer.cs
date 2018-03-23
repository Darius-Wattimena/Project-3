namespace ProjectData
{
    partial class Vraag2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkallyears = new System.Windows.Forms.CheckBox();
            this.yearone = new System.Windows.Forms.CheckBox();
            this.yeartwo = new System.Windows.Forms.CheckBox();
            this.updatechart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button3.Location = new System.Drawing.Point(45, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 62);
            this.button3.TabIndex = 7;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button2.Location = new System.Drawing.Point(45, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 62);
            this.button2.TabIndex = 6;
            this.button2.Text = "Question 3";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button1.Location = new System.Drawing.Point(45, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 62);
            this.button1.TabIndex = 5;
            this.button1.Text = "Question 1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(45, 308);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(492, 244);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // checkallyears
            // 
            this.checkallyears.AutoSize = true;
            this.checkallyears.Location = new System.Drawing.Point(262, 46);
            this.checkallyears.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkallyears.Name = "checkallyears";
            this.checkallyears.Size = new System.Drawing.Size(87, 17);
            this.checkallyears.TabIndex = 10;
            this.checkallyears.Text = "(un)check all";
            this.checkallyears.UseVisualStyleBackColor = true;
            this.checkallyears.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // yearone
            // 
            this.yearone.AutoSize = true;
            this.yearone.Location = new System.Drawing.Point(262, 67);
            this.yearone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.yearone.Name = "yearone";
            this.yearone.Size = new System.Drawing.Size(50, 17);
            this.yearone.TabIndex = 11;
            this.yearone.Text = "2014";
            this.yearone.UseVisualStyleBackColor = true;
            this.yearone.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // yeartwo
            // 
            this.yeartwo.AutoSize = true;
            this.yeartwo.Location = new System.Drawing.Point(262, 102);
            this.yeartwo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.yeartwo.Name = "yeartwo";
            this.yeartwo.Size = new System.Drawing.Size(50, 17);
            this.yeartwo.TabIndex = 12;
            this.yeartwo.Text = "2015";
            this.yeartwo.UseVisualStyleBackColor = true;
            this.yeartwo.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // updatechart
            // 
            this.updatechart.Location = new System.Drawing.Point(374, 185);
            this.updatechart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.updatechart.Name = "updatechart";
            this.updatechart.Size = new System.Drawing.Size(134, 53);
            this.updatechart.TabIndex = 13;
            this.updatechart.Text = "update chart";
            this.updatechart.UseVisualStyleBackColor = true;
            // 
            // Vraag2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectData.Resource.MainMenuBackgroundNoText;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.updatechart);
            this.Controls.Add(this.yeartwo);
            this.Controls.Add(this.yearone);
            this.Controls.Add(this.checkallyears);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Vraag2";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkallyears;
        private System.Windows.Forms.CheckBox yearone;
        private System.Windows.Forms.CheckBox yeartwo;
        private System.Windows.Forms.Button updatechart;
    }
}