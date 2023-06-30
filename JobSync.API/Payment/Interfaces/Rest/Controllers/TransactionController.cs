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
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly IMapper _mapper;
    
    public TransactionController(ITransactionService transactionService, IMapper mapper)
    {
        _transactionService = transactionService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TransactionResource>), 200)]
    public async Task<IEnumerable<PaymentPlanResource>> GetAllAsync()
    {
        var pays = await _transactionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Transaction>, IEnumerable<PaymentPlanResource>>(pays);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TransactionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var pay = _mapper.Map<TransactionResource, Transaction>(resource);
        var result = await _transactionService.CreateAsync(pay);
    
        if (!result.Success)
            return BadRequest(result.Message);

        var payResource = _mapper.Map<Transaction, TransactionResource>(result.Resource);
    
        return Created(nameof(PostAsync), payResource);
    }
}