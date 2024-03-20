using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuStrip.Parsers
{
    public class ParserUserMenu
    {
        private IDictionary<string, int> _userConfigs;
        private IList<string[]> _menuConfigs;

        public ParserUserMenu(IDictionary<string, int> userConfigs, IList<string[]> menuConfigs)
        {
            _userConfigs = userConfigs;
            _menuConfigs = menuConfigs;
        }

        public IList<string[]> Parse()
        {
            IList<string[]> result = new List<string[]>(_menuConfigs);

            foreach (string[] config in result)
            {
                if (_userConfigs.TryGetValue(config[1], out int access))
                {
                    config[2] = access.ToString();
                }
            }

            return result;
        }
    }
}
