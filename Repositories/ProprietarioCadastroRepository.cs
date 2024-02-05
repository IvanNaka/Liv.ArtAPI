using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liv.ArtAPI.Repositories
{
    public class ProprietarioCadastroRepository
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CertificadoPath { get; set; }
        public string DocumentoPath { get; set; }
        public string Formacao { get; set; }
        public string Nacionalidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }

        public Proprietario ProprietarioCadastro()
        {
            string NomeCompleto = $"{this.Nome} {this.Sobrenome}";
            Proprietario proprietarioObj = new Proprietario();
            proprietarioObj.NomeCompleto = NomeCompleto;
            proprietarioObj.DataNascimento = this.DataNascimento;
            proprietarioObj.CPF = this.CPF;
            proprietarioObj.DocumentoPath = this.DocumentoPath;
            proprietarioObj.Email = this.Email;
            proprietarioObj.Telefone = this.Telefone;
            proprietarioObj.Username = this.Username;
            proprietarioObj.Senha = this.Senha;
            proprietarioObj.StatusId = "pendente_proprietario";
            return proprietarioObj;
        }
    }
}