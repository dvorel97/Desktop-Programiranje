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

        private void Form1_Load()
        {
            notes.getAllNotes();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            rtbNotes.Text = notes.loadXMLdb();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            notes.addXML(rtbNew.Text);
        }

    }
}
