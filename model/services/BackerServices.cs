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
        public BackerServices(data.CrowdFunDbContext ctx)
        {
            context_ = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<ApiResult<Backer>> AddBackerNewAsync(AddNewBackerOptions options)
        {
            if (options == null) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Null options");
            }
            if (options.Donate <= 0.0M) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Invalid Donate");
            }

            if (string.IsNullOrWhiteSpace(options.FirstName) ||
                string.IsNullOrWhiteSpace(options.LastName) ||
                string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.Password)) {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, "Null options");
            }
            var new_backer = new Backer()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                Donate = options.Donate              
            };

            context_.Add(new_backer);

            try 
            {

                await context_.SaveChangesAsync();

            } catch (Exception ex) {

                return new ApiResult<Backer>(StatusCode.InternalServerError, "Could not save creator");
            }
            return new ApiResult<Backer>()
            {
                ErrorCode = StatusCode.Ok,
                Data = new_backer
            };

        }
        public IQueryable<Backer> SearchBacker(SearchBaker options)
        {
            var backer_ = context_
                .Set<Backer>()
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

        public Backer SearchBackerId(int id)
        {
            var backer_ = context_
               .Set<Backer>()
               .SingleOrDefault(s => s.Id==id);

            if (id <= 0) {

                return null;
            }

           return backer_;
        }

        public bool UpdateBacker(int id, UpdateBacker options)
        { 
            var backer = SearchBackerId(id);
            var built = true;
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
            if (options.NewDonate <= 0) {
                backer.Donate = options.NewDonate;
            }
            try {
                built = context_.SaveChanges() > 0;
            } catch (Exception ex) {
                Console.WriteLine("UPDATE FAIL" + ex);
                return false;
            }
            return built;
        }
    }   
 }
        