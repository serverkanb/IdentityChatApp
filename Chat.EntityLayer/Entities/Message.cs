namespace IdentityChat.Models.Entities
{
    public class Message

    {

        public int Id { get; set; }
        public string SenderId { get; set; }       // Identity user ID
        public string ReceiverId { get; set; }     // Identity user ID
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }

    }
}
