using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ekkleisa.Repository.Implementation.Context
{
    public class EkklesiaContext
    {
        private readonly string _connectionString;

        public EkklesiaContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EkklesiaConnection");
        }
    }
}
