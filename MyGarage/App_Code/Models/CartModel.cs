using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            MyGarageDBEntities db = new MyGarageDBEntities();
            db.Carts.Add(cart);
            db.SaveChanges();

            return "Order was successfully inserted";
        }

        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            MyGarageDBEntities db = new MyGarageDBEntities();

            //Fetch object from db
            Cart p = db.Carts.Find(id);

            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.ProductID = cart.ProductID;
            p.IsInCart = cart.IsInCart;
            p.Amount = cart.Amount;

            db.SaveChanges();

            return  "Order was successfully updated";
        }

        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteCart(int id)
    {
        try
        {
            MyGarageDBEntities db = new MyGarageDBEntities();
            Cart cart = db.Carts.Find(id);

            db.Carts.Attach(cart);
            db.Carts.Remove(cart);
            db.SaveChanges();

            return  "Order was successfully deleted";

        }

        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public List<Cart> GetOrdersInCart(string userId)
    {
        MyGarageDBEntities db = new MyGarageDBEntities();
        List<Cart> orders = (from x in db.Carts
                             where x.ClientID == userId
                             && x.IsInCart
                             orderby x.DatePurchased
                             select x).ToList();
        return orders;
    }

    public int GetAmountOfOrders(string userId)
    {
        try
        {
            MyGarageDBEntities db = new MyGarageDBEntities();
            int amount = (from x in db.Carts
                          where x.ClientID == userId
                          && x.IsInCart
                          orderby x.DatePurchased
                          select x.Amount).Sum();
            return amount;
        }
        catch
        {
            return 0;
        }
    }

    public void UpdateQuantity(int id, int quantity)
    {
        MyGarageDBEntities db = new MyGarageDBEntities();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;

        db.SaveChanges();
    }

    public void MarkOrdersAsPaid(List<Cart> carts)
    {
        MyGarageDBEntities db = new MyGarageDBEntities();

        if(carts != null)
        {
            foreach(Cart cart in carts)
            {
                Cart oldCart = db.Carts.Find(cart.ID);
                oldCart.DatePurchased = DateTime.Now;
                oldCart.IsInCart = false;
            }
            db.SaveChanges();
        }
    }
}