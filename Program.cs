using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UniversalDialogue
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOACTIVATE = 0x0010;

        [STAThread]
        static void Main(string[] args)
        {
            string title = "Universal Dialogue";
            string text = "Arguments:\n" +
                "-title <string>: Set the title of the dialogue box.\n" +
                "-text <string>: Set the content of the dialogue box.\n" +
                "-icon <string> [information, error, warning, question]: Set the icon of the dialogue box.\n" +
                "-form <type> [messagebox, winforms]: Set the form type. WinForms will always on top.";
            MessageBoxIcon icon = MessageBoxIcon.Information;
            bool topMost = false;
            string formType = "messagebox";

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-title" && i + 1 < args.Length)
                {
                    title = args[i + 1];
                }
                else if (args[i] == "-text" && i + 1 < args.Length)
                {
                    text = args[i + 1];
                }
                else if (args[i] == "-icon" && i + 1 < args.Length)
                {
                    switch (args[i + 1].ToLower())
                    {
                        case "error":
                            icon = MessageBoxIcon.Error;
                            break;
                        case "warning":
                            icon = MessageBoxIcon.Warning;
                            break;
                        case "question":
                            icon = MessageBoxIcon.Question;
                            break;
                        default:
                            icon = MessageBoxIcon.Information;
                            break;
                    }
                }
                else if (args[i] == "-form" && i + 1 < args.Length)
                {
                    formType = args[i + 1].ToLower();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            if (formType == "winforms")
            {
                topMost = true;

                Form dialog = new Form
                {
                    Text = title,
                    Width = 300,
                    Height = 200,
                    StartPosition = FormStartPosition.CenterScreen,
                    TopMost = topMost,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    MaximizeBox = false,
                    ShowIcon = false
                };

                Label label = new Label
                {
                    Text = text,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button button = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Dock = DockStyle.Bottom

                };

                dialog.Controls.Add(label);
                dialog.Controls.Add(button);
                dialog.AcceptButton = button;

                dialog.ShowDialog();
            }
            else
            {
                MessageBox.Show(text, title, MessageBoxButtons.OK, icon);
            }
        }
    }
}
