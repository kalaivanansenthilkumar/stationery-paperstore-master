using System.Threading.Tasks;
using Stationery.PaperStore.Core.Entities;
using Stationery.PaperStore.Core.Entities.OrderAggregate;

namespace Stationery.PaperStore.Core.Interfaces
{
    public interface IPaymentService
    {
         Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
         Task<Order> UpdatePaymentOrderSucceeded(string paymentIntentId);
         Task<Order> UpdatePaymentOrderFailed(string paymentIntentId);
    }
}