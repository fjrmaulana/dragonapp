﻿using System;
using System.Runtime.Caching;

namespace IDS.Tool
{
    interface ICache
    {
        T GetOrSet<T>(string cacheKey, System.Func<T> getItemCallback) where T : class;
    }
        
    public class InMemoryCache : ICache
    {
        private static object locker = new object();

        private static InMemoryCache _instance;

        public static InMemoryCache GetInstance()
        {
            if (_instance == null)
                _instance = new InMemoryCache();

            return _instance;
        }

        /// <summary>
        /// Set atau Get data dari cache. Default lama penyimpanan adalah 10 menit
        /// </summary>
        /// <typeparam name="T">Tipe data output</typeparam>
        /// <param name="cacheKey">Key dari cache</param>
        /// <param name="getItemCallback">Method yang dijalankan jika cache kosong atau tidak ditemukan</param>
        /// <returns>Tipe data result adalah List Collection</returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;

            if (item == null)
            {
                lock (locker)
                {
                    item = MemoryCache.Default.Get(cacheKey) as T;

                    if (item == null) // Double Checking
                    {
                        item = getItemCallback();
                        MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// Set atau Get data dari cache. Durasi lama penyimpanan sesuai dengan parameter
        /// </summary>
        /// <typeparam name="T">Tipe data output</typeparam>
        /// <param name="cacheKey">Key dari cache</param>
        /// <param name="getItemCallback">Method yang dijalankan jika cache kosong atau tidak ditemukan</param>>
        /// <param name="cacheDuration">Lama penyimpanan data didalam cache dalam menit</param>
        /// <returns>Tipe data result adalah List Collection</returns>
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, int cacheDuration) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;

            if (item == null)
            {
                lock (locker)
                {
                    item = MemoryCache.Default.Get(cacheKey) as T;

                    if (item == null) // Double Checking
                    {
                        item = getItemCallback();
                        MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(cacheDuration));
                    }
                }
            }

            return item;
        }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<T>> GetOrSet<T>(string cacheKey, string dictionaryKey, Func<System.Collections.Generic.List<T>> getItemCallback, int cacheDuration) where T : class
        {
            System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<T>> dict = MemoryCache.Default.Get(cacheKey) as System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<T>>;

            if (dict == null)
            {
                lock (locker)
                {
                    dict = MemoryCache.Default.Get(cacheKey) as System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<T>>;

                    if (dict == null) // Double Checking
                    {
                        // Retrieve data yang di cari
                        System.Collections.Generic.List<T> items = getItemCallback();

                        if (items != null && (items as System.Collections.Generic.List<T>).Count > 0)
                        {
                            dict = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<T>>();

                            dict[dictionaryKey] = items as System.Collections.Generic.List<T>;
                            MemoryCache.Default.Add(cacheKey, dict, DateTime.Now.AddMinutes(cacheDuration));
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (dict.ContainsKey(dictionaryKey))
                        {
                        }
                        else
                        {
                            System.Collections.Generic.List<T> item = getItemCallback();

                            if (item != null && (item as System.Collections.Generic.List<T>).Count > 0)
                            {
                                dict.Add(dictionaryKey, item);

                                MemoryCache.Default.Remove(cacheKey);
                                MemoryCache.Default.Add(cacheKey, dict, DateTime.Now.AddMinutes(cacheDuration));
                            }
                            else
                            {
                            }
                        }
                    }
                }

                return dict;
            }
            else
            {
                // Cek apakah user group sesuai parameter sudah ada atau belum
                if (dict.ContainsKey(dictionaryKey))
                {
                }
                else
                {
                    System.Collections.Generic.List<T> items = getItemCallback();

                    // Add to Cache
                    if (items != null && items.Count > 0)
                    {
                        dict.Add(dictionaryKey, items);

                        MemoryCache.Default.Set(cacheKey, dict, DateTime.Now.AddMinutes(cacheDuration));
                    }
                    else
                    {
                    }
                }

                return dict;
            }
        }
    }
}