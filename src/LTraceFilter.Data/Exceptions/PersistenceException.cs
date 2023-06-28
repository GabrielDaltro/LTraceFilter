namespace LTraceFilter.Business.Application
{
    public class PersistenceException : Exception
    {
        public PersistenceException() { }

        public PersistenceException(string message) : base(message) { }
        
        public PersistenceException(string message, Exception e) : base(message, e) { }
    }
}