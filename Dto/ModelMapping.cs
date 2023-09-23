using Mapster;
using SchiaviDelPadel.Domain.Models;
using SchiaviDelPadel.Dto.ModelRequest;
using SchiaviDelPadel.Dto.ModelResponse;
using System.Text.RegularExpressions;

namespace SchiaviDelPadel.Dto
{
    public class ModelMapping : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.ForType<User, UserResponse>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.SlotDatesTime, src => src.Slots.Select(x=>x.DateTime).ToList());

            config.ForType<Slot, SlotResponse>()
                .Map(dest => dest.UserName, src => src.User.Name)
                .Map(dest => dest.DateTime, src => src.DateTime);

            config.ForType<UserRequest, User>();
            config.ForType<SlotRequest, Slot>();
        }
    }
}
