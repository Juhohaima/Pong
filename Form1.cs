using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pongipeli
{
    public partial class Form1 : Form
    {
        int ballXspeed = 4;
        int ballYspeed = 4;
        int speed = 2;
        Random rand = new Random(); // Pallolle valitaan satunnainen nopeus
        bool goDown, goUp;
        int computer_speed_change = 50; // Kuinka usein tietokoneen nopeus vaihtelee
        int playerScore = 0; // Pelaajan pistemäärä
        int computerScore = 0; // Tietokoneen pistemäärä
        int playerSpeed = 8;
        int [] i = {5, 6, 8, 9}; // Tietokoneen nopeus valitaan näistä numeroista
        int [] j = {10, 9, 8, 11, 12}; // Valitaan pallolle eri nopeus satunnaisesti (BallXspeed, ballYspeed)



        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;

            this.Text = "Player Score: " + playerScore + " -- Computer Score: " + computerScore; // Näyttää pistetilanteen ja päivittää sitä

            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed;
            }
            if (ball.Left < -2) // Kun pallo on osunut vasempaan reunaan, eli pelaaja on missannut pallon niin resetoidaan pallo keskelle
            {
                ball.Left = 300; // Resetoidaan pallo keskelle
                ballXspeed = -ballXspeed;
                computerScore++; // Lisätään piste tietokoneelle
            }
            if (ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300; // Resetoidaan pallo keskelle 
                ballXspeed = -ballXspeed; // Kun pallo on osunut oikeaan reunaan, eli tietokone on missannut pallon
                playerScore++; // Lisätään piste pelaajalle
            }
            // Tietokoneen liikehdintä

            if (computer.Top <= 1)
            {
                computer.Top = 0;
            }
            else if (computer.Bottom >= this.ClientSize.Height)
            {
                computer.Top = this.ClientSize.Height -computer.Height;
            }

            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top -=speed;
            }
            if (ball.Top > computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top +=speed;
            }

            computer_speed_change -= 1;

            if (computer_speed_change < 0)
            {
                speed = i[rand.Next(i.Length)];
                computer_speed_change = 50;
            }

            if (goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;
            }

            if (goUp && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }

            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, computer, computer.Left - 35);

            if (computerScore > 5)
            {
                GameOver("YOU ARE LOSER!"); // Jos tietokone voittaa, tulostetaan tämä viesti
            }
            else if (playerScore > 5)
            {
                GameOver("YOU ARE WINNER!"); // Jos pelaaja voittaa, tulostetaan tämä viesti
            }
        }




        private void KeyIsDown(object sender, KeyEventArgs e)
    {
            if (e.KeyCode == Keys.Down)
        {
                goDown = true; // Jos pelaaja painaa nuoli alaspäin, menee paddle alaspäin
        }
        if (e.KeyCode == Keys.Up)
        {
                goUp = true; // Jos pelaaja painaa nuoli ylöspäin, menee paddle ylöspäin
        }
    }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }

        private void CheckCollision(PictureBox Pic0ne, PictureBox PicTwo, int offset)
        {
            if (Pic0ne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                Pic0ne.Left = offset;

                int x = j[rand.Next(j.Length)];
                int y = j[rand.Next(j.Length)];

                if (ballXspeed < 0)
                {
                    ballXspeed = x;
                }
                else
                {
                    ballXspeed = -x;
                }

                if (ballYspeed < 0)
                {
                   ballYspeed = -y;
                }
                else
                {
                    ballYspeed = y;
                }
            }
        }


        private void GameOver(string message) // Kun pelaaja voittaa tai häviää näytetään viesti, sekä palautetaan pallon nopeus alkuperäiseen nopeuteen
        {
            GameTimer.Stop();
            MessageBox.Show(message, "FINAL SCORE ");
            computerScore = 0; // Kun peli päättyy resetoidaan pisteet tietokoneelta
            playerScore = 0; // Sama myös pelaajalle
            ballXspeed = ballYspeed = 4; // Resetoidaan pallon nopeus takaisin hitaampaan alkunopeuteen
            computer_speed_change = 50;
            GameTimer.Start(); // Aloitetaan pelikello
        }
    }
}
