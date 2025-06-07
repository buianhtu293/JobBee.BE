using Amazon.S3.Model;
using JobBee.Shared.Shared;
using Directory = JobBee.Shared.Shared.Directory;

namespace JobBee.Application.CloudService
{
	public interface ICloudService
	{
		Task<string> UploadFile(string contentType, string directory, Stream stream, string? oldUrl = null);
		Task<DeleteObjectResponse> DeleteFile(string url);
	}
}
