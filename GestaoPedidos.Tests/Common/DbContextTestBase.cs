using GestaoPedidos.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedidos.Tests.Common
{
    public class DbContextTestBase
    {
        protected GestaoPedidosDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<GestaoPedidosDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GestaoPedidosDbContext(options);
        }
    }
}
