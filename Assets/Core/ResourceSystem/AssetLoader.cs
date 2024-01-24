using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.ResourceSystem
{
    internal class AssetLoader
    {
        private bool _isInitialized;
        
        public async Task Init()
        {
            await Addressables.InitializeAsync().Task;
            _isInitialized = true;
        }

        public async Task<object> LoadAsset(string id)
        {
            RequireBeValid();
            
            var operation = Addressables.LoadAssetAsync<object>(id);
            await operation.Task;
            return operation.Status == AsyncOperationStatus.Failed ? null : operation.Result;
        }

        public void ReleaseAsset(object asset)
        {
            RequireBeValid();
            Addressables.Release(asset);
        }

        private void RequireBeValid() { if (!_isInitialized) throw new InvalidOperationException($"{nameof(AssetLoader)} is not initialized"); }
    }
}