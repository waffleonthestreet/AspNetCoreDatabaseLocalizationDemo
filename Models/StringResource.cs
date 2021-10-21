using System;
using System.Collections.Generic;

#nullable disable

namespace AspNetCoreDatabaseLocalizationDemo.Models
{
    public partial class StringResource
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }

        public virtual Lang Language { get; set; }
    }
}
