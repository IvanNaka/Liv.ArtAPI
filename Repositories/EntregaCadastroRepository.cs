using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liv.ArtAPI.Repositories
{
    public class EntregaCadastroRepository
    {

        public DateTime DataPrevista { get; set; }
        public string Status { get; set; }
        public int CompradorId { get; set; }
        public int ProprietarioId { get; set; }
        public int PagamentoId { get; set; }

        public Entrega Cadastro()
        {
            Entrega EntregaObj = new Entrega();
            EntregaObj.DataPrevista = DateTime.Now;
            EntregaObj.Status = this.Status;
            EntregaObj.CompradorId = this.CompradorId;
            EntregaObj.ProprietarioId = this.ProprietarioId;
            EntregaObj.PagamentoId = this.PagamentoId;
            return EntregaObj;
        }
    }
}