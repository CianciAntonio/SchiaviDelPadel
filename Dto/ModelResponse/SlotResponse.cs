using SchiaviDelPadel.Domain.Models;
using System.Text.Json.Serialization;

namespace SchiaviDelPadel.Dto.ModelResponse
{
    public class SlotResponse
    {
        public string UserName { get; set; }
        public string DateTime { get; set; }
    }
}
