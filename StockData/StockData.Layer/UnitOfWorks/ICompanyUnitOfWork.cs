using System;
using System.Collections.Generic;
using System.Linq;
using StockData.Data;
using StockData.Layer.Repositories;
namespace StockData.Layer.UnitOfWorks
{
    public interface ICompanyUnitOfWork:IUnitOfWork
    {
        ICompanyRepository Companies { get;}
    }
}
