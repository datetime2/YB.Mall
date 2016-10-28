using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YB.Mall.Extend.Helper;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;
using YB.Mall.Service;
using YB.Mall.Web.Controllers;
namespace YB.Mall.Web.Areas.SystemManage.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService roleService;
        private readonly IOrganizeService oragService;
        public RoleController(IRoleService _roleService, IOrganizeService _oragService)
        {
            this.roleService = _roleService;
            this.oragService = _oragService;
        }
        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult RoleGrid(RoleQueryModel query)
        {
            var grid = roleService.RoleGrid(query);
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 表单加载
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult InitForm(int? keyValue)
        {
            var role = roleService.InitForm(s => s.RoleId == keyValue);
            return Json(new RoleInfo
            {
                RoleName = role.RoleName,
                RoleType = role.RoleType,
                OrganizeId = role.OrganizeId,
                OrganizeName = role.OrganizeName,
                IsEnabled = role.IsEnabled,
                AllowDelte = role.AllowDelte,
                AllowEdit = role.AllowEdit,
                Remark = role.Remark,
                Sort = role.Sort
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 角色类型下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult InitRoleType()
        {
            return Json(EnumHelper.ToDescriptionDictionary<RoleType>().Select(s => new TreeSelectModel
            {
                id = s.Value,
                text = s.Key
            }), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 机构下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult InitOrganizeType(MenuQueryModel query)
        {
            return Json(oragService.OrganizeTree(query), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 角色权限树
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult RoleAuthorize(int? roleId)
        {
            return Json(roleService.RoleAuthorize(roleId), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 表单保存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SubmitForm(RoleInfo role, string permissionIds, int? keyValue)
        {
            return roleService.SubmitForm(role, permissionIds.Split(',').Select(int.Parse), keyValue) ? Success("操作成功") : Error("操作失败");
        }
    }
}