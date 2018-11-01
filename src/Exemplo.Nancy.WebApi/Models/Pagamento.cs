using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo.Nancy.WebApi.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdEstabelecimento { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}