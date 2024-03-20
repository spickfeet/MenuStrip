using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MenuStrip.Users;
using MenuStrip;
using Microsoft.VisualBasic.ApplicationServices;
using MenuStrip.Parsers;


namespace ProgPR2
{
    public partial class LogInForm : Form
    {
        private IList<IUser> _users = new List<IUser>();
        private IUser _currentUser;
        private ParserUser _userParser = new("usersConfig.txt");
        System.Windows.Forms.Timer timer1;
        public LogInForm()
        {
            InitializeComponent();
            _users = _userParser.Parse();
            timer1 = new System.Windows.Forms.Timer();
            this.timer1.Enabled = true;
            this.timer1.Interval = 100;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            timer1.Stop();

            this.TopMost = true;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetKeyboardLayout(int WindowsThreadProcessID);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr handleWindow, out int lpdwProcessID);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();



        private static InputLanguageCollection _InstalledInputLanguages;
        // Идентификатор активного потока
        private static int _ProcessId;
        // Текущий язык ввода
        private static string _CurrentInputLanguage;


        private static string GetKeyboardLayoutId()
        {

            _InstalledInputLanguages = InputLanguage.InstalledInputLanguages;

            // Получаем хендл активного окна
            IntPtr hWnd = GetForegroundWindow();
            // Получаем номер потока активного окна
            int WinThreadProcId = GetWindowThreadProcessId(hWnd, out _ProcessId);

            // Получаем раскладку
            IntPtr KeybLayout = GetKeyboardLayout(WinThreadProcId);
            // Циклом перебираем все установленные языки для проверки идентификатора
            for (int i = 0; i < _InstalledInputLanguages.Count; i++)
            {
                if (KeybLayout == _InstalledInputLanguages[i].Handle)
                {
                    _CurrentInputLanguage = _InstalledInputLanguages[i].Culture.ThreeLetterWindowsLanguageName.ToString();
                }
            }
            return _CurrentInputLanguage;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Text = GetKeyboardLayoutId();
            if (Text == "RUS")
            {
                labelLanguage.Text = "Язык ввода русский";
            }
            if (Text == "ENU")
            {
                labelLanguage.Text = "Язык ввода английский";
            }
            labelCapsStatus.Text = Console.CapsLock ? "Клавиша CapsLock нажата" : "";
        }

        public bool LogIn()
        {
            foreach (IUser user in _users)
            {
                if (user.Password == textBoxPassword.Text && user.Login == textBoxLogin.Text)
                {
                    _currentUser = user;
                    return true;
                }
            }
            return false;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (LogIn())
            {
                MainMenu mainMenu = new MainMenu(_currentUser.Configs);
                Hide();
                mainMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!!!!!!!!!!!!!!!");
            }
        }
    }
}
