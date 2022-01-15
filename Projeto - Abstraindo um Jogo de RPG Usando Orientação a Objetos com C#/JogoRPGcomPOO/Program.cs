using JogoRPGcomPOO.src.Entities;
using static System.Console;

namespace JogoRPGcomPOO.src.Entities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Knight arus = new("Arus", 23, "Knight", 749, 72);
            Ninja wedge = new("Wedge", 23, "Ninja", 574, 89);
            Wizard wizard = new("Jenica", 23, "White Wizard", 601, 482);
            BlackWizard topapa = new("Topapa", 23, "Black Wizard", 385, 641);


            WriteLine($@"Ataque da(o) {arus.Name}");
            WriteLine($@"{arus.Attack()}");
            WriteLine($@"{arus.Attack(4)}");
            WriteLine($@"{arus.Attack(6)}");
            WriteLine($@"{arus.Attack(10)}");
            WriteLine("");
            
            WriteLine($@"Ataque da(o) {wizard.Name}");
            WriteLine($@"{wizard.Attack()}");
            WriteLine($@"{wizard.Attack(4)}");
            WriteLine($@"{wizard.Attack(6)}");
            WriteLine($@"{wizard.Attack(10)}");
            WriteLine("");
            
            WriteLine($@"Ataque da(o) {wedge.Name}");
            WriteLine($@"{wedge.Attack()}");
            WriteLine($@"{wedge.Attack(4)}");
            WriteLine($@"{wedge.Attack(6)}");
            WriteLine($@"{wedge.Attack(10)}");
            WriteLine("");

            WriteLine($@"Ataque da(o) {topapa.Name}");
            WriteLine($@"{topapa.Attack()}");
            WriteLine($@"{topapa.Attack(4)}");
            WriteLine($@"{topapa.Attack(6)}");
            WriteLine($@"{topapa.Attack(10)}");
            WriteLine("");

            
        }
    }
}   