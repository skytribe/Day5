using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
    public enum StrategyChoice
    {
        Cooperate,
        Defect
    }

    public interface IPDStrategy
    {
        string Name { get; set; }
        StrategyChoice Start();
        StrategyChoice Step(StrategyChoice inputChoice);
    }
 
    /// <summary>
    /// Each strategy will implement the IPDStrategy Interfaces
    /// This is used when creating prisoners to ensure that they are using a class which supports
    /// these members.
    /// </summary>
    public abstract class Strategy : IPDStrategy
    {
        public string Name { get; set; }

        public abstract StrategyChoice Start();
        public abstract StrategyChoice Step(StrategyChoice inputChoice);
    }


}
