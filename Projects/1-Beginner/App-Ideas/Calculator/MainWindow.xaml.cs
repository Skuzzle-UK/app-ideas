using System.Windows;

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

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(0);
                last_button_operator = false;
                last_button_final = false;

            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(1);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(2);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(3);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(4);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(5);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(6);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(7);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(8);
                last_button_operator = false;
                last_button_final = false;
            }
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(9);
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
