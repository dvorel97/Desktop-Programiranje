namespace VubChat.Server;

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
        lblPort = new Label();
        nudPort = new NumericUpDown();
        btnPokreni = new Button();
        btnZaustavi = new Button();
        lblStatus = new Label();
        lblKlijenti = new Label();
        lblAdrese = new Label();
        lblLog = new Label();
        lbLog = new ListBox();
        btnOcistiLog = new Button();
        panelTop = new Panel();
        panelBottom = new Panel();
        ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
        panelTop.SuspendLayout();
        panelBottom.SuspendLayout();
        SuspendLayout();
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new Point(16, 22);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(35, 20);
        lblPort.TabIndex = 0;
        lblPort.Text = "Port:";
        // 
        // nudPort
        // 
        nudPort.Location = new Point(58, 19);
        nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
        nudPort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
        nudPort.Name = "nudPort";
        nudPort.Size = new Size(100, 27);
        nudPort.TabIndex = 1;
        nudPort.Value = new decimal(new int[] { 50000, 0, 0, 0 });
        // 
        // btnPokreni
        // 
        btnPokreni.BackColor = Color.FromArgb(30, 64, 175);
        btnPokreni.FlatAppearance.BorderSize = 0;
        btnPokreni.FlatStyle = FlatStyle.Flat;
        btnPokreni.ForeColor = Color.White;
        btnPokreni.Location = new Point(176, 17);
        btnPokreni.Name = "btnPokreni";
        btnPokreni.Size = new Size(130, 32);
        btnPokreni.TabIndex = 2;
        btnPokreni.Text = "▶  Pokreni server";
        btnPokreni.UseVisualStyleBackColor = false;
        btnPokreni.Click += btnPokreni_Click;
        // 
        // btnZaustavi
        // 
        btnZaustavi.BackColor = Color.FromArgb(194, 65, 12);
        btnZaustavi.FlatAppearance.BorderSize = 0;
        btnZaustavi.FlatStyle = FlatStyle.Flat;
        btnZaustavi.ForeColor = Color.White;
        btnZaustavi.Location = new Point(316, 17);
        btnZaustavi.Name = "btnZaustavi";
        btnZaustavi.Size = new Size(130, 32);
        btnZaustavi.TabIndex = 3;
        btnZaustavi.Text = "■  Zaustavi";
        btnZaustavi.UseVisualStyleBackColor = false;
        btnZaustavi.Click += btnZaustavi_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblStatus.Location = new Point(16, 60);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(165, 19);
        lblStatus.TabIndex = 4;
        lblStatus.Text = "○ Server zaustavljen";
        // 
        // lblKlijenti
        // 
        lblKlijenti.AutoSize = true;
        lblKlijenti.Font = new Font("Segoe UI", 10F);
        lblKlijenti.Location = new Point(280, 60);
        lblKlijenti.Name = "lblKlijenti";
        lblKlijenti.Size = new Size(168, 19);
        lblKlijenti.TabIndex = 5;
        lblKlijenti.Text = "Spojenih klijenata: 0";
        // 
        // lblAdrese
        // 
        lblAdrese.AutoSize = true;
        lblAdrese.ForeColor = Color.DimGray;
        lblAdrese.Location = new Point(16, 84);
        lblAdrese.Name = "lblAdrese";
        lblAdrese.Size = new Size(133, 20);
        lblAdrese.TabIndex = 6;
        lblAdrese.Text = "Lokalne adrese: ...";
        // 
        // lblLog
        // 
        lblLog.AutoSize = true;
        lblLog.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblLog.Location = new Point(16, 8);
        lblLog.Name = "lblLog";
        lblLog.Size = new Size(127, 19);
        lblLog.TabIndex = 0;
        lblLog.Text = "Zapisnik servera:";
        // 
        // lbLog
        // 
        lbLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lbLog.BackColor = Color.FromArgb(14, 23, 38);
        lbLog.BorderStyle = BorderStyle.None;
        lbLog.Font = new Font("Cascadia Mono", 9F);
        lbLog.ForeColor = Color.FromArgb(230, 237, 243);
        lbLog.FormattingEnabled = true;
        lbLog.IntegralHeight = false;
        lbLog.ItemHeight = 17;
        lbLog.Location = new Point(16, 32);
        lbLog.Name = "lbLog";
        lbLog.Size = new Size(620, 320);
        lbLog.TabIndex = 1;
        // 
        // btnOcistiLog
        // 
        btnOcistiLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnOcistiLog.FlatStyle = FlatStyle.Flat;
        btnOcistiLog.Location = new Point(536, 4);
        btnOcistiLog.Name = "btnOcistiLog";
        btnOcistiLog.Size = new Size(100, 26);
        btnOcistiLog.TabIndex = 2;
        btnOcistiLog.Text = "Očisti";
        btnOcistiLog.UseVisualStyleBackColor = true;
        btnOcistiLog.Click += btnOcistiLog_Click;
        // 
        // panelTop
        // 
        panelTop.BackColor = Color.FromArgb(247, 245, 238);
        panelTop.Controls.Add(lblPort);
        panelTop.Controls.Add(nudPort);
        panelTop.Controls.Add(btnPokreni);
        panelTop.Controls.Add(btnZaustavi);
        panelTop.Controls.Add(lblStatus);
        panelTop.Controls.Add(lblKlijenti);
        panelTop.Controls.Add(lblAdrese);
        panelTop.Dock = DockStyle.Top;
        panelTop.Location = new Point(0, 0);
        panelTop.Name = "panelTop";
        panelTop.Size = new Size(652, 116);
        panelTop.TabIndex = 0;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(btnOcistiLog);
        panelBottom.Controls.Add(lblLog);
        panelBottom.Controls.Add(lbLog);
        panelBottom.Dock = DockStyle.Fill;
        panelBottom.Location = new Point(0, 116);
        panelBottom.Name = "panelBottom";
        panelBottom.Padding = new Padding(0, 0, 0, 8);
        panelBottom.Size = new Size(652, 365);
        panelBottom.TabIndex = 1;
        // 
        // GlavnaForma
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(652, 481);
        Controls.Add(panelBottom);
        Controls.Add(panelTop);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(560, 360);
        Name = "GlavnaForma";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "VubChat Server — VUB · Desktop aplikacije";
        Load += GlavnaForma_Load;
        ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelBottom.ResumeLayout(false);
        panelBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Label lblPort;
    private NumericUpDown nudPort;
    private Button btnPokreni;
    private Button btnZaustavi;
    private Label lblStatus;
    private Label lblKlijenti;
    private Label lblAdrese;
    private Label lblLog;
    private ListBox lbLog;
    private Button btnOcistiLog;
    private Panel panelTop;
    private Panel panelBottom;
}
