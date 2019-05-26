using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDCardTool.Common
{
    /// <summary>
    /// 随机工具类
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 生成随机种子
        /// </summary>
        /// <returns></returns>
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
