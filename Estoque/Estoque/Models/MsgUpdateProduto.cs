using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public class MsgUpdateProduto
    {
        public int ProdId { get; set; }
        public int ProdQtd { get; set; }
    }
}
