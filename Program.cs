// See https://aka.ms/new-console-template for more information
int tq = 0;
Console.WriteLine("digite seu nome");
string name = Console.ReadLine();
Console.WriteLine("Quantos brinquedos vc tem?");
tq = int.Parse(Console.ReadLine());
if(tq>30){
Console.WriteLine(name+" é Rico");
}else if(tq>15){
    Console.WriteLine(name+" é de Classe media");
}

else{
    Console.WriteLine(name+" é Pobre");
}
