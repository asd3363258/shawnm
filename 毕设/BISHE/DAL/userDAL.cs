using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using System.Data.SqlClient;


namespace userDAL
{
    public class userDAL

    {
        //实例化DBbase 对象  
        DAL.DBbase db = new DAL.DBbase();

        //用户登录的方法  
        public int userLogin(string name, string psw)
        {
            string strsql = "select * from users where username = '" + name + "' and password = '" + psw + "'";
            return db.returnRowCount(strsql);
        }
    }
}