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

namespace TeknikServis.Formlar
{
    public partial class FrmYoutube : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        public FrmYoutube()
        {
            InitializeComponent();

            InitializeChromium();
        }

        private void FrmYoutube_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("http://www.youtube.com");
        }
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            
            chromeBrowser = new ChromiumWebBrowser("http://www.youtube.com");

            this.Controls.Add(chromeBrowser);

            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void FrmYoutube_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
