using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;
using System.ServiceModel.Web;
using System.IO;


namespace PuzzleUServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IPuzzleUWebService
    {
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "signup", BodyStyle = WebMessageBodyStyle.Bare)]
        string Singup(Stream streamContent);
    }
}
