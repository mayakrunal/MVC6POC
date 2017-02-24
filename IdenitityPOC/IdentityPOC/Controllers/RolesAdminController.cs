using IdentityPOC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityPOC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
        #region Properties
        /// <summary>
        /// The user manager
        /// </summary>
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        /// <summary>
        /// Gets or sets the user manager.
        /// </summary>
        /// <value>
        /// The user manager.
        /// </value>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }


        /// <summary>
        /// Gets the role manager.
        /// </summary>
        /// <value>
        /// The role manager.
        /// </value>
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }


        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesAdminController"/> class.
        /// </summary>
        public RolesAdminController() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesAdminController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        public RolesAdminController(ApplicationUserManager userManager,
         ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        #endregion

        #region Index
        // GET: RolesAdmin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        #endregion

        #region Details
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = await RoleManager.FindByIdAsync(id);
            var users = new List<ApplicationUser>();

            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }
            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }
        #endregion

        #region Create
        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(roleViewModel.Name)
                {
                    Description = roleViewModel.Description
                };
                var result = await RoleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Edit

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel rolemodel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(rolemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id,Description")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;

                // Update the new Description property:
                role.Description = roleModel.Description;
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Delete
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                if (deleteUser != null)
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                else
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion  
    }


}