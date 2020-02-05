using System;
using System.Collections.Generic;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    public class RandomDataGenerator
    {
        private Random rng = new Random(1234);
        private String[] firstNames = {
            "Inez", "Emery", "Virginia", "Charissa", "Tyrone", "Ayanna", "Jena", "Ora",
            "Cooper", "Gareth", "Karleigh", "Aladdin", "Arden", "Pearl", "Mariko", "Hadley",
            "Tanya", "Madeline", "Naomi", "Maggie", "Kerry", "Elmo", "Wylie", "Alec",
            "Axel", "Belle", "Cally", "Theodore", "Emmanuel", "Christopher", "Olympia"};

        private String[] lastNames =  {
            "Winifred", "Tanner", "Rajah", "Cedric", "Tyler", "Nicholas", "Abra", "Aurora",
            "Bryar", "Kibo", "Myles", "Hillary", "Lydia", "Dolan", "Lucian", "Prescott"
        };

        public List<UserNode> Generate()
        {
            List<UserNode> users = new List<UserNode>();
            UserNode firstUser = GenerateNewUser();
            users.Add(firstUser);
            
            // first generate and connect users in a star shaped tree
            GenerateTree(firstUser, users, 4);

            for (int i = 0; i < users.Count - 30; i++)
            {
                if (i % 5 == 0)
                {
                    var friendUser = users[i + 30];
                    users[i].AddFriend(friendUser);
                }
            }

            return users;
        }

        private void GenerateTree(UserNode user, List<UserNode> allUsers, int depth)
        {
            if (depth == 0)
            {
                return;
            }
            for (int i = 0; i < depth; i++)
            {
                UserNode newUser = GenerateNewUser();
                user.AddFriend(newUser);
                allUsers.Add(newUser);
                GenerateTree(newUser, allUsers, depth - 1);
            }
        }

        public List<UserNode> GenerateCustomTree()
        {
            List<UserNode> users = new List<UserNode>();
            var userA = new UserNode
            {
                FirstName = "A",
                LastName = "0",
                Id = 0
            };
            var userB = new UserNode
            {
                FirstName = "B",
                LastName = "1",
                Id = 1
            };
            var userC = new UserNode
            {
                FirstName = "C",
                LastName = "2",
                Id = 2
            };
            var userD = new UserNode
            {
                FirstName = "D",
                LastName = "4",
                Id = 4
            };
            var userE = new UserNode
            {
                FirstName = "E",
                LastName = "5",
                Id = 5
            };
            var userF = new UserNode
            {
                FirstName = "F",
                LastName = "6",
                Id = 6
            };
            var userG = new UserNode
            {
                FirstName = "G",
                LastName = "7",
                Id = 7
            };
            var userH = new UserNode
            {
                FirstName = "H",
                LastName = "8",
                Id = 8
            };
            var userI = new UserNode
            {
                FirstName = "I",
                LastName = "9",
                Id = 9
            };
            
            userA.AddFriends(new List<UserNode>{userB, userC, userD, userH});
            userB.AddFriend(userA);
            userC.AddFriend(userA);
            userD.AddFriends(new List<UserNode>{userA, userF, userE, userG});
            userE.AddFriends(new List<UserNode>{userD, userG});
            userF.AddFriend(userD);
            userG.AddFriends(new List<UserNode>{userD, userE, userH, userI});
            userG.AddFriends(new List<UserNode>{userA, userG});
            userI.AddFriend(userG);
            
            users.AddRange(new List<UserNode>{userA, userB, userC, userD, userE, userF, userG, userH, userI});
            
            return users;
        }

        private UserNode GenerateNewUser()
        {
            return new UserNode(GetRandomElement(firstNames), GetRandomElement(lastNames));
        }

        private string GetRandomElement(string[] array)
        {
            return array[rng.Next(array.Length)];
        }        
    }
}