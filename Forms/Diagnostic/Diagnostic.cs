using System.Windows.Forms;

namespace MAS7.Forms
{
    /// <summary>
    /// <see cref="Form"/> used to display Diagnostic data regarding MAS functions.
    /// </summary>
    public partial class Diagnostic : Form
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Diagnostic"/> Form.
        /// </summary>
        /// <param name="input">Diagnostic log text.</param>
        public Diagnostic(string input)
        {
            InitializeComponent();
            // Add text to RichTextBox.
            rtbxOutput.AppendText(input);
        }
    }
}
