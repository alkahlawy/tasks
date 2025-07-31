using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8_oop3.Interfaces
{
    public interface IRectangle : IShape
    {
        public double Width { get;}
        public double Length { get;}
    }
}
