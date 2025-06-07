
using Amazon.S3;
using Amazon.S3.Model;
using JobBee.Shared.Shared;
using JobBee.Shared.Ultils;
using Microsoft.Extensions.Options;

namespace JobBee.Application.CloudService
{
	public class AWSService(
		IAmazonS3 s3Client,
		IOptions<S3Settings> s3Settings
	) : ICloudService
	{
		private const string cloudFrontUrl = "https://d337z7935xgdcs.cloudfront.net";

		/// <summary>
		/// Upload file to AWS S3 
		/// </summary>
		/// <param name="contentType">content type of file</param>
		/// <param name="directory">Directory where store file</param>
		/// <param name="stream">stream of file</param>
		/// <param name="oldFileUrl">pass old file url if it exists</param>
		/// <returns></returns>
		public async Task<string> UploadFile(string contentType, string directory, Stream stream, string? oldFileUrl = null)
		{
			if (oldFileUrl != null) {
				await Delete(oldFileUrl);
			}
			var fileName = FileNameGenerator.GenerateFileName();
			var key = $"{directory}/{Guid.NewGuid()}_{fileName}";
			var putRequest = new PutObjectRequest
			{
				BucketName = s3Settings.Value.BucketName,
				Key = key,
				InputStream = stream,
				ContentType = contentType,
				ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
				Metadata =
				{
					["file-name"] = fileName,
					["upload-timestamp"] = DateTime.UtcNow.ToString("O")
				}
			};

			await s3Client.PutObjectAsync(putRequest);
			stream.Close();
			return $"{cloudFrontUrl}/{key}";
		}

		/// <summary>
		/// delete file
		/// </summary>
		/// <param name="url">Pass file url</param>
		/// <returns>delete response</returns>

		public async Task<DeleteObjectResponse> DeleteFile(string url)
		{
			var response = await Delete(url);
			return response;
		}

		private async Task<DeleteObjectResponse> Delete(string url)
		{
			var uri = new Uri(url);

			string path = uri.AbsolutePath;

			string key = path.StartsWith("/") ? path.Substring(1) : path;

			var deleteRequest = new DeleteObjectRequest
			{
				BucketName = s3Settings.Value.BucketName,
				Key = key
			};

			var response = await s3Client.DeleteObjectAsync(deleteRequest);

			return response;
		}

	}
}
