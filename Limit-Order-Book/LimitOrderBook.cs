using System;
using System.Collections.Generic;
using System.Linq;

namespace Limit_Order_Book { }


public class LimitOrderBook
{
    private SortedDictionary<decimal, Queue<Order>> bids;
    private SortedDictionary<decimal, Queue<Order>> asks;

    public LimitOrderBook()
    {
        bids = new SortedDictionary<decimal, Queue<Order>>(Comparer<decimal>.Create((x, y) => y.CompareTo(x)));
        asks = new SortedDictionary<decimal, Queue<Order>>();
    }

    public void AddOrder(Order order)
    {
        if (order.Type == OrderType.Bid)
        {
            if (!bids.ContainsKey(order.Price))
            {
                Queue<Order> orders = new();
                bids[order.Price] = orders;
            }
            bids[order.Price].Enqueue(order);
        }
        else if (order.Type == OrderType.Ask)
        {
            if (!asks.ContainsKey(order.Price))
            {
                asks[order.Price] = new Queue<Order>();
            }
            asks[order.Price].Enqueue(order);
        }
    }

    public void RemoveOrder(Order order)
    {
        if (order.Type == OrderType.Bid)
        {
            bids[order.Price].Dequeue();
            if (bids[order.Price].Count == 0)
            {
                bids.Remove(order.Price);
            }
        }
        else if (order.Type == OrderType.Ask)
        {
            asks[order.Price].Dequeue();
            if (asks[order.Price].Count == 0)
            {
                asks.Remove(order.Price);
            }
        }
    }

    public IEnumerable<Order> GetBids()
    {
        return bids.Values.SelectMany(q => q);
    }

    public IEnumerable<Order> GetAsks()
    {
        return asks.Values.SelectMany(q => q);
    }

    public IEnumerable<Order> GetMatchingOrders(Order order)
    {
        if (order.Type == OrderType.Bid)
        {
            foreach (var askQueue in asks)
            {
                if (askQueue.Key <= order.Price)
                {
                    foreach (var matchingOrder in askQueue.Value)
                    {
                        yield return matchingOrder;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else if (order.Type == OrderType.Ask)
        {
            foreach (var bidQueue in bids)
            {
                if (bidQueue.Key >= order.Price)
                {
                    foreach (var matchingOrder in bidQueue.Value)
                    {
                        yield return matchingOrder;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}

public enum OrderType
{
    Bid,
    Ask
}

public class Order
{
    public OrderType Type { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}