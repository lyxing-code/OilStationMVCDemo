//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OilStationDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_Organization
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Leve { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public bool IsDel { get; set; }
        public string ParentName { get; set; }
        public string ParentCode { get; set; }
    }
}
