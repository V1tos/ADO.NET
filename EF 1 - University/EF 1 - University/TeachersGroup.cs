//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_1___University
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeachersGroup
    {
        public int Id { get; set; }
        public Nullable<int> IdTeacher { get; set; }
        public Nullable<int> IdGroup { get; set; }
        public Nullable<int> IdSubject { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
