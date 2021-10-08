using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;


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

        private struct ProductState
        {
            public decimal productValue;
            public Sign productSign;
        }
        private List<ProductState> _productHistory = new List<ProductState>();

        private decimal _product;
        public decimal product
        {
            get
            {
                return _product;
            }
            set
            {
                //@TODO remove decimal places if not required due to zero post decimal value.
                ProductState ps = new ProductState();
                ps.productValue = _product;
                if (product < 0)
                {
                    ps.productSign = Sign.negative;
                }
                else
                {
                    ps.productSign = Sign.positive;
                }
                _productHistory.Add(ps);
                _product = value;
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
        
        private bool DisplayingProduct = false;
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
        private Operator @lastoperator;
        
        private Sign _sign;
        public Sign sign
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
            _decimalPlace = false;
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
                    case Operator.percent:
                        lastoperator = @operator;
                        DisplayProduct();
                        break;
                }
            }
            else
            {
                decimal onePercentOfProduct = product / 100;
                decimal calculatedPercent = onePercentOfProduct * val;
                switch (lastoperator)
                {
                    case Operator.none:
                        break;
                    case Operator.add:
                        product += calculatedPercent;
                        DisplayProduct();
                        break;
                    case Operator.divide:
                        Debug.WriteLine(calculatedPercent);
                        product /= calculatedPercent;
                        DisplayProduct();
                        break;
                    case Operator.multiply:
                        product = onePercentOfProduct * val;
                        DisplayProduct();
                        break;
                    case Operator.subtract:
                        product -= calculatedPercent;
                        DisplayProduct();
                        break;
                    case Operator.equal:
                        product = 0;
                        DisplayProduct();
                        break;
                }
                if (product < 0)
                {
                    sign = Sign.negative;
                }
                else
                {
                    sign = Sign.positive;
                }
                lastoperator = @operator;
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

        public void Undo()
        {
            if (lastoperator == Operator.equal)
            {
                _product = _productHistory[_productHistory.Count - 1].productValue;
                sign = _productHistory[_productHistory.Count - 1].productSign;
                _productHistory.RemoveAt(_productHistory.Count - 1);
                lastoperator = Operator.none;
                DisplayProduct();
            }
             else if (lastoperator != Operator.none)
            {
                lastoperator = Operator.none;
            }
            else if (_productHistory.Count > 0)
            {
                _product = _productHistory[_productHistory.Count - 1].productValue;
                sign = _productHistory[_productHistory.Count - 1].productSign;
                _productHistory.RemoveAt(_productHistory.Count - 1);
                lastoperator = Operator.none;
                DisplayProduct();
            }
        }
    }
}