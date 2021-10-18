using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class Plot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.containerControl1 = new System.Windows.Forms.ContainerControl();
            this.formsPlot3 = new ScottPlot.FormsPlot();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textN = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.containerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.containerControl1);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox4);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox3);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox2);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textN);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 805);
            this.splitContainer1.SplitterDistance = 599;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.formsPlot1);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.formsPlot2);
            this.splitContainer2.Size = new System.Drawing.Size(599, 805);
            this.splitContainer2.SplitterDistance = 393;
            this.splitContainer2.TabIndex = 0;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Location = new System.Drawing.Point(3, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(585, 355);
            this.formsPlot1.TabIndex = 0;
            this.formsPlot1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formsPlot1_MouseMove);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(3, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(593, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(3, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(593, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "label6";
            // 
            // formsPlot2
            // 
            this.formsPlot2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot2.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot2.Location = new System.Drawing.Point(4, 3);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(592, 366);
            this.formsPlot2.TabIndex = 0;
            // 
            // containerControl1
            // 
            this.containerControl1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.containerControl1.Controls.Add(this.formsPlot3);
            this.containerControl1.Controls.Add(this.label7);
            this.containerControl1.Location = new System.Drawing.Point(4, 396);
            this.containerControl1.Name = "containerControl1";
            this.containerControl1.Size = new System.Drawing.Size(544, 406);
            this.containerControl1.TabIndex = 13;
            this.containerControl1.Text = "containerControl1";
            // 
            // formsPlot3
            // 
            this.formsPlot3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot3.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot3.Location = new System.Drawing.Point(-2, 4);
            this.formsPlot3.Name = "formsPlot3";
            this.formsPlot3.Size = new System.Drawing.Size(543, 368);
            this.formsPlot3.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(-2, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(543, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "label7";
            // 
            // checkBox4
            // 
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.checkBox4.Location = new System.Drawing.Point(4, 261);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(158, 19);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "Runge-Kutta method";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.checkBox3.Location = new System.Drawing.Point(4, 236);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(167, 19);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "improved Euler’s method";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.checkBox2.Location = new System.Drawing.Point(4, 211);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(158, 19);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Euler’s method";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.checkBox1.Location = new System.Drawing.Point(4, 186);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 19);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Exact Solution";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "N";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label3.Location = new System.Drawing.Point(4, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "X";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "y0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "x0";
            // 
            // textN
            // 
            this.textN.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textN.Location = new System.Drawing.Point(3, 159);
            this.textN.Name = "textN";
            this.textN.Size = new System.Drawing.Size(545, 21);
            this.textN.TabIndex = 4;
            this.textN.Text = "5";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox1.Location = new System.Drawing.Point(3, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(545, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "8";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox2.Location = new System.Drawing.Point(3, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(545, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox3.Location = new System.Drawing.Point(3, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(545, 21);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "0";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(2, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(546, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 805);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Plot";
            this.Text = "Plot";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.containerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ScottPlot.FormsPlot formsPlot3;

        private ScottPlot.FormsPlot formsPlot2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.ContainerControl containerControl1;

        private System.Windows.Forms.Label label5;

        private ScottPlot.FormsPlot formsPlot1;

        private System.Windows.Forms.TextBox textN;

        private System.Windows.Forms.CheckBox checkBox4;

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.TextBox textBox2;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.SplitContainer splitContainer2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion
    }
}