using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.PaperStore.Core.Interfaces
{
    public interface IOfferCalculator
    {
        double Calculate(double offeramount, double amount);
    }
}
