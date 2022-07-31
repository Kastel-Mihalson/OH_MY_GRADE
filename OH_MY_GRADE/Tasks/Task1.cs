using OH_MY_GRADE;

public class Task1
{
    public void Example()
    {
        const int FOOTBALLER_COUNT = 11;
        var team = new FootballTeam(FOOTBALLER_COUNT);

        for (int i = 0; i < FOOTBALLER_COUNT; i++)
        {
            team[i] = new Footballer { Name = $"Some {i}", Number = new Random().Next(1, 100) };
        }

        team[25] = new Footballer { Name = $"Some 25", Number = new Random().Next(1, 100) };

        Console.WriteLine($"Name: {team[2].Name} Number: {team[2].Number}");
        Console.WriteLine($"Name: {team[25].Name} Number: {team[25].Number}");
    }
}
