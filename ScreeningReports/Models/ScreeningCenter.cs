//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScreeningReports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class ScreeningCenter
    {
        [Required(ErrorMessage = "UserName field is Required")]
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password field is Required")]
        public string password { get; set; }
        
        public string phoneNumber { get; set; }
        public int age { get; set; }
        public string Gender { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public string SCenterLogInErrorMessage { set; get; }
    }
}
