using System;
using System.Windows.Forms;
using System.IO;

namespace MAS7.Forms
{
    /// <summary>
    /// <see cref="Form"/> used to alter Application settings.
    /// </summary>
    public partial class Settings : Form
    {
        // Value changes flag.
        private bool _changes = false;

        /// <summary>
        /// Initializes a new instance of <see cref="Settings"/> Form.
        /// </summary>
        public Settings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update GUI to match current settings.
        /// </summary>
        /// <remarks>Raised on <see cref="Settings"/> Load Event.</remarks>
        private void OnSettingsLoad(object sender, EventArgs args)
        {
            // Update GUI to match user settings.
            txbPath.Text = Properties.Settings.Default.MASPath;
            ckbxIntelExclusive.Checked = Properties.Settings.Default.IntelExclusive;
            ckbxCommandLine.Checked = Properties.Settings.Default.CommandLine;
            ckbxMinimizeTray.Checked = Properties.Settings.Default.MinimizeOnTray;
            ckbxCloseTray.Checked = Properties.Settings.Default.CloseOnTray;
        }

        /// <summary>
        /// Check if <see cref="Settings"/> Form can close.
        /// </summary>
        /// <remarks>Raised on <see cref="Settings"/> Closing Event.</remarks>
        private void OnSettingsClosing(object sender, FormClosingEventArgs args)
        {
            // If changes have been made, inform user.
            if (_changes && DialogResult == DialogResult.Cancel)
            {
                DialogResult dialogResult = MessageBox.Show("Changes you made will not be saved.", "Cancel",
                                                               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                // Cancel close.
                if (dialogResult == DialogResult.Cancel) args.Cancel = true;
            }
        }

        /// <summary>
        /// Save new application settings.
        /// </summary>
        private void OnSaveSettingsClick(object sender, EventArgs args)
        {
            // Save new settings, then close.
            Properties.Settings.Default.MASPath = txbPath.Text;
            Properties.Settings.Default.IntelExclusive = ckbxIntelExclusive.Checked;
            Properties.Settings.Default.CommandLine = ckbxCommandLine.Checked;
            Properties.Settings.Default.MinimizeOnTray = ckbxMinimizeTray.Checked;
            Properties.Settings.Default.CloseOnTray = ckbxCloseTray.Checked;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cancel new application settings.
        /// </summary>
        private void OnCancelSettingsClick(object sender, EventArgs args)
        {
            // Indicate cancellation
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Sets text to <see cref="txbPath"/>.
        /// </summary>
        private void OnChangePathClick(object sender, EventArgs args)
        {
            bool found = false;
            string path = "";
            // Repeat till sst.exe or IntelMAS.exe is found.
            do
            {
                DialogResult folderDialogResult = folderBroswer.ShowDialog();
                if (folderDialogResult == DialogResult.OK)
                {
                    // Path may be found.
                    path = folderBroswer.SelectedPath;
                    found = true;
                }
                else
                {
                    // Inform user. If cancel, then break.
                    DialogResult messageDialogResult = MessageBox.Show("Please specify Intel/Solidigm Storage Tool installation path.",
                        "Installation Path", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (messageDialogResult == DialogResult.Cancel) break;
                }
            } while (!File.Exists(path + "\\IntelMAS.exe") && !File.Exists(path + "\\sst.exe"));
            // Check if .exe is found.
            if (!found) return;
            // If sst.exe exists, then Solidigm is used instead of MAS.
            if (File.Exists(path + "\\sst.exe")) Properties.Settings.Default.Solidigm = true;
            else Properties.Settings.Default.Solidigm = false;
            txbPath.Text = path;
            _changes = true;
        }

    }
}
