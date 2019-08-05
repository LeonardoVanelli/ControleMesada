namespace PrismaWEB.Utils.Exception
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    public class ListEntidadeException : Exception
    {
        public ListEntidadeException()
        {
            exceptions = new List<EntidadeException>();
        }

        public void AdicionarException(string nomeCampo, string MensagemErro)
        {
            exceptions.Add(new EntidadeException(MensagemErro, nomeCampo));            
        }        

        public bool TemErro
        {
            get { return exceptions.Count > 0; }
        }


        private IList<EntidadeException> exceptions;

        public IList<EntidadeException> Exceptions
        {
            get
            {
                return new ReadOnlyCollection<EntidadeException>(exceptions);
            }
        }


    }
}
