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

        private void ButtonNormalOperator_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            switch (b.Tag.ToString())
            {
                case "add":
                    sum.Operation(Sum.Operator.add);
                    break;
                case "subtract":
                    sum.Operation(Sum.Operator.subtract);
                    break;
                case "multiply":
                    sum.Operation(Sum.Operator.multiply);
                    break;
                case "divide":
                    sum.Operation(Sum.Operator.divide);
                    break;
            }
            last_button_operator = true;
            last_button_final = false;
        }

        private void ButtonFinalOperator_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            switch (b.Tag.ToString())
            {
                case "equals":
                    sum.Operation(Sum.Operator.equal);
                    break;
                case "percent":
                    sum.Operation(Sum.Operator.percent);
                    break;
            }
            last_button_operator = false;
            last_button_final = true;
        }

        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            sum.SummandSignSwap();
        }

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {
            sum.Undo();
            last_button_operator = false;
            last_button_final = false;
        }
    }
}
