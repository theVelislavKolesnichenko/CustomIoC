using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisCountRepository
{
    public class DisCountRepository
    {
        public double GetDiscount(string status)
        {
            IDictionary<string, double> discount = new Dictionary<string, double>()
            {
	            {"Fish", 5.5},
	            {"Vegetables", 11.5},
	            {"Fruit", 87.5}
            };

            return discount[status];
        }
    }
}
