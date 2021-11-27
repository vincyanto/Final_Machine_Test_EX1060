using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using SalesApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        ISalesRepository salesRepository;

        public SalesController(ISalesRepository _p)
        {
            salesRepository = _p;
        }

        #region get sales employee
        [HttpGet]
        //[Route("GetSalesEmployee")]
        public async Task<IActionResult> GetSalesEmployee()
        {
            try
            {
                var emp = await salesRepository.GetSalesEmployee();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
        #endregion

        # region get sales employee by id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesEmployeeById(int id)

        {
            try
            {
                var course = await salesRepository.GetSalesEmployeeById(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion



        #region Add sales employee

        [HttpPost]
        //[Route("Addemployee")]

        public async Task<IActionResult> AddSalesEmployee([FromBody] EmployeeRegistration model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await salesRepository.AddSalesEmployee(model);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


        #region Update employee
        [HttpPut]
        //[Route("UpdateEmployee")]

        public async Task<IActionResult> UpdateSalesEmployee([FromBody] EmployeeRegistration model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await salesRepository.UpdateSalesEmployee(model);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion 

    }
}
