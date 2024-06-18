using Agregator;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2049ClusterFuck
{
    public partial class Table : Form
    {
        public Table(string log, int Score)
        {
            InitializeComponent();
            label15.Text = log;
            label17.Text = Convert.ToString(Score);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var obj = new Game(label15.Text);
            obj.ShowDialog();
            this.Close();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            DB dB = new DB();
            int score = Convert.ToInt32(label17.Text);
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT Name,Score FROM `users` ORDER BY Score DESC;", dB.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            label7.Text = Convert.ToString(table.Rows[0][0]);
            label8.Text = Convert.ToString(table.Rows[1][0]);
            label9.Text = Convert.ToString(table.Rows[2][0]);
            label10.Text = Convert.ToString(table.Rows[3][0]);
            label11.Text = Convert.ToString(table.Rows[4][0]);
            int counter = 0;
            bool found = false;
            do
            {
                if (Convert.ToInt32(table.Rows[counter][1]) == score)
                {
                    found = true;
                }
                else counter++;
            }
            while (found == false);
            counter++;
            label13.Text = Convert.ToString(counter);
        }
    }
}
