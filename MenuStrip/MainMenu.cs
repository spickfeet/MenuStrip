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

        public MainMenu()
        {
            InitializeComponent();

            ParserMenu parser = new ParserMenu("menuConfig.txt");
            _menuConfig = parser.Parse();

            Init();
        }

        public void CreateStrip(ToolStripMenuItem parentItem, int levelIndex, ref int i)
        {
            i++;

            while (i <= _menuConfig.Count - 1 && levelIndex == Convert.ToInt32(_menuConfig[i][0]))
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(_menuConfig[i][1]);

                parentItem.DropDownItems.Add(menuItem);


                if (_menuConfig[i].Length != 4)
                {
                    CreateStrip(menuItem, levelIndex + 1, ref i);
                    continue;
                }

                i++;
            }
        }

        public void Init()
        {
            for (int i = 0; i < _menuConfig.Count; i++)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(_menuConfig[i][1]);

                if (_menuConfig[i].Length != 4)
                {
                    CreateStrip(menuItem, 1, ref i);
                    menuStrip.Items.Add(menuItem);
                    i--;
                    continue;
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
