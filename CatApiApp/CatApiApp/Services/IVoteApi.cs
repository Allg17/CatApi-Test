using CatApiApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services
{
    [Headers("Content-Type: application/json", "x-api-key: 42030dee-dc15-4010-a931-b9aaf28fbd09")]
    public interface IVoteApi
    {
        [Get("/v1/votes")]
        Task<string> CreateAvote([Body] CreateVote vote);

        [Post("/v1/votes?sub_id={sub_id}")]
        Task<string> GetOwerVotes(string sub_id);
    }
}
