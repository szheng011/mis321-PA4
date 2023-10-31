using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using api.models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        // GET: api/Activity
        [HttpGet]
        public List<Activity> Get()
        {
            // GenerateActivities activities = new GenerateActivities();
            // return activities.GetAllActivities();
            List<Activity> activity = Data.GetAllActivities();
            return activity; 
        }

        // // GET: api/Activity/5
        // [HttpGet("{activityID}", Name = "Get")]
        // public Activity Get(int activityID)
        // {
        //     // GenerateActivities activities = new GenerateActivities();
        //     // return activities.GetActivity(activityID);
        //     return Data.GetActivity(activityID);
        // }

        // POST: api/Activity
        [HttpPost]
        public void Post([FromBody] Activity value)
        {
            System.Console.WriteLine(value);
            Data.AddActivity(value);
        }

        // PUT: api/Activity/5
        [HttpPut("{activityID}")]
        public void Put(int activityID)
        {
            System.Console.WriteLine(activityID);
            Data.PinActivity(activityID);
        }

        // DELETE: api/Activity/5
        [HttpDelete("{activityID}")]
        public void Delete(int activityID)
        {
            Data.DeleteActivity(activityID);
        }
    }
}
