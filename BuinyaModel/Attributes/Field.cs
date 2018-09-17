using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinyaModel.Attributes
{
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
