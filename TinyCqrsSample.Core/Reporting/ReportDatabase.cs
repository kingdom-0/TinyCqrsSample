using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCqrsSample.Core.Reporting
{
    public class ReportDatabase:IReportDatabase
    {
        private static List<DiaryItemDto> items = new List<DiaryItemDto>();

        public DiaryItemDto GetById(Guid id)
        {
            return items.Where(d => d.Id == id).FirstOrDefault();
        }

        public void Add(DiaryItemDto item)
        {
            items.Add(item);
        }

        public void Delete(Guid id)
        {
            items.RemoveAll(d => d.Id == id);
        }

        public List<DiaryItemDto> GetItems()
        {
            return items;
        }
    }
}
