using System.ComponentModel.DataAnnotations;

namespace TestCaseVersta.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; } = System.Guid.NewGuid().ToString();

        public string SendersCity { get; set; }
        public string SendersAdress { get; set; }

        public string RecipientsCity { get; set; }
        public string RecipientsAdress { get; set; }

        public double CargoWeight { get; set; }

        public DateTime PickupDate { get; set; }
    }
}
