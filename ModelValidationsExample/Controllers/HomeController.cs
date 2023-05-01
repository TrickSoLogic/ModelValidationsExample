﻿using Microsoft.AspNetCore.Mvc;
using CustomModelBindersModelValidationsCoreMVC6.Models;
using CustomModelBindersModelValidationsCoreMVC6.CustomModelBinders;

namespace CustomModelBindersModelValidationsCoreMVC6.Controllers
{
  public class HomeController : Controller
  {
    [Route("register")]
    //Example JSON: { "PersonName": "William", "Email": "william@example.com", "Phone": "123456", "Password": "william123", "ConfirmPassword": "william123" }
    public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))] Person person)
    {
      if (!ModelState.IsValid)
      {
        //get error messages from model state
        string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
  
        return BadRequest(errors);
      }

      return Content($"{person}");
    }
  }
}
