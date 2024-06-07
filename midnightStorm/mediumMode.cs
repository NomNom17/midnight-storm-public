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
    public partial class mediumMode : Form
    {
        // Global Variables
        bool goright; // If the player moving right or not
        bool goleft; // If the player moving left or not
        int score = 0; // Set the score as 0
        int missed = 0; // Set the missed/chances to 0
        int speed = 4; // Set the speed that the rain falls at 
        int playerspeed = 10; // Speed that the player is moving at
        new Random lightningRnd = new Random(); // Lightning randomiser
        new Random rainRndY = new Random(); // Rain spawn randomiser (Y location)
        new Random rainRndX = new Random(); // Rain spawn randomiser (X Location)
        PictureBox splash = new PictureBox(); // Create new splash picturebox if the rain drop missed
        PictureBox bad_splash = new PictureBox(); // Create new picturebox for poison drop splash
        int striketime = 0; // The duration before the lightning strike's hit
        int visibleTimer = 0; // Duration of lightning strike being displayed
        System.Media.SoundPlayer lightningPlayer = new System.Media.SoundPlayer(); // For playing lightning audio file
        //System.Media.SoundPlayer rain = new System.Media.SoundPlayer(); // Responsible for playing the rain audio file
        int poisonspeed = 8; // The speed at which the poison drop would be falling at
        bool poisoned; // Whether if the player is poisoned or not
        int poisonedtime = 300; // Duration of the poison effect
        bool striked; // A boolean that will be used with poisoned to help with compatibility between them

        public mediumMode()
        {
            InitializeComponent();
            Reset(); // Will initiate the game to restart
            striketime = lightningRnd.Next(900, 1500); // Duration before lightning strike hits - Integer
            // Plays the rain audio file in the background
            //rain.Stream = Properties.Resources.rain;
            //rain.PlayLooping();

            // Windows Media Player (backgroundPlayer) - to counter the issue with the sounds ending each other
            backgroundPlayer.URL = "rain.wav"; // Giving the media player the location of the file & the file name with it's file extension type
            backgroundPlayer.settings.setMode("loop", true); // Making the sound loop
            backgroundPlayer.Ctlcontrols.play(); // Telling the media player to loop the sound
            backgroundPlayer.Visible = false; // Hides the media player to prevent an issue that causes the player to not move
        }

        // Reset function
        private void Reset()
        {
            // Reset position of the raindrops & repeating the function again
            foreach (Control X in this.Controls) // Checking the components
            {
                if (X is PictureBox && (string) X.Tag == "raindrop") // Defining that X variable is picturebox with raindrop tag, this allows us to give the pictureboxes with their tags functions to follow and do
                {
                    X.Top = rainRndY.Next(100, 300) * -1; // Setting the position where the raindrop would spawn into (X Axis)
                    X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Setting the position where the raindrop would spawn into (Y Axis)
                }
            }


            // Reset position of the poison drop & repeat the 
            foreach (Control Z in this.Controls) // Checking the components and giving a local variable 
            {
                if (Z is PictureBox && Z.Name == "poisondrop") // Defining that Z variable is a picturebox and has the tag of poisondrop
                {
                    Z.Top = rainRndY.Next(100, 300) * -1; // reset the position where the poisondrop would spawn into
                    Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // reset the position where the poisondrop would spawn into
                }
            }

            striketime = lightningRnd.Next(900, 1500); // Setting the duration before lightning strike hits at reset
            lightningstrike.Visible = false; // Hides the lightning strike picturebox

            turbo_label.Visible = false; // hides turbo label on reset

            playerspeed -= player.Left; // Playerspeed value will continuously decrease player left (width) value. Player moves left.
            playerspeed += player.Left; // Playerspeed value will continuously increase player left (width) value. Player moves right.

            // Reset the image to default
            player.Image = Properties.Resources.player_left;

            // Stop the sounds from playing on reset
            lightningPlayer.Stop();
            backgroundPlayer.Ctlcontrols.stop();
            //rain.Stop();

            // Reset the integers back to default
            score = 0; // Score
            missed = 0; // Missed 
            playerspeed = 10; // Player speed
            striketime = 0; // Duration of before the lightning strike appears
            visibleTimer = 0; // Duration of the lightning strike
            speed = 5; // Rainfall speed
            poisonspeed = 7; // Poison speed

            // Reset the booleans to default to prevent player from moving while the game is resetting
            goleft = false;
            goright = false;

            // Revert the player's poisoned status
            poisoned = false;
            // Revert the player's striked status
            striked = false;

            // Starts the timer back up
            gameTimer1.Start();
        }

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
                    X.Top += speed; // // raindrop would continuously fall at the defined variable's value

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
                    if (score > 25 && missed < 2) // If the player has more than 20 score & has less than two missed
                    {   // Do the following.
                        speed = 6; // Increase rain speed
                        turbo_label.Visible = true; // shows turbo label
                        striketime = lightningRnd.Next(750, 1250); // Duration before the lightning strikes hit - making it appear frequently
                    }

                    // Win condition
                    if (score > 35) // If the player has more than 35 score
                    {   // Do the following.
                        gameTimer1.Stop(); // Stop the timer
                        MessageBox.Show("Congratulation! You've finished this level! Check out the other bonus levels. This level will now close and you will be directed to level selector."); // Shows the messagebox on screen with the following message.
                        this.Close(); // Self destruct itself
                    }

                    // Lose condition
                    if (missed > 5) // If player missed more than 5 rain drops
                    {   // Do the following.
                        gameTimer1.Stop(); // Stop the timer
                        MessageBox.Show("GAME OVER!!!! WE LOST GOOD RAINDROPS!" + "\r\n" + "Click OK to restart."); // Show the messagebox with the following message
                        Reset(); // Call the Reset function
                    }
                }
            }

            // Function for the poisondrop & coding the poisondrop to fall from the top
            foreach (Control Z in this.Controls)
            {
                if (Z is PictureBox && Z.Name == "poisondrop") // Saying that Z variable is a picturebox which has a name of poisondrop
                {
                    Z.Top += poisonspeed; // poison drop would continuously fall at the defined variable's value

                    if (Z.Top + Z.Height > this.ClientSize.Height) // If poisondrop height and top is more than window's height then do the following
                    {
                        bad_splash.Image = Properties.Resources.bad_Splash; // changes the splash picturebox's image
                        bad_splash.Location = Z.Location; // Place the splash picturebox at poison drop location
                        bad_splash.Height = 119; // Height of the picturebox
                        bad_splash.Width = 120; // Width of the picturebox
                        bad_splash.BackColor = System.Drawing.Color.Transparent; // made the picturebox background colour transparent

                        this.Controls.Add(bad_splash); // Adds the splash picturebox onto the game

                        // Respawns the poisondrop at the top but randomly within the range
                        Z.Top = rainRndY.Next(80, 150); // Spawning location for poisondrop (height / Y Axis)
                        Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // Spawning location for the poison drop (width / X Axis)
                        
                    }

                    // The effect of which the player would get if they touch the poisondrop
                    if (Z.Bounds.IntersectsWith(player.Bounds))
                    {
                        poisoned = true; // sets the playerspeed to 3 (currently not working)
                        Z.Top = rainRndY.Next(100, 300) * -1; // Respawns the poisondrop at given Y axis location
                        Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // Respawn the poison drop at given X axis location
                    }
                }
            }

            // Decreasing the striketime
            striketime -= 5;

            // When striketime hits less than 0 then will call the strikelightning function
            if (striketime < 0)
            {
                strikelightning(); // Calls the function
            }

            // Several if statements to check each boolean to ensure compatibility between poisondrop and lightning strike
            if (striketime > 0 || !poisoned) // If the striketime is more than 0 and isn't poisoned then do the following
            {
                playerspeed = 10; // Set the playerspeed to default
            }

            if (poisoned == true) // If the player caught the poison drop, they bool *poisoned* will become true, if it does then doing the following...
            {
                playerspeed = 3; // Set playerspeed
                poisonedtime -= 5; // Continuously count down the poison timer
            }

            if (poisonedtime < 0) // If the poison timer reached less than 0
            {
                poisoned = false; // Change this booleon to false
                playerspeed = 10; // Restore the playerspeed
            }

            if (poisoned == false) // If the player isn't poisoned
            {
                poisonedtime = 300; // reset the poisonedtime
            }

            if (striked == true && poisoned == true) // If the player is poisoned & striked by the lightning
            {
                playerspeed = 0; // Set the playerspeed to 0
            }

            if (striked == false && poisoned == true) // if the player is poisoned by isn't striked
            {
                playerspeed = 3; // set the player speed to 3
                poisonedtime -= 5; // continue with depleting the poisonedtime
            }

            if (striked == true && poisoned == false) // if the player has been strucked by the lightning however isn't poisoned
            {
                playerspeed = 0; //set player speed to 0
            }
        }

        // Lightning Strike Function
        public void strikelightning()
        {
            visibleTimer += 1; // Continuously adds 1 towards the visible timer which is responsible for the duration of lightning strike visibility

            lightningstrike.Left = player.Left; // Lightning strike will follow player's width/left

            if (visibleTimer < 25) // Set the duration of the lightning strike
            {
                lightningstrike.Visible = true; // Lightning strike appears
                playerspeed = 0; // Stops the player from moving
                striked = true; // change boolean to true
                lightningPlayer.Stream = Properties.Resources.lightning_sound; // Define which sound to play
                lightningPlayer.Play(); // Plays lightning strike sound
                // Reloop the background sound once the lightning strike stops playing
                backgroundPlayer.URL = "rain.wav"; // Location and the name of the file with the file extension type
                backgroundPlayer.settings.setMode("loop", true); // Loop the sound
                backgroundPlayer.Ctlcontrols.play(); // Play the sound
            }
            else
            {
                striked = false; // changes the boolean to false
                lightningstrike.Visible = false; // Hides lightning strike
                striketime = lightningRnd.Next(900, 1500); // Duration before the lightning strikes hit
                visibleTimer = 0; //Reset visibletimer to default
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

        private void mediumMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the game level closes, the level selector re-opens
            select_level levelSelector = new select_level();
            levelSelector.Show();
        }

        private void mediumMode_Load(object sender, EventArgs e)
        {
            // Once the game level launches, the level selector closes
            select_level levelselector = new select_level();
            levelselector.Close();
        }
    }
}
