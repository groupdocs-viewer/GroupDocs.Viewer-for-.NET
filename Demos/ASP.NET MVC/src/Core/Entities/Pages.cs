using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Viewer.AspNetMvc.Core.Entities
{
    public class Pages : IEnumerable<Page>
    {
        readonly List<Page> _pages;

        public Pages()
        {
            _pages = new List<Page>();
        }

        public Pages(IEnumerable<Page> pages)
        {
            _pages = pages.ToList();
        }

        public void Add(Page page) => _pages.Add(page);

        public Page this[int index]
        {
            get => _pages[index];
            set => _pages.Insert(index, value);
        }

        public IEnumerator<Page> GetEnumerator() 
            => _pages.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();
    }
}