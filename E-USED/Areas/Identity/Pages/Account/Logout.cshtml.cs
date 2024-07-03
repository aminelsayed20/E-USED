// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using E_USED.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SellingUsedThings.Models.Entity;

namespace E_USED.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ILogger<LoginModel> _logger;
		private readonly UserManager<AppUser> _userManager;

		public LogoutModel(SignInManager<AppUser> signInManager, ILogger<LoginModel> logger, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_logger = logger;
			_userManager = userManager;
		}

		public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
				var user = _userManager.GetUserAsync(User).Result;
				await activityHandel(user);

				return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }

		private async Task<bool> activityHandel(AppUser user)
		{
			if (user == null) return false;

			user.IsActive = false;
			await _userManager.UpdateAsync(user);
			return true;
		}

	}
}
