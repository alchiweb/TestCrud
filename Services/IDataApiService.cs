using JqueryDataTables.ServerSide.AspNetCoreWeb;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.Services
{
    public interface IDataApiService
    {
        Task<JsonResult> GetDataAsync(IQueryable<object> dbset, JqueryDataTablesParameters table);
    }
}
