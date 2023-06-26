namespace LTraceFilter.Business.Domain
{
    internal class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message) { }

        public DomainException(string message, Exception e) : base(message, e) { }
    }
}
