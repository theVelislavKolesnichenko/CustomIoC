using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SendEmailService
{
    [ServiceContract]
    public interface ISendEmail
    {
        [OperationContract]
        void Send(string emailFrom, string password,
            string emailTo, string subject, string body);

    }
}
