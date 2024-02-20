﻿using CallRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository.IRepository
{
    public interface IPhoneCallRepository : IRepository<PhoneCall>
    {
        void Update(PhoneCall obj);
    }
}
