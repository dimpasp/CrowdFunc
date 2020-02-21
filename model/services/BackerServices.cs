using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class BackerServices: IBackerService

    {
        private readonly data.CrowdFunDbContext context_;
        public async Task<ApiResult< Backers>> AddBackerNewAsync(AddNewBackerOptions options)
        {
            if (options == null) {
                return new ApiResult<Backers>(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.FirstName) ||
                string.IsNullOrWhiteSpace(options.LastName) ||
                string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.Id)||
                string.IsNullOrWhiteSpace(options.Password)){
                return new ApiResult<Backers>(
                    StatusCode.BadRequest, "Null options");
            }
            var new_backer = new Backers()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Password = options.Password,
                Email = options.Email         
            };
            context_.Add(new_backer);
            try {
                await context_.SaveChangesAsync();
            } catch (Exception ex) {
                return new ApiResult<Backers>(
                    StatusCode.InternalServerError, "Could not save creator");
            }

        public Task<ApiResult<Backers>> AddBackerNewAsync(AddNewBackerOptions options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Backers> SearchBacker(SearchBaker options)
        {
            var backer_ = context_
                .Set<Backers>()
                .AsQueryable();


            if (options == null) {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(options.Email)) {
                backer_ = backer_.Where(c =>
                    c.Email == options.Email);
            }
         
            if (!string.IsNullOrWhiteSpace(options.FirstName)) {
                backer_ = backer_.Where(c =>
                    c.FirstName == options.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(options.LastName)) {
                backer_ = backer_.Where(c =>
                    c.LastName == options.LastName);
            }
          
            return backer_;
        }

        public Backers SearchBackerId(int id)
        {
            var backer_ = context_
               .Set<Backers>()
               .SingleOrDefault(s => s.Id==id);

            if (id < 0) {
                return null;
            }

           return backer_;
        }

        public bool UpdateBacker(int id, UpdateBacker options)
        { 
            var backer = SearchBackerId(id);
            var built = false;
            if ((id <= 0)|| (options == null)) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.FirstName)) {
                backer.FirstName = options.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(options.LastName)) {
                backer.LastName = options.LastName;
            }
            if (!string.IsNullOrWhiteSpace(options.Password)) {
                backer.Password = options.Password;
            }
            try {
                built = context_.SaveChanges() > 0;
            } catch (Exception ex) {
            }
            return built;
        }
    }
}
        