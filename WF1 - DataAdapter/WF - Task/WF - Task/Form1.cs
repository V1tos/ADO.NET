using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF___Task
{
    public partial class Form1 : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        SqlCommandBuilder builder = null;
        DataSet set = null;
        byte[] convImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.bmp; *.jpg; *.jpeg, *.png)|*.BMP;*.JPG;*.JPEG;*.PNG";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                pictureBox1.Image = Image.FromFile(fileName);
                ConvertImageToByteArr(pictureBox1.Image);
            }

        }

        private void ConvertImageToByteArr(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                convImage =  ms.ToArray();
            }
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("select * from Books", connection);
            builder = new SqlCommandBuilder(adapter);

            set = new DataSet();
            adapter.Fill(set);
            dataGridView1.DataSource = set.Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            set.Tables[0].Rows[int.Parse(textBox1.Text)]["Picture"] = convImage;

            SqlCommand command = new SqlCommand($"Update Books Set Picture = @p1 where Id = @p2");

            command.Parameters.AddWithValue("@p1", convImage);
            command.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));

            adapter.UpdateCommand = command;
            adapter.Update(set);
        }
    }
}
