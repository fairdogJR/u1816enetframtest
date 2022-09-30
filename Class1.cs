using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agilent.U1816x;

namespace u1816eNS
{
    public class unitData
    {
        public unitData(string serialno, string modelno)
        {
            this.serialno = serialno;
            this.modelno = modelno;

        }
        public string serialno { get; private set; }
        public string modelno { get; private set; }

        




    }
    public class initSwitch

    {
        public string unitInfo { get; set; }
        
        public string currentPath { get; set; }

        public List<string> unitdata2 = new List<string>();


        public void getSwitch1(string serialNo, string modelNo)
        {
            //Create an instance of the driver
            AgU1816x driver = new AgU1816x();
            AgU1816x.StatusEnum status;
            int RFPath1 = 0, RFPath2 = 0;
            int CycleCount = 0;
            
            //string serialNo = "MY641410001"; //tkf this MUST be correct for the switch you are accessing
            //string modelNo = "U1816E";

            driver.Initialize(modelNo, serialNo);
            //status = driver.RFPATH(a, b);

            driver.GetRFPath2(ref RFPath1, ref RFPath2);
            
            //get the instrument liste and serial numbers available
           // driver.InstrumentList().ForEach(i => Console.WriteLine("{0}\t", i));

            //Console.WriteLine("Switch 1 current RF path :     {0} ", RFPath1);
            // Console.WriteLine("Switch 2 current RF path :     {0} \n", RFPath2);
            this.currentPath = RFPath1.ToString() + ',' + RFPath2.ToString();
        }
        public void setSwitch1(string serialNo, string modelNo, int swPos1, int swPos2)
        {
            //Create an instance of the driver
            AgU1816x driver = new AgU1816x();
            AgU1816x.StatusEnum status;
            int RFPath1 = 0, RFPath2 = 0;
            int CycleCount = 0;
            

            //string serialNo = "MY641410001"; //tkf this MUST be correct for the switch you are accessing
           //string modelNo = "U1816E";

            driver.Initialize(modelNo, serialNo);
// status = driver.RFPATH(a, b);
            driver.RFPATH2(swPos1, swPos2);


            driver.GetRFPath2(ref RFPath1, ref RFPath2);
            //Console.WriteLine("Switch 1 current RF path :     {0} ", RFPath1);
            //Console.WriteLine("Switch 2 current RF path :     {0} \n", RFPath2);
            this.currentPath = RFPath1.ToString() + ',' + RFPath2.ToString();

        }


        public void getSwInfo()
        {
            // this call will get you a list of the available switches 

            //Create an instance of the driver
            AgU1816x driver = new AgU1816x();
            AgU1816x.StatusEnum status;
            int RFPath1 = 0, RFPath2 = 0;
            int CycleCount = 0;
            //string unitInfo = "";


            //driver.Initialize(modelNo, serialNo);
            //status = driver.RFPATH(a, b);

            //driver.GetRFPath2(ref RFPath1, ref RFPath2);

            //get the instrument liste and serial numbers available
            //driver.InstrumentList().ForEach(i => Console.Write("{0}\t", i));

            driver.InstrumentList().ForEach(i => this.unitInfo=i);

            foreach (var item in driver.InstrumentList())
            {
                unitdata2.Add(item);
              Console.Write(item+",");

            }  

                

        }
    }
}
