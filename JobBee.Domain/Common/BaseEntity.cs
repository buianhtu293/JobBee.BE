using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Domain.Common
{
	public abstract class BaseEntity<TKey>
	{
		[Key]
		public TKey Id { get; set; }
        public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
    }
}
