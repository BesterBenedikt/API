//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class T004_Match
    {
        public int Id { get; set; }
        public int TeamID_1_FK_T001 { get; set; }
        public int TeamID_2_FK_T001 { get; set; }
        public Nullable<int> Score_Team_1 { get; set; }
        public Nullable<int> Score_Team_2 { get; set; }
        public Nullable<System.DateTime> MatchDate { get; set; }
        public int EventID_FK_T003 { get; set; }
        public string Description { get; set; }
    
        public virtual T001_Teams T001_Teams { get; set; }
        public virtual T001_Teams T001_Teams1 { get; set; }
        public virtual T003_Event T003_Event { get; set; }
    }
}
