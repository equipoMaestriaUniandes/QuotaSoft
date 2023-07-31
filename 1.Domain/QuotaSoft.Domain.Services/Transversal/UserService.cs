namespace Quota.Domain.Services.Transversal
{
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.ErrorHandler;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Services.Services;
    using Quota.Domain.Services.Transversal.Validator;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Quota.Domain.Entities.Config;
    using Quota.Domain.Services.Utilities;

    /// <summary>
    /// Defines the <see cref="UserService" />
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        /// <summary>
        /// The User repository
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Defines the rol Repository
        /// </summary>
        private readonly IRolRepository rolRepository;

        private readonly AppSettings appSettings;
        

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository, IRolRepository rolRepository
           ) 
            : base(userRepository)
        {
            this.userRepository = userRepository;
            this.rolRepository = rolRepository;
            this.appSettings = appSettings.Value;
        }
        
        public User InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Password = Util.GetCrypt(user.Password);
            var validator = new BaseValidator<User>(userRepository);

            var validations = validator.Validate(user);
            if (!validations.IsValid)
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Validations, validations.Errors.First().ErrorMessage);
            }
            user.id = (int)this.userRepository.Insert(user);
            return user;
        }

        /*
        public override void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var oldUsuario = this.userRepository.ObtenerUsuarioPorId(user.id);

            ++Validator = new GeneralValidator(userRepository, rolRepository);

            if (!string.IsNullOrEmpty(user.password))
            {
                var utilidad = new UtilidadEncriptacion();
                user.password = Encoding.UTF8.GetString(Convert.FromBase64String(user.password));
                base.GeneralValidator(user);
                Validator = null;
                user.password = utilidad.Encriptar(user.password);
            }
            else
            {
                user.password = oldUsuario.password;
            }

            base.Update(user);
        }
        */

        /*
        public override void Delete(User user)
        {
            if (user == null)
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Validations, "El user no ha sido encontrado.");
            }

            base.Validator = new EliminarValidator(this.userRepository);
            base.Delete(user);
        }*/

        /*
        public IEnumerable<User> GetByRol(int rolId)
        {
            return this.userRepository.GetByRol(rolId);
        }*/

      /*  public User UpdatePassword(int userId, string oldPassword, string newPassword)
        {

            var user = this.userRepository.GetById(userId);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Validator = new GeneralValidator(userRepository, rolRepository, obrasJefeSupervisorRepositorio);

            user.AuditoriaFecha = user.AuditoriaFecha <= DateTime.MinValue ? DateTime.Now : user.AuditoriaFecha;
            user.AuditoriaUsuarioModifica = user.Id;
            var utilidad = new UtilidadEncriptacion();
            passwordActual = Encoding.UTF8.GetString(Convert.FromBase64String(passwordActual));
            if (!utilidad.Comparar(user.password, passwordActual))
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Validations, "Contraseña actual inválida.");
            }
            user.password = utilidad.Encriptar(Encoding.UTF8.GetString(Convert.FromBase64String(passwordNueva)));
            base.Actualizar(user);

            return user;
        }*/

      /*
        public User InactivateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (!user.activo.Equals("True"))
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Validations, "El user se encuentra inactivo.");
            }

            user.activo = "False";
            this.userRepository.Update(user);
            return user;
        }
      */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User SignIn(string userName, string password)
        {
            User userAuth = this.userRepository.GetUserAuth(userName);
            //password = Encoding.UTF8.GetString(Convert.FromBase64String(password));
            if (userAuth == null)
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Validations, "User o password wrong.");
            }
            var validator = new AuthenticationValidator(this.userRepository, password);
            var validations = validator.Validate(userAuth);
            if (!validations.IsValid)
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Validations, validations.Errors.First().ErrorMessage);
            }


            return userAuth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetToken(string user, int? id)
        {
            var claims = new[] {
                new Claim (ClaimTypes.Name, user.Trim()),
                new Claim(ClaimTypes.NameIdentifier, id.Value.ToString())
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = creds
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            /*    const string authenticationType = "Cookies";
                var claimsIdentity = new ClaimsIdentity(claims, authenticationType);
                _httpContextAccessor.HttpContext.SignInAsync(authenticationType, new ClaimsPrincipal(claimsIdentity), authProperties);*/
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// The GetUserAuth
        /// </summary>
        /// <param name="user">The user<see cref="string"/></param>
        /// <returns>The <see cref="User"/></returns>
        public User GetUserAuth(string userName)
        {
            var userIn = this.userRepository.GetUserAuth(userName);
            
            if (userIn == null)
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Authentication, "User not found.");
            }
            else
            {
                userIn.Rol = this.rolRepository.RolByUser(userIn.id);
            }
            return userIn;
        }


        /// <summary>
        /// Obteners the por identifier.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public User GetUserById(int? userId) {
          return  this.userRepository.GetUserById(userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            return this.userRepository.GetObjectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            return this.userRepository.GetUserByUserName(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            return this.userRepository.GetObjectById(new User() { id = userId });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public User GetUserByUserCode(int userCode)
        {
            return this.userRepository.GetUserByUserCode(userCode);
        }
    }
}
