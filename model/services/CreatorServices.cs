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
                Password=options.Password          
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
        public IQueryable<Creator> SearchCreator(SearchProjects options)
        {
            var Creator_ = context_
           .Set<Creator>()
           .AsQueryable();

            if (options == null) {
                return null;
            } else if (string.IsNullOrWhiteSpace(options.Title)) {
                return null;
            }
            return Creator_;
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

        public bool UpdateCreator(int id, UpdateCreator options)
        {
            var creator = SearchCreatorById(id);
            var built = false;
            if ((id<=0)||
                (options == null)||
                (creator==null)) {
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

            }
            try {
                built = context_.SaveChanges() > 0;
            } catch (Exception ex) {
            }
            return built;
        }
    }
}
 //if(user == null) {
 //               return new ApiResult<User>()
 //               {
 //                   ErrorCode = StatusCode.NotFound,
 //                   ErrorText = $"User Id not found in database"
 //               };
 //           }

 //           if (!string.IsNullOrWhiteSpace(options.UserEmail)) {
 //               var emailCheck = SearchUser(new SearchUserOptions()
 //               {
 //                   UserEmail = options.UserEmail
 //               }).SingleOrDefault();

 //               if(emailCheck == null) {
 //                   user.UserEmail = options.UserEmail;
 //               } else {
 //                   return new ApiResult<User>()
 //                   {
 //                       ErrorCode = StatusCode.Conflict,
 //                       ErrorText = $"Email already found in database"
 //                   };
 //               }
 //           }

 //           if (!string.IsNullOrWhiteSpace(options.UserFirstName)) {
 //               user.UserFirstName = options.UserFirstName;
 //           }            
            
 //           if (!string.IsNullOrWhiteSpace(options.UserLastName)) {
 //               user.UserLastName = options.UserLastName;
 //           }            
            
 //           if (!string.IsNullOrWhiteSpace(options.UserPhone)) {
 //               user.UserPhone = options.UserPhone;
 //           }            
            
 //           if (!string.IsNullOrWhiteSpace(options.UserVat)) {
 //               user.UserVat = options.UserVat;
 //           }

 //           context.Update(user);

 //           var success = false;

 //           try {
 //               success = await context.SaveChangesAsync() > 0;
 //           } catch (Exception e) {
 //               return new ApiResult<User>()
 //               {
 //                   ErrorCode = StatusCode.InternalServerError,
 //                   ErrorText = $"Something went wrong, user not updated. {e}"
 //               };
 //           }

 //           if (success) {
 //               return ApiResult<User>.CreateSuccess(user);
 //           } else {
 //               return new ApiResult<User>()
 //               {
 //                   ErrorCode = StatusCode.InternalServerError,
 //                   ErrorText = "Something went wrong, user not updated"
 //               };
 //           }
 //       }

