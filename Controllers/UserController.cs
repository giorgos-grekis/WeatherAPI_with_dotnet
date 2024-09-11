

using Microsoft.AspNetCore.Mvc;

/**
*   The name of the file is really important because when we have the 
*   controller there is this default setup where our route is going to
*   match the name of our controller.
*   So if we wan tour route to be weatherforecast, then we have to have 
*   the name WeatherForecastController as that class's name.
*   That's where we're going to get that initial route from.
*/
namespace WeatherAPI.Controller;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    // we need to specify the public keyword because,
    // when we do this request we have an error as a response.
    // Error => System.InvalidOperationException: A suitable constructor for type 'WeatherAPI.Controller.UserController' could not be located.
    public UserController()
    {

    }


    [HttpGet("GetUsers/{testValue}")]
    /* 
    * IActionResult means an API response.
    * When we use an IActionResult as the response from one of our controller methods, it's pretty safe to return any types of data that we would want to return.
    */
    public string[] GetUsers(string testValue)
    {
        string[] responseArray = new string[] {
            "test1",
            "test2",
            testValue
        };

        return responseArray;

    }
}
