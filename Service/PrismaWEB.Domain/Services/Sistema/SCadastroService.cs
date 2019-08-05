using PrismaWEB.Utils.Attributes;
using PrismaWEB.Utils.Exception;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Utils;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SCadastroService : ServiceBase<SCadastro>, ISCadastroService
    {
        private readonly ISCadastroRepository _SCadastroRepository;

        public SCadastroService(ISCadastroRepository SCadastroRepository)
            : base(SCadastroRepository)
        {
            _SCadastroRepository = SCadastroRepository;
        }

        public override void Add(SCadastro obj)
        {
            Validate(obj);
            obj.Senha = Hashing.HashPassword(obj.Senha);
            base.Add(obj);
        }

        public override void Update(SCadastro obj)
        {
            var pessoaAnterior = _SCadastroRepository.BuscaCadastroPorPessoa(obj.Pessoa_Id);
            if (obj.Senha == null && pessoaAnterior != null)
            {                
                pessoaAnterior.Login = obj.Login;
                base.Update(pessoaAnterior);
            }else
                Add(obj);
        }

        public SCadastro BuscaCadastroPorPessoa(int idPessoa)
        {
            return _SCadastroRepository.BuscaCadastroPorPessoa(idPessoa);
        }

        public SCadastro BuscaUsuarioLoginSenha(string login, string senha)
        {
            var ultimoRegistroUsuarios = _SCadastroRepository.BuscaUltimoRegistroTodosUsuariosPorLogin(login);
            foreach (var cadastro in ultimoRegistroUsuarios)
            {
                if (Hashing.ValidatePassword(senha, cadastro.Senha))
                {
                    return cadastro;
                }
            }
            return null;
        }

        public bool SenhaIgualAnterior(int idPessoa, string senha)
        {
            var cadastroAnterior = _SCadastroRepository.BuscaCadastroPorPessoa(idPessoa);
            return Hashing.ValidatePassword(senha, cadastroAnterior.Senha);
        }

        public void Validate(SCadastro cadastro)
        {            
            foreach (var item in ((System.Reflection.TypeInfo)cadastro.GetType()).DeclaredProperties)
            {
                var required = cadastro.GetAttributeFrom<RequiredAttribute>(item.Name);
                if (required != null)
                {
                    
                }
            }


            //var attrType = typeof(MaxLengthAttribute);
            //var passos = cadastro.GetType().GetProperties()[2];
            //var teste = (MaxLengthAttribute)passos.GetCustomAttributes(attrType, false).FirstOrDefault();


            var exps = new ListEntidadeException();
            if (cadastro.Senha == null)
                exps.AdicionarException(nameof(SCadastro.Senha), "O campo Senha é obrigatório.");
            else if (cadastro.Senha.Length < 7)
                exps.AdicionarException(nameof(SCadastro.Senha), "Senha precisa ter no minimo 7 digitos");
            if (cadastro.Login == null)
                exps.AdicionarException(nameof(SCadastro.Login), "O campo Login é obrigatório.");
            if (exps.TemErro)
                throw exps;


        }        
    }
}

