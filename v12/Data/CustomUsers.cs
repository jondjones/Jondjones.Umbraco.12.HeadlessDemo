using System.ComponentModel.DataAnnotations;

namespace v12.Data {

    public class CustomUsers {

        public string Name { get; set; }

        [MinLength(6)]
        public string Surname { get; set; }


        //[Key]
        //public int UserId { get; set; }
    }
}
