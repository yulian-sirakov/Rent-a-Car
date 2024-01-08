using Bussines_Layer.Models;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ReviewManager
    {
        private readonly IDb<Review, int> reviewContext;

        public ReviewManager(IDb<Review, int> reviewContext)
        {
            this.reviewContext = reviewContext;
        }

        public async Task CreateAsync(Review review)
        {
            await reviewContext.CreateAsync(review);
        }

        public async Task<Review> ReadAsync(int key, bool navigationalProperties = false, bool IsReadOnly = true)
        {
            return await reviewContext.ReadAsync(key, navigationalProperties, IsReadOnly);
        }

        public async Task<ICollection<Review>> ReadAllAsync(bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await reviewContext.ReadAllAsync(navigationalProperties, isReadOnly);
        }
        public async Task Update(Review review, bool navigationalProperties = false)
        {
            await reviewContext.UpdateAsync(review, navigationalProperties);
        }

        public async Task Delete(int key)
        {
            await reviewContext.DeleteAsync(key);
        }
    }
}
