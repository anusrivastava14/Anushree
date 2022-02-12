using Anushree.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Anushree.DAL
{
    public class DataAccess:DbContext
    {
        public IEnumerable<stu>reach(int procid ,stu model)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter {ParameterName="@StuId",Value=model.uid==null?0:model.uid },
                new SqlParameter {ParameterName="@Uname",Value=model.name??string.Empty },
                new SqlParameter {ParameterName="@Uclass",Value=model.Class??string.Empty },
                new SqlParameter {ParameterName="@Umobile",Value=model.mobile??string.Empty },
                new SqlParameter {ParameterName="@Uemail",Value=model.email??string.Empty },
                new SqlParameter {ParameterName="@procid",Value=procid },
            };
            var com = @"SP_anu @StuId,@Uname,@Uclass,@Umobile,@Uemail,@procid";
            return this.Database.SqlQuery<stu>(com, param);

        }
    }
}