using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Models
{
    public class Lembrete
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
