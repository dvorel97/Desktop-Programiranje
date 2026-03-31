namespace Projekt
{
    public partial class NoteForge : Form
    {
        public NoteForge()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var splitView = new SplitView();
            splitView.ShowDialog();  // isto kao WinForms ShowDialog
        }
    }
}
