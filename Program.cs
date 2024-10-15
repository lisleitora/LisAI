// See https://aka.ms/new-console-template for more information

//Q1();
using System.Diagnostics.Metrics;
static int Random(int start = 1, int end = 10)
{
    Random randNum = new Random();
    return randNum.Next(start, end);
}
var trad = new Dictionary<int, string>();
trad.Add(1, "R");
trad.Add(2, "P");
trad.Add(3, "S");

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
        var youint = trad.Where(x => x.Value.Equals(you)).First().Key;
        if (youint > bot || youint== 1&& bot==3){
                        Console.WriteLine("+1 point");
                    ywin++;
        }else if(bot > youint || bot==1&&youint==3){
            Console.WriteLine("-1point");
            bwin++;
        }else if (youint == bot)
        {
            Console.WriteLine("draw");
            ywin++;
            bwin++;
        }

        if (counter >= 3)
        {
            if (ywin > bwin)
            {
                Console.WriteLine("you won");
            }
            else
            {
                Console.WriteLine("bot won hahaha");
            }
            Environment.Exit(0);
        }
    }
}