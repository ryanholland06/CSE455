using System;
using System.Collections.Generic;
using System.Text;

namespace FIrebaseTest2
{
    public class Citation
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string VehicleInfo { get; set; }

        public long VinNumber { get; set; }

        //NEED TO ADD NUMBER OF CITATIONS AND CITATION NUMBER
        //ALSO REASON FOR CITATION

        public int FineAmount { get; set; }

        public bool PaidStatus { get; set; }


    }
}
