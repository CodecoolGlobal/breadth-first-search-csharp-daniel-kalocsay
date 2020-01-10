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
            BFS bfs = new BFS();
            bfs.VisitAllNodes(users);

            var user1 = users[0];
            var user2 = users[20];
            
            Console.WriteLine($"\nDistance between {user1} and {user2}:\n");
            Console.WriteLine(bfs.CalculateUsersDistance(user1, user2));

            var distance = 40;

            Console.WriteLine($"\n{user1}'s friends of friends at {distance} distance:\n");

            foreach (var friend in bfs.GetFriendsOfFriends(user1, distance))
            {
                Console.WriteLine(friend);
            }
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
