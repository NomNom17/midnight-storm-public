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
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }

        private void exit_click(object sender, EventArgs e)
        {
            this.Dispose(true); // Closes the main menu, invoking the whole game to end
        }

        private void helpScreen_Click(object sender, EventArgs e)
        {
            // Opens up the help screen window
            helpScreen Help = new helpScreen(); // Creating a local variable for the help screen
            Help.Show(); // calling the local variable to show the form
        }

        private void play_Click(object sender, EventArgs e)
        {
            // Opens up the game window
            //midnightStorm Game = new midnightStorm(); // Creating a local variable for the game window
            //Game.Show(); // Calls the variable to open the game window
            select_level SelectLevel = new select_level(); //Creating a local variable that opens the defined window
            SelectLevel.Show(); // Shows the window
            this.WindowState = FormWindowState.Minimized; // Minimises the main menu instead of closing the main menu which causes the process to end.
        }

        private void main_menu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimises the main menu
            MessageBox.Show("Complete the first level to unlock other levels"); // Shows message box on startup
        }
    }
}
