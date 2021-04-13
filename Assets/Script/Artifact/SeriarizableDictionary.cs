using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serialize
{ 

    [System.Serializable]
    public class TableBase<TKey, TValue, Type> where Type : KeyAndValue<TKey, TValue>
    {
        [SerializeField]
        public List<Type> list;
        private Dictionary<TKey, TValue> table;
        //private double tei;

        public Dictionary<TKey, TValue> GetTable()
        {
            if (table == null)
            {
                table = ConvertListToDictionary(list);
            }
            return table;
        }

        /// <summary>
        /// Editor Only
        /// </summary>
        public List<Type> GetList()
        {
            return list;
        }

        static Dictionary<TKey, TValue> ConvertListToDictionary(List<Type> list)
        {
            Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
            foreach (KeyAndValue<TKey, TValue> pair in list)
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }
    }

    /// <summary>
    /// シリアル化できる、KeyValuePair
    /// </summary>
    [System.Serializable]
    public class KeyAndValue<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        [Tooltip("CalculateWayをExpにすると，底がteiであるような指数関数でコストを計算します．\n CalculateWayをAddにすると，" +
            "レベル当たりの増分がteiであるような線形関数でコストを計算します．\n 注：Logは使わないでね")]
        public ARTIFACT.CalculateWay calculateWay;
        [Tooltip("CalculateWayをExpにすると，底がteiであるような指数関数でコストを計算します．\n CalculateWayをAddにすると，" +
    "レベル当たりの増分がteiであるような線形関数でコストを計算します．\n 注：Logは使わないでね")]
        public double tei;

        public KeyAndValue(TKey key, TValue value,double tei)
        {
            Key = key;
            Value = value;
            this.tei = tei;
        }
        public KeyAndValue(KeyValuePair<TKey, TValue> pair,double tei)
        {
            Key = pair.Key;
            Value = pair.Value;
            this.tei = tei;
        }


    }
}
