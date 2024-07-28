New-Service -Name YarpDemo `
    -BinaryPathName "C:\Yarp\YarpDemo.dll --contentRoot C:\Yarp\" `
    -Credential "Localsystem" `
    -Description "YARP running as Windows Service" `
    -DisplayName "YarpDemo" `
    -StartupType Automatic