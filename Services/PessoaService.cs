using ApiCadastroPessoa.Models;
using ApiCadastroPessoa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastroPessoa.Services
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(PessoaModel pessoa)
        {
            _repository.Adicionar(pessoa);
        }

        public void Remover(string codigoPessoa)
        {
            _repository.Remover(codigoPessoa);
        }

        public List<PessoaModel> Consultar()
        {
            return _repository.Consultar();
        }
    }
}
