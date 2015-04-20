using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{


    public class UnTitForTat : Strategy
    {
        public override StrategyChoice Start()
        {
            return StrategyChoice.Cooperate;
        }

        public override StrategyChoice Step(StrategyChoice inputChoice)
        {
            var retValue = StrategyChoice.Cooperate;

            if (inputChoice == StrategyChoice.Cooperate)
                retValue = StrategyChoice.Defect;

            return retValue;
        }
    }
}
