using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Yahtzee
{
    public partial class frmYahtzee : Form
    {
        private List<Dice> dice = new List<Dice>
        {
            //create 5 dice objects
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
        };

        private int numRolls;
        private List<Button> holdButtons = new List<Button>();
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private Random random = new Random();
        private List<TextBox> firstSectionScores = new List<TextBox>();
        private List<TextBox> secondSectionScores = new List<TextBox>();
        private bool firstSectionComplete, secondSectionComplete;
        private int yatzeeBonus = 0;

        public frmYahtzee()
        {
            InitializeComponent();
            AssignGameControls();
        }

        private void AssignGameControls()
        {

            //populate list of picture boxes
            pictureBoxes.Add(dice1);
            pictureBoxes.Add(dice2);
            pictureBoxes.Add(dice3);
            pictureBoxes.Add(dice4);
            pictureBoxes.Add(dice5);

            //populate list of section 1 Text Boxes
            firstSectionScores.Add(txtDice1);
            firstSectionScores.Add(txtDice2);
            firstSectionScores.Add(txtDice3);
            firstSectionScores.Add(txtDice4);
            firstSectionScores.Add(txtDice5);
            firstSectionScores.Add(txtDice6);

            //populate list of section 2 Text Boxes
            secondSectionScores.Add(txtTotalof3Kind);
            secondSectionScores.Add(txtTotalof4Kind);
            secondSectionScores.Add(txt25Points);
            secondSectionScores.Add(txtSmStraight);
            secondSectionScores.Add(txtLgStraight);
            secondSectionScores.Add(txtYahtzee);
            secondSectionScores.Add(txtChance);


        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            RollDice();

            numRolls++; //increment numRolls on every click

            //if first roll enable hold buttons
            if (numRolls == 1)
            {
                foreach (Button b in holdButtons)
                {
                    b.Enabled = true;
                }
            }

            //if third roll turn roll button off
            if (numRolls == 3)
            {
                btnRoll.BackColor = Color.LightGray;
                btnRoll.Enabled = false;
            }
        }

        private void RollDice()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                if (!dice[i].Hold)
                {
                    dice[i].Value = random.Next(6) + 1;
                    setImage(dice[i].Value, pictureBoxes[i]);
                }
            }

        }

        private void setImage(int v, PictureBox pictureBox)
        {
            switch (v)
            {
                case 1:
                    pictureBox.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBox.Image = Properties.Resources._6;
                    break;
            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void reload()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                dice[i] = new Dice();
                pictureBoxes[i].Image = null;
                //holdButtons[i].Enabled = false;
                //holdButtons[i].BackColor = Color.White;
            }

            btnRoll.BackColor = Color.Blue;
            btnRoll.Enabled = true;
            numRolls = 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice die in dice)
            {
                if (die.Value == 1)
                {
                    score += die.Value;
                }
            }

            txtDice1.Text = score.ToString();
            btn1.BackColor = Color.White;
            btn1.Enabled = false;
            checkSection1();
            reload();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice die in dice)
            {
                if (die.Value == 2)
                {
                    score += die.Value;
                }
            }

            txtDice2.Text = score.ToString();
            btn2.BackColor = Color.White;
            btn2.Enabled = false;
            checkSection1();
            reload();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice die in dice)
            {
                if (die.Value == 3)
                {
                    score += die.Value;
                }
            }

            txtDice3.Text = score.ToString();
            btn3.BackColor = Color.White;
            btn3.Enabled = false;
            checkSection1();
            reload();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice die in dice)
            {
                if (die.Value == 4)
                {
                    score += die.Value;
                }
            }

            txtDice4.Text = score.ToString();
            btn4.BackColor = Color.White;
            btn4.Enabled = false;
            checkSection1();
            reload();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice die in dice)
            {
                if (die.Value == 5)
                {
                    score += die.Value;
                }
            }

            txtDice5.Text = score.ToString();
            btn5.BackColor = Color.White;
            btn5.Enabled = false;
            checkSection1();
            reload();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice die in dice)
            {
                if (die.Value == 6)
                {
                    score += die.Value;
                }
            }

            txtDice6.Text = score.ToString();
            btn6.BackColor = Color.White;
            btn6.Enabled = false;
            checkSection1();
            reload();
        }

        private void checkSection1()
        {
            int count = 0;
            int bonus = 35;
            int total = 0;

            //count first section labels that are not blank
            foreach (TextBox l in firstSectionScores)
            {
                if (l.Text != "")
                {
                    count++;
                }
            }

            //if count is 6 first section is complete
            if (count == 6)
            {
                //add scores to total
                foreach (TextBox l in firstSectionScores)
                {
                    total += Convert.ToInt32(l.Text);
                }

                //display total
                txtSectionLabel1.Text = total.ToString();

                //if total is greater than 63 give bonus
                if (total >= 63)
                {
                    txtBonus.Text = bonus.ToString();
                    total += bonus;
                }
                else
                {
                    txtBonus.Text = "0";
                }

                firstSectionComplete = true;
                GameOver();
            }

        }
        private void checkSection2()
        {
            int count = 0;
            int total = 0;

            foreach (TextBox l in secondSectionScores)
            {
                if (l.Text != "")
                {
                    count++;
                }
            }

            if (count == 7)
            {
                foreach (TextBox l in secondSectionScores)
                {
                    total += Convert.ToInt32(l.Text);
                }

                txtSectionLabel2.Text = total.ToString();
                secondSectionComplete = true;
                GameOver();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmYahtzee_Load(object sender, EventArgs e)
        {

        }

        private void btnTotalof3Kind_Click(object sender, EventArgs e)
        {
            //counts is an array for each value on a die. A loop goes through the dice 
            //and increases that index in the array.
            int score = 0;
            bool hasThree = false;
            int[] counts = new int[6];

            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i].Value != 0)
                {
                    counts[dice[i].Value - 1]++;
                    score += dice[i].Value; //add all dice for score
                }
            }

            //loop checks to see if any of the values in counts are 3 or greater. If so, sets hasThree to true
            foreach (int i in counts)
            {
                if (i >= 3)
                {
                    hasThree = true;
                    break;
                }
            }
            if (!hasThree)
            {
                score = 0; //set score back to zero if array doesn't have 3
            }

            btnTotalof3Kind.BackColor = Color.White;
            btnTotalof3Kind.Enabled = false;
            txtTotalof3Kind.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btnTotalof4Kind_Click(object sender, EventArgs e)
        {
            //counts is an array for each value on a die. A loop goes through the dice 
            //and increases that index in the array. 
            int score = 0;
            bool hasFour = false;
            int[] counts = new int[6];

            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i].Value != 0)
                {
                    counts[dice[i].Value - 1]++;
                    score += dice[i].Value; //add to all dice for score
                }
            }

            //loop checks to see if any of the values in counts are 4 or greater. If so, sets hasFour to true
            foreach (int i in counts)
            {
                if (i >= 4)
                {
                    hasFour = true;
                    break;
                }
            }
            if (!hasFour)
            {
                score = 0; //set total back to zero if array doesn't have 4
            }

            btnTotalof4Kind.BackColor = Color.White;
            btnTotalof4Kind.Enabled = false;
            txtTotalof4Kind.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btn25Points_Click(object sender, EventArgs e)
        {
            //counts is an array for each value on a die. A loop goes through the dice 
            //and increases that index in the array. 
            int score = 0;
            bool hasTwo = false;
            bool hasThree = false;
            int[] counts = new int[6];

            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i].Value != 0)
                {
                    counts[dice[i].Value - 1]++;
                }
            }

            //loop checks to see if any of the values in counts are 2 or 3. 
            //If so, sets hasTwo or hasThree to true.
            foreach (int i in counts)
            {
                if (i == 3)
                {
                    hasThree = true;
                }
                if (i == 2)
                {
                    hasTwo = true;
                }
            }

            if (hasTwo && hasThree)
            {
                score = 25; //if hand has set of 2 and 3 score = 25
            }

            btn25Points.BackColor = Color.White;
            btn25Points.Enabled = false;
            txt25Points.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btnSmStraight_Click(object sender, EventArgs e)
        {
            dice.Sort();
            int score = 0;
            int run = 1;
            for (int i = 0; i < dice.Count - 1; i++)
            {
                if (dice[i + 1].Value == dice[i].Value + 1)
                {
                    run++;
                }
            }
            if (run >= 4)
            {
                score = 30;
            }

            btnSmStraight.BackColor = Color.White;
            btnSmStraight.Enabled = false;
            txtSmStraight.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btnLgStraight_Click(object sender, EventArgs e)
        {
            dice.Sort();
            int score = 0;
            int run = 1;
            for (int i = 0; i < dice.Count - 1; i++)
            {
                if (dice[i + 1].Value == dice[i].Value + 1)
                {
                    run++;
                }
            }
            if (run == 5)
            {
                score = 40;
            }

            btnLgStraight.BackColor = Color.White;
            btnLgStraight.Enabled = false;
            txtLgStraight.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btnYahtzee_Click(object sender, EventArgs e)
        {
            //counts is an array for each value on a die. A loop goes through the dice 
            //and increases that index in the array. 
            int score = 0;
            int[] counts = new int[6];
            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i].Value != 0)
                {
                    counts[dice[i].Value - 1]++;
                }
            }

            //loop checks to see if any of the values in counts are 5. If so, sets score to 50
            foreach (int i in counts)
            {
                if (i == 5)
                {
                    score = 50;
                    btnYahtzee.Enabled = true;
                    btnYahtzee.BackColor = Color.FromArgb(192, 255, 192);
                    break;
                }
            }

            btnYahtzee.BackColor = Color.White;
            btnYahtzee.Enabled = false;
            txtYahtzee.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btnChance_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (Dice d in dice)
            {
                score += d.Value;
            }

            btnChance.BackColor = Color.White;
            btnChance.Enabled = false;
            txtChance.Text = score.ToString();
            checkSection2();
            reload();
        }

        private void btnYahtzeeBonus_Click(object sender, EventArgs e)
        {
            //counts is an array for each value on a die. A loop goes through the dice 
            //and increases that index in the array. 
            int[] counts = new int[6];
            for (int i = 0; i < dice.Count; i++)
            {
                counts[dice[i].Value-1]++;
            }

            //loop checks to see if any of the values in counts are 5. If so, sets score to 50
            foreach (int i in counts)
            {
                if (i == 5)
                {
                    yatzeeBonus += 100;
                    txtYahtzeeBonus.Text = yatzeeBonus.ToString();
                    reload();
                    break;
                }
            }
        }

        private void GameOver()
        {
            if (firstSectionComplete && secondSectionComplete)
            {
                int score = Convert.ToInt32(txtSectionLabel1.Text) + Convert.ToInt32(txtSectionLabel2.Text) + Convert.ToInt32(txtBonus.Text) + yatzeeBonus;
                Global.ThisScore = score;
                txtTotal.Text = score.ToString();
               // Global.CheckScore();
            }
        }
    }


    class Dice : IComparable<Dice>
    {
        public Dice() { }

        public int Value { get; set; }
        public bool Hold { get; set; }

        public int CompareTo(Dice other)
        {
            if (this.Value == other.Value)
                return 0;
            if (this.Value > other.Value)
                return 1;
            return -1;
        }
    }

    class Player : IComparable<Player>
    {
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }

        public int CompareTo(Player other)
        {
            if (this.Score == other.Score)
                return 0;
            if (this.Score > other.Score)
                return 1;
            return -1;
        }
    }

   
}
