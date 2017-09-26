using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
   public class DTO_UserManage
    {
        public int allcount { get; set; }
      
        public List<DT_UserLoginRecord> ulist { get; set; }
    }
}
