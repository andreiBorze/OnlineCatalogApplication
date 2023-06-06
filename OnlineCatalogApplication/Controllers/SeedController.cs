using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        #region Initialization
        private readonly IDataAccessLayerService dal;
        public SeedController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }
        #endregion
   

        /// <summary>
        /// Initialize the database
        /// </summary>
        [HttpPost()]
        public void Seed() => 
            dal.Seed(); 
    }
}
