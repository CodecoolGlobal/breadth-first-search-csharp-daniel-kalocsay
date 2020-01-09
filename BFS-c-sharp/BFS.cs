using System;
using System.Collections.Generic;
using System.Configuration;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    public class BFS
    {
        private List<UserNode> _users;

        public BFS(List<UserNode> users)
        {
            _users = users;
        }

        public void VisitAllNodes()
        {
            Console.WriteLine($"\nThere are {_users.Count} users in total.\n");
            
            var currentNode = _users[0];
            
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
            foreach (var node in visited)
            {
                Console.WriteLine(node);
            }
        }
    }
}