using System.Reflection;

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

        private void Init()
        {
            ToolStripMenuItem prevItem = new();
          
            foreach (string[] elementConfig in _configs)
            {
                ToolStripMenuItem Item = new(elementConfig[1]);

                if (elementConfig.Length == 4)
                {
                    _methods.Add(elementConfig[1], elementConfig[3]);
                    Item.Click += OnClick;
                }

                if (elementConfig[0] == "0")
                    menuStrip.Items.Add(Item);
                else
                    prevItem.DropDownItems.Add(Item);

                prevItem = Item;
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            string keyMethod = (sender as ToolStripMenuItem).Text;

            MessageBox.Show(_menuMethods.GetType().GetMethod(_methods[keyMethod]).Invoke(_menuMethods, null).ToString());
        }
    }
}
