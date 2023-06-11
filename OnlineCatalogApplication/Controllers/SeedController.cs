using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public SeedController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }

        /// <summary>
        /// Initialize the database by seeding data.
        /// </summary>
        [HttpPost()]
        public void Seed() => dal.Seed();
    }

}
