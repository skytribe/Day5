using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
   class Program { 
    static void Main(string[] args) { 
      RunPrisonersDilemma(); 
      Console.WriteLine("Press ENTER to exit."); 
      Console.ReadLine(); 
     } 
 

     private static void RunPrisonersDilemma() {

         // Various Presets to cut and paste to test certain conditions
         //new Prisoner("Cooperator", new Cooperator()); 
         //new Prisoner("Defector", new Defector()); 
         //new Prisoner("titfortat", new TitForTat()); 
         //new Prisoner("RNG", new RandomChoice()); 
         //new Prisoner("untitfortate", new UnTitForTat()); 

         //Setup both prisoners for the game.
       var prisoner1 = new Prisoner("Random", new RandomChoice()); 
       var prisoner2 = new Prisoner("untitfortate", new UnTitForTat());
       int iterations = 10;

       var pd = new Game(prisoner1, prisoner2);  
       Console.WriteLine(string.Format("Prisoner1: {0}  Prisoner2: {1}", prisoner1.Name, prisoner2.Name)); 
 
       // How many iterations are we going to step through for this game
       for (int i = 1; i < iterations; i++) { 
         Console.WriteLine(pd.Step()); 
       } 
     } 
   } 

}
