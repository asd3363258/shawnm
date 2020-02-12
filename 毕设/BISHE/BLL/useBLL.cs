using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class userBLL
    {

        userDAL.userDAL d_userAccess = new userDAL.userDAL();

        public int userLogin(Model.UserInfo m_userInfo)//把model层的值传过来进行比对
        {
            return d_userAccess.userLogin(m_userInfo.username, m_userInfo.password);//如果有返回值则登录成功
        }
    }
}
