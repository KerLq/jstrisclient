using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Jstris_Client
{
    public partial class Jstris : Form
    {
        public ChromiumWebBrowser browser;
        public Jstris()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            InitializeChromium();

        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("https://jstris.jezevec10.com");
            browser.KeyboardHandler = new KeyboardHandler();
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

        }

        private void Jstris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("SheesH");
            }
        }
    }


    //KeyboardHandler by tobre => https://stackoverflow.com/questions/60740328/keyboard-shortcut-does-not-make-it-to-cefsharp-browser-control
    public class KeyboardHandler : IKeyboardHandler
    {
        private bool _cefAltKeyPressed;
        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }

        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            if (windowsKeyCode == 18)
            {
                _cefAltKeyPressed = true;
            }
            const int KEY_F4 = 115;
            //Console.WriteLine("Key Pressed " + windowsKeyCode); .> To Debug and analyse other Shortcut Combinations
            if (_cefAltKeyPressed)
            {
                if (windowsKeyCode == KEY_F4)
                {

                    Application.Exit();
                }
                
                _cefAltKeyPressed = false;

            }
            return true;
        }
    }
}
