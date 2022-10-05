using Restaurant.DAL.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Specifications.OrderSpecifications
{
    public class OrderWithHisItemsSpecification : BaseSpecification<Order>
    {
        public OrderWithHisItemsSpecification(string buyerEmail) : base(O => O.BuyerEmail == buyerEmail)
        {
            AddInclude(O => O.Items);
            ApplyOrderByDescending(O => O.OrderDate);
        }
        public OrderWithHisItemsSpecification(int orderId, string buyerEmail) :
                                                         base(O => (O.BuyerEmail == buyerEmail && O.Id == orderId))
        {
            AddInclude(O => O.Items);
        }
    }
}
