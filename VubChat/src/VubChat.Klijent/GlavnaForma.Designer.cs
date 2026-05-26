namespace VubChat.Klijent;

partial class GlavnaForma
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
        lblHost = new Label();
        txtHost = new TextBox();
        lblPort = new Label();
        nudPort = new NumericUpDown();
        lblNadimak = new Label();
        txtNadimak = new TextBox();
        btnSpoji = new Button();
        btnOdspoji = new Button();
        lblStatus = new Label();
        rtbChat = new RichTextBox();
        txtPoruka = new TextBox();
        btnPosalji = new Button();
        panelTop = new Panel();
        panelBottom = new Panel();
        tBNadimak = new TextBox();
        ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
        panelTop.SuspendLayout();
        panelBottom.SuspendLayout();
        SuspendLayout();
        // 
        // lblHost
        // 
        lblHost.AutoSize = true;
        lblHost.Location = new Point(16, 22);
        lblHost.Name = "lblHost";
        lblHost.Size = new Size(71, 19);
        lblHost.TabIndex = 0;
        lblHost.Text = "Poslužitelj:";
        // 
        // txtHost
        // 
        txtHost.Location = new Point(112, 19);
        txtHost.Name = "txtHost";
        txtHost.Size = new Size(140, 25);
        txtHost.TabIndex = 1;
        txtHost.Text = "127.0.0.1";
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new Point(264, 22);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(37, 19);
        lblPort.TabIndex = 2;
        lblPort.Text = "Port:";
        // 
        // nudPort
        // 
        nudPort.Location = new Point(304, 19);
        nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
        nudPort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
        nudPort.Name = "nudPort";
        nudPort.Size = new Size(90, 25);
        nudPort.TabIndex = 3;
        nudPort.Value = new decimal(new int[] { 50000, 0, 0, 0 });
        // 
        // lblNadimak
        // 
        lblNadimak.AutoSize = true;
        lblNadimak.Location = new Point(16, 60);
        lblNadimak.Name = "lblNadimak";
        lblNadimak.Size = new Size(66, 19);
        lblNadimak.TabIndex = 4;
        lblNadimak.Text = "Nadimak:";
        // 
        // txtNadimak
        // 
        txtNadimak.Location = new Point(112, 57);
        txtNadimak.MaxLength = 32;
        txtNadimak.Name = "txtNadimak";
        txtNadimak.Size = new Size(282, 25);
        txtNadimak.TabIndex = 5;
        // 
        // btnSpoji
        // 
        btnSpoji.BackColor = Color.FromArgb(30, 64, 175);
        btnSpoji.FlatAppearance.BorderSize = 0;
        btnSpoji.FlatStyle = FlatStyle.Flat;
        btnSpoji.ForeColor = Color.White;
        btnSpoji.Location = new Point(412, 17);
        btnSpoji.Name = "btnSpoji";
        btnSpoji.Size = new Size(120, 30);
        btnSpoji.TabIndex = 6;
        btnSpoji.Text = "🔌  Spoji se";
        btnSpoji.UseVisualStyleBackColor = false;
        btnSpoji.Click += btnSpoji_Click;
        // 
        // btnOdspoji
        // 
        btnOdspoji.BackColor = Color.FromArgb(194, 65, 12);
        btnOdspoji.FlatAppearance.BorderSize = 0;
        btnOdspoji.FlatStyle = FlatStyle.Flat;
        btnOdspoji.ForeColor = Color.White;
        btnOdspoji.Location = new Point(412, 55);
        btnOdspoji.Name = "btnOdspoji";
        btnOdspoji.Size = new Size(120, 30);
        btnOdspoji.TabIndex = 7;
        btnOdspoji.Text = "⏏  Odspoji";
        btnOdspoji.UseVisualStyleBackColor = false;
        btnOdspoji.Click += btnOdspoji_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblStatus.Location = new Point(16, 96);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(107, 19);
        lblStatus.TabIndex = 8;
        lblStatus.Text = "○ Niste spojeni";
        // 
        // rtbChat
        // 
        rtbChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        rtbChat.BackColor = Color.White;
        rtbChat.BorderStyle = BorderStyle.FixedSingle;
        rtbChat.Font = new Font("Segoe UI", 10F);
        rtbChat.Location = new Point(16, 8);
        rtbChat.Name = "rtbChat";
        rtbChat.ReadOnly = true;
        rtbChat.Size = new Size(616, 297);
        rtbChat.TabIndex = 0;
        rtbChat.Text = "";
        // 
        // txtPoruka
        // 
        txtPoruka.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtPoruka.Font = new Font("Segoe UI", 10F);
        txtPoruka.Location = new Point(16, 376);
        txtPoruka.MaxLength = 1000;
        txtPoruka.Name = "txtPoruka";
        txtPoruka.PlaceholderText = "Upišite poruku i pritisnite Enter...";
        txtPoruka.Size = new Size(378, 25);
        txtPoruka.TabIndex = 1;
        // 
        // btnPosalji
        // 
        btnPosalji.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnPosalji.BackColor = Color.FromArgb(30, 64, 175);
        btnPosalji.FlatAppearance.BorderSize = 0;
        btnPosalji.FlatStyle = FlatStyle.Flat;
        btnPosalji.ForeColor = Color.White;
        btnPosalji.Location = new Point(534, 374);
        btnPosalji.Name = "btnPosalji";
        btnPosalji.Size = new Size(98, 30);
        btnPosalji.TabIndex = 2;
        btnPosalji.Text = "Pošalji ➤";
        btnPosalji.UseVisualStyleBackColor = false;
        btnPosalji.Click += btnPosalji_Click;
        // 
        // panelTop
        // 
        panelTop.BackColor = Color.FromArgb(247, 245, 238);
        panelTop.Controls.Add(lblHost);
        panelTop.Controls.Add(txtHost);
        panelTop.Controls.Add(lblPort);
        panelTop.Controls.Add(nudPort);
        panelTop.Controls.Add(lblNadimak);
        panelTop.Controls.Add(txtNadimak);
        panelTop.Controls.Add(btnSpoji);
        panelTop.Controls.Add(btnOdspoji);
        panelTop.Controls.Add(lblStatus);
        panelTop.Dock = DockStyle.Top;
        panelTop.Location = new Point(0, 0);
        panelTop.Name = "panelTop";
        panelTop.Size = new Size(648, 128);
        panelTop.TabIndex = 0;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(tBNadimak);
        panelBottom.Controls.Add(rtbChat);
        panelBottom.Controls.Add(txtPoruka);
        panelBottom.Controls.Add(btnPosalji);
        panelBottom.Dock = DockStyle.Fill;
        panelBottom.Location = new Point(0, 128);
        panelBottom.Name = "panelBottom";
        panelBottom.Padding = new Padding(0, 0, 0, 8);
        panelBottom.Size = new Size(648, 413);
        panelBottom.TabIndex = 1;
        // 
        // tBNadimak
        // 
        tBNadimak.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tBNadimak.Font = new Font("Segoe UI", 10F);
        tBNadimak.Location = new Point(399, 374);
        tBNadimak.MaxLength = 1000;
        tBNadimak.Name = "tBNadimak";
        tBNadimak.PlaceholderText = "Nadimak";
        tBNadimak.Size = new Size(129, 25);
        tBNadimak.TabIndex = 3;
        // 
        // GlavnaForma
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(648, 541);
        Controls.Add(panelBottom);
        Controls.Add(panelTop);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(560, 380);
        Name = "GlavnaForma";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "VubChat Klijent — VUB · Desktop aplikacije";
        Load += GlavnaForma_Load;
        ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelBottom.ResumeLayout(false);
        panelBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Label lblHost;
    private TextBox txtHost;
    private Label lblPort;
    private NumericUpDown nudPort;
    private Label lblNadimak;
    private TextBox txtNadimak;
    private Button btnSpoji;
    private Button btnOdspoji;
    private Label lblStatus;
    private RichTextBox rtbChat;
    private TextBox txtPoruka;
    private Button btnPosalji;
    private Panel panelTop;
    private Panel panelBottom;
    private TextBox tBNadimak;
}
