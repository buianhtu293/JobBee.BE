using JobBee.Application.CloudService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using JobBee.Application.PayOSService;

namespace JobBee.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestsController(ICloudService cloudService, IPayOSService payOSService) : ControllerBase
	{
		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			if (file.Length == 0)
			{
				return BadRequest("Missing File");
			} 
			var stream =  file.OpenReadStream();
			var url = await cloudService.UploadFile(file.ContentType, JobBee.Shared.Shared.Directory.Images, stream);
			return Ok(url);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFile([FromBody] string fileUrl)
		{
			var response = await cloudService.DeleteFile(fileUrl);
			var t = response.DeleteMarker;
			return Ok(t);
		}

		[HttpPost("{id}/payment")]
		public async Task<IActionResult> PaymentTest(Guid id)
		{
			var payResult = await payOSService.PayTransaction(id);
			return Ok(payResult);
		}
	}
}
