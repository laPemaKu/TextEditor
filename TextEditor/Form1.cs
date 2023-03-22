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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string text, path;
        bool opened, bold = false, underline = false, italic = false;

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (underline == false)
            {
                rtxtUnos.Font = new Font(rtxtUnos.Font, FontStyle.Underline);
                underline = true;
                if (bold == true || italic == true)
                {
                    bold = false;
                    italic = false;
                }
            }
            else
            {
                rtxtUnos.Font = new Font(rtxtUnos.Font, FontStyle.Regular);
                underline = false;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (italic == false)
            {
                rtxtUnos.Font = new Font(rtxtUnos.Font, FontStyle.Italic);
                italic = true;
                if (bold == true || underline == true)
                {
                    bold= false;
                    underline = false;
                }
            }
            else
            {
                rtxtUnos.Font = new Font(rtxtUnos.Font, FontStyle.Regular);
                italic = false;
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rtxtUnos.Clear();
                path = ofd.FileName;
                StreamReader reader = new StreamReader(path);
                text = reader.ReadToEnd();
                rtxtUnos.AppendText(text);
                reader.Close();
                
            }
            opened = true;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if(bold == false)
            {
                rtxtUnos.Font = new Font(rtxtUnos.Font, FontStyle.Bold);
                bold=true;
                if (italic == true || underline == true)
                {
                    italic = false;
                    underline = false;
                }
            }
            else
            {
                rtxtUnos.Font = new Font(rtxtUnos.Font, FontStyle.Regular);
                bold = false;
            }
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (opened == true)
            {
                text = rtxtUnos.Text;
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(text);
                writer.Close();
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    text = rtxtUnos.Text;
                    StreamWriter writer = new StreamWriter(save.FileName);
                    writer.WriteLine(text);
                    writer.Close();

                }
            }
        }
    }
}
