using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Models.Response
{
	public class ApiResponse<T>
	{
		public string Type { get; set; }
		public int Status { get; set; }
		public T Data { get; set; }

		public ApiResponse(string type, int status, T data)
		{
			Type = type;
			Status = status;
			Data = data;
		}
	}
}
