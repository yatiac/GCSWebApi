﻿using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSApi.Apis
{
    public class OwnersApi : IApi<Owner>
    {
        public Owner Create(Owner data)
        {
            throw new NotImplementedException();
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> Get(string filter)
        {
            using (var context = new dbContext())
            {
                var response = context.Owners.ToList();
                return response;
            }
        }

        public Owner Get(int id)
        {
            throw new NotImplementedException();
        }

        public Owner Update(Owner data)
        {
            throw new NotImplementedException();
        }
    }
}
