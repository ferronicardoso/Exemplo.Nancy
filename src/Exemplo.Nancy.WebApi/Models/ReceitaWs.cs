using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo.Nancy.WebApi.Models
{
    public class ReceitaWs
    {
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string natureza_juridica { get; set; }
        public string situacao { get; set; }
    }
}