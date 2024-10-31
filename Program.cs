

using System.Security.Cryptography.X509Certificates;

var trad = new List<Trad>();
trad.Add(new Trad
{
    Id = 1,
    Code = "R",
    Name = "Rock"
});
trad.Add(new Trad
{
    Id = 2,
    Code = "P",
    Name = "Paper"
});
trad.Add(new Trad
{
    Id = 3,
    Code = "S",
    Name = "Scissors"
});

Game();

async void Game()
{
    int counter = 0;
    int ywin = 0;
    int bwin = 0;
    List<Round> rounds = new List<Round>();


        Console.WriteLine("Rock Paper Scissors game R/P/S");
    while (true)
    {
        counter++;
        int bot = Random(1, 4);

        var fav = rounds
            .GroupBy(f => f.Player)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault();

        if (fav != null && fav.Count() > 0)
        {
            bot = fav.Key;
            bot = Convert(bot);
            //Console.WriteLine("ooooo " + fav.Key + " o " + bot);
        }

        Round round = new Round();
        string you = Console.ReadLine();  
        you = you.ToUpper();
        if (you != "R"|| you != "S"|| you != "P")
        {
            you = "R";
        }

        var youint = trad.Where(x => x.Code.Equals(you)).First();
        var botint = trad.Where(x => x.Id.Equals(bot)).First();

        Console.WriteLine("You: " + youint.Name + " VS " + " bot: " + botint.Name);
        round.Bot = botint.Id;
        round.Player = youint.Id;

        if ((youint.Id > bot && !(bot == 1 && youint.Id == 3)) || (youint.Id == 1 && bot == 3))
        {
            Console.WriteLine("+1 point");
            ywin++;
            round.PlayerWin = true;
        }
        if (bot > youint.Id || (bot == 1 && youint.Id == 3))
        {
            Console.WriteLine("-1point");
            bwin++;
            round.PlayerWin = false;
        }
        else if (youint.Id == bot)
        {
            Console.WriteLine("draw");
            ywin++;
            bwin++;
        }
        rounds.Add(round);
        if (counter >= 30)
        {
            if (ywin > bwin)
            {
                Console.WriteLine("YOU WON! " + bwin + "/" + ywin);
            }
            else
            {
                Console.WriteLine("bot won hahaha " + bwin + "/" + ywin);
            }
            break;
        }
    }

    foreach (var round in rounds)
    {
        Console.WriteLine(round.Player);
        Console.WriteLine(round.Bot);
        Console.WriteLine(round.PlayerWin);
    }

    static int Convert(int i)
    { int result = 0;
        if (i == 1)
        {
            result = 2;
        }if(i == 2)
        {
            result = 3;
        }if(i == 3)
        {
            result = 1;
        }
        return result;
    }
    static int Random(int start = 1, int end = 10)
    {
        Random randNum = new Random();
        return randNum.Next(start, end);
    }
}


class Trad
{
    public int Id;
    public string Code;
    public string Name;
};
class Round
{
    public int Bot { get; set; }
    public int Player { get; set; }
    public bool PlayerWin { get; set; }
}
