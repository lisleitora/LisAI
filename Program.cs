

using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

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
    FunCode(Code.Welcome);
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
        if (you != "R" && you != "S" && you != "P")
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
        if (counter >= 10)
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
    {
        int result = 0;
        if (i == 1)
        {
            result = 2;
        }
        if (i == 2)
        {
            result = 3;
        }
        if (i == 3)
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

    static void FunCode(Code i)
    {
        if(i == Code.Lose)
        {
            Console.Write(@"
▓██   ██▓ ▒█████   █    ██     ██▓     ▒█████    ██████ ▄▄▄█████▓
 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▓██▒    ▒██▒  ██▒▒██    ▒ ▓  ██▒ ▓▒
  ▒██ ██░▒██░  ██▒▓██  ▒██░   ▒██░    ▒██░  ██▒░ ▓██▄   ▒ ▓██░ ▒░
  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ▒██░    ▒██   ██░  ▒   ██▒░ ▓██▓ ░ 
  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░██████▒░ ████▓▒░▒██████▒▒  ▒██▒ ░ 
   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒    ░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░  ▒ ░░   
 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░    ░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░    ░    
 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░      ░ ░   ░ ░ ░ ▒  ░  ░  ░    ░      
 ░ ░         ░ ░     ░            ░  ░    ░ ░        ░           
 ░ ░                                                             
");
        }
        if(i == Code.Win){
            Console.Write(@"
░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░  
░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
 ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
   ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
   ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
   ░▒▓█▓▒░    ░▒▓██████▓▒░ ░▒▓██████▓▒░        ░▒▓█████████████▓▒░ ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░ 
                                                                                              
                                                                                              
");
        }
        if(i == Code.PxP){
            Console.Write(@"
 _____  _____  _____  _____  _____    __  __    _____  _____  _____  _____  _____ 
/  _  \/  _  \/  _  \/   __\/  _  \  /  \/  \  /  _  \/  _  \/  _  \/   __\/  _  \
|   __/|  _  ||   __/|   __||  _  <  >-    -<  |   __/|  _  ||   __/|   __||  _  <
\__/   \__|__/\__/   \_____/\__|\_/  \__/\__/  \__/   \__|__/\__/   \_____/\__|\_/
                                                                                  
");
        }
        if(i == Code.SxS){
            Console.Write(@"
 _____  _____  ___  _____  _____  _____  _____    __  __    _____  _____  ___  _____  _____  _____  _____ 
/  ___>/     \/___\/  ___>/  ___>/  _  \/  _  \  /  \/  \  /  ___>/     \/___\/  ___>/  ___>/  _  \/  _  \
|___  ||  |--||   ||___  ||___  ||  |  ||  _  <  >-    -<  |___  ||  |--||   ||___  ||___  ||  |  ||  _  <
<_____/\_____/\___/<_____/<_____/\_____/\__|\_/  \__/\__/  <_____/\_____/\___/<_____/<_____/\_____/\__|\_/
                                                                                                          
");
        }if(i == Code.RxR){
            Console.Write(@"
 _____  _____  _____  __ ___   __  __    _____  _____  _____  __ ___
/  _  \/  _  \/     \|  |  /  /  \/  \  /  _  \/  _  \/     \|  |  /
|  _  <|  |  ||  |--||  _ <   >-    -<  |  _  <|  |  ||  |--||  _ < 
\__|\_/\_____/\_____/|__|__\  \__/\__/  \__|\_/\_____/\_____/|__|__\
                                                                    
");
        }if(i == Code.PxR){
            Console.Write(@"
 _____  _____  _____  _____  _____    __  __    _____  _____  _____  __ ___
/  _  \/  _  \/  _  \/   __\/  _  \  /  \/  \  /  _  \/  _  \/     \|  |  /
|   __/|  _  ||   __/|   __||  _  <  >-    -<  |  _  <|  |  ||  |--||  _ < 
\__/   \__|__/\__/   \_____/\__|\_/  \__/\__/  \__|\_/\_____/\_____/|__|__\
                                                                           
");
        }if(i == Code.PxS){
            Console.Write(@"
 _____  _____  _____  _____  _____    __  __    _____  _____  ___  _____  _____  _____  _____  _____ 
/  _  \/  _  \/  _  \/   __\/  _  \  /  \/  \  /  ___>/     \/___\/  ___>/  ___>/  _  \/  _  \/  ___>
|   __/|  _  ||   __/|   __||  _  <  >-    -<  |___  ||  |--||   ||___  ||___  ||  |  ||  _  <|___  |
\__/   \__|__/\__/   \_____/\__|\_/  \__/\__/  <_____/\_____/\___/<_____/<_____/\_____/\__|\_/<_____/
                                                                                                     
");
        }if(i == Code.SxP){
            Console.Write(@"
 _____  _____  ___  _____  _____  _____  _____  _____    __  __    _____  _____  _____  _____  _____ 
/  ___>/     \/___\/  ___>/  ___>/  _  \/  _  \/  ___>  /  \/  \  /  _  \/  _  \/  _  \/   __\/  _  \
|___  ||  |--||   ||___  ||___  ||  |  ||  _  <|___  |  >-    -<  |   __/|  _  ||   __/|   __||  _  <
<_____/\_____/\___/<_____/<_____/\_____/\__|\_/<_____/  \__/\__/  \__/   \__|__/\__/   \_____/\__|\_/
                                                                                                     
");
        }if(i == Code.RxP){
            Console.Write(@"
 _____  _____  _____  __ ___   __  __    _____  _____  _____  _____  _____ 
/  _  \/  _  \/     \|  |  /  /  \/  \  /  _  \/  _  \/  _  \/   __\/  _  \
|  _  <|  |  ||  |--||  _ <   >-    -<  |   __/|  _  ||   __/|   __||  _  <
\__|\_/\_____/\_____/|__|__\  \__/\__/  \__/   \__|__/\__/   \_____/\__|\_/
                                                                           
");
        }if(i == Code.RxS){
            Console.Write(@"
 _____  _____  _____  __ ___   __  __    _____  _____  ___  _____  _____  _____  _____  _____ 
/  _  \/  _  \/     \|  |  /  /  \/  \  /  ___>/     \/___\/  ___>/  ___>/  _  \/  _  \/  ___>
|  _  <|  |  ||  |--||  _ <   >-    -<  |___  ||  |--||   ||___  ||___  ||  |  ||  _  <|___  |
\__|\_/\_____/\_____/|__|__\  \__/\__/  <_____/\_____/\___/<_____/<_____/\_____/\__|\_/<_____/
                                                                                              
");
        }if(i == Code.SxR){
            Console.Write(@"
 _____  _____  ___  _____  _____  _____  _____  _____    __  __    _____  _____  _____  __ ___
/  ___>/     \/___\/  ___>/  ___>/  _  \/  _  \/  ___>  /  \/  \  /  _  \/  _  \/     \|  |  /
|___  ||  |--||   ||___  ||___  ||  |  ||  _  <|___  |  >-    -<  |  _  <|  |  ||  |--||  _ < 
<_____/\_____/\___/<_____/<_____/\_____/\__|\_/<_____/  \__/\__/  \__|\_/\_____/\_____/|__|__\
                                                                                              
");
        }if(i == Code.Welcome){
            Console.Write(@"
ooooooooo.                         ooooooooo.                          .oooooo..o 
`888   `Y88.                       `888   `Y88.                       d8P'    `Y8 
 888   .d88'      oooo    ooo       888   .d88'      oooo    ooo      Y88bo.      
 888ooo88P'        `88b..8P'        888ooo88P'        `88b..8P'        `Y8888o.  
 888`88b.            Y888'          888                 Y888'              `Y88b 
 888  `88b.        .o8''88b         888               .o8''88b        oo     .d8P 
o888o  o888o      o88'   888o      o888o             o88'   888o      8''88888P'  
                                                                                  
                                                                                  
                                                                                  
");
        }


    }

}


enum Code
{
    Welcome,
    Lose,
    Win,
    SxS,
    PxS,
    SxP,
    SxR,
    RxS,
    RxR,
    PxR,
    RxP,
    PxP

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
