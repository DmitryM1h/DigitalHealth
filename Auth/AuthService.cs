using Auth;
using CSharpFunctionalExtensions;
using DigitalHealth.Auth.DomainEvents;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace DigitalHealth.Auth
{
    public record LoginDto(string Email, string Password);
    public record RegisterDoctorDto(string UserName, string Email, string Password, string PhoneNumber, Guid ClinicId, string Specialty, int Capacity);



    public class AuthService(SignInManager<User> signInManager,
         UserManager<User> userManager,
         TokenGenerator tokenGenerator
         )
    {
        public async Task<Result> LoginAsync(LoginDto logDto)
        {
            var user = await userManager.FindByEmailAsync(logDto.Email);

            if (user is null)
                return Result.Failure("Invalid login or password");


            var p = await signInManager.CheckPasswordSignInAsync(user, logDto.Password, false);

            if (!p.Succeeded)
                return Result.Failure("Invalid login or password");

            var claims = await GetUserClaimsAsync(user);

            var token = tokenGenerator.GenerateToken(claims);

            return Result.Success(token);

        }


        public async Task<Result<User>> RegisterUserAsync(RegisterDoctorDto regRequest, Role role, CancellationToken token)
        {
            var user = new User {UserName = regRequest.UserName, Email = regRequest.Email, PhoneNumber = regRequest.PhoneNumber};

            var userExists = await userManager.FindByEmailAsync(regRequest.Email);

            if (userExists is not null)
                return Result.Failure<User>("User is not present in the system");

            var result = await userManager.CreateAsync(user, regRequest.Password);

            if (!result.Succeeded)
                return Result.Failure<User>(result.Errors.First().Description.ToString());

            await AddToRole(user, role.ToString());

            var registredUser = await userManager.FindByEmailAsync(regRequest.Email);

            registredUser!.RaiseDomainEvent(new UserRegistredEvent());

            return Result.Success(registredUser);
        }

        //public async Task<Result> RegisterPatientAsync(RegisterHrDto regRequest, CancellationToken token)
        //{
        //    var user = ApplicationUser.CreateFromRegisterDto(
        //                                                UserName: regRequest.UserName,
        //                                                BirthDay: regRequest.BirthDay,
        //                                                Email: regRequest.Email,
        //                                                Telegram: regRequest.Telegram,
        //                                                Password: regRequest.Password,
        //                                                PhoneNumber: regRequest.PhoneNumber
        //                                            );

        //    var result = await userManager.CreateAsync(user, regRequest.Password);

        //    if (!result.Succeeded)
        //        return new Result(false, result.Errors.First().Description.ToString());

        //    await AddToRole(user, nameof(HrManager));


        //    var hr = HrManager.CreateHr(user.Id, regRequest.Company);

        //    await _hrManagerRepo.AddAsync(hr, token);

        //    await _unitOfWork.SaveAsync(token);

        //    return new Result(true, null);
        //}


        private async Task AddToRole(User user, string Role)
        {
            await userManager.AddToRoleAsync(user, Role);
            await userManager.AddClaimAsync(user, new Claim("email", user!.Email!));
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.UserName!));
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
        }

        private async Task<List<Claim>> GetUserClaimsAsync(User user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            claims.AddRange(userClaims);

            return claims;
        }
    }
}
