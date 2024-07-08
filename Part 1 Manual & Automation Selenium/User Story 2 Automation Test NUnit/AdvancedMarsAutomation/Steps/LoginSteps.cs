using AdvancedMarsAutomation.Model;
using AdvancedMarsAutomation.Pages;
using AdvancedMarsAutomation.Pages.Components.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Steps
{
    public class LoginSteps
    {
        SplashPage loginPage;
        LoginComponent loginComponent;

        public LoginSteps()
        {
            loginPage = new SplashPage();
            loginComponent = new LoginComponent();
        }

        public void DoLogin()
        {
            /*
            loginPage.ClickSignInButton();
                      
            UserInformation userInformation = new UserInformation();
            userInformation.setEmail("testdata@gmail.com");
            userInformation.setPassword("123123");

            loginComponent.DoSignIn(userInformation);
            */
        }
    }
}
