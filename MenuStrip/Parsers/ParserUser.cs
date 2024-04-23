using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuStrip.Users;

namespace MenuStrip.Parsers
{
    public class ParserUser
    {
        private string _pathConfig;

        //проверяем существование файла с заданным путем
        public ParserUser(string pathConfig)
        {
            
            if (!File.Exists(pathConfig)) { throw new Exception("File Users non existent"); }

            _pathConfig = pathConfig;
        }


        // преобразуем строки файла в массивы значений
        public IList<IUser> Parse()
        {
            IList<IUser> listUsers = new List<IUser>();

            using (StreamReader streamReader = new StreamReader(_pathConfig))
            {
                IList<string> list = new List<string>();
                list.Add(streamReader.ReadLine());

                IUser user = new User();
                string str = "";
                string[] logAndPas;

                while (!streamReader.EndOfStream)
                {
                    str = streamReader.ReadLine();

                    if (str.StartsWith('#'))
                    {
                        user = new User();

                        logAndPas = list[0].Split(' ');
                        user.Login = logAndPas[0].Remove(0, 1);
                        user.Password = logAndPas[1];

                        for (int i = 1; i < list.Count; i++)
                        {
                            string[] configUser = list[i].Split(' ');
                            user.Configs.Add(configUser[0], int.Parse(configUser[1]));
                        }

                        listUsers.Add(user);
                        list.Clear();
                        list.Add(str);
                    }
                    else
                    {
                        list.Add(str);
                    }
                }

                user = new User();

                logAndPas = list[0].Split(' ');
                user.Login = logAndPas[0].Remove(0, 1);
                user.Password = logAndPas[1];

                for (int i = 1; i < list.Count; i++)
                {
                    string[] configUser = list[i].Split(' ');
                    user.Configs.Add(configUser[0], int.Parse(configUser[1]));
                }

                listUsers.Add(user);
            }

            return listUsers;
        }
    }
}
