using System;
using System.Drawing;
using System.Windows.Forms;

namespace GitUI
{
    public partial class AboutBox : GitExtensionsForm
    {
        public AboutBox()
        {
            InitializeComponent(); Translate();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=WAL2SSDV8ND54&lc=US&item_name=GitExtensions&no_note=1&no_shipping=1&currency_code=EUR&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted");
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            Bitmap image = Lemmings.GetPictureBoxImage(DateTime.Now);
            if (image != null)
                logoPictureBox.Image = image;

            thanksTimer_Tick(null, null);
            thanksTimer.Enabled = true;
            thanksTimer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _NO_TRANSLATE_labelVersionInfo.Text = _NO_TRANSLATE_labelVersionInfo.Text + GitCommands.Settings.GitExtensionsVersionString;
        }

        //Contributers list 
        //TODO: fix order (commit count?)
        private const string contributers = "                                                                         Steffen Forkmann, Jacob Stanley, Nick Mayer, Kevin Moore, Davide, dominiqueplante, Grzegorz Pachocki, Seth Behunin, bleis-tift, Chris Meaney, Adrian Codrington, Troels Thomsen, Wilbert van Dolleweerd, Tobias Bieniek, Radoslaw Miazio, Stan Angeloff, Matt McCormick, Bj�rn Moe, William Swanson, Daniel Locantore, Harald Deischinger, Radek Miazio, Stefan Rueckl, Emanuel Henrique do Prado, Lukasz Byczynski, Steffen M. Colding-J�rgensen, alexeik, arBmind, Gianni Rosa Gallina, mausch, xaro, Xharze, Kim Christensen, gor, Charles Brossollet, Patrick Earl, ultonis, Michael Frenzel, showell";

        private int thanksCounter;
        private void thanksTimer_Tick(object sender, EventArgs e)
        {
            _NO_TRANSLATE_thanksToTicker.Text = contributers.Substring(thanksCounter);// "Thanks to: " + contributers[thanksCounter % contributers.Length];
            _NO_TRANSLATE_thanksToTicker.Tag = null;
            _NO_TRANSLATE_thanksToTicker.Refresh();
            thanksCounter = (thanksCounter + 1) % contributers.Length;
        }

        private void _NO_TRANSLATE_thanksToTicker_Click(object sender, EventArgs e)
        {
            MessageBox.Show(contributers.Trim(), "Contributors");
        }
    }
}
