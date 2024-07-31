using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Model
{
    public class SearchSkillModel
    {
        private string _mainCategory;
        private string _subCategory;
        private string _skillTitle;
        private string _searchByUser;
        private string _skillFilter;

        public string MainCategory
        {
            get { return _mainCategory; }
            set { _mainCategory = value; }
        }
        public string SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }
        public string SkillTitle
        {
            get { return _skillTitle; }
            set { _skillTitle = value; }
        }
        public string SearchByUser
        {
            get { return _searchByUser; }
            set { _searchByUser = value; }
        }

        public string SkillFilter
        {
            get { return _skillFilter; }
            set { _skillFilter = value; }
        }
    }
}
