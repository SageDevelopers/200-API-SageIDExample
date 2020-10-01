namespace APISampleWinFormsApp
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
			this.buttonDepartments = new System.Windows.Forms.Button();
			this.buttonPostDept = new System.Windows.Forms.Button();
			this.textBoxCode = new System.Windows.Forms.TextBox();
			this.buttonSites = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.buttonSitesAsync = new System.Windows.Forms.Button();
			this.buttonDepartmentsAsync = new System.Windows.Forms.Button();
			this.buttonPostDeptAsync = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonDepartments
			// 
			this.buttonDepartments.Location = new System.Drawing.Point(36, 83);
			this.buttonDepartments.Name = "buttonDepartments";
			this.buttonDepartments.Size = new System.Drawing.Size(144, 36);
			this.buttonDepartments.TabIndex = 0;
			this.buttonDepartments.Text = "Get Departments";
			this.buttonDepartments.UseVisualStyleBackColor = true;
			this.buttonDepartments.Click += new System.EventHandler(this.buttonDepartments_Click);
			// 
			// buttonPostDept
			// 
			this.buttonPostDept.Location = new System.Drawing.Point(36, 259);
			this.buttonPostDept.Name = "buttonPostDept";
			this.buttonPostDept.Size = new System.Drawing.Size(144, 36);
			this.buttonPostDept.TabIndex = 1;
			this.buttonPostDept.Text = "Post Dept";
			this.buttonPostDept.UseVisualStyleBackColor = true;
			this.buttonPostDept.Click += new System.EventHandler(this.buttonPostDept_Click);
			// 
			// textBoxCode
			// 
			this.textBoxCode.Location = new System.Drawing.Point(393, 265);
			this.textBoxCode.Name = "textBoxCode";
			this.textBoxCode.Size = new System.Drawing.Size(101, 20);
			this.textBoxCode.TabIndex = 2;
			this.textBoxCode.Text = "201";
			// 
			// buttonSites
			// 
			this.buttonSites.Location = new System.Drawing.Point(36, 25);
			this.buttonSites.Name = "buttonSites";
			this.buttonSites.Size = new System.Drawing.Size(144, 31);
			this.buttonSites.TabIndex = 3;
			this.buttonSites.Text = "Get Sites";
			this.buttonSites.UseVisualStyleBackColor = true;
			this.buttonSites.Click += new System.EventHandler(this.buttonSites_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(36, 151);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(671, 83);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// buttonSitesAsync
			// 
			this.buttonSitesAsync.Location = new System.Drawing.Point(203, 25);
			this.buttonSitesAsync.Name = "buttonSitesAsync";
			this.buttonSitesAsync.Size = new System.Drawing.Size(144, 31);
			this.buttonSitesAsync.TabIndex = 5;
			this.buttonSitesAsync.Text = "Get Sites Async";
			this.buttonSitesAsync.UseVisualStyleBackColor = true;
			this.buttonSitesAsync.Click += new System.EventHandler(this.buttonSitesAsync_Click);
			// 
			// buttonDepartmentsAsync
			// 
			this.buttonDepartmentsAsync.Location = new System.Drawing.Point(203, 83);
			this.buttonDepartmentsAsync.Name = "buttonDepartmentsAsync";
			this.buttonDepartmentsAsync.Size = new System.Drawing.Size(144, 36);
			this.buttonDepartmentsAsync.TabIndex = 6;
			this.buttonDepartmentsAsync.Text = "Get Departments Async";
			this.buttonDepartmentsAsync.UseVisualStyleBackColor = true;
			this.buttonDepartmentsAsync.Click += new System.EventHandler(this.buttonDepartmentsAsync_Click);
			// 
			// buttonPostDeptAsync
			// 
			this.buttonPostDeptAsync.Location = new System.Drawing.Point(203, 259);
			this.buttonPostDeptAsync.Name = "buttonPostDeptAsync";
			this.buttonPostDeptAsync.Size = new System.Drawing.Size(144, 36);
			this.buttonPostDeptAsync.TabIndex = 7;
			this.buttonPostDeptAsync.Text = "Post Dept Async";
			this.buttonPostDeptAsync.UseVisualStyleBackColor = true;
			this.buttonPostDeptAsync.Click += new System.EventHandler(this.buttonPostDeptAsync_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 335);
			this.Controls.Add(this.buttonPostDeptAsync);
			this.Controls.Add(this.buttonDepartmentsAsync);
			this.Controls.Add(this.buttonSitesAsync);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.buttonSites);
			this.Controls.Add(this.textBoxCode);
			this.Controls.Add(this.buttonPostDept);
			this.Controls.Add(this.buttonDepartments);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonDepartments;
		private System.Windows.Forms.Button buttonPostDept;
		private System.Windows.Forms.TextBox textBoxCode;
		private System.Windows.Forms.Button buttonSites;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button buttonSitesAsync;
		private System.Windows.Forms.Button buttonDepartmentsAsync;
		private System.Windows.Forms.Button buttonPostDeptAsync;
	}
}

