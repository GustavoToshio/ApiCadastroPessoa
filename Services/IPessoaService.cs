using ApiCadastroPessoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastroPessoa.Services
{
    public interface IPessoaService
    {
        void Adicionar(PessoaModel pessoa);

        void Remover(string codigoPessoa);

        List<PessoaModel> Consultar();
    }
}
