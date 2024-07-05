namespace DesafioSorte.Exceptions
{
    public class EmailCadastradoException : Exception
    {
        public EmailCadastradoException() { }
        public EmailCadastradoException(string message) : base(message) { }
    }
}