using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IConstService
    {
        List<ConstSharedModel> GetListConst();

        ConstSharedModel GetConstById(string constId);

        bool CreateConst(ConstSharedModel const_item);

        bool EditConst(ConstSharedModel const_item);

        bool DeleteConst(string constId);
    }
}
