using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DA_Form
    {

        DAL.DBbase db = new DAL.DBbase();

        //查询会员数
        public int MemberNubmer()
        {
            string strsql = "SELECT * FROM member";
            return db.returnRowCount(strsql);
        }

        public bool UpdateSQL_Registration(int Number, string Name, string ID)
        {

            string strsql = " INSERT INTO member VALUES (" + Number + ",'" + Name + "','" + ID + "','" + "','" + "'" + ")";
            return db.UpdateSQL(strsql,"");
        }
        
        public int CheckRowExist_Resgistration(string ID)
        {
            //检测是否存在相同数据
            string strsql_check = " SELECT * FROM MEMBER WHERE 身份证 = '" + ID + "' ";
            return db.returnRowCount(strsql_check);
        }

        public bool UpdataSQL_Land(int RowIndex, string Number, string Name, string ID, decimal Blance)
        {
            string strsql_land = " INSERT INTO landrecord VALUES(" + Number + ",'" + Name + "','" + ID + "','" + RowIndex + "',Getdate()" +",''" + ") ";

            string strsql_updategrid = " UPDATE gridtable " + 
                                       " SET 用户卡号 = '"+ Number + "'," +" 姓名 = '" +  Name  + "'," + "开始时间 = Getdate()," + "持续时间 ='0'," + "当前消费 = 0," + "余额 = " + Blance + ""+ 
                                       " WHERE 机号 = " + RowIndex + "";
                                    
            return db.UpdateSQL(strsql_land,strsql_updategrid);
        }

        public bool UpdataSQL_LogOut(int RowIndex)
        {
            string strsql = " UPDATE gridtable " +
                            " SET 用户卡号 = '', 姓名 = '', 开始时间 = NULL,持续时间 = NULL ,当前消费 = NULL ,余额 = NULL" +
                            " WHERE 机号 = " + RowIndex + "";

            return db.UpdateSQL_LogOut(strsql);
        }

        public void UpdataSQL_Timer()
        {
            string strsql = "EXEC UpdateTime";

            db.UpdateSQL(strsql);
        }

        public System.Data.DataTable Check_Balance(string ID)
        {
            string strsql = " SELECT 用户卡号,余额 FROM member " +
                            " WHERE 身份证 = '" + ID + "'";

            return db.GetDataTable(strsql);
        }


        public System.Data.DataSet GetDataSet()
        {
            string strsql = " SELECT * FROM gridtable";
            return db.GetDataSet(strsql);
        }

    }
}
