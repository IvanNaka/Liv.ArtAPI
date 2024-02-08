using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liv.ArtAPI.Repositories
{
    public class ProprietarioObraCadastroRepository
    {
        public string Artista { get; set; }
        public string Titulo { get; set; }
        public DateOnly DataCriacao { get; set; }
        public string Dimensao { get; set; }
        public string Tecnica { get; set; }
        public string? Descricao { get; set; }


        public ObraArte ObraArteCadastro(int ProprietarioId)
        {
            ObraArte obraarteObj = new ObraArte();
            obraarteObj.Artista = this.Artista;
            obraarteObj.Titulo = this.Titulo;
            obraarteObj.DataCriacao = this.DataCriacao;
            obraarteObj.Dimensao = this.Dimensao;
            obraarteObj.Tecnica = this.Tecnica;
            obraarteObj.Descricao = this.Descricao;
            obraarteObj.ProprietarioId = ProprietarioId;
            return obraarteObj;
        }
    }
}