using System;
using System.Threading.Tasks;

namespace Core.ResourceSystem
{
    public class AssetProvider : IDisposable
    {
        private readonly ResourceContainer _resourceContainer = new();
        private readonly AssetLoader _assetLoader = new();
        
        private bool _disposed;

        public async Task<object> GetAsset(string id)
        {
            RequireBeValid();

            if (_resourceContainer.TryGet(id, out object asset)) return asset;
            
            object result = await _assetLoader.LoadAsset(id);
            
            _resourceContainer.TryAdd(id, result);
            return result;
        }
        
        public async Task<T> GetAsset<T>(string id) where T : class => (T) await GetAsset(id);

        public bool ContainsAsset(string id)
        {
            RequireBeValid();
            return _resourceContainer.Contains(id);
        }

        public void ReleaseAsset(string id)
        {
            RequireBeValid();
            if (_resourceContainer.TryRemove(id, out object asset)) _assetLoader.ReleaseAsset(asset);
        }

        public void ReleaseAllAssets()
        {
            RequireBeValid();

            foreach (object asset in _resourceContainer.GetAll()) _assetLoader.ReleaseAsset(asset);
            _resourceContainer.Clear();
        }

        public int AssetsCount()
        {
            RequireBeValid();
            return _resourceContainer.Count();
        }

        public void Dispose()
        {
            ReleaseAllAssets();
            _disposed = true;
        }

        private void RequireBeValid() { if (_disposed) throw new ObjectDisposedException(nameof(AssetProvider)); }
    }
}