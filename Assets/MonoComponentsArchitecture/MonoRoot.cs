using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoRoot : MonoBehaviour
{
    public IEnumerable<HashSet<object>> CachedComponents => _cachedComponentsMap.Values;

    private Dictionary<Type, HashSet<object>> _cachedComponentsMap = new Dictionary<Type, HashSet<object>>();

    public void ClearCachedComponents()
    {
        _cachedComponentsMap.Clear();
    }
        
    public T ResolveComponent<T>()
    {
        Type componentType = typeof(T);

        if (_cachedComponentsMap.TryGetValue(componentType, out var cachedComponents))
        {
            return (T)cachedComponents.First();
        }

        T foundComponent = FindComponent<T>();

        if (foundComponent == null) return default;
            
        CacheComponent(foundComponent);

        return foundComponent;
    }

    public bool TryResolveComponent<T>(out T component)
    {
        component = ResolveComponent<T>();

        return component != null;
    }

    public HashSet<T> ResolveComponents<T>(bool refreshCache = false)
    {
        T[] found = GetComponentsInChildren<T>();
        HashSet<T> result = new HashSet<T>(found);

        if (refreshCache)
        {
            foreach (var component in result)
            {
                CacheComponent(component);
            }
        }
            
        return result;
    }

    private T FindComponent<T>()
    {
        T foundComponent = GetComponentInChildren<T>();

        return foundComponent;
    }

    private void CacheComponent<T>(T component)
    {
        Type componentType = component.GetType();

        if (_cachedComponentsMap.ContainsKey(componentType) == false)
        {
            _cachedComponentsMap.Add(componentType, new HashSet<object>());
        }
            
        if(_cachedComponentsMap[componentType].Contains(component)) return;

        _cachedComponentsMap[componentType].Add(component);
    }
}
