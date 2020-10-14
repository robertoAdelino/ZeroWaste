using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Regras
    {
        [Key]
        public int RegrasID { get; set; }

        [Required(ErrorMessage = "Dê um nome à regra.")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza uma regra válida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Regra inválida!!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o Rendimento.")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor introduza um número maior que zero")]
        public int Rendimento { get; set; }
        /*
        public string Maior { get; set; }
        public string Menor { get; set; }
        public string MaiorIgual { get; set; }
        public string MenorIgual { get; set; }
        */
        [Range(0, int.MaxValue, ErrorMessage = "Por favor introduza um número maior que zero")]
        public int Agregado { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Por favor introduza um número maior que zero")]
        public int Pedidos { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Por favor introduza um número maior que zero")]
        public int Alimentos { get; set; }



    }
}
