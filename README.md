# Unity RGB Based Level Generator
![](https://i.imgur.com/iUR6DSI.png)
## Overview
During my spare time playing with a Dungeon Crawler prototype, I decided to make this simple algorithm (the main script has only 54 lines and you can get it ![here](https://github.com/lcrabbit/unity-room-creator/blob/master/Assets/Scripts/RoomGenerator.cs)) to level design prototyping.

Basically, it turns a `Texture2D` into a GameObject.
This base system has now support to N `GameObject: color` pairs. You just need to increase the `Instances To Generate` size, drag 'n drop your objects and see the magic. With that you can build entire levels from a simple pixelated image. This is useful to turn concept to live having only one `minimap` like and the desired props to be used.
Remember that you need to feed it with a `Source Sprite [Texture 2D]` which will be read (the sprite must have write/read permission) and used to generate the map. By default, all the generated room prefabs are going to the `Assets/Resources/Prefabs/GeneratedOutput` folder.

Feel free to suggest or send any changes, thanks.

![](https://i.imgur.com/GPvEfKP.png)
