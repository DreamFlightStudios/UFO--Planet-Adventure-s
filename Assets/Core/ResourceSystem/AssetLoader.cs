using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.ResourceSystem
{
    internal class AssetLoader
    {
        public async Task<object> LoadAsset(string id)
        {
            var operation = Addressables.LoadAssetAsync<object>(id);
            await operation.Task;
            return operation.Status == AsyncOperationStatus.Failed ? null : operation.Result;
        }

        public void ReleaseAsset(object asset) => Addressables.Release(asset);
    }
}