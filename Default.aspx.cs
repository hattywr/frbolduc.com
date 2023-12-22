using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azure.Identity;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Buldoc_Reader_Take_4
{
    public partial class _Default : Page
    {

        //Buldoc_Storage_Connections connections = new Buldoc_Storage_Connections();
        protected void Page_Load(object sender, EventArgs e)
        {
          //need a place to send feedback and email frbolduc@gmail.com
          // Sources
          // Images
          // Descriptions of items 
        }

        protected void audio_redirect_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Audio_Table_Of_Contents.aspx");
        }

        protected void video_redirect_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Video_Table_Of_Contents.aspx");
        }

        protected void image_redirect_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Image_Table_Of_Contents.aspx");
        }

        protected void sources_redirect_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sources_Table_Of_Contents.aspx");
        }
    }
}