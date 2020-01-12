using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    public class BFS
    {
        public List<List<UserNode>> GetShortestPaths(UserNode user1, UserNode user2)
        {
            int maxDistance = 0;
            int currentDistance = 0;
            var currentNode = user1;
            
            Queue<UserNode> toVisit = new Queue<UserNode>();
            List<UserNode> visited = new List<UserNode>();
            List<List<UserNode>> shortestPaths = new List<List<UserNode>>();
            
            toVisit.Enqueue(currentNode);

            while (toVisit.Count > 0)
            {
                currentNode = toVisit.Peek();
                var currentPath = new List<UserNode>{user1};
                
                foreach (var neighbor in currentNode.Friends)
                {
                    currentPath.Add(neighbor);
                    
                    if (neighbor == user2)
                    {
                        if (IsNewPathTheShortest(shortestPaths, currentDistance))
                        {
                            shortestPaths.Clear();
                        }
                        
                        shortestPaths.Add(currentPath);
                        
                    }
                    if (!visited.Contains(neighbor) && !toVisit.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                    }
                }

                visited.Add(toVisit.Dequeue());
            }

            return shortestPaths;
        }

        public bool IsNewPathTheShortest(List<List<UserNode>> paths, int length)
        {
            foreach (var path in paths)
            {
                if (path.Count > length) return true;
            }
            return false;
        }
        public List<UserNode> GetFriendsOfFriends(UserNode user, int distance)
        {
            HashSet<UserNode> friendsOfFriends = new HashSet<UserNode>();

            var currentNode = user;
            Queue<UserNode> toVisit = new Queue<UserNode>();
            
            toVisit.Enqueue(currentNode);

            while (distance > 0)
            {
                currentNode = toVisit.Peek();
                distance--;
                
                foreach (var neighbor in currentNode.Friends)
                {
                    if (!friendsOfFriends.Contains(neighbor) && !toVisit.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                    }
                }

                friendsOfFriends.Add(toVisit.Dequeue());
            }

            friendsOfFriends.Remove(user);
            return friendsOfFriends.ToList();
        }
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