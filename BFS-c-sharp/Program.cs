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
            // var users = generator.Generate();
            var users = generator.GenerateCustomTree();
            
//            ShowUsers(users);
            TestBfsMethods(users);

            Console.WriteLine("\nDone");
            Console.ReadKey();
        }

        private static void TestBfsMethods(List<UserNode> users)
        {
            BFS bfs = new BFS();
            bfs.VisitAllNodes(users);

            var user1 = users[0];
            var user2 = users[6];
            
            Console.WriteLine($"\nDistance between {user1} and {user2}:\n");
            Console.WriteLine(bfs.CalculateUsersDistance(user1, user2));

            var distance = 2;

            Console.WriteLine($"\n{user1}'s friends of friends at {distance} distance:\n");

            foreach (var friend in bfs.GetFriendsOfFriends(user1, distance))
            {
                Console.WriteLine(friend);
            }

            Console.WriteLine($"\nShortest paths between {user1} and {user2}:");
            var shortestPaths = bfs.GetShortestPaths(user1, user2);

            foreach (var path in shortestPaths)
            {
                Console.WriteLine("\nPath:\n");
                foreach (var user in path)
                {
                    Console.WriteLine(user);
                }
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
