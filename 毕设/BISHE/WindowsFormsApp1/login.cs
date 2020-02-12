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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //实例化model层中 userinfo类中用于传递数据

        Model.UserInfo m_userinfo = new Model.UserInfo();

        BAL.userBLL b_userAccess = new BAL.userBLL();

        private void button1_Click(object sender, EventArgs e)
        {

            //将用户输入的账户密码赋值给userInfo类 username.psw属性

            m_userinfo.username = loginText.Text.Trim().ToString();

            m_userinfo.password = PasswordText.Text.Trim().ToString();

            //如果BLL层 useLogin调用返回记录条数 大于1则账号密码正确
            if (b_userAccess.userLogin(m_userinfo) > 0)
            {
                MessageBox.Show("登陆成功");
                
                MainMenu MainMenu = new MainMenu();

                this.Hide();

                MainMenu.Show();

            }
            else 
            {
                MessageBox.Show("登陆失败");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
