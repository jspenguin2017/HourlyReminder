using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Hourly_Reminder
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region Variables

        /// <summary>
        /// The minute of the hour to send reminder
        /// </summary>
        private int minuteOfHour;
        /// <summary>
        /// The message to display in the notification
        /// </summary>
        private string msg;
        /// <summary>
        /// Windows registry library object
        /// </summary>
        private RegLib autoStart = new RegLib("Hourly Reminder Auto-Start", Application.ExecutablePath);
        /// <summary>
        /// If it is the timer's first tick, on the first tick, the timer will adjust the interval to 1 hour
        /// </summary>
        private bool isFirstTick;
        /// <summary>
        /// If settings are changed, when closing, this variable will be checked and ask the user if he wants to save settings if needed
        /// </summary>
        private bool settingsChanged;
        /// <summary>
        /// If the form closing event is from tray context menu "Exit" button click event
        /// If this is true, this software will exit, otherwise, only the settings window will be hidden
        /// </summary>
        private bool exiting = false;

        #endregion

        #region Form Events

        /// <summary>
        /// Event handler for form load
        /// Load and adjust some settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            //Set textboxes length limit
            TxtMinute.MaxLength = 2;
            //Load settings
            LoadSettings();
            //settingsChanged can be changed while loading settings, set it back to false
            settingsChanged = false;
            //Schedule next notification
            ScheduleNotification();
        }
        /// <summary>
        /// Event handler for form shown
        /// Check settings "Start hidden" and hide the settings form if needed
        /// Passing any argument from command line will also make this software start hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Shown(object sender, EventArgs e)
        {
            if (BoxStartHidden.Checked || Environment.GetCommandLineArgs().Length > 1)
            {
                this.Hide();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// Event handler for form closing
        /// Check if settings are changed, and ask the user if he wants to save settings if needed
        /// Then hides the settings form if this event comes from the close button, or completely exit if it comes from tray context menu "Exit" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The event object, will be used to cancel closing event if needed</param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cancel closing event if it is not from tray context menu
            if (!exiting)
            {
                e.Cancel = true;
            }
            //If the user changed any settings, ask him what to do
            if (settingsChanged)
            {
                if (MessageBox.Show("You have changed some settings, do you want to apply them?", "Hourly Reminder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Yes clicked, apply
                    BtnApply.PerformClick();
                }
                else
                {
                    //No clicked, cancel
                    BtnCancel.PerformClick();
                }
            }
            else
            {
                //Nothing changed, simply hide the form
                this.Hide();
            }
        }

        #endregion

        #region Timer Mechanism

        /// <summary>
        /// Schedule or re-schedule next reminder
        /// Update startTime before calling this function for correct scheduling
        /// There can be up to 1 second inaccuracy
        /// </summary>
        private void ScheduleNotification()
        {
            //Schedule the first tick, subsequent ticks are set inside tick handler
            int delay, sec, min;
            //Calculate the amount of seconds until next minute
            sec = 60 - DateTime.Now.Second;
            //Calculate the amount of minutes from the next minute until next reminder
            if (DateTime.Now.Minute < minuteOfHour)
            {
                //The reminder is in the same hour
                //Minus one because we are calculating starting the next minute
                min = minuteOfHour - DateTime.Now.Minute - 1;
            }
            else
            {
                //The reminder is in the next hour
                //We need to calculate how many minutes are remaining in the hour and add startTime
                //Using 59 instead of 60 because we are calculating starting the next minute
                min = 59 - DateTime.Now.Minute + minuteOfHour;
            }
            //Put minutes and seconds into milliseconds
            delay = (min * 60 + sec) * 1000;
            //Check if we are right on the hour, just in case
            if (delay <= 1000)
            {
                //Set delay to 1 hour
                delay = 3600000;
                //Since the interval is set to 1 hour, we do not to set it again
                isFirstTick = false;
                //Display notification if enabled
                if (TrayEnableBtn.Checked)
                {
                    DisplayNotification(msg);
                }
            }
            else
            {
                //Set isFirstTick so next tick can be scheduled properly
                isFirstTick = true;
            }
            //Set interval and reset timmer
            MainTimer.Interval = delay;
            MainTimer.Enabled = true;
        }
        /// <summary>
        /// Event handler for timer tick
        /// The timer will be running even if tray context menu enable is un-checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            //Set interval to 1 hour if needed
            if (isFirstTick)
            {
                MainTimer.Interval = 3600000;
                //Set isFirstTick so interval will not be set again before it is needed
                isFirstTick = false;
            }
            //Display notification if enabled
            if (TrayEnableBtn.Checked)
            {
                DisplayNotification(msg);
            }
        }

        #endregion

        #region Tray Icon Events

        /// <summary>
        /// Event handler for enable click
        /// Toggle checked state and change the tray icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayEnableBtn_Click(object sender, EventArgs e)
        {
            TrayEnableBtn.Checked = !TrayEnableBtn.Checked;
            if (TrayEnableBtn.Checked)
            {
                TrayIcon.Icon = Properties.Resources.Icon_Enabled;
            }
            else
            {
                TrayIcon.Icon = Properties.Resources.Icon_Disabled;
            }
        }
        /// <summary>
        /// Event handler for tray context menu "Show" button click and tray icon double-click
        /// Show the window and restore it if minimized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayShowBtn_Click(object sender, EventArgs e)
        {
            //Show the window
            this.Show();
            //Restore the window
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// Event handler for exit click
        /// Update flag and call Application.Exit()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayExitBtn_Click(object sender, EventArgs e)
        {
            //Set exiting so form closing event will not stop it
            exiting = true;
            Application.Exit();
        }

        #endregion

        #region Buttons Events

        /// <summary>
        /// Event handler for cancel click
        /// Discard changed to settings if needed, then hide the settings form
        /// Since settings loaded are already applied, we do not need to schedule it again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (settingsChanged)
            {
                //Write variables back into textboxes
                TxtMinute.Text = minuteOfHour.ToString();
                TxtMsg.Text = msg;
                //For checkboxes, we need to load the setting again, since they are not saved in a variable
                BoxStartHidden.Checked = (bool)Properties.Settings.Default["startHidden"];
                BoxAutoStart.Checked = autoStart.Validate();
                //Since we discarded changes, we can set settingsChanged back to false
                settingsChanged = false;
            }
            this.Hide();
        }
        /// <summary>
        /// Event handler for apply click
        /// Apply the settings if needed, then hide the settings form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (settingsChanged)
            {
                ApplySettings();
            }
            this.Hide();
        }
        /// <summary>
        /// Event handler for test click
        /// Show notification with message that is in the textbox if it is valid (not empty string or all white spaces)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtMsg.Text))
            {
                MessageBox.Show("Your message cannot be empty.", "Hourly Reminder");
            }
            else
            {
                DisplayNotification(TxtMsg.Text);
            }
        }
        /// <summary>
        /// Event hander for reset click
        /// Ask the user if he really want to restore settings to default and act accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to restore all settings to their default values?", "Hourly Reminder", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RestoreSettings();
            }
        }

        #endregion

        #region Settings Management

        /// <summary>
        /// Load settings
        /// This will not apply them
        /// </summary>
        private void LoadSettings()
        {
            //=====Minute of the hour=====
            //Load
            minuteOfHour = (int)Properties.Settings.Default["startTime"];
            //Check if it is in valid range
            if (minuteOfHour < 0)
            {
                minuteOfHour = 0;
            }
            else if (minuteOfHour > 59)
            {
                minuteOfHour = 59;
            }
            //Write into textbox
            TxtMinute.Text = minuteOfHour.ToString();
            //=====Message=====
            //Load
            msg = (string)Properties.Settings.Default["msg"];
            //Message cannot be an empty string
            if (string.IsNullOrWhiteSpace(TxtMsg.Text))
            {
                msg = (string)Properties.Settings.Default.Properties["msg"].DefaultValue;
            }
            //Write into textbox
            TxtMsg.Text = msg;
            //=====Start hidden=====
            //Write into checkbox
            BoxStartHidden.Checked = (bool)Properties.Settings.Default["startHidden"];
            //=====Start with Windows=====
            //Write into checkbox
            BoxAutoStart.Checked = autoStart.Validate();
        }
        /// <summary>
        /// Save settings and apply them
        /// Settings that are not valid are auto-corrected
        /// </summary>
        private void ApplySettings()
        {
            //=====Minute of the hour=====
            //Parse and validate input, then save it into variable
            if (int.TryParse(TxtMinute.Text, out int tempStartTime))
            {
                //Successfully parsed input, check if it is in valid range
                if (tempStartTime < 0)
                {
                    tempStartTime = 0;
                }
                else if (tempStartTime > 59)
                {
                    tempStartTime = 59;
                }
                //Write into variable
                minuteOfHour = tempStartTime;
            }
            else
            {
                //Cannot parse input, use default value
                minuteOfHour = Convert.ToInt32(Properties.Settings.Default.Properties["startTime"].DefaultValue);
            }
            //Write back into textbox to prevent confusion
            TxtMinute.Text = minuteOfHour.ToString();
            //Write into settings
            Properties.Settings.Default["startTime"] = minuteOfHour;
            //=====Message=====
            //Message cannot be an empty string
            if (string.IsNullOrWhiteSpace(TxtMsg.Text))
            {
                TxtMsg.Text = (string)Properties.Settings.Default.Properties["msg"].DefaultValue;
            }
            //Write into variable
            msg = TxtMsg.Text;
            //Write into settings
            Properties.Settings.Default["msg"] = msg;
            //=====Start hidden=====
            //Write into settings
            Properties.Settings.Default["startHidden"] = BoxStartHidden.Checked;
            //=====Start with Windows=====
            //Write into registry
            if (BoxAutoStart.Checked)
            {
                autoStart.Enable();
            }
            else
            {
                autoStart.Disable();
            }
            //=====Wrap up=====
            //Save settings
            Properties.Settings.Default.Save();
            //Set settingsChanged so the user will not be asked to save settings when closing
            settingsChanged = false;
            //Re-schedule notification
            ScheduleNotification();
            //Ask user if he wants to enable notification if needed
            if (!TrayEnableBtn.Checked && MessageBox.Show("Notification is disabled, do you want to enable it now?", "Hourly Reminder", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TrayEnableBtn.PerformClick();
            }
        }
        /// <summary>
        /// Load default settings, save them, then apply them
        /// Default value of start with Windows is hard coded here as false, other settings are set in application settings in project properties
        /// </summary>
        private void RestoreSettings()
        {
            //Load default settings to settings inputs
            TxtMinute.Text = (string)Properties.Settings.Default.Properties["startTime"].DefaultValue;
            TxtMsg.Text = (string)Properties.Settings.Default.Properties["msg"].DefaultValue;
            BoxStartHidden.Checked = Convert.ToBoolean(Properties.Settings.Default.Properties["startHidden"].DefaultValue);
            BoxAutoStart.Checked = false;
            //Apply them
            ApplySettings();
        }

        #endregion

        #region Other Functions

        /// <summary>
        /// Display notification
        /// For how long the notification is shown, Windows 8 and above will use the system settings, older system will show for a hard coded 5000 milliseconds
        /// This value is hard coded because modern operation systems ignore it, and showing a setting that does not work most of the time will confuse the user
        /// </summary>
        /// <param name="msg">The message to display in the notification</param>
        private void DisplayNotification(string msg)
        {
            //We might want to switch to Windows.UI.Notifications
            //https://www.whitebyte.info/programming/c/how-to-make-a-notification-from-a-c-desktop-application-in-windows-10
            TrayIcon.ShowBalloonTip(5000, "Hourly Reminder", msg, ToolTipIcon.Info);
        }
        /// <summary>
        /// Event handler for key down of message textbox
        /// Check if Ctrl+A is pressed, if yes, select all and suppress beep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                //Select all
                TxtMsg.SelectAll();
                //Suppress beep
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// Event handler for change of all 4 settings inputs
        /// Set settingsChanged so the user will be asked to save settings when closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsUpdate(object sender, EventArgs e)
        {
            settingsChanged = true;
        }
        /// <summary>
        /// Event hander for author name link click
        /// Launch GitHub project page in a browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jspenguin2017/HourlyReminder");
        }

        #endregion

    }
}
