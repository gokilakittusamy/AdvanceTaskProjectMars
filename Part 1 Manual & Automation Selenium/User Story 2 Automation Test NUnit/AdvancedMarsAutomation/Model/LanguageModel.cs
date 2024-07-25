using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Model
{
    public class LanguageModel
    {
        private string _languageName;
        private string _languageLevel;

        public string LanguageName
        {
            get { return _languageName; }
            set { _languageName = value; }
        }

        public string LanguageLevel
        {
            get { return _languageLevel; }
            set { _languageLevel = value; }
        }
    }
 }
