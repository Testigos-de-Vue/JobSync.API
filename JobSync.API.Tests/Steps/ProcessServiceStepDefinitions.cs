using System.Net;
using System.Net.Mime;
using System.Text;
using JobSync.API.Recruitment.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;

namespace JobSync.API.Tests.Steps;

[Binding]
public class ProcessServiceStepDefinitions: WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    public ProcessServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }

    [Given(@"the Endpoint http://localhost:(.*)/api/v(.*)/recruitment/processes is Available")]
    public void GivenTheEndpointHttpLocalhostApiVRecruitmentProcessesIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"http://localhost:{port}/api/v{version}/recruitment/processes");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveProcessResource)
    {
        var resource = saveProcessResource.CreateInstance<SaveProcessResource>();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response is received with Status Code (.*)")]
    public void ThenAResponseIsReceivedWithStatusCode(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Process Resource is included in Response Body")]
    public async void ThenAProcessResourceIsIncludedInResponseBody(Table expectedProcessResource)
    {
        var expectedResource = expectedProcessResource.CreateSet<ProcessResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var actualResource = JsonConvert.DeserializeObject<ProcessResource>(responseData);
        Assert.AreEqual(expectedResource.Name, actualResource.Name);
    }

    [When(@"a Delete Request is sent")]
    public void WhenADeleteRequestIsSent(Table processResource)
    {
        var process = processResource.CreateInstance<ProcessResource>();
        var uriToDelete = new Uri($"{BaseUri}/{process.Id}");
        Response = Client.DeleteAsync(uriToDelete);
    }

    [Then(@"the Process with Id (.*) is deleted")]
    public async void ThenTheProcessWithIdIsDeleted()
    {
        var expectedStatusCode = HttpStatusCode.NotFound.ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
    }

    [When(@"Process with Id (.*) does not exist")]
    public void WhenProcessWithIdDoesNotExist(int processId)
    {
        var uri = new Uri($"{BaseUri}/{processId}");
        Response = Client.GetAsync(uri);
        var expectedStatusCode = HttpStatusCode.NotFound.ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        Assert.AreEqual(expectedStatusCode, actualStatusCode);
    }

    [Then(@"An Error Message is returned with Value ""(.*)""")]
    public void ThenAnErrorMessageIsReturnedWithValue(string expectedMessage)
    {
        var actualMessage = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.AreEqual(expectedMessage, actualMessage);
    }
}