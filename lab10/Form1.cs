using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab10
{
    public partial class Form1 : Form
    {
        Notes notes = new Notes();
        public Form1()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string data = notes.ToString();
            MessageBox.Show(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var n = notes.getAllNotes();
            notes.delete(n.First());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notes.update(notes.getAllNotes().First());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            notes.add();
        }
    }
}
