using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    public interface MutationType
    {
        // (содержит обработку мутаций хромосомы (локус))

        GeneValue Mutate(GeneValue toMutate);  
        
    }
}
