namespace Neoxim.Platform.Core.Infrastructure
{
    public interface IStorageService
    {
        Task<string> UploadFileAsync(Guid tenantId, Guid DocumentId, string fileContentType, Stream fileStream);

        Task<object> GetBlobPropertiesAsync(string fileUrl, CancellationToken token = default);

        Task<byte[]> DownloadFileAsync(string fileUrl, CancellationToken token = default);
        Task<bool> CopyFileToStreamAsync(string fileUrl, Stream stream, CancellationToken token = default);

        Task DeleteAsync(string fileUrl);
    }

}