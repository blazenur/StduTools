using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace StduTools
{
    class ClsTools
    {
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 检测网络连接状态
        /// </summary>
        public static bool IsNetReady()
        {
            bool success;
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                //测试网络连接：目标计算机为192.168.1.1(可以换成你所需要的目标地址）
                //如果网络连接成功，PING就应该有返回；否则，网络连接有问题
                PingReply reply = pingSender.Send("info.stdu.edu.cn", timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch
            {
                success = false;
            }
            return success;
        }
    }
}
