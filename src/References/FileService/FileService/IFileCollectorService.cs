using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.ServiceModel.Web;

namespace FileService
{
    [ServiceContract]
    public interface IFileCollectorService
    {
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "invoke", BodyStyle =WebMessageBodyStyle.Bare)]
        string UploadFile(Stream fileContents);
    }
}
