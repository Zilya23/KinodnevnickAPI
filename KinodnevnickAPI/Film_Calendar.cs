//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinodnevnickAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film_Calendar
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ID_User { get; set; }
        public Nullable<int> ID_Film { get; set; }
        public string Description { get; set; }
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        public Nullable<System.TimeSpan> End_Time { get; set; }
    
        public virtual Film Film { get; set; }
        public virtual User User { get; set; }
    }
}
