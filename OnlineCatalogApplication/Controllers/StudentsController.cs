using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using OnlineCatalogApplication.Dtos;
using OnlineCatalogApplication.Utils;
using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public StudentsController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }

        /// <summary>
        /// Returns all students in the database.
        /// </summary>
        /// <returns>A list of students</returns>
        [HttpGet()]
        public IEnumerable<StudentToGetDto> GetAllStudents() =>
            dal.GetAllStudents().Select(s => s.ToDto()).ToList();

        /// <summary>
        /// Get a student by ID.
        /// </summary>
        /// <param name="id">The ID of the student</param>
        /// <returns>The student data</returns>
        [HttpGet("/id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<StudentToGetDto> GetStudentById([Range(1, int.MaxValue)] int id) =>
            Ok(dal.GetStudentById(id).ToDto());

        /// <summary>
        /// Create a student.
        /// </summary>
        /// <param name="studentToCreate">Student data to create</param>
        /// <returns>The created student data</returns>
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Update a student.
        /// </summary>
        /// <param name="studentToUpdate">Student data to update</param>
        /// <returns>The updated student data</returns>
        [HttpPut]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();

        /// <summary>
        /// Delete a student.
        /// </summary>
        /// <param name="id">The ID of the student to delete</param>
        /// <returns>Response status</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest($"Id cannot be 0!");
            }

            dal.DeleteStudent(id);
            return Ok();
        }

        /// <summary>
        /// Update or create an address for a student.
        /// </summary>
        /// <param name="id">The ID of the student</param>
        /// <param name="addressToUpdate">Address data to update</param>
        /// <returns>Status and the address</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {
            if (dal.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity()))
            {
                return Created("Success", null);
            }
            return Ok();
        }

        /// <summary>
        /// Get all students ordered by grades.
        /// </summary>
        /// <returns>A list of students ordered by grades</returns>
        [HttpGet("/api/GetAllStudentsOrderByGrades/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentOrderByGradesDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IEnumerable<StudentOrderByGradesDto> GetAllStudentsOrderByGrades() =>
            dal.GetAllStudentsOrderByGrades().Select(s => s.ToDtos()).ToList();

        /// <summary>
        /// Get the address for a student.
        /// </summary>
        /// <param name="studentId">The ID of the student</param>
        /// <returns>The address for the student</returns>
        [HttpGet("/studentId/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<StudentToGetDto> GetAddressForStudent(int studentId) =>
            Ok(dal.GetAddressForStudent(studentId).ToDtos());
    }

}
