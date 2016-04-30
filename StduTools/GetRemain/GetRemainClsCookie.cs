using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace StduTools
{
    class GetRemainClsCookie
    {
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="number">学号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static CookieContainer GetCookie(string number,string pwd)
        {
            //获取网页源码
            CookieContainer cookie = new CookieContainer();
            string PageHtml = ClsHttp.PostHttp("http://info.stdu.edu.cn/index.php","",ref cookie);
            //正则分离参数
            //return分离
            string Rreturn = Regex.Replace(Regex.Replace(Regex.Match(PageHtml, "<input type=\"hidden\" name=\"return\" value=\"(.*?)\" />").Value, "<input type=\"hidden\" name=\"return\" value=\"",""), "=\" />","")+"%3D";
            //随机数分离
            string Rrad = Regex.Replace(Regex.Replace(Regex.Match(PageHtml, "<input type=\"hidden\" name=\"(.*?)\" value=\"1\" />").Value, "<input type=\"hidden\" name=\"",""), "\" value=\"1\" />","");
            string PostData = "username=" + number + "&remember=yes&password=" + pwd + "&Submit=%E7%99%BB%E5%BD%95&option=com_users&task=user.login&return=" + Rreturn + "&" + Rrad + "=1";
            
            PageHtml = ClsHttp.PostHttp("http://info.stdu.edu.cn/index.php", PostData, ref cookie);

            //网页内容返回给全局静态变量
            frmGetRemain.Html = PageHtml;
            return cookie;
        }


        /// <summary>
        /// 遍历CookieContainer
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }

        /// <summary>
        /// 判断是否登陆成功
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static bool IsReady(CookieContainer cookie)
        {
            string PageHtml = ClsHttp.PostHttp("http://info.stdu.edu.cn/index.php/component/gatewayinformation/?view=gatewayinformation", "",ref cookie);
            if (Regex.IsMatch(PageHtml, "您好"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
