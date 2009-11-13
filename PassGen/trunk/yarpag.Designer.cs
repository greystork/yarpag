namespace PassGen {
	/// <summary>
	/// Yet Another Random PAssword Generator.
	/// Copyright (C) 2009  GreyStork.com
	/// 
	/// This program is free software: you can redistribute it and/or modify
	/// it under the terms of the GNU General Public License as published by
	/// the Free Software Foundation, either version 3 of the License, or
	/// (at your option) any later version.
	/// 
	/// This program is distributed in the hope that it will be useful,
	/// but WITHOUT ANY WARRANTY; without even the implied warranty of
	/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	/// GNU General Public License for more details.
	/// 
	/// You should have received a copy of the GNU General Public License
	/// along with this program.  If not, see http://www.gnu.org/licenses/.
	/// </summary>
	partial class yarpag {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yarpag));
			this.staPasswordGenerator = new System.Windows.Forms.StatusStrip();
			this.lblPasswordCharCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tipPasswordGenerator = new System.Windows.Forms.ToolTip(this.components);
			this.btnGenerateCopy = new System.Windows.Forms.Button();
			this.cboSpecific = new System.Windows.Forms.ComboBox();
			this.chkSpecific = new System.Windows.Forms.CheckBox();
			this.chkSpecialChars = new System.Windows.Forms.CheckBox();
			this.chkSpaces = new System.Windows.Forms.CheckBox();
			this.chkUppercase = new System.Windows.Forms.CheckBox();
			this.chkNumbers = new System.Windows.Forms.CheckBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.trkLength = new System.Windows.Forms.TrackBar();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.staPasswordGenerator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkLength)).BeginInit();
			this.SuspendLayout();
			// 
			// staPasswordGenerator
			// 
			this.staPasswordGenerator.BackColor = System.Drawing.Color.Transparent;
			this.staPasswordGenerator.BackgroundImage = global::PassGen.Properties.Resources.StreamerImage;
			this.staPasswordGenerator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.staPasswordGenerator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.staPasswordGenerator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPasswordCharCount,
            this.lblStatus});
			this.staPasswordGenerator.Location = new System.Drawing.Point(0, 106);
			this.staPasswordGenerator.Name = "staPasswordGenerator";
			this.staPasswordGenerator.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.staPasswordGenerator.ShowItemToolTips = true;
			this.staPasswordGenerator.Size = new System.Drawing.Size(372, 23);
			this.staPasswordGenerator.TabIndex = 8;
			// 
			// lblPasswordCharCount
			// 
			this.lblPasswordCharCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblPasswordCharCount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPasswordCharCount.Name = "lblPasswordCharCount";
			this.lblPasswordCharCount.Size = new System.Drawing.Size(102, 18);
			this.lblPasswordCharCount.Tag = "";
			this.lblPasswordCharCount.Text = "8 characters.";
			this.lblPasswordCharCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPasswordCharCount.ToolTipText = "The number of password characters generated.";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(255, 18);
			this.lblStatus.Spring = true;
			this.lblStatus.Tag = "";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnGenerateCopy
			// 
			this.btnGenerateCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGenerateCopy.Location = global::PassGen.Properties.Settings.Default.btnGenerateCopyLocation;
			this.btnGenerateCopy.Name = "btnGenerateCopy";
			this.btnGenerateCopy.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.btnGenerateCopy.Size = new System.Drawing.Size(18, 41);
			this.btnGenerateCopy.TabIndex = 8;
			this.btnGenerateCopy.Text = global::PassGen.Properties.Settings.Default.btnGenerateCopyText;
			this.tipPasswordGenerator.SetToolTip(this.btnGenerateCopy, "Generate a new password and copy it to clipboard.");
			this.btnGenerateCopy.UseVisualStyleBackColor = true;
			this.btnGenerateCopy.Click += new System.EventHandler(this.btnGenerateCopy_Click);
			// 
			// cboSpecific
			// 
			this.cboSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.cboSpecific.Enabled = global::PassGen.Properties.Settings.Default.cboSpecificEnabled;
			this.cboSpecific.FormattingEnabled = true;
			this.cboSpecific.Location = new System.Drawing.Point(100, 77);
			this.cboSpecific.Name = "cboSpecific";
			this.cboSpecific.Size = global::PassGen.Properties.Settings.Default.cboSpecificSize;
			this.cboSpecific.TabIndex = 5;
			this.cboSpecific.Text = global::PassGen.Properties.Settings.Default.cboSpecificText;
			this.tipPasswordGenerator.SetToolTip(this.cboSpecific, "Select the special character set to allow.");
			this.cboSpecific.EnabledChanged += new System.EventHandler(this.cboSpecific_EnabledChanged);
			this.cboSpecific.Leave += new System.EventHandler(this.cboSpecific_Leave);
			this.cboSpecific.SelectedValueChanged += new System.EventHandler(this.cboSpecific_SelectedValueChanged);
			this.cboSpecific.TextChanged += new System.EventHandler(this.cboSpecific_TextChanged);
			// 
			// chkSpecific
			// 
			this.chkSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkSpecific.AutoSize = true;
			this.chkSpecific.BackColor = System.Drawing.Color.Transparent;
			this.chkSpecific.CheckState = global::PassGen.Properties.Settings.Default.chkSpecificCheckState;
			this.chkSpecific.Enabled = global::PassGen.Properties.Settings.Default.chkSpecificEnabled;
			this.chkSpecific.Location = new System.Drawing.Point(33, 79);
			this.chkSpecific.Name = "chkSpecific";
			this.chkSpecific.Size = new System.Drawing.Size(70, 17);
			this.chkSpecific.TabIndex = 4;
			this.chkSpecific.Text = global::PassGen.Properties.Settings.Default.chkSpecificText;
			this.tipPasswordGenerator.SetToolTip(this.chkSpecific, "Specify a specific set of special characters to allow.");
			this.chkSpecific.UseVisualStyleBackColor = false;
			this.chkSpecific.CheckStateChanged += new System.EventHandler(this.chkSpecific_CheckStateChanged);
			// 
			// chkSpecialChars
			// 
			this.chkSpecialChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkSpecialChars.AutoSize = true;
			this.chkSpecialChars.BackColor = System.Drawing.Color.Transparent;
			this.chkSpecialChars.CheckState = global::PassGen.Properties.Settings.Default.chkSpecialCharsCheckState;
			this.chkSpecialChars.Location = new System.Drawing.Point(12, 58);
			this.chkSpecialChars.Name = "chkSpecialChars";
			this.chkSpecialChars.Size = new System.Drawing.Size(115, 17);
			this.chkSpecialChars.TabIndex = 3;
			this.chkSpecialChars.Text = global::PassGen.Properties.Settings.Default.chkSpecialCharsText;
			this.tipPasswordGenerator.SetToolTip(this.chkSpecialChars, "Allow passwords to contain other special characters.\r\nDefault is a universal set " +
							"found in most keyboard layouts.");
			this.chkSpecialChars.UseVisualStyleBackColor = false;
			this.chkSpecialChars.CheckStateChanged += new System.EventHandler(this.chkSpecialChars_CheckStateChanged);
			// 
			// chkSpaces
			// 
			this.chkSpaces.AutoSize = true;
			this.chkSpaces.BackColor = System.Drawing.Color.Transparent;
			this.chkSpaces.CheckState = global::PassGen.Properties.Settings.Default.chkSpacesCheckState;
			this.chkSpaces.Location = new System.Drawing.Point(12, 40);
			this.chkSpaces.Name = "chkSpaces";
			this.chkSpaces.Size = new System.Drawing.Size(62, 17);
			this.chkSpaces.TabIndex = 2;
			this.chkSpaces.Text = global::PassGen.Properties.Settings.Default.chkSpacesText;
			this.tipPasswordGenerator.SetToolTip(this.chkSpaces, "Allow passwords to contain spaces.");
			this.chkSpaces.UseVisualStyleBackColor = false;
			this.chkSpaces.CheckStateChanged += new System.EventHandler(this.chkSpaces_CheckStateChanged);
			// 
			// chkUppercase
			// 
			this.chkUppercase.AutoSize = true;
			this.chkUppercase.BackColor = System.Drawing.Color.Transparent;
			this.chkUppercase.Checked = true;
			this.chkUppercase.CheckState = global::PassGen.Properties.Settings.Default.chkUppercaseCheckState;
			this.chkUppercase.Location = new System.Drawing.Point(12, 4);
			this.chkUppercase.Name = "chkUppercase";
			this.chkUppercase.Size = new System.Drawing.Size(78, 17);
			this.chkUppercase.TabIndex = 0;
			this.chkUppercase.Text = global::PassGen.Properties.Settings.Default.chkUppercaseText;
			this.tipPasswordGenerator.SetToolTip(this.chkUppercase, "Allow passwords to contain uppercase characters.");
			this.chkUppercase.UseVisualStyleBackColor = false;
			this.chkUppercase.CheckStateChanged += new System.EventHandler(this.chkUppercase_CheckStateChanged);
			// 
			// chkNumbers
			// 
			this.chkNumbers.AutoSize = true;
			this.chkNumbers.BackColor = System.Drawing.Color.Transparent;
			this.chkNumbers.Checked = true;
			this.chkNumbers.CheckState = global::PassGen.Properties.Settings.Default.chkNumbersCheckState;
			this.chkNumbers.Location = new System.Drawing.Point(12, 22);
			this.chkNumbers.Name = "chkNumbers";
			this.chkNumbers.Size = new System.Drawing.Size(86, 17);
			this.chkNumbers.TabIndex = 1;
			this.chkNumbers.Tag = "Numbers ";
			this.chkNumbers.Text = global::PassGen.Properties.Settings.Default.chkNumbersText;
			this.chkNumbers.ThreeState = true;
			this.tipPasswordGenerator.SetToolTip(this.chkNumbers, "Allow passwords to contain numerals, including or excluding zero and one.");
			this.chkNumbers.UseVisualStyleBackColor = false;
			this.chkNumbers.CheckStateChanged += new System.EventHandler(this.chkNumbers_CheckStateChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtPassword.Font = global::PassGen.Properties.Settings.Default.txtPasswordFont;
			this.txtPassword.Location = new System.Drawing.Point(100, 31);
			this.txtPassword.MaxLength = 256;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.ReadOnly = true;
			this.txtPassword.Size = global::PassGen.Properties.Settings.Default.txtPasswordSize;
			this.txtPassword.TabIndex = 9;
			this.txtPassword.TabStop = false;
			this.txtPassword.Tag = "This password is one of {0} possible combinations.";
			this.txtPassword.Text = global::PassGen.Properties.Settings.Default.txtPasswordText;
			this.tipPasswordGenerator.SetToolTip(this.txtPassword, "Clipboard: ");
			this.txtPassword.WordWrap = false;
			this.txtPassword.FontChanged += new System.EventHandler(this.txtPassword_FontChanged);
			this.txtPassword.SizeChanged += new System.EventHandler(this.txtPassword_SizeChanged);
			// 
			// trkLength
			// 
			this.trkLength.AutoSize = false;
			this.trkLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(228)))), ((int)(((byte)(221)))));
			this.trkLength.Location = new System.Drawing.Point(89, 3);
			this.trkLength.Margin = new System.Windows.Forms.Padding(0);
			this.trkLength.Maximum = 37;
			this.trkLength.Name = "trkLength";
			this.trkLength.Size = global::PassGen.Properties.Settings.Default.trkLengthSize;
			this.trkLength.TabIndex = 0;
			this.trkLength.TabStop = false;
			this.tipPasswordGenerator.SetToolTip(this.trkLength, "Move slider to change password length.");
			this.trkLength.Value = global::PassGen.Properties.Settings.Default.PasswordLength;
			this.trkLength.Scroll += new System.EventHandler(this.trkLength_Scroll);
			// 
			// btnCopy
			// 
			this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopy.Location = global::PassGen.Properties.Settings.Default.btnCopyLocation;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(65, 21);
			this.btnCopy.TabIndex = 7;
			this.btnCopy.Text = global::PassGen.Properties.Settings.Default.btnCopyText;
			this.tipPasswordGenerator.SetToolTip(this.btnCopy, "Copy current password to clipboard.");
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnGenerate.Location = global::PassGen.Properties.Settings.Default.btnGenerateLocation;
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(65, 21);
			this.btnGenerate.TabIndex = 6;
			this.btnGenerate.Text = global::PassGen.Properties.Settings.Default.btnGenerateText;
			this.tipPasswordGenerator.SetToolTip(this.btnGenerate, "Generate a different password.");
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// yarpag
			// 
			this.AcceptButton = this.btnGenerateCopy;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(228)))), ((int)(((byte)(221)))));
			this.ClientSize = new System.Drawing.Size(372, 129);
			this.Controls.Add(this.cboSpecific);
			this.Controls.Add(this.chkSpecific);
			this.Controls.Add(this.chkSpecialChars);
			this.Controls.Add(this.chkSpaces);
			this.Controls.Add(this.chkUppercase);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.chkNumbers);
			this.Controls.Add(this.trkLength);
			this.Controls.Add(this.staPasswordGenerator);
			this.Controls.Add(this.btnGenerateCopy);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnGenerate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Location = global::PassGen.Properties.Settings.Default.Location;
			this.MaximumSize = new System.Drawing.Size(1024, 165);
			this.MinimumSize = new System.Drawing.Size(280, 165);
			this.Name = "yarpag";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "yarpag";
			this.staPasswordGenerator.ResumeLayout(false);
			this.staPasswordGenerator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkLength)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkUppercase;
		private System.Windows.Forms.CheckBox chkSpecialChars;
		private System.Windows.Forms.CheckBox chkNumbers;
		private System.Windows.Forms.TrackBar trkLength;
		private System.Windows.Forms.CheckBox chkSpecific;
		private System.Windows.Forms.ComboBox cboSpecific;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnGenerateCopy;
		private System.Windows.Forms.StatusStrip staPasswordGenerator;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripStatusLabel lblPasswordCharCount;
		private System.Windows.Forms.CheckBox chkSpaces;
		private System.Windows.Forms.ToolTip tipPasswordGenerator;
		private System.Windows.Forms.TextBox txtPassword;
	}
}

