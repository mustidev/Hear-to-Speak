# Hear-to-Speak
This is a desktop application developed to learn and practice the pronunciation of Turkish words by listening and speaking.

## DEFINITION

Hear To Speak is an desktop application like a word game which provides users to learn how to pronounce Turkish words. Application has 3 menus.The first menu allows you to listen to the Turkish voice-overs of the words by clicking the words on the buttons.The second menu aims to find the listened word by clicking the correct word on buttons.In the third menu, the user is expected to speak the word on the screen in Turkish.If the user speaks correctly, it prints the "Doğru!" message on the screen.If not, then it ask to say it again.

## TECHNOLOGIES

This application is made using by C# Language on Visual Studio platform including Microsoft Azure Speech Services and Firebase Realtime Database services.

```csharp
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using Firebase.Database;
using Firebase.Database.Query;

```

## CONTENTS 

![image](https://www.linkpicture.com/q/picture_1675541460444.png)


## KEYS 
You need the create a **[Microsoft Azure Services](https://portal.azure.com/#create/Microsoft.CognitiveServicesSpeechServices)** account and get a subscription key to run the code. You can acces service and subscripton region from your subscription.
After creation of Azure account, go to console and select the create resource on the left panel.The follow the next instructions:
**Create resource >> AI and Machine Learning >> Speech.**

![image](https://www.linkpicture.com/q/WhatsApp-Image-2023-02-04-at-22.24.03_1.jpeg)

Then you can complete the steps and creat the resource. After create the resource , you might acces the keys and endpoints which includes your ***"Subscription_Key"**** and ***"Subscription_Region"*** that you need the add your code. These need to be added to **Form2.cs**, **Form3.cs** and **Form4.cs** pages.


![image](https://www.linkpicture.com/q/WhatsApp-Image-2023-02-04-at-22.08.26.jpeg)
## DOWNLOAD 

You can download the setup file form [here](https://drive.google.com/drive/folders/1KXulqEoTlYojuCza5GMs-CJN-Wq0Eqd8?usp=sharing). After downloading the file you can setup the **.exe** file and complete the installation.


## LINKS
Thanks for following me on Github and LinkedIn.

  [![Github](https://icons.iconarchive.com/icons/limav/flat-gradient-social/48/Github-icon.png)](https://github.com/mustidev)  [![LinkedIn](https://icons.iconarchive.com/icons/limav/flat-gradient-social/48/Linkedin-icon.png)](https://www.linkedin.com/in/mustafa8demir/)


## AUTHOR

**Mustafa Demir © 2023**
