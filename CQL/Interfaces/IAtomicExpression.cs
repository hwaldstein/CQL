using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Models;
using Data.Interfaces;

namespace CQL.Interfaces
{
    public interface IAtomicExpression
    {
        IEnumerable<ICourse> Evaluate(ISource source);
    }
}
