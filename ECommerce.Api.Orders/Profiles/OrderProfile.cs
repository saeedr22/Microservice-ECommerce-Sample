namespace ECommerce.Api.Orders.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Data.Order, Models.Order>();
            CreateMap<Data.OrderItem, Models.OrderItem>();
        }
    }
}
