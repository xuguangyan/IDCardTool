using IDCardTool.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace IDCardTool
{
    class DistrictData
    {
        //全量数据表（含历史区划）
        private DataTable district = new DataTable("district");
        //新版数据表
        private DataTable district_new = new DataTable("district_new");

        string filename = AppDomain.CurrentDomain.BaseDirectory + "\\district_data.txt";
        string filename_new = AppDomain.CurrentDomain.BaseDirectory + "\\district_new.txt";

        string datfile = AppDomain.CurrentDomain.BaseDirectory + "\\district_data.dat";
        string datfile_new = AppDomain.CurrentDomain.BaseDirectory + "\\district_new.dat";

        public DistrictData()
        {
            district.Columns.Add("code", Type.GetType("System.String"));
            district.Columns.Add("name", Type.GetType("System.String"));

            district_new.Columns.Add("code", Type.GetType("System.String"));
            district_new.Columns.Add("name", Type.GetType("System.String"));

            //loadData(district, filename);
            //loadData(district_new, filename_new);
            loadZipData(district, datfile);
            loadZipData(district_new, datfile_new);
        }

        /// <summary>
        /// 通过text文件装载数据
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="filename">文件路径</param>
        private void loadData(DataTable dt, string filename)
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() == "")
                    {
                        continue;
                    }
                    try
                    {
                        string[] cols = line.Split('\t');
                        dt.Rows.Add(new string[] { cols[0], cols[1] });
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// 通过dat(压缩)文件装载数据
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="filename">压缩文件路径</param>
        private void loadZipData(DataTable dt, string filename)
        {
            byte[] rawData = File.ReadAllBytes(filename);
            byte[] outData = ZipHelper.Decompress(rawData);
            MemoryStream mm = new MemoryStream(outData);

            using (StreamReader sr = new StreamReader(mm))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() == "")
                    {
                        continue;
                    }
                    try
                    {
                        string[] cols = line.Split('\t');
                        dt.Rows.Add(new string[] { cols[0], cols[1] });
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// 根据地区代码查找地名
        /// </summary>
        /// <param name="code">地区代码</param>
        /// <returns></returns>
        public string findNameByCode(string code)
        {
            string name = "";
            DataRow[] rows = district.Select("code like '%" + code + "%'");
            if (rows.Length > 0)
            {
                name = rows[0]["name"].ToString();
            }
            return name;
        }

        /// <summary>
        /// 根据地区名称查找代码
        /// </summary>
        /// <param name="name">地区名称</param>
        /// <returns></returns>
        public string findCodeByName(string name)
        {
            string code = "";
            DataRow[] rows = district.Select("name like '%" + name + "%'");
            if (rows.Length > 0)
            {
                code = rows[0]["code"].ToString();
            }
            return code;
        }

        /// <summary>
        /// 获取随机地区代码
        /// </summary>
        /// <returns></returns>
        public string getRndAreaCode()
        {
            string code = "";
            int count = district_new.Rows.Count;
            if (count > 0)
            {
                Random random = new Random(RandomHelper.GetRandomSeed());
                int rndNum = random.Next(count);
                code = district_new.Rows[rndNum]["code"].ToString();
            }
            return code;
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        public void CompressFile()
        {
            byte[] rawData1 = File.ReadAllBytes(filename);
            byte[] outData1 = ZipHelper.Compress(rawData1);
            File.WriteAllBytes(datfile, outData1);

            byte[] rawData2 = File.ReadAllBytes(filename_new);
            byte[] outData2 = ZipHelper.Compress(rawData2);
            File.WriteAllBytes(datfile_new, outData2);
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        public void DeCompressFile()
        {
            byte[] rawData1 = File.ReadAllBytes(datfile);
            byte[] outData1 = ZipHelper.Decompress(rawData1);
            File.WriteAllBytes(filename, outData1);

            byte[] rawData2 = File.ReadAllBytes(datfile_new);
            byte[] outData2 = ZipHelper.Decompress(rawData2);
            File.WriteAllBytes(filename_new, outData2);
        }
    }
}
