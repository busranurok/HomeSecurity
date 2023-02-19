# 📋 Project Name
Home Security

> 🔗 Proje link : (If you want to see the project content page, please click the image below.)

<a href="http://bilgisayarkocaelibitirmeteziguvenlik.blogspot.com" target="_blank"><img src="https://2.bp.blogspot.com/-OGVM5ZZwqy4/Wx3M8LSG4QI/AAAAAAAAAMg/lTkG6nK0tq4A1HTT_IillxYI-nMWwHMSgCLcBGAs/s1600/poster.png" alt="Project Link" height="90"/></a>

## 👉 Follow This List

- [🎯 Project Description](#-project-description)
- [🔧 How to Setup](#-how-to-setup)

## 🎯 Project Description 
> It is a multi-platform application for providing home supply.

#### _With this project:_
- A camera connected to Arduino is placed in the desired area of the house and takes the image from there and sends this image to the computer it is connected to via serial port.
- The application(Winform app) that takes the image uses the EmguCV libraries to compare the new image with the previously trained model.
- The application that receives the image uses the emgucv libraries to compare the previously trained model with the new image. As a result of comparison,
the system generates alarm when there is a match below a certain percentage.
- These alarms are:
  1) Mobile notification
  2) Skype call
  3) Sending sms to the defined numbers
- Management procedures for the alarm mechanism are carried out using the web application.
- Finally, there are functions of location tracking and panic button in the mobile application.
- With the location tracking feature, if the user did not activate the alarm while leaving the house, the user can be warned using the mobile notification.
- With the panic button feature, when the user does not feel safe while outside the home, the address information of the current location is sent as sms to the previously defined numbers.

### Tech Stack
- [EmguCV] - Image processing
- [OV7670 Camera] - Getting images from camera
- [MSSQL] - Database 
- [Xamarin\Android] - Mobile application
- [ASP.NET Web Api] - Mobile-DB communication

### Upcoming Features
- Login With Google & Login With Microsoft & External System.
- UI test.
- Better Design.
- Styling definitions for textviews and buttons etc.
- Mobile Application for Apple.

## 🔧 How to Setup
There are no rules for downloading.

### 📷 Photo
<p align="center">
<img src="https://user-images.githubusercontent.com/49414644/219973191-f507f16a-535e-48d8-97b8-0deee735c711.jpg" width="24%"/> 
<img src="https://user-images.githubusercontent.com/49414644/219973207-082625a8-6ed8-4a7e-b8e7-0009be8616dc.png" width="24%"/> 
<img src="https://user-images.githubusercontent.com/49414644/219973217-253ad8ae-22e9-4cf3-a4c4-911fbe3cfc4e.png" width="24%"/> 
<img src="https://user-images.githubusercontent.com/49414644/219973227-140f2a40-2167-4814-8380-9cfd1c5d06da.png" width="24%"/> 
<img src="https://user-images.githubusercontent.com/49414644/219973232-f52157a1-b73a-447b-9d62-84591c695cf7.png" width="24%"/>
<img src="https://user-images.githubusercontent.com/49414644/219973235-732679f9-61ed-4785-b910-32ea00ab5f9c.png" width="24%"/> 
</p>

### 🎥 Video

## [🔝 Back to Top](#-follow-this-list) 

 [EmguCV]: <https://developer.apple.com/documentation/uikit>
 [OV7670 Camera]: <https://circuitdigest.com/microcontroller-projects/how-to-use-ov7670-camera-module-with-arduino>
 [MSSQL]: <https://www.tutorialspoint.com/ms_sql_server/index.htm>
 [Xamarin\Android]: <https://learn.microsoft.com/en-us/xamarin/android/>
 [ASP.NET Web Api]: <https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_web_api.htm>
