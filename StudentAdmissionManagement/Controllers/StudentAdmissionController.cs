using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        // GET: api/<StudentAdmissionController>
        [HttpGet]
        public IEnumerable<StudentAdmissionDetailsModel> Get()
        {
            StudentAdmissionDetailsModel admissionobj1 = new StudentAdmissionDetailsModel();
            StudentAdmissionDetailsModel admissionobj2 = new StudentAdmissionDetailsModel();
            admissionobj1.StudentID = 1;
            admissionobj1.StudentName = "Adam";
            admissionobj1.StudentClass = "X";
            admissionobj1.DateofJoining = DateTime.Now;
            admissionobj2.StudentID = 2;
            admissionobj2.StudentName = "Brad";
            admissionobj2.StudentClass = "IX";
            admissionobj2.DateofJoining = DateTime.Now;
            List<StudentAdmissionDetailsModel> listofobj = new List<StudentAdmissionDetailsModel>
            {
                admissionobj1,
                admissionobj2
            };
            return listofobj;
        }

        [HttpGet]
        [Route("Validate2")]
        public async Task<string> Validate2()
        {
            var httpClient = new HttpClient();
            try
            { 
                
                var request = new HttpRequestMessage(new HttpMethod("GET"), "http://localhost:5002/api/StudentAttendance/Validate");
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadAsStringAsync() + " - From AdmissionController";
            }
            catch(Exception e)
            {

            }
            finally
            {
                if(httpClient != null)
                    httpClient.Dispose();
            }
        }


        // GET api/<StudentAdmissionController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return id;
        }

        // POST api/<StudentAdmissionController>
        [HttpPost]
        public void Post([FromBody] StudentAdmissionDetailsModel value)
        {
        }

        // PUT api/<StudentAdmissionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentAdmissionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
