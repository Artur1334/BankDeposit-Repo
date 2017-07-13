using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositTypeServices
{
   public class ListDepositType
    {
        public IEnumerable<DpositType> GetAllTypes()
        {
            DpositType type1 = new DpositType { TypeID = 1, TypeName = "Accumulative" };
            DpositType type2 = new DpositType { TypeID = 2, TypeName = "Family"};
            DpositType type3 = new DpositType { TypeID = 3, TypeName = "Saving"};
            IEnumerable<DpositType> deposittypes = new[] { type1, type2, type3 };
            return deposittypes;
        }
        public string GetType(byte typeNumber)
        {
            IEnumerable<DpositType> types = GetAllTypes();
            DpositType ob = types.Single(a => a.TypeID == typeNumber);
            string type = ob.TypeName;
            return type;
        }
    }
}
