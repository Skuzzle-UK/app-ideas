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

        public enum Sign
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
        
        private Sign _sign;
        public Sign @sign
        {
            get
            {
                return _sign;
            }
            set
            {
                _sign = value;
                NotifyPropertyChanged("sign");
            }
        }


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
            decimal val = decimal.Parse(summand);
            
            if(sign == Sign.negative)
            {
                val *= -1;
            }
            SummandSignSwap();

            switch (lastoperator)
            {
                case Operator.none:
                    product = val;
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.add:
                    product += val;
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.divide:
                    product /= val;
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.multiply:
                    product *= val;
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.subtract:
                    product -= val;
                    lastoperator = @operator;
                    Clear();
                    break;
                case Operator.equal:
                    lastoperator = @operator;
                    Clear();
                    break;
            }
            if (@operator == Operator.equal)
            {
                summand = product.ToString();
                lastoperator = @operator;
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