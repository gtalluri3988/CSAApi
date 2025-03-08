using BusinessLogic.Interfaces;
using BusinessLogic.Models.Users;
using BusinessLogic.Services;
using DB.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminController : AuthorizedCSABaseAPIController
    {
        private readonly IPasswordPolicyService _passwordPolicyService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IRoleService _roleService;
        private readonly IMenuService _menuService;
        private readonly IRoleMenuPermissionService _roleMenuPermissionervice;

        public AdminController(
            IPasswordPolicyService passwordPolicyService,IRoleService roleService,
            ICurrentUserService currentUserService,
            IUserService userService,IMenuService menuService,
            IRoleMenuPermissionService roleMenuPermissionService,
            ILogger<ResidentController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _passwordPolicyService = passwordPolicyService;
            _roleService = roleService;
            _roleMenuPermissionervice = roleMenuPermissionService;
            _menuService = menuService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPasswordPolicyDetails()
        {
            var PasswordPolicy = await _passwordPolicyService.GetAllPasswordPolicyAsync();
            return Ok(PasswordPolicy);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePasswordPolicy(List<PasswordPolicyDTO> policy)
        {
            var PasswordPolicy = await _passwordPolicyService.SavePasswordPolicyAsync(policy);
            return Ok(PasswordPolicy);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
        [HttpPut]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var roles = await _roleService.GetRoleByIdAsync(roleId);
            return Ok(roles);
        }

        [HttpPut]
        public async Task<IActionResult> SaveRole(RoleDTO role)
        {
            await _roleService.SaveRoleAsync(role);
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(int roleId,RoleDTO role)
        {
            await _roleService.UpdateRoleAsync(roleId,role);
            return Ok(true);
        }


        //Menu

        [HttpGet]
        public async Task<IActionResult> GetAllMenuRolePermission()
        {
            var MenuRoles = await _roleMenuPermissionervice.GetAllMenuRolesAsync();
            return Ok(MenuRoles);
        }
        //[HttpPut]
        //public async Task<IActionResult> GetMenuById(int roleId)
        //{
        //    var roles = await _roleMenuPermissionervice.GetRoleByIdAsync(roleId);
        //    return Ok(roles);
        //}

        [HttpPost]
        public async Task<IActionResult> SaveMenuRolePermission(RoleMenuPermissionDTO roleMenuPermissionDTO)
        {
            try
            {
                var createdUser = await _roleMenuPermissionervice.CreateMenuRoleAsync(roleMenuPermissionDTO);
                return Ok(new { message = "Role Permissions created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return only the message
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoleMenuPermission(int id, RoleMenuPermissionDTO roleMenuPermissionDTO)
        {
            try
            {
                await _roleMenuPermissionervice.UpdateMenuRoleAsync(id, roleMenuPermissionDTO);
                return Ok(new { message = "Role Permissions created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return only the message
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            var roles = await _menuService.GetAllMenusAsync();
            return Ok(roles);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubMenuListByMenuId(int subMenuId)
        {
            var SubMenu = await _menuService.GetSubMenuList(subMenuId);
            return Ok(SubMenu);
        }

    }
}
