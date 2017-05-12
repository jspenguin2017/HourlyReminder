using Microsoft.Win32;

namespace Hourly_Reminder
{
    /// <summary>
    /// Windows registry library
    /// </summary>
    class RegLib
    {
        /// <summary>
        /// The name of the software, will be used as registry name
        /// </summary>
        private string appName;
        /// <summary>
        /// The complete path to software executable, with quotation marks and arguments
        /// </summary>
        private string execPath;
        /// <summary>
        /// Registry key "Run" for the current user
        /// </summary>
        private RegistryKey runKey;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the software, will be used as registry name</param>
        /// <param name="path">The complete path to software executable, without quotation marks, usually is the value of "Application.ExecutablePath"</param>
        public RegLib(string name, string path)
        {
            //Store arguments into object variables
            this.appName = name;
            this.execPath = "\"" + path + "\" /autostart";
            this.runKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        /// <summary>
        /// Check if auto-start registry entry is enabled and valid
        /// </summary>
        /// <returns>True if auto-start registry entry is enabled and valid, false otherwise</returns>
        public bool Validate()
        {
            return (runKey.GetValue(this.appName) != null && runKey.GetValue(this.appName).ToString() == execPath);
        }

        /// <summary>
        /// Enable auto-start, can be used to fix invalid auto-start registry
        /// </summary>
        public void Enable()
        {
            runKey.SetValue(this.appName, this.execPath);
        }

        /// <summary>
        /// Disable auto-start
        /// </summary>
        public void Disable()
        {
            runKey.DeleteValue(this.appName, false);
        }
    }
}
