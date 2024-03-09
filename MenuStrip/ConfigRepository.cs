using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuStrip
{
    public class ConfigRepository
    {
        List<string> configs = ["0 Разное 0 Others", "0 Сотрудники 0 Stuff", "0 Приказы 0 Orders",
            "0 Документы 0 Docs", "0 Справочники 0", "1 Отделы 0", "2 Города 0", "2 Города 0", "2 Города 0 Towns"];

        public List<string[]> GetConfigs()
        {
            List<string[]> strings = new List<string[]>();

            foreach (string config in configs)
            {
                strings.Add(config.Split(' '));
            }

            return strings;
        }
    }
}
