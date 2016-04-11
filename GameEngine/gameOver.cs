using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine
{
    public partial class gameOver : UserControl
    {
        public gameOver()
        {
            InitializeComponent();

            goodbye();
        }

        private void goodbye()
        {
            for (int i = 0; i < 30; i++)
            {
                label1.Text = "Game Over. The App will exit in 30 seconds, goodbye.";

                Refresh();
            }

            freeze();
        }
        private void freeze()
        {

        }
    }
}
