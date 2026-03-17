using System.Xml.Serialization;


namespace LAB2
{
    public partial class Form1 : Form
    {
        private Pomodoro pomodoro;

        public Form1()
        {
            InitializeComponent();
            pomodoro = new Pomodoro();
            textBoxRad.Text = pomodoro.WorkDuration.ToString();
            textBoxOdmor.Text = pomodoro.RestDuration.ToString();
            labelRad.ForeColor = Color.Red;
            labelTimer.Text = pomodoro.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timerPomodoro.Enabled)
            {
                timerPomodoro.Start();
                btnStart.Text = "Stop";
                textBoxRad.Enabled = false;
                textBoxOdmor.Enabled = false;
            }
            else
            {
                timerPomodoro.Stop();
                btnStart.Text = "Start";
                textBoxRad.Enabled = true;
                textBoxOdmor.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timerPomodoro.Stop();
            btnStart.Text = "Start";
            pomodoro = new Pomodoro(
                int.Parse(textBoxRad.Text), 
                int.Parse(textBoxOdmor.Text));
            labelTimer.Text = pomodoro.ToString();
            labelRad.ForeColor=Color.Red;
            labelOdmor.ForeColor=Color.Black;
        }

        private void timerPomodoro_Tick(object sender, EventArgs e)
        {
            if (pomodoro.CurrentSeconds >= 0)
            {
                labelTimer.Text = pomodoro.ToString();
                pomodoro.CurrentSeconds--;
            }
            else
            {
                if (pomodoro.WorkInProgress)
                {
                    pomodoro.CurrentSeconds = Pomodoro.ConvertMinutesToSeconds(pomodoro.RestDuration);
                    pomodoro.WorkInProgress = false;
                    labelRad.ForeColor = Color.Black;
                    labelOdmor.ForeColor = Color.Red;
                }
                else {
                    pomodoro.CurrentSeconds = Pomodoro.ConvertMinutesToSeconds(pomodoro.WorkDuration);
                    pomodoro.WorkInProgress = true;
                    labelRad.ForeColor = Color.Red;
                    labelOdmor.ForeColor = Color.Black;
                }
            }
        }
    }
}
