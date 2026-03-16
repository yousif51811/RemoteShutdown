# RemoteShutdown
A Simple windows service to shutdown a computer
> [!CAUTION]
> Only ever use this on your **own machine!**

> [!NOTE]
> This Service is best paired with the [RemoteShutdown App](https://github.com/yousif51811/RemoteShutdown-App)
## Building
#### 1. Make sure you have the .NET sdk installed
#### 2. Run the following command to build
```
dotnet build -c Release
```
#### 3. The executable will be available at `/bin/Release/app.publish`

## Installation
#### 1. Move the executable to the directory of your choice.
#### 2. Run a terminal with elevated privileges.
#### 3. Create the service
```
sc create RemoteShutdown binPath="C:\Full\Path\To\Service.exe" start=auto obj="LocalSystem"
```
Feel free to Change the arguments to your own prefrences.

#### 4. Run the service
```
sc start RemoteShutdown
```

## Uninstalling
#### 1. Run a terminal with elevated privileges.
#### 2. Stop the service
```
sc stop RemoteShutdown
```
#### 3. Uninstall the service
```
sc delete RemoteShutdown
```

------------------
Made with ❤️ by yousif51811
