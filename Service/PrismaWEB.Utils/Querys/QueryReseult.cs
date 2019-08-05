using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismaWEB.Utils.Querys
{
    public class QueryReseult
    {
        private IList<Field> _campos;

        public IList<Field> Campos { get => new ReadOnlyCollection<Field>(_campos); }

        public QueryReseult()
        {
            _campos = new List<Field>();
        }

        public void AdicionarCampo(object campo, string NomeCampo)
        {
            _campos.Add(new Field(NomeCampo, campo));
        }

        public Field Get(string nomeCampo)
        {
            var campo = Campos.Where(c => c.Key == nomeCampo).FirstOrDefault();
            if (campo == null)
                throw new NullReferenceException($"Não foi encontrado um campo com o nome: {nomeCampo}");
            return campo;
        }

        public Field this[string nomeCampo]
        {
            get
            {
                return Get(nomeCampo);
            }
        }

        public Field this[int indice]
        {
            get
            {
                return Campos[indice];
            }
        }
    }
}
