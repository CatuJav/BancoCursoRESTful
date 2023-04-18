using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository;

public class MyRepositoryAsync<T>:RepositoryBase<T>, IRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext dbsContext;

    public MyRepositoryAsync(ApplicationDbContext dbsContext):base(dbsContext)
    {
        this.dbsContext = dbsContext;
    }

    
}