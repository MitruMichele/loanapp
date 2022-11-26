using System;
using System.Windows.Forms;
using System.IO;

namespace loanapp
{
    public partial class Form1 : Form
    {
        double InterestRate, monthlyInterestRate, LoanAmount, MonthlyPayment, TotalPayment;

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "Loan System ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAmountLoan.Clear();
            txtNumberOfYear.Clear();
            txtInterestRate.Clear();
            lblMonthlyPayment.Text = "";
            lblTotalPayment.Text = "";
            rtfReceipt.Clear();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            InterestRate = Convert.ToDouble(txtInterestRate.Text);
            monthlyInterestRate = InterestRate / 1200;
            NumberOfYear = Convert.ToInt32(txtNumberOfYear.Text);
            LoanAmount = Convert.ToDouble(txtAmountLoan.Text);

            MonthlyPayment = LoanAmount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate, NumberOfYear * 12));

            //--------------------------------------------------------------------------------------------------------
            iMonthlyPayment = Convert.ToString(MonthlyPayment);
            iMonthlyPayment = String.Format("{0:c}", MonthlyPayment);
            lblMonthlyPayment.Text = (iMonthlyPayment);
            //----------------------------------------------------------------------------------------------------------
            TotalPayment = MonthlyPayment * NumberOfYear * 12;
            iTotalPayment = String.Format("{0:c}", TotalPayment);
            lblTotalPayment.Text = (iTotalPayment);

            txtAmountLoan.Text = String.Format("{0:c}", LoanAmount);


        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            rtfReceipt.AppendText("Loan Management Systems Calculator" + "\n");
            rtfReceipt.AppendText("-------------------------------------------------" + "\n");
            rtfReceipt.AppendText("Enter amount of loan" + "\t" + txtAmountLoan.Text + "\n");
            rtfReceipt.AppendText("Enter number of year" + "\t" + txtNumberOfYear.Text + "\n");
            rtfReceipt.AppendText("Enter Interest Rate" + "\t" + txtInterestRate.Text + "\n");
            rtfReceipt.AppendText("Monthly Payment" + "\t" + lblMonthlyPayment.Text + "\n");
            rtfReceipt.AppendText("Total Payment" + "\t" + lblTotalPayment.Text + "\n");
            rtfReceipt.AppendText("---------------------------------------------------" + "\n");
            rtfReceipt.AppendText("-------------------------Thank You------------------------" + "\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to save the Receipt?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                    System.IO.File.WriteAllText(dialog.FileName, rtfReceipt.Text);

                return;
            }






        }


        private void btnXml_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to open  Receipt file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
               
            }
            if (result == DialogResult.Yes)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                   rtfReceipt.Text =  System.IO.File.ReadAllText(dialog.FileName);
                }
                
                return;
            }
           
        }


        int NumberOfYear;
        string iMonthlyPayment, iTotalPayment;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
