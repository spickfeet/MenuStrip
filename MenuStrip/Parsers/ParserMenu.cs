using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuStrip.Parsers
{
    public class ParserMenu
    {
        private string _pathConfig;

        public ParserMenu(string pathConfig)
        {
            if (!File.Exists(_pathConfig)) throw new Exception("File Menu non existent"); 

            _pathConfig = pathConfig;
        }


        public IList<string[]> Parse()
        {
            IList<string[]> strings = new List<string[]>();

            using (StreamReader streamReader = new StreamReader(_pathConfig))
            {
                for (int i = 0; !streamReader.EndOfStream; i++) { strings.Add(streamReader.ReadLine().Split(' ')); }
            }

            return strings;
        }
    }
}
