using BusinessLogicLayer.Owners.PetHotel;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Entities.OwnerModels.Request;

namespace DataAccessLayer.Owners.PetHotel
{
    public class UserFormDal : IUserFormBal
    {
        readonly IRepositoryWrapper repository;

        public UserFormDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }

        public Task<UserFormModel> Add(UserFormModel doc)
        {
            return repository.userFormRepository.Add(doc);
        }

        public Task<bool> Delete(string _id)
        {
            var filter = Builders<UserModel>.Filter.Eq(q => q._id, _id);
            return repository.userRepository.Delete(filter);
        }

        public async Task<List<UserModel>> GetAll()
        {
            var statusList = await repository.statusRepository.GetAll();
            var roleList = await repository.roleRepository.GetAll();
            var userList = await repository.userRepository.GetAll();


            foreach (var user in userList)
            {
                var roleID = user.roleID;
                var statusID = user.statusID;
                if (roleList.Count > 0)
                {
                    var role = roleList.Where(x => x.roleID == roleID).FirstOrDefault();
                    if (role != null)
                    {
                        user.roleName = role.roleName;
                    }
                }
                if (statusList.Count > 0)
                {
                    var status = statusList.Where(x => x.statusID == statusID).FirstOrDefault();
                    if (status != null)
                    {
                        user.statusName = status.statusName;
                    }
                }


            }
            return userList.Where(x => x.roleID != 5).ToList();
        }

        public async Task<UserModel> GetId(string _id)
        {
            var filter = Builders<UserModel>.Filter.Eq(q => q._id, _id);
            var user = await repository.userRepository.GetId(filter);
            var statusid = user.statusID;
            var roleid = user.roleID;

            if (statusid > 0)
            {
                var filterStatusid = Builders<StatusModel>.Filter.Eq(q => q.statusID, statusid);
                var status = await repository.statusRepository.GetId(filterStatusid);
                if (status != null)
                {
                    user.statusName = status.statusName;
                }
            }
            if (roleid > 0)
            {
                var filterRoleid = Builders<RoleModel>.Filter.Eq(q => q.roleID, roleid);
                var role = await repository.roleRepository.GetId(filterRoleid);
                if (role != null)
                {
                    user.roleName = role.roleName;
                }
            }

            return user;
        }
        public async Task<List<UserModel>> GetByCondition(int condition)
        {

            var statusList = await repository.statusRepository.GetAll();
            var roleList = await repository.roleRepository.GetAll();
            var filter = Builders<UserModel>.Filter.Eq(q => q.roleID, condition);
            var userList = await repository.userRepository.GetUserByCondition(filter);


            foreach (var user in userList)
            {
                var roleID = user.roleID;
                var statusID = user.statusID;
                if (roleList.Count > 0)
                {
                    var role = roleList.Where(x => x.roleID == roleID).FirstOrDefault();
                    if (role != null)
                    {
                        user.roleName = role.roleName;
                    }
                }
                if (statusList.Count > 0)
                {
                    var status = statusList.Where(x => x.statusID == statusID).FirstOrDefault();
                    if (status != null)
                    {
                        user.statusName = status.statusName;
                    }
                }


            }
            return userList;
        }
        public async Task<UserFormModel> EditUser(string _id)
        {
            var statusList = await repository.statusRepository.GetAll();
            var roleList = await repository.roleRepository.GetAll();


            var filter = Builders<UserFormModel>.Filter.Eq(q => q._id, _id);
            var user = await repository.userRepository.GetUserFormById(filter);



            if (roleList.Count > 0)
            {
                var role = roleList.Where(x => x.roleID == user.roleID).FirstOrDefault();
                if (role != null)
                {
                    role.select = "selected";
                    user.roleName = role.roleName;
                }
            }
            if (statusList.Count > 0)
            {
                var status = statusList.Where(x => x.statusID == user.statusID).FirstOrDefault();
                if (status != null)
                {
                    status.select = "selected";
                    user.statusName = status.statusName;
                }
            }


            user.roleList = roleList;
            user.statusList = statusList;


            return user;
        }

        public Task<bool> Update(UserBaseModel user, string _id)
        {
            var checkid = Builders<UserModel>.Filter.Eq(q => q._id, _id);
            var update = Builders<UserModel>.Update.Set(p => p.userName, user.userName).Set(p => p.address, user.address).Set(p => p.email, user.email).Set(p => p.roleID, user.roleID).Set(p => p.phone, user.phone).Set(p => p.statusID, user.statusID);

            return repository.userRepository.Update(checkid, update);
        }

        public async Task<UserFormModel> AddUser()
        {
            var statusList = await repository.statusRepository.GetAll();
            var roleList = await repository.roleRepository.GetAll();

            var addUser = new UserFormModel
            {
                statusList = statusList,
                roleList = roleList,
            };
            return addUser;
        }
    }
    public class UserDal : IUserBal
    {
        readonly IRepositoryWrapper repository;
        public UserDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public async Task<RequestModel<UserBaseModel>> Add(UserBaseModel doc)
        {
            var response = new RequestModel<UserBaseModel> { HttpStatusCode = 400 };
            doc.userHandle = handler(doc.userName);
            doc.userID = "KH" + randomID();
            doc.password = GetHash(doc.password);

            var userList = await repository.userRepository.GetAll();

            foreach (var user in userList)
            {
                if (doc.userName == user.userName)
                {
                    response.message = "Tên tài khoản đã tồn tại, vui lòng nhập tên khác!";
                    return response;

                }
                else
                {
                    if (doc.phone == user.phone)
                    {
                        response.message = "Số điện thoại đã được đăng ký, vui lòng đăng ký tài khoản bằng số điện thoại khác!";
                        return response;

                    }
                    else
                    {
                        if (doc.email == user.email)
                        {

                            response.message = "Email đã được đăng ký, vui lòng đăng ký tài khoản bằng email khác!";
                            return response;

                        }
                      
                    }
                    
                }
            }
            var addUser = await repository.userRepository.Add(doc);
            response.message = "Đăng ký thành công!";
            response.HttpStatusCode = 200;
            response.model = addUser;

            return response;


        }

        public Task<bool> Delete(string _id)
        {
            var filter = Builders<UserModel>.Filter.Eq(q => q._id, _id);

            return repository.userRepository.Delete(filter);
        }
        public Task<List<UserModel>> GetAll()
        {

            return repository.userRepository.GetAll();
        }
        public async Task<UserModel> GetId(string _id)
        {
            var filter = Builders<UserModel>.Filter.Eq(q => q._id, _id);
            var user = await repository.userRepository.GetId(filter);

            var statusid = user.statusID;
            var roleid = user.roleID;

            if (statusid > 0)
            {
                var filterStatusid = Builders<StatusModel>.Filter.Eq(q => q.statusID, statusid);
                var status = await repository.statusRepository.GetId(filterStatusid);
                if (status != null)
                {
                    user.statusName = status.statusName;
                }
            }
            if (roleid > 0)
            {
                var filterRoleid = Builders<RoleModel>.Filter.Eq(q => q.roleID, roleid);
                var role = await repository.roleRepository.GetId(filterRoleid);
                if (role != null)
                {
                    user.roleName = role.roleName;
                }
            }
            return user;

        }
        public async Task<bool> Update(UserModel user, string _id)
        {
            var checkid = Builders<UserModel>.Filter.Eq(q => q._id, _id);
            var update = Builders<UserModel>.Update.Set(p => p.userName, user.userName).Set(p => p.address, user.address).Set(p => p.email, user.email).Set(p => p.roleID, user.roleID).Set(p => p.phone, user.phone).Set(p => p.statusID, user.statusID);

            return await repository.userRepository.Update(checkid, update);
        }
        public static string GetHash(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            // Compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            // Get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public int randomID()
        {
            Random r = new Random();
            int n = r.Next();
            return n;
        }
        public string handler(string text)
        {
            var chuyendoi = LoaiDau(text).ToLower();
            string strPattern = @"[\s]+";
            Regex rgx = new Regex(strPattern);
            string Ouput = rgx.Replace(chuyendoi, "-");
            return Ouput;
        }
        public string LoaiDau(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('đ', 'd').Replace('Đ', 'D');


        }
    }
}
