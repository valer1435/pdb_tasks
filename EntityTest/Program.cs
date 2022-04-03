using MySQLApp;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
               
                string[] parsed_command;
                while (true) {
                    Console.WriteLine("Введите команду");
                    parsed_command = Console.ReadLine().Split();
                    if (parsed_command[0] == "add")
                    {
                        string nickname = parsed_command[1];
                        string name = parsed_command[2];
                        string password = parsed_command[3];
                        int age = Int32.Parse(parsed_command[4]);
                        addUser(nickname, name, password, age);
                    }
                    else if (parsed_command[0] == "remove")
                    {
                        string nickname = parsed_command[1];
                        removeUser(nickname);
                    }
                    else if (parsed_command[0] == "setAge")
                    {
                        string nickname = parsed_command[1];
                        int age = Int32.Parse(parsed_command[2]);
                        updateAge(nickname, age);
                    }
                    else if (parsed_command[0] == "printAll")
                    {
                        printAllUsers();
                    }
                    else {
                        Console.WriteLine("Неопознанная команда");
                    }
                }
                
            }
        }

        public static void addUser(string nickname, string name, string password, int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User { Nickname = nickname, Name = name, Password = GetMD5(password), Age = age };
                if (getUser(nickname) is null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    Console.WriteLine("Вставка успешна");
                }
                else {
                    Console.WriteLine("Юзер с таким ником уже есть");
                }
            }
        }

        public static User getUser(string nickname)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user_query = db.Users.Where(p => p.Nickname == nickname);
                if (user_query.Any())
                    return user_query.First();
                else
                    return null;
            }
        }

        public static void printAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user_query = db.Users;
                foreach (User user in user_query)
                    Console.WriteLine($"{user.Nickname}, {user.Password}, {user.Name},  {user.Age}");
            }
        }

        public static void updateAge(string nickname, int age)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = getUser(nickname);
                if (user is null)
                {
                    Console.WriteLine("Нет юзера с таким ником");
                }
                else {
                    user.Age = age;
                    db.SaveChanges();
                    Console.WriteLine("Изменение успешно");
                }

            }
        }

        public static void removeUser(string nickname)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = getUser(nickname);
                if (user is not null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Console.WriteLine("Удаление успешно");
                }
            }
        }
        static string GetMD5(string password)
        {
            byte[] hash = Encoding.ASCII.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}