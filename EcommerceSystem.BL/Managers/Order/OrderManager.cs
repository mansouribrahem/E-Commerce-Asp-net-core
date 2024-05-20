using EcommerceSystem.BL.DTOs.Order;
using EcommerceSystem.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public class OrderManager : IOrderManager
    {
        private readonly IProductRepo _productRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IOrderItemRepo _orderItemRepo;

        public OrderManager(IProductRepo productRepo,IOrderRepo orderRepo,IOrderItemRepo orderItemRepo)
        {
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
        }
        public Order Add(AddOrderDto item)
        {
            if (item.CustomerId == 0)
                return null;
          
            Order order = new Order()
            {
                Date = DateTime.Now,
                CustomerId = item.CustomerId,
                Status="Pending",
            };

            _orderRepo.Add(order);
           

            var orderItems = new List<OrderItem>();
            decimal totalPrice = 0;
            foreach (var oItem in item.OrderItems)
            {
                OrderItem orderItem = new OrderItem();
                Product product=_productRepo.GetById(oItem.ProductId);
                
                orderItem.ProductId = oItem.ProductId;
                orderItem.Quantity = oItem.Quantity;
                orderItem.Price = (product?.Price??0)* oItem.Quantity;
                totalPrice += orderItem.Price;
                orderItems.Add(orderItem);
                
                
            }
            order.TotalPrice = totalPrice;
            _orderRepo.SaveChanges();
            foreach (var orderItemm in orderItems)
            {
                orderItemm.OrderId = order.Id;
                _orderItemRepo.Add(orderItemm);
                _orderItemRepo.SaveChanges();
            }
            return order;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetOrderDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public GetOrderDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(int id, AddOrderDto item)
        {
            throw new NotImplementedException();
        }
    }
}
