using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class CreatorServices : ICreatorService
    {
        private readonly data.CrowdFunDbContext context_;
        public CreatorServices(data.CrowdFunDbContext ctx)
        {
            context_ = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public async Task<ApiResult<Creator>> CreateNewCreatorAsync(AddNewCreatorOptions options)
        {
            //kai enan elegxo na kanw gia an uparxei
            if (options == null) {
                return new ApiResult<Creator>(
                    StatusCode.BadRequest, "Null options");
            }
            if (string.IsNullOrWhiteSpace(options.Password) ||
              string.IsNullOrWhiteSpace(options.Email)||
              string.IsNullOrWhiteSpace(options.FirstName)||
              string.IsNullOrWhiteSpace(options.LastName)) {
                return new ApiResult<Creator>(
                    StatusCode.BadRequest, "Null options");
            }
            var new_Creator = new Creator()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                Password=options.Password ,
                Phone=options.Phone,
                TotalCost=options.TotalCost
            };
            context_.Add(new_Creator);
            try {
               await context_.SaveChangesAsync();
            } catch (Exception ex) {
                return new ApiResult<Creator>(
                    StatusCode.InternalServerError, "Could not save creator");
            }

            return new ApiResult<Creator>()
            {
                ErrorCode = StatusCode.Ok,
                Data = new_Creator
            };
        }

        public IQueryable<Creator> SearchCreator(SearchCreatorOptions options)
        {
            var query = context_
                .Set<Creator>()
                .AsQueryable();

            if (options == null) {
                return null;
            }

            if (options.Id != null) {
                return query.Where(s => s.Id == options.Id);
            }

         
            if (!string.IsNullOrWhiteSpace(options.Email)) {
                query = query.Where(s => s.Email == options.Email);
            }

            if (options.FirstName != null) {
                query = query
                    .Where(s => s.FirstName == options.FirstName);
            }

            if (options.LastName != null) {
                query = query
                    .Where(s => s.LastName == options.LastName);
            }

            return query
                .Take(500);
        }

        public Creator SearchCreatorById(int Id)
        {
            if (Id <= 0) {
                return null;
            }

            return context_
                .Set<Creator>()
                .SingleOrDefault(s => s.Id == Id);
        }
        public async Task<bool> UpdateProjectCreator(int id, UpdateCreator options)
        {
            var creator = SearchCreatorById(id);
            if ((id <= 0) ||
                (options == null) ||
                (creator == null)||
                (options.TotalCost <= 0.0M)) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.FirstName)) {
                creator.FirstName = options.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(options.LastName)) {
                creator.LastName = options.LastName;
            }
            if (!string.IsNullOrWhiteSpace(options.Password)) {
                creator.Password = options.Password;
            }
            if (creator == null) {
                //elegxo gia ton creator
            }

            var UpdProjectCreator = context_.Set<Creator>().SingleOrDefault(p => p.Id == id);

            if (UpdProjectCreator == null) {
                return false;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.FirstName)) {
                UpdProjectCreator.FirstName = options.FirstName;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.LastName)) {
                UpdProjectCreator.LastName = options.LastName;
            }

            if (!string.IsNullOrEmpty(UpdProjectCreator.Email)) {
                UpdProjectCreator.Email = options.Email;
            }

            if (UpdProjectCreator.TotalCost > 0) {
                UpdProjectCreator.TotalCost = options.TotalCost;
            }
            context_.Update(UpdProjectCreator);
            try {
                context_.SaveChanges();
                Console.WriteLine("Update creator ok");
            } catch (Exception ex) {
                Console.WriteLine("UPDATE CREATOR FAIL" + ex);
                return false;
            }
            return true;
        }
    }
}


