using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.Evolushion
{
    public interface GeneValue
    {
        GeneValue Copy();
        string ToString(); // хз как это пометить, но в коде используется для вывода информации преобразование класса к строке
    }
}
