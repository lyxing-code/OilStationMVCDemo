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
    
    public partial class OilMaterialOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OilMaterialOrder()
        {
            this.OilMaterialOrderDetail = new HashSet<OilMaterialOrderDetail>();
        }
    
        public System.Guid Id { get; set; }
        public string No { get; set; }
        public System.Guid ApplyPersonId { get; set; }
        public Nullable<System.DateTime> ApplyDate { get; set; }
        public string Remark { get; set; }
        public bool IsDel { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilMaterialOrderDetail> OilMaterialOrderDetail { get; set; }
    }
}