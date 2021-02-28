using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vittighedsmaskinen.apikey
{
    public interface IGetAllApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }

}
