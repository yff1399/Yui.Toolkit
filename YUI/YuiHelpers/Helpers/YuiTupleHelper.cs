using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YuiHelpers.Helpers
{
    public static class YuiTupleHelper
    {
        /// <summary>
        /// 通过T1找出T2
        /// </summary>
        /// <param name="Item1"></param>
        /// <returns></returns>
        public static string Find(IList<Tuple<string, string>> lt, string t1)
        {
            string t2 = null;

            foreach (var item in lt)
            {
                if (item.Item1.Equals(t1))
                {
                    t2 = item.Item2;
                }
            }
            return t2;
        }

        public static string Serializ(this Tuple<string, string> tuple2)
        {
            return $"{tuple2.Item1}:{tuple2.Item2}";
        }

        public static Tuple<string, string> Deserialize(string strTuple)
        {
            var strArr = strTuple?.Split(':');
            if (strArr?.Length == 2)
            {
                return Tuple.Create(strArr[0], strArr[1]);
            }
            return null;
        }
        public static string Serialize(this IList<Tuple<string, string>> tuple2s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tuple2s)
            {
                sb.Append($"{item.Serializ()},");
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public static List<Tuple<string, string>> DeserializeList(string strTuples)
        {
            if (string.IsNullOrWhiteSpace(strTuples))
                return null;

            List<Tuple<string, string>> tupleList = new List<Tuple<string, string>>();
            var strArr = strTuples?.Split(',');
            if (strArr != null)
            {
                Tuple<string, string> tmp = null;
                foreach (var str in strArr)
                {
                    tmp = Deserialize(str);
                    if (tmp == null)
                        continue;
                    tupleList.Add(tmp);
                }

                if (tupleList.Count > 0)
                {
                    return tupleList;
                }
            }
            return null;
        }
    }
}
