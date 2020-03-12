using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.State
{
    public enum UnitState
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }

    public interface IUnitState
    {
        UnitState UnitState { get; set; }
    }
}
