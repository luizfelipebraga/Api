using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insira um nome")]
        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Insira uma data")]
        public DateTime DataLancamento { get; set; }

        public float Valor { get; set; }
        public int IdEstudio { get; set; }
        public EstudioDomain Estudio { get; set; }

    }
}
