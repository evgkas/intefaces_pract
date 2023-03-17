using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//FlyTo(новая точка), GetFlyTime(новая точка)

namespace intefaces_pract
{
    public interface IFlyable
    {
        void Flyto(int x, int y, int z)
        {

        }
        void GetFlyTime(int x, int y, int z)
        {

        }
        void IGetHeight (double time0, double time1)
        {

        }
    }
}
