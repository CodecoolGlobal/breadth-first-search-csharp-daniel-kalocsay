using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            var users = generator.Generate();
            
            ShowUsers(users);
            
            TestBfsMethods(users);

            Console.WriteLine("\nDone");

            Console.ReadKey();
        }

        private static void TestBfsMethods(List<UserNode> users)
        {
            BFS bfs = new BFS(users);
            bfs.VisitAllNodes(users[0]);
        }

        private static void ShowUsers(List<UserNode> users)
        {
            Console.WriteLine("Users:\n");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
