namespace Countries.Backend.Helpers
{
    using Countries.Backend.Models;
    using Countries.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    public  class DBHelpers
    {
        public async static Task<Response> SaveChanges(LocalDataContext db)
        {
            try
            {
                await db.SaveChangesAsync();
                return new Response { IsSuccess = true, };
            }
            catch (Exception ex)
            {
                var response = new Response { IsSuccess = false, };
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "There is a record with the same value";
                }
                else if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "The record can't be delete because it has related records";
                }
                else
                {
                    response.Message = ex.Message;
                }

                return response;
            }
        }
    }
}