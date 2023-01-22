using OnlineShop.DistributedLock.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DistributedLock.Configuration
{
    public static class WebApplicationConfigurations
    {
        public static void DisposeLockFactory(this IHostApplicationLifetime lifeTime)
        {
            lifeTime.ApplicationStopping.Register(() => {
                RedLockProvider.RedLockFactoryObject.Dispose();
            });
        }
    }
}
