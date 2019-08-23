using System;
using System.Collections.Generic;
using System.Text;

namespace Pets
{

    public class Rootobject
    {
        public Home[] Homes { get; set; }
    }

    public class Home
    {
        public string[] pets { get; set; }
    }

}
