using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Land : Form
    {

        public int RowIndex = 0; 

        public Land(int RowIndex)
        {
            InitializeComponent();

            this.RowIndex = RowIndex;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAL.DP_Form Land = new BAL.DP_Form();

            decimal flBalance = 0;

            string strNumber = "";

            flBalance = Convert.ToDecimal(Land.GetDataTable(IDText.Text.ToString()).Rows[0][1]);

            strNumber = Convert.ToString(Land.GetDataTable(IDText.Text.ToString()).Rows[0][0]);

            if (flBalance >= 5)
            {
                if (Land.UpdataSQL_Land(RowIndex + 1, strNumber, NameText.Text.ToString(), IDText.Text.ToString(),flBalance) == true)
                {

                    MessageBox.Show("成功");

                    charg ChargForm = (charg)this.Owner;

                    ChargForm.SourceBind(RowIndex);

                    ChargForm.SettingTime();
                }
                else
                {
                    MessageBox.Show("不成功");
                }
            }
            else
            {
                if (flBalance <= 0)
                {
                    MessageBox.Show("余额剩余为 0"  + "元,请及时充值");

                }
                else
                {
                    MessageBox.Show("余额剩余不到 " + flBalance + "元,请及时充值");
                    if (Land.UpdataSQL_Land(RowIndex + 1, strNumber, NameText.Text.ToString(), IDText.Text.ToString(), flBalance) == true)
                    {

                        MessageBox.Show("成功");

                        charg ChargForm = (charg)this.Owner;

                        ChargForm.SourceBind(RowIndex);

                        ChargForm.SettingTime();
                    }
                    else
                    {
                        MessageBox.Show("不成功");
                    }
                }
            }
        }
    }
}
