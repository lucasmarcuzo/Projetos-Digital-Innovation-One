using System;

namespace ExemploApiCatalogoJogos.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException()
            : base("O Jogo já foi cadastrado")
        { }

        public JogoJaCadastradoException(string message) : base(message)
        {
        }

        public JogoJaCadastradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
