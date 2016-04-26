namespace BMI_Calculator
{
	partial class BMI_Calculator
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
			this.label1 = new System.Windows.Forms.Label();
			this.AnotherCalculation = new System.Windows.Forms.GroupBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.inputWeight = new System.Windows.Forms.TextBox();
			this.inputHeight = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.CalculateBMI_button = new System.Windows.Forms.Button();
			this.AnotherCalculation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(270, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Body Mass Index Calculator";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// AnotherCalculation
			// 
			this.AnotherCalculation.Controls.Add(this.radioButton2);
			this.AnotherCalculation.Controls.Add(this.radioButton1);
			this.AnotherCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AnotherCalculation.Location = new System.Drawing.Point(48, 162);
			this.AnotherCalculation.Name = "AnotherCalculation";
			this.AnotherCalculation.Size = new System.Drawing.Size(200, 60);
			this.AnotherCalculation.TabIndex = 1;
			this.AnotherCalculation.TabStop = false;
			this.AnotherCalculation.Text = "Another Calculation?";
			this.AnotherCalculation.Visible = false;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(27, 25);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(58, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Yes";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(111, 25);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(49, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "No";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// inputWeight
			// 
			this.inputWeight.Location = new System.Drawing.Point(33, 83);
			this.inputWeight.Name = "inputWeight";
			this.inputWeight.Size = new System.Drawing.Size(100, 20);
			this.inputWeight.TabIndex = 2;
			// 
			// inputHeight
			// 
			this.inputHeight.Location = new System.Drawing.Point(159, 83);
			this.inputHeight.Name = "inputHeight";
			this.inputHeight.Size = new System.Drawing.Size(100, 20);
			this.inputHeight.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(29, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Weight (kg)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(155, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Height (m)";
			// 
			// CalculateBMI_button
			// 
			this.CalculateBMI_button.Location = new System.Drawing.Point(33, 109);
			this.CalculateBMI_button.Name = "CalculateBMI_button";
			this.CalculateBMI_button.Size = new System.Drawing.Size(226, 34);
			this.CalculateBMI_button.TabIndex = 6;
			this.CalculateBMI_button.Text = "Calculate BMI";
			this.CalculateBMI_button.UseVisualStyleBackColor = true;
			this.CalculateBMI_button.Click += new System.EventHandler(this.button1_Click);
			// 
			// BMI_Calculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(299, 243);
			this.Controls.Add(this.CalculateBMI_button);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.inputHeight);
			this.Controls.Add(this.inputWeight);
			this.Controls.Add(this.AnotherCalculation);
			this.Controls.Add(this.label1);
			this.Name = "BMI_Calculator";
			this.Text = "BMI Calculator";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.AnotherCalculation.ResumeLayout(false);
			this.AnotherCalculation.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox AnotherCalculation;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Button CalculateBMI_button;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inputHeight;
		private System.Windows.Forms.TextBox inputWeight;
	}
}

