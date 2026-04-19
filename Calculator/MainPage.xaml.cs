using System;
using Microsoft.Maui.Controls;

namespace Calculator
{
    public partial class MainPage : ContentPage

    {
       private double currentNumber = 0;
       private double result = 0;
       private string currentOperator = "";
       private bool newNumber = true;
        private double memory = 0;

        public MainPage()
        {
            InitializeComponent();
            EntryResult.Text = "0";
        }

        private void ClearButton(object sender, EventArgs e)
            {
            EntryResult.Text = "0";
            EntryCalculations.Text = "";
            result = 0;
            currentOperator = "";
            newNumber = true;
        }

        private void NumberButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (newNumber)
            {
                EntryResult.Text = button.Text;
                newNumber = false;
            }
            else
            {
                if (button.Text == "," && EntryResult.Text.Contains(",")) return;

                EntryResult.Text += button.Text;
            }
        }

        private void OperatorButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Calculate();

            currentOperator = button.Text;
            EntryCalculations.Text = result + " " + currentOperator;

            newNumber = true;
        }

        private void EqualButton(object sender, EventArgs e)
        {
            Calculate();

            EntryResult.Text = result.ToString();
            EntryCalculations.Text = "";

            currentOperator = "";
            newNumber = true;
        }

        private void Calculate()
        {
            currentNumber = Convert.ToDouble(EntryResult.Text);

            switch (currentOperator)
            {
                case "+":
                    result += currentNumber;
                    break;

                case "-":
                    result -= currentNumber;
                    break;

                case "*":
                    result *= currentNumber;
                    break;

                case "/":
                    if (currentNumber != 0)
                        result /= currentNumber;
                    else
                    {
                        EntryResult.Text = "Error";
                        return;
                    }
                    break;

                default:
                    result = currentNumber;
                    break;
            }
        }
        private void StoreInMemoryButton(object sender, EventArgs e)
        {
            memory += Convert.ToDouble(EntryResult.Text);
        }

        private void CatchFromMemoryButton(object sender, EventArgs e)
        {
            memory -= Convert.ToDouble(EntryResult.Text);
            EntryResult.Text = memory.ToString();
            newNumber = true;




        }

        private void DecimalButton(object sender, EventArgs e)
        {
            if (newNumber)
            {
                EntryResult.Text = "0,";
                newNumber = false;
                return;
            }

            if (!EntryResult.Text.Contains(","))
            {
                EntryResult.Text += ",";
            }
        }

    }

    }
