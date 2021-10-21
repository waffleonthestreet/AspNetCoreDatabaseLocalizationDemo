using AspNetCoreDatabaseLocalizationDemo.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreDatabaseLocalizationDemo.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;

        public BaseController(ILanguageService languageService, ILocalizationService localizationService)
        {
            _languageService = languageService;
            _localizationService = localizationService;
        }

        public HtmlString Localize(string resourceKey, params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageService.GetLanguageByCulture(currentCulture);

            if (language != null)
            {
                var stringResource = _localizationService.GetStringResource(resourceKey, language.LanguageId);
                if (stringResource == null || string.IsNullOrEmpty(stringResource.ResourceValue))
                {
                    return new HtmlString(resourceKey);
                }

                return new HtmlString((args == null || args.Length == 0)?stringResource.ResourceValue : string.Format(stringResource.ResourceValue, args));
            }

            return new HtmlString(resourceKey);
        }
    }
}
