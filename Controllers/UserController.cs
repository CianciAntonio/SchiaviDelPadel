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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IMapper _mapper { get; }

        public UserController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AddUser(UserRequest userRequest)
        {
            User user = _mapper.Map<User>(userRequest);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        [HttpGet("users")]
        public async Task<List<UserResponse>> GetAllUsers()
        {
            List<User> users = await _context.Users
                .AsNoTracking()
                .Include(y => y.Slots)
                .ToListAsync();

            List<UserResponse> usersResponse = _mapper.Map<List<UserResponse>>(users);

            return usersResponse;
        }
    }
}
