using System.Net.Mime;
using AutoMapper;
using JobSync.API.Payment.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Payment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentPlanController : ControllerBase
{
    private readonly IPaymentPlanService _planService;
    private readonly IMapper _mapper;
  
    public PaymentPlanController(IPaymentPlanService planService, IMapper mapper)
    {
        _planService = planService;
        _mapper = mapper;
    }
}