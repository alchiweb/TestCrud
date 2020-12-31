using AutoMapper;
using AutoMapper.QueryableExtensions;
using JqueryDataTables.ServerSide.AspNetCoreWeb;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestCrud.Models;
using Microsoft.AspNetCore.Mvc;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Infrastructure;
// using TestCrud.Api.Models;

namespace TestCrud.Services
{
    public class DataApiService : IDataApiService
    {
        private readonly IConfigurationProvider _mappingConfiguration;

        public DataApiService(IConfigurationProvider mappingConfiguration)
        {
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<JsonResult> GetDataAsync(IQueryable<object> dbset, JqueryDataTablesParameters param)
        {
            switch (dbset)
            {
                // case IQueryable<Chauffeur> chauffeurs:
                //     return await GetDataAsync<Chauffeur, ChauffeurApi>(chauffeurs, param);
                default:
                    await Task.CompletedTask;
                    return null;
            }
        }


        public async Task<JsonResult> GetDataAsync<TEntity, TEntityApi>(IQueryable<TEntity> query, JqueryDataTablesParameters param) where TEntity : class
        {

            query = SearchOptionsProcessor<TEntityApi, TEntity>.Apply(query, param.Columns);
            query = SortOptionsProcessor<TEntityApi, TEntity>.Apply(query, param);

            var items = await query
                .AsNoTracking()
                .Skip(param.Start)
                .Take(param.Length)
                .ProjectTo<TEntityApi>(_mappingConfiguration)
                .ToArrayAsync();

            return new JsonResult(new JqueryDataTablesResult<TEntityApi>
            {
                Draw = param.Draw,
                Data = items,
                RecordsFiltered = items.Length,
                RecordsTotal = items.Length
            });
        }

    }
}
