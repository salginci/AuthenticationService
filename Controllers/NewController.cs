namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

[ApiController]
[Route("api/[controller]")]
public class NewController : ControllerBase
{
    private IUserService _userService;

    public NewController(IUserService userService)
    {
        _userService = userService;
    }

    
    [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

         

         return Ok( );


        }

    
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
