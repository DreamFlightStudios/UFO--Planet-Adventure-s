using System.Collections.Generic;

namespace Core.ResourceSystem
{
    internal class ResourceContainer
    {
        private readonly Dictionary<string, object> _assets = new();
        
        public bool TryAdd(string id, object obj) => _assets.TryAdd(id, obj);
        public bool TryGet(string id, out object obj) => _assets.TryGetValue(id, out obj);
        public IEnumerable<object> GetAll() => _assets.Values;
        public bool TryRemove(string id, out object obj) => _assets.Remove(id, out obj);
        public bool Contains(string id) => _assets.ContainsKey(id);
        public void Clear() => _assets.Clear();
        public int Count() => _assets.Count;
    }
}