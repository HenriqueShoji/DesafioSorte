namespace DesafioSorte.Exceptions
{
    public class ClienteNaoCadastradoException : Exception
    {
        public ClienteNaoCadastradoException() { }
        public ClienteNaoCadastradoException(string message) : base(message) { }
    }
}
