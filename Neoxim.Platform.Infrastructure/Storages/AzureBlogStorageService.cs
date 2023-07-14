using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Options;

namespace Neoxim.Platform.Infrastructure.Storages
{
    public class AzureBlogStorageService : IStorageService
    {
        private readonly AzureStorageOptions _options;
        private readonly BlobServiceClient _serviceClient;

        public AzureBlogStorageService(IOptions<AzureStorageOptions> options)
        {
            _serviceClient = new BlobServiceClient(options.Value.ConnectionString);
            _options = options.Value;
        }

        public async Task<object> GetBlobPropertiesAsync(string fileUrl, CancellationToken token = default)
        {
            var (containerName, fileName) = GetContainerNameAndFileName(fileUrl);

            var containerClient = _serviceClient.GetBlobContainerClient(containerName);

            var blogClient = containerClient.GetBlobClient(fileName);

            var properties = await blogClient.GetPropertiesAsync(cancellationToken: token);

            return properties.Value as BlobProperties;
        }

        public async Task<byte[]> DownloadFileAsync(string fileUrl, CancellationToken token = default)
        {
            var (containerName, fileName) = GetContainerNameAndFileName(fileUrl);

            var containerClient = _serviceClient.GetBlobContainerClient(containerName);
            var blogClient = containerClient.GetBlobClient(fileName);

            var result = await blogClient.DownloadContentAsync(cancellationToken: token);

            return result.Value.Content.ToArray();
        }

        public async Task<bool> CopyFileToStreamAsync(string fileUrl, Stream stream, CancellationToken token = default)
        {
            var (containerName, fileName) = GetContainerNameAndFileName(fileUrl);

            var containerClient = _serviceClient.GetBlobContainerClient(containerName);
            var blogClient = containerClient.GetBlobClient(fileName);

            var result = await blogClient.DownloadToAsync(stream, cancellationToken: token);

            return result.IsError;
        }

        public async Task<string> UploadFileAsync(Guid tenantId, Guid documentId, string fileContentType, Stream fileStream)
        {
            var containerName = tenantId.ToString("N");
            var containerClient = _serviceClient.GetBlobContainerClient(containerName);
            // if(containerClient == null)
            // {
            //     containerClient = (await _serviceClient.CreateBlobContainerAsync(containerName)).Value;
            // }
            await containerClient.CreateIfNotExistsAsync();

            //var fileName = $"{documentId:N}{GetExtension(fileContentType)}".ToLower();
            var fileName = $"{documentId:N}".ToLower();

            var blogClient = containerClient.GetBlobClient(fileName);

            await blogClient.UploadAsync(fileStream);

            var fileUrl = $"https://{_options.AccountName}.blob.core.windows.net/{containerName}/{fileName}";

            return fileUrl;
        }

        public async Task DeleteAsync(string fileUrl)
        {
            var (containerName, fileName) = GetContainerNameAndFileName(fileUrl);

            var containerClient = _serviceClient.GetBlobContainerClient(containerName);
            var blogClient = containerClient.GetBlobClient(fileName);

            await blogClient.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        private static (string, string) GetContainerNameAndFileName(string fileUrl)
        {
            var parts = fileUrl.Replace("https://", "").Split('/');

            var containerName = parts[1];
            var fileName = parts[2];

            return (containerName, fileName);
        }

        //https://developer.mozilla.org/fr/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types
        private static string GetExtension(string contentType)
        {
            return contentType switch
            {
                "video/mp4" => ".mp4",
                "video/mpeg" => ".mpeg",
                "video/mpeg3" => ".mpeg",
                "video/x-mpeg" => ".mpeg",
                "video/x-msvideo" => ".avi",
                "video/ogg" => ".oga",

                "audio/aac" => ".acc",
                "audio/mpeg" => ".mpeg",
                "audio/mpeg3" => ".mpeg",
                "audio/x-mpeg-3" => ".mpeg",
                "audio/midi" => ".midi",
                "audio/ogg" => ".oga",

                "image/png" => ".png",
                "image/jpeg" => ".jpg",
                "image/bmp" => ".bmp",
                "image/gif" => ".gif",

                "application/pdf" => ".pdf",
                "application/msword" => ".doc",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => ".docx",
                "application/vnd.ms-powerpoint" => ".ppt",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation" => ".pptx",
                "application/vnd.ms-excel" => ".xls",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" => ".xlsx",
                "application/zip" => ".zip",
                "application/x-7z-compressed" => ".7z",

                "text/csv" => ".csv",

                _ => $".{contentType}",
            };
        }
    }
}