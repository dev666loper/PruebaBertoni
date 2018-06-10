using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVisorAlbum.Models
{
    public class FotoModel
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
          

    }
}