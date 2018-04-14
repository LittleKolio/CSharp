namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder(IDictionary<Type, IGarbageDisposalStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (!this.GetDisposalStrategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Add(disposableAttribute, strategy);
                return true;
            }

            return false;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (this.GetDisposalStrategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);
                return true;
            }

            return false;
        }
    }
}
