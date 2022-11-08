using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeProject.DataModels
{
    public class Credit
    {

        private string name;

        public Credit(string name)
        {
            this.name = name;
        }

        public string GetName() { return name; }
    }
}
