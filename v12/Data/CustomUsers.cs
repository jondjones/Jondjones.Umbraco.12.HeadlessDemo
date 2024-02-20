using System.ComponentModel.DataAnnotations;

namespace v12.Data
{

    public class CustomUser {

        public string Name { get; set; }

        [MinLength(6)]
        public string Surname { get; set; }
    }
}
