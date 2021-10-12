using System;

namespace Viridian.Demo.Informix.DataAccess
{
    public class Users
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string Fullname { get; set; }
        public string DocId { get; set; }
        public short Enabled { get; set; }
        public DateTime BirthDate { get; set; }
    }
}