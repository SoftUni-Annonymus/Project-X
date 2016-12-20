﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSoftUni.Models.ImageUploadApp.Models;

namespace BlogSoftUni.Models
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public virtual IDbSet<Article> Articles { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public  virtual IDbSet<Article.Tag> Tags { get; set; }
        public virtual IDbSet<Image> ImageGallery { get; set; }
        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}