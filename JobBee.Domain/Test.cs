using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Common;

namespace JobBee.Domain
{
	public class Test :BaseEntity<Guid>
	{
        public string Name { get; set; }
    }
}
