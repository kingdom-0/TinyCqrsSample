using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCqrsSample.Core.Reporting
{
    public class ReportDatabase:IReportDatabase
    {
        private static readonly List<DiaryItemDto> Items = new List<DiaryItemDto>();

        public DiaryItemDto GetById(Guid id)
        {
            return Items.FirstOrDefault(d => d.Id == id);
        }

        public void Add(DiaryItemDto item)
        {
            Items.Add(item);
        }

        public void Delete(Guid id)
        {
            Items.RemoveAll(d => d.Id == id);
        }

        public List<DiaryItemDto> GetItems()
        {
            return Items;
        }
    }
}
