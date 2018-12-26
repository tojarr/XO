using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        Button lastMovePlayer = new Button();
        bool isChekedX = true;
        int count = 0;
        string isTextComp = "";
        bool playerFirst = true;
        bool isPlayer = true;
        bool isCompEasy = false;
        bool isCompMedium = true;
        bool isCompHard = false;
        bool isOver = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void position_Click(object sender, EventArgs e)
        {
            isOver = false;
            Button pos = (Button)sender;
            lastMovePlayer = pos;
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;

            if (isCompEasy)
            {
                NextMove(pos);
                if (!isOver)
                {
                    CompMoveEasy();
                }
            }
            else if (isCompMedium)
            {
                NextMove(pos);
                if (!isOver)
                {
                    CompMoveHard();
                }
            }
            else if (isCompHard)
            {
                NextMove(pos);
                if (!isOver)
                {
                    CompMoveHard();
                }
            }
            else
            {
                NextMove(pos);
            }
        }

        private void IsWin()
        {
            if (position1.Text != "" && position1.Text == position2.Text &&
                position2.Text == position3.Text)
            {
                PrintResult("Win " + position1.Text);
            }
            else if (position4.Text != "" && position4.Text == position5.Text &&
                position5.Text == position6.Text)
            {
                PrintResult("Win " + position4.Text);
            }
            else if (position7.Text != "" && position7.Text == position8.Text &&
                position8.Text == position9.Text)
            {
                PrintResult("Win " + position7.Text);
            }
            else if (position1.Text != "" && position1.Text == position4.Text &&
                position4.Text == position7.Text)
            {
                PrintResult("Win " + position1.Text);
            }
            else if (position2.Text != "" && position2.Text == position5.Text &&
                position5.Text == position8.Text)
            {
                PrintResult("Win " + position2.Text);
            }
            else if (position3.Text != "" && position3.Text == position6.Text &&
                position6.Text == position9.Text)
            {
                PrintResult("Win " + position3.Text);
            }
            else if (position1.Text != "" && position1.Text == position5.Text &&
                position5.Text == position9.Text)
            {
                PrintResult("Win " + position1.Text);
            }
            else if (position3.Text != "" && position3.Text == position5.Text &&
                position5.Text == position7.Text)
            {
                PrintResult("Win " + position3.Text);
            }
            if (count > 8)
            {
                PrintResult("Draw");
            }
        }

        void NextMove(Button pos)
        {
            if (isChekedX)
            {
                pos.Text = "X";
            }
            else
            {
                pos.Text = "O";
            }
            textBox2.Text = ChangeIsText(pos.Text);
            isChekedX = !isChekedX;
            pos.Enabled = false;
            count++;
            IsWin();
        }

        void CompMoveEasy()
        {
            NextMove(GetRandomPosition());
        }

        void CompMovemedium()
        {
            Button pos = new Button();
            
            pos = GetWinPosition(isTextComp);
            if (pos.Name == "")
            {
                pos = GetWinPosition(ChangeIsText(isTextComp));
            }
            if (pos.Name == "")
            {
                pos = GetRandomPosition();
            }
            NextMove(pos);
        }

        void CompMoveHard()
        {
            Button pos = new Button();

            if (count > 0)
            {
                pos = GetWinPosition(isTextComp);
                if(pos.Name == "")
                {
                    pos = GetWinPosition(ChangeIsText(isTextComp));
                }
                if (pos.Name == "")
                {
                    pos = GetPosition();
                }
                if (pos.Name == "")
                {
                    pos = GetRandomPosition();
                }
            }
            else
            {
                pos = position1;
            }
            NextMove(pos);
        }

        void PrintResult(string str = "")
        {
            MessageBox.Show(str);
            Reload();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void XToolStripMenuPlayer_Click(object sender, EventArgs e)
        {
            isPlayer = true;
            playerFirst = true;
            isChekedX = true;
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
        }

        private void OToolStripMenuPlayer_Click(object sender, EventArgs e)
        {
            isPlayer = true;
            playerFirst = false;
            isChekedX = false;
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox2.Text = "O";
        }

        private void XToolStripMenuCompEasy_Click(object sender, EventArgs e)
        {
            playerFirst = true;
            isChekedX = true;
            isCompEasy = true;
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox3.Text = "CompVsPlayer";
        }

        private void OToolStripMenuCompEasy_Click(object sender, EventArgs e)
        {
            playerFirst = false;
            isChekedX = true;
            isCompEasy = true;
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox3.Text = "CompVsPlayer";
            CompMoveEasy();
        }

        private void XToolStripMenuCompMedium_Click(object sender, EventArgs e)
        {
            playerFirst = true;
            isChekedX = true;
            isCompMedium = true;
            isTextComp = "O";
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox3.Text = "CompVsPlayer";
        }

        private void OToolStripMenuCompMedium_Click(object sender, EventArgs e)
        {
            playerFirst = false;
            isChekedX = true;
            isCompMedium = true;
            isTextComp = "X";
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox3.Text = "CompVsPlayer";
            CompMovemedium();
        }

        private void XToolStripMenuCompHard_Click(object sender, EventArgs e)
        {
            playerFirst = true;
            isChekedX = true;
            isCompHard = true;
            isTextComp = "O";
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox3.Text = "CompVsPlayer";
        }

        private void OToolStripMenuCompHard_Click(object sender, EventArgs e)
        {
            playerFirst = false;
            isChekedX = true;
            isCompHard = true;
            isTextComp = "X";
            playerVsPlayerMenu.Enabled = false;
            compVsPlayerMenu.Enabled = false;
            textBox3.Text = "CompVsPlayer";
            CompMoveHard();
        }

        void Reload()
        {
            for (int i = 1; i < 10; i++)
            {
                Controls.Find("position" + i.ToString(), false).First().ResetText();
                Controls.Find("position" + i.ToString(), false).First().Enabled = true;
            }
            count = 0;
            isOver = true;
            if(playerFirst)
            {
                if (isCompEasy)
                {
                    isChekedX = true;
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox3.Text = "CompVsPlayer";
                }
                else if (isCompMedium)
                {
                    isChekedX = true;
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox3.Text = "CompVsPlayer";
                }
                else if (isCompHard)
                {
                    isChekedX = true;
                    isTextComp = "O";
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox3.Text = "CompVsPlayer";
                }
                else if (isPlayer)
                {
                    isChekedX = true;
                    textBox2.Text = "X";
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                }
            }
            else
            {
                if (isCompEasy)
                {
                    isChekedX = true;
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox3.Text = "CompVsPlayer";
                    CompMoveEasy();
                }
                else if (isCompMedium)
                {
                    isChekedX = true;
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox3.Text = "CompVsPlayer";
                    CompMovemedium();
                }
                else if (isCompHard)
                {
                    isChekedX = true;
                    isTextComp = "X";
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox3.Text = "CompVsPlayer";
                    CompMoveHard();
                }
                else if (isPlayer)
                {
                    isChekedX = false;
                    playerVsPlayerMenu.Enabled = false;
                    compVsPlayerMenu.Enabled = false;
                    textBox2.Text = "O";
                }
            }
        }

        Button[] GetPositionArraw()
        {
            return new Button[9] { position1, position2, position3, position4,
                position5, position6, position7, position8, position9};
        }

        Button GetRandomPosition()
        {
            Button pos = new Button();
            Random rnd = new Random();
            Button[] arr = GetPositionArraw();
            while (pos.Text == "")
            {
                int i = (rnd.Next(9));
                if (arr[i].Enabled)
                {
                    return arr[i];
                }
            }
            return pos;
        }

        Button GetPosition()
        {
            Button pos = new Button();

            if (lastMovePlayer == position5)
            {
                if (position1.Enabled)
                {
                    pos = position1;
                }
                else if (position3.Enabled)
                {
                    pos = position3;
                }
                else if (position7.Enabled)
                {
                    pos = position7;
                }
                else if (position9.Enabled)
                {
                    pos = position9;
                }
            }
            else if (position5.Enabled)
            {
                pos = position5;
            }
            else if (lastMovePlayer == position1 || lastMovePlayer == position3 || lastMovePlayer == position7 || lastMovePlayer == position9)
            {
                if (lastMovePlayer == position1)
                {
                    if (position3.Enabled)
                    {
                        pos = position3;
                    }
                    else if (position7.Enabled)
                    {
                        pos = position7;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                }
                else if (lastMovePlayer == position3)
                {
                    if (position1.Enabled)
                    {
                        pos = position1;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                    else if (position7.Enabled)
                    {
                        pos = position7;
                    }
                }
                else if (lastMovePlayer == position7)
                {
                    if (position1.Enabled)
                    {
                        pos = position1;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                    else if (position3.Enabled)
                    {
                        pos = position3;
                    }
                }
                else if (lastMovePlayer == position9)
                {
                    if (position7.Enabled)
                    {
                        pos = position7;
                    }
                    else if (position3.Enabled)
                    {
                        pos = position3;
                    }
                    else if (position1.Enabled)
                    {
                        pos = position1;
                    }
                }
            }
            else if (lastMovePlayer == position2 || lastMovePlayer == position4 || lastMovePlayer == position6 || lastMovePlayer == position8)
            {
                if (lastMovePlayer == position2)
                {
                    if (position7.Enabled)
                    {
                        pos = position7;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                    else if (position3.Enabled)
                    {
                        pos = position3;
                    }
                    else if (position1.Enabled)
                    {
                        pos = position1;
                    }
                }
                else if (lastMovePlayer == position4)
                {
                    if (position3.Enabled)
                    {
                        pos = position3;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                    else if (position7.Enabled)
                    {
                        pos = position7;
                    }
                    else if (position1.Enabled)
                    {
                        pos = position1;
                    }
                }
                else if (lastMovePlayer == position6)
                {
                    if (position1.Enabled)
                    {
                        pos = position1;
                    }
                    else if (position7.Enabled)
                    {
                        pos = position7;
                    }
                    else if (position3.Enabled)
                    {
                        pos = position3;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                }
                else if (lastMovePlayer == position8)
                {
                    if (position1.Enabled)
                    {
                        pos = position1;
                    }
                    else if (position3.Enabled)
                    {
                        pos = position3;
                    }
                    else if (position7.Enabled)
                    {
                        pos = position7;
                    }
                    else if (position9.Enabled)
                    {
                        pos = position9;
                    }
                }
            }
            return pos;
        }

        Button GetWinPosition(string text)
        {
            Button pos = new Button();
            
            if (position1.Text == position2.Text && position1.Text == text || position1.Text == position3.Text && position1.Text == text
                || position2.Text == position3.Text && position2.Text == text)
            {
                if (position1.Enabled)
                {
                    return position1;
                }
                else if (position2.Enabled)
                {
                    return position2;
                }
                else if (position3.Enabled)
                {
                    return position3;
                }
            }
            if (position4.Text == position5.Text && position4.Text == text || position4.Text == position6.Text && position4.Text == text
                || position5.Text == position6.Text && position5.Text == text)
            {
                if (position4.Enabled)
                {
                    return position4;
                }
                else if (position5.Enabled)
                {
                    return position5;
                }
                else if (position6.Enabled)
                {
                    return position6;
                }
            }
            if (position7.Text == position8.Text && position7.Text == text || position7.Text == position9.Text && position7.Text == text
                || position8.Text == position9.Text && position8.Text == text)
            {
                if (position7.Enabled)
                {
                    return position7;
                }
                else if (position8.Enabled)
                {
                    return position8;
                }
                else if (position9.Enabled)
                {
                    return position9;
                }
            }
            if (position1.Text == position4.Text && position1.Text == text || position1.Text == position7.Text && position1.Text == text
                || position4.Text == position7.Text && position4.Text == text)
            {
                if (position1.Enabled)
                {
                    return position1;
                }
                else if (position4.Enabled)
                {
                    return position4;
                }
                else if (position7.Enabled)
                {
                    return position7;
                }
            }
            if (position2.Text == position5.Text && position2.Text == text || position2.Text == position8.Text && position2.Text == text
                || position5.Text == position8.Text && position5.Text == text)
            {
                if (position2.Enabled)
                {
                    return position2;
                }
                else if (position5.Enabled)
                {
                    return position5;
                }
                else if (position8.Enabled)
                {
                    return position8;
                }
            }
            if (position3.Text == position6.Text && position3.Text == text || position3.Text == position9.Text && position3.Text == text
                || position6.Text == position9.Text && position6.Text == text)
            {
                if (position3.Enabled)
                {
                    return position3;
                }
                else if (position6.Enabled)
                {
                    return position6;
                }
                else if (position9.Enabled)
                {
                    return position9;
                }
            }
            if (position1.Text == position5.Text && position1.Text == text || position1.Text == position9.Text && position1.Text == text
                || position5.Text == position9.Text && position5.Text == text)
            {
                if (position1.Enabled)
                {
                    return position1;
                }
                else if (position5.Enabled)
                {
                    return position5;
                }
                else if (position9.Enabled)
                {
                    return position9;
                }
            }
            if (position3.Text == position5.Text && position3.Text == text || position3.Text == position7.Text && position3.Text == text
                || position5.Text == position7.Text && position5.Text == text)
            {
                if (position3.Enabled)
                {
                    return position3;
                }
                else if (position5.Enabled)
                {
                    return position5;
                }
                else if (position7.Enabled)
                {
                    return position7;
                }
            }

            return pos;
        }

        string ChangeIsText(string text)
        {
            if(text == "X")
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }
    }
}
