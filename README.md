# Unity Room Creator
![](https://i.imgur.com/iUR6DSI.png)
## Overview
During my spare time playing with a Dungeon Crawler prototype, I decided to make this simple algorithm (the main script has only 54 lines and you can get it ![here](https://github.com/lcrabbit/unity-room-creator/blob/master/Assets/Scripts/RoomGenerator.cs)) to level design prototyping.

Basically, it turns a `Texture2D` into a structure (or whatever you'd like to generate based in colored pixels).
This base uses only the magenta (`Color(1, 0, 1, 1)`) to handle Walls, but the script is easily expansible to map enemies, chests, ground and everything else.
After setting up your generator Game Object with the script, you need to feed it with a `Source Sprite [Texture 2D]` which will be read and used to generate the map. By default, all the generated room prefabs are going to the `Assets/Resources/Prefabs/GeneratedOutput` folder.

Feel free to suggest or send any changes, thanks.

![](https://i.imgur.com/GPvEfKP.png)
