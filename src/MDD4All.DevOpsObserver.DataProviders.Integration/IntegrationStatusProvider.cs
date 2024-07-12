using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.DataProviders.Bitbucket;
using MDD4All.DevOpsObserver.DataProviders.Contracts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MDD4All.DevOpsObserver.DataProviders.Integration
{
    public class IntegrationStatusProvider : IDevOpsStatusProvider
    {
        private BitbucketStatusProvider _bitbucketStatusProvider;

        public IntegrationStatusProvider(IConfiguration configuration, HttpClient httpClient)
        {
            _bitbucketStatusProvider = new BitbucketStatusProvider(configuration, httpClient);
        }


        public async Task<List<DevOpsStatusInformation>> GetDevOpsStatusListAsync(DevOpsSystem devOpsSystem)
        {
            List<DevOpsStatusInformation> result = new List<DevOpsStatusInformation>();

            if (devOpsSystem.SystemType == DevOpsSystemType.BitBucketCloud)
            {
                result = await _bitbucketStatusProvider.GetDevOpsStatusListAsync(devOpsSystem); 
            }

            return result;
        }

    }
}
