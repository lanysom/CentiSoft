using CentiSoft.TimeReg.Repository.Interface;
using CentiSoft.TimeReg.Repository.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository
{
    public static class EntityFactory
    {
        public static TEntity Create<TEntity>()
        {
            switch (typeof(TEntity).Name)
            {
                case "ITask":
                    ITask task = new Task();
                    return (TEntity)task;
                case "IDeveloper":
                    IDeveloper developer = new Developer
                    {
                        Tasks = new List<ITask>()              
                    };
                    return (TEntity)developer;
                case "IProject":
                    IProject project = new Project
                    {
                        Tasks = new List<ITask>()
                    };
                    return (TEntity)project;
                case "ICustomer":
                    ICustomer customer = new Customer
                    {
                        Projects = new List<IProject>()
                    };
                    return (TEntity)customer;
                case "IClient":
                    IClient client = new Client
                    {
                        Customers = new List<ICustomer>()
                    };
                    return (TEntity)client;
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
