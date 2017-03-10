using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var helloPasswords =
                from user in users
                where user.Password == "hello"
                select user.Password;
            
            //I don't see how I can output the passwords to the console without
            //using some kind of loop here
            foreach (string password in helloPasswords)
            {
                Console.WriteLine($"Password: {password}");
            }

            users.RemoveAll( user => user.Password == user.Name.ToLower());

            var firstWithHello = users.Where( user => user.Password == "hello").First();
            users.Remove(firstWithHello);

            Console.WriteLine();

            foreach (var user in users)
            {
                Console.WriteLine("******Users Left ******");
                Console.WriteLine($"Username: {user.Name}, Password: {user.Password}");
            }
            Console.WriteLine();
        }
    }
}
