using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agilent.U1816x;

namespace u1816eNS
{
    public class initSwitch

    {
        public string unitInfo { get; set; }

        public int Startup()
        {
            //try
            //{
            //Create an instance of the driver
            AgU1816x driver = new AgU1816x();
            AgU1816x.StatusEnum status;
            int RFPath1 = 0, RFPath2 = 0;
            int CycleCount = 0;

            string serialNo = "MY641410001"; //tkf this MUST be correct for the switch you are accessing
            string modelNo = "U1816E";

            driver.Initialize(modelNo, serialNo);


            ////Read some driver attributes
            Console.WriteLine("Model :               {0} ", driver.InstrumentModel());
            Console.WriteLine("Firmware Revision :   {0} ", driver.InstrumentFirmwareRevision());
            Console.WriteLine("Serial Number :       {0} ", driver.SerialNumber());

            //Console.WriteLine("-----------------------------------------------------");

            //Set RFPath to Port 3 on Switch 1
            status = driver.RFPATH(1, 3);
            Console.WriteLine("Switching to Port 3 on Switch 1 : {0} ", status);
            //Get RFPath for switch 1
            driver.GetRFPath(1, ref RFPath1);
            Console.WriteLine("Switch 1 current RF path :     {0} ", RFPath1);

            //Set RFPath for both switches
            driver.RFPATH2(4, 6);
            Console.WriteLine("Switching to Port 4 on Switch 1 and Port 6 on Switch 2 : {0} ", status);
            //Get RFPath for both switches
            driver.GetRFPath2(ref RFPath1, ref RFPath2);
            Console.WriteLine("Switch 1 current RF path :     {0} ", RFPath1);
            Console.WriteLine("Switch 2 current RF path :     {0} \n", RFPath2);

            //Get relay count
            for (int SwitchNo = 1; SwitchNo <= 2; SwitchNo++)
            {
                for (int PathNo = 1; PathNo <= 6; PathNo++)
                {
                    driver.GetRelayCount(SwitchNo, PathNo, ref CycleCount);
                    //Console.WriteLine("Cycle Count for switch {0} Port {1}:         {2} ", SwitchNo, PathNo, CycleCount);
                }
            }

            //}
            //catch (exception ex)
            //{
            //    // perform any necessary error handling in the catch clause
            //    Console.Writeline(ex.message);

            //}
            //Console.WriteLine("Done ");
            ////Console.ReadLine();
            return 0;
        }

        //sanity check code
        public int Add(int a, int b)
        {
            return a + b;
        }

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
            driver.InstrumentList().ForEach(i => Console.WriteLine("{0}\t", i));

            //Console.WriteLine("Switch 1 current RF path :     {0} ", RFPath1);
           // Console.WriteLine("Switch 2 current RF path :     {0} \n", RFPath2);
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
            Console.WriteLine("Switch 1 current RF path :     {0} ", RFPath1);
            Console.WriteLine("Switch 2 current RF path :     {0} \n", RFPath2);


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
           
            
        }
    }
}
