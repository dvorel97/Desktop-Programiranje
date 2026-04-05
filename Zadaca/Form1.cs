namespace Zadaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
        this.ClientRectangle,
        Color.FromArgb(180, 130, 0),
        Color.FromArgb(70, 20, 150),
        System.Drawing.Drawing2D.LinearGradientMode.Horizontal
    );
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void visuals()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox3.BackColor = Color.Transparent;
            this.groupBox4.BackColor = Color.Transparent;
            this.lblSumTxt.BackColor = Color.Transparent;
            this.lblSum.BackColor = Color.Transparent;
            this.lblHeader.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
