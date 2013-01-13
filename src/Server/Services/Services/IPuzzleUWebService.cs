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
    [DataContract]
    public class Returned
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class LoginReposne
    {
        [DataMember]
        public bool success { get; set; }

        [DataMember]
        public int userId { get; set; }

        [DataMember]
        public string error { get; set; }
    }

    [DataContract]
    public class SignupReposne
    {
        [DataMember]
        public bool success { get; set; }

        [DataMember]
        public int userId { get; set; }

        [DataMember]
        public string error { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IPuzzleUWebService
    {       
        [OperationContract, WebInvoke(UriTemplate = "login?username={userName}", Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        LoginReposne Login(string userName); //string userName

        [OperationContract, WebInvoke(UriTemplate = "signup?username={userName}", Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        SignupReposne Signup(string userName); //string userName
    }

}
