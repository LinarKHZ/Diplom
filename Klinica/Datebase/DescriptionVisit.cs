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
    
    public partial class DescriptionVisit
    {
        public int Id { get; set; }
        public string Complaints { get; set; }
        public string Anamnesis { get; set; }
        public string Examination { get; set; }
        public string TreatmentPlan { get; set; }
        public string SurveyPlan { get; set; }
        public string Recommendations { get; set; }
        public string Conclusion { get; set; }
        public int AppointmentId { get; set; }
    
        public virtual Appointment Appointment { get; set; }
    }
}