using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO
{
    public class Brand : ClassNotify
    {
        private int brandId;
        private string brandName;

        public Brand()
        {

        }

        public int BrandId
        {
            get { return brandId; }
            set
            {
                if (value != brandId)
                {
                    brandId = value;
                    Notify("BrandId");
                }
            }
        }

        public string BrandName
        {
            get { return brandName; }
            set
            {
                if (value != brandName)
                {
                    brandName = value;
                    Notify("BrandName");
                }
            }
        }
    }
}
