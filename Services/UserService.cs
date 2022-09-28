using System;
using Microsoft.Extensions.Options;
using SampleWebApi.Models;

namespace SampleWebApi.Services
{
    /// <summary>
    /// UserService
    /// </summary>
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly AccountService _accountService;

        /// <summary>
        /// UserService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="accountService"></param>
        public UserService(ILogger<UserService> logger, AccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        /// <summary>
        /// 取得使用者名稱
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string?> GetUserName(string id)
        {
            var info = await _accountService.GetInfo(id);

            return info.Name;
        }
    }
}