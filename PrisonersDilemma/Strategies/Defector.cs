using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
    public class Defector : Strategy
    {

        public override StrategyChoice Start()
        {
            return StrategyChoice.Defect;
        }

        public override StrategyChoice Step(StrategyChoice inputChoice)
        {
            return StrategyChoice.Defect;
        }
    }

}
