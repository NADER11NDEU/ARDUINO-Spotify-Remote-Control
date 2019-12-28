# Hi 

Hello, this is an university project which we have to use arduino. So I decided to make remote control for active devices which are using Spotify at the same time :D I do not know C# properly. I didnt work on .NET applications before, so some of my codes may seem absurd or unnecessary to you, just ignore them. See this project as a reference and find out what works for you.

Arduino Spotify Control With C# Spotify Api

![alt_text](https://i.imgur.com/AciutFS.png)


Spotify Web Api: https://developer.spotify.com/documentation/web-api/

Spotify API-Net: https://github.com/JohnnyCrazy/SpotifyAPI-NET

Bunifu Framework: https://bunifuframework.com/

 
# How it Works ? What it Does ? etc (Purpose of this project)

Well, with this project we will be able to control active spotify devices with Arduino. How we gonna do that ? We will use serial communication.

We will connect our arduino with our pc (use USB2.0 / 3.0) , and arduino will read which button we pressed on remote controller (ir reciver), then it will send it to our C# application. Our C# application will read which button we pressed and for example if we pressed stop music button then it will stop the music.
It is simple like that. If you have wifi module , you can do nearly same things (like stop,play music, go next etc) but as you know arduino actually does not have multi threading support so you have to deal with a lot of bugs. Thats why I made it on computer, not on Arduino. Also I hadnt have wifi module.

My suggestion: Use bluetooth module for send your data to computer, and power up arduino with rechargable battery. As I said before, use this project as referance :) 

# Arduino Circuit
![alt_text](https://i.imgur.com/zyQlwpS.png)
![alt_text](https://i.imgur.com/TlGhO2C.png)

# Remote Controller:
![alt_text](https://i.imgur.com/3LikE9M.png)


CH- : Delete current song from user favorite list

CH+:  Add current song to user favorite list

CH:   Play user favorite list

|<<:  Play previous track

>>|:  Play next track

Play_Pause.

-	: Volume up.

+ : Volume down.

EQ:  Change featured list country

0-9: Play track list on featured list. (0-9 index number)

100+: |<<< : Skip 30 secs, EQ: shuffle = !shuffle 

200+: |<<< : Skip 60 secs, EQ: shuffle = !shuffle

Button Array:
{0xFFE01F,0xFFA857,0xFFC23D,0xFF02FD,0xFF22DD,0xFFE21D,0xFFA25D,0xFF629D,0xFF6897,0xFF30CF,0xFF18E7,0xFF7A85,0xFF10EF,0xFF38C7,0xFF5AA5,0xFF42BD,0xFF4AB5,0xFF52AD,0xFF906F,0xFF9867,0xFFB04F,0xFFA857};

I'll add more informations & usages about our application soon...
