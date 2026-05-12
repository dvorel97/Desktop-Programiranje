namespace lab10
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.rtbNew = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(309, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Dohvati";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(370, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(308, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Spremi";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(13, 13);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(308, 396);
            this.rtbNotes.TabIndex = 4;
            this.rtbNotes.Text = "";
            // 
            // rtbNew
            // 
            this.rtbNew.Location = new System.Drawing.Point(370, 13);
            this.rtbNew.Name = "rtbNew";
            this.rtbNew.Size = new System.Drawing.Size(308, 396);
            this.rtbNew.TabIndex = 5;
            this.rtbNew.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.Controls.Add(this.rtbNew);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.RichTextBox rtbNew;
    }
}

