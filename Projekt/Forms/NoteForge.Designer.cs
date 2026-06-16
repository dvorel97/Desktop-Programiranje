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
            TSEdit = new ToolStripMenuItem();
            TSDelete = new ToolStripMenuItem();
            txtSearch = new TextBox();
            cmbCategory = new ComboBox();
            btnNew = new Button();
            txtPreview = new TextBox();
            autoSaveTimer = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            TSExportHtml = new ToolStripMenuItem();
            TSExportMd = new ToolStripMenuItem();
            TSExportZip = new ToolStripMenuItem();
            TSImportMd = new ToolStripMenuItem();
            grpNotes.SuspendLayout();
            contextMenu.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpNotes
            // 
            grpNotes.Controls.Add(lstNotes);
            grpNotes.Controls.Add(txtSearch);
            grpNotes.Controls.Add(cmbCategory);
            grpNotes.Location = new Point(12, 27);
            grpNotes.Name = "grpNotes";
            grpNotes.Size = new Size(338, 625);
            grpNotes.TabIndex = 0;
            grpNotes.TabStop = false;
            grpNotes.Text = "Biljeske";
            // 
            // lstNotes
            // 
            lstNotes.ContextMenuStrip = contextMenu;
            lstNotes.Location = new Point(6, 90);
            lstNotes.Name = "lstNotes";
            lstNotes.Size = new Size(326, 529);
            lstNotes.TabIndex = 2;
            lstNotes.MouseDown += lstNotes_MouseDown;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(40, 40);
            contextMenu.Items.AddRange(new ToolStripItem[] { TSEdit, TSDelete });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(106, 48);
            // 
            // TSEdit
            // 
            TSEdit.Name = "TSEdit";
            TSEdit.Size = new Size(105, 22);
            TSEdit.Text = "Uredi";
            TSEdit.Click += EditNote;
            // 
            // TSDelete
            // 
            TSDelete.Name = "TSDelete";
            TSDelete.Size = new Size(105, 22);
            TSDelete.Text = "Obriši";
            TSDelete.Click += DeleteNote;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 51);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Pretraga";
            txtSearch.Size = new Size(326, 23);
            txtSearch.TabIndex = 1;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(6, 22);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(326, 23);
            cmbCategory.TabIndex = 5;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(12, 658);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(338, 45);
            btnNew.TabIndex = 3;
            btnNew.Text = "Nova biljeska";
            btnNew.Click += btnNew_Click;
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(356, 117);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.Size = new Size(598, 535);
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
            menuStrip1.Size = new Size(971, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { TSExportHtml, TSExportMd, TSExportZip, TSImportMd });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 20);
            toolStripMenuItem1.Text = "File";
            // 
            // TSExportHtml
            // 
            TSExportHtml.Name = "TSExportHtml";
            TSExportHtml.Size = new Size(143, 22);
            TSExportHtml.Text = "Export HTML";
            TSExportHtml.Click += TSExportHtml_Click;
            // 
            // TSExportMd
            // 
            TSExportMd.Name = "TSExportMd";
            TSExportMd.Size = new Size(143, 22);
            TSExportMd.Text = "Export MD";
            TSExportMd.Click += TSExportMd_Click;
            // 
            // TSExportZip
            // 
            TSExportZip.Name = "TSExportZip";
            TSExportZip.Size = new Size(143, 22);
            TSExportZip.Text = "Export ZIP";
            TSExportZip.Click += TSExportZip_Click;
            // 
            // TSImportMd
            // 
            TSImportMd.Name = "TSImportMd";
            TSImportMd.Size = new Size(143, 22);
            TSImportMd.Text = "Uvezi .md";
            TSImportMd.Click += TSImportMd_Click;
            // 
            // NoteForge
            // 
            ClientSize = new Size(971, 757);
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
            contextMenu.ResumeLayout(false);
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
        private ToolStripMenuItem TSExportMd;
        private ToolStripMenuItem TSExportZip;
        private ToolStripMenuItem TSEdit;
        private ToolStripMenuItem TSDelete;
        private ComboBox cmbCategory;
        private ToolStripMenuItem TSImportMd;
    }
    }
