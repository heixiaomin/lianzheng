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
    
    public partial class DT_WorkUnit
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string CreateUnit { get; set; }
        public string CreateDept { get; set; }
        public Nullable<System.DateTime> AddUnitTime { get; set; }
        public Nullable<System.DateTime> AddDeptTime { get; set; }
        public Nullable<System.DateTime> UpdUnitTime { get; set; }
        public Nullable<System.DateTime> UpdDeptTime { get; set; }
        public string Remarks { get; set; }
    }
}
