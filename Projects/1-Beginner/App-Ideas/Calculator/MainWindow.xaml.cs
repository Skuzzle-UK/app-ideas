using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Sum sum = new Sum();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = sum;
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            sum.Clear();
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            sum.Reset();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(0);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(3);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(4);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(5);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(6);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(7);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(8);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendSummand(9);
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            sum.AppendDecimalPlace();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.add);
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.subtract);
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.multiply);
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.divide);
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.equal);
        }
    }

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
        Operator @lastoperator;

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
            summand = "0";
            product = 0;
            _decimalPlace = false;
            _productHistory.Clear();
        }

        public void Clear()
        {
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
