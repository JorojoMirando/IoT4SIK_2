using IoT4SIK.Util;
using SQLite;

namespace IoT4SIK.Model
{
    [Table("tbUser")]
    public class User
    {
        [PrimaryKey]
        public string _id { get; set; }
        public TypeUser typeUser { get; set; }
        public string name { get; set; }
    }
}