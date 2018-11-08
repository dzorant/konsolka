using System;
using System.Collections.Generic;

namespace konsolowe.Models
{
    public class User
    {
        private ISet<Order> _orders = new HashSet<Order>(); //znajduja sie nie powtarzajace sie elementy
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }    
        public DateTime UpdatedAt { get; private set; }   
        public decimal Funds { get; private set; } 

        public IEnumerable<Order> Orders {get {return _orders;} }

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
                if(string.IsNullOrWhiteSpace(email))
                {
                    throw new Exception("Email is incorrect.");
                }
                if(Email == email)
                {
                    return;
                }

                Email = email;
                Update();    
        }

        public void SetPassword(string password)
        {
                if(string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("password is incorrect.");
                }
                if(Password == Password)
                {
                    return;
                }

                Password = password;
                Update();    
        }

        public void SetAge(int age)
        {
            if(age < 13)
            {
                throw new Exception("Za malo lat");
            }
            if(Age == age)
            {
                return;
            }
            Age = age;
            Update();
        }

        public void SetActive()
        {
            if(IsActive)
            {
                return;
            }

            IsActive = true;
            Update();
        }

        public void Deactivate()
        {
            if(!IsActive)
            {
                return;
            }

            IsActive = false;
            Update();
        }

        public void IncreaseFunds(decimal funds)
        {
            if(funds <= 0 )
            {
                throw new Exception("Funds must be  wiecej jak 0");
            }
            Funds += funds;
            Update();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
                throw new Exception("Only acrive user can purchase an order.");
            }
            decimal orderPrice = order.TotalPrice;
            if(Funds - orderPrice <0)
            {
                throw new Exception("You dont have enough money.");
            }

            order.Purchese();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();
            
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}