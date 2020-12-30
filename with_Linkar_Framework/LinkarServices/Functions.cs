using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NEWFRAMEWORK: Linkar Framework Libraries
using Linkar;
using Linkar.LkData;
using Linkar.Strings;

namespace LinkarServices
{
    public class Functions
    {
        public static string SubDemoLinkar(string text, int seconds)
        {
            string error = "";
            string returnValue = "";
            CredentialOptions crd = new CredentialOptions("192.168.1.1", "MYENTRYPOINT", 11300, "admin", "admin", "", "LINKAR DEMO SERVICES"); //NEWFRAMEWORK: Replace CredentialsOptions for CredentialOptions

            string args = StringFunctions.ComposeSubroutineArgs(seconds.ToString(),text,""); //NEWFRAMEWORK: Compose subroutine arguments with funcion
            string lkString = Linkar.Functions.Direct.MV.Functions.Subroutine(crd, "SUB.DEMOLINKAR", 3, args); //NEWFRAMEWORK: Replace LinkarClt for Linkar.Functions.Direct.MV.Functions (Functions cause ambiguity), change return to string and add LkDataSubroutine consturctor below
            LkDataSubroutine subResult = new LkDataSubroutine(lkString);
            if (subResult != null && subResult.Arguments.Length == 3)
                //Get Result Value
                returnValue = subResult.Arguments[2];
            else
            {
                //Manage Errors
                if (subResult.Errors != null && subResult.Errors.Length > 0)
                    error = string.Join("\r\n", subResult.Errors);
                else if (subResult.Arguments.Length != 3)
                    error = "Invalid Output number of Arguments";
                else
                    error = "UNKNOW ERROR";
            }
            if (string.IsNullOrEmpty(error))
                return returnValue;
            else
                throw new Exception(error);
        }
    }
}
