using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webAPI.Dto;
using webAPI.Interfaces;
using webAPI.Models;
//using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
      private readonly IUnitOfWork uow;
      private readonly IConfiguration configuration;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
          this.uow=uow;
          this.configuration=configuration;
        }

      [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq){
          var user= await uow.UserRepository.Authenticate(loginReq.user_mailId,loginReq.user_password);
            if(user==null)
            {
              return Unauthorized();
            }
            var loginResp= new LoginRespDto();
            loginResp.user_mailId=user.user_mailId;
            loginResp.token=CreateJWT(user);
            return Ok(loginResp);

        }
        private string CreateJWT(User user)
        {
          var secretKey= configuration.GetSection("AppSettings:Key").Value;
          var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
          var claims= new Claim[] {
            new Claim(ClaimTypes.Name,user.user_mailId),
            new Claim(ClaimTypes.NameIdentifier,user.user_id.ToString())
          };
          var signingCredentials= new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
          var tokenDiscriptor= new SecurityTokenDescriptor{
            Subject= new ClaimsIdentity(claims),
            Expires=DateTime.UtcNow.AddMinutes(3),
            SigningCredentials=signingCredentials
          };
          var tokenHandler= new JwtSecurityTokenHandler();
          var token=tokenHandler.CreateToken(tokenDiscriptor);

          return tokenHandler.WriteToken(token);
        }
    }
}
