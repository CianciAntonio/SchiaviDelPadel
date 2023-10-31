using Microsoft.AspNetCore.Mvc;
using SchiaviDelPadel.Domain.Models;
using SchiaviDelPadel.Domain;
using Microsoft.EntityFrameworkCore;
using SchiaviDelPadel.Dto.ModelRequest;
using MapsterMapper;
using SchiaviDelPadel.Dto.ModelResponse;

namespace SchiaviDelPadel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SlotController : Controller
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public SlotController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AddSlot(SlotRequest slotRequest)
        {
            Slot slot = _mapper.Map<Slot>(slotRequest);
            await _context.Slots.AddAsync(slot);
            await _context.SaveChangesAsync();
        }

        [HttpGet("slots")]
        public async Task<List<SlotResponse>> GetAllSlots()
        {
            List<Slot> slots = await _context.Slots
                .AsNoTracking()
                .Include(y => y.User)
                .ToListAsync();

            List<SlotResponse> slotsResponse = _mapper.Map<List<SlotResponse>>(slots);

            return slotsResponse;
        }

        // Slot/ByDate?date=07/10/2023 08:30:00
        [HttpGet("byDate")]
        public async Task<List<SlotResponse>> GetSlotByDate(string date)
        {
            DateTime? _date = DateTime.Parse(date);
            DateTime dateOnly = _date.Value.Date;
            List<SlotResponse> timeSpans = new List<SlotResponse>()
            {
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(8.5)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(10)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(11.5)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(13)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(14.5)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(16)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(17.5)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(19)},                
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(20.5)},
                new SlotResponse{UserName= null ,DateTime = dateOnly.AddHours(22)}
            };
                
            List<Slot> slots = await _context.Slots
                .Where(x=>x.DateTime >= dateOnly && x.DateTime <= dateOnly.AddDays(1))
                .Include(y => y.User)
                .ToListAsync();

            List<SlotResponse> slotsResponse = _mapper.Map<List<SlotResponse>>(slots);

            foreach(var timeSpan in timeSpans)
            {
                foreach(var slot in slotsResponse)
                {
                    if(timeSpan.DateTime == slot.DateTime)
                    {
                        timeSpan.UserName = slot.UserName;
                    }
                }
            }

            return timeSpans;
        }
    }
}
