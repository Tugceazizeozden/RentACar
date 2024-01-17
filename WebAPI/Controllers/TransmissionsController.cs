using Business.Abstract;
using Business.Requests.Transmission;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : ControllerBase
{
    private readonly ITransmissionService _TransmissionService; 

    public TransmissionsController()
    {
        _TransmissionService = TransmissionServiceRegistration.TransmissionService;
    }

    

    [HttpGet]  
    public ICollection<Transmission> GetList()
    {
        IList<Transmission> TransmissionList = _TransmissionService.GetList();
        return TransmissionList; 
    }

    [HttpPost] 
    public ActionResult<AddTransmissionResponse> Add(AddTransmissionRequest request)
    {
        AddTransmissionResponse response = _TransmissionService.Add(request);

        return CreatedAtAction(nameof(GetList), response); 
    }
}
