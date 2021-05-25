using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.Services
{
  public  class FAQ:BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
