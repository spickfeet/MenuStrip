using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MenuStrip.Parsers
{
    public class ParserMenu
    {
        private string _pathConfig;

        public ParserMenu(string pathConfig)
        {
            if (!File.Exists(pathConfig)) throw new Exception("File Menu non existent"); 

            _pathConfig = pathConfig;
        }


        public IList<string[]> Parse()
        {
            IList<string[]> strings = new List<string[]>();

            using (StreamReader streamReader = new StreamReader(_pathConfig))
            {
                while (!streamReader.EndOfStream) { 
                    string line = streamReader.ReadLine();
                    string pattern = @"^(\d+) (.+) (\d+) (.+)$";
                    string pattern2 = @"^(\d+) (.+) (\d+)$";

                    if (Regex.IsMatch(line, pattern))
                    {
                        foreach (Match match in Regex.Matches(line, pattern))
                        {
                            strings.Add(new string[] {
                        match.Groups[1].Value,
                        match.Groups[2].Value,
                        match.Groups[3].Value,
                        match.Groups[4].Value
                        });
                        }
                    }
                    if (Regex.IsMatch(line, pattern2)) {

                        foreach (Match match in Regex.Matches(line, pattern2))
                        {
                            strings.Add(new string[] {
                        match.Groups[1].Value,
                        match.Groups[2].Value,
                        match.Groups[3].Value
                        });
                        }
                    }
                }
            }



            return strings;
        }
    }
}
