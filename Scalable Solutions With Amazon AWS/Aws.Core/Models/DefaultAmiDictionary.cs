using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aws.Core.Models
{
    public class DefaultAmiDictionary : IDictionary<AwsRegionLocations, string>
    {
         private IDictionary<AwsRegionLocations, string> dictionary = new Dictionary<AwsRegionLocations, string>();
        public IEnumerator<KeyValuePair<AwsRegionLocations, string>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) dictionary).GetEnumerator();
        }

        public void Add(KeyValuePair<AwsRegionLocations, string> item)
        {
            dictionary.Add(item);
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public bool Contains(KeyValuePair<AwsRegionLocations, string> item)
        {
            return dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<AwsRegionLocations, string>[] array, int arrayIndex)
        {
            dictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<AwsRegionLocations, string> item)
        {
            return dictionary.Remove(item);
        }

        public int Count
        {
            get { return dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return dictionary.IsReadOnly; }
        }

        public bool ContainsKey(AwsRegionLocations key)
        {
            return dictionary.ContainsKey(key);
        }

        public void Add(AwsRegionLocations key, string value)
        {
            dictionary.Add(key, value);
        }

        public bool Remove(AwsRegionLocations key)
        {
            return dictionary.Remove(key);
        }

        public bool TryGetValue(AwsRegionLocations key, out string value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        public string this[AwsRegionLocations key]
        {
            get { return dictionary[key]; }
            set { dictionary[key] = value; }
        }

        public ICollection<AwsRegionLocations> Keys
        {
            get { return dictionary.Keys; }
        }

        public ICollection<string> Values
        {
            get { return dictionary.Values; }
        }
    }
}