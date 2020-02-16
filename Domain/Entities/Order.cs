using System;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Product Product { get; set; }
    }
}