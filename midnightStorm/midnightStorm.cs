using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib; // Windows Media Player


namespace midnightStorm
{
    public partial class midnightStorm : Form
    {
        // Global Variables
        bool goright; // If the player moving right or not
        bool goleft; // If the player moving left or not
        int score = 0; // Set the score as 0
        int missed = 0; // Set the missed/chances to 0
        int speed = 6; // Set the speed that the rain falls at 
        int playerspeed = 10; // Speed that the player is moving at
        Random lightningRnd = new Random(); // Lightning randomiser
        Random rainRndY = new Random(); // Rain spawn randomiser (Y location)
        Random rainRndX = new Random(); // Rain spawn randomiser (X Location)
        PictureBox splash = new PictureBox(); // Create new splash picturebox if the rain drop missed
        int striketime = 0; // The duration before the lightning strike's hit
        int visibleTimer = 0; // Duration of lightning strike being displayed
        System.Media.SoundPlayer lightningPlayer = new System.Media.SoundPlayer(); // For playing lightning audio file

        public midnightStorm()
        {
            InitializeComponent();
            Reset(); // Will initiate the game to restart
            striketime = lightningRnd.Next(1000, 1750); // Duration before lightning strike hits - Integer
            // Plays the audio file in the background
            //rain.Stream = Properties.Resources.rain;
            //rain.PlayLooping();
            // Windows Media Player (backgroundPlayer) - to counter the issue with the sounds ending each other
            backgroundPlayer.URL = "rain.wav"; // Giving the media player the location of the file & the file name with it's file extension type
            backgroundPlayer.settings.setMode("loop", true); // Making the sound loop
            backgroundPlayer.Ctlcontrols.play(); // Telling the media player to loop the sound
            backgroundPlayer.Visible = false; // Hides the media player to prevent an issue that causes the player to not move

        }

        // Reset the game function
        public void Reset()
        {
            // Reset position of the raindrops & repeating the function again
            foreach (Control X in this.Controls) // Checking the components
            {
                if (X is PictureBox && (string)X.Tag == "raindrop") // Defining that X variable is picturebox with raindrop tag, this allows us to give the pictureboxes with their tags functions to follow and do
                {
                    X.Top = rainRndY.Next(100, 300) * -1; // Setting the position where the raindrop would spawn into (X Axis)
                    X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Setting the position where the raindrop would spawn into (Y Axis)
                }
            }

            striketime = lightningRnd.Next(1250, 1950); // Setting the duration before lightning strike hits at reset
            lightningstrike.Visible = false; // Hides the lightning strike picturebox

            playerspeed -= player.Left; // Playerspeed value will continuously decrease player left (width) value. Player moves left.
            playerspeed += player.Left; // Playerspeed value will continuously increase player left (width) value. Player moves right.

            // Reset the image to default
            player.Image = Properties.Resources.player_left;

            // Stop the sounds from playing on reset
            lightningPlayer.Stop();
            backgroundPlayer.Ctlcontrols.stop();

            // Reset the variables back to default
            score = 0; // Score 
            missed = 0; // Missed
            playerspeed = 10; // The speed of the player
            striketime = 0; // duration before the lightning strike hits
            visibleTimer = 0; // the duration of how long the lightning strike lasts for before it disappears
            speed = 6; // the speed of the rainfall

            // Reset the booleans to default to prevent player from moving while the game is resetting
            goleft = false;
            goright = false;

            // Starts the timer back up
            gameTimer.Start();
        }

        // Lightning Strike Function
        public void strikelightning()
        {

            visibleTimer += 1; // Continuously adds 1 towards the visible timer which is responsible for the duration of lightning strike visibility

            lightningstrike.Left = player.Left; // Lightning strike will follow player's width/left

            if (visibleTimer < 15) // Set the duration of the lightning strike
            {
                lightningstrike.Visible = true; // Lightning strike appears
                playerspeed = 0; // Stops the player from moving
                lightningPlayer.Stream = Properties.Resources.lightning_sound; // Define which sound to play
                lightningPlayer.Play(); // Plays lightning strike sound
                // Reloop the background sound once the lightning strike stops playing
                backgroundPlayer.URL = "rain.wav"; // Location and the name of the file with the file extension type
                backgroundPlayer.settings.setMode("loop", true); // Loop the sound
                backgroundPlayer.Ctlcontrols.play(); // Play the sound
            }
            else
            {
                lightningstrike.Visible = false; // Hides lightning strike
                striketime = lightningRnd.Next(1250, 1950); // Duration before the lightning strikes hit will be reset
                visibleTimer = 0; //Reset visibletimer to default
            }
        }

        // Timer event
        private void GameTick(object sender, EventArgs e)
        {
            // Label Counter Starts here
            score_label.Text = "Raindrops Caught: " + score; // Changes the label text to add the score variable
            missed_label.Text = "Missed: " + missed; // Changes the label text to add the missed variable
            // Label Counter Ends here

            // Player movement starts here
            if (goleft == true && player.Left > 0) // goleft boolean is true then do the following below and if player's X/left location is more than 0 (prevents going out of bounds)
            {
                player.Left -= playerspeed; // Amount of pixels (defined in the variable) the player will move to the left continuously (as long as goleft is true)
                player.Image = Properties.Resources.player_left; // changes the player's picturebox image to player_left
            }

            if (goright == true && player.Left + player.Width < this.ClientSize.Width) // Do the following below if goright is true, also prevents player going out of bounds by adding collision if the player touches the client/window's end of width
            {
                //player.Left += 24; // Amount of pixels the player will move to the right
                player.Left += playerspeed; // Amount of pixels (defined in the variable) the player will move to the right continuously (as long as goright is true)
                player.Image = Properties.Resources.player_right; // changes player image to player_right
            }
            // Player movement ends here

            // Falling rain drop function
            foreach (Control X in this.Controls) // Given an variable of X
            {
                if (X is PictureBox && (string)X.Tag == "raindrop") // Telling the program that the variable X is a picturebox which has the tag of raindrop
                {
                    X.Top += speed; // raindrop would continuously fall at the defined variable's value

                    if (X.Top + X.Height > this.ClientSize.Height) // If raindrop height and top is more than window's height then do the following
                    {
                        splash.Image = Properties.Resources.Splash; // changes the splash picturebox image
                        splash.Location = X.Location; // Place the splash picturebox at rain drop location
                        splash.Height = 119; // Height of the picturebox
                        splash.Width = 120; // Width of the picturebox
                        splash.BackColor = System.Drawing.Color.Transparent; // made the picturebox background colour transparent

                        this.Controls.Add(splash); // Adds the splash picturebox onto the game

                        // Respawns the rain at the top but randomly within the range
                        X.Top = rainRndY.Next(80, 150); // Spawning location for raindrop (height / Y Axis)
                        X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Spawning location for the rain drop (width / X Axis)
                        missed++; // Adds to missed counter integer
                    }

                    // Score system, if raindrop touches the player, it will add a point and respawn the raindrop at the top
                    if (X.Bounds.IntersectsWith(player.Bounds))
                    {
                        X.Top = rainRndY.Next(100, 300) * -1;
                        X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width);
                        score++;
                    }

                    // Score Condition
                    if (score > 20) // If the player has more than 20 score
                    {   // Do the following.
                        speed = 8; // Increase rain speed
                        turbo_label.Visible = true; // shows turbo label
                        striketime = lightningRnd.Next(1500, 2250); // Duration before the lightning strikes hit
                    }

                    // Win condition
                    if (score > 35) // If the player has more than 35 score
                    {   // Do the following.
                        gameTimer.Stop(); // Stop the timer
                        MessageBox.Show("Congratulation! You've finished this level! Check out the other bonus levels. This level will now close and you will be directed to level selector."); // Shows the messagebox on screen with the following message.
                        this.Close(); // Self destruct itself
                    }

                    // Lose condition
                    if (missed > 5) // If player missed more than 5 rain drops
                    {   // Do the following.
                        gameTimer.Stop(); // Stop the timer
                        MessageBox.Show("GAME OVER!!!! WE LOST GOOD RAINDROPS!" + "\r\n" + "Click OK to restart."); // Show the messagebox with the following message
                        Reset(); // Call the Reset function
                    }
                }
            }

            // Decreasing the time
            striketime -= 5;

            // When striketime hits less than 0 then will call the strikelightning function
            if (striketime < 0)
            {
                strikelightning(); // Calls the function
            }

            // Meanwhile if the striketime is still being counted down before it hits above condition, it will set the player speed to default to counter the issue with player being frozen after being struck with lightning
            if (striketime > 0)
            {
                playerspeed = 10; // Set the playerspeed to default
            }
        }

        // Key been pressed and held event
        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // If Left key is being held down (assigned the key as Left)
            {
                goleft = true; // Player moves left - Boolean
            }

            if (e.KeyCode == Keys.Right) // If Right key is being held down (assigned the key as Right)
            {
                goright = true; // Player moves right - Boolean
            }
        }

        // Key has been released event
        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // If Left key is released/not being held down
            {
                goleft = false; // Player stops moving left
            }

            if (e.KeyCode == Keys.Right) // If Right key is released/not being held down
            {
                goright = false; // Player stops moving right
            }
        }
 
        private void midnightStorm_Load(object sender, EventArgs e)
        {
            // Once the game level launches, the level selector closes
            select_level levelselector = new select_level();
            levelselector.Close(); // Closes level selector
        }

        private void midnightStorm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the game level closes, the level selector re-opens
            select_level levelSelector = new select_level();
            levelSelector.Show(); // Show the level selector
        }
    }
}