using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_14_2019_Code
{
    public class EquationSolver
    {
        private readonly Dictionary<string, IEquation> _equations;
        private readonly Dictionary<string, long> _surplus = new Dictionary<string, long>();
        private Dictionary<string, long> _consumedChemicals = new Dictionary<string, long>();

        public EquationSolver(Dictionary<string, IEquation> equations)
        {
            _equations = equations;
            _surplus = new Dictionary<string, long>();
            foreach (var equation in equations)
            {
                _surplus[equation.Key] = 0;
            }

            _surplus["ORE"] = 0;
        }


        public bool Produce(string chemical, long quantity)
        {
            if (chemical == "ORE")
            {
                _consumedChemicals![chemical] += quantity;
                return false;
            }

            var reaction = _equations[chemical];
            var reactionCount = (long) Math.Ceiling((double) quantity / reaction.Output.Amount);

            foreach (var reactant in reaction.Inputs)
            {
                if (!Consume(reactant.Unit, reactionCount * reactant.Amount))
                {
                    return false;
                }
            }

            _surplus[chemical] = _surplus[chemical] + reactionCount * reaction.Output.Amount;

            return true;
        }

        public bool Consume(string chemical, long quantity)
        {
            if (chemical == "ORE")
            {
                if (_consumedChemicals.ContainsKey(chemical))
                {
                    _consumedChemicals[chemical] += quantity;
                }
                else
                {
                    _consumedChemicals.Add(chemical, quantity);
                }

                return true;
            }

            if (!_surplus!.ContainsKey(chemical))
            {
                _surplus[chemical] = 0;
            }

            if (_surplus[chemical] < quantity)
            {
                if (!Produce(chemical, quantity - _surplus[chemical]))
                {
                    return false;
                }
            }

            if (_consumedChemicals!.ContainsKey(chemical))
            {
                _consumedChemicals![chemical] += quantity;
            }
            else
            {
                _consumedChemicals![chemical] = quantity;
            }

            _surplus[chemical] -= quantity;

            return true;
        }


        public long GetSurplus(string key)
        {
            return _surplus[key];
        }

        public long GetConsumedChemicals(string key)
        {
            return _consumedChemicals[key];
        }

        public void ResetConsumedChemicals()
        {
            _consumedChemicals = new Dictionary<string, long>();
        }

        public void ResetSurplus()
        {
            _consumedChemicals = new Dictionary<string, long>();
        }

        public void Reset()
        {
            ResetConsumedChemicals();
            ResetSurplus();
        }

        // e.g. Fuel , 1
        public long GetRequiredOre(IEquation chemicalReaction, long amount)
        {
            checked
            {
                long sum = 0;
                var existingSurplus = _surplus.ContainsKey(chemicalReaction.Output.Unit)
                    ? _surplus[chemicalReaction.Output.Unit]
                    : 0;

                for (; existingSurplus < amount; existingSurplus += chemicalReaction.Output.Amount)
                {
                    sum += chemicalReaction.Inputs
                        .Select(c => c.Unit == "ORE" ? c.Amount : GetRequiredOre(_equations[c.Unit], c.Amount)).Sum();
                }

                _surplus[chemicalReaction.Output.Unit] = existingSurplus - amount;

                return sum;
            }
        }

        public long CalculateFuelFromOre(long targetOre)
        {
            var startFuel = targetOre / 2;
            long ore = 0;
            long fuel = startFuel, increment = startFuel;

            while (true)
            {
                var previousOre = ore;
                Reset();
                var res = Consume("FUEL", fuel);
                ore = GetConsumedChemicals("ORE");

                if (previousOre >= targetOre && ore <= targetOre && increment == 1)
                {
                    break;
                }

                if (ore < targetOre)
                {
                    if (ore - previousOre > previousOre)
                    {
                        increment *= 2;
                    }

                    fuel += increment;
                }
                else
                {
                    increment = (long) Math.Round(Convert.ToDouble(increment / 2), MidpointRounding.AwayFromZero);
                    if (increment <= 0)
                    {
                        increment = 1;
                    }

                    fuel -= increment;
                }
            }


            return fuel;
        }
    }
}