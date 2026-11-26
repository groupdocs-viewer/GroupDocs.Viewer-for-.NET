namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.CachingResults.ImplementThreadSafeCacheForGroupdocsViewer;

using System.Collections.Concurrent;

interface IKeyLockerStore
{
    object GetLockerFor(string key);
}

class ConcurrentDictionaryKeyLockerStore : IKeyLockerStore
{
    private readonly ConcurrentDictionary<string, object> _keyLockerMap;
    private readonly string _uniqueKeyPrefix;

    public ConcurrentDictionaryKeyLockerStore(ConcurrentDictionary<string, object> keyLockerMap, string uniqueKeyPrefix)
    {
        _keyLockerMap = keyLockerMap;
        _uniqueKeyPrefix = uniqueKeyPrefix;
    }

    public object GetLockerFor(string key)
    {
        string uniqueKey = GetUniqueKey(key);
        return _keyLockerMap.GetOrAdd(uniqueKey, k => new object());
    }

    private string GetUniqueKey(string key)
    {
        return $"{_uniqueKeyPrefix}_{key}";
    }
}

public static class ThreadSafeCacheKeyLocker
{
    public static void Run()
    {
        // ...
    }
}
