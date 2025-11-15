using _03._Teamwork_Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Teamwork_Projects
{
    public class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; } = new List<string>();
    }

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] createInfo = Console.ReadLine().Split("-");
                string creator = createInfo[0];
                string teamName = createInfo[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team currentTeam = new Team(teamName, creator);
                    teams.Add(currentTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] userTeamInfo = input.Split("->");
                string member = userTeamInfo[0];
                string teamName = userTeamInfo[1];

                if (!teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(t => t.Members.Contains(member) || t.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                    Team teamToAddMember = teams.First(t => t.Name == teamName);
                    teamToAddMember.Members.Add(member);
                }

                input = Console.ReadLine();
            }

            var validTeams = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name);

            var disbandTeams = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name);

            foreach (var team in validTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in disbandTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}