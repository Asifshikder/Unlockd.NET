using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Service.Interface.Orders
{
  public  interface IImeiCheck
    {
       bool ImeiCheck(long imei);
    }
}
