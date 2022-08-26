using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;

namespace ccgo_bluetooth_tool {
    class SetDataManage {
        private string filePath = "seting.txt";
        private static readonly Object LockObj = new object();
        private string host = "https://zhihuiwulian.com";


        public string readSetStr()
        {
            if (!File.Exists(filePath)) {
                return null;
            }

            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null) {
                sr.Close();
                return line;
            }
            sr.Close();
            return null;
        }

        public void writeSetStr(string csq_shold, string gps_num, string gps_shold, string wifi_shold, int platformIndex, int comIndex)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            string resultValue = csq_shold + "," + gps_num + "," + gps_shold + "," + wifi_shold + "," + platformIndex + "," + comIndex;
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(resultValue);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public void writeErrorLog(Exception e)
        {
            DebugLog(e.ToString());
        }

        public void DebugLog(string log)
        {
            lock (LockObj) {
                string path = "error.log";
                FileStream fs = new FileStream(path, FileMode.Append);
                byte[] data = Encoding.Default.GetBytes(log+"\r\n");
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
        }

        public string uploadDeviceInfo2Cloud(string imei, string mac)
        {
            String url = host + "/api/open/device/bindMac2ByImei?imei=" + imei+"&mac="+mac;
            try {

                HttpWebResponse res = createPostRequest(url, null, null, null);
                if (res == null) {
                    return "出错了,可能是由于您的网络环境差、不稳定或安全软件禁止访问网络，您可在网络好时或关闭安全软件再重新访问网络。";
                } else {
                    string result = getResponseString(res);
                    Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    if ("0000".Equals(dic["code"].ToString())) {
                        return "提交成功！";
                    }
                    return dic["message"].ToString();
                }
            } catch (Exception ex) {
                writeErrorLog(ex);
                return "解析提交结果发生未知异常！";
            }
        }

        // 创建POST方式的HTTP请求  
        public HttpWebResponse createPostRequest(string url, IDictionary<string, string> parameters, CookieCollection cookies, string companyId = null)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase)) {
                request = WebRequest.Create(url) as HttpWebRequest;
            } else {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/json";
            if (cookies != null) {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //发送POST数据  
            if (parameters != null && parameters.Count != 0) {
                byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(parameters));
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }


        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public string getResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream()) {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}
