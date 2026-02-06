using System;
using System.Linq.Expressions;
using Stationery.PaperStore.Core.Entities.OrderAggregate;

namespace Stationery.PaperStore.Core.Specifications
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId) : base(o => o.PaymentIntentId == paymentIntentId)
        {
            
        }
    }
}