using Microsoft.AspNetCore.Identity;

namespace ProjetoDeRestaurante.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()// cria os cargos Membros e Admin no banco de dados na tabela AspNetRoles de formar automatica
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)//se caso não existir algum cargo com o nome "Member", o codigo continuara a execução e criara o cargo
            {
                IdentityRole role = new IdentityRole(); //objeto criado a partir do pacote identity no ASP.Net
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleresult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)// se caso não existir o cargo "Admin", o codigo continuara e criará o perfil admmin
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = " ADMIN";
                IdentityResult roleresult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()//cria usuarios originais.
        {
           if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)// criar um usuario padrão
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#2023").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
            
            if(_userManager.FindByEmailAsync("admin@localhost").Result == null)// cria o admin
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#2022").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
