using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Neoxim.Platform.Infrastructure.Externals.Autodesk
{
    public partial class APS
    {
        private async Task EnsureBucketExists(string bucketKey)
        {
            var token = await GetInternalToken();

            var api = new BucketsApi();
            api.Configuration.AccessToken = token.AccessToken;

            try
            {
                await api.GetBucketDetailsAsync(bucketKey);
            }
            catch (ApiException ae)
            {
                if(ae.ErrorCode == 404)
                {
                    await api.CreateBucketAsync(new PostBucketsPayload(bucketKey, null, PostBucketsPayload.PolicyKeyEnum.Transient));
                }
                else
                    throw ae;
            }
        }

        public async Task<ObjectDetails> UploadModel(string objectName, Stream content)
        {
            await EnsureBucketExists(_bucket);

            var token = await GetInternalToken();
            var api = new ObjectsApi();
            api.Configuration.AccessToken = token.AccessToken;
            var results = await api.uploadResources(_bucket, new List<UploadItemDesc>
            {
                new UploadItemDesc(objectName, content)
            });
            var data = results.FirstOrDefault();
            if(data?.Error ?? true)
            {
                throw new Exception(data?.completed.ToString() ?? "Upload failed!");
            }
            else
            {
                var json = data.completed.ToJson();
                return json.ToObject<ObjectDetails>();
            }
        }

        public async Task<IEnumerable<ObjectDetails>> GetObjectsAsync()
        {
            await EnsureBucketExists(_bucket);
            
            const int PageSize = 64;
            var token = await GetInternalToken();
            var api = new ObjectsApi();
            api.Configuration.AccessToken = token.AccessToken;

            var results = new List<ObjectDetails>();

            var response = (await api.GetObjectsAsync(_bucket, PageSize)).ToObject<BucketObjects>();

            results.AddRange(response.Items);

            while(!string.IsNullOrEmpty(response.Next))
            {
                response = (await api.GetObjectsAsync(_bucket, PageSize, beginsWith: null, startAt: null)).ToObject<BucketObjects>();
                results.AddRange(response.Items);
            }

            return results;
        }
    }
}