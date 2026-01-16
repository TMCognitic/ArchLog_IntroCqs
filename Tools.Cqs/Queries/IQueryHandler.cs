using Tools.Cqs.Results;

namespace Tools.Cqs.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        CqsResult<TResult> Execute(TQuery query);
    }
}
