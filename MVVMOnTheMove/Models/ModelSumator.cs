using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MVVMOnTheMove.Models
{
    public class ModelSumator
    {
        public IEnumerable<double> PreviousResults
        {
            get
            {
                if (this.previousResults == null)
                {
                    previousResults = new List<double>();
                }
                return this.previousResults;
            }
        }

        double result;

        public double Result
        {
            get
            {
                return result;
            }
        }


        public void CalcResult(double a, double b, char operation)
        {
            switch (operation)
            {
                case '-':
                    this.result =Math.Abs( b - (b*(a/100))) ;
                    break;
                case '+':
                    this.result = a - b;
                    break;
                default:
                    break;
            }
            (previousResults as List<double>).Add(this.result);

        }

        private IEnumerable<double> previousResults;

        public static double GetDiscount(string status)
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