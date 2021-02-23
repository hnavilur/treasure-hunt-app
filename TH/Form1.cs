using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TH
{
    public partial class Form1 : Form
    {
        const int NUM_QUES = 14;
        string[] answers = new string[] { "start", "ironmaiden", "abdevilliers", "mozilla", "sexpositions", "harrypotter", "elonmusk", "robertdowneyjunior",
                                "lalbahadurshastri", "osamabinladen", "cristianoronaldo", "khatronkekhiladi", "emraanhashmi", "dubsmash", "iamsherlocked"};
        List<Image> images = new List<Image>();
        String query = ""; // answer submitted by the player
        static int qnum = 0; // current question numbers
        enum STATE {RUNNING, ENDED};
        STATE state = STATE.RUNNING;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            images.Add(TH.Properties.Resources.i0);
            images.Add(TH.Properties.Resources.i1);
            images.Add(TH.Properties.Resources.i2);
            images.Add(TH.Properties.Resources.i3);
            images.Add(TH.Properties.Resources.i4);
            images.Add(TH.Properties.Resources.i5);
            images.Add(TH.Properties.Resources.i6);
            images.Add(TH.Properties.Resources.i7);
            images.Add(TH.Properties.Resources.i8);
            images.Add(TH.Properties.Resources.i9);
            images.Add(TH.Properties.Resources.i10);
            images.Add(TH.Properties.Resources.i11);
            images.Add(TH.Properties.Resources.i12);
            images.Add(TH.Properties.Resources.i13);
            images.Add(TH.Properties.Resources.i14);
            images.Add(TH.Properties.Resources.i15);

            pictureBox.Image = images[0];
            qnumLabel.Text = qnum.ToString();
            CheckAnswer();
            timer1.Start();
        }

        private void CheckAnswer()
        {
            if (state == STATE.RUNNING)
            {
                if (answers[qnum] == query) // check correctness of answer
                {
                    qnum++; // if correct, goto next image
                    pictureBox.Image = images[qnum];
                    seconds = minutes = 0;
                    qnumLabel.Text = qnum.ToString();

                    if (qnum > NUM_QUES) // if the questions are over...
                    {
                        state = STATE.ENDED;
                        submitButton.Enabled = false;
                        answerBox.Text = DateTime.Now.ToString();
                        answerBox.ReadOnly = true;
                        timer1.Stop();
                        timeLabel.Text = "0:00";
                        return;
                    }
                }

                answerBox.Text = ""; // clear the previous answer.
                query = ""; // should be after the end of if
            }
        }

        private void answerBox_TextChanged(object sender, EventArgs e)
        {
            query = answerBox.Text;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        int seconds = 0, minutes = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            timeLabel.Text = minutes.ToString() + ":" + seconds.ToString();
        }
    }
}
