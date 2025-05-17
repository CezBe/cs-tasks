using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class MainForm : Form
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
        public MainForm() {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            txtDividend = new TextBox();
            txtDivisor = new TextBox();
            txtResult = new TextBox();
            btnDivide = new Button();

            // txtDividend
            txtDividend.Location = new Point(20, 20);
            txtDividend.Name = "txtDividend";
            txtDividend.Size = new Size(100, 20);

            // txtDivisor
            txtDivisor.Location = new Point(20, 60);
            txtDivisor.Name = "txtDivisor";
            txtDivisor.Size = new Size(100, 20);

            // txtResult
            txtResult.Location = new Point(20, 140);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(100, 20);

            // btnDivide
            btnDivide.Location = new Point(20, 100);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(100, 30);
            btnDivide.Text = "Oblicz";
            btnDivide.Click += btnDivide_Click;

            // MainForm
            ClientSize = new Size(200, 200);
            Controls.Add(txtDividend);
            Controls.Add(txtDivisor);
            Controls.Add(txtResult);
            Controls.Add(btnDivide);
            Name = "MainForm";
            Text = "Kalkulator Dzielenia";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                double dividend = double.Parse(txtDividend.Text);
                double divisor = double.Parse(txtDivisor.Text);

                if (divisor == 0)
                {
                    throw new DivideByZeroException("Nie można dzielić przez zero.");
                }

                double result = dividend / divisor;
                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TextBox txtDividend;
        private TextBox txtDivisor;
        private TextBox txtResult;
        private Button btnDivide;
    }
}
