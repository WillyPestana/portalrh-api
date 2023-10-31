using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Dtos
{
    public class ChatTypeOneToOneDto
    {
        [Required]
        public string To { get; set; } = null!;

        [Required]
        public string From { get; set; } = null!;

        private string _message = null!;

        [Required]
        public string Message
        {
            get => _message;
            set => _message = Regex.Replace(value, @"[\r\n]+", "<br/>");
        }
    }
}
