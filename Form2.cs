using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Emlak_uygulama
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-7RQ7VJ29\SQLEXPRESS;Initial Catalog=siteler;Integrated Security=True");
        private void show_data()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select* From bilgiler", connection);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["id"].ToString();
                add.SubItems.Add(read["site"].ToString());
                add.SubItems.Add(read["durum"].ToString());
                add.SubItems.Add(read["oda"].ToString());
                add.SubItems.Add(read["metre"].ToString());
                add.SubItems.Add(read["fiyat"].ToString());
                add.SubItems.Add(read["blog"].ToString());
                add.SubItems.Add(read["no"].ToString());
                add.SubItems.Add(read["ad_soyad"].ToString());
                add.SubItems.Add(read["telefon"].ToString());
                add.SubItems.Add(read["notlar"].ToString());

                listView1.Items.Add(add);
            }
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Akdeniz")
            {
                button1.BackColor = Color.Blue;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;

            }
            if(comboBox1.Text== "Ege")
            {
                button4.BackColor = Color.YellowGreen;
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
            }
            if(comboBox1.Text== "Doğu Anadolu")
            {
                button2.BackColor = Color.Brown;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
                button1.BackColor = Color.Gray;

            }
            if(comboBox1.Text== "Karadeniz")
            {
                button3.BackColor = Color.Green;
                button4.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button1.BackColor = Color.Gray;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show_data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into bilgiler(id,site,durum,oda,metre,fiyat,blog,no,ad_soyad,telefon,notlar) Values ('"+textBox7.Text.ToString()+"'," +
                "'"+comboBox1.Text.ToString()+"','"+comboBox2.Text.ToString()+"','"+comboBox3.Text.ToString()+"','"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"'," +
                "'"+comboBox4.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+textBox6.Text.ToString()+"')",connection);
            command.ExecuteNonQuery();
            connection.Close();
            show_data();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        int id = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from bilgiler where id=('" + id + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            show_data();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update bilgiler set id='" + textBox7.Text.ToString() + "',site='" + comboBox1.Text.ToString() +
                "',durum='"+comboBox2.Text.ToString()+"',oda='"+comboBox3.Text.ToString()+"',metre='"+textBox1.Text.ToString()+"',fiyat='"+textBox2.Text.ToString()+"',blog='" +
                comboBox4.Text.ToString() + "',no='" + textBox3.Text.ToString() + "',ad_soyad='" + textBox4.Text.ToString() + "',telefon='" + textBox5.Text.ToString() +
                "',notlar='" + textBox6.Text.ToString() + "'where id=('"+id+"')",connection);
            command.ExecuteNonQuery();
            connection.Close();
            show_data();
        }
    }
}



