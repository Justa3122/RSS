using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS
{
    /// <summary>
    /// Klasa służy do odczytu poszczególnych elementów <description>
    /// Rozdziela go na opis oraz link do obrazka
    /// </summary>
    public class Description
    {
        public string Text { get; set; }
        public string ImgsrcFragment { get; set; }
        public string ImageLink { get; set; }

        public Description()
        {

        }

        private void GetImageLink(string imgsrcFragment)
        {
            if (imgsrcFragment.Contains("src="))
            {
                ImageLink = imgsrcFragment.Substring(imgsrcFragment.IndexOf("src=") + 5, (imgsrcFragment.IndexOf("width") - 2) - (imgsrcFragment.IndexOf("src=") + 5));
            }
            else
            {
                ImageLink = @"http://jopna.net/wp-content/plugins/special-recent-posts/images/no-thumb.png";
            }
        }
        public Description(string description)
        {
            try
            {
                Text = GetText(description);
                ImgsrcFragment = description.Substring(description.IndexOf("<img"), description.IndexOf("/>") + 2);
                GetImageLink(ImgsrcFragment);
            }
            catch
            {
                Text = GetText(description);
                ImgsrcFragment = null;
                ImageLink = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkJOK5c3FY4LEGltI9O20KPVdKbJrS3rzoQ1TvzMoKDmagAzsCAQ";
            }
        }
        private string GetText(string textWithLinks)
        {
            string text = textWithLinks;
            for (int i = 0; i < 3; i++)
            {
                if (text.Contains("<"))
                {
                    text = text.Remove(text.IndexOf("<"), (text.IndexOf(">") - text.IndexOf("<") + 1));
                } 
            }
            return text;
        }
    }
}
