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
    
    public partial class HoneyCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoneyCard()
        {
            this.ReceptionServices = new HashSet<ReceptionService>();
        }
    
        public string Id { get; set; }
        public System.DateTime DateRegistration { get; set; }
        public int Therapist { get; set; }
        public int PatientId { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Worker Worker { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceptionService> ReceptionServices { get; set; }
    }
}