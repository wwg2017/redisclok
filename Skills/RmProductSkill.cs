using MyRedisLockSkills.Locks;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisLockSkills
{
    /// <summary>
    /// 商品秒杀类
    /// </summary>
    class ProductSkill
    {   
        // 1、redis连接管理类
        private ConnectionMultiplexer connectionMultiplexer = null;

        // 2、redis数据操作类
        private IDatabase database = null;
        /// <summary>
        /// 秒杀方法
        /// </summary>
        public void SkillProduct()
        {
            try
            {
                RedisLock redisLock = new RedisLock();
                redisLock.Lock();
                // 1、获取商品库存
                var stocks = getPorductStocks();

                // 2、判断商品库存是否为空
                if (stocks == 0)
                {
                    // 2.1 秒杀失败消息
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}：不好意思，秒杀已结束，商品编号:{stocks}");
                    redisLock.unLock();
                    return;
                }

                // 3、秒杀成功消息
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}：恭喜你，秒杀成功，商品编号:{stocks}");

                // 4、扣减商品库存
                subtracPorductStocks();

                redisLock.unLock();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 获取商品库存
        /// </summary>
        /// <returns></returns>
        private int getPorductStocks()
        {
            connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            database = connectionMultiplexer.GetDatabase(0);
            var strint= database.StringGet("C");
            return Convert.ToInt32(strint);
        }

        /// <summary>
        /// 扣减商品库存
        /// </summary>
        private void subtracPorductStocks()
        {
            connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            database = connectionMultiplexer.GetDatabase(0);
            var strint = database.StringGet("C");
            var autoint= Convert.ToInt32(strint);
            autoint = autoint - 1;

            database.StringSet("C", autoint);
        }
    }
}
