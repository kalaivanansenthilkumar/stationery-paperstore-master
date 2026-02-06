using Stationery.PaperStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.PaperStore.Infrastructure.Services
{
    internal class OfferCalculator:IOfferCalculator
    {

        public OfferCalculator() { }

        public double Calculate(double offeramount, double amount)
        {
            return (offeramount * amount)/100;
        }
    }
}
