using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSoftUni.Models
{
    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles=new HashSet<Article>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique  = true)]
        [StringLength(22)]
        public  string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}