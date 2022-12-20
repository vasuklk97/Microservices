﻿using Microsoft.AspNetCore.Mvc;
using StudentAdmissionManagement;
using StudentAdmissionManagement.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAttendanceManagement.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        // GET: api/<StudentAttendanceController>
        [HttpGet]
        public IEnumerable<StudentAttendanceDetailsModel> Get()
        {
            StudentAttendanceDetailsModel attendanceObj1 = new StudentAttendanceDetailsModel();
            StudentAttendanceDetailsModel attendanceObj2 = new StudentAttendanceDetailsModel();
            attendanceObj1.StudentID = 1;
            attendanceObj1.StudentName = "Adam";
            attendanceObj1.AttendencePercentage = 83.02;
            attendanceObj2.StudentID = 2;
            attendanceObj2.StudentName = "Brad";
            attendanceObj2.AttendencePercentage = 71.02;
            List<StudentAttendanceDetailsModel> listObj = new List<StudentAttendanceDetailsModel>
            {
                attendanceObj1,
                attendanceObj2
            };
            return listObj;
        }

        [HttpGet]
        [Route("Validate")]
        public string Validate()
        {
            StudentAdmissionController studentAdmission = new StudentAdmissionController();
            IEnumerable<StudentAdmissionDetailsModel> listofstudentAdmission = studentAdmission.Get();
            List<StudentAdmissionDetailsModel> obj1 = listofstudentAdmission.ToList();
            IEnumerable<StudentAttendanceDetailsModel> listofobj = this.Get();
            List<StudentAttendanceDetailsModel> obj = listofobj.ToList();
            if (obj[0].StudentName == obj1[0].StudentName)
                return obj[0].StudentName;
            else
                return "Failed";
        }

        // GET api/<StudentAttendanceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentAttendanceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentAttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentAttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
