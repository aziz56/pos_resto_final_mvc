using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.BO;
using pos.DAL.Interface;

namespace pos.DAL.DAL
{
    public class Role : IRole
    {
        void IRole.AddUserToRole(string username, int roleId)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"insert into UserRoles (Username, RoleID) values (@Username, @RoleID)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        void ICrud<Roles>.Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"delete from Roles where RoleID=@RoleID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
            
        }

        IEnumerable<Roles> ICrud<Roles>.GetAll()
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Roles";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                List<Roles> list = new List<Roles>();
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(new Roles
                            {
                                RoleID = Convert.ToInt32(dr["RoleID"]),
                                RoleName = dr["RoleName"].ToString()
                            });
                        }
                    }
                    dr.Close();
                    return list;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        Roles ICrud<Roles>.GetByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"select * from Roles where RoleID=@RoleID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                Roles roles = new Roles();
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            roles.RoleID = Convert.ToInt32(dr["RoleID"]);
                            roles.RoleName = dr["RoleName"].ToString();
                        }
                    }
                    dr.Close();
                    return roles;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
            
        }

        void ICrud<Roles>.Insert(Roles entity)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"insert into Roles (RoleName) values (@RoleName)";
                SqlCommand cmd = new SqlCommand(strSql, connection);
                cmd.Parameters.AddWithValue("@RoleName", entity.RoleName);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        void ICrud<Roles>.Update(Roles entity)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string strSql = @"update Roles set RoleName=@RoleName where RoleID=@RoleID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@RoleName", entity.RoleName);
                cmd.Parameters.AddWithValue("@RoleID", entity.RoleID);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
           
        }
    }
}
