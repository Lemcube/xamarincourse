using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course.DataAccess.DataAccess
{
    [Table("dbItem")]
    public class DbItem
    {
        // PrimaryKey is typically numeric
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EsempioData { get; set; }

        public bool EsempioBool { get; set; }

        public double EsempioDouble { get; set; }

        public int? NuericoNullabile { get; set; }
    }
}
