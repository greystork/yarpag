using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PassGen {

	public partial class PasswordGenerator : Form {

		public const int DefaultPasswordLength = 8;

		private int btnGenerateDeltaX;
		private int btnCopyDeltaX;
		private int btnGenerateCopyDeltaX;
		private int trkLengthMarginWidth;
		private int txtPasswordDeltaWidth;
		private int cboSpecificDeltaWidth;
		private int txtPasswordHorizontalMargin;
		private int charPixelWidth;
		private int passwordLength;
		private int moveCount;
		private double seed;

		private string letters = "abcdefghijklmnopqrstuvwxyz";
		private string capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private string numerals = "0123456789";
		private string whitespace = " ";

		private ResourceSet specialCharResources = SpecialCharacters.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

		public PasswordGenerator() {

			moveCount = 1;
			seed = DateTime.Now.Ticks;

			InitializeComponent();

			int thisWidth = this.Width;

			this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, this.MaximumSize.Height);

			btnGenerateDeltaX = thisWidth - btnGenerate.Location.X;
			btnCopyDeltaX = thisWidth - btnCopy.Location.X;
			btnGenerateCopyDeltaX = thisWidth - btnGenerateCopy.Location.X;
			txtPasswordDeltaWidth = thisWidth - txtPassword.Width;
			cboSpecificDeltaWidth = thisWidth - cboSpecific.Width;

			charPixelWidth = GetCharPixelWidth();
			txtPasswordHorizontalMargin = txtPassword.Margin.Horizontal;
			passwordLength = DefaultPasswordLength;

			int widthChars = (txtPassword.Width - txtPasswordHorizontalMargin) / charPixelWidth;
			int maxStringWidth = widthChars * charPixelWidth;
			
			trkLengthMarginWidth = trkLength.Width - maxStringWidth - 3; // Don't know where the minus 3 come from...

			foreach (DictionaryEntry entry in specialCharResources)
				cboSpecific.Items.Add(entry.Key.ToString());

			cboSpecific.SelectedItem = "Universal";

			seed = DateTime.Now.Ticks / seed;
			Generate();
			DoResize();
		}

		private int GetCharPixelWidth() {

			string testString = "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
			Graphics graphics = txtPassword.CreateGraphics();

			SizeF stringSize = graphics.MeasureString(testString, txtPassword.Font);
			float charWidth = stringSize.Width / testString.Length;

			graphics.Dispose();

			return (int)charWidth;
		}

		private void DoResize() {

			this.SuspendLayout();

			int thisWidth = this.Width;
			int txtPasswordWidth = thisWidth - txtPasswordDeltaWidth;
			int widthChars = (txtPasswordWidth - txtPasswordHorizontalMargin) / charPixelWidth;

			if (widthChars < passwordLength) {
				txtPassword.Text = txtPassword.Text.Remove(widthChars);
				trkLength.Value = widthChars;
				passwordLength = widthChars;
			}
			txtPassword.Width = txtPasswordWidth;
			txtPassword.MaxLength = widthChars;
			trkLength.Width = trkLengthMarginWidth + (widthChars * charPixelWidth);
			trkLength.Maximum = widthChars;

			cboSpecific.Width = thisWidth - cboSpecificDeltaWidth;
			cboSpecific.SelectionLength = 0;

			btnGenerate.Location = new Point(thisWidth - btnGenerateDeltaX, btnGenerate.Location.Y);
			btnCopy.Location = new Point(btnGenerate.Location.X, btnCopy.Location.Y);
			btnGenerateCopy.Location = new Point(thisWidth - btnGenerateCopyDeltaX, btnGenerateCopy.Location.Y);

			this.ResumeLayout(true);

			trkLength.Focus();
		}

		private string GetRandomPassword(int length) {

			return GetRandomPassword(length, false, false, false, String.Empty);
		}

		private string GetRandomPassword(int length, bool uppercase) {

			return GetRandomPassword(length, uppercase, false, false, String.Empty);
		}

		private string GetRandomPassword(int length, bool uppercase, bool numbers) {

			return GetRandomPassword(length, uppercase, numbers, false, String.Empty);
		}

		private string GetRandomPassword(int length, bool uppercase, bool numbers, bool spaces) {

			return GetRandomPassword(length, uppercase, numbers, spaces, String.Empty);
		}

		private string GetRandomPassword(int length, bool uppercase, bool numbers, bool spaces, string specials) {

			string password = String.Empty;
			char character;
			int index;

			string validChars = letters;

			if (uppercase)
				validChars += capitals;

			if (numbers)
				validChars += numerals;

			if (spaces)
				validChars += whitespace;

			validChars += specials;

			seed -= Math.Truncate(seed); // Get value greater than -1 and less than 1.

			Random randomizer = new Random((int)(seed * int.MinValue));

			char[] validCharArray = validChars.ToCharArray();

			while (length > 0) {

				index = randomizer.Next(0, validCharArray.Length);
				character = validCharArray[index];
				password += character;
				--length;
			}
			seed = randomizer.NextDouble();

			return password;
		}

		private void Generate() {

			string specialCharString = GetSpecialCharString();

			txtPassword.Text = GetRandomPassword(passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkSpaces.Checked, specialCharString);
		}

		private string GetSpecialCharString() {

			string specialCharString = String.Empty;

			if (chkSpecialChars.Checked) {
				if (chkSpecific.Enabled && chkSpecific.Checked && cboSpecific.SelectedIndex >= 0)
					specialCharString = specialCharResources.GetString(cboSpecific.SelectedItem.ToString());
				else {
					specialCharString = SpecialCharacters.Universal;
					if (cboSpecific.Text == String.Empty)
						cboSpecific.SelectedItem = "Universal";
				}
			}
			return specialCharString;
		}

		private void Copy() {

			Clipboard.SetText(txtPassword.Text);
			UpdateStatusText();
		}

		private void UpdateStatusText() {

			string clipboardText = Clipboard.GetText();
			string clipboardLine = clipboardText.Split(new char[] { '\r', '\n' })[0];

			lblStatus.Text = lblStatus.Tag.ToString() + clipboardLine;
			lblStatus.ToolTipText = clipboardText;
			lblPasswordCharCount.Text = String.Format(lblPasswordCharCount.Tag.ToString(), passwordLength);
			trkLength.Focus();
		}

		private void PasswordGenerator_Activated(object sender, EventArgs e) {

			UpdateStatusText();
		}

		private void PasswordGenerator_FormClosing(object sender, FormClosingEventArgs e) {

			// Put future code for saving user-defined special characters here.
		}

		private void chkUppercase_CheckedChanged(object sender, EventArgs e) {

			Generate();
		}

		private void chkNumbers_CheckedChanged(object sender, EventArgs e) {

			Generate();
		}

		private void chkSpaces_CheckedChanged(object sender, EventArgs e) {

			Generate();
		}

		private void chkSpecialChars_CheckedChanged(object sender, EventArgs e) {

			Generate();
			chkSpecific.Enabled = chkSpecialChars.Checked;
			cboSpecific.Enabled = chkSpecialChars.Checked && chkSpecific.Checked;
		}

		private void chkSpecific_CheckedChanged(object sender, EventArgs e) {

			Generate();
			cboSpecific.Enabled = chkSpecialChars.Checked && chkSpecific.Checked;
		}

		private void cboSpecific_TextChanged(object sender, EventArgs e) {

			if (cboSpecific.Text == String.Empty)
				cboSpecific.SelectedItem = "Universal";

			Generate();
		}

		private void trkLength_Scroll(object sender, EventArgs e) {

			if (passwordLength > trkLength.Value)
				txtPassword.Text = txtPassword.Text.Remove(trkLength.Value);
			else if (passwordLength < trkLength.Value) {
				string specialCharString = GetSpecialCharString();
				string passwordChars = GetRandomPassword(trkLength.Value - passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkSpaces.Checked, specialCharString);

				txtPassword.Text += passwordChars;
			}
			passwordLength = trkLength.Value;
			UpdateStatusText();
		}

		private void btnGenerate_Click(object sender, EventArgs e) {

			Generate();
		}

		private void btnCopy_Click(object sender, EventArgs e) {

			Copy();
		}

		private void btnGenerateCopy_Click(object sender, EventArgs e) {

			Generate();
			Copy();
		}

		private void PasswordGenerator_Resize(object sender, EventArgs e) {

			DoResize();
		}

		private void PasswordGenerator_MouseMove(object sender, MouseEventArgs e) {

			if (--moveCount <= 0) {

				moveCount = (int)(DateTime.Now.Ticks % 16);

				try {
					if (moveCount % 2 == 0 && e.Y != 0) {
						double fraction = ((seed / e.Y) + e.Y);
						if (e.X % 2 == 1)
							seed += fraction;
						else
							seed -= fraction;
					}
					else if (e.X != 0) {
						if (e.Y % 2 == 0)
							seed *= e.X;
						else
							seed /= e.X;
					}
				}
				catch (Exception) {
					seed -= Math.Truncate(seed);
				}
			}
		}
	}
}