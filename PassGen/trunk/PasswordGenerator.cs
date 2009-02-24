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


		#region Private Variables

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
		private string safe_numerals = "23456789";
		private string whitespace = " ";
		private ResourceSet specialCharResources = SpecialCharacters.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
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

		#endregion

		#region Private Methods

		/// <summary>
		/// Compute the character width of the current font for txtPassword.
		/// </summary>
		/// <remarks>
		/// For this computation to remain meaningful, 
		/// txtPassword must always be assigned a proportional font, 
		/// such as Courier New.
		/// </remarks>
		/// <returns>The character width of the current font for txtPassword in pixels.</returns>
		private int GetCharPixelWidth() {

			string testString = "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
			Graphics graphics = txtPassword.CreateGraphics();

			SizeF stringSize = graphics.MeasureString(testString, txtPassword.Font);
			float charWidth = stringSize.Width / testString.Length;

			graphics.Dispose();

			return (int)charWidth;
		}

		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length) {

			return GetRandomPassword(length, false, false, false, false, String.Empty);
		}

		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <param name="uppercase">Allow uppercase characters in password.</param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length, bool uppercase) {

			return GetRandomPassword(length, uppercase, false, false, false, String.Empty);
		}

		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <param name="uppercase">Allow uppercase characters in password.</param>
		/// <param name="numbers"Allow numerals in password.></param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length, bool uppercase, bool numbers) {

			return GetRandomPassword(length, uppercase, numbers, false, false, String.Empty);
		}

		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <param name="uppercase">Allow uppercase characters in password.</param>
		/// <param name="numbers"Allow numerals in password.></param>
		/// <param name="spaces">Allow spaces in password.</param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length, bool uppercase, bool numbers, bool eight_digit) {

			return GetRandomPassword(length, uppercase, numbers, eight_digit, false, String.Empty);
		}

		
		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <param name="uppercase">Allow uppercase characters in password.</param>
		/// <param name="numbers"Allow numerals in password.></param>
		/// <param name="spaces">Allow spaces in password.</param>
		/// <param name="specials">String containing special characterrs to allow in password.</param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length, bool uppercase, bool numbers, bool eight_digit, bool spaces) {

			return GetRandomPassword(length, uppercase, numbers, eight_digit, spaces, String.Empty);
		}

		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <param name="uppercase">Allow uppercase characters in password.</param>
		/// <param name="numbers"Allow numerals in password.></param>
		/// <param name="spaces">Allow spaces in password.</param>
		/// <param name="specials">String containing special characterrs to allow in password.</param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length, bool uppercase, bool numbers, bool eight_digit, bool spaces, string specials) {

			string password = String.Empty;
			char character;
			int index;

			string validChars = letters;

			if (uppercase)
				validChars += capitals;

			if (numbers) {
				if (eight_digit)
					validChars += safe_numerals;
				else
					validChars += numerals;
			}

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

		/// <summary>
		/// Generate a new password and display it in txtPassword.
		/// </summary>
		private void Generate() {

			string specialCharString = GetSpecialCharString();

			txtPassword.Text = GetRandomPassword(passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkNumbers.CheckState == CheckState.Indeterminate, chkSpaces.Checked, specialCharString);
		}

		/// <summary>
		/// Copy text from txtPassword to clipboard.
		/// </summary>
		private void Copy() {

			Clipboard.SetText(txtPassword.Text);
			UpdateStatusText();
		}

		/// <summary>
		/// Ressize and arrange embedded controls to fit parent form.
		/// </summary>
		private void DoResize() {

			this.SuspendLayout();

			int thisWidth = this.Width;
			int txtPasswordWidth = thisWidth - txtPasswordDeltaWidth;
			int widthChars = (txtPasswordWidth - txtPasswordHorizontalMargin) / charPixelWidth;

			if (widthChars < passwordLength) {
				trkLength.Value = widthChars;
				AdjustPasswordLength();
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

		/// <summary>
		/// Adjust password length based on the position of trkLength.
		/// </summary>
		private void AdjustPasswordLength() {

			if (passwordLength > trkLength.Value)
				txtPassword.Text = txtPassword.Text.Remove(trkLength.Value);
			else if (passwordLength < trkLength.Value) {
				string specialCharString = GetSpecialCharString();
				string passwordChars = GetRandomPassword(passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkNumbers.CheckState == CheckState.Indeterminate, chkSpaces.Checked, specialCharString);


				txtPassword.Text += passwordChars;
			}
			passwordLength = trkLength.Value;
			UpdateStatusText();
		}

		/// <summary>
		/// Update label text fields in status bar.
		/// </summary>
		private void UpdateStatusText() {

			string clipboardText = Clipboard.GetText();
			string clipboardLine = clipboardText.Split(new char[] { '\r', '\n' })[0];

			lblStatus.Text = lblStatus.Tag.ToString() + clipboardLine;
			lblPasswordCharCount.Text = String.Format(lblPasswordCharCount.Tag.ToString(), passwordLength);
			trkLength.Focus();
		}

		/// <summary>
		/// Get string containing special characters selected in cboSpecific,
		/// as defined in the SpecialCharacters resource file.
		/// </summary>
		/// <returns></returns>
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
		
		#endregion

		#region Event Handlers
		
		private void PasswordGenerator_Activated(object sender, EventArgs e) {

			UpdateStatusText(); // Refresh clipboard display.
		}

		private void PasswordGenerator_FormClosing(object sender, FormClosingEventArgs e) {

			// Put future code for saving user-defined special characters here.
		}

		private void chkUppercase_CheckedChanged(object sender, EventArgs e) {

			Generate();
		}

		private void chkNumbers_CheckStateChanged(object sender, EventArgs e) {

			chkNumbers.Text = chkNumbers.Tag.ToString();

			if (chkNumbers.CheckState == CheckState.Checked)
				chkNumbers.Text += "0-9";
			else if (chkNumbers.CheckState == CheckState.Indeterminate)
				chkNumbers.Text += "2-9";

			Generate();
		}

		private void chkSpaces_CheckedChanged(object sender, EventArgs e) {

			Generate();
		}

		private void chkSpecialChars_CheckedChanged(object sender, EventArgs e) {

			chkSpecific.Enabled = chkSpecialChars.Checked;
			cboSpecific.Enabled = chkSpecialChars.Checked && chkSpecific.Checked;
			Generate();
		}

		private void chkSpecific_CheckedChanged(object sender, EventArgs e) {

			cboSpecific.Enabled = chkSpecialChars.Checked && chkSpecific.Checked;
			Generate();
		}

		private void cboSpecific_TextChanged(object sender, EventArgs e) {

			if (cboSpecific.Text == String.Empty)
				cboSpecific.SelectedItem = "Universal";

			Generate();
		}

		private void trkLength_Scroll(object sender, EventArgs e) {

			AdjustPasswordLength();
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

		/// <summary>
		/// The form MouseMove event is used to generate seed entropy.
		/// </summary>
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

		#endregion
	}
}