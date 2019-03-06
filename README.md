# Unity Room Creator
![](https://i.imgur.com/iUR6DSI.png)
## Overview
During my spare time playing with a Dungeon Crawler prototype, I decided to make this simple algorithm (the main script has only 54 lines and you can get it ![here](https://github.com/lcrabbit/unity-room-creator/blob/master/Assets/Scripts/RoomGenerator.cs)) to level design prototyping.

Basically, it turns a `Texture2D` into our map (or whatever you'd like to generate based in colors).
This base uses only the magenta (`Color(1, 0, 1, 1)`) to handle Walls, but the script is easily expansible to map enemies, chests, ground and everything else.
After setting up your generator Game Object with the script, you need to feed it with a `Source Sprite [Texture 2D]` which will be read and used to generate the map.
At the moment, you need to play and then create a prefab by dragging the generated source. As I made it on a few minutes of spare time, I'll improve as soon as possible.
Feel free to suggest or send any changes, thanks.

![](https://i.imgur.com/GPvEfKP.png)
