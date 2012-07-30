
#define SIMPLE_JSON_DYNAMIC

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataBase;



namespace WebServices
{
    /// <summary>
    /// Summary description for StrefaKibica
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StrefaKibica : System.Web.Services.WebService
    {
        DataBaseEntity.DataBase _data = new DataBaseEntity.DataBase();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

      
        [WebMethod]
        public string GetEventTypes()
        {
            return SimpleJson.SerializeObject(_data.GetEventTypes()); //.SerializeObject(_data.GetEventTypes());
        }


        [WebMethod]
        public string test()
        {
            var ret = _data.GetEventTypes();
            return  SimpleJson.SerializeObject(ret);
        }
    }
}
