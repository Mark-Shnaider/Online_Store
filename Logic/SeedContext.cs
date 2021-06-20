using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Common.Models.Entities;
using System.Linq;
using Common.Contracts;

namespace Logic
{
    public class SeedContext
    {
        public static void Seed(IUnitOfWork unitOfWork, ILoggerFactory loggerFactory)
        {
            IEnumerable<Category> categories;
            //IEnumerable<Amount> amounts;
            //IEnumerable<Customer> customers;
            //IEnumerable<Product> products;
            //IEnumerable<Order> orders;

            if (!unitOfWork.Categories.GetAll().Any() && !unitOfWork.Products.GetAll().Any())
            {
                unitOfWork.Categories.AddRange(categories = GetPreconfiguredCategories());
                unitOfWork.Commit();
                
                unitOfWork.Products.AddRange(GetPreconfiguredProducts(categories));
                unitOfWork.Commit();
            }

            if (!unitOfWork.Customers.GetAll().Any())
            {
                unitOfWork.Customers.AddRange(GetPreconfiguredCustomers());
                unitOfWork.Commit();
            }

            

        }
        static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category{ Id = Guid.NewGuid(), Name = "Category1", Description="Description1"},
                new Category{ Id = Guid.NewGuid(), Name = "Category2", Description="Description2"},
                new Category{ Id = Guid.NewGuid(), Name = "Category3", Description="Description3"},
                new Category{ Id = Guid.NewGuid(), Name = "Category4", Description="Description4"},
                new Category{ Id = Guid.NewGuid(), Name = "Category5", Description="Description5"}

            };
        }
        static IEnumerable<Customer> GetPreconfiguredCustomers()
        {
            return new List<Customer>()
            {
                new Customer{Id = Guid.NewGuid(), Login = "Login1", Password ="12345", Email="1@ya.ru", Address="Something", PhoneNumber="911" },
                new Customer{Id = Guid.NewGuid(), Login = "Login2", Password ="12345", Email="2@ya.ru", Address="Something", PhoneNumber="123" },
                new Customer{Id = Guid.NewGuid(), Login = "Login3", Password ="12345", Email="3@ya.ru", Address="Something", PhoneNumber="456" },
                new Customer{Id = Guid.NewGuid(), Login = "Login4", Password ="12345", Email="4@ya.ru", Address="Something", PhoneNumber="789" },
                new Customer{Id = Guid.NewGuid(), Login = "Login5", Password ="12345", Email="5@ya.ru", Address="Something", PhoneNumber="911" },
            };
        }

        static IEnumerable<Product> GetPreconfiguredProducts(IEnumerable<Category> categories)
        {
            var _categories = categories.ToList();
            return new List<Product>()
            { 
                new Product{ Id=Guid.NewGuid(), Name = "Product1", Description = "Description1", Price=2, Quantity=5, Category = _categories[0]},
                new Product{ Id=Guid.NewGuid(), Name = "Product2", Description = "Description2", Price=4, Quantity=10, Category = _categories[1]},
                new Product{ Id=Guid.NewGuid(), Name = "Product3", Description = "Description3", Price=6, Quantity=15, Category = _categories[2]},
                new Product{ Id=Guid.NewGuid(), Name = "Product4", Description = "Description4", Price=8, Quantity=20, Category = _categories[3]},
                new Product{ Id=Guid.NewGuid(), Name = "Product5", Description = "Description5", Price=10, Quantity=25, Category = _categories[4]},
                new Product{ Id=Guid.NewGuid(), Name = "Product6", Description = "Description6", Price=12, Quantity=30, Category = _categories[0]},
                new Product{ Id=Guid.NewGuid(), Name = "Product7", Description = "Description7", Price=14, Quantity=35, Category = _categories[1]}
            };
        }
    }
}
