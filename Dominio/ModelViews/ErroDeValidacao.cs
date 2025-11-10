using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.ModelViews
{
    public struct ErroDeValidacao
    {
        public List<string> Mensagens { get; set; }
    }
}