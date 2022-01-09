using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers
{
    /// <summary>
    /// With this interface classes can be passed before calling Parse()
    /// </summary>
    public interface IParseLogic
    {
        object Parse(String _data);
    }
}
