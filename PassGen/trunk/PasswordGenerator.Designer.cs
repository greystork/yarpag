namespace PassGen {
	partial class PasswordGenerator {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordGenerator));
			this.chkUppercase = new System.Windows.Forms.CheckBox();
			this.chkSpecialChars = new System.Windows.Forms.CheckBox();
			this.chkNumbers = new System.Windows.Forms.CheckBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.trkLength = new System.Windows.Forms.TrackBar();
			this.chkSpecific = new System.Windows.Forms.CheckBox();
			this.cboSpecific = new System.Windows.Forms.ComboBox();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnGenerateCopy = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblPasswordCharCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.chkSpaces = new System.Windows.Forms.CheckBox();
			this.tipPasswordgenerator = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.trkLength)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkUppercase
			// 
			this.chkUppercase.AutoSize = true;
			this.chkUppercase.Checked = true;
			this.chkUppercase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUppercase.Location = new System.Drawing.Point(12, 4);
			this.chkUppercase.Name = "chkUppercase";
			this.chkUppercase.Size = new System.Drawing.Size(78, 17);
			this.chkUppercase.TabIndex = 0;
			this.chkUppercase.Text = "Uppercase";
			this.tipPasswordgenerator.SetToolTip(this.chkUppercase, "Allow passwords to contain uppercase characters.");
			this.chkUppercase.UseVisualStyleBackColor = true;
			this.chkUppercase.CheckedChanged += new System.EventHandler(this.chkUppercase_CheckedChanged);
			// 
			// chkSpecialChars
			// 
			this.chkSpecialChars.AutoSize = true;
			this.chkSpecialChars.Location = new System.Drawing.Point(12, 58);
			this.chkSpecialChars.Name = "chkSpecialChars";
			this.chkSpecialChars.Size = new System.Drawing.Size(115, 17);
			this.chkSpecialChars.TabIndex = 1;
			this.chkSpecialChars.Text = "Special Characters";
			this.tipPasswordgenerator.SetToolTip(this.chkSpecialChars, "Allow passwords to contain other special characters.\r\nDefault is a universal set " +
							"found in most keyboard layouts.");
			this.chkSpecialChars.UseVisualStyleBackColor = true;
			this.chkSpecialChars.CheckedChanged += new System.EventHandler(this.chkSpecialChars_CheckedChanged);
			// 
			// chkNumbers
			// 
			this.chkNumbers.AutoSize = true;
			this.chkNumbers.Checked = true;
			this.chkNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkNumbers.Location = new System.Drawing.Point(12, 22);
			this.chkNumbers.Name = "chkNumbers";
			this.chkNumbers.Size = new System.Drawing.Size(68, 17);
			this.chkNumbers.TabIndex = 1;
			this.chkNumbers.Text = "Numbers";
			this.tipPasswordgenerator.SetToolTip(this.chkNumbers, "Allow passwords to contain numerals.");
			this.chkNumbers.UseVisualStyleBackColor = true;
			this.chkNumbers.CheckedChanged += new System.EventHandler(this.chkNumbers_CheckedChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtPassword.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(100, 32);
			this.txtPassword.MaxLength = 256;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.ReadOnly = true;
			this.txtPassword.Size = new System.Drawing.Size(274, 22);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "password";
			this.tipPasswordgenerator.SetToolTip(this.txtPassword, "The automatically generated password.");
			// 
			// trkLength
			// 
			this.trkLength.AutoSize = false;
			this.trkLength.Location = new System.Drawing.Point(90, 4);
			this.trkLength.Margin = new System.Windows.Forms.Padding(0);
			this.trkLength.Maximum = 36;
			this.trkLength.Name = "trkLength";
			this.trkLength.Size = new System.Drawing.Size(294, 34);
			this.trkLength.TabIndex = 3;
			this.tipPasswordgenerator.SetToolTip(this.trkLength, "Move slider to change password length.");
			this.trkLength.Value = 8;
			this.trkLength.Scroll += new System.EventHandler(this.trkLength_Scroll);
			// 
			// chkSpecific
			// 
			this.chkSpecific.AutoSize = true;
			this.chkSpecific.Enabled = false;
			this.chkSpecific.Location = new System.Drawing.Point(33, 79);
			this.chkSpecific.Name = "chkSpecific";
			this.chkSpecific.Size = new System.Drawing.Size(70, 17);
			this.chkSpecific.TabIndex = 4;
			this.chkSpecific.Text = "Specific: ";
			this.tipPasswordgenerator.SetToolTip(this.chkSpecific, "Specify a specific set of special characters to allow.");
			this.chkSpecific.UseVisualStyleBackColor = true;
			this.chkSpecific.CheckedChanged += new System.EventHandler(this.chkSpecific_CheckedChanged);
			// 
			// cboSpecific
			// 
			this.cboSpecific.Enabled = false;
			this.cboSpecific.FormattingEnabled = true;
			this.cboSpecific.Location = new System.Drawing.Point(100, 77);
			this.cboSpecific.Name = "cboSpecific";
			this.cboSpecific.Size = new System.Drawing.Size(187, 21);
			this.cboSpecific.Sorted = true;
			this.cboSpecific.TabIndex = 6;
			this.tipPasswordgenerator.SetToolTip(this.cboSpecific, "Select the special character set to allow.");
			this.cboSpecific.TextChanged += new System.EventHandler(this.cboSpecific_TextChanged);
			// 
			// btnGenerate
			// 
			this.btnGenerate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnGenerate.Location = new System.Drawing.Point(293, 58);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(65, 21);
			this.btnGenerate.TabIndex = 7;
			this.btnGenerate.Text = "Generate";
			this.tipPasswordgenerator.SetToolTip(this.btnGenerate, "Generate a different password.");
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(293, 78);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(65, 21);
			this.btnCopy.TabIndex = 7;
			this.btnCopy.Text = "Copy";
			this.tipPasswordgenerator.SetToolTip(this.btnCopy, "Copy current password to clipboard.");
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnGenerateCopy
			// 
			this.btnGenerateCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGenerateCopy.Location = new System.Drawing.Point(357, 58);
			this.btnGenerateCopy.Name = "btnGenerateCopy";
			this.btnGenerateCopy.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.btnGenerateCopy.Size = new System.Drawing.Size(18, 41);
			this.btnGenerateCopy.TabIndex = 7;
			this.btnGenerateCopy.Text = "+";
			this.tipPasswordgenerator.SetToolTip(this.btnGenerateCopy, "Generate a new password and copy it to clipboard.");
			this.btnGenerateCopy.UseVisualStyleBackColor = true;
			this.btnGenerateCopy.Click += new System.EventHandler(this.btnGenerateCopy_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPasswordCharCount,
            this.lblStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 108);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.ShowItemToolTips = true;
			this.statusStrip1.Size = new System.Drawing.Size(386, 23);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "staPasswordGenerator";
			// 
			// lblPasswordCharCount
			// 
			this.lblPasswordCharCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblPasswordCharCount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPasswordCharCount.Name = "lblPasswordCharCount";
			this.lblPasswordCharCount.Size = new System.Drawing.Size(109, 18);
			this.lblPasswordCharCount.Tag = " {0,3:D} Characters";
			this.lblPasswordCharCount.Text = "  8 Characters";
			this.lblPasswordCharCount.ToolTipText = "The number of password characters generated.";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(59, 18);
			this.lblStatus.Tag = "Clipboard: ";
			this.lblStatus.Text = "Clipboard: ";
			// 
			// chkSpaces
			// 
			this.chkSpaces.AutoSize = true;
			this.chkSpaces.Location = new System.Drawing.Point(12, 40);
			this.chkSpaces.Name = "chkSpaces";
			this.chkSpaces.Size = new System.Drawing.Size(62, 17);
			this.chkSpaces.TabIndex = 9;
			this.chkSpaces.Text = "Spaces";
			this.tipPasswordgenerator.SetToolTip(this.chkSpaces, "Allow passwords to contain spaces.");
			this.chkSpaces.UseVisualStyleBackColor = true;
			this.chkSpaces.CheckedChanged += new System.EventHandler(this.chkSpaces_CheckedChanged);
			// 
			// PasswordGenerator
			// 
			this.AcceptButton = this.btnGenerateCopy;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnGenerate;
			this.ClientSize = new System.Drawing.Size(386, 131);
			this.Controls.Add(this.chkSpaces);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.btnGenerateCopy);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.cboSpecific);
			this.Controls.Add(this.chkSpecific);
			this.Controls.Add(this.trkLength);
			this.Controls.Add(this.chkNumbers);
			this.Controls.Add(this.chkSpecialChars);
			this.Controls.Add(this.chkUppercase);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1024, 165);
			this.MinimumSize = new System.Drawing.Size(280, 165);
			this.Name = "PasswordGenerator";
			this.Text = "Random Password Generator";
			this.Activated += new System.EventHandler(this.PasswordGenerator_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordGenerator_FormClosing);
			this.Resize += new System.EventHandler(this.PasswordGenerator_Resize);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PasswordGenerator_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.trkLength)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkUppercase;
		private System.Windows.Forms.CheckBox chkSpecialChars;
		private System.Windows.Forms.CheckBox chkNumbers;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TrackBar trkLength;
		private System.Windows.Forms.CheckBox chkSpecific;
		private System.Windows.Forms.ComboBox cboSpecific;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnGenerateCopy;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripStatusLabel lblPasswordCharCount;
		private System.Windows.Forms.CheckBox chkSpaces;
		private System.Windows.Forms.ToolTip tipPasswordgenerator;
	}
}

