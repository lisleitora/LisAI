// See https://aka.ms/new-console-template for more information

//Q1();
using System.Diagnostics.Metrics;

static int Random(int start = 1, int end = 10)
{
    Random randNum = new Random();
    return randNum.Next(start, end);
}

var trad = new List<Trad>();
trad.Add(new Trad{
    Id = 1,
    Code = "R",
    Name = "Rock"
});
trad.Add(new Trad{
    Id = 2,
    Code = "P",
    Name = "Paper"
});
trad.Add(new Trad{
    Id = 3,
    Code = "S",
    Name = "Scissors"
});

Game();
async void Q1()
{
    while (true)
    {
        int tq = 0;
        Console.WriteLine("digite seu nome");
        string name = Console.ReadLine();
        Console.WriteLine("Quantos brinquedos vc tem?");
        tq = int.Parse(Console.ReadLine());
        if (tq > 30)
        {
            Console.WriteLine(name + " é Rico");
        }
        else if (tq > 15)
        {
            Console.WriteLine(name + " é de Classe media");
        }

        else
        {
            Console.WriteLine(name + " é Pobre");
        }
        Console.WriteLine("quer sair? Y/N");
        string exit = Console.ReadLine();
        if (exit == "Y")
        {
            Environment.Exit(0);
        }
    }
}

async void Game()
{
    int counter = 0;
    int ywin = 0;
    int bwin = 0;
    while (true)
    {
        counter++;
        int bot = Random(1, 4);
        Console.WriteLine("Rock Paper Scissors game R/P/S");
        string you = Console.ReadLine();
        you = you.ToUpper();
        var youint = trad.Where(x => x.Code.Equals(you)).First();
        var botint = trad.Where(x => x.Id.Equals(bot)).First();
        Console.WriteLine("You played " + youint.Name + " and bot played " + botint.Name);
        if ((youint.Id > bot && !(bot==1&&youint.Id==3)) || (youint.Id== 1&& bot==3)){
                        Console.WriteLine("+1 point");
                    ywin++;
        }if(bot > youint.Id || (bot==1&&youint.Id==3)){
            Console.WriteLine("-1point");
            bwin++;
        }else if (youint.Id == bot)
        {
            Console.WriteLine("draw");
            ywin++;
            bwin++;
        }

        if (counter >= 3)
        {
            if (ywin > bwin)
            {
                Console.WriteLine("YOU WON! "+bwin+"/"+ywin);
            }
            else
            {
                Console.WriteLine("bot won hahaha "+bwin+"/"+ywin);
            }
            Environment.Exit(0);
        }
    }
}
class Trad{
    public int Id;
    public string Code;
    public string Name; 
};