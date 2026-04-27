namespace Projekt
{
    partial class NoteForge
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                    components.Dispose();
                base.Dispose(disposing);
            }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpNotes = new GroupBox();
            txtSearch = new TextBox();
            lstNotes = new ListBox();
            contextMenu = new ContextMenuStrip(components);
            btnNew = new Button();
            txtPreview = new TextBox();
            grpNotes.SuspendLayout();
            SuspendLayout();
            // 
            // grpNotes
            // 
            grpNotes.Controls.Add(txtSearch);
            grpNotes.Controls.Add(lstNotes);
            grpNotes.Controls.Add(btnNew);
            grpNotes.Location = new Point(12, 12);
            grpNotes.Name = "grpNotes";
            grpNotes.Size = new Size(448, 1172);
            grpNotes.TabIndex = 0;
            grpNotes.TabStop = false;
            grpNotes.Text = "Biljeske";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(8, 46);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Pretraga";
            txtSearch.Size = new Size(434, 47);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lstNotes
            // 
            lstNotes.ContextMenuStrip = contextMenu;
            lstNotes.Location = new Point(8, 102);
            lstNotes.Name = "lstNotes";
            lstNotes.Size = new Size(434, 988);
            lstNotes.TabIndex = 2;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(40, 40);
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(61, 4);
            // 
            // btnNew
            // 
            btnNew.Location = new Point(8, 1109);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(434, 57);
            btnNew.TabIndex = 3;
            btnNew.Text = "Nova biljeska";
            btnNew.Click += btnNew_Click;
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(482, 111);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.Size = new Size(1078, 1067);
            txtPreview.TabIndex = 3;
            // 
            // NoteForge
            // 
            ClientSize = new Size(1575, 1196);
            Controls.Add(txtPreview);
            Controls.Add(grpNotes);
            MinimumSize = new Size(700, 480);
            Name = "NoteForge";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoteForge";
            grpNotes.ResumeLayout(false);
            grpNotes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpNotes;
            private TextBox txtSearch;
            private ListBox lstNotes;
            private Button btnNew;
        private TextBox txtPreview;
        private ContextMenuStrip contextMenu;
    }
    }
