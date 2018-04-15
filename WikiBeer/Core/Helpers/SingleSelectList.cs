using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WikiBeer.Core.Helpers
{
    public abstract class SingleSelectList
    {
        public List<SelectListItem> Items { get; protected set; }

        public string SelectedText
        {
            get
            {
                return Items.Single(sli => sli.Selected).Text;
            }
        }
    }

    public class SingleSelectList<TCollectionItem, TKey> : SingleSelectList
    {
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
                .ToList();
        }
    }
}