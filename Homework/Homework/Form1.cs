using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Init();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal prec = (decimal)this.GetTaxPercentage();

            string amountText = this.txtAmount.Text;
            //decimal amount = Convert.ToDecimal(amountText);
            decimal amount;


            if(prec == 0)
            {
                this.labTaxTypeMA.Text = "請正確輸入下拉選單";
                this.labTaxTypeMA.Visible = true;
            }

            if(decimal.TryParse(amountText, out amount))
            {
                this.label4.Text = "請輸入金額";
                this.label4.Visible = true;
            }

            decimal result = amount * prec;

            if (result < 1)
            {
                result = 0;
            }
            else if (result > 1)
            {
                result = Math.Truncate(result);
            }
            this.lblResult.Text = $"{result.ToString("#,0")} 元";
        }

        private void Init()
        {
            this.txtAmount.Text = "0";
            this.cbxType.SelectedIndex = 0;
            this.lblResult.Text = "0元";
        }

        private double GetTaxPercentage()
        {
            if(this.cbxType.SelectedIndex == -1)
            {
                return 0;
            }

            string taxType = this.cbxType.Text;

            switch(taxType)
            {
                case "1":
                   return 0.004;

                case "2":
                    return 0.001;

                case "3":
                    return 0.001;

                default:
                    return 0;
            }
        }
    }
}
