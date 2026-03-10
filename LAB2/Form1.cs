using System.Xml.Serialization;

namespace LAB2
{
    public partial class Form1 : Form
    {
        int secondsLeft;
        bool isRunning = false;
        bool isWorkTime = true;

        public Form1()
        {
            InitializeComponent();
            textBoxRad.Text = "25";
            textBoxOdmor.Text = "5";
            secondsLeft = int.Parse(textBoxRad.Text) * 60;
            labelRad.ForeColor = Color.Red;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerPomodoro.Start();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }


        private void timerPomodoro_Tick(object sender, EventArgs e)
        {
            int minutes = secondsLeft / 60;
            labelTimer.Text = minutes.ToString() + ":" + (secondsLeft % 60).ToString();

            secondsLeft--;
        }
    }
}
