﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using WebApplication1.Enums;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        [EnableCors("_myAllowSpecificOrigins")]

        [HttpGet("post")]
        public IActionResult Post(string name, string lastName, string telephon, double x, double y, DateTime beginDate, DateTime endDate, string typeOfVehicle, int priority)
        {
            try
            {
                if (beginDate > endDate)
                {
                    return BadRequest("Время начала меньше либо равно времени конца.");
                }
                using var context = new ApplicationContext();
                int customerId = context.Customers.First(rec => rec.PhoneNumber == telephon && rec.UserName == $"{lastName} {name}").Id;
                context.Forms.Add(new()
                {
                    CustomeId = customerId,
                    TransportType = typeOfVehicle,
                    BeginDate = beginDate,
                    EndDate = endDate,
                    Location = new Location()
                    {
                        X = x,
                        Y = y,
                    },
                });
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Что-то пошло не так при отправке формы.");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]

        [HttpGet("get")]
        public IActionResult Get(int formId)
        {
            using var context = new ApplicationContext();
            var form = context.Forms.FirstOrDefault(rec => rec.Id == formId);
            if (form == null)
            {
                return NotFound($"Не найдена заявка под идентификатором {formId}.");
            }
            return Ok(form);
        }

        
        [EnableCors("_myAllowSpecificOrigins")]

        [HttpDelete("delete")]
        public IActionResult Delete(int formId)
        {
            /*try
            {
                using var context = new ApplicationContext();
                var form = context.Forms.First(item => item.Id == formId);
                var answer = context.Forms.Remove(form);
                context.SaveChanges();
                return Ok(answer);
            }
            catch
            {
                return BadRequest("Что-то пошло не так при получении формы.");
            }*/
            return Ok();
        }
    }
}
