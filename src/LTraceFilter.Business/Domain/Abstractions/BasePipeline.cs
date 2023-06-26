namespace LTraceFilter.Business.Domain.Abstractions
{
    internal abstract class BasePipeline<T> : IPipeline<T>
    {
        private readonly List<IFilter<T>> filters;

        protected BasePipeline(List<IFilter<T>> filters)
        {
            this.filters = filters;
        }

        protected void Add(IFilter<T> filter)
        {
            filters.Add(filter);
        }

        protected void Remove(IFilter<T> filter)
        {
            filters.Remove(filter);
        }

        public virtual T[] Apply(T[] inputSignal)
        {
            T[] result = inputSignal;

            foreach (var filter in filters)
            {
                result = filter.Apply(result);
            }

            return result;
        }
    }
}