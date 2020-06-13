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

namespace trainingExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        /* void createMatrix(int row, int col, string filePath)
         {
             string path = filePath;
             StreamWriter f = new StreamWriter(path);
             int x = 20, y = 20;
             for(int i=0; i<col; i++)
             {
                 for (int j = 0; j < row; j++)
                 {
                     TextBox newTextBox = new TextBox();
                     this.Controls.Add(newTextBox);  
                     Point position = new Point(x, y);
                     newTextBox.Location = position;
                     newTextBox.Width = 20;
                     newTextBox.Text = "3";
                     x += 25;
                     f.Write(newTextBox.Text);
                     f.Write(".");
                 }
                 f.Write(";");
                 y += 30;
                 x = 20;
             }
             f.Close();
         }
         void showMatrix(string filePath)
         {

             string path = filePath;
             StreamReader f = new StreamReader(path);
             string[] cols = f.ReadLine().Split(".\n;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
             f.BaseStream.Seek(0, SeekOrigin.Begin);
             string[] rows = f.ReadToEnd().Split(";\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
             f.Close();
             int x = 20, y = 20, k=0;
             dataGridView1.RowCount = rows.Length;
             dataGridView1.ColumnCount = cols.Length;
             for (int i = 0; i < 5; i++)
             {
                 for (int j = 0; j < 4; j++)
                 {
                     dataGridView1.Rows[i].Cells[j].Value = "2";
                     k++;
                 }
                 y += 30;
                 x = 20;
             }
             f.Close();
         }*/
        string path = @"D:\Programming\C#\trainingExam\matrix.txt";
        void createMatrix(int n, int m, string pathToFile)
        {
            /*StreamWriter f = new StreamWriter(pathToFile);*/
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;
            for(int i=0; i < n; i++)
            {
                for(int j=0; j<m; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "2";
                }
            }
        }
        void saveMatrixInTxt(string pathToFile)
        {
            StreamWriter f = new StreamWriter(pathToFile);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    f.Write(dataGridView1.Rows[i].Cells[j].Value);
                    if (j == dataGridView1.Columns.Count - 1)
                        f.Write(";");
                    else
                        f.Write(".");
                }
                f.Write("");
            }
            f.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            createMatrix(int.Parse(textBox2.Text), int.Parse(textBox1.Text), path);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveMatrixInTxt(saveFileDialog1.FileName);
            }
        }
        OpenFileDialog openFile = new OpenFileDialog();

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 StreamReader f = new StreamReader(openFileDialog1.FileName);
                string[] digits = f.ReadToEnd().Split(";.\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                f.BaseStream.Seek(0, SeekOrigin.Begin);
                int cols = f.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0].Split('.').Length;
                f.BaseStream.Seek(0, SeekOrigin.Begin);
                int rows = f.ReadToEnd().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
                MessageBox.Show("m= " + cols + "n= " + rows);
                int k = 0;
                dataGridView1.RowCount = rows;
                dataGridView1.ColumnCount = cols;
                for(int i=0; i<rows; i++)
                {
                    for(int j=0; j<cols; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = digits[k];
                        k++;
                    }
                }
                f.Close();
            }
        }
    }
}
