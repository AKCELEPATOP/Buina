using BuinyaModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinyaModel
{
    public class Account
    {
        [Field("id")]
        public long Id { get; set; }

        [Field("name")]
        public string Name { get; set; }

        [Field("number")]
        public string Number { get; set; }

        [Field("active")]
        public Active Active { get; set; }
    }
}
