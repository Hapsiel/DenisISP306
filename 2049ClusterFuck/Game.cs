using Agregator;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace _2049ClusterFuck
{
    public partial class Game : Form
    {
        public Game(string login)
        {
            InitializeComponent();
            init();
            KeyPreview = true;
            label5.Text = login;
            string loga = login;
        }
        
        int Score = 0;
        int[,] map = new int[4, 4];
        Random rnd = new Random();
        bool Blocked = false;
        bool BlockWin = false;
        private void init()
        {
            ScoreLabel.Text = Convert.ToString(Score);
            Spawn();
            Spawn();
            button2.Enabled = false;
            button3.Enabled = false;
            button2.Visible = false;
            button3.Visible = false;
        }
        private string drawof(int num)
        {
            string path = " ";
            switch (num)
            {
                case 0:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\0.png";
                    return path;
                    break;
                case 2:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\2.png";
                    return path;
                    break;
                case 4:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\4.png";
                    return path;
                    break;
                case 8:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\8.png";
                    return path;
                    break;
                case 16:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\16.png";
                    return path;
                    break;
                case 32:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\32.png";
                    return path;
                    break;
                case 64:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\64.png";
                    return path;
                    break;
                case 128:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\128.png";
                    return path;
                    break;
                case 256:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\256.png";
                    return path;
                    break;
                case 512:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\512.png";
                    return path;
                    break;
                case 1024:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\1024.png";
                    return path;
                    break;
                case 2048:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\2048.png";
                    return path;
                    break;
                case 4096:
                    path = "C:\\Work\\2049ClusterFuck\\2049ClusterFuck\\numbers\\4096.png";
                    return path;
                    break;
            }
            return path;
        }
        private void Draw()
        {
            pictureBox1.Image = Image.FromFile(drawof(map[0, 0]));
            pictureBox2.Image = Image.FromFile(drawof(map[0, 1]));
            pictureBox3.Image = Image.FromFile(drawof(map[0, 2]));
            pictureBox4.Image = Image.FromFile(drawof(map[0, 3]));
            pictureBox5.Image = Image.FromFile(drawof(map[1, 0]));
            pictureBox6.Image = Image.FromFile(drawof(map[1, 1]));
            pictureBox7.Image = Image.FromFile(drawof(map[1, 2]));
            pictureBox8.Image = Image.FromFile(drawof(map[1, 3]));
            pictureBox9.Image = Image.FromFile(drawof(map[2, 0]));
            pictureBox10.Image = Image.FromFile(drawof(map[2, 1]));
            pictureBox11.Image = Image.FromFile(drawof(map[2, 2]));
            pictureBox12.Image = Image.FromFile(drawof(map[2, 3]));
            pictureBox13.Image = Image.FromFile(drawof(map[3, 0]));
            pictureBox14.Image = Image.FromFile(drawof(map[3, 1]));
            pictureBox15.Image = Image.FromFile(drawof(map[3, 2]));
            pictureBox16.Image = Image.FromFile(drawof(map[3, 3]));
        }
        private void UP()
        {
            bool isMoved = false;
            bool placed = false;
            int x;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    x = j;
                    placed = false;
                    if (x != 0)
                    {
                        do
                        {
                            if (x != 0)
                            {
                                if (map[x, i] == 0) placed = true;
                                else
                                {
                                    if (map[x - 1, i] == 0)
                                    {
                                        map[x - 1, i] = map[x, i];
                                        map[x, i] = 0;
                                        x--;
                                        isMoved = true;
                                    }
                                    else
                                    {
                                        if (map[x - 1, i] == map[x, i])
                                        {
                                            map[x - 1, i] = map[x - 1, i] * 2;
                                            map[x, i] = 0;
                                            Score = Score + map[x - 1, i];
                                            x--;
                                            isMoved = true;
                                        }
                                        else placed = true;
                                    }
                                }
                            }
                            else placed = true;
                        }
                        while (placed == false);
                    }
                }
                Draw();
            }
            if (isMoved == true) Spawn();
        }
        private void Down()
        {
            bool isMoved = false;
            bool placed = false;
            int x;
            int count = 1;
            bool search = false;
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    x = j;
                    placed = false;
                    if (x <= 2)
                    {
                        do
                        {
                            if (x <= 2 && x >= 0)
                            {
                                if (map[x, i] == 0) placed = true;
                                else
                                {
                                    if (map[x + 1, i] == 0)
                                    {
                                        map[x + 1, i] = map[x, i];
                                        map[x, i] = 0;
                                        x++;
                                        isMoved = true;
                                    }
                                    else
                                    {
                                        if (map[x + 1, i] == map[x, i])
                                        {
                                            map[x + 1, i] = map[x + 1, i] * 2;
                                            map[x, i] = 0;
                                            Score = Score + map[x + 1, i];
                                            x++;
                                            isMoved = true;
                                        }
                                        else placed = true;
                                    }
                                }
                            }
                            else placed = true;
                        }
                        while (placed == false);
                    }
                }
                Draw();
            }
            if (isMoved == true) Spawn();
        }
        private void Right()
        {
            bool isMoved = false;
            bool placed = false;
            int x;
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    x = j;
                    placed = false;
                    if (x != 3)
                    {
                        do
                        {
                            if (x != 3)
                            {
                                if (map[i, x] == 0) placed = true;
                                else
                                {
                                    if (map[i, x + 1] == 0)
                                    {
                                        map[i, x + 1] = map[i, x];
                                        map[i, x] = 0;
                                        x++;
                                        isMoved = true;
                                    }
                                    else
                                    {
                                        if (map[i, x + 1] == map[i, x])
                                        {
                                            map[i, x + 1] = map[i, x + 1] * 2;
                                            map[i, x] = 0;
                                            Score = Score + map[i, x + 1];
                                            x++;
                                            isMoved = true;
                                        }
                                        else placed = true;
                                    }
                                }
                            }
                            else placed = true;
                        }
                        while (placed == false);
                    }
                }
                Draw();
            }
            if (isMoved == true) Spawn();
        }
        private void Left()
        {
            bool isMoved = false;
            bool placed = false;
            int x;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    x = j;
                    placed = false;
                    if (x != 0)
                    {
                        do
                        {
                            if (x != 0)
                            {
                                if (map[i, x] == 0) placed = true;
                                else
                                {
                                    if (map[i, x - 1] == 0)
                                    {
                                        map[i, x - 1] = map[i, x];
                                        map[i, x] = 0;
                                        x--;
                                        isMoved = true;
                                    }
                                    else
                                    {
                                        if (map[i, x - 1] == map[i, x])
                                        {
                                            map[i, x - 1] = map[i, x - 1] * 2;
                                            map[i, x] = 0;
                                            Score = Score + map[i, x - 1];
                                            x--;
                                            isMoved = true;
                                        }
                                        else placed = true;
                                    }
                                }
                            }
                            else placed = true;
                        }
                        while (placed == false);
                    }
                }
                Draw();
            }
            if (isMoved == true) Spawn();
        }
        private bool Fullcheack()
        {
            bool res = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i, j] == 0)
                    {
                        res = false;
                    }
                }
            }
            return res;
        }
        private void Spawn()
        {
            Random rnd = new Random();
            bool placed = false;
            bool placedS = false;
            int x = 0;
            int y = 0;

            for (int i = 0; i < 10; i++)
            {
                if (Fullcheack() == false && placed == false)
                {
                    x = rnd.Next(0, 4);
                    y = rnd.Next(0, 4);
                    if (map[x, y] == 0)
                    {
                        map[x, y] = 2;
                        placed = true;
                    }
                }
                else placed = true;
            }
            if (placed = false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (map[i, j] == 0 && placed == false)
                        {
                            map[i, j] = 2;
                            placed = true;
                        }
                    }
                }
            }
            Draw();
        }
        private bool CheckWin()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i, j] == 2048)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool CheckLose()
        {
            if (Fullcheack() == true)
            {
                if (map[0, 0] == map[0, 1]) return false;
                if (map[0, 0] == map[1, 0]) return false;
                if (map[0, 3] == map[1, 3]) return false;
                if (map[0, 3] == map[0, 2]) return false;
                if (map[3, 0] == map[3, 1]) return false;
                if (map[3, 0] == map[2, 0]) return false;
                if (map[3, 3] == map[3, 2]) return false;
                if (map[3, 3] == map[2, 3]) return false;
                if (map[1, 1] == map[0, 1]) return false;
                if (map[1, 1] == map[1, 0]) return false;
                if (map[1, 1] == map[1, 2]) return false;
                if (map[1, 1] == map[2, 1]) return false;
                if (map[2, 2] == map[2, 1]) return false;
                if (map[2, 2] == map[2, 3]) return false;
                if (map[2, 2] == map[3, 2]) return false;
                if (map[2, 2] == map[1, 2]) return false;
                if (map[1, 0] == map[1, 1]) return false;
                if (map[2, 0] == map[2, 1]) return false;
                if (map[1, 3] == map[1, 2]) return false;
                if (map[2, 3] == map[2, 2]) return false;
                if (map[0, 1] == map[1, 1]) return false;
                if (map[0, 2] == map[1, 2]) return false;
                if (map[3, 1] == map[2, 1]) return false;
                if (map[3, 2] == map[2, 2]) return false;
                if (map[1, 0] == map[2, 0]) return false;
                if (map[1, 3] == map[2, 3]) return false;
                if (map[3, 1] == map[3, 2]) return false;
                if (map[0, 1] == map[0, 2]) return false;
                return true;
            }
            return false;
        }
        private void Win()
        {
            Blocked = true;
            label2.Text = "Win";
            button2.Enabled = true;
            button3.Enabled = true;
            button2.Visible = true;
            button3.Visible = true;
        }
        private void Lose()
        {
            Blocked = true;
            label2.Text = "Lose";
            button3.Enabled = true;
            button3.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Blocked != true)
            {
                switch (Convert.ToString(e.KeyCode))
                {
                    case "W":
                        UP();
                        break;
                    case "S":
                        Down();
                        break;
                    case "D":
                        Right();
                        break;
                    case "A":
                        Left();
                        break;
                }
            }
            ScoreLabel.Text = Convert.ToString(Score);
            if (CheckWin() == true && BlockWin == false)
            {
                Win();
            }
            if (CheckLose() == true)
            {
                Lose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blocked = false;
            label2.Text = "";
            button2.Visible = false;
            button3.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
            BlockWin = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            string login = label5.Text;
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `Score` = @s WHERE `Name` = @l;", dB.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@s", MySqlDbType.Int64).Value = Score;
            dB.openconnection();

            if (command.ExecuteNonQuery() == 1)
            {
            }
            dB.closeconnection();
            this.Hide();
            var gh = new Table(label5.Text, Score);
            gh.Show();
        }
    }
}