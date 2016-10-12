﻿using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class UserInfoRepository : Repository<UserInfo>, IUserRepository
    {
        public UserInfoRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}