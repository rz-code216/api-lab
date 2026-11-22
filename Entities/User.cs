//This using isn't used in this file: you can remove it
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        //In C#, properties are written in PascalCase: UserId. users.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
        public int userId { get; set; }
        public string firstname { get; set; }

        public string lastname { get; set; }
        
        public string email { get; set; }
        
        public string password { get; set; }
    }
}
