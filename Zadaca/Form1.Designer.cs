namespace Zadaca
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
            lblHeader = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            btnSweets = new Button();
            btnIceCream = new Button();
            groupBox4 = new GroupBox();
            btnCupon100 = new Button();
            btnClose = new Button();
            richTextBox1 = new RichTextBox();
            lblSumTxt = new Label();
            lblSum = new Label();
            btnNew = new Button();
            btnCheckout = new Button();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("MV Boli", 15.9000006F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(23, 32);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(295, 70);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "VUB Caffe";
            lblHeader.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(78, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(871, 182);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kave";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(78, 379);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(871, 206);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bezalkoholna pića";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnSweets);
            groupBox3.Controls.Add(btnIceCream);
            groupBox3.Location = new Point(78, 628);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(875, 194);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Deserti";
            // 
            // btnSweets
            // 
            btnSweets.Location = new Point(304, 57);
            btnSweets.Name = "btnSweets";
            btnSweets.Size = new Size(204, 105);
            btnSweets.TabIndex = 2;
            btnSweets.Text = "Kolač";
            btnSweets.UseVisualStyleBackColor = true;
            // 
            // btnIceCream
            // 
            btnIceCream.Location = new Point(52, 57);
            btnIceCream.Name = "btnIceCream";
            btnIceCream.Size = new Size(204, 105);
            btnIceCream.TabIndex = 1;
            btnIceCream.Text = "Sladoled";
            btnIceCream.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnCupon100);
            groupBox4.Location = new Point(78, 875);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(875, 203);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Kuponi";
            // 
            // btnCupon100
            // 
            btnCupon100.Location = new Point(52, 59);
            btnCupon100.Name = "btnCupon100";
            btnCupon100.Size = new Size(204, 105);
            btnCupon100.TabIndex = 1;
            btnCupon100.Text = "100€";
            btnCupon100.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(773, 34);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(180, 105);
            btnClose.TabIndex = 5;
            btnClose.Text = "Izlaz";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(998, 32);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(802, 790);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // lblSumTxt
            // 
            lblSumTxt.AutoSize = true;
            lblSumTxt.Font = new Font("Segoe UI", 14F);
            lblSumTxt.Location = new Point(998, 837);
            lblSumTxt.Name = "lblSumTxt";
            lblSumTxt.Size = new Size(202, 62);
            lblSumTxt.TabIndex = 7;
            lblSumTxt.Text = "Ukupno:";
            // 
            // lblSum
            // 
            lblSum.AutoSize = true;
            lblSum.Font = new Font("Segoe UI", 14.1F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSum.Location = new Point(1576, 837);
            lblSum.Name = "lblSum";
            lblSum.Size = new Size(224, 62);
            lblSum.TabIndex = 8;
            lblSum.Text = "0,00 EUR";
            lblSum.TextAlign = ContentAlignment.TopRight;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(998, 973);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(394, 105);
            btnNew.TabIndex = 9;
            btnNew.Text = "Novi račun";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(1406, 973);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(394, 105);
            btnCheckout.TabIndex = 10;
            btnCheckout.Text = "Naplata";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1837, 1183);
            Controls.Add(groupBox1);
            Controls.Add(btnCheckout);
            Controls.Add(btnNew);
            Controls.Add(lblSum);
            Controls.Add(lblSumTxt);
            Controls.Add(richTextBox1);
            Controls.Add(btnClose);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(lblHeader);
            Name = "Form1";
            Text = "VUB Caffe";
            Paint += Form1_Paint;
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnSweets;
        private Button btnIceCream;
        private GroupBox groupBox4;
        private Button btnCupon100;
        private Button btnClose;
        private RichTextBox richTextBox1;
        private Label lblSumTxt;
        private Label lblSum;
        private Button btnNew;
        private Button btnCheckout;
    }
}
