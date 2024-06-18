using Agregator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace _2049ClusterFuck
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            string Log;
            string pass;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = LoginTextbox.Text;
            string password = PassTextbox.Text;
            string Log = login;
            string pass = password;
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Name`= @l", dB.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM `users` WHERE `Name`= @l AND `Password` = @p", dB.getConnection());
                command2.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
                command2.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command2;
                table.Reset();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    var ob = new Game(Log);
                    ob.ShowDialog();
                }
                else LabelDot.Text = "Неверный пароль";
            }
            else
            {
                MySqlCommand command3 = new MySqlCommand("INSERT INTO `users` (`Name`, `Password`, `Score`) VALUES (@LoginUse, @pass, 0);", dB.getConnection());
                command3.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                command3.Parameters.Add("@LoginUse", MySqlDbType.VarChar).Value = login;
                dB.openconnection();

                if (command3.ExecuteNonQuery() == 1)
                {
                    LabelDot.Text = "Команда запущена";
                }
                dB.closeconnection();
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM `users` WHERE `Name`= @l AND `Password` = @p", dB.getConnection());
                command2.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
                command2.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command2;
                table.Reset();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    var ob = new Game(Log);
                    ob.ShowDialog();
                }
                else LabelDot.Text = "Неверный пароль";
            }
        }
    }
}
