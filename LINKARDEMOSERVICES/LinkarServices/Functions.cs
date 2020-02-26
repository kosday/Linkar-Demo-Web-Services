using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkarClient;
using LinkarCommon;

namespace LinkarServices
{
    public class Functions
    {
        public static string SubDemoLinkar(string text, int seconds)
        {
            string error = "";
            string returnValue = "";
            CredentialsOptions crd = new CredentialsOptions("192.168.1.1", "MYENTRYPOINT", 11300, "admin", "admin", "", "LINKAR DEMO SERVICES");

            string args = seconds + ASCII_Chars.DC4_str + text + ASCII_Chars.DC4_str + "";
            LkData subResult = LinkarClt.RunSubroutine(crd, "SUB.DEMOLINKAR", 3, args);
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
