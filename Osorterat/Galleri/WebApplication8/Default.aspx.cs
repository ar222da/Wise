using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class Default : System.Web.UI.Page
    {
        private Gallery _gallery;

        private Gallery Gallery
        {
            get { return _gallery ?? (_gallery = new Gallery()); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
                var filename = Request.QueryString["FileName"];

                if (filename != null)
                {
                    Image1.ImageUrl = "~/Content/" + filename.ToString();
                    Image1.Visible = true;
                }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = FileUpload1.FileName;
            Stream content = FileUpload1.FileContent;
            Gallery.SaveImage(content, filename);
            Response.Redirect("~/Default.aspx?FileName="+FileUpload1.FileName, true);
        }

        public IEnumerable<string> Repeater_GetData()
        {
            return Gallery.GetImageNames();
        }
    }
}

        