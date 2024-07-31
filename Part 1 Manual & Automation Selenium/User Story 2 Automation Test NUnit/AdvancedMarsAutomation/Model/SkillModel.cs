using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Model
{
    public class SkillModel
    {
        private string _skillName;
        private string _skillLevel;
        private string _happyPathUpdate;
        
        public string SkillName
        {
            get { return _skillName; }
            set { _skillName = value; }
        }

        public string SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }
    }
    public class SkillData
    {
        public List<SkillModel> HappyPathUpdate { get; set; }
        public List<SkillModel> SkillAlreadyExist { get; set; }
        public List<SkillModel> ChangeLevelOnly { get; set; }
        public List<SkillModel> UpdateSkillWithExistingDataWithoutChangingTheLevel { get; set; }

        public SkillData()
        {
            HappyPathUpdate = new List<SkillModel>();
            SkillAlreadyExist = new List<SkillModel>();
            ChangeLevelOnly = new List<SkillModel>();
            UpdateSkillWithExistingDataWithoutChangingTheLevel = new List<SkillModel>();
        }
    }
}
