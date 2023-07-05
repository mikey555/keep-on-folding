using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ExtensionMethods
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list, System.Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class TransformExtensions
    {
        public static void SetX(this Transform t, float value)
        {
            Vector3 v = t.position;
            v.x = value;
            t.position = v;
        }
        public static void SetY(this Transform t, float value)
        {
            Vector3 v = t.position;
            v.y = value;
            t.position = v;
        }
        public static void SetZ(this Transform t, float value)
        {
            Vector3 v = t.position;
            v.z = value;
            t.position = v;
        }

        public static void SetLocalX(this Transform t, float value)
        {
            Vector3 v = t.localPosition;
            v.x = value;
            t.localPosition = v;
        }

        public static void SetLocalY(this Transform t, float value)
        {
            Vector3 v = t.localPosition;
            v.y = value;
            t.localPosition = v;
        }
        public static void SetLocalZ(this Transform t, float value)
        {
            Vector3 v = t.localPosition;
            v.z = value;
            t.localPosition = v;
        }
    }
}