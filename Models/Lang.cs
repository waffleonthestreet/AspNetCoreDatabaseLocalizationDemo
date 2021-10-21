using System;
using System.Collections.Generic;

#nullable disable

namespace AspNetCoreDatabaseLocalizationDemo.Models
{
    public partial class Lang
    {
        public Lang ()
        {
            StringResources = new HashSet<StringResource>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Culture { get; set; }

       
        public virtual ICollection<StringResource> StringResources { get; set; }
    }
}
