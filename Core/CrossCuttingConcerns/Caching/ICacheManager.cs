﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        void Remove(string key);
        void RemoveByPattern(string pattern); //patterne gore silme
        T Get<T>(string key);
        object Get(string key);
        bool IsAdd(string key);
    }
}
