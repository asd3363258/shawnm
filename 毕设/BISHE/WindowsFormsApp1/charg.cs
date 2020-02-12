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
    public partial class charg : Form
    {
        public charg()
        {
            InitializeComponent();

            timer1.Start();

            RefreshTimer.Start();

            //GridSetting();
        
            BAL.DP_Form Getdata = new BAL.DP_Form();

            Getdata.UPdataSQL_Timer();

            SourceBind(0);

            SettingTime();

       }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void charg_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
        private void GridSetting()
        {
            /*for (int i = 0; i < 100; i++)
            {
                DataGridViewRow Row = new DataGridViewRow();
                GridView.Rows.Add(Row);

                //int index = GridView.Rows.Add();
                GridView.Rows[i].Cells[0].Value = i + 1;
                //GridView.Rows.Insert(2, Row);
            }

           /*   (int rowcount = 0; rowcount < 100; rowcount++)
            {
                //index = GridView.Rows.Add(Row);
               GridView.Rows[0].Cells[rowcount].Value = rowcount + 1;
            }
            */
        }

        public void SettingTime()
        {
            int count = 0;

            for (count = 0; count < 100; count++)
            {
                if (GridView.Rows[count].Cells[1].Value.ToString().Trim() != "")
                {
                    int IntTempValue = Convert.ToInt32(GridView.Rows[count].Cells[4].Value);

                    string strValue = "";

                    if (IntTempValue / 1440 >= 1)
                    {

                        if (IntTempValue % 1440 == 0)
                        {
                            GridView.Rows[count].Cells[4].Value = (IntTempValue / 1440).ToString() + "天" + "0小时0分钟";
                        }
                        else
                        {
                            strValue = (IntTempValue / 1440).ToString() + "天";

                            if ((IntTempValue - 1440 * (IntTempValue / 1440)) % 60 == 0)
                            {
                                strValue += (IntTempValue - 1440 * (IntTempValue / 1440)) / 60 + "小时0分钟";

                                GridView.Rows[count].Cells[4].Value = strValue;
                            }
                            else
                            {
                                strValue += (IntTempValue - 1440 * (IntTempValue / 1440)) / 60 + "小时";
                                strValue += (IntTempValue - 1440 * (IntTempValue / 1440)) % 60 + "分钟";

                                GridView.Rows[count].Cells[4].Value = strValue;
                            }

                        }

                    }
                    else
                    {
                        if (IntTempValue % 60 == 0)
                        {   
                            strValue += "0天" + (IntTempValue - 1440 * (IntTempValue / 1440)) / 60 + "小时0分钟";

                            GridView.Rows[count].Cells[4].Value = strValue;
                        }
                        else
                        {
                            strValue += "0天";
                            strValue += IntTempValue / 60 + "小时";
                            strValue += IntTempValue % 60 + "分钟";

                            GridView.Rows[count].Cells[4].Value = strValue;

                        }
                    }
                }
            }
        }

        private void Land_Click(object sender, EventArgs e)
        {
            Form LandFrom = new Form();
            LandFrom.ShowDialog();
        }

        private void GridView_ColumnDataPropertyNameChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void 上机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RowIndex = GridView.CurrentRow.Index;

            Land LandFrom = new Land(RowIndex);
            LandFrom.StartPosition = FormStartPosition.CenterScreen;
            LandFrom.ShowDialog(this);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Registration_Click(object sender, EventArgs e)
        {
            Registration RegistrationForm = new Registration();
            RegistrationForm.StartPosition = FormStartPosition.CenterScreen;
            RegistrationForm.ShowDialog();
        }

        //当上机后刷新grid
        public void RefreshDataGrid(string Number, string Name, string ID)
        {
           
            //int RowIndex = GridView.CurrentRow.Index;

            //GridView.Rows[RowIndex].Cells[1].Value = Number;
            //GridView.Rows[RowIndex].Cells[2].Value = Name;
           // GridView.Rows[RowIndex].Cells[3].Value = DateTime.Now.ToString();


        }

        public void SourceBind(int RowIndex)
        {
            BAL.DP_Form Getdata = new BAL.DP_Form();

            GridView.DataSource = Getdata.GetDataSet().Tables[0].DefaultView;

            //不允许用户点击列名自动排序
            for (int Intcount = 0; Intcount < GridView.Columns.Count; Intcount++)
            {
                GridView.Columns[Intcount].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            GridView.ClearSelection();
            GridView.Rows[RowIndex].Selected = true;

            GridView.CurrentCell = GridView.Rows[RowIndex].Cells[1];
            GridView.CurrentRow.Selected = true;
        }


        private void 下机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BAL.DP_Form UpdateSQL = new BAL.DP_Form();

            int RowIndex = GridView.CurrentRow.Index;

            if(UpdateSQL.UpdataSQL_LogOut(RowIndex + 1) == true)
            {
                MessageBox.Show("下机成功");
            }
            else
            {
                MessageBox.Show("下机失败");
            }

            //重新刷新Grid
            this.SourceBind(RowIndex);

            this.SettingTime();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {


            BAL.DP_Form Getdata = new BAL.DP_Form();

            Getdata.UPdataSQL_Timer();

            int RowIndex = GridView.CurrentRow.Index;

            this.SourceBind(RowIndex);

            SettingTime();

        }
    }
}
