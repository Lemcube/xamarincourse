using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.DataAccess.DataAccess
{
    public class DbItemAsyncRepository
    {
        public async Task<List<DbItem>> GetAllDbItemAsync(string filterTesto = null, 
            DateTime? filterDataMin = null, 
            DateTime? filterDataMax = null)
        { 
            var query = AsyncDatabase.Instance.Table<DbItem>();

            if (!String.IsNullOrEmpty(filterTesto))
                query = query.Where(x => x.Name.Contains(filterTesto));

            if (filterDataMax.HasValue)
                query = query.Where(x => x.EsempioData < filterDataMax.Value);

            if (filterDataMin.HasValue)
                query = query.Where(x => x.EsempioData > filterDataMin.Value);

            var result = await query.ToListAsync();
            // .ConfigureAwait(false);

            // ConfigureAwait(false); il metodo con cui viene risolto l'await in uscita non
            // è sincronizzato con l'interfaccia utente.
            /*
             * ConfigureAwait vale sono in questa zona!!!!!!
             */

            return result;
        }

        public void Insert(string name, string description, DateTime date)
        {
            var nuovoItem = new DbItem() {
                Name = name,
                Description = description,
                EsempioData = date
            };

            Database.Instance.Insert(nuovoItem);
        }

        public void Udate(int id, string name, string description, DateTime date)
        {
            var itemToUpdate = new DbItem()
            {
                Id = id,
                Name = name,
                Description = description,
                EsempioData = date
            };

            Database.Instance.Update(itemToUpdate);
        }
    }
}
