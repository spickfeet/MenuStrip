using MenuStrip.Parsers;
using MenuStrip.Users;
using System.Reflection;
using System.Windows.Forms;


namespace MenuStrip
{

    public partial class MainMenu : Form
    {
        private static Assembly asm = Assembly.LoadFrom("MenuStripBuilderDLL.dll");
        private Dictionary<string, string> _methods = new Dictionary<string, string>();



        private IList<string[]> _menuConfig = new List<string[]>();

        public MainMenu(IDictionary<string, int> userConfigs)
        {
            FormClosed += OnClosed;

            InitializeComponent();

            Type? t = asm.GetType("MenuStripParser");
            if (t is not null)
            {
                // получаем метод Square
                MethodInfo? method = t.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);

                // вызываем метод, передаем ему значения для параметров и получаем результат
                object? menuConfig = method?.Invoke(null, new[] { "menuConfigs.txt" }); ;
                _menuConfig = (IList<string[]>)asm.GetType("UserMenuParser").GetMethod("Parse", BindingFlags.Public | BindingFlags.Static).Invoke(null, new[] { userConfigs, menuConfig });
            }         


            Init();
        }

        private void OnClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Создаёт элемент меню вложенный в объект-родитель, проверяя уровень доступа
        /// </summary>
        /// <param name="parentItem"></param>
        /// <param name="levelIndex"></param>
        /// <param name="i">Текущий индекс цикла</param>
        public void CreateStrip(ToolStripMenuItem parentItem, int levelIndex, ref int i)
        {
            i++;

            while (i <= _menuConfig.Count - 1 && levelIndex == Convert.ToInt32(_menuConfig[i][0]))
            {

                ToolStripMenuItem menuItem = new ToolStripMenuItem(_menuConfig[i][1]);

                parentItem.DropDownItems.Add(menuItem);

                if (_menuConfig[i][2] == "2")
                {
                    menuItem.Visible = false;
                }

                if (_menuConfig[i][2] == "1")
                {
                    menuItem.Enabled = false;
                }

                if (_menuConfig[i].Length != 4)
                {
                    CreateStrip(menuItem, levelIndex + 1, ref i);
                    continue;
                }

                if (_menuConfig[i][2] == "0")
                {
                    _methods.Add(_menuConfig[i][1], _menuConfig[i][3]);
                    menuItem.MouseDown += OnClick;
                }

                i++;
            }
        }

        /// <summary>
        /// Создаёт меню пользователя на основе конфига
        /// </summary>
        public void Init()
        {
            int j = 0;
            for (int i = 0; i < _menuConfig.Count; i++)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(_menuConfig[i][1]);


                j = i;

                if (_menuConfig[i].Length != 4)
                {
                    CreateStrip(menuItem, 1, ref i);
                    if (_menuConfig[j][2] == "2") continue;
                    if (_menuConfig[j][2] == "1")
                    {
                        menuItem.Enabled = false;
                    }
                    menuStrip.Items.Add(menuItem);
                    i--;
                    continue;
                }

                if (_menuConfig[j][2] == "2") continue;

                if (_menuConfig[j][2] == "1") menuItem.Enabled = false;

                if (_menuConfig[i][2] == "0")
                {
                    _methods.Add(_menuConfig[i][1], _menuConfig[i][3]);
                    menuItem.MouseDown += OnClick;
                }

                menuStrip.Items.Add(menuItem);
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            string keyMethod = (sender as ToolStripMenuItem).Text;

            MessageBox.Show(asm.GetType("MyMenuMethods").GetMethod(_methods[keyMethod], BindingFlags.Public | BindingFlags.Static).Invoke(null, null).ToString());
        }
    }
}
