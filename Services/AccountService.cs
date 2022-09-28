using System;
using Microsoft.Extensions.Options;
using SampleWebApi.Models;

namespace SampleWebApi.Services
{
    /// <summary>
    /// UserService
    /// </summary>
    public class AccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IOptions<AppSettings> _config;

        /// <summary>
        /// UserService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="config"></param>
        public AccountService(ILogger<AccountService> logger, IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// 取得帳號資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccountModel> GetInfo(string id)
        {
            return await Task.FromResult(new AccountModel
            {
                Id = id,
                Name = _config.Value.DefaultName ?? "DefaultName"
            });
        }
    }
}