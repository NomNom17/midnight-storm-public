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
    public partial class extremeMode : Form
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
        Random lightningRnd = new Random(); // Lightning randomiser
        Random rainRndY = new Random(); // Rain spawn randomiser (Y location)
        Random rainRndX = new Random(); // Rain spawn randomiser (X Location)
        Random randomDrop = new Random(); // Randomise the effect of the random drop
        PictureBox splash = new PictureBox(); // Create new splash picturebox if the rain drop missed
        //int poisonTimer = 0; // Duration of the poison effect
        int striketime = 0; // The duration before the lightning strike's hit
        int visibleTimer = 0; // Duration of lightning strike being displayed
        System.Media.SoundPlayer lightningPlayer = new System.Media.SoundPlayer(); // For playing lightning audio file
        //System.Media.SoundPlayer rain = new System.Media.SoundPlayer(); // Responsible for playing the rain audio file
        bool poisoned; // Whether if the player is poisoned or not
        int poisonedtime = 300; // Duration of the poison effect
        bool striked; // A boolean that will be used with poisoned to help with compatibility between them

        public extremeMode()
        {
            InitializeComponent();
            Reset(); // Reset function
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
                if (X is PictureBox && (string) X.Tag == "raindrop") // Defining that X variable is picturebox with raindrop tag, this allows us to give the pictureboxes with their tags functions to follow and do
                {
                    X.Top = rainRndY.Next(100, 300) * -1; // Setting the position where the raindrop would spawn into (X Axis)
                    X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Setting the position where the raindrop would spawn into (Y Axis)
                }
            }

            // Reset position of the poison drop & repeat the function again
            foreach (Control Z in this.Controls) // Checking the components and giving a local variable 
            {
                if (Z is PictureBox && (string) Z.Tag == "poisondrop") // Giving the picturebox component a defined variable which has the tag of poisondrop
                {
                    Z.Top = rainRndY.Next(100, 300) * -1; // reset the position where the poisondrop would spawn into
                    Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // reset the position where the poisondrop would spawn into
                }
            }

            // Reset position of the random drop & repeat the function again
            foreach (Control R in this.Controls) // Checking the components and giving a local variable
            {
                if (R is PictureBox && (string) R.Tag == "randomdrop") // giving the picturebox component a defined variable which has the tag of randomdrop
                {
                    R.Top = rainRndY.Next(100, 300) * -1; // reset the position where the random drop would spawn into
                    R.Left = rainRndX.Next(5, this.ClientSize.Width - R.Width); // reset the position where the random drop would spawn into
                }
            }

            striketime = lightningRnd.Next(750, 1050); // Setting the duration before lightning strike hits at reset
            lightningstrike.Visible = false; // Hides the lightning strike picturebox

            playerspeed -= player.Left; // Playerspeed value will continuously decrease player left (width) value. Player moves left.
            playerspeed += player.Left; // Playerspeed value will continuously increase player left (width) value. Player moves right.

            // Reset the image to default
            player.Image = Properties.Resources.player_left;

            // Stop the sounds from playing on reset
            //rain.Stop();
            lightningPlayer.Stop();

            // Reset the integers back to default
            score = 0;
            missed = 0;
            playerspeed = 10;
            speed = 5;
            poisonspeed = 4; // Rate of the speed that the poison drop would fall
            randomspeed = 5; // Rate of the speed that the random drop would fall
            striketime = 0;
            visibleTimer = 0;

            // Reset the booleans to default to prevent player from moving while the game is resetting
            goleft = false;
            goright = false;

            // Reset the poison status
            poisoned = false;
            // Revert the player's striked status
            striked = false;

            // Starts the timer back up
            gameTimer3.Start();
        }

        private void GameOver()
        {
            gameTimer3.Stop(); // Stops the timer
            MessageBox.Show("GAME OVER!!!! WE LOST GOOD RAINDROPS!" + "\r\n" + "Click OK to restart."); // Show the messagebox
            Reset(); // Calls the reset function
        }

        private void GameTick(object sender, EventArgs e)
        {
            // Label Counter Starts here
            score_label.Text = "Raindrops Caught: " + score; // Changes the label text to add the score variable
            // missed_label.Text = "Missed: " + missed; // Changes the label text to add the missed variable - Extreme mode won't be able to see the label on the form to add a bit more challenge to the player.
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
                if (X is PictureBox && X.Tag == "raindrop") // Telling the program that the variable X is a picturebox which has the tag of raindrop
                {
                    X.Top += speed; // Increase the rate that the raindrop is falling at

                    if (X.Top + X.Height > this.ClientSize.Height) // If raindrop height and top is more than window's height then do the following
                    {
                        splash.Image = Properties.Resources.Splash; // changes the splash picturebox image
                        splash.Location = X.Location; // Place the splash picturebox at rain drop location
                        splash.Height = 119; // Height of the picturebox
                        splash.Width = 120; // Width of the picturebox
                        splash.BackColor = System.Drawing.Color.Transparent; // made the picturebox background colour transparent

                        this.Controls.Add(splash); // Adds the splash picturebox onto the game

                        // Respawns the rain at the top but randomly within the range
                        X.Top = rainRndY.Next(100, 300); // Spawning location for raindrop (height / Y Axis)
                        X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Spawning location for the rain drop (width / X Axis)
                        missed++; // Adds to missed counter integer
                    }

                    // Score system, if raindrop touches the player, it will add a point and respawn the raindrop at the top
                    if (X.Bounds.IntersectsWith(player.Bounds))
                    {
                        X.Top = rainRndY.Next(100, 300) * -1; // Spawning location for raindrop (height / Y Axis)
                        X.Left = rainRndX.Next(5, this.ClientSize.Width - X.Width); // Spawning location for raindrop (width / X Axis)
                        score++; // Adds a score
                    }

                    // Score Condition
                    if (score > 20) // If the player has more than 20 score
                    {   // Do the following.
                        speed = 8; // Increase rain speed
                    }

                    // Win condition
                    if (score > 50) // If the player has more than 50 score (score changed to 50 instead of 35 to increase difficulty)
                    {   // Do the following.
                        gameTimer3.Stop(); // Stop the timer
                        MessageBox.Show("Congratulation! You've finished the game!"); // Shows the messagebox on screen with the following message.
                        this.Close(); // Self destruct itself
                    }

                    // Lose condition
                    if (missed > 5) // If player missed more than 5 rain drops
                    {   // Do the following.
                        gameTimer3.Stop(); // Stop the timer
                        MessageBox.Show("GAME OVER!!!! You lose!" + "\r\n" + "Click OK to restart."); // Show the messagebox with the following message
                        Reset(); // Call the Reset function
                    }
                }
            }

            // Poison drop functionality
            foreach (Control Z in this.Controls) // Gives an variable for Control - Z
            {
                if (Z is PictureBox && Z.Tag == "poisondrop") // Defined that Z is a picturebox
                {
                    Z.Top += poisonspeed; // Increase the rate that the poisondrop is falling at

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

                    if (Z.Bounds.IntersectsWith(player.Bounds)) // If the poison drop touches the players' bounds
                    {
                        poisoned = true; // change poisoned booleon to true
                        Z.Top = rainRndY.Next(100, 300) * -1; // respawn the poison drop in the given location (Y Axis / Height)
                        Z.Left = rainRndX.Next(5, this.ClientSize.Width - Z.Width); // Respawns the poison drop in the given location (X Axis/Width)
                    }
                }
            }

            // Random Drop Functionality
            foreach (Control R in this.Controls) // Gives an variable for Control which is R
            {
                if (R is PictureBox && (string) R.Tag == "randomdrop")  // defined that R is a picturebox which has a tag of 'randomdrop'
                {
                    R.Top += randomspeed; // The picturebox is continuously moving down in the amount that has been defined in the randomspeed variable

                    if (R.Top + R.Height > this.ClientSize.Height) //  If the randomdrop's top & height is more than the clientsize's height
                    {
                        splash.Image = Properties.Resources.random_Splash; // Spawn a splash image with the definted random splash image
                        splash.Location = R.Location; // Spawn the splash at the location of the randomdrop
                        splash.Height = 119; // Height of the splash
                        splash.Width = 120; // Width of the splash
                        splash.BackColor = System.Drawing.Color.Transparent; // make the splash image transparent

                        // Add the splash to the game
                        this.Controls.Add(splash);

                        // Respawn the random drop again
                        R.Top = rainRndY.Next(80, 150) * -1; // Spawning location for poisondrop (height / Y Axis)
                        R.Left = rainRndX.Next(5, this.ClientSize.Width - R.Width); // Spawning location for poisondrop (width / X Axis)
                    }

                    // If the random drop touches the player bounds
                    if (R.Bounds.IntersectsWith(player.Bounds))
                    {
                        int num = randomDrop.Next(1, 14); // Randomly does an effect within the 1st & 14th effect
                        switch (num)// Randomly selects a number between 1 & 14
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
                                speed = 12; // Speed of the rainfall is set at 12
                                poisonspeed = 8; // Speed of the poison drop is set at 12
                                randomspeed = 8; // Speed of the random drop is set at 12
                                playerspeed = 15; // speed of the player changes to 15
                                break;

                            case 12:
                                speed = 5; // Set rainfall speed to 5
                                poisonspeed = 2; // Set poison speed to 2
                                randomspeed = 3; // Set random drop speed to 3
                                playerspeed = 10; // Set playerspeed speed to 10
                                break;

                            case 13:
                                striketime = lightningRnd.Next(2000, 3000); // Set the strike time for a longer duration
                                break;

                            case 14:
                                striketime = lightningRnd.Next(750, 800); // Set the strike time for a shorter duration
                                break;

                        }

                        // Respawns the random drop
                        R.Top = rainRndY.Next(100, 300) * -1; // Spawning location for poisondrop (height / Y Axis)
                        R.Left = rainRndX.Next(5, this.ClientSize.Width - R.Width); // Spawning location for poisondrop (width / X Axis)
                    }

                    // Decreasing the striketime
                    striketime -= 5;

                    // When striketime hits less than 0 then will call the strikelightning function
                    if (striketime < 0)
                    {
                        strikelightning(); // Calls the function
                    }

                    // Several if statements to check each boolean to ensure compatibility between poisondrop and lightning strike
                    // If the striketime is more than 0 and isn't poisoned then do the following
                    if (striketime > 0 || !poisoned)
                    {
                        playerspeed = 10; // Set the playerspeed to default
                    }

                    if (poisoned == true) // If the player is poisoned then do the following
                    {
                        playerspeed = 3; // Set playerspeed to 3
                        poisonedtime -= 5; // continuously decrease the poisonedtime every 5 integer
                    }

                    if (poisonedtime < 0) // If the poisonedtime is less than 0
                    {
                        poisoned = false; // change this booleon back to false
                        playerspeed = 10; // set the playerspeed to 10
                    }

                    if (poisoned == false) // if the player is not poisoned
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
                striketime = lightningRnd.Next(750, 1050); // Duration before the lightning strikes hit
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

        private void extremeMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Creates a new instance of level selector
            select_level levelselector = new select_level();
            levelselector.Show(); // Shows the level selector form
        }

        private void extremeMode_Load(object sender, EventArgs e)
        {

        }
    }
}
