using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ProgPR2
{
    public partial class LogInForm : Form
    {
        System.Windows.Forms.Timer timer1;  
        public LogInForm()
        {
            InitializeComponent();

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
            labelCapsStatus.Text = Console.CapsLock ? "Клавишка CapsLock нажата" : "";
        }
    }
}
