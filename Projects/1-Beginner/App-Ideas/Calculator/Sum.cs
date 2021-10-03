using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Calculator
{
    public class Sum : INotifyPropertyChanged
    {
        public enum Operator
        {
            none,
            add,
            subtract,
            multiply,
            divide,
            equal
        }

        private enum Sign
        {
            positive,
            negative
        }

        public decimal product { get; set; }
        private string _summand;
        public string summand
        {
            get
            {
                return _summand;
            }
            set
            {
                _summand = value;
                NotifyPropertyChanged("summand");
            }
        }
        private bool _decimalPlace;
        private List<decimal> _productHistory = new List<decimal>();
        private Operator @lastoperator;
        private Sign @sign;

        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Sum()
        {
            Reset();
        }

        public void Reset()
        {
            lastoperator = Operator.none;
            product = 0;
            Clear();
            _productHistory.Clear();
        }

        public void Clear()
        {
            sign = Sign.positive;
            _decimalPlace = false;
            summand = "0";
        }

        public void AppendSummand(int digit)
        {
            if (EmptySummand()) { summand = null; }
            summand += (digit.ToString());
        }

        public void AppendDecimalPlace()
        {
            if (!_decimalPlace)
            {
                summand += ".";
                _decimalPlace = true;
            }
        }

        public void SummandSignSwap()
        {
            if (sign == Sign.positive)
            {
                sign = Sign.negative;
            }
            else
            {
                sign = Sign.positive;
            }
        }

        public void Operation(Operator @operator)
        {
            switch (lastoperator)
            {
                case Operator.none:
                    product = int.Parse(summand);
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.add:
                    product += int.Parse(summand);
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.divide:
                    product /= int.Parse(summand);
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.multiply:
                    product *= int.Parse(summand);
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.subtract:
                    product -= int.Parse(summand);
                    lastoperator = @operator;
                    Clear();
                    break;
            }
            if (@operator == Operator.equal)
            {
                summand = product.ToString();
            }
        }

        private bool EmptySummand()
        {
            switch (summand)
            {
                case "0":
                    return true;
                default:
                    return false;
            }
        }
    }
}