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
        /// <summary>
        /// Post a vote selecting a image of a cat.
        /// </summary>
        /// <param name="vote"> the object that create the vote.</param>
        /// <returns></returns>
        [Post("/v1/votes")]
        Task<string> CreateAvote([Body] CreateVote vote);

        /// <summary>
        /// This methods return a list with all the votes of someone specifying with the sub_id
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        [Get("/v1/votes?sub_id={sub_id}")]
        Task<string> GetOwerVotes(string sub_id);

        /// <summary>
        /// This method delete a vote made before, specifying the vote_id
        /// </summary>
        /// <param name="vote_id"> the Id of the vote.</param>
        /// <returns></returns>
        [Delete("/v1/votes/{vote_id}")]
        Task<string> DeleteVote(string vote_id);
    }
}
