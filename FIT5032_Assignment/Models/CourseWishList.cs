//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseWishList
    {
        public int Id { get; set; }
        public System.DateTime InsertDate { get; set; }
        public int TrainingCourseId { get; set; }
        public string AspNetUserId { get; set; }
    
        public virtual TrainingCourse TrainingCourse { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}