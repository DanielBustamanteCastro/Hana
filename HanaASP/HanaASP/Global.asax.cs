using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace HanaASP
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            //      new ScriptResourceDefinition
            //      {
            //          Path = "/Scripts/jquery-1.8.0.js"
            //      }
            //      );
            //ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            //myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            //myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            //myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            //myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            //ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

        }
    }
}