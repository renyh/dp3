using DigitalPlatform.LibraryRestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp2analysis.service
{
    public class dp2analysisService
    {
        #region 单一实例

        static dp2analysisService _instance;
        private static object _lock = new object();
        static public dp2analysisService Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_lock)  //线程安全的
                    {
                        _instance = new dp2analysisService();
                    }
                }
                return _instance;
            }
        }

        // 构造函数
        private dp2analysisService()
        {

        }

        #endregion

        
        #region 按需登录
        internal LibraryChannelPool _libraryChannelPool = new LibraryChannelPool();

        public string dp2ServerUrl { get; set; }
        public string dp2Username { get; set; }
        public string dp2Password { get; set; }
        void _channelPool_BeforeLogin(object sender, BeforeLoginEventArgs e)
        {
            if (string.IsNullOrEmpty(this.dp2Username))
            {
                e.Cancel = true;
                e.ErrorInfo = "尚未登录";
            }

            e.LibraryServerUrl = this.dp2ServerUrl;
            e.UserName = this.dp2Username;
            e.Parameters = "type=worker,client=dp2analysis|0.01";
            e.Password = this.dp2Password;
        }

        public void ReturnChannel(LibraryChannel channel)
        {
            this._libraryChannelPool.ReturnChannel(channel);
        }



        #endregion
    

        #region 检查dp2帐户是否存在

        //检查帐户是否存在
        public int Verify(string serverUrl,string userName, string passord, out string error)
        {
            error = "";

            LibraryChannel channel = this._libraryChannelPool.GetChannel(serverUrl,
                userName);
            try
            {



                LoginResponse response = channel.Login(userName,
                passord,
                "type=worker,client=dp2analysis|0.01");

                if (response.LoginResult.Value == -1 || response.LoginResult.Value == 0)
                {
                    error = "用户名或者密码不存在";
                    return 0;
                }

                //if ((int)ret.LoginResult.ErrorCode != 1)
                //{
                //    error = "用户名或者密码不存在";
                //    return 0;
                //}

                return 1;

            }
            finally
            {
                this.ReturnChannel(channel);
            }
        }

        #endregion
    }
}
