﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
    public class Cooperator : Strategy
    {
        public override StrategyChoice Start()
        {
            return StrategyChoice.Cooperate;
        }

        public override StrategyChoice Step(StrategyChoice inputChoice)
        {
            return StrategyChoice.Cooperate;
        }
    }

}
