namespace Core.Persistence.Repositories.abstracts;

public interface IQuery<T>
{
    IQueryable<T> Query();
}