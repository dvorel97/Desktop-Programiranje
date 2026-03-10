namespace LAB2
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
            components = new System.ComponentModel.Container();
            labelRad = new Label();
            textBoxRad = new TextBox();
            labelOdmor = new Label();
            textBoxOdmor = new TextBox();
            labelTimer = new Label();
            btnStart = new Button();
            btnReset = new Button();
            timerPomodoro = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labelRad
            // 
            labelRad.AutoSize = true;
            labelRad.Location = new Point(43, 31);
            labelRad.Name = "labelRad";
            labelRad.Size = new Size(27, 15);
            labelRad.TabIndex = 0;
            labelRad.Text = "Rad";
            labelRad.Click += label1_Click;
            // 
            // textBoxRad
            // 
            textBoxRad.Location = new Point(12, 49);
            textBoxRad.Name = "textBoxRad";
            textBoxRad.Size = new Size(100, 23);
            textBoxRad.TabIndex = 1;
            // 
            // labelOdmor
            // 
            labelOdmor.AutoSize = true;
            labelOdmor.Location = new Point(226, 31);
            labelOdmor.Name = "labelOdmor";
            labelOdmor.Size = new Size(45, 15);
            labelOdmor.TabIndex = 2;
            labelOdmor.Text = "Odmor";
            // 
            // textBoxOdmor
            // 
            textBoxOdmor.Location = new Point(198, 49);
            textBoxOdmor.Name = "textBoxOdmor";
            textBoxOdmor.Size = new Size(100, 23);
            textBoxOdmor.TabIndex = 3;
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.Font = new Font("Segoe UI", 20F);
            labelTimer.Location = new Point(108, 138);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(0, 37);
            labelTimer.TabIndex = 4;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 207);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 55);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start / Stop";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(198, 207);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 55);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 304);
            Controls.Add(btnReset);
            Controls.Add(btnStart);
            Controls.Add(labelTimer);
            Controls.Add(textBoxOdmor);
            Controls.Add(labelOdmor);
            Controls.Add(textBoxRad);
            Controls.Add(labelRad);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRad;
        private TextBox textBoxRad;
        private Label labelOdmor;
        private TextBox textBoxOdmor;
        private Label labelTimer;
        private Button btnStart;
        private Button btnReset;
        private System.Windows.Forms.Timer timerPomodoro;
    }
}
