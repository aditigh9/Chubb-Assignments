using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;

using OrderManagementApi.Models;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;


namespace OrderManagementApi.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class AuthController : ControllerBase

    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;


        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration config)

        {

            _userManager = userManager;

            _config = config;

        }


        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterDto dto)

        {

            var user = new ApplicationUser { UserName = dto.Email, Email = dto.Email };

            var result = await _userManager.CreateAsync(user, dto.Password);


            if (!result.Succeeded)

                return BadRequest(result.Errors);


            return Ok("User Registered Successfully");

        }


        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDto dto)

        {

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null) return Unauthorized();


            if (!await _userManager.CheckPasswordAsync(user, dto.Password))

                return Unauthorized();


            //define claims that will be embedded inside the JWT when a user successfully logs in

            //ClaimTypes.Name is a standard claim type that represents the user’s identity

            //(often their username or email).Here, it stores the user’s email address.

            //JwtRegisteredClaimNames.Jti is a standard field in JWTs that represents a unique

            //identifier for the token. Guid.NewGuid().ToString() generates a random unique value.

            //Prevents token replay attacks (each token has a unique ID).

            //Helps with token tracking and invalidation if needed.

            var authClaims = new List<Claim>

{

new Claim(ClaimTypes.Name, user.Email),

new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

};


            var jwt = _config.GetSection("Jwt");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));


            var token = new JwtSecurityToken(

            issuer: jwt["Issuer"],

            audience: jwt["Audience"],

            expires: DateTime.Now.AddHours(2),

            claims: authClaims,

            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

            );


            return Ok(new

            {

                token = new JwtSecurityTokenHandler().WriteToken(token)

            });

        }

    }

}
