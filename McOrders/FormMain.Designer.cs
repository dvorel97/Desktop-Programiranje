namespace McOrders {
  partial class FormMain {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      gbMenu = new GroupBox();
      btnDrink = new Button();
      btnBigMac = new Button();
      btnPommes = new Button();
      gbActiveOrders = new GroupBox();
      lbActiveOrders = new ListBox();
      gbCompletedOrders = new GroupBox();
      lbCompletedOrders = new ListBox();
      gbMenu.SuspendLayout();
      gbActiveOrders.SuspendLayout();
      gbCompletedOrders.SuspendLayout();
      SuspendLayout();
      // 
      // gbMenu
      // 
      gbMenu.Controls.Add(btnDrink);
      gbMenu.Controls.Add(btnBigMac);
      gbMenu.Controls.Add(btnPommes);
      gbMenu.Location = new Point(12, 12);
      gbMenu.Name = "gbMenu";
      gbMenu.Size = new Size(291, 774);
      gbMenu.TabIndex = 0;
      gbMenu.TabStop = false;
      gbMenu.Text = "Izbor";
      // 
      // btnDrink
      // 
      btnDrink.Image = (Image)resources.GetObject("btnDrink.Image");
      btnDrink.Location = new Point(20, 525);
      btnDrink.Name = "btnDrink";
      btnDrink.Size = new Size(250, 218);
      btnDrink.TabIndex = 2;
      btnDrink.UseVisualStyleBackColor = true;
      btnDrink.Click += btnDrink_Click;
      // 
      // btnBigMac
      // 
      btnBigMac.Image = (Image)resources.GetObject("btnBigMac.Image");
      btnBigMac.Location = new Point(20, 278);
      btnBigMac.Name = "btnBigMac";
      btnBigMac.Size = new Size(250, 218);
      btnBigMac.TabIndex = 1;
      btnBigMac.UseVisualStyleBackColor = true;
      btnBigMac.Click += btnBigMac_Click;
      // 
      // btnPommes
      // 
      btnPommes.Image = (Image)resources.GetObject("btnPommes.Image");
      btnPommes.Location = new Point(22, 35);
      btnPommes.Name = "btnPommes";
      btnPommes.Size = new Size(250, 218);
      btnPommes.TabIndex = 0;
      btnPommes.UseVisualStyleBackColor = true;
      btnPommes.Click += btnPommes_Click;
      // 
      // gbActiveOrders
      // 
      gbActiveOrders.Controls.Add(lbActiveOrders);
      gbActiveOrders.Location = new Point(309, 12);
      gbActiveOrders.Name = "gbActiveOrders";
      gbActiveOrders.Size = new Size(291, 774);
      gbActiveOrders.TabIndex = 1;
      gbActiveOrders.TabStop = false;
      gbActiveOrders.Text = "U pripremi";
      // 
      // lbActiveOrders
      // 
      lbActiveOrders.BackColor = SystemColors.Control;
      lbActiveOrders.BorderStyle = BorderStyle.None;
      lbActiveOrders.Font = new Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
      lbActiveOrders.ForeColor = Color.Gray;
      lbActiveOrders.FormattingEnabled = true;
      lbActiveOrders.ItemHeight = 30;
      lbActiveOrders.Location = new Point(6, 22);
      lbActiveOrders.Name = "lbActiveOrders";
      lbActiveOrders.Size = new Size(279, 720);
      lbActiveOrders.TabIndex = 0;
      // 
      // gbCompletedOrders
      // 
      gbCompletedOrders.Controls.Add(lbCompletedOrders);
      gbCompletedOrders.Location = new Point(606, 12);
      gbCompletedOrders.Name = "gbCompletedOrders";
      gbCompletedOrders.Size = new Size(291, 774);
      gbCompletedOrders.TabIndex = 2;
      gbCompletedOrders.TabStop = false;
      gbCompletedOrders.Text = "Za preuzeti";
      // 
      // lbCompletedOrders
      // 
      lbCompletedOrders.BackColor = SystemColors.Control;
      lbCompletedOrders.BorderStyle = BorderStyle.None;
      lbCompletedOrders.Font = new Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
      lbCompletedOrders.ForeColor = Color.ForestGreen;
      lbCompletedOrders.FormattingEnabled = true;
      lbCompletedOrders.ItemHeight = 30;
      lbCompletedOrders.Location = new Point(6, 22);
      lbCompletedOrders.Name = "lbCompletedOrders";
      lbCompletedOrders.Size = new Size(279, 720);
      lbCompletedOrders.TabIndex = 0;
      // 
      // FormMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(909, 798);
      Controls.Add(gbCompletedOrders);
      Controls.Add(gbActiveOrders);
      Controls.Add(gbMenu);
      Name = "FormMain";
      Text = "McOrders";
      gbMenu.ResumeLayout(false);
      gbActiveOrders.ResumeLayout(false);
      gbCompletedOrders.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private GroupBox gbMenu;
    private Button btnPommes;
    private GroupBox gbActiveOrders;
    private ListBox lbActiveOrders;
    private GroupBox gbCompletedOrders;
    private ListBox lbCompletedOrders;
    private Button btnDrink;
    private Button btnBigMac;
  }
}