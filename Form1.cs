using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillEXIF
{
    public partial class Form1 : Form
    {

        string[] fileList = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                e.Effect = DragDropEffects.Copy;
                button1.Text = "";
                foreach (var file in fileList)
                {
                    button1.Text += file + "\n";
                }

                button1.Text += "\n\nCLICK TO REMOVE EXIF";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fileList == null)
            {
                MessageBox.Show("You have to select one or more files first.");
            }
            else
            {
                foreach (var file in fileList)
                {
                    ((System.Drawing.Bitmap)System.Drawing.Image.FromFile(file).Clone()).Save(System.IO.Path.ChangeExtension(file, null) + "_anon.png");
                }
            }
        }
    }
}
