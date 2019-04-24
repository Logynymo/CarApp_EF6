using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO
{
    public class Propellant: ClassNotify
    {
        private int propellantId;
        private string propellantName;

        public Propellant()
        {

        }

        public int PropellantId
        {
            get { return propellantId; }
            set
            {
                if (value != propellantId)
                {
                    propellantId = value;
                    Notify("PropellantId");
                }
            }
        }
        
        public string PropellantName
        {
            get { return propellantName; }
            set
            {
                if (value != propellantName)
                {
                    propellantName = value;
                    Notify("PropellantName");
                }
            }
        }
    }
}
