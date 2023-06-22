using System.Net.Mime;
using AutoMapper;
using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Services;
using JobSync.API.Payment.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Payment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PayController : ControllerBase
{
    private readonly IPayService _payService;
    private readonly IMapper _mapper;
    
    public PayController(IPayService payService, IMapper mapper)
    {
        _payService = payService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PayResource>), 200)]
    public async Task<IEnumerable<PaymentPlanResource>> GetAllAsync()
    {
        var pays = await _payService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Pay>, IEnumerable<PaymentPlanResource>>(pays);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] PayResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var pay = _mapper.Map<PayResource, Pay>(resource);
        var result = await _payService.CreateAsync(pay);
    
        if (!result.Success)
            return BadRequest(result.Message);

        var payResource = _mapper.Map<Pay, PayResource>(result.Resource);
    
        return Created(nameof(PostAsync), payResource);
    }
}