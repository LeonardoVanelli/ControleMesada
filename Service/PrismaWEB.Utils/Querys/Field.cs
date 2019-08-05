using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismaWEB.Utils.Querys
{
    public class Field
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public Field(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public DateTime ToDateTime()
        {
            return Convert.ToDateTime(Value);
        }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }

        public int ToInt32()
        {
            Value.GetType();
            return Convert.ToInt32(Value);
        }

        public double toDouble()
        {
            return Convert.ToDouble(Value);
        }
    }
}
