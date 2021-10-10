using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

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
            if (CheckCharCount() || last_button_operator || last_button_final)
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
            Debug.WriteLine(e);
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

        private void ValueDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            bool isGood = false;
            string str = "";

            if (text.Text.Length > 10)
            {
                char[] chars = text.Text.ToCharArray();
                for (int i = 0; i < 10; i++)
                {
                    str += chars[i].ToString();
                    if (chars[i].ToString() == ".")
                    {
                        isGood = true;
                        if (int.Parse(chars[10].ToString()) >= 5 && chars[9].ToString() != ".")
                        {
                            int j = int.Parse(chars[9].ToString());
                            j++;
                            chars[9] = char.Parse(j.ToString());
                        }
                    }
                }

                if (isGood)
                {
                    text.Text = str;
                }
                else
                {
                    text.Text = "ERR";
                    last_button_operator = false;
                    last_button_final = true;
                    sum.ClearLastOperator();
                }
            }
        }

        private void ButtonMPlus_Click(object sender, RoutedEventArgs e)
        {
            sum.AddToMemory();
        }

        private void ButtonMMinus_Click(object sender, RoutedEventArgs e)
        {
            sum.SubtractFromMemory();
        }

        private void ButtonMR_Click(object sender, RoutedEventArgs e)
        {
            sum.RecallMemory();
        }

        private void ButtonMC_Click(object sender, RoutedEventArgs e)
        {
            sum.ClearMemory();
        }


        //@TODO needs percent key adding somehow and look at why weird behaviour after button physically pressed.
        private void Calculator_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    ButtonEquals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad0:
                    Button0.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad1:
                    Button1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad2:
                    Button2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad3:
                    Button3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad4:
                    Button4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad5:
                    Button5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad6:
                    Button6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad7:
                    Button7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad8:
                    Button8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad9:
                    Button9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Multiply:
                    ButtonMultiply.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Divide:
                    ButtonDivide.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Subtract:
                    ButtonSubtract.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Add:
                    ButtonAdd.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
            }
        }
    }
}
