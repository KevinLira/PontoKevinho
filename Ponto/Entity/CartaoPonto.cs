using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ponto.Entity
{
    public class CartaoPonto
    {
        public List<BatidasPonto> Batidas { get; set; }
        public TimeSpan SaldoHoras { get; set; }
    }
}
