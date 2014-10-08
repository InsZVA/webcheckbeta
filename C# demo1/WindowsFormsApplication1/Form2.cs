using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace NetCheck
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string strId = textBox2.Text;//用户名
            //string strsubmit = "YES";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "user=" + strId;

            byte[] data = encoding.GetBytes(postData);
            // Prepare web request...
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.inszva.tk/loginsys/test_count.php");//在此输入您的网站后台验证php
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            textBox1.Text = content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strId = textBox2.Text;//用户名
            //string strsubmit = "YES";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "user=" + strId;
            postData += ("&num=" + 1);//在此输入您需要扣的费用数量
            
            byte[] data = encoding.GetBytes(postData);
            // Prepare web request...
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.inszva.tk/loginsys/test_buy.php");//在此输入您的网站后台验证php
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            textBox1.Text = content;
        }
    }
}
