# u1816enetframtest
This Project is to add Python Capability to program U1816E DC to 50GHz  USB DUAL SP6T Coaxial Switches.
<p>https://www.keysight.com/ca/en/product/U1816E/usb-coaxial-switch-dc-to-50-ghz-dual-sp6t.html</p>
They are used in Digital test and RF applications to automate signal path switching. this gives repeatability and test speed without a user to have to connect and disconnect a cable everytime. Above 5GHz moving a cable can change the signal path and very much affect repeatability of test results.  

Most users just need: <b>u1816eswitchtooselfcontained2.zip</b> Unzip it and run it , everything is self contained. Tested on Windows 10 multiple machines and 2 clean OS installs. The other source files are there if you want to dig in or look at how things work. 


<H3>Design explanation Console app called by Python rather than direct DLL</H3>  (why did I did it this way)<p>
Because the DLL did not work with python directly (pythonnet was misbehaving and I dont have the source code for the hardware dll.) Luckily the Keysight Library is available for the switch for C# and has an example which does compile. I made a wrapper that should behave nicely to set the switches and can be run from windows console or be called using python subprocess. I used a way of returning values by having the wrapper writeback Console.Write commands so that variables could be passed back to python without the need for callback handler to be in place. One simply needs to  just constole write and delimit as you want. Since I am only handling a few items this works perfectly. This eliminates pythonnet issues and also doesnt need to be necessarily 32 bit or 64 bit. It doesnt matter since python is only calling the compiled exe. With .net it does matter and can be a pain.  


<img width="412" alt="Snag_9dec0a2" src="https://user-images.githubusercontent.com/11721205/193296996-69ca90fc-b89d-451d-9bc0-529151dc32f3.png">


Precomiled code here
U1816ESwitchtoolcompiled.zip

Put ALL the precompiled code all into 1 folder

<img width="469" alt="Snag_b379389" src="https://user-images.githubusercontent.com/11721205/193356417-722c3e2e-fc85-4cd7-b0aa-22a69e09556f.png">



Then you can run from command line in windows
In this case I ran the following lines:

U1816ESwitchtool.exe help

U1816ESwitchtool.exe getSwInfo

U1816ESwitchtool.exe getSwitch1 MY641410001 U1816E

U1816ESwitchtool.exe setSwitch1 MY641410001 U1816E 2 4

U1816ESwitchtool.exe setSwitch1 MY61410007 U1816E 2 4

![image](https://user-images.githubusercontent.com/11721205/193299974-1fca85c8-8023-4fbb-bb0b-a76bd22836da.png)


Finally you can run the python code, since it calls subprocess you dont need any special net modules installed. 
I ran this below:
python U1816EExample.py

<img width="599" alt="Snag_9ee6526" src="https://user-images.githubusercontent.com/11721205/193300480-8a9b46f2-90c8-467c-8665-6408baa58a31.png">


if you want to build this yourself , I used Visual Studio 2019 Pro
and use the profile settings as I did. If your more experienced I am sure you can compile even more efficiently than I did.
<img width="1123" alt="Snag_b411f42" src="https://user-images.githubusercontent.com/11721205/193357685-636c7cdd-0049-4544-94c9-9cb51800be15.png">
