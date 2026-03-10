using System.Xml.Serialization;

namespace LAB2
{
    public partial class Form1 : Form
    {
        int secondsLeft;
        bool isWorkTime;

        public Form1()
        {
            InitializeComponent();
            textBoxRad.Text = "25";
            textBoxOdmor.Text = "5";
            secondsLeft = int.Parse(textBoxRad.Text) * 60;
            labelRad.ForeColor = Color.Red;
            isWorkTime = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timerPomodoro.Enabled)
            {
                timerPomodoro.Start();
                btnStart.Text = "Stop";
                
                //dodatne funkcionalnosti
                textBoxRad.Enabled = false;
                textBoxOdmor.Enabled = false;
            }
            else
            {
                timerPomodoro.Stop();
                btnStart.Text = "Start";

                //dodatne funkcionalnosti
                textBoxRad.Enabled = true;
                textBoxOdmor.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timerPomodoro.Stop();
            btnStart.Text = "Start";
            setTimerToWork();
        }

        private void timerPomodoro_Tick(object sender, EventArgs e)
        {
            if (secondsLeft >= 0)
            {
                setTimerLabel();
                secondsLeft--;
            }
            else
            {
                if (isWorkTime)
                {
                    secondsLeft = int.Parse(textBoxOdmor.Text) * 60;
                    labelRad.ForeColor = Color.Black;
                    labelOdmor.ForeColor = Color.Red;
                    isWorkTime = false;
                }
                else {
                    secondsLeft = int.Parse(textBoxRad.Text) * 60;
                    labelRad.ForeColor = Color.Red;
                    labelOdmor.ForeColor = Color.Black;
                    isWorkTime = true;
                }
            }
        }
        private void setTimerToWork()
        {
            secondsLeft = int.Parse(textBoxRad.Text) * 60;
            labelRad.ForeColor = Color.Red;
            labelOdmor.ForeColor = Color.Black;
            setTimerLabel();
        }

        private void setTimerLabel()
        {
            int minutes = secondsLeft / 60;
            int seconds = secondsLeft % 60;
            labelTimer.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }
    }
}
