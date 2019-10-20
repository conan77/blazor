using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    public interface IEntityKey
    {
        object GetPrimaryKey();
        void SetPrimaryKey(object value);
    }
}
