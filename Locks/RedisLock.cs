using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisLockSkills.Locks
{
    /// <summary>
    /// redis分布式锁
    /// 分布式锁四要素
    /// 1、锁名 === 锁标识
    /// 2、加锁操作 === 去获取锁
    /// 3、解锁操作 === 释放锁 === 让其他线程能够去执行
    /// 4、锁超时时间 ==== 解锁是死锁问题
    /// </summary>
    class RedisLock
    {
        // 1、redis连接管理类
        private ConnectionMultiplexer connectionMultiplexer = null;

        // 2、redis数据操作类
        private IDatabase database = null;
        public RedisLock()
        {
            connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");

            database = connectionMultiplexer.GetDatabase(0);
        }

        /// <summary>
        /// 加锁
        /// </summary>
        public void Lock()
        {
            // 1、如何加锁
            //1.1 锁名 
            //1.2 锁对象 谁获取锁
            //1.3 锁超时时间 防止死锁
            while (true)
            {
                bool flag = database.LockTake("skill_key", Thread.CurrentThread.ManagedThreadId, TimeSpan.FromSeconds(100));

                if (flag)
                {
                    break;
                }
                // while 会导致什么后果？
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void unLock()
        {
            // 1、解锁
            bool flag = database.LockRelease("skill_key", Thread.CurrentThread.ManagedThreadId);

            // 2、释放资源
            connectionMultiplexer.Close();
        }

    }
}
