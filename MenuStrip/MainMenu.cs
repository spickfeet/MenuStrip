using MenuStrip.Parsers;
using MenuStrip.Users;
using System.Reflection;
using System.Windows.Forms;

namespace MenuStrip
{
    public partial class MainMenu : Form
    {
        private MenuMethods _menuMethods = new();
        private Dictionary<string, string> _methods = new Dictionary<string, string>();

        private IList<string[]> _menuConfig = new List<string[]>();

        public MainMenu(IDictionary<string, int> userConfigs)
        {
            FormClosed += OnClosed;

            InitializeComponent();

            ParserMenu parserMenu = new ParserMenu("menuConfigs.txt");
            IList<string[]> menuConfig = parserMenu.Parse();

            ParserUserMenu parserUserMenu = new ParserUserMenu(userConfigs, menuConfig);
            _menuConfig = parserUserMenu.Parse();

            Init();
        }

        private void OnClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void CreateStrip(ToolStripMenuItem parentItem, int levelIndex, ref int i)
        {
            i++;

            while (i <= _menuConfig.Count - 1 && levelIndex == Convert.ToInt32(_menuConfig[i][0]))
            {
                if (_menuConfig[i][2] == "2")
                {
                    i++;
                    continue;
                }

                ToolStripMenuItem menuItem = new ToolStripMenuItem(_menuConfig[i][1]);

                parentItem.DropDownItems.Add(menuItem);

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

                if (_menuConfig[j][2] == "1")
                {
                    menuItem.Enabled = false;
                }

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

            MessageBox.Show(_menuMethods.GetType().GetMethod(_methods[keyMethod]).Invoke(_menuMethods, null).ToString());
        }
    }
}
