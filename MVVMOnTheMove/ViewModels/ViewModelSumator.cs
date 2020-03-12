using System.Collections.Generic;
using MVVMOnTheMove.Models;
using System.Collections.Specialized;

namespace MVVMOnTheMove.ViewModels
{
    class ViewModelSumator:ViewModelBase
    {
        ModelSumator model;

        public ViewModelSumator()
        {
            model = new ModelSumator();
        }

        public double Result
        {
            get
            {
                return this.model.Result;
            }
        }

        public void CalculateResult(string first, string second, char operation)
        {
            //var a = double.Parse(first);
            var a = Models.ModelSumator.GetDiscount(first);
            var b = double.Parse(second);
            this.model.CalcResult(a, b, operation);
            OnPropertyChanged("Result");
        }

        public IEnumerable<double> PreviousResult
        {
            get
            {
                return model.PreviousResults;
            }
        }
    }
}