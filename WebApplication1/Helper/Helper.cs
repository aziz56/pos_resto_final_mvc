﻿using pos.BLL.DTO;

namespace WebApplication1.Helper
{
    public static class Auth
    {
        public static bool CheckRole(string role, List<RoleDTO> roleDTOs)
        {
            var roles = role.Split(',');
            foreach (var item in roles)
            {
                var checkRole = roleDTOs.Find(x => x.RoleName == item);
                if (checkRole != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
