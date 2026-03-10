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
            labelTimer.Text = "25:00";
        }

        private void btnStartClick(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                if (secondsLeft == 0)
                {
                    int minutes = int.Parse(textBoxRad.Text);
                    secondsLeft = minutes * 60;
                }
                timerPomodoro.Start();
                isRunning = true;
            }
            else
            {
                timerPomodoro.Stop();
                isRunning = false;
            }

        }

        private void btnResetClick(object sender, EventArgs e) {
            
        }
        
    }
}
