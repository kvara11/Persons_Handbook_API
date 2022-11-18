using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons_Handbook_API.Models;

namespace Persons_Handbook_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            return Ok(unitOfWork.PersonsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var data = unitOfWork.PersonsRepository.GetById(id);
            return Ok(data);
        }

        [HttpPost(Name = "AddPerson")]
        public IActionResult Create(Persons person)
        {
            unitOfWork.PersonsRepository.Insert(person);
            unitOfWork.Save();

            return Ok("Inserted");
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        public IActionResult UpdatePerson(Guid id, Persons person)
        {
            var data = unitOfWork.PersonsRepository.GetById(id);
            data.Firstname = person.Firstname;
            data.Lastname = person.Lastname;
            data.Gender = person.Gender;
            data.PersonalNumber = person.PersonalNumber;
            //data.DateOfBirth = person.DateOfBirth;
            data.City = person.City;
            data.Phone = person.Phone;
            data.RelatedPersons = person.RelatedPersons;

            unitOfWork.PersonsRepository.Update(data);
            unitOfWork.Save();

            return Ok("Row Updated");
        }

        public IActionResult UploadPhoto(Photos photo)
        {

        }
    }
}
