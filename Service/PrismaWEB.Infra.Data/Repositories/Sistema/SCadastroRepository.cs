using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class SCadastroRepository : RepositoryBase<SCadastro>, ISCadastroRepository
    {
        public SCadastro BuscaCadastroPorPessoa(int idPessoa)
        {
            return Db.S_Cadastros.SqlQuery(@"SELECT *
                                               FROM S_Cadastros c
                                              WHERE c.Pessoa_Id = " + idPessoa +
                                                @"AND c.DataCriacao = (SELECT MAX(DataCriacao) 
                                                                     FROM S_Cadastros
                                                                     WHERE Pessoa_Id = c.Pessoa_Id 
                                                                     GROUP BY Pessoa_Id)").FirstOrDefault();
        }

        public IList<SCadastro> BuscaUltimoRegistroTodosUsuariosPorLogin(string login)
        {
            return Db.S_Cadastros.SqlQuery(@"SELECT *
                                               FROM S_Cadastros c
                                              WHERE c.DataCriacao = (SELECT MAX(DataCriacao) 
                                                                     FROM S_Cadastros
                                                                     WHERE Pessoa_Id = c.Pessoa_Id 
                                                                     GROUP BY Pessoa_Id)
                                                AND c.Login = '" + login + "'").ToList();
        }
    }
}

