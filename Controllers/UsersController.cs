using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Services;

namespace SampleWebApi.Controllers;

/// <summary>
/// UsersController
/// </summary>
public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UserService _service;

    /// <summary>
    /// UsersController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="service"></param>
    /// <returns></returns>
    public UsersController(ILogger<UsersController> logger, UserService service) : base(logger)
    {
        _logger = logger;
        _service = service;
    }

    /// <summary>
    /// 取得使用者名稱
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Name/{id}")]
    public async Task<string?> GetUserName(string id)
    {
        return await _service.GetUserName(id);
    }
}
