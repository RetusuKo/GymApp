using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    public List<TKey> Keys = new List<TKey>();
    public List<TValue> Values = new List<TValue>();
    public void OnAfterDeserialize()
    {
        Clear();
        if (Keys.Count !=Values.Count)
            Debug.LogError("Amount of keys and values are not equal");
        for (int i = 0; i < Values.Count; i++)
            Add(Keys[i] ,Values[i]);
    }

    public void OnBeforeSerialize()
    {
        Keys.Clear();
        Values.Clear();
        foreach (var item in this)
        {
            Keys.Add(item.Key);
            Values.Add(item.Value);
        }
    }
}
