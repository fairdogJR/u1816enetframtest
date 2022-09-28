#Tim Fairfield Sept 22,2022
import subprocess

#makesure that testswitchdll.exe and the Agilent.U1816x are in this dir
appPath=r'C:\Users\fairfiel.KEYSIGHT\source\repos\testswitchdll\bin\Debug\netcoreapp3.1\testswitchdll.exe'
#subprocess.call([appPath])
#
#
#get serial number and unit model for making switch calls.
stdoutdata = subprocess.getoutput(appPath+' getSwInfo')
#get the values into variabls. this code below assumes there is only one unit , check returned data if you have more than one switch
modelNum, serialNum= stdoutdata.split(',')[0],stdoutdata.split(',')[1]
print("unit info: "+serialNum+' '+modelNum)

#subprocess.call([appPath, 'setSwitch1','MY641410001' ,'U1816E' ,'5' ,'4']);

swPos1='5';
swPos2='4';
print('setting switches')
#subprocess.call([appPath, 'setSwitch1',serialNum ,modelNum ,swPos1,swPos2]);
stdoutdata = subprocess.getoutput(appPath+' setSwitch1 '+serialNum +' '+modelNum +' '+swPos1+' '+swPos2)
swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
print(f'Switch1= {swPos1} Switch2= {swPos2}')

swPos1='1';
swPos2='2';
print('setting switches')
#subprocess.call([appPath, 'setSwitch1',serialNum ,modelNum ,swPos1,swPos2]);
stdoutdata = subprocess.getoutput(appPath+' setSwitch1 '+serialNum +' '+modelNum +' '+swPos1+' '+swPos2)
swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
print(f'Switch1= {swPos1} Switch2= {swPos2}')

stdoutdata = subprocess.getoutput(appPath+' getSwitch1 '+serialNum +' '+modelNum )
swPos1,swPos2=stdoutdata.split(',')[0],stdoutdata.split(',')[1]
print(f'Getting Switch info: Switch1= {swPos1} Switch2= {swPos2}')
