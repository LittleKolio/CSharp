using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Lab.Lab_04
{
    public class RobotAdapter : IRechargeable
    {
        private Robot rob;

        public RobotAdapter(string id, int capacity)
        {
            this.rob = new Robot(id, capacity);
        }
        public void Recharge()
        {
            this.rob.Recharge();
        }
    }
}
