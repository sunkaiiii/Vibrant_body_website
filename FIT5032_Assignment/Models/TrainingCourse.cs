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
    
    public partial class TrainingCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingCourse()
        {
            this.Rate = 0;
            this.TrainingCourseTimetables = new HashSet<TrainingCourseTimetable>();
            this.UserSkills = new HashSet<UserSkills>();
            this.CourseWishLists = new HashSet<CourseWishList>();
            this.CourseBookings = new HashSet<CourseBooking>();
        }
    
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CourseCapacity { get; set; }
        public string CourseHeldLocation { get; set; }
        public string CourseDescribtion { get; set; }
        public bool IsOver { get; set; }
        public short Rate { get; set; }
        public string AspNetUserId { get; set; }
        public Nullable<int> PreRequestId { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingCourseTimetable> TrainingCourseTimetables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSkills> UserSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseWishList> CourseWishLists { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseBooking> CourseBookings { get; set; }
    }
}