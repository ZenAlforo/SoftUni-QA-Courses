namespace _3._TeamWork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>(); 
            int count = int.Parse(Console.ReadLine());
            string userDetails = Console.ReadLine();

            while (userDetails != "end of assignment")
            {
                if (userDetails.Contains(">")) 
                {
                    string[] teamCreation = userDetails.Split("->");
                    string newMember = teamCreation[0];
                    string teamToJoin = teamCreation[1];
                    
                    if (!teams.ContainsKey(team)) {
                        Console.WriteLine($"Team {team} does not exist!");
                    } else
                    {
                        if (teams.ContainsKey(member))
                        {

                        }
                    }


                } else
                {
                    string[] teamCreation = userDetails.Split("-");
                    string creator = teamCreation[0];
                    string team = teamCreation[1];
                    if (!teams.ContainsKey(creator))
                    {
                        Team currentTeam = new Team(creator, team);
                        Console.WriteLine($"Team {team} has been created by {creator}!");
                    } else
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                    }
                    
                    
                }

            }
        }

        class Team
        {
            public Team(string creator, string teamName, List<string> member)
            {
                Creator = creator;
                TeamName = teamName;
                Members = member;
            }

            public Team(string creator, string teamName)
            {
                Creator = creator;
                TeamName = teamName;
                
            }

            public Team(List<string> member)
            {
                Members = member;
            }

            public string Creator { get; set; }
            public string TeamName { get; set; }
            public List<string> Members { get; set; }

            public void AddMember(string member)
            {
                Members.Add(member);
            }
        }
    }
}
