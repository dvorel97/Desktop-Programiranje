namespace Projekt
{
    public partial class NoteForge : Form
    {
        private NoteRepository repository = new NoteRepository();
        public NoteForge()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshNoteList();
        }

        private void LoadSampleData()
        {
            repository.Add(new Note("Arhitektura projekta", NoteType.Project));
            repository.Add(new Note("Sprint Review", NoteType.Work));
            repository.Add(new Note("OOP biljeske", NoteType.Study));
            repository.Add(new Note("Ideja: dark mode", NoteType.Idea));
            repository.Add(new Note("Osobni ciljevi", NoteType.Personal));
        }

        private void RefreshNoteList()
        {
            lstNotes.Items.Clear();
            foreach (var note in repository.Notes)
                lstNotes.Items.Add(note);
            lstNotes.DisplayMember = "Title";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var splitView = new SplitView();
            splitView.ShowDialog();
        }

        private void txtPreview_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
