﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LastCakeProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Orders = new HashSet<Order>();
        }
        [DisplayName("Mã nhân viên")]
        public int employeeId { get; set; }
        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }
        [DisplayName("Mật khâu")]
        public string password { get; set; }
        [DisplayName("Tên")]
        public string employeeName { get; set; }
        [DisplayName("Số điện thoại")]
        public string employeePhone { get; set; }
        [DisplayName("Emial")]
        public string employeeEmail { get; set; }
        [DisplayName("Địa chỉ")]
        public string employeeAddress { get; set; }
        [DisplayName("Ngày tạo")]
        public System.DateTime createAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}