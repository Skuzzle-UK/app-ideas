using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Sum sum = new Sum();
        private bool last_button_operator = false;
        private bool last_button_final = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = sum;
        }

        private bool CheckCharCount()
        {
            if (sum.summand.Length == 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            if (last_button_final)
            {
                sum.Reset();
            }
            else if (!last_button_operator)
            {
                sum.Clear();
                last_button_operator = false;
                last_button_final = false;
            }
            else
            {
                sum.ClearLastOperator();
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            sum.Reset();
            last_button_operator = false;
            last_button_final = false;
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                Button b = sender as Button;
                sum.AppendSummand(int.Parse(b.Tag.ToString()));
                last_button_operator = false;
                last_button_final = false;

            }
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendDecimalPlace();
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.add);
            last_button_operator = true;
            last_button_final = false;
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.subtract);
            last_button_operator = true;
            last_button_final = false;
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.multiply);
            last_button_operator = true;
            last_button_final = false;
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.divide);
            last_button_operator = true;
            last_button_final = false;
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.equal);
            last_button_operator = false;
            last_button_final = true;
        }

        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            sum.SummandSignSwap();
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.percent);
            last_button_operator = false;
            last_button_final = true;
        }

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {
            sum.Undo();
            last_button_operator = false;
            last_button_final = false;
        }
    }
}
