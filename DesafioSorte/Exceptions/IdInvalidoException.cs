namespace DesafioSorte.Exceptions
{
    public class IdInvalidoException : Exception
    {
        public IdInvalidoException() { }
        public IdInvalidoException(string message) : base(message) { }
    }
}
