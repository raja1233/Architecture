using architecture.Data;
using architecture.Entity;
using architecture.Service.Abstract;
using architecture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace architecture.Web.Controllers
{
    public class PersonApiController : ApiController
    {
        private readonly IFunction _ifunctionService;
        private PersonContext db = new PersonContext();
        //public PersonApiController()
        //{
        //    Person p = new Person();
        //}

        public PersonApiController(IFunction ifunctionservice)
        {
            _ifunctionService = ifunctionservice;
        }
        //Get  Api/PersonApi
        [ResponseType(typeof(Person))]

        public IHttpActionResult Get()
        {
            var data = _ifunctionService.getAllList().ToList();
            return Ok(data);
        }
        // GET api/PersonApi/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult Get(long? id)
        {
            var data = _ifunctionService.getById(id);
            return Ok(data);
        }

        [ResponseType(typeof(Person))]
        public IHttpActionResult Delete(int id = 0)
        {
            var data = _ifunctionService.DeleteRecord(id);
            return Ok(data);
        }
        public 
            IHttpActionResult PostPerson(PersonVIewModel person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _ifunctionService.AddData(person);
            }
            return CreatedAtRoute("DefaultApi", new { id = person.ID }, person);
        }

        public IHttpActionResult PutPerson(PersonVIewModel person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    _ifunctionService.updateEmployee(person);

                }
                catch(Exception)
                {
                    NotFound();
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}