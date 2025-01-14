using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace NetHangfireDB
{
    public class NetHangfireDBContextFactory : IDesignTimeDbContextFactory<NetHangfireDBContext>
    {
        public NetHangfireDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NetHangfireDBContext>();
            //optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;initial catalog=NetHangfireDB;Integrated Security=True;Trusted_Connection=True;Encrypt=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlite("Data Source=localdb.sqlite");
            return new NetHangfireDBContext(optionsBuilder.Options);
        }
    }

}
