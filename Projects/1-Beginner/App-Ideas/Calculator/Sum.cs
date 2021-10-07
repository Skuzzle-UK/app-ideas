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
            equal,
            percent
        }

        public enum Sign
        {
            positive,
            negative
        }

        public decimal product { get; set; }

        public bool DisplayingProduct = false;

        private string _summand;
        public string summand
        {
            get
            {
                return _summand;
            }
            set
            {
                if (value != null)
                {
                    char[] chars = value.ToCharArray();
                    if (chars[0].ToString() == "-")
                    {
                        value = null;
                        for (int i = 1; i < chars.Length; i++)
                        {
                            value += chars[i].ToString();
                        }
                    }
                }
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

        public void DisplayProduct()
        {
            DisplayingProduct = true;
            summand = product.ToString();
        }

        public void AppendSummand(int digit)
        {
            if (EmptySummand() || DisplayingProduct)
            {
                sign = Sign.positive;
                summand = null;
                DisplayingProduct = false;
            }
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

            if (@operator != Operator.percent)
            {
                switch (lastoperator)
                {
                    case Operator.none:
                        product = val;
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                    case Operator.add:
                        product += val;
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                    case Operator.divide:
                        product /= val;
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                    case Operator.multiply:
                        product *= val;
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                    case Operator.subtract:
                        product -= val;
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                    case Operator.equal:
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                }
            }
            else
            {
                //@TODO Code here for percentage calc
                switch (lastoperator)
                {
                    case Operator.none:
                        break;
                    case Operator.add:
                        //Should work out summand percent of product and then add that value to product.
                        DisplayProduct();
                        break;
                    case Operator.divide:
                        //@TODO Not sure what to do here: test a calculator if I get a chance to see what happens if you key eg.. 600 / 30 %
                        break;
                    case Operator.multiply:
                        //Should work out summand percent of product and then display the percentage.
                        DisplayProduct();
                        break;
                    case Operator.subtract:
                        //Should work out summand percent of product and then subtract that value from product.
                        DisplayProduct();
                        break;
                    case Operator.equal:
                        //@TODO Not sure what to do here: test a calculator if I get a chance to see what happens if you key eg.. 600 / 30 %
                        break;
                }
            }

            if (@operator == Operator.equal)
            {
                summand = Math.Abs(product).ToString();
                if (product < 0)
                {
                    sign = Sign.negative;
                }
                else
                {
                    sign = Sign.positive;
                }
                lastoperator = @operator;
                DisplayProduct();
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