using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class DP_Form
    {

        DAL.DA_Form GetData = new DAL.DA_Form();

        DAL.DA_Form UpdataSQL = new DAL.DA_Form();

        DAL.DA_Form CheckRowExist = new DAL.DA_Form();
    
        public int GetMemberNumber()
        {
            return GetData.MemberNubmer();//返回会员个数

        }

        public bool UpdateSQL_Registration(int Number,string Name, string ID)
        {
            return UpdataSQL.UpdateSQL_Registration(Number, Name, ID);
        }

        public int CheckRowExist_Registration(string ID)
        {
            return CheckRowExist.CheckRowExist_Resgistration(ID);
        }

        public bool UpdataSQL_Land(int RowIndex, string Number, string Name, string ID, decimal Blance)
        {
            return UpdataSQL.UpdataSQL_Land(RowIndex, Number, Name, ID, Blance);
        }

        public bool UpdataSQL_LogOut(int RowIndex)
        {
            return UpdataSQL.UpdataSQL_LogOut(RowIndex);
        }

        public void UPdataSQL_Timer()
        {
            UpdataSQL.UpdataSQL_Timer();
        }

        public System.Data.DataSet GetDataSet()
        {
            return GetData.GetDataSet(); 
        }

        public System.Data.DataTable GetDataTable(string ID)
        {
            return GetData.Check_Balance(ID);
        }

    }
}
