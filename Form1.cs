using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoecsharp
{
    public partial class Form1 : Form
    {
        //True =X, False = Y
        bool turn = true;
        // overall 9 turns,and it means draw
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3 in a row wins", "Click the window to mark X or Y");
        }//message box block ends

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//exit button

        private void clickthebutton(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            turnCount++;
            //index starts with 0 and ++ -> 1.2.3 etc.
            b.Enabled = false;
            winnercheck();
        }//clickthebutton block ends
        private void winnercheck()
        {
            bool foundwinner = false;
            if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled)) foundwinner = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c2.Text) && (!c1.Enabled)) foundwinner = true;
            //diagonal wins
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled)) foundwinner = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled)) foundwinner = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled)) foundwinner = true;
            //vertical wins
            else if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled)) foundwinner = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled)) foundwinner = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled)) foundwinner = true;
            //horizontal wins

            if (foundwinner)
            {
                disableb();
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " Wins!");
            }//if foundwinner block ends
            else
            {
                if (turnCount == 9)
                    MessageBox.Show("Draw!");
            }//draw else block
        }
        private void disableb()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//foreach block ends
            }//try block ends
            catch { }
            //catch is empty but still nessecary
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    
                    Button b = (Button)c;
                    //enable button to this block
                    b.Enabled = true;
                    b.Text = "";
                }//foreach block ends
            }//try block ends
            catch { }

        }
        //new game block ends
    }
}
