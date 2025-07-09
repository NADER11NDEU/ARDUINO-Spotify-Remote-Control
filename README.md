# Main 

This is a university project where we were required to use Arduino. So, I decided to build a remote control system for active Spotify devices using Arduino.
I’ve never worked with C# before, so some of my code might seem a bit strange or unnecessary—feel free to ignore those parts. Instead, treat this project as a reference and adapt what works for you.

Arduino Spotify Control With C# Spotify Api

![alt_text](https://i.imgur.com/AciutFS.png)


Spotify Web Api: https://developer.spotify.com/documentation/web-api/

Spotify API-Net: https://github.com/JohnnyCrazy/SpotifyAPI-NET

Bunifu Framework: https://bunifuframework.com/

  
# Purpose of this project

The goal is to control active Spotify devices using an Arduino.
How are we going to do that? Through serial communication.

We’ll connect the Arduino to a PC (via USB 2.0 / 3.0). The Arduino reads which button is pressed on the remote controller (via IR receiver), then sends that information to a C# application.
The C# app interprets the command—for example, if the stop button was pressed, it stops the music.
Additionally, the app fetches the music title and artist name, and displays them on a 16x2 LCD screen.

That’s basically it. If you have a Wi-Fi module, you could implement similar functionality (play, pause, next track, etc.), but since Arduino doesn’t support multithreading, you’ll likely run into bugs. That’s why I decided to handle the logic on the PC instead of the Arduino.
Also… I didn’t have a Wi-Fi module 😅

My suggestion: Use a Bluetooth module to send data to your computer and power your Arduino with a rechargeable battery.
Again, use this project as a reference. :)

# Usage
```
1-Download the C# source code.
2-Open it with Visual Studio.
3-Click "Add Reference", then select Bunifu_UI_v1.5.3.dll (you can find it in the release folder).
4-Build the project, then reopen both Visual Studio and the project.
5-Edit the Auth_Client_Id, Auth_Client_Secret, and Redirect URI values (get them from your Spotify Developer Dashboard by creating a new client).
6-Run the application.
7-Select the necessary scopes and click "Get Auth Link".
8-A browser window will ask for permission—accept it.
9-In the Tab Menu, go to Spotify Access Token.
10-Press "Get Tokens".
11-Now you have an access token, refresh token, etc. You can start using the Spotify .NET API.
12-Go to Spotify Control in the Tab Menu.
13-Press "Connect to API". You’ll now see connected devices, the current song, etc.
14-Select your Arduino COM port and press "Connect to Port".
15-That’s it! You can now control Spotify on your active device using your remote controller. Have fun! 🎉
```

# Features
```
*Display album, track, and playlist info
*Show album art
*Control volume, play next/previous song (via remote or app)
*Browse featured playlists by market
*Play featured lists (via remote or app)
*Add current song to favorites (via remote or app)
*Remove current song from favorites (via remote or app)
*Play your favorite playlist (via remote or app)
*Enable shuffle mode (via remote or app)
*Show artist and song name on LCD screen
*Auto refresh token (new feature)
```

# Arduino Circuit with HC05 Bluetooth Module
![alt_text](https://i.imgur.com/02xA6jN.png)

You can easily adapt this project with some minor changes. Just search for tutorials online.
If it’s your first time with Arduino and programming—and you don’t know where to start—stick to serial communication via USB.
If you run into problems with the HC-05, feel free to reach out.

# Arduino Circuit (for this project)
![alt_text](https://i.imgur.com/zyQlwpS.png)
![alt_text](https://i.imgur.com/TlGhO2C.png)

# Circuit Elements
```
1- Remote Controller
2- IR Reciever (VS1838B)
3- Leds for debug
4- 220-500 ohm resistance
5- 16x2 LCD Display
6- LCD I2C/IIC Converter Card
```
# Remote Controller:
![alt_text](https://i.imgur.com/3LikE9M.png)

```
CH-    : Delete current song from user's favorites  
CH+    : Add current song to user's favorites  
CH     : Play user's favorite playlist  
|<<    : Previous track  
>>|    : Next track  
|>     : Play/Pause  
-      : Volume down  
+      : Volume up  
EQ     : Change featured list's country  
0–9    : Play track from featured list (index 0–9)  
100+   : Skip 30 seconds, toggle shuffle  
200+   : Skip 60 seconds, toggle shuffle  

```

# Release
https://github.com/NADER11NDEU/ARDUINO-Spotify-Remote-Control/releases/tag/1.1

# Special Thanks to:
[JohnnyCrazy](https://github.com/JohnnyCrazy) for his awesome Spotify .NET Api (it saved my time).
[Bunifu Framework](https://bunifuframework.com/) I designed my form with this framework.
