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
    
    public partial class TimingSegmentation
    {
        public int Id { get; set; }
        public System.TimeSpan TimeS { get; set; }
        public System.TimeSpan TimeF { get; set; }
        public int TimingId { get; set; }
        public int Actively { get; set; }
        public Nullable<int> AppointmentId { get; set; }
    
        public virtual Appointment Appointment { get; set; }
        public virtual Timing Timing { get; set; }
    }
}