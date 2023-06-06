﻿using Data.DAL;
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
        #region Initialization
        private readonly IDataAccessLayerService dal;
        public StudentsController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }
        #endregion

        #region GetAllStudents
        /// <summary>
        /// Returns all students in db
        /// </summary>
        /// <returns></returns>
        
        [HttpGet()]
        public IEnumerable<StudentToGetDto> GetAllStudents() => 
            dal.GetAllStudents().Select(s => s.ToDto()).ToList();

        #endregion

        #region GetStudentById
        /// <summary>
        /// Get a student by id    
        /// </summary>
        /// <param name="id"></param>
        /// <returns>student data</returns>
        
        [HttpGet("/id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<StudentToGetDto> GetStudentById([Range(10, int.MaxValue)] int id)
        {
            try
            {
                return Ok(dal.GetStudentById(id).ToDto());
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region CreateStudent
        /// <summary>
        /// Create a student
        /// </summary>
        /// <param name="studentToCreate">Student to create data</param>
        /// <returns>created student data</returns>
        
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        #endregion

        #region UpdateStudent
        /// <summary>
        /// Updates a student 
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        
        [HttpPut]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate)=>
            dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();

        #endregion

        #region DeleteStudent
        /// <summary>
        /// Delete a student 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Response status</returns>
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public IActionResult DeleteStudent(int id)
        {
            if(id == 0)
            {
                return BadRequest($"Id cannot be 0!");
            }
            try
            {
                dal.DeleteStudent(id);
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

        #endregion

        #region UpdateOrCreateStudentAddress

        /// <summary>
        /// Update Or Create an Address for a Student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressToUpdate"></param>
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
            return Ok(addressToUpdate);
        }
        #endregion
    }
}
