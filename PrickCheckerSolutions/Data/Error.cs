//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrickCheckerSolutions.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string URL { get; set; }
        public Nullable<System.DateTime> DateLogged { get; set; }
        public Nullable<bool> Resolved { get; set; }
        public string ResolvedBy { get; set; }
        public Nullable<System.DateTime> ResolvedOn { get; set; }
    }
}