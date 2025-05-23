﻿using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Entities;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class AuthorizedCSABaseAPIController : ControllerBase
    {

        protected readonly ILogger<AuthorizedCSABaseAPIController> _logger;
        protected readonly IUserService _userService;
        private IUser _currentUser;

        public AuthorizedCSABaseAPIController(IUserService userService,ILogger<AuthorizedCSABaseAPIController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public IUser CurrentUser
        {
            get
            {
                _currentUser ??= GetCurrentUser();
                return _currentUser;
            }
        }

        private IUser GetCurrentUser()
        {
            try
            {
                string username = HttpContext.User.Identity.Name;
                if (!string.IsNullOrEmpty(username))
                {
                    return _userService.GetByUsername(username);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
            }
            return null;
        }
        protected bool IsCSAAdmin()
        {
            return HttpContext.User.Claims.Any(x => x.Value == Roles.CSAAdmin.ToString());
        }

        protected bool IsResidentAdmin()
        {
            return HttpContext.User.Claims.Any(x => x.Value == Roles.ResidentAdmin.ToString());
        }
        protected bool IsResidentUser()
        {
            return HttpContext.User.Claims.Any(x => x.Value == Roles.ResidentUser.ToString());
        }
    }
}
