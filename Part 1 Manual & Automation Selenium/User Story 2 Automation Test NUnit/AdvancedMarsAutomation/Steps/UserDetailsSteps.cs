
using NUnit.Framework;
using AdvancedMarsAutomation.AssertHelpers;
using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages.Components.ProfileOverview;
using AdvancedMarsAutomation.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Steps
{
    public class UserDetailsSteps
    {
        UserDetailsComponent userDetailsComponent;
        UserAvailability userAvailability;
        UserHours userHours;
        UserEarnTarget userEarnTarget;

        public UserDetailsSteps() {
            userDetailsComponent = new UserDetailsComponent();
            userAvailability = new UserAvailability();
            userHours = new UserHours();
            userEarnTarget = new UserEarnTarget();

        }

        public void EditAvailability()
        {

           // Read the Json file
            List<UserAvailability> _jsonData = JsonDataHelper.ReadJsonFile<UserAvailability>(ConstantHelper.AvailabilityPath);
            bool readOnlyFirstRow = false;
            
            // Use only the first set of data
            if (_jsonData.Count > 0)
             {
                 foreach (UserAvailability item in _jsonData)
                 {
                    if (!readOnlyFirstRow)
                    {
                       userAvailability.setAvailability(item.availability.ToString());
                       readOnlyFirstRow = true;
                    }
                 }
                userDetailsComponent.EditAvailability(userAvailability);
                String acutalSuccessMessage = userDetailsComponent.getSuccessMessage();
                AssertAvailability.assertUpdatedAvailabilitySuccessMessage("Availability updated", acutalSuccessMessage);
            }
            else
            {
                Assert.Fail("No data found in the Json file to change the availability.");
            }
        }

        public void EditHours()
        {
            // Read the Json file
            List<UserHours> _jsonData = JsonDataHelper.ReadJsonFile<UserHours>(ConstantHelper.HoursPath);
            bool readOnlyFirstRow = false;

            // Use only the first set of data
            if (_jsonData.Count > 0)
            {
                foreach (UserHours item in _jsonData)
                {
                    if (!readOnlyFirstRow)
                    {
                        userHours.setHours(item.hours.ToString());
                        readOnlyFirstRow = true;
                    }
                }
                userDetailsComponent.EditHours(userHours);
                String acutalSuccessMessage = userDetailsComponent.getSuccessMessage();
                //AssertHours.assertUpdatedHoursSuccessMessage("Hours updated", acutalSuccessMessage);
                AssertHours.assertUpdatedHoursSuccessMessage("Availability updated", acutalSuccessMessage);

            }
            else
            {
                Assert.Fail("No data found in the Json file to change the hours.");
            }
        }

        public void EditEarnTarget()
        {
            // Read the Json file
            List<UserEarnTarget> _jsonData = JsonDataHelper.ReadJsonFile<UserEarnTarget>(ConstantHelper.EarnTargetPath);
            bool readOnlyFirstRow = false;

            // Use only the first set of data
            if (_jsonData.Count > 0)
            {
                foreach (UserEarnTarget item in _jsonData)
                {
                    if (!readOnlyFirstRow)
                    {
                        userEarnTarget.setEarnTarget(item.earnTarget.ToString());
                        readOnlyFirstRow = true;
                    }
                }
                userDetailsComponent.EditEarnTarget(userEarnTarget);
                String acutalSuccessMessage = userDetailsComponent.getSuccessMessage();
                //AssertHours.assertUpdatedHoursSuccessMessage("Hours updated", acutalSuccessMessage);
                AssertEarnTarget.assertUpdatedEarnTargetSuccessMessage("Availability updated", acutalSuccessMessage);

            }
            else
            {
                Assert.Fail("No data found in the Json file to change the Earn Target.");
            }
        }
    }
}
