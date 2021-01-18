using Microsoft.Extensions.Configuration;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Repository
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(PhamaMicroCrmContext context, IConfiguration configuration) : base(context, configuration) { }
    }
}
