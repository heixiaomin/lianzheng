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
    
    public partial class DT_PetitionLetter
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> YearTable { get; set; }
        public string RecordNum { get; set; }
        public string LetterTime { get; set; }
        public string FromUnit { get; set; }
        public string ByManName { get; set; }
        public string ByManPost { get; set; }
        public string ByManUnit { get; set; }
        public string ManName { get; set; }
        public string ManTel { get; set; }
        public string ManUnit { get; set; }
        public string ManPost { get; set; }
        public string Content { get; set; }
        public string SurveyResult { get; set; }
        public string HandleResult { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> FillTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
