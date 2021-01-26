using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMvcApp.Models
{
    public class DbActionResult
    {
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public bool Action { get; set; }
        public object Value { get; set; }
        public List<object> listObject { get; set; }
        public List<ReturnValues> listReturnValues { get; set; }
    }

    public class ReturnValues
    {
        public int intValue { get; set; }
        public string stringValue { get; set; }
        public string Description { get; set; }
    }
}
