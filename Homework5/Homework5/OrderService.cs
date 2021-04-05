﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class OrderService
    {
        public List<Order> orderList = new List<Order>();


        public void AddOrder(Order order)
        {
            orderList.Add(order);
        }

        public void Update(Order order)
        {
            RemoveOrder(order.Id);
            orderList.Add(order);
        }

        public Order GetById(int orderId)
        {
            return orderList.Where(o => o.Id == orderId).FirstOrDefault();
        }

        public void RemoveOrder(int orderId)
        {
            orderList.RemoveAll(o => o.Id == orderId);
        }


        public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            return orderList.Where(o => condition(o));
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderList.Where(
              o => o.Details.Any(d => d.Goods.Name == goodsName));
            return query.ToList();
        }

        public List<Order> QueryByTotalAmount(double totalAmount)
        {
            var query = orderList.Where(o => o.Amounts == totalAmount);
            return query.ToList();
        }

        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderList
                .Where(o => o.Client.Name == customerName);
            return query.ToList();
        }


        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }
    }
}
