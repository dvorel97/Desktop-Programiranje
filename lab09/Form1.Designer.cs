namespace NotesApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbNotes = new System.Windows.Forms.ListBox();
            this.tbNewNote = new System.Windows.Forms.TextBox();
            this.btnNewNote = new System.Windows.Forms.Button();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNotes
            // 
            this.lbNotes.FormattingEnabled = true;
            this.lbNotes.Location = new System.Drawing.Point(23, 23);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(170, 420);
            this.lbNotes.TabIndex = 0;
            this.lbNotes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbNotes_MouseDoubleClick);
            // 
            // tbNewNote
            // 
            this.tbNewNote.Location = new System.Drawing.Point(23, 449);
            this.tbNewNote.Name = "tbNewNote";
            this.tbNewNote.Size = new System.Drawing.Size(170, 20);
            this.tbNewNote.TabIndex = 1;
            // 
            // btnNewNote
            // 
            this.btnNewNote.Location = new System.Drawing.Point(23, 474);
            this.btnNewNote.Name = "btnNewNote";
            this.btnNewNote.Size = new System.Drawing.Size(170, 34);
            this.btnNewNote.TabIndex = 2;
            this.btnNewNote.Text = "Nova bilješka";
            this.btnNewNote.UseVisualStyleBackColor = true;
            this.btnNewNote.Click += new System.EventHandler(this.btnNewNote_Click);
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(199, 23);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(631, 485);
            this.tbNote.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(660, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Pohrani";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(23, 514);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(170, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Obriši bilješku";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 564);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.btnNewNote);
            this.Controls.Add(this.tbNewNote);
            this.Controls.Add(this.lbNotes);
            this.Name = "Form1";
            this.Text = "Notes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbNotes;
        private System.Windows.Forms.TextBox tbNewNote;
        private System.Windows.Forms.Button btnNewNote;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}

