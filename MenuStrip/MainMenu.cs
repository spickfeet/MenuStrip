using System.Reflection;
using System.Windows.Forms;

namespace MenuStrip
{
    public partial class MainMenu : Form
    {
        private MenuMethods _menuMethods = new();
        private ConfigRepository _configRepository = new ConfigRepository();
        private List<string[]> _configs = new List<string[]>();
        private Dictionary<string, string> _methods = new Dictionary<string, string>();

        public MainMenu()
        {
            InitializeComponent();
            _configs = _configRepository.GetConfigs();
            Init();
        }

        public void CreateStrip(ToolStripMenuItem parentItem, int levelIndex, ref int i)
        {
            i++;

            while (i <= _configs.Count - 1 && levelIndex == Convert.ToInt32(_configs[i][0]))
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(_configs[i][1]);

                parentItem.DropDownItems.Add(menuItem);


                if (_configs[i].Length != 4)
                {
                    CreateStrip(menuItem, levelIndex + 1, ref i);
                    continue;
                }

                i++;
            }
        }

        public void Init()
        {
            for (int i = 0; i < _configs.Count; i++)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(_configs[i][1]);

                if (_configs[i].Length != 4)
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
