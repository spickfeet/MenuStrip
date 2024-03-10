using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuStrip.Users;

namespace MenuStrip.Parser
{
    public class Parser
    {
        public Parser(string pathMenu, string pathUsers)
        {
            if (!File.Exists(pathMenu)) { throw new Exception("File Menu non existent"); }
            if (!File.Exists(pathUsers)) { throw new Exception("File Users non existent"); }

            this.pathMenu = pathMenu;
            this.pathUsers = pathUsers;
        }

        private string pathMenu;

        private string pathUsers;

        public IList<string[]> ParseMenu()
        {
            IList<string[]> strings = new List<string[]>();

            using (StreamReader streamReader = new StreamReader(pathMenu))
            {
                for (int i = 0; !streamReader.EndOfStream; i++) { strings.Add(streamReader.ReadLine().Split(' ')); }
            }

            return strings;
        }


        public IList<IUser> ParseUsers()
        {
            IList<IUser> listUsers = new List<IUser>();

            using (StreamReader streamReader = new StreamReader(pathUsers))
            {
                IList<string> list = new List<string>();
                list.Add(streamReader.ReadLine());//отсутствие проверок. Обязательно должен быть соблюден строгий формат

                while (!streamReader.EndOfStream)
                {
                    string str = streamReader.ReadLine(); //формат

                    if (str.StartsWith('#')) //формат
                    {
                        IUser user = new User();

                        string[] logAndPas = list[0].Split(' ');
                        user.Login = logAndPas[0];
                        user.Password = logAndPas[1];

                        for (int i = 1; i < list.Count; i++) // формат
                        {
                            string[] configUser = list[i].Split(' ');
                            user.Configs.Add(configUser[0], int.Parse(configUser[1]));
                        }

                        listUsers.Add(user);
                        list.Clear();
                    }
                    else
                    {
                        list.Add(str);
                    }
                }
            }

            return listUsers;
        }
    }
}
