using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAndAsp.NetCoreWebApiEcommerce.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsers : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

    

        public ApplicationUsers(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //Post: api/ApplicationUsers/Register
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            model.Role = "Customer";
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email= model.Email,
                FullName=model.FullName
            
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser,model.Password);
                await _userManager.AddToRoleAsync(applicationUser,model.Role);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("Login")]
        //Post: api/ApplicationUsers/Login
        public async Task<IActionResult> Login(LoginModel model )
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            
            if (user!=null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //get role Assigned
                    Subject = new ClaimsIdentity(new Claim[]
                    {

                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),SecurityAlgorithms.HmacSha256)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });

            }
            else
            {
                return BadRequest(new { message = "User Name or Password is Incorrect" });
            }
        }

    }
}
