using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers
{ 
    /// <summary>
    /// Concrete Json Parser Class
    /// </summary>
    public class JsonParser : IParseLogic
    {
        /// <summary>
        /// Parser Method for Json
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns>Dynamic Object</returns>
        public object Parse(String jsonData)
        {
            var serializer = new JavaScriptSerializer(); //need to use nancy because of system.web.script couldnt founded Maybe It is a VM issue
            dynamic jsonObject = serializer.DeserializeObject(jsonData);

            var jsonArray = jsonObject.ToArray();

            return jsonArray;

        }


    }
}
