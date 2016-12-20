using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSoftUni.Models
{
    namespace ImageUploadApp.Models
    {
        using System;
        using System.Collections.Generic;

        public partial class Image
        {
            public int ID { get; set; }
            public string ImagePath { get; set; }
        }
    }
}