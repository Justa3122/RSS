using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS
{
    /// <summary>
    /// Klasa służy do odczytu znacznika <description>, ponieważ zawiera ona: opis, obrazek oraz link
    /// przez co XmlReader sobie z tym nie radzi.
    /// </summary>
    public class Description
    {
        public string Text { get; set; }
        public string ImgsrcFragment { get; set; }
        public string ImageLink { get; set; }

        private void GetImageLink(string imgsrcFragment)
        {
            ImageLink = imgsrcFragment.Substring(imgsrcFragment.IndexOf("src=") + 5, (imgsrcFragment.IndexOf("width") - 2) - (imgsrcFragment.IndexOf("src=") + 5));
        }
        public Description(string description)
        {
            try
            {
                ImgsrcFragment = description.Substring(description.IndexOf("<img"), description.IndexOf("/>") + 2);
                Text = description.Substring(description.IndexOf("/>") + 2, description.IndexOf("<a") - (description.IndexOf("/>") + 2));
                GetImageLink(ImgsrcFragment);
            }
            catch
            {
                Text = description;
                ImgsrcFragment = null;
                ImageLink = null;
            }
        }
    }
}
