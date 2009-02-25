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

	public partial class yarpag : Form {


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
		private int numValidChars;
		private int moveCount;
		private double seed;

		private Properties.Settings settings;

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
		public yarpag() {

			settings = Properties.Settings.Default;
			passwordLength = 8;
			numValidChars = 60;
			moveCount = 1;
			seed = DateTime.Now.Ticks;

			InitializeComponent();

			this.Text = settings.Title;
			lblPasswordCharCount.ToolTipText = settings.lblPasswordCharCountTooltip;
			chkUppercase.Text = settings.chkUppercaseText;
			chkNumbers.Text = settings.chkNumbersStart;
			chkSpaces.Text = settings.chkSpacesText;
			chkSpecialChars.Text = settings.chkSpecialCharsText;
			chkSpecific.Text = settings.chkSpecificText;
			btnGenerate.Text = settings.btnGenerateText;
			btnCopy.Text = settings.btnCopyText;
			btnGenerateCopy.Text = settings.btnGenerateCopyText;
			tipPasswordgenerator.SetToolTip(chkUppercase, settings.chkUppercaseTooltip);
			tipPasswordgenerator.SetToolTip(chkNumbers, settings.chkNumbersTooltip);
			tipPasswordgenerator.SetToolTip(chkSpaces, settings.chkSpacesTooltip);
			tipPasswordgenerator.SetToolTip(chkSpecialChars, settings.chkSpecialCharsTooltip);
			tipPasswordgenerator.SetToolTip(chkSpecific, settings.chkSpecificTooltip);
			tipPasswordgenerator.SetToolTip(cboSpecific, settings.cboSpecificTooltip);
			tipPasswordgenerator.SetToolTip(trkLength, settings.trkLengthTooltip);
			tipPasswordgenerator.SetToolTip(btnGenerate, settings.btnGenerateTooltip);
			tipPasswordgenerator.SetToolTip(btnCopy, settings.btnCopyTooltip);
			tipPasswordgenerator.SetToolTip(btnGenerateCopy, settings.btnGenerateCopyTooltip);

			for (int specIndex = 0; specIndex < settings.Keyboards.Count; ++specIndex)
				cboSpecific.Items.Add(settings.Keyboards[specIndex]);

			cboSpecific.SelectedItem = settings.Keyboards[0];

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

			trkLengthMarginWidth = trkLength.Width - maxStringWidth - 3; // Don't know where the minus 3 came from...

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

			string testString = settings.LengthTestString;
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

			string validChars = settings.Letters;

			if (uppercase)
				validChars += settings.Capitals;

			if (numbers) {
				if (eight_digit)
					validChars += settings.SafeNumerals;
				else
					validChars += settings.Numerals;
			}

			if (spaces)
				validChars += settings.Whitespace.Replace("\"", "");

			validChars += specials;
			numValidChars = validChars.Length;

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
			UpdateStatusText();

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
				string passwordChars = GetRandomPassword(trkLength.Value - passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkNumbers.CheckState == CheckState.Indeterminate, chkSpaces.Checked, specialCharString);
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

			tipPasswordgenerator.SetToolTip(txtPassword, String.Format(settings.txtPasswordTooltipFormat, DoubleToString(Math.Pow(numValidChars, passwordLength))));
			lblStatus.Text = settings.lblStatusStart + clipboardLine;
			lblStatus.ToolTipText = clipboardText;
			lblPasswordCharCount.Text = String.Format(settings.lblPasswordCharCountFormat, passwordLength);
			trkLength.Focus();
		}

		/// <summary>
		/// Convert a double precision floating point number to a descriptive string.
		/// </summary>
		/// <param name="number">Number to convert.</param>
		/// <returns>String describing input number.</returns>
		private string DoubleToString(double number) {

			if (number == 0)
				return settings.ZeroName;

			if (double.IsInfinity(number))
				return settings.InifinityName;

			if (number < 1000000)
				return number.ToString(settings.SmallNumberFormat);

			number /= 1000000f;

			int index = 1;
			int power = 6;
			string name = String.Empty;

			while (number > 1000) {
				number /= 1000f;
				++index;
				power += 3;
				if (index >= settings.NumberNames.Count) {
					name = settings.NumberNames[settings.NumberNames.Count - 1] + ' ' + name;
					index -= settings.NumberNames.Count;
				}
			}
			name = settings.NumberNames[index] + ' ' + name;

			return String.Format(settings.NumberFormat, number) + name.Trim() + String.Format(settings.PowerFormat, power);
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
					specialCharString = settings.KeyboardSpecialCharacters[cboSpecific.SelectedIndex];
				else {
					specialCharString = settings.KeyboardSpecialCharacters[0];
					cboSpecific.SelectedItem = settings.Keyboards[0];
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

			chkNumbers.Text = settings.chkNumbersStart;

			if (chkNumbers.CheckState == CheckState.Checked)
				chkNumbers.Text += settings.NumeralsName;
			else if (chkNumbers.CheckState == CheckState.Indeterminate)
				chkNumbers.Text += settings.SafeNumeralsName;

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
				cboSpecific.SelectedItem = settings.Keyboards[0];

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