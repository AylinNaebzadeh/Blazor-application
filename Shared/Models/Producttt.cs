using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDB.Shared.Models
{
    public class Product
    {
        [Required]
        public string Catagory{get; set;}
        public int ID{get; set;}
        [Required]
        public int Price{get; set;}
        [Required]
        public int  Inventory{get; set;}//-->تعداد موجودی در انبار
        [Required]

        public string Size{get; set;}
        [Required]
        public string Material{get; set;}
        [Required]
        [RegularExpression("http(s)?://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\\'\\,]*)?" , ErrorMessage ="Url is not valid")]
        public string ImgURL{get; set;}
        public Product(){}

        public Product(int id,int price,int inventory,string size,string material,string img,string Cat)
        {
            this.ID = id;
            this.Price = price;
            this.Size = size;
            this.Material = material;
            this.ImgURL = img;
            this.Catagory = Cat;
        }

        public override int GetHashCode()
        {
            return Size.GetHashCode()^ImgURL.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Product other && other !=null)
            {
                if(Price==other.Price && Size==other.Size && Material==other.Material && ImgURL==other.ImgURL)
                return true;
            }
            return false;
        }
    }
}