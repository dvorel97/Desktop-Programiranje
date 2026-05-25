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
            lstNotes = new ListBox();
            contextMenu = new ContextMenuStrip(components);
            txtSearch = new TextBox();
            btnNew = new Button();
            txtPreview = new TextBox();
            autoSaveTimer = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            TSExportHtml = new ToolStripMenuItem();
            grpNotes.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpNotes
            // 
            grpNotes.Controls.Add(lstNotes);
            grpNotes.Controls.Add(txtSearch);
            grpNotes.Location = new Point(12, 65);
            grpNotes.Name = "grpNotes";
            grpNotes.Size = new Size(448, 1013);
            grpNotes.TabIndex = 0;
            grpNotes.TabStop = false;
            grpNotes.Text = "Biljeske";
            // 
            // lstNotes
            // 
            lstNotes.ContextMenuStrip = contextMenu;
            lstNotes.Location = new Point(6, 139);
            lstNotes.Name = "lstNotes";
            lstNotes.Size = new Size(434, 865);
            lstNotes.TabIndex = 2;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(40, 40);
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(61, 4);
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(8, 46);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Pretraga";
            txtSearch.Size = new Size(434, 47);
            txtSearch.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(20, 1096);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(434, 57);
            btnNew.TabIndex = 3;
            btnNew.Text = "Nova biljeska";
            btnNew.Click += btnNew_Click;
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(476, 86);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.Size = new Size(1078, 1067);
            txtPreview.TabIndex = 3;
            // 
            // autoSaveTimer
            // 
            autoSaveTimer.Interval = 30000;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1575, 52);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { TSExportHtml });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(87, 48);
            toolStripMenuItem1.Text = "File";
            // 
            // TSExportHtml
            // 
            TSExportHtml.Name = "TSExportHtml";
            TSExportHtml.Size = new Size(448, 54);
            TSExportHtml.Text = "Export HTML";
            TSExportHtml.Click += TSExportHtml_Click;
            // 
            // NoteForge
            // 
            ClientSize = new Size(1575, 1250);
            Controls.Add(menuStrip1);
            Controls.Add(btnNew);
            Controls.Add(txtPreview);
            Controls.Add(grpNotes);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(700, 480);
            Name = "NoteForge";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoteForge";
            Load += NoteForge_Load;
            grpNotes.ResumeLayout(false);
            grpNotes.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpNotes;
            private TextBox txtSearch;
            private ListBox lstNotes;
            private Button btnNew;
        private TextBox txtPreview;
        private ContextMenuStrip contextMenu;
        private System.Windows.Forms.Timer autoSaveTimer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem TSExportHtml;
    }
    }
