//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Klinica.Datebase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Documents = new HashSet<Document>();
            this.PaymentHistories = new HashSet<PaymentHistory>();
        }
    
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string PassportData { get; set; }
        public Nullable<System.DateTime> PassportDate { get; set; }
        public string PassportDivisionCode { get; set; }
        public string SNILS { get; set; }
        public string INN { get; set; }
        public string Polis { get; set; }
        public string AdressRegistration { get; set; }
        public string AdressResidence { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string HomeTelephone { get; set; }
        public string PlaceWork { get; set; }
        public int Benefit { get; set; }
        public System.DateTime CreateDatetime { get; set; }
        public Nullable<System.DateTime> ModifeDatetime { get; set; }
        public string Comment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
        public virtual SocStatu SocStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
    }
}