using AUD9001.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly AUD9001StorageContext context;

        public QueryExecutor(AUD9001StorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
