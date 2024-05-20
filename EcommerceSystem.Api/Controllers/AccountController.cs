using EcommerceSystem.BL;
using EcommerceSystem.BL.DTOs.Account;
using EcommerceSystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ICustomerManager _customerManager;

        public AccountController(UserManager<ApplicationUser> userManager,IConfiguration configuration,ICustomerManager customerManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _customerManager = customerManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult>  Register(RegisterDto userCreds)
        {
            if(ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser
                {
                    FirstName = userCreds.FirstName,
                    LastName = userCreds.LastName,
                    UserName = userCreds.UserName,
                    Email = userCreds.Email,
                    Address = userCreds.Address,
                };

                var result = await _userManager.CreateAsync(user, userCreds.Password);

                if (result.Succeeded)
                {
                    _customerManager.Add(new AddCustomerDto()
                    {
                        UserName = userCreds.UserName,
                        FirstName = userCreds.FirstName,
                        LastName = userCreds.LastName,
                        Address = userCreds.Address,
                    });
                    await _userManager.AddToRoleAsync(user, "User");
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto userCreds)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser user= await _userManager.FindByNameAsync(userCreds.UserName);
                if (user is null)
                    return BadRequest();
                bool isFound = await _userManager.CheckPasswordAsync(user,userCreds.Password);
                if (!isFound)
                    return BadRequest();

                //create token

                List<Claim> userClaims=new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                var roles=await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, role));
                }


                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                SigningCredentials siningCreds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                JwtSecurityToken myToken = new JwtSecurityToken(
                     issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    signingCredentials: siningCreds,
                    expires:DateTime.Now.AddDays(1),
                    claims: userClaims
                    );
                
                return Ok(new
                {
                    token=new JwtSecurityTokenHandler().WriteToken(myToken),
                    expiration= myToken.ValidTo
                });
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }
    }
}
