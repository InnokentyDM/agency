using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agency.Models
{
    public class AddAdModel
    {
        public AddAdModel()
        {
            Files = new List<HttpPostedFileBase>();
        }
        public Ad advert { get; set; }
        public OBJ obj { get; set; }
        public List<HttpPostedFileBase> Files { get; set; }
     

    }
}