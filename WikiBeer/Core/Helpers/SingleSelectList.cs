using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WikiBeer.Core.Helpers
{
    public class SingleSelectList<TCollectionItem, TKey>
    {
        public SelectListItem[] Items { get; protected set; }

        public SingleSelectList(
            IEnumerable<TCollectionItem> items,
            Func<TCollectionItem, TKey> getValue,
            Func<TCollectionItem, string> getText,
            TKey selectedValue = default(TKey))
        {
            Items = items
                .Select(item =>
                {
                    var value = getValue(item);
                    return new SelectListItem
                    {
                        Value = value.ToString(),
                        Text = getText(item),
                        Selected = value.Equals(selectedValue)
                    };
                })
                .OrderBy(i => i.Text)
                .ToArray();
        }
    }
}