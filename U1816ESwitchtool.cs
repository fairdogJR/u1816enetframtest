using System;
using u1816eNS;
using System.Buffers;

namespace testswitchdll
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            int swPos1 ;
            int swPos2 ;
            string swCommand = "";
            var a = new initSwitch();
            string serialNo = "";
            string modelNo = "";

            //Console.WriteLine("Switchdemo");

            if (args.Length != 0)
            {
                swCommand = args[0];
            }

            if (swCommand == "setSwitch1")

            {
                serialNo = args[1];
                modelNo = args[2];
                swPos1 = int.Parse(args[3]);
                swPos2 = int.Parse(args[4]);

                a.setSwitch1(serialNo, modelNo, swPos1, swPos2);

                Console.WriteLine(a.currentPath);
            }

            if (swCommand == "getSwitch1")
            {
                serialNo = args[1];
                modelNo = args[2];
                a.getSwitch1(serialNo, modelNo);
                Console.WriteLine(a.currentPath);
            }

            if (swCommand == "getSwInfo")
            {
                a.getSwInfo();

            }

            if (swCommand == "Help" || swCommand=="help")
            {
                Console.WriteLine("****U1816ESwitchtool V1.0 ************************************");
                Console.WriteLine("https://github.com/fairdogJR/u1816enetframtest");
                Console.WriteLine(" can be called directly from command line or from python using subprocess\n see github above for python example.");
                Console.WriteLine(" Help:");
                Console.WriteLine("get available switches and serial numbers:\ngetSwInfo");
                Console.WriteLine("set a specific switch:\nsetSwitch1 <serialNo> <modelNo> <swPos1> <swPos2>");
                Console.WriteLine("read the switch settings on a particular switch:\ngetSwitch1 <serialNo> <modelNo>");
                Console.WriteLine("to turn off a switch , set to zero <swPosx>=0");
                Console.WriteLine("**************************************************************");
            }


            return;
        }
    }
}
