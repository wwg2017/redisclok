
using MyRedisLockSkills.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisLockSkills
{
    /// <summary>
    /// 今天我们学习高性能，高并发场景下的分布式锁。上课时间20:05--21:30
    /// 多线程 
    /// 共享资源（对象，方法，属性）的问题？ lock 机制
    /// 1、同一时刻，只允许一个线程在操作共享资源
    /// 线程===进程
    /// 
    /// 学习过分布式系统的同学，打个1
    /// 没有学习过分布式系统的同学，打个2
    /// 
    /// SOA 
    /// 事务
    /// 锁
    /// 1、分布式锁介绍
    /// 分布式锁是控制分布式系统之间同步访问共享资源的一种方式，简单说来，就是锁进程
    /// 换一句话，就是同一时刻，只允许分布式系统中的一个系统在访问共享资源（对象，方法，属性）
    /// 
    /// 例如：锁进程
    /// 
    /// 为什么要学习使用分布式锁？
    /// 1、自身方面
    ///     分布式系统相关的知识，事务和锁机制。面试
    ///     
    /// 2、业务方面
    ///     2.1、淘宝京东
    ///     2.2、分布式系统，如果说你们遇到了系统之间存在共享数据的时候，保证数据安全的时候，你们是怎么解决的呢？
    ///     必须通过锁机制来解决
    ///     
    ///     例如：分布式电商业务系统
    ///     
    /// 
    /// 2、分布式锁如何实现
    /// 3、淘宝，京东电商中的是如何实现和运用分布锁机制
    /// 
    /// 没有使用过redis同学，打个1
    /// 使用过redis同学，打个2
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎大家来软谋.net vip体验课的学习，我是tony老师");

            Console.WriteLine("***********************高性能，高并发场景下的分布式锁**********************");

            // 1、秒杀
            RmClient.Skills(20);

            Console.ReadKey();
        }
    }
}
