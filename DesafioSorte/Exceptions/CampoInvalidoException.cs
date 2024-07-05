namespace DesafioSorte.Exceptions
{
    public class CampoInvalidoException : Exception
    {
        public CampoInvalidoException() { }
        public CampoInvalidoException(string message) : base(message) { }
    }
}
