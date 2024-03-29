using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merkleVA2
{
    public partial class Form1 : Form
    {

        List<TextBox[]> rows = new List<TextBox[]>();
        TextBox[] row1 = new TextBox[5];
        TextBox[] row2 = new TextBox[5];
        TextBox[] row3 = new TextBox[5];
        TextBox[] row4 = new TextBox[5];
        TextBox[] row5 = new TextBox[5];
        TextBox[] row6 = new TextBox[5];

        int rowIndex = 1, letterIndex = 1;

        string currentWord = "ABORT";

        bool youWin = false;
        bool youLose = false;

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (youWin)
            {
                System.Windows.Forms.MessageBox.Show("You win!!!");
                //Application.Restart();
                //break;
            }
            else if (youLose)
            {
                System.Windows.Forms.MessageBox.Show("You lose!!!");
                //Application.Restart();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyWasPressed(object sender, KeyPressEventArgs e)
        {
            int i = (int)e.KeyChar;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (youLose || youWin)
                return;

            if ((e.KeyValue >= 65 && e.KeyValue <= 90) || e.KeyValue == 221 || e.KeyValue == 222 || e.KeyValue == 192)
            {

                if (rows[rowIndex - 1][4].Text == "")
                {

                    rows[rowIndex - 1][letterIndex - 1].Text = e.KeyCode.ToString();
                    if (letterIndex < 5)
                        letterIndex++;

                }

            }
            else if (e.KeyCode == Keys.Enter && letterIndex == 5)
            {

                List<int> keepIndex = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    char correctC = currentWord[i];
                    char answeredC = rows[rowIndex - 1][i].Text[0];

                    if (correctC == answeredC)
                    {
                        rows[rowIndex - 1][i].BackColor = Color.Green;
                    }
                    else
                    {
                        keepIndex.Add(i);
                    }
                }

                List<char> correctLeft = new List<char>();
                List<char> answeredLeft = new List<char>();
                for (int i = 0; i < keepIndex.Count; i++)
                {
                    correctLeft.Add(currentWord[keepIndex[i]]);
                    answeredLeft.Add(rows[rowIndex - 1][keepIndex[i]].Text[0]);
                }

                foreach (char c in correctLeft)
                {
                    if (answeredLeft.Contains(c))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            char answeredC = rows[rowIndex - 1][i].Text[0];
                            if (answeredC == c && keepIndex.Contains(i))
                            {
                                rows[rowIndex - 1][i].BackColor = Color.Yellow;
                                answeredLeft.Remove(c);
                                keepIndex.Remove(i);
                                break;
                            }
                        }
                    }
                }

                bool winPossible = true;
                for (int i = 0; i < 5; i++)
                {
                    if (rows[rowIndex - 1][i].BackColor != Color.Green)
                    {
                        winPossible = false;
                        break;
                    }
                }
                if (winPossible)
                {
                    youWin = true;
                    return;
                }

                if (rowIndex < 6)
                {
                    rowIndex++;
                    letterIndex = 1;
                }
                else if (rowIndex == 6)
                {
                    bool win = true;
                    for (int i = 0; i < 5; i++)
                    {
                        if (rows[rowIndex - 1][i].BackColor != Color.Green)
                        {
                            win = false;
                            break;
                        }
                    }

                    if (win)
                        youWin = true;
                    else
                        youLose = true;
                }

            }
            else if (e.KeyCode == Keys.Back)
            {

                rows[rowIndex - 1][letterIndex - 1].Text = "";
                letterIndex--;
                if (letterIndex < 1)
                    letterIndex = 1;

            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            row1[0] = word1_letter1;
            row1[1] = word1_letter2;
            row1[2] = word1_letter3;
            row1[3] = word1_letter4;
            row1[4] = word1_letter5;
            rows.Add(row1);

            row2[0] = word2_letter1;
            row2[1] = word2_letter2;
            row2[2] = word2_letter3;
            row2[3] = word2_letter4;
            row2[4] = word2_letter5;
            rows.Add(row2);

            row3[0] = word3_letter1;
            row3[1] = word3_letter2;
            row3[2] = word3_letter3;
            row3[3] = word3_letter4;
            row3[4] = word3_letter5;
            rows.Add(row3);

            row4[0] = word4_letter1;
            row4[1] = word4_letter2;
            row4[2] = word4_letter3;
            row4[3] = word4_letter4;
            row4[4] = word4_letter5;
            rows.Add(row4);

            row5[0] = word5_letter1;
            row5[1] = word5_letter2;
            row5[2] = word5_letter3;
            row5[3] = word5_letter4;
            row5[4] = word5_letter5;
            rows.Add(row5);

            row6[0] = word6_letter1;
            row6[1] = word6_letter2;
            row6[2] = word6_letter3;
            row6[3] = word6_letter4;
            row6[4] = word6_letter5;
            rows.Add(row6);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    rows[i][j].Text = "";
                    rows[i][j].ForeColor = Color.White;
                    rows[i][j].Enabled = false;
                }
            }


        }
    }
}
