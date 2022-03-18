using ApiCadastroPessoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastroPessoa.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private List<PessoaModel> _pessoas = new List<PessoaModel>();

        public void Adicionar(PessoaModel pessoa)
        {
            pessoa.CodigoPessoa = Guid.NewGuid().ToString();
            _pessoas.Add(pessoa);
        }

        public void Remover(string codigoPessoa)
        {
            var pessoaRemover = _pessoas.Find(pessoa => pessoa.CodigoPessoa == codigoPessoa);
            _pessoas.Remove(pessoaRemover);
        }

        public List<PessoaModel> Consultar()
        {
            return _pessoas;
        }

    }
}
