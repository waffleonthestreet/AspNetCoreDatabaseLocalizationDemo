using AspNetCoreDatabaseLocalizationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public interface ILanguageService
    {
        IEnumerable<Lang> GetLanugages();
        Lang GetLanguageByCulture(string culture);
    }
}
