﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace vittighedsmaskinen.apikey
{
    public class InMemoryGetApiKeyQuery : IGetAllApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public InMemoryGetApiKeyQuery()
        {
            var existingApiKeys = new List<ApiKey>
        {
            new ApiKey(1, "Programmer", "C5BFF7F0-B4DF-475E-A331-F737424F013C", new DateTime(2019, 01, 01),
                new List<string>
                {
                    Roles.Programmer
                })
            
        };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }



        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }


}
