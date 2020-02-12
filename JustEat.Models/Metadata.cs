#region Usings

using System.Collections.Generic;

#endregion

namespace JustEat.Models
{
    public class Metadata
    {
        public object SearchedTerms { get; set; }
        public List<TagDetail> TagDetails { get; set; }

        public Metadata()
        {
            TagDetails = new List<TagDetail>();
        }
    }
}