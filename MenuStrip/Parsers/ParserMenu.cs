﻿using System.Text.RegularExpressions;

namespace MenuStrip.Parsers
{
    public class ParserMenu
    {
        private string _pathConfig;

        // Проверяем существование файла с заданным путем.
        public ParserMenu(string pathConfig)
        {
            if (!File.Exists(pathConfig)) throw new Exception("File Menu non existent");

            _pathConfig = pathConfig;
        }


        // Преобразуем строки файла в массивы значений.
        public IList<string[]> Parse()
        {
            IList<string[]> strings = new List<string[]>();

            using (StreamReader streamReader = new StreamReader(_pathConfig))
            {
                while (!streamReader.EndOfStream)
                {
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
                    if (Regex.IsMatch(line, pattern2))
                    {

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
