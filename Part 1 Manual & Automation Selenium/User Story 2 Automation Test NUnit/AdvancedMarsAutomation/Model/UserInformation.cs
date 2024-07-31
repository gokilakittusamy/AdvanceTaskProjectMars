using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Model
{
    public class UserInformation
    {

        private String email;
        private String password;
        private String firstName;
        private String lastName;

        public void setEmail(String email)
        {
            this.email = email;
        }


        public String getEmail()
        {
            return email;
        }


        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getPassword()
        {
            return password;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }


        public String getFirstName()
        {
            return firstName;
        }

    }
    public class UserAvailability
    {

        //private String availability;
        public String availability;


        public void setAvailability(String availability)
        {
            this.availability = availability;
        }

        public String getAvailability()
        {
            return availability;
        }
    }

    public class UserHours
    {

        //private String hours;
        public String hours;


        public void setHours(String hours)
         {
             this.hours = hours;
         }

         public String getHours()
         {
             return hours;
         }
    }

    public class UserEarnTarget
    {

        //private String earnTarget;
        public String earnTarget;


        public void setEarnTarget(String earnTarget)
        {
            this.earnTarget = earnTarget;
        }

        public String getEarnTarget()
        {
            return earnTarget;
        }
    }

}