using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Course.DataAccess.DataAccess
{
    public class DbItemRepository
    {
        public List<DbItem> GetAllDbItem(string filterTesto = null, 
            DateTime? filterDataMin = null, 
            DateTime? filterDataMax = null)
        { 
            var query = Database.Instance.Table<DbItem>();
             
            if (!String.IsNullOrEmpty(filterTesto))
                query = query.Where(x => x.Name.Contains(filterTesto));

            if (filterDataMax.HasValue)
                query = query.Where(x => x.EsempioData < filterDataMax.Value);

            if (filterDataMin.HasValue)
                query = query.Where(x => x.EsempioData > filterDataMin.Value);

            var result = query.ToList();
              
            return result;
        }

        public void Insert(string nuovoTesto)
        { 
            Database.Instance.BeginTransaction();

            var nuovoItem = new DbItem() {
                Name = nuovoTesto,
            };

            Database.Instance.Insert(nuovoItem);

            Database.Instance.Commit();
        }

        internal void Delete(DbItem item)
        {
            Database.Instance.Delete(item);
        }
    }
}
