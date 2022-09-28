using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SampleWebApi.Models;
using SampleWebApi.Services;

namespace SampleWebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : ApiControllerBase
    {
        private readonly AccountService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        public AccountController(ILogger<AccountController> logger, AccountService service) : base(logger)
        {
            _service = service;
        }

        /// <summary>
        /// 取得帳號資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<AccountModel> GetInfo(string id)
        {
            return await _service.GetInfo(id);
        }
    }
}