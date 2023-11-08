using Models.Enums;
using Models.Extensions;

namespace Models.Classificacao
{
    public class Resposta
    {
        public int RespostaId { get; set; }
        public bool RespostaTexto { get; set; }  
        public bool RespostaTextoArea { get; set; } 
        public string RespostaCheckBox { get; set; }
        public string RespostaComboBox { get; set; }
        public string RespostaRadioButtom { get; set; }
        public DateTime? RespostaData { get; set; }
        public int ValorTipoResposta { get;  set; } // Tipo da resposta 
        public TipoResposta TipoResposta 
        {
            get { return ValorTipoResposta.ParaValor(); }
            set { ValorTipoResposta = value.ParaInt(); }
        }
        public int ValorResposta { get; set; } // Pontuação da resposta

    }
}
