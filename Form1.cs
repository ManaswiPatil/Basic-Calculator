using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Double resultValue = 0;
        String operatorClicked = "";
        bool IsOperatorClicked = false;

        public Calculator()
        {
            InitializeComponent();
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            if (resultTextBox.Text == "0" || IsOperatorClicked == true)
                resultTextBox.Clear();

            IsOperatorClicked = false;
            Button button = (Button)sender;

            if(button.Text == ".")
            {
                //resultTextBox.Text = resultTextBox.Text + button.Text;
                if (!resultTextBox.Text.Contains("."))
                {
                    resultTextBox.Text = resultTextBox.Text + button.Text;
                }
            }else
                resultTextBox.Text = resultTextBox.Text + button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            IsOperatorClicked = true;
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                equaltoButton.PerformClick();
                operatorClicked = button.Text;
                currentOperationLabel.Text = resultValue + " " + operatorClicked;
            }
            else
            {
                operatorClicked = button.Text;
                resultValue = Convert.ToDouble(resultTextBox.Text);
                currentOperationLabel.Text = resultValue + " " + operatorClicked;
            }
        }

        private void clearEntry_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
            resultValue = 0;
        }

        private void equalTo_Click(object sender, EventArgs e)
        {
            switch(operatorClicked)
            {
                case "+":
                    resultTextBox.Text = (resultValue + Convert.ToDouble(resultTextBox.Text)).ToString();
                    break;
                case "-":
                    resultTextBox.Text = (resultValue - Convert.ToDouble(resultTextBox.Text)).ToString();
                    break;
                case "*":
                    resultTextBox.Text = (resultValue * Convert.ToDouble(resultTextBox.Text)).ToString();
                    break;
                case "/":
                    resultTextBox.Text = (resultValue / Convert.ToDouble(resultTextBox.Text)).ToString();
                    break;
                default:
                    break;

            }
            resultValue = Convert.ToDouble(resultTextBox.Text);
            currentOperationLabel.Text = "";
        }
    }
}
