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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.preventie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkallyears = new System.Windows.Forms.CheckBox();
            this.yearone = new System.Windows.Forms.CheckBox();
            this.yeartwo = new System.Windows.Forms.CheckBox();
            this.updatechart = new System.Windows.Forms.Button();
            this.yearthree = new System.Windows.Forms.CheckBox();
            this.yearfour = new System.Windows.Forms.CheckBox();
            this.yearfive = new System.Windows.Forms.CheckBox();
            this.yearsix = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.preventie)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.button3.Location = new System.Drawing.Point(60, 209);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 76);
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
            this.button2.Location = new System.Drawing.Point(60, 126);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 76);
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
            this.button1.Location = new System.Drawing.Point(60, 42);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 76);
            this.button1.TabIndex = 5;
            this.button1.Text = "Question 1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // preventie
            // 
            chartArea4.Name = "ChartArea1";
            this.preventie.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.preventie.Legends.Add(legend4);
            this.preventie.Location = new System.Drawing.Point(60, 379);
            this.preventie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.preventie.Name = "preventie";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.preventie.Series.Add(series4);
            this.preventie.Size = new System.Drawing.Size(656, 300);
            this.preventie.TabIndex = 9;
            this.preventie.Text = "chart1";
            this.preventie.Click += new System.EventHandler(this.chart1_Click);
            // 
            // checkallyears
            // 
            this.checkallyears.AutoSize = true;
            this.checkallyears.Location = new System.Drawing.Point(349, 42);
            this.checkallyears.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkallyears.Name = "checkallyears";
            this.checkallyears.Size = new System.Drawing.Size(111, 21);
            this.checkallyears.TabIndex = 10;
            this.checkallyears.Text = "(un)check all";
            this.checkallyears.UseVisualStyleBackColor = true;
            this.checkallyears.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // yearone
            // 
            this.yearone.AutoSize = true;
            this.yearone.Location = new System.Drawing.Point(349, 75);
            this.yearone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yearone.Name = "yearone";
            this.yearone.Size = new System.Drawing.Size(62, 21);
            this.yearone.TabIndex = 11;
            this.yearone.Text = "2012";
            this.yearone.UseVisualStyleBackColor = true;
            this.yearone.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // yeartwo
            // 
            this.yeartwo.AutoSize = true;
            this.yeartwo.Location = new System.Drawing.Point(349, 100);
            this.yeartwo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yeartwo.Name = "yeartwo";
            this.yeartwo.Size = new System.Drawing.Size(62, 21);
            this.yeartwo.TabIndex = 12;
            this.yeartwo.Text = "2013";
            this.yeartwo.UseVisualStyleBackColor = true;
            this.yeartwo.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // updatechart
            // 
            this.updatechart.Location = new System.Drawing.Point(499, 228);
            this.updatechart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updatechart.Name = "updatechart";
            this.updatechart.Size = new System.Drawing.Size(179, 65);
            this.updatechart.TabIndex = 13;
            this.updatechart.Text = "update chart";
            this.updatechart.UseVisualStyleBackColor = true;
            this.updatechart.Click += new System.EventHandler(this.updatechart_Click);
            // 
            // yearthree
            // 
            this.yearthree.AutoSize = true;
            this.yearthree.Location = new System.Drawing.Point(349, 159);
            this.yearthree.Name = "yearthree";
            this.yearthree.Size = new System.Drawing.Size(62, 21);
            this.yearthree.TabIndex = 14;
            this.yearthree.Text = "2014";
            this.yearthree.UseVisualStyleBackColor = true;
            this.yearthree.CheckedChanged += new System.EventHandler(this.yearthree_CheckedChanged);
            // 
            // yearfour
            // 
            this.yearfour.AutoSize = true;
            this.yearfour.Location = new System.Drawing.Point(349, 209);
            this.yearfour.Name = "yearfour";
            this.yearfour.Size = new System.Drawing.Size(62, 21);
            this.yearfour.TabIndex = 15;
            this.yearfour.Text = "2015";
            this.yearfour.UseVisualStyleBackColor = true;
            this.yearfour.CheckedChanged += new System.EventHandler(this.yearfour_CheckedChanged);
            // 
            // yearfive
            // 
            this.yearfive.AutoSize = true;
            this.yearfive.Location = new System.Drawing.Point(349, 253);
            this.yearfive.Name = "yearfive";
            this.yearfive.Size = new System.Drawing.Size(62, 21);
            this.yearfive.TabIndex = 16;
            this.yearfive.Text = "2016";
            this.yearfive.UseVisualStyleBackColor = true;
            this.yearfive.CheckedChanged += new System.EventHandler(this.yearfive_CheckedChanged);
            // 
            // yearsix
            // 
            this.yearsix.AutoSize = true;
            this.yearsix.Location = new System.Drawing.Point(349, 303);
            this.yearsix.Name = "yearsix";
            this.yearsix.Size = new System.Drawing.Size(62, 21);
            this.yearsix.TabIndex = 17;
            this.yearsix.Text = "2017";
            this.yearsix.UseVisualStyleBackColor = true;
            this.yearsix.CheckedChanged += new System.EventHandler(this.yearsix_CheckedChanged);
            // 
            // Vraag2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectData.Resource.MainMenuBackgroundNoText;
            this.ClientSize = new System.Drawing.Size(1707, 886);
            this.Controls.Add(this.yearsix);
            this.Controls.Add(this.yearfive);
            this.Controls.Add(this.yearfour);
            this.Controls.Add(this.yearthree);
            this.Controls.Add(this.updatechart);
            this.Controls.Add(this.yeartwo);
            this.Controls.Add(this.yearone);
            this.Controls.Add(this.checkallyears);
            this.Controls.Add(this.preventie);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Vraag2";
            ((System.ComponentModel.ISupportInitialize)(this.preventie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart preventie;
        private System.Windows.Forms.CheckBox checkallyears;
        private System.Windows.Forms.CheckBox yearone;
        private System.Windows.Forms.CheckBox yeartwo;
        private System.Windows.Forms.Button updatechart;
        private System.Windows.Forms.CheckBox yearthree;
        private System.Windows.Forms.CheckBox yearfour;
        private System.Windows.Forms.CheckBox yearfive;
        private System.Windows.Forms.CheckBox yearsix;
    }
}