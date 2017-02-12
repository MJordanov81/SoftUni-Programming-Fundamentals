using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamworkProjects
{
    public class Team
    {
        public string Name { get; set; }
        public string CreatorName { get; set;}
        public List<string> Members { get; set; }
    }
    public class TeamworkProjects
    {
        public static void Main()
        {
            var teamList = new Dictionary<string, Team>();
            var commentsList = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split('-');

                var currentTeam = new Team
                {
                    Name = input[1],
                    CreatorName = input[0],
                    Members = new List<string>()
                };

                if (!teamList.ContainsKey(currentTeam.Name))
                {
                    bool isNewCreator = true;

                    foreach (var item in teamList.Values)
                    {
                        if (item.CreatorName == currentTeam.CreatorName)
                        {
                            isNewCreator = false;
                        }
                    }

                    if (isNewCreator)
                    {
                        teamList[currentTeam.Name] = currentTeam;
                        commentsList.Add("Team " + currentTeam.Name + " has been created by " + currentTeam.CreatorName + "!");
                    }
                    else
                    {
                        commentsList.Add(currentTeam.CreatorName + " cannot create another team!");
                    }
                }

                else
                {
                    commentsList.Add("Team " + currentTeam.Name + " was already created!");
                }
            }

            var inputMember = Console.ReadLine();

            while (inputMember != "end of assignment")
            {
                var member = inputMember.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                var currentMember = member[0];
                var currentTeam = member[1];

                bool existsTeam = false;
                bool isAlreadyTeamMember = false;

                foreach (var team in teamList.Values)
                {
                    if (team.Name == currentTeam)
                    {
                        existsTeam = true;
                        break;
                    }
                }

                foreach (var team in teamList.Values)
                {
                    if (team.CreatorName == currentMember)
                    {
                        isAlreadyTeamMember = true;
                        break;
                    }

                    foreach (var memberName in team.Members)
                    {
                        if (memberName == currentMember)
                        {
                            isAlreadyTeamMember = true;
                            break;
                        }
                    }
                }

                if (!existsTeam)
                {
                    commentsList.Add("Team " + currentTeam + " does not exist!");
                }

                else if (isAlreadyTeamMember)
                {
                    commentsList.Add("Member " + currentMember + " cannot join team " + currentTeam + "!");
                }

                else
                {
                    teamList[currentTeam].Members.Add(currentMember);
                }

                inputMember = Console.ReadLine();

            }

            foreach (var comment in commentsList)
            {
                Console.WriteLine(comment);
            }

            teamList = teamList
                .OrderByDescending(x => x.Value.Members.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var team in teamList.Values.Where(x => x.Members.Count > 0))
            {
                    Console.WriteLine(team.Name);
                    Console.WriteLine("- {0}", team.CreatorName);
                    
                    foreach (var member in team.Members.OrderBy(x => x).ToList())
                    {
                        Console.WriteLine("-- {0}", member);
                }             
            }

            Console.WriteLine("Teams to disband:");

            teamList.Values
                .Where(x => x.Members.Count == 0)
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
