namespace PrismaWEB.Utils.Exception
{
    using System;

    public class EntidadeException : Exception
    {
        public EntidadeException()
            : base()
        {
        }

        public EntidadeException(string message)
            : base(message)
        {
        }

        public EntidadeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public EntidadeException(string message, string nomeCampo)
            : this(message)
        {
            NomeCampo = nomeCampo;
        }

        public readonly string NomeCampo = "";
    }
}
