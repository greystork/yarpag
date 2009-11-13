using System;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace PassGen {
	/// <summary>
	/// Yet Another Random PAssword Generator.
	/// Copyright (C) 2009  Torben K. Jensen
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
	public partial class yarpag : Form {

		#region Private Variables

		/// <summary>
		/// Keeps track of form window minimize/maximize status.
		/// </summary>
		private FormWindowState previousState;
		/// <summary>
		/// Number of characters in password.
		/// </summary>
		private int passwordLength;
		/// <summary>
		/// Trackbar padding.
		/// </summary>
		private int trkLengthHorizontalPadding;
		/// <summary>
		/// Count of characters that may appear in password,
		/// based on user selections.
		/// </summary>
		private int numValidChars;
		/// <summary>
		/// Variable used for entropy generation.
		/// </summary>
		private int moveCount;
		/// <summary>
		/// Seed variable used for randomization.
		/// </summary>
		private double seed;
		/// <summary>
		/// Indicates whether form window size and location changes are saved in settings.
		/// </summary>
		private bool writeBoundsSettings = false;
		/// <summary>
		/// Shortcut variable for settings.
		/// </summary>
		private Properties.Settings settings;
		/// <summary>
		/// Shortcut variable for application version.
		/// </summary>
		private Version version;

		#endregion .Private Variables

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Yet Another Random PAssword Generator (yarpag) class.
		/// </summary>
		public yarpag() {

			// Initialize a bunch of private variables.
			seed = DateTime.Now.Ticks;
			version = Assembly.GetExecutingAssembly().GetName().Version;
			settings = Properties.Settings.Default;
			passwordLength = settings.PasswordLength;
			moveCount = 1;
			
			InitializeComponent();
			// Write-enable form bounds settings during resizing.
			writeBoundsSettings = true;
			// Find trackbar padding, assuming that txtPassword.Margin is used as text padding inside TextBox control..
			trkLengthHorizontalPadding = trkLength.Width - (txtPassword.ClientSize.Width - txtPassword.Margin.Horizontal);
			// Hook system event to detect screen resolution changes.
			SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
			// Initialize dependent settings:
			SystemEvents_DisplaySettingsChanged(this, EventArgs.Empty);
			previousState = this.WindowState;
			// Restore bounds settings.
			this.Location = settings.Location;
			this.Size = settings.Size;

			// Set title.
			this.Text = String.Format("{0} v{1}.{2}", Application.ProductName, version.Major, version.Minor);
			// Add special character set names to combobox.
			for (int specIndex = 0; specIndex < settings.Keyboards.Count; ++specIndex)
				cboSpecific.Items.Add(settings.Keyboards[specIndex]);
			// Select the default special character set.
			cboSpecific.SelectedIndex = 0;
		}

		#endregion .Constructors

		#region Protected Methods

		/// <summary>
		/// Initializations to perform when form turns visible.
		/// </summary>
		protected override void OnShown(EventArgs e) {

			UpdateTrackBar();

			seed = DateTime.Now.Ticks / seed;
			Generate();

			base.OnShown(e);
		}

		/// <summary>
		/// Update clipboard display whenever application receives focus.
		/// </summary>
		protected override void OnActivated(EventArgs e) {

			UpdateStatusText(); // Refresh clipboard display.

			base.OnActivated(e);
		}

		/// <summary>
		/// Update status text if any selected text is copied to clipboard.
		/// </summary>
		protected override void OnKeyUp(KeyEventArgs e) {
			
			base.OnKeyUp(e);

			if (e.Modifiers == Keys.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.Insert))
				UpdateStatusText();
		}

		/// <summary>
		/// The form MouseMove event is used to generate seed entropy.
		/// The code aims at maximizing chaotic behavior through 
		/// arbitrarily selected amplification of small arbitrary changes.
		/// </summary>
		protected override void OnMouseMove(MouseEventArgs e) {

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

			base.OnMouseMove(e);
		}

		/// <summary>
		/// Provide persistent bounds settings for form window restore.
		/// </summary>
		protected override void OnResize(EventArgs e) {

			base.OnResize(e);

			if (this.WindowState == FormWindowState.Normal) {
				if (previousState != FormWindowState.Normal) { // Restore size and position.
					Location = settings.Location;
					Size = settings.Size;
				}
				else if (writeBoundsSettings) { // Save size and position.
					settings.Location = Location;
					settings.Size = Size;
				}
			}
			previousState = this.WindowState;
		}

		/// <summary>
		/// Make sure the correct values are saved in user settings on exit.
		/// </summary>
		protected override void OnClosing(CancelEventArgs e) {

			// Freeze form bounds settings.
			writeBoundsSettings = false;

			if (this.WindowState != FormWindowState.Normal)
				this.WindowState = FormWindowState.Normal; // Restore form window.

			settings.PasswordLength = passwordLength;
			settings.Save();

			base.OnClosing(e);
		}

		#endregion .Protected Methods

		#region Private Methods

		#region Event Handlers

		#region System Events

		// Handle display setting changes.
		private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e) {

			this.MaximumSize = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width, this.MaximumSize.Height);
		}

		#endregion .System Events

		// Depending on state, set the label text.
		// Settings have changed; generate new password.
		private void chkNumbers_CheckStateChanged(object sender, EventArgs e) {

			chkNumbers.Text = settings.chkNumbersStart;

			if (chkNumbers.CheckState == CheckState.Checked)
				chkNumbers.Text += settings.NumeralsName; // 0-9
			else if (chkNumbers.CheckState == CheckState.Indeterminate)
				chkNumbers.Text += settings.SafeNumeralsName; // 2-9

			Generate();
		}

		// Password settings have changed; generate new password.
		private void chkUppercase_CheckStateChanged(object sender, EventArgs e) {

			Generate();
		}

		// Password settings have changed; generate new password.
		private void chkSpaces_CheckStateChanged(object sender, EventArgs e) {

			Generate();
		}

		// Enable or disable 'Specific' special character controls based on new state.
		// Password settings have changed; generate new password.
		private void chkSpecialChars_CheckStateChanged(object sender, EventArgs e) {

			chkSpecific.Enabled = chkSpecialChars.Checked;
			cboSpecific.Enabled = chkSpecialChars.Checked && chkSpecific.Checked;
			Generate();
		}

		// Enable or disable 'Specific' special character set combobox based on 'Special Characters' checkbox and new states.
		// Password settings have changed; generate new password.
		private void chkSpecific_CheckStateChanged(object sender, EventArgs e) {

			cboSpecific.Enabled = chkSpecialChars.Checked && chkSpecific.Checked;
			if (cboSpecific.SelectedIndex > 0)
				Generate();
		}

		// When cboSpecific is enabled or disabled, revert to default combobox selection.
		private void cboSpecific_EnabledChanged(object sender, EventArgs e) {

			cboSpecific.SelectedItem = settings.Keyboards[0];
		}

		// Password settings have changed; generate new password.
		private void cboSpecific_TextChanged(object sender, EventArgs e) {

			// Select any matching keyboard definition.
			if (settings.Keyboards.Contains(cboSpecific.Text))
				cboSpecific.SelectedItem = cboSpecific.Text;

			Generate();
		}

		// Upon user edit, if text is an empty string, reset 'Specific'
		// special character set combobox selection to default;
		// otherwise, set to any mathcing keyboard definition.
		private void cboSpecific_Leave(object sender, EventArgs e) {

			if (cboSpecific.Text == String.Empty)
				cboSpecific.SelectedItem = settings.Keyboards[0];
			else
				cboSpecific.SelectedItem = cboSpecific.Text;
		}

		// When selecting am item in the drop-down list, fire the focus 'Leave' event.
		private void cboSpecific_SelectedValueChanged(object sender, EventArgs e) {

			if (cboSpecific.Enabled)
				Generate();
		}

		// Adjust password length based on the position of trackbar slider.
		private void trkLength_Scroll(object sender, EventArgs e) {

			AdjustPasswordLength();
		}

		// Generate new password.
		private void btnGenerate_Click(object sender, EventArgs e) {

			Generate();
		}

		// Copy text from password text control to clipboard.
		private void btnCopy_Click(object sender, EventArgs e) {

			Copy();
		}

		// Generate new password and copy text from password text control to clipboard.
		private void btnGenerateCopy_Click(object sender, EventArgs e) {

			trkLength.Focus();
			Generate();
			Copy();
		}

		// Update trackbar properties based on password text control metrics.
		private void txtPassword_FontChanged(object sender, EventArgs e) {

			UpdateTrackBar();
		}

		// Update trackbar properties based on password text control metrics.
		private void txtPassword_SizeChanged(object sender, EventArgs e) {

			UpdateTrackBar();
		}

		#endregion .Event Handlers

		/// <summary>
		/// Update trackbar properties based on password text control metrics.
		/// </summary>
		private void UpdateTrackBar() {

			// Compensation for discrepancy between how graphics.MeasureString()
			// and System.Windows.Forms.TextBox render text strings.
			double compensation = 154f / 150;

			double charPixelWidth = GetCharPixelWidth() * compensation;

			if (charPixelWidth > 0) {
				this.SuspendLayout();

				int maxChars = (int)((txtPassword.ClientSize.Width - txtPassword.Margin.Horizontal) / charPixelWidth);

				// Rescaled to less than password text width?
				if (maxChars < passwordLength) {
					trkLength.Value = maxChars;
					AdjustPasswordLength();
				}
				trkLength.Width = (int)Math.Round(maxChars * charPixelWidth) + trkLengthHorizontalPadding;
				trkLength.Maximum = maxChars;

				this.ResumeLayout();
			}
		}

		/// <summary>
		/// Compute the character width of the current font for password text control.
		/// </summary>
		/// <remarks>
		/// For this computation to remain meaningful, 
		/// txtPassword must always be assigned a proportional font, 
		/// such as Courier New.
		/// </remarks>
		/// <returns>The character width of the current font for txtPassword in pixels.</returns>
		private double GetCharPixelWidth() {

			string testString = settings.LengthTestString;
			// Test string character count must be an even number!
			int halfTestStringCharCount = testString.Length / 2;
			Graphics graphics = txtPassword.CreateGraphics();
			graphics.PageUnit = GraphicsUnit.Pixel;
			SizeF testStringSize = graphics.MeasureString(testString, txtPassword.Font);
			SizeF halfTestStringSize = graphics.MeasureString(testString.Substring(0, halfTestStringCharCount), txtPassword.Font);
			// Assuming that margin component is the same for halfTestStringSize and testStringSize:
			double margin = (halfTestStringSize.Width * 2) - testStringSize.Width;
			double charWidth = (testStringSize.Width - margin) / testString.Length;

			graphics.Dispose();
			Debug.Print("CharPixelWidth: " + charWidth.ToString());
			return charWidth;
		}

		/// <summary>
		/// Generate a new password and display it in password text control.
		/// </summary>
		private void Generate() {

			string specialCharString = GetSpecialCharString();

			txtPassword.Text = GetRandomPassword(passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkNumbers.CheckState == CheckState.Indeterminate, chkSpaces.Checked, specialCharString);
		}

		/// <summary>
		/// Generate a random password.
		/// </summary>
		/// <param name="length">Length of password to generate.</param>
		/// <param name="uppercase">Allow uppercase characters in password.</param>
		/// <param name="numbers">Allow numerals in password.</param>
		/// <param name="eight_digit">Allow only numbers 2-9 to avoid confusion with capital oh and lowercase ell.</param>
		/// <param name="spaces">Allow spaces in password.</param>
		/// <param name="specials">String containing special characterrs to allow in password.</param>
		/// <returns>Random password compliant with specified constraints.</returns>
		private string GetRandomPassword(int length, bool uppercase, bool numbers, bool eight_digit, bool spaces, string specials) {

			string password = String.Empty;
			char character;
			int index;

			// Begin: Collecting valid password characters.
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
				validChars += settings.Whitespace.Replace("\"", ""); // Remove quotes.

			validChars += specials;

			char[] validCharArray = validChars.ToCharArray();
			numValidChars = validChars.Length;
			// End: Collecting valid password characters.

			seed -= Math.Truncate(seed); // Get value greater than -1 and less than 1.
			Random randomizer = new Random((int)(seed * int.MinValue));

			// Add random characters to password:
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
		/// Copy text from password text control to clipboard.
		/// </summary>
		private void Copy() {

			Clipboard.SetText(txtPassword.Text);
			UpdateStatusText();
		}

		/// <summary>
		/// Adjust password length based on the position of trackbar slider.
		/// </summary>
		private void AdjustPasswordLength() {

			if (passwordLength > trkLength.Value) // Shrink password to match trackbar position.
				txtPassword.Text = txtPassword.Text.Remove(trkLength.Value);
			else if (passwordLength < trkLength.Value) { // Append random characters to match trackbar position.
				string specialCharString = GetSpecialCharString();
				string passwordChars = GetRandomPassword(trkLength.Value - passwordLength, chkUppercase.Checked, chkNumbers.Checked, chkNumbers.CheckState == CheckState.Indeterminate, chkSpaces.Checked, specialCharString);
				txtPassword.Text += passwordChars;
			}
			passwordLength = trkLength.Value;
			UpdateStatusText();
		}

		/// <summary>
		/// Update label text fields in status bar and password text field tooltip.
		/// </summary>
		private void UpdateStatusText() {

			String clipboardText = Clipboard.GetText().Trim();

			if (clipboardText != String.Empty) { // Add first line of clipboard text to status bar text.
				string clipboardLine = clipboardText.Split(new char[] { '\r', '\n' })[0];

				lblStatus.Text = settings.lblStatusStart + clipboardLine;
				lblStatus.ToolTipText = clipboardText;
			}
			else { // Display version information.
				lblStatus.Text = "Build " + version.Build.ToString();
				lblStatus.ToolTipText = Application.ProductName + " v" + version.Major.ToString() + "." + version.Minor.ToString() + " Build " + version.Build.ToString();
			}
			lblPasswordCharCount.Text = String.Format(settings.lblPasswordCharCountFormat, passwordLength);
			// Password text field tooltip:
			tipPasswordGenerator.SetToolTip(txtPassword, String.Format(settings.txtPasswordTooltipFormat, DoubleToString(Math.Pow(numValidChars, passwordLength))));
			//trkLength.Focus();
		}

		/// <summary>
		/// Convert a double precision floating point number to a descriptive string.
		/// </summary>
		/// <param name="number">Number to convert.</param>
		/// <returns>String describing input number.</returns>
		private string DoubleToString(double number) {

			if (number == 0)
				return settings.ZeroName;

			// Set sign prefix.
			string prefix = String.Empty;
			if (number < 0) {
				prefix = settings.NegativePrefix;
				number = Math.Abs(number);
			}

			if (double.IsInfinity(number))
				return prefix + settings.InifinityName;

			if (number < 1000000) // Thousands only don't require named prefixes.
				return prefix + number.ToString(settings.SmallNumberFormat);

			number /= 1000000f;

			int index = 1; // 'million'
			int power = 6; // 10^6 == 1 million.
			int nameCount = settings.NumberNames.Count; // Number of named prefixes.
			string name = String.Empty;

			while (number > 1000) {
				// Proceed to next named prefix.
				number /= 1000f;
				++index;
				power += 3;
				// Check if we have a name for this power of ten.
				if (index == nameCount) {
					name = settings.NumberNames[nameCount - 1] + ' ' + name;
					index = 0; // Back to 'thousand'.
				}
			}
			// Add latest prefix as leftmost.
			name = settings.NumberNames[index] + ' ' + name;

			return prefix + String.Format(settings.NumberFormat, number) + name.Trim() + String.Format(settings.PowerFormat, power);
		}

		/// <summary>
		/// Get string containing special characters selected in combobox,
		/// as defined in application settings (Keyboards and KeyboardSpecialCharacters).
		/// </summary>
		/// <returns>The special character string corresponding to the combobox selection.</returns>
		private string GetSpecialCharString() {

			string specialCharString = String.Empty;

			if (chkSpecialChars.Checked) {
				if (chkSpecific.Enabled && chkSpecific.Checked) {
					if (cboSpecific.SelectedIndex >= 0)
						specialCharString = settings.KeyboardSpecialCharacters[cboSpecific.SelectedIndex];
					else {
						foreach (char specialChar in cboSpecific.Text) {

						}
						specialCharString = cboSpecific.Text;
					}
				}
				else
					specialCharString = settings.KeyboardSpecialCharacters[0];
			}
			return specialCharString;
		}
		
		#endregion
	}
}