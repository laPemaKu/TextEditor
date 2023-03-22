using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string text, path;
        bool opened;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                StreamReader reader = new StreamReader(path);
                text = reader.ReadToEnd();
                txtUnos.AppendText(text);
                reader.Close();
                opened = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (opened == true)
            {
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(text);
                writer.Close();
            }
            else {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    
                }

            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {

        }

        private void btnItalic_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {

        }
    }
}
