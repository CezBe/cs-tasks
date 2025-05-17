using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public class CalculatorForm : Form
    {
        private TextBox display;
        private string currentOperation = "";
        private double firstNumber = 0;
        private bool isNewEntry = true;

        public CalculatorForm()
        {
            Text = "Kalkulator";
            Width = 300;
            Height = 400;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Pole tekstowe do wyświetlania
            display = new TextBox
            {
                Font = new Font("Arial", 20),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Top,
                Height = 50
            };
            Controls.Add(display);

            // Tworzenie panelu z przyciskami
            var buttonsPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4,
                ColumnCount = 4,
                AutoSize = true,
            };

            // Ustaw proporcje kolumn i wierszy
            for (int i = 0; i < 4; i++)
            {
                buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }
            Controls.Add(buttonsPanel);

            // Przyciski kalkulatora
            string[] buttonLabels = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "C", "0", "=", "+" };
            foreach (var label in buttonLabels)
            {
                var button = new Button
                {
                    Text = label,
                    Font = new Font("Arial", 14),
                    Dock = DockStyle.Fill, // Ustawienie dopasowania przycisków
                    Margin = new Padding(5) // Przerwy między przyciskami
                };
                button.Click += Button_Click;
                buttonsPanel.Controls.Add(button);
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            string buttonText = button.Text;

            if (double.TryParse(buttonText, out double number))
            {
                if (isNewEntry)
                {
                    display.Text = buttonText;
                    isNewEntry = false;
                }
                else
                {
                    display.Text += buttonText;
                }
            }
            else
            {
                switch (buttonText)
                {
                    case "C":
                        display.Text = "";
                        firstNumber = 0;
                        currentOperation = "";
                        isNewEntry = true;
                        break;

                    case "=":
                        PerformCalculation();
                        currentOperation = "";
                        isNewEntry = true;
                        break;

                    default:
                        currentOperation = buttonText;
                        firstNumber = double.Parse(display.Text);
                        isNewEntry = true;
                        break;
                }
            }
        }

        private void PerformCalculation()
        {
            double secondNumber = double.Parse(display.Text);

            switch (currentOperation)
            {
                case "+":
                    display.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "-":
                    display.Text = (firstNumber - secondNumber).ToString();
                    break;
                case "*":
                    display.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "/":
                    display.Text = secondNumber == 0 ? "Błąd" : (firstNumber / secondNumber).ToString();
                    break;
            }
        }
    }
}
