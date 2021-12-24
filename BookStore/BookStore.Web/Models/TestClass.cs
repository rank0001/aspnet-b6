using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Models
{
    public class TestClass : ITestClass
    {
        public string Test()
        {
            return "This is working!";
       }
    }
}
