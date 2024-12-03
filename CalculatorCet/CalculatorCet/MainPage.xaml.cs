using System.Globalization; 

namespace CalculatorCet
{
    public partial class MainPage : ContentPage
    {

    double FirstNumber;
    bool isFirstNumberAfterOperator = true;
    Operator PreviousOperator = Operator.None;
    double MemoryValue = 0;
    bool hasDecimalPoint = false;

    private void DecimalPoint_Clicked(object sender, EventArgs e)
    {
        if (!hasDecimalPoint && !Display.Text.Contains(","))
        {
            if (isFirstNumberAfterOperator)
            {
                Display.Text = "0,";
                isFirstNumberAfterOperator = false;
            }
            else
            {
                Display.Text += ",";
            }
            hasDecimalPoint = true;
        }
    }

    private void MemoryStore_Clicked(object sender, EventArgs e)
    {
        if (Double.TryParse(Display.Text, NumberStyles.Any, new CultureInfo("tr-TR"), out double value))
        {
            MemoryValue = value;
        }
    }

  private void MemoryRecall_Clicked(object sender, EventArgs e)
    {
        Display.Text = MemoryValue.ToString(new CultureInfo("tr-TR"));
        isFirstNumberAfterOperator = false;
    }
        public MainPage()
        {
            InitializeComponent();
        }


        private void SubtractButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Subtract;

        }

        private void MultiplyButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Multiply;
        }

        private void DivideButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Divide;

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

            DoCalculation();
            PreviousOperator = Operator.Add;

        }

        void DoCalculation()
        {

            if (!isFirstNumberAfterOperator)
        {
            double currentNumber;
            if (Double.TryParse(Display.Text, NumberStyles.Any, new CultureInfo("tr-TR"), out currentNumber))
            {
                switch (PreviousOperator)
                {
                    case Operator.None:
                        FirstNumber = currentNumber;
                        break;
                    case Operator.Add:
                        FirstNumber += currentNumber;
                        break;
                    case Operator.Subtract:
                        FirstNumber -= currentNumber;
                        break;
                    case Operator.Multiply:
                        FirstNumber *= currentNumber;
                        break;
                    case Operator.Divide:
                        if (currentNumber != 0)
                            FirstNumber /= currentNumber;
                        else
                        {
                            Display.Text = "Error";
                            return;
                        }
                        break;
                }
            }
        }
        isFirstNumberAfterOperator = true;
        hasDecimalPoint = false;
        Display.Text = FirstNumber.ToString(new CultureInfo("tr-TR"));
        }

        private void Digit_Clicked(object sender, EventArgs e)
        {
            Button digitButton = sender as Button;
            if(isFirstNumberAfterOperator)
            {
                Display.Text = digitButton.Text;
                isFirstNumberAfterOperator = false;

            }
            else
            {
                Display.Text += digitButton.Text;
            }
           
        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.None;

        }

        private void CEButton_Clicked(object sender, EventArgs e)
    {
        Display.Text = "0";
        isFirstNumberAfterOperator = true;
        hasDecimalPoint = false;
    }

    private void CButton_Clicked(object sender, EventArgs e)
    {
        Display.Text = "0";
        FirstNumber = 0;
        PreviousOperator = Operator.None;
        isFirstNumberAfterOperator = true;
        hasDecimalPoint = false;
    }
    }

}
