using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo.Nancy.WebApi.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string NaturezaJuridica { get; set; }
        public string Situacao { get; set; }
    }
}