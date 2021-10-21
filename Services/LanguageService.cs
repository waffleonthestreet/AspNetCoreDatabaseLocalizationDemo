using AspNetCoreDatabaseLocalizationDemo.Data;
using AspNetCoreDatabaseLocalizationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly MyAppDbContext _context;

        public LanguageService(MyAppDbContext context)
        {
            _context = context;
        }

        public Lang GetLanguageByCulture(string culture)
        {
            return _context.Langs.FirstOrDefault(x => x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }

        public IEnumerable<Lang> GetLanugages()
        {
            return _context.Langs.ToList();
        }
    }
}
