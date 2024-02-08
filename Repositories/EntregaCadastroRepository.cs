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

        public Entrega Cadastro()
        {
            Entrega EntregaObj = new Entrega();
            EntregaObj.DataPrevista = DateTime.Now;
            EntregaObj.Status = this.Status;
            return EntregaObj;
        }
    }
}