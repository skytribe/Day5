using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
 

    public class RandomChoice : Strategy
    {
        private static Random rng = new Random();


        public override StrategyChoice Start()
        {
            return (StrategyChoice)rng.Next(0, 2);
        }


        public override StrategyChoice Step(StrategyChoice inputChoice)
        {
            return (StrategyChoice)rng.Next(0, 2);
        }

    }
}
