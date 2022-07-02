using BusinessLogicLayer.Owners.PetHotel.Login;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.PetHotelModel.User;
using Entities.OwnerModels.Request;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Login
{
    public class LoginDal : ILoginBal
    {
        readonly IRepositoryWrapper repository;

        public LoginDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public async Task<RequestModel<UserModel>> GetId(LoginModel login)
        {
               
            var response = new RequestModel<UserModel> { HttpStatusCode = 400 };

            var filter = (Builders<UserModel>.Filter.Eq(q => q.email, login.userName) | Builders<UserModel>.Filter.Eq(q => q.phone, login.userName))
           & Builders<UserModel>.Filter.Eq(q => q.password, login.password);
            var signin = await repository.loginRepository.GetId(filter);
            

            if (signin != null)
            {
                var statusid = signin.statusID;
                var roleid = signin.roleID;


                if (statusid > 0)
                {
                    var filterStatusid = Builders<StatusModel>.Filter.Eq(q => q.statusID, statusid);
                    var status = await repository.statusRepository.GetId(filterStatusid);
                    if (status != null)
                    {
                        signin.statusName = status.statusName;
                    }
                }
                if (roleid > 0)
                {
                    var filterRoleid = Builders<RoleModel>.Filter.Eq(q => q.roleID, roleid);
                    var role = await repository.roleRepository.GetId(filterRoleid);
                    if (role != null)
                    {
                        signin.roleName = role.roleName;
                    }
                }

                response.model = signin;
                response.message = "Đăng nhập thành công!";
                response.HttpStatusCode = 200;
            }
            else
            {
                response.HttpStatusCode = 400;
                response.message = "Đăng nhập không thành công vui lòng nhập lại!";
            }
            return response;
        }
        // Convert pasword
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public string MaHoaMatKhau(string password)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            Byte[] hashBytes = encoding.GetBytes(password);
            // Compute the SHA-1 hash
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            Byte[] cryptPassword = sha1.ComputeHash(hashBytes);
            return BitConverter.ToString(cryptPassword);
        }
    }
}
