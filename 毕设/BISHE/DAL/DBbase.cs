using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;

namespace DAL
{
    public class DBbase
    {
        //读取配置文件 连接数据库语句  
        public static string strCon = "Data Source=(local);Initial Catalog=BiShe;Integrated Security=TRUE;";
        //public static string strCon = "Data Source=.;Initial Catalog=threeLayer;Persist Security Info=True;User ID=sa;Password=123";  

        //实例化连接对象 con  
        SqlConnection con = new SqlConnection(strCon);

        //检测连接是否打开  
        public void chkConnection()
        {
            if (this.con.State == ConnectionState.Closed)
            {
                this.con.Open();
            }
        }

        //执行语句，返回该语句查询的数据行的总行数  
        public int returnRowCount(string strSQL)
        {
            chkConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0].Rows.Count;
            }
            catch
            {
                return 0;
            }
        }

        public bool UpdateSQL(string strSQL,string strSQL_update)
        {
            chkConnection();
            try
            {

                SqlCommand update = new SqlCommand(strSQL, con);

                SqlCommand update_grid = new SqlCommand(strSQL_update,con);

                if(update.ExecuteNonQuery() == 1 && update_grid.ExecuteNonQuery () ==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                return false;
                
            }
        }

        public void UpdateSQL(string strSQL)
        {
            chkConnection();
            try
            {

                SqlCommand update = new SqlCommand(strSQL, con);

                update.ExecuteNonQuery();            

            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }
        }

        public bool UpdateSQL_LogOut(string strSQL)
        {
            chkConnection();
            try
            {

                SqlCommand update = new SqlCommand(strSQL, con);

                if (update.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return false;

            }
        }

        public System.Data.DataSet GetDataSet(string strSQL)
        {
            chkConnection();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                    
                return ds;
            }
            catch
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }

        public System.Data.DataTable GetDataTable(string strSQL)
        {
            chkConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }

    }
}