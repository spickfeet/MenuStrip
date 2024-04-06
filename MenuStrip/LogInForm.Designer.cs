namespace ProgPR2
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            labelLogin = new Label();
            labelPassword = new Label();
            buttonLogIn = new Button();
            buttonCancel = new Button();
            panel1 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            label5 = new Label();
            labelLanguage = new Label();
            labelCapsStatus = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(167, 125);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(294, 27);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(167, 180);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(291, 27);
            textBoxPassword.TabIndex = 1;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(11, 128);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(139, 20);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "Имя пользователя";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(11, 180);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(62, 20);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Пароль";
            // 
            // buttonLogIn
            // 
            buttonLogIn.Location = new Point(56, 235);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(94, 29);
            buttonLogIn.TabIndex = 4;
            buttonLogIn.Text = "Вход";
            buttonLogIn.UseVisualStyleBackColor = true;
            buttonLogIn.Click += buttonLogIn_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(298, 235);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightYellow;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(11, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 21);
            panel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(312, 0);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 0;
            label3.Text = "АИС Отдел кадров";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gold;
            panel2.Controls.Add(label4);
            panel2.Location = new Point(11, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 21);
            panel2.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(312, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 0;
            label4.Text = "Версия 1.0.0.0";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label5);
            panel3.Location = new Point(11, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 21);
            panel3.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(182, 3);
            label5.Name = "label5";
            label5.Size = new Size(265, 20);
            label5.TabIndex = 0;
            label5.Text = "Введите имя пользователя и пароль";
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Location = new Point(23, 269);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(0, 20);
            labelLanguage.TabIndex = 11;
            // 
            // labelCapsStatus
            // 
            labelCapsStatus.AutoSize = true;
            labelCapsStatus.Location = new Point(234, 269);
            labelCapsStatus.Name = "labelCapsStatus";
            labelCapsStatus.Size = new Size(0, 20);
            labelCapsStatus.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(466, 299);
            Controls.Add(pictureBox1);
            Controls.Add(labelCapsStatus);
            Controls.Add(labelLanguage);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonLogIn);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Name = "LogInForm";
            Text = "LogInForm";
            Load += LogInForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label labelLogin;
        private Label labelPassword;
        private Button buttonLogIn;
        private Button buttonCancel;
        private Panel panel1;
        private Label label3;
        private Panel panel2;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private Label labelLanguage;
        private Label labelCapsStatus;
        private PictureBox pictureBox1;
    }
}