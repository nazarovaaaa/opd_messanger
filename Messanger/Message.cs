using System.ComponentModel.DataAnnotations;


namespace Messanger
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}