using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisLockSkills.Clients
{
    /// <summary>
    /// 客户端对象
    /// </summary>
    class RmClient
    {
        /// <summary>
        /// 用户秒杀
        /// </summary>
        public static void Skills(int threadCount)
        {
            // 1、商品秒杀对象
            ProductSkill productSkill = new ProductSkill();

            // 2、创建20个请求来秒杀
            for (int i = 0; i < threadCount; i ++)
            {
                Thread thread = new Thread(() => {

                    productSkill.SkillProduct();
                });

                thread.Start();
            }
           
        }
    }
}
