using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo.Nancy.WebApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCartao { get; set; }
    }
}