using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchoolRemake.DTOs;
using BigSchoolRemake.Models;
using Microsoft.AspNet.Identity;

namespace BigSchoolRemake.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public AttendancesController()
        {

        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Anttendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Anttendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
