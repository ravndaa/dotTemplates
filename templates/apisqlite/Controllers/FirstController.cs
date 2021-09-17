using ApiSqlite.Data;
using ApiSqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlite.Controllers
{
    [Route("api/first")]
    [ApiController]
    public class FirstController : CrudController<First>
    {
        public FirstController(IDataService<First> repository): base(repository) {}
    }
}