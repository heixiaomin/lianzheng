﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yisaa.DAL
{
    //搜索框搜索出来的已归档人员信息
   public class DTO_Search
    {
        public int userid { get; set; }
        public string realname { get; set; }
        public int? unitname { get; set; }
       
        public string tel{ get; set; }

        public string status { get; set; }

    }
}
