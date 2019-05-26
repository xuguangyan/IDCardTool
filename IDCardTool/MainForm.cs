using IDCardTool.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IDCardTool
{
    public partial class MainForm : Form
    {
        //1-17各位相乘因子F，下标为位序0-16
        private int[] arrFactor = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        //余数-校验码对照表，下标为余数0-10
        private char[] arrTrans = { '1', '0', 'x', '9', '8', '7', '6', '5', '4', '3', '2' };
        //行政区划数据
        private DistrictData district = null;

        public MainForm()
        {
            InitializeComponent();

            district = new DistrictData();

            string rndIdCard = generateIdCard(0, 1, 80);
            txtIDCard.Text = rndIdCard;

            comBoxAge.SelectedIndex = 0;
        }

        //查询（验证）身份证
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string idCard = txtIDCard.Text;
            string areaCode = "", birthday = "", sexType = "", verifyCode = "";

            //证件号码类型
            int idCardType = -1;
            //15位身份证号
            string pattern1 = "^[1-9]\\d{7}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}$";
            //18位身份证号
            string pattern2 = "^[1-9]\\d{5}[1-9]\\d{3}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}([0-9]|X|x)$";
            Match match1 = Regex.Match(idCard, pattern1);
            if (match1.Success)
            {
                idCardType = 1;
                areaCode = idCard.Substring(0, 6);  //省市地区
                birthday = "19" + idCard.Substring(6, 6);  //出生日期（如64年）
                sexType = idCard.Substring(14, 1);  //性别（奇数表示男性，偶数表示女性）
                verifyCode = "";    //校验码
            }

            Match match2 = Regex.Match(idCard, pattern2);
            if (match2.Success)
            {
                idCardType = 2;
                areaCode = idCard.Substring(0, 6);//省市地区
                birthday = idCard.Substring(6, 8);//出生日期（如1964年）
                sexType = idCard.Substring(16, 1);      //性别（奇数表示男性，偶数表示女性）
                verifyCode = idCard.Substring(17, 1);   //校验码
            }

            if (idCardType == -1)
            {
                MessageBox.Show("身份证格式有误！");
                return;
            }

            if (idCardType == 2 && chkVerify.Checked)
            {
                bool isCheckOk = chkVerifyCode(idCard);
                if (!isCheckOk)
                {
                    MessageBox.Show("身份证校验出错！");
                    return;
                }
            }

            string areaName = district.findNameByCode(areaCode);

            txtResult.AppendText("证号：" + idCard + "\r\n");
            txtResult.AppendText("性别：" + getSex(sexType) + "  ");
            txtResult.AppendText("出生：" + birthday + "\r\n");
            txtResult.AppendText("签发：" + areaName + "\r\n");
            txtResult.AppendText("============================\r\n\r\n");
        }

        /// <summary>
        /// 18位身份证效验
        /// </summary>
        /// <param name="idCard">证件号码</param>
        /// <returns></returns>
        private bool chkVerifyCode(string idCard)
        {
            //拆散号码为字符数组，下标范围0-17
            char[] arrNumber = idCard.ToCharArray();

            int sum = 0;
            for (int i = 0; i < arrFactor.Length; i++)
            {
                int val = int.Parse(new string(arrNumber, i, 1));
                sum += val * arrFactor[i];
            }
            int remainder = sum % 11;
            char verifyCode = arrTrans[remainder];

            return verifyCode == char.ToLower(arrNumber[17]);
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="setType">性别类型（奇数表示男性，偶数表示女性）</param>
        /// <returns></returns>
        private string getSex(string setType)
        {
            int num = int.Parse(setType);
            if (num % 2 == 1)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        }

        //随机生成身份证
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int sexType = -1;
            if (chkMale.Checked && chkFemal.Checked)
            {
                sexType = 0;
            }
            else if (chkMale.Checked && !chkFemal.Checked)
            {
                sexType = 1;
            }
            else if (!chkMale.Checked && chkFemal.Checked)
            {
                sexType = 2;
            }
            if (sexType == -1)
            {
                MessageBox.Show("请至少选择一种性别");
                return;
            }

            int startAge = 1, endAge = 80;

            switch (comBoxAge.SelectedIndex)
            {
                case 1:
                    startAge = 1;
                    endAge = 18;
                    break;
                case 2:
                    startAge = 18;
                    endAge = 25;
                    break;
                case 3:
                    startAge = 25;
                    endAge = 40;
                    break;
                case 4:
                    startAge = 40;
                    endAge = 80;
                    break;
                default:
                    break;
            }

            txtResult.AppendText("===生成随机身份证bigin===\r\n");
            int count = int.Parse(txtNum.Text);
            for (int i = 0; i < count; i++)
            { 
                string rndIdCard = generateIdCard(sexType, startAge, endAge);
                txtResult.AppendText(rndIdCard + "\r\n");
            }
            txtResult.AppendText("===生成随机身份证end===\r\n\r\n");
        }

        /// <summary>
        /// 生成随机身份证
        /// </summary>
        /// <param name="sexType">性别类型（1.男 2.女 3.全部）</param>
        /// <param name="startAge">开始岁数</param>
        /// <param name="endAge">截止岁数</param>
        /// <returns></returns>
        private string generateIdCard(int sexType, int startAge, int endAge)
        {
            string areaCode = district.getRndAreaCode();
            string birthday = getRndBirthday(startAge, endAge);
            string serialNum = getRndSerialNum();
            string sexNum = getRndSexNum(sexType);
            string idCard = areaCode + birthday + serialNum + sexNum;
            idCard += getVerifyCode(idCard);

            return idCard;
        }

        /// <summary>
        /// 生成随机性别位数字，1位[17]
        /// </summary>
        /// <param name="sexType">性别类型（1.男 2.女 3.全部）</param>
        /// <returns></returns>
        private string getRndSexNum(int sexType)
        {
            int[] arrMale = { 1, 3, 5, 7, 9, 1, 3, 5, 7, 9 };
            int[] arrFeMal = { 0, 2, 4, 6, 8, 0, 2, 4, 6, 8 };

            Random random = new Random(RandomHelper.GetRandomSeed());
            int rndNum = random.Next(10);
            if (sexType == 1)
            {
                rndNum = arrMale[rndNum];
            }
            else if (sexType == 2)
            {
                rndNum = arrFeMal[rndNum];
            }
            return rndNum.ToString();
        }

        /// <summary>
        /// 生成随机出生日期，8位[7-14]
        /// </summary>
        /// <param name="startAge">开始岁数</param>
        /// <param name="endAge">截止岁数</param>
        /// <returns></returns>
        private string getRndBirthday(int startAge, int endAge)
        {
            DateTime startTime = DateTime.Now.AddYears(-endAge);
            DateTime endTime = DateTime.Now.AddYears(-startAge);
            TimeSpan ts = endTime.Subtract(startTime);
            int range = ts.Days;

            Random random = new Random(RandomHelper.GetRandomSeed());
            int rndNum = random.Next(range);
            DateTime rndTime = startTime.AddDays(rndNum);
            return rndTime.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 生成随机流水号（派出所代码），2位[15-16]
        /// </summary>
        /// <returns></returns>
        private string getRndSerialNum()
        {
            Random random = new Random(RandomHelper.GetRandomSeed());
            int rndNum = random.Next(100);
            string retVal = rndNum < 10 ? "0" + rndNum : rndNum.ToString();
            return retVal;
        }

        /// <summary>
        /// 获取效验位数字
        /// </summary>
        /// <param name="idCard">证件号码</param>
        /// <returns></returns>
        private string getVerifyCode(string idCard)
        {
            //拆散号码为字符数组，下标范围0-17
            char[] arrNumber = idCard.ToCharArray();

            int sum = 0;
            for (int i = 0; i < arrFactor.Length; i++)
            {
                int val = int.Parse(new string(arrNumber, i, 1));
                sum += val * arrFactor[i];
            }
            int remainder = sum % 11;
            char verifyCode = arrTrans[remainder];

            return verifyCode.ToString();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            district.CompressFile();
            MessageBox.Show("操作成功！");
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            district.DeCompressFile();
            MessageBox.Show("操作成功！");
        }

        private void txtResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnCompress.Visible = true;
                btnDecompress.Visible = true;
            }
        }
    }
}
