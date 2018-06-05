using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LastCakeProject.Models
{
    public class ProductMetadata
    {
        [DisplayName("Mã sản phẩm")]
        public int productId { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string productName { get; set; }
        [DisplayName("Ảnh sản phẩm")]
        public string productImage { get; set; }
        [DisplayName("Giá sản phẩm")]
        public decimal productPrice { get; set; }
        [DisplayName("Ngày tạo sản phẩm")]
        public System.DateTime createAt { get; set; }
        [DisplayName("Mổ tả sản phẩm")]
        public string productDescription { get; set; }
    }
}