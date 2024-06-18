namespace _2049ClusterFuck
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginTextbox = new TextBox();
            PassTextbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            LabelDot = new Label();
            SuspendLayout();
            // 
            // LoginTextbox
            // 
            LoginTextbox.Location = new Point(59, 108);
            LoginTextbox.Name = "LoginTextbox";
            LoginTextbox.Size = new Size(125, 27);
            LoginTextbox.TabIndex = 0;
            // 
            // PassTextbox
            // 
            PassTextbox.Location = new Point(59, 221);
            PassTextbox.Name = "PassTextbox";
            PassTextbox.Size = new Size(125, 27);
            PassTextbox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 85);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 2;
            label1.Text = "Регистрация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 198);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 3;
            label2.Text = "Пароль";
            // 
            // button1
            // 
            button1.Location = new Point(95, 280);
            button1.Name = "button1";
            button1.Size = new Size(60, 29);
            button1.TabIndex = 4;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LabelDot
            // 
            LabelDot.AutoSize = true;
            LabelDot.Location = new Point(95, 353);
            LabelDot.Name = "LabelDot";
            LabelDot.Size = new Size(0, 20);
            LabelDot.TabIndex = 5;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Orange;
            ClientSize = new Size(257, 450);
            Controls.Add(LabelDot);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PassTextbox);
            Controls.Add(LoginTextbox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginTextbox;
        private TextBox PassTextbox;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label LabelDot;
    }
}