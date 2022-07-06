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

            var filterUserName = Builders<UserModel>.Filter.Eq(q => q.email, login.userName);
            var filter = (Builders<UserModel>.Filter.Eq(q => q.email, login.userName)) & Builders<UserModel>.Filter.Eq(q => q.password, login.password);
            var checkUserName = await repository.loginRepository.GetId(filterUserName);
            var signIn = await repository.loginRepository.GetId(filter);
            

            if (login.userName == "" && login.password == "")
            {
                response.message = "Bạn chưa nhập tài khoản, mật khẩu!";
            }
            else
            {
                if (login.userName == "")
                {
                    response.message = "Bạn chưa nhập tài khoản!";
                }
                else
                {
                    if (login.password == "")
                    {
                        response.message = "Bạn chưa nhập mật khẩu!";
                    }
                    else
                    {
                        if (checkUserName == null)
                        {
                            response.message = "Tài khoản không tồn tại";

                        }
                        else
                        {
                            if (checkUserName.password != login.password)
                            {
                                response.message = "Sai mật khẩu vui lòng nhập lại!";
                            }
                            else
                            {
                                if (signIn != null)
                                {
                                    var statusid = signIn.statusID;
                                    var roleid = signIn.roleID;


                                    if (statusid > 0)
                                    {
                                        var filterStatusid = Builders<StatusModel>.Filter.Eq(q => q.statusID, statusid);
                                        var status = await repository.statusRepository.GetId(filterStatusid);
                                        if (status != null)
                                        {
                                            signIn.statusName = status.statusName;
                                        }
                                    }
                                    if (roleid > 0)
                                    {
                                        var filterRoleid = Builders<RoleModel>.Filter.Eq(q => q.roleID, roleid);
                                        var role = await repository.roleRepository.GetId(filterRoleid);
                                        if (role != null)
                                        {
                                            signIn.roleName = role.roleName;
                                        }
                                    }

                                    response.model = signIn;
                                    response.message = "Đăng nhập thành công!";
                                    response.HttpStatusCode = 200;
                                }
                                else
                                {
                                    response.message = "Tài khoản không tồn tại!";
                                    response.HttpStatusCode = 404;
                                }
                            }


                        }
                    }
                }
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
