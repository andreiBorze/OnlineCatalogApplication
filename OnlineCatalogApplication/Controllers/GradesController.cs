using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCatalogApplication.Dtos;
using OnlineCatalogApplication.Utils;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public GradesController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }

        /// <summary>
        /// Award Grade 
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>The status</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        public GradeToCreateDto AwardGrade([FromBody] GradeToCreateDto grade) => dal.AwardGrade(grade.Value, grade.StudentId, grade.CourseId).ToDto();
   
    }
}
