using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Sum sum = new Sum();

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
            sum.Clear();
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            sum.Reset();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(0);
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(1);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(2);
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(3);
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(4);
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(5);
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(6);
            }
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(7);
            }
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(8);
            }
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendSummand(9);
            }
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCharCount())
            {
                sum.AppendDecimalPlace();
            }
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

        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            sum.SummandSignSwap();
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            sum.Operation(Sum.Operator.percent);
        }

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {
            sum.Undo();
        }
    }
}
