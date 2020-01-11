# Hi 

Hello, this is an university project which we have to use arduino. So I decided to make remote control for active devices which are using Spotify at the same time :D I do not know C# properly. I didnt work on .NET applications before, so some of my codes may seem absurd or unnecessary to you, just ignore them. See this project as a reference and find out what works for you.

Arduino Spotify Control With C# Spotify Api

![alt_text](https://i.imgur.com/AciutFS.png)


Spotify Web Api: https://developer.spotify.com/documentation/web-api/

Spotify API-Net: https://github.com/JohnnyCrazy/SpotifyAPI-NET

Bunifu Framework: https://bunifuframework.com/

  
# How it Works ? What it Does ? etc (Purpose of this project)

Well, with this project we will be able to control active spotify devices with Arduino. How we gonna do that ? We will use serial communication.

We will connect our arduino with our pc (use USB2.0 / 3.0) , and arduino will read which button we pressed on remote controller (ir reciver), then it will send it to our C# application. Our C# application will read which button we pressed and for example if we pressed stop music button then it will stop the music. Also our C# application will send Music Name & Singer Name. And we will display them on our 16x2 LCD Display Screen. 
It is simple like that. If you have wifi module , you can do nearly same things (like stop,play music, go next etc) but as you know arduino actually does not have multi threading support so you have to deal with a lot of bugs. Thats why I made it on computer, not on Arduino. Also I hadnt have wifi module.

My suggestion: Use bluetooth module for send your data to computer, and power up arduino with rechargable battery. As I said before, use this project as referance :) 

# Usage
```
1- Download our C# source
2- Open it with Visual Studio
3- Press Add Reference and select Bunifu_UI_v1.5.3.dll (you can get this dll from Release.)
4- Build the project and reopen visual studio and our project.
5- Change "Auth_Client_id ,Auth_Client_sr and Redirect URI's (you can get your client id, client sr and r_uris on your spotify dashboard, just create new client on your spotify developer dashboard)
6- Run our application
7- Select scopes and press Get Auth Link
8- It will ask you for premission, accept it. (I used webbrowser)
9- Press Spotify Access Token button on tab menu
10- Press Get Tokens button
11- Now we have access token, refresh token etc. We can start Spotify NET API ...
12- Press Spotify Control button on Tab Menu
13- Press Connect to Api, now you will debug which devices are connected with spotify, what is current song etc etc.
14- Select your arduino port and press Connect to Port
15- Now you can control your active devices spotify with your remote controller. Have a fun :)
```

# Features
```
* Display Album , track, list informations.
* Display Album Image
* Control Volume, next song etc. (with remote controller, application)
* Display Featured list, featured market
* Play Featured list (with remote controller, application)
* Add current song to your spotify favorite list (with remote controller, application)
* Delete current song from your spotify favorite list (with remote controller, application)
* Play your favorite list (with remote controller, application)
* Set Shuffle (with remote controller, application)
* Display Singer and Song name on LCD Screen
* Auto refresh token (new feature)
```

# Arduino Circuit
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
CH- : Delete current song from user favorite list
CH+:  Add current song to user favorite list
CH:   Play user favorite list
|<<:  Play previous track
>>|:  Play next track
|> Play_Pause.
-	: Volume down.
+ : Volume up.
EQ:  Change featured list country
0-9: Play track list on featured list. (0-9 index number)
100+: |<<< : Skip 30 secs, EQ: shuffle = !shuffle 
200+: |<<< : Skip 60 secs, EQ: shuffle = !shuffle

Button Array:
{0xFFE01F,0xFFA857,0xFFC23D,0xFF02FD,0xFF22DD,0xFFE21D,0xFFA25D,0xFF629D,0xFF6897,0xFF30CF,0xFF18E7,0xFF7A85,0xFF10EF,0xFF38C7,0xFF5AA5,0xFF42BD,0xFF4AB5,0xFF52AD,0xFF906F,0xFF9867,0xFFB04F,0xFFA857};
```

# Credits:

1- [JohnnyCrazy](https://github.com/JohnnyCrazy) for his awesome Spotify .NET Api (it saved my time).

2- [Bunifu Framework](https://bunifuframework.com/) I designed my form with this framework.

3- Dr. Onur Bugra KOLCU - He taught arduino to me and his students in a short time.

4- Nader11ndeu (me)


 
