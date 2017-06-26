using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triliza

{
    public partial class Form1 : Form
    {
        
        bool turn = true; // X if turn is true and O if turn is false
       int turn_count=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By Stathis", "About Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult r= MessageBox.Show("Do you really want to exit?", "Exit Tic Tac Toe", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
            else {}
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            CheckForWinner();
            turn_count++;
        }
        private void CheckForWinner()
        {
            bool check_for_winner = false;
            //vertical check
            if (A1.Text == A2.Text && A2.Text == A3.Text &&!A1.Enabled)
                check_for_winner = true;
            if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled)
                check_for_winner = true;
            if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled)
                check_for_winner = true;
            //horizontal check
            if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled)
                check_for_winner = true;
            if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled)
                check_for_winner = true;
            if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled)
                check_for_winner = true;
            //diagonal check
            if (C1.Text == B2.Text && B2.Text == A3.Text && !C1.Enabled)
                check_for_winner = true;
            if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled)
                check_for_winner = true;
            if (check_for_winner)
            {
                if (turn)
                {
                    MessageBox.Show("Player 'O' is the winner!!");
                    o_count.Text = (Int32.Parse(o_count.Text) + 1).ToString() ;
                    Asking_For_New_Game();
                    
                }
                else
                {
                    MessageBox.Show("Player 'X' is the winner!!");
                    x_count.Text = (Int32.Parse(x_count.Text) + 1).ToString() ;
                    Asking_For_New_Game();
                }
                
            }
            if (!check_for_winner && turn_count == 8) {
                MessageBox.Show("Draw!");
                draws_count.Text = (Int32.Parse(draws_count.Text) + 1).ToString() ;
                Asking_For_New_Game();
            }
           
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch
                { }
            }
            Reset.Text = "Reset";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Asking_For_New_Game()
        {
            turn = true;
            turn_count = 0;
            Button[] buttons = { A1, A2, A3, B1, B2, B3, C1, C2,C3};
            DialogResult r = MessageBox.Show("Do you want to start a new game?", "New Triliza", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch
                    { }
                    Reset.Text = "Reset";
                }
            }
            //disable buttons
            
            else {
                for (int i = 0; i < 9; i++)
                {
                    buttons[i].Enabled = false;
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            o_count.Text = "0";
            x_count.Text = "0";
            draws_count.Text = "0";
        }
    }
}

