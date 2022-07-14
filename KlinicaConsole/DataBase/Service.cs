//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KlinicaConsole.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.ReceptionServices = new HashSet<ReceptionService>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int FunctionId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Nullable<int> Photo { get; set; }
        public int Status { get; set; }
    
        public virtual Function Function { get; set; }
        public virtual Pfile Pfile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceptionService> ReceptionServices { get; set; }
        public virtual Status Status1 { get; set; }
    }
}
