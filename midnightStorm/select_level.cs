using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midnightStorm
{
    public partial class select_level : Form
    {


        public select_level()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            midnightStorm Easy = new midnightStorm(); // Creates a new instance of the level & gives a variable
            // Opens up the level
            Easy.Show(); // shows the level

            // Closes level selector to prevent too many window from unnecessarily running in the background
            this.Close();
        }

        private void mediumMode_Click(object sender, EventArgs e)
        {
            mediumMode Medium = new mediumMode(); // Creates a new instance of the level & gives a variable

            // Opens up the level
            Medium.Show(); // shows the level

            // Closes level selector to prevent too many window from unnecessarily running in the background
            this.Close();
        }

        private void select_level_Load(object sender, EventArgs e)
        {

        }

        private void extreme_button_click(object sender, EventArgs e)
        {
            MessageBox.Show("This mode will be significantly harder, lightning strike is more punishable, rain drops will fall significantly faster and more! Click OK once you're ready."); // Shows a little popup to let the player know of the increased difficulty
            extremeMode Extreme = new extremeMode(); // new variable for the extreme mode form
            Extreme.Show(); // shows the extreme mode form
            this.Close(); // closes the level selector
        }

        private void hardMode_Click_1(object sender, EventArgs e)
        {
            hardMode Hard = new hardMode(); // new variable for hard mode

            Hard.Show(); // shows hard mode form

            this.Close(); // closes level selector
        }
    }
}
