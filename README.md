# Code 10-10
Code 10-10 is a multiplayer first-person shooter deathmatch game made in the Unity game engine. The server application repo can be found [here](https://github.com/EngineerFaunce/code-1010-client).

![image](https://user-images.githubusercontent.com/16312436/127939143-24df046e-ced8-476c-828d-772d3d7753b7.png)

This client application will allow a user to connect to a Code 10-10 server. Upon joining, players will spawn at one of the various spawn points in an arena.

This game was originally made as part of a course I took on Unity game development. The topic I chose to pursue was multiplayer and 
this is the product of having taken the course. Code 10-10 follows a client-server architecture pattern where player input is sent to the
server which processes each player's input and then sends the results back to the client(s).

## Game Mechanics

Players have a typical health and stamina bar as well as a score count to keep track of points from killing other players. *Note: there is currently no way
to win a game from accumulating points.*

Players can walk, run, and jump to traverse the map. If a player falls off the map, they will hit a death barrier and respawn.

![image](https://user-images.githubusercontent.com/16312436/127939707-8560a8b1-358e-42de-9852-9dd5d942bf45.png)

The player's gun also has infinite ammo in the current implementation with no limit on rate of fire either.
