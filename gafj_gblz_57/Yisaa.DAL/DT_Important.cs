//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yisaa.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DT_Important
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> YearTable { get; set; }
        public string Report { get; set; }
        public string CheckIn { get; set; }
        public Nullable<System.DateTime> CheckInTime { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> FillTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
