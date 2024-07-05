namespace DesafioSorte.Exceptions
{
    public class IdNaoEncontradoException : Exception
    {
        public IdNaoEncontradoException() { }
        public IdNaoEncontradoException(string message) : base(message) { }
    }
}
