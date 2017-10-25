using UnitTestScreen.Models;

namespace UnitTestScreen.TestData
{
    public static class Config 
    {
        public static ConfigModel [] AuthenticateSet = new ConfigModel []
        {
            new ConfigModel
            {
                 ResourceUri = @"http://courses.way2automation.com",
                    UserName = @"i1go1by@gmail.com",
                UserPassword = @"321654"
            }
        };
    }
}
