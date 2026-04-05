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
    }
}
