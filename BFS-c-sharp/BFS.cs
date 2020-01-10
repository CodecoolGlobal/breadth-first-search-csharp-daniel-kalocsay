using System;
using System.Collections.Generic;
using System.Configuration;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    public class BFS
    {
        public int CalculateUsersDistance(UserNode user1, UserNode user2)
        {
            int distance = 0;
            var currentNode = user1;
            
            Queue<UserNode> toVisit = new Queue<UserNode>();
            List<UserNode> visited = new List<UserNode>();
            
            toVisit.Enqueue(currentNode);

            while (toVisit.Count > 0)
            {
                currentNode = toVisit.Peek();
                distance++;
                
                foreach (var neighbor in currentNode.Friends)
                {
                    if (neighbor == user2)
                    {
                        return distance;
                    }
                    if (!visited.Contains(neighbor) && !toVisit.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                    }
                }

                visited.Add(toVisit.Dequeue());
            }

            //TODO this might be wrong, thing is, i don't know how to test it yet
            return distance;
        }

        public void VisitAllNodes(List<UserNode> users)
        {
            Console.WriteLine($"\nThere are {users.Count} users in total.\n");
            
            var currentNode = users[0];
            
            Queue<UserNode> toVisit = new Queue<UserNode>();
            List<UserNode> visited = new List<UserNode>();
            
            toVisit.Enqueue(currentNode);

            while (toVisit.Count > 0)
            {
                currentNode = toVisit.Peek();
                
                foreach (var neighbor in currentNode.Friends)
                {
                    if (!visited.Contains(neighbor) && !toVisit.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                    }
                }

                visited.Add(toVisit.Dequeue());
            }

            Console.WriteLine($"\nVisited {visited.Count} users:\n");
            PrintUsers(visited);
        }

        private void PrintUsers(List<UserNode> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}