using System;
using System.Collections.Generic;

namespace Collection
{
    public class Q1
    {
        public static Dictionary<string,int> Execute(List<(string sku,int qty)> scans)
        {
            var dict = new Dictionary<string,int>();
            foreach (var (sku, qty) in scans)
            {
                if (qty <= 0) continue;
                if (dict.ContainsKey(sku)) dict[sku] += qty;
                else dict[sku] = qty;
            }
            return dict;
        }
    }
}
