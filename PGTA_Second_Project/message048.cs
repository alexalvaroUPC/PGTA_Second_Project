using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA_Second_Project
{
    public class message048
    {
        private int length;
        private int ID;
        private int dataItem1;
        private int dataItem2;
        private int dataItem3;

        public message048(int dataItem1, int dataItem2, int dataItem3)
        {
            this.dataItem1 = dataItem1;
            this.dataItem2 = dataItem2;
            this.dataItem3 = dataItem3;
        }
    }
}
