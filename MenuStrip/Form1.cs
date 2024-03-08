using System.Reflection;

namespace MenuStrip
{
    public partial class Form1 : Form
    {        
        private MenuMethods menuMethods = new();
        private Dictionary<string, string> methods = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            InitMenu();
        }
        private void InitMenu()
        {
            string prevElement;
            ToolStripMenuItem prevItem = new();
            List<string> configs = ["0 Разное 0 Others", "0 Сотрудники 0 Stuff", "0 Приказы 0 Orders", "0 Документы 0 Docs", "0 Справочники 0", "1 Отделы 0", "2 Города 0", "2 Города 0", "2 Города 0 Towns"];
            foreach (string elementConfig in configs)
            {
                string[] splitElementConfig = elementConfig.Split(' ');
                if (splitElementConfig[0] == "0")
                {
                    ToolStripMenuItem Item = new(splitElementConfig[1]);
                    if (splitElementConfig.Length == 4)
                    {
                        methods.Add(splitElementConfig[1], splitElementConfig[3]);
                        Item.Click += OnClick;
                    }
                    menuStrip.Items.Add(Item);
                    prevItem = Item;
                }
                else
                {
                    ToolStripMenuItem Item = new(splitElementConfig[1]);
                    prevItem.DropDownItems.Add(Item);
                    if (splitElementConfig.Length == 4)
                    {
                        methods.Add(splitElementConfig[1], splitElementConfig[3]);
                        Item.Click += OnClick;
                    }
                    prevItem = Item;
                }
            }
        }
        private void OnClick(object sender, EventArgs e)
        {
            string keyMethod = (sender as ToolStripMenuItem).Text;

            MessageBox.Show(menuMethods.GetType().GetMethod(methods[keyMethod]).Invoke(menuMethods, null).ToString());
        }
    }
}
