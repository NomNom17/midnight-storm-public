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
    public partial class hardMode : Form
    {
        // Global Variables
        bool goright; // If the player moving right or not
        bool goleft; // If the player moving left or not
        int score = 0; // Set the score as 0
        int missed = 0; // Set the missed/chances to 0
        int speed = 6; // Set the speed that the rain falls at 
        int poisonspeed = 4; // Rate of the speed that the poison drop would fall
        int randomspeed = 5; // Rate of the speed that the random drop would fall
        int playerspeed = 10; // Speed that the player is moving at
        Random rainRndY = new Random(); // Rain spawn randomiser (Y location)
        Random rainRndX = new Random(); // Rain spawn randomiser (X Location)
        Random randomDrop = new Random(); // Randomise the effect of the random drop
        PictureBox splash = new PictureBox(); // Create new splash picturebox if the rain drop missed
        System.Media.SoundPlayer rain = new System.Media.SoundPlayer(); // Responsible for playing the rain audio file
        bool poisoned; // Whether if the player is poisoned or not
        int poisonedtime = 300; // Duration of the poison effect

        public hardMode()
        {
            InitializeComponent();
            Reset(); // Reset function (written below)

            // Windows Media Player (backgroundPlayer) - to counter the issue with the sounds ending each other
            backgroundPlayer.URL = "rain.wav"; // Giving the media player the location of the file & the file name with it's file extension type
            backgroundPlayer.settings.setMode("loop", true); // Making the sound loop
            backgroundPlayer.Ctlcontrols.play(); // Telling the media player to loop the sound
            backgroundPlayer.Visible = false; // Hides the media player to prevent an issue that causes the player to not move
        }

        private void Reset()
        {
            // Reset position of the raindrops & repeating the function again
            foreach (Control X in this.Controls) // Checking the components
            {
                if (X is PictureBox && (string)X.Tag == "raindrop") // Defining that X variable is a picturebox and has the tag of raindrop, this allows us to give the pictureboxes with their tags, functions to follow and do
                {
                    X.Top = rainRndY.Next(100, 300) * -1; // Setting the position where the raindrop would spawn into (X Axis)
                    X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Setting the position where the raindrop would spawn into (Y Axis)
                }
            }


            // Reset position of the poison drop & repeat the function again
            foreach (Control Z in this.Controls) // Checking the components and giving a local variable 
            {
                if (Z is PictureBox && (string) Z.Tag == "poisondrop") // Defining that Z variable is a picturebox and has the tag of poisondrop
                {
                    Z.Top = rainRndY.Next(100, 300) * -1; // reset the position where the poisondrop would spawn into
                    Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // reset the position where the poisondrop would spawn into
                }
            }

            // Reset position of the randomdrops & repeat the function again
            foreach (Control R in this.Controls) // Checking the components and giving a local variable
            {
                if (R is PictureBox && (string)R.Tag == "randomdrops") // Defining that R variable is a picturebox and has the tag of randomdrops
                {
                    R.Top = rainRndY.Next(100, 300) * -1; // reset the position of the randomdrop at Y axis which is where randomdrop would respawn into
                    R.Left = rainRndX.Next(5, this.ClientSize.Width - R.Width); // reset the position of the randomdrop at X axism which is where random drop would respawn into
                }
            }

            playerspeed -= player.Left; // Playerspeed value will continuously decrease player left (width) value. Player moves left.
            playerspeed += player.Left; // Playerspeed value will continuously increase player left (width) value. Player moves right.

            // Reset the image to default
            player.Image = Properties.Resources.player_left;

            // Stop the sounds from playing on reset
            rain.Stop();

            // Reset the integers back to default
            score = 0; // Score Counter
            missed = 0; // Missed counter 
            playerspeed = 10; // Player speed
            speed = 5; // The speed at which the rain drop would fall at
            poisonspeed = 4; // Rate of the speed that the poison drop would fall
            randomspeed = 5; // Rate of the speed that the random drop would fall

            // Reset the booleans to default to prevent player from moving while the game is resetting
            goleft = false;
            goright = false;

            poisoned = false; // Reset the player's poisoned status

            // Starts the timer back up
            gameTimer2.Start();
        }

        // Function when the user held a key down
        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // If the player presses the left key, it will do the following...
            {
                goleft = true; // Go left bool will become true
            }

            if (e.KeyCode == Keys.Right) // If the player presses the right key, it will do the following...
            {
                goright = true; // Go right bool will become true
            }
        }

        // Function when the user releases a key
        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // If the player releases the left key, it will do the following...
            {
                goleft = false; // Go left booleon will become false which stops the player from moving
            }

            if (e.KeyCode == Keys.Right) // If the player releases the right key, it will do the following...
            {
                goright = false; // Go left booleon will become false which stops the player from moving
            }
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
                player.Left -= playerspeed; // Amount of pixels the player will move to the left continuously (as long as goleft is true)
                player.Image = Properties.Resources.player_left; // changes the player's picturebox image to player_left
            }

            if (goright == true && player.Left + player.Width < this.ClientSize.Width) // Do the following below if goright is true, also prevents player going out of bounds by adding collision if the player touches the client/window's end of width
            {
                //player.Left += 24; // Amount of pixels the player will move to the right
                player.Left += playerspeed;
                player.Image = Properties.Resources.player_right; // changes player image to player_right
            }
            // Player movement ends here

            // Falling rain drop function
            foreach (Control X in this.Controls) // Given an variable of X
            {
                if (X is PictureBox && (string)X.Tag == "raindrop") // Telling the program that the variable X is a picturebox which has the tag of raindrop
                {
                    X.Top += speed; // The picturebox is continuously moving down in the amount that has been defined in the speed variable

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
                    }

                    // Win condition
                    if (score > 35) // If the player has more than 35 score
                    {   // Do the following.
                        gameTimer2.Stop(); // Stop the timer
                        MessageBox.Show("Congratulation! You've finished this level! Check out the other bonus levels. This level will now close and you will be directed to level selector."); // Shows the messagebox on screen with the following message.
                        this.Close(); // Self destruct itself
                    }

                    // Lose condition
                    if (missed > 5) // If player missed more than 5 rain drops
                    {   // Do the following.
                        gameTimer2.Stop(); // Stop the timer
                        MessageBox.Show("GAME OVER!!!! WE LOST GOOD RAINDROPS!" + "\r\n" + "Click OK to restart."); // Show the messagebox with the following message
                        Reset(); // Call the Reset function
                    }
                }
            }

            // Poison drop functionality
            foreach (Control Z in this.Controls) // Gives an variable for Control, which is Z
            {
                if (Z is PictureBox && (string)Z.Tag == "poisondrop") // Defined that Z is a picturebox
                {
                    Z.Top += poisonspeed; // The picturebox is continuously moving down in the amount that has been defined in the poisonspeed variable

                    if (Z.Top + Z.Height > this.ClientSize.Height) // If poisondrop height and top is more than window's height then do the following
                    {
                        splash.Image = Properties.Resources.bad_Splash; // changes the splash picturebox's image
                        splash.Location = Z.Location; // Place the splash picturebox at rain drop location
                        splash.Height = 119; // Height of the picturebox
                        splash.Width = 120; // Width of the picturebox
                        splash.BackColor = System.Drawing.Color.Transparent; // made the picturebox background colour transparent

                        this.Controls.Add(splash); // Adds the splash picturebox onto the game

                        // Respawns the rain at the top but randomly within the range
                        Z.Top = rainRndY.Next(80, 150); // Spawning location for raindrop (height / Y Axis)
                        Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // Spawning location for the rain drop (width / X Axis)
                    }

                    if (Z.Bounds.IntersectsWith(player.Bounds)) // If the Z (poisondrop) intersects with/touches the player's bounds then do the following
                    {
                        poisoned = true; // sets the playerspeed to 3 (currently not working)
                        Z.Top = rainRndY.Next(100, 300) * -1; // Spawning location for poisondrop (height / Y Axis)
                        Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // Spawning location for the poison drop (width / X Axis)
                    }
                }
            }

            // Random Drop Functionality
            foreach (Control R in this.Controls) // Gives an variable for Control which is R
            {
                if (R is PictureBox && (string)R.Tag == "randomdrop") // defined that R is a picturebox which has a tag of 'randomdrop'
                {
                    R.Top += randomspeed; // The picturebox is continuously moving down in the amount that has been defined in the randomspeed variable

                    //  If the randomdrop's top & height is more than the clientsize's height
                    if (R.Top + R.Height > this.ClientSize.Height)
                    {
                        splash.Image = Properties.Resources.random_Splash; // Spawn a splash image with the definted random splash image
                        splash.Location = R.Location; // Spawn the splash at the location of the randomdrop
                        splash.Height = 119; // Height of the splash
                        splash.Width = 120; // Width of the splash
                        splash.BackColor = System.Drawing.Color.Transparent; // Make the splash transparent

                        // Add the splash to the game
                        this.Controls.Add(splash);

                        // Respawn the random drop again
                        R.Top = rainRndY.Next(80, 150) * -1; // Spawning location for poisondrop (height / Y Axis)
                        R.Left = rainRndX.Next(5, this.ClientSize.Width - R.Width); // Spawning location for poisondrop (width / X Axis)
                    }

                    // If the random drop touches the player bounds
                    if (R.Bounds.IntersectsWith(player.Bounds))
                    {
                        int num = randomDrop.Next(1, 12); // Randomly does an effect within the first and the twelveth effect
                        switch (num) // Randomly selects a number between 1 & 12
                        {
                            case 1:
                                missed++; // Will add a miss to the integer
                                break;

                            case 2:
                                score++; // Will add a score point to the integer
                                break;

                            case 3:
                                GameOver(); // Immediantly ends the game
                                break;

                            case 4:
                                playerspeed = 20; // Set player speed to 20
                                break;

                            case 5:
                                playerspeed = 3; // Set player speed to 3
                                break;

                            case 6:
                                speed = 2; // Set the rain drops speed to 2
                                break;

                            case 7:
                                speed = 12; // Set the rain drops speed to 12
                                break;

                            case 8:
                                poisonspeed = 1; // Set the poison speed to 1
                                speed = 10; // Set the rainfall speed to 10
                                break;

                            case 9:
                                missed = 0; // Reset missed variable
                                score = 0; // Reset score variable
                                break;

                            case 10:
                                missed = 0; // Reset missed variable
                                break;

                            case 11:
                                speed = 10; // Speed of the rainfall is set at 10
                                poisonspeed = 8; // Poison drop fall speed is set at 8
                                randomspeed = 8; // Random drop fall speed is set at 8
                                break;

                            case 12:
                                speed = 5; // Set rainfall speed to 5
                                poisonspeed = 2; // Set poison drop speed to 2
                                randomspeed = 3; // Set random drop speed to 3
                                playerspeed = 10; // Set player speed to 10
                                break;
                        }

                        // Respawns the random drop
                        R.Top = rainRndY.Next(100, 300) * -1; // Spawning location for poisondrop (height / Y Axis)
                        R.Left = rainRndX.Next(5, this.ClientSize.Width - R.Width); // Spawning location for poisondrop (width / X Axis)
                    }

                }
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
        }

        // Game over function (exclusively used for random drop)
        private void GameOver()
        {
            gameTimer2.Stop(); // Stops the timer
            MessageBox.Show("GAME OVER!!!! WE LOST GOOD RAINDROPS!" + "\r\n" + "Click OK to restart."); // Show the messagebox
            Reset(); // Call the reset function to reset the game to return the level to default state
        }

        private void hardMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the game level closes, the level selector re-opens
            select_level levelSelector = new select_level();
            levelSelector.Show(); // Show the level selector
        }
    }
}