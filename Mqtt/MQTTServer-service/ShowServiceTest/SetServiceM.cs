using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowServiceTest
{
    public class SetServiceM
    {
        public string KeyMsg { get; set; }
        public string ValueMsg { get; set; }
        public SetServiceM() { }
        public SetServiceM(string key, string val)
        {
            KeyMsg = key;
            ValueMsg = val;
        }
        public static SetServiceM SetService(string key, string val)
        {
            return new SetServiceM(key, val);
        }
    }
}
