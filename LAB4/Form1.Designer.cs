namespace LAB4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNaslov = new Label();
            tbNaslov = new TextBox();
            lblTekst = new Label();
            cbSlikovni = new CheckBox();
            cbVideo = new CheckBox();
            tbSlika = new TextBox();
            tbVideo = new TextBox();
            btnDodaj = new Button();
            label1 = new Label();
            tbOglasi = new RichTextBox();
            tbTekst = new RichTextBox();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Location = new Point(12, 25);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(83, 15);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Naslov oglasa:";
            // 
            // tbNaslov
            // 
            tbNaslov.Location = new Point(12, 43);
            tbNaslov.Name = "tbNaslov";
            tbNaslov.Size = new Size(175, 23);
            tbNaslov.TabIndex = 1;
            // 
            // lblTekst
            // 
            lblTekst.AutoSize = true;
            lblTekst.Location = new Point(12, 86);
            lblTekst.Name = "lblTekst";
            lblTekst.Size = new Size(79, 15);
            lblTekst.TabIndex = 2;
            lblTekst.Text = "Teskst oglasa:";
            // 
            // cbSlikovni
            // 
            cbSlikovni.AutoSize = true;
            cbSlikovni.Location = new Point(13, 256);
            cbSlikovni.Name = "cbSlikovni";
            cbSlikovni.Size = new Size(98, 19);
            cbSlikovni.TabIndex = 4;
            cbSlikovni.Text = "Slikovni oglas";
            cbSlikovni.UseVisualStyleBackColor = true;
            cbSlikovni.CheckedChanged += cbSlikovni_CheckedChanged;
            // 
            // cbVideo
            // 
            cbVideo.AutoSize = true;
            cbVideo.Location = new Point(13, 325);
            cbVideo.Name = "cbVideo";
            cbVideo.Size = new Size(87, 19);
            cbVideo.TabIndex = 5;
            cbVideo.Text = "Video oglas";
            cbVideo.UseVisualStyleBackColor = true;
            cbVideo.CheckedChanged += cbVideo_CheckedChanged;
            // 
            // tbSlika
            // 
            tbSlika.Location = new Point(12, 276);
            tbSlika.Name = "tbSlika";
            tbSlika.Size = new Size(175, 23);
            tbSlika.TabIndex = 6;
            // 
            // tbVideo
            // 
            tbVideo.Location = new Point(13, 350);
            tbVideo.Name = "tbVideo";
            tbVideo.Size = new Size(175, 23);
            tbVideo.TabIndex = 7;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(12, 406);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(175, 32);
            btnDodaj.TabIndex = 8;
            btnDodaj.Text = "Dodaj oglas";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(220, 25);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 10;
            label1.Text = "Oglasi:";
            // 
            // tbOglasi
            // 
            tbOglasi.Location = new Point(220, 43);
            tbOglasi.Name = "tbOglasi";
            tbOglasi.Size = new Size(261, 395);
            tbOglasi.TabIndex = 11;
            tbOglasi.Text = "";
            // 
            // tbTekst
            // 
            tbTekst.Location = new Point(12, 104);
            tbTekst.Name = "tbTekst";
            tbTekst.Size = new Size(176, 133);
            tbTekst.TabIndex = 12;
            tbTekst.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 450);
            Controls.Add(tbTekst);
            Controls.Add(tbOglasi);
            Controls.Add(label1);
            Controls.Add(btnDodaj);
            Controls.Add(tbVideo);
            Controls.Add(tbSlika);
            Controls.Add(cbVideo);
            Controls.Add(cbSlikovni);
            Controls.Add(lblTekst);
            Controls.Add(tbNaslov);
            Controls.Add(lblNaslov);
            Name = "Form1";
            Text = "Oglasnik";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private TextBox tbNaslov;
        private Label lblTekst;
        private CheckBox cbSlikovni;
        private CheckBox cbVideo;
        private TextBox tbSlika;
        private TextBox tbVideo;
        private Button btnDodaj;
        private Label label1;
        private RichTextBox tbOglasi;
        private RichTextBox tbTekst;
    }
}
