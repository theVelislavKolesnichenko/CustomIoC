using SendEmail.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Data.Interface
{
    public interface IEmailRepository
    {
        List<User> GetPoints();
    }
}
