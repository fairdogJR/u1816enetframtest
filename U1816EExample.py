#Tim Fairfield Sept 22,2022
#https://github.com/fairdogJR/u1816enetframtest

import subprocess
import sys
#makesure that exe and the Agilent.U1816x are in the dir with this tool
#appPath=r'C:\Users\fairfiel.KEYSIGHT\source\repos\testswitchdll\bin\Debug\netcoreapp3.1\U1816ESwitchtool.exe'
appPath=r'U1816ESwitchtool.exe'
#subprocess.call([appPath])
#
#
stdoutdata = subprocess.getoutput(appPath+' Help')
print (stdoutdata)

#get serial number and unit model for making switch calls.
stdoutdata = subprocess.getoutput(appPath+' getSwInfo')

try:
    print ("units found: "+ stdoutdata)
    #get the values into variabls. this code below assumes there is only one unit , check returned data if you have more than one switch
    modelNum, serialNum= stdoutdata.split(',')[0],stdoutdata.split(',')[1]
    print("setting unit 1 : "+modelNum+' '+serialNum)

except:
    print(" no switches found! make sure they are plugged in to this system and lights are on\nThe switch should cycle through all switches if it is connected and working")
    sys.exit()
#subprocess.call([appPath, 'setSwitch1','MY641410001' ,'U1816E' ,'5' ,'4']);

try:
    swPos1='5';
    swPos2='4';
    print(f'setting switches on {serialNum}')
    #subprocess.call([appPath, 'setSwitch1',serialNum ,modelNum ,swPos1,swPos2]);
    stdoutdata = subprocess.getoutput(appPath+' setSwitch1 '+serialNum +' '+modelNum +' '+swPos1+' '+swPos2)
    swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
    print(f'Switch1= {swPos1} Switch2= {swPos2}')

    swPos1='1';
    swPos2='2';
    print(f'setting switches on {serialNum}')
    #subprocess.call([appPath, 'setSwitch1',serialNum ,modelNum ,swPos1,swPos2]);
    stdoutdata = subprocess.getoutput(appPath+' setSwitch1 '+serialNum +' '+modelNum +' '+swPos1+' '+swPos2)
    swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
    print(f'Switch1= {swPos1} Switch2= {swPos2}')
except:
    print("cant set switch, possibly not found?")

try:
    stdoutdata = subprocess.getoutput(appPath + ' getSwInfo')
    modelNum, serialNum = stdoutdata.split(',')[2], stdoutdata.split(',')[3]
    print("setting unit 2 : " + modelNum + ' ' + serialNum)

    swPos1='5';
    swPos2='4';
    print(f'setting switches on {serialNum}')
    #subprocess.call([appPath, 'setSwitch1',serialNum ,modelNum ,swPos1,swPos2]);
    stdoutdata = subprocess.getoutput(appPath+' setSwitch1 '+serialNum +' '+modelNum +' '+swPos1+' '+swPos2)
    swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
    print(f'Switch1= {swPos1} Switch2= {swPos2}')

    swPos1='6';
    swPos2='6';
    print(f'setting switches on {serialNum}')
    #subprocess.call([appPath, 'setSwitch1',serialNum ,modelNum ,swPos1,swPos2]);
    stdoutdata = subprocess.getoutput(appPath+' setSwitch1 '+serialNum +' '+modelNum +' '+swPos1+' '+swPos2)
    swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
    print(f'Switch1= {swPos1} Switch2= {swPos2}')
except:
    print("cant set second switch, possibly not found?")



try:
    stdoutdata = subprocess.getoutput(appPath+' getSwitch1 '+serialNum +' '+modelNum )
    swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
    print(f'Getting Switch info:{modelNum} {serialNum} Switch1= {swPos1} Switch2= {swPos2}')
except:
    print("cant read switch, check if switch is powered and connected this system")