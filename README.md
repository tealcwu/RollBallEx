# RollBallEx

This is an extension project base on Unity Roll a Ball tutorial (https://learn.unity.com/project/roll-a-ball). I will extend this project by adding more features.

Dev Log:

**2023/08/15 - Audio Manager**

Add audio manager in setting page, to control BGM and sound effect volume and On/Off.

* [New] Update setting page, add toggle and slider to control audio settings.
* [New] Save audio status and volume in PlayerPrefs, load them when starting.
* [New] Add AudioManager to control all audio sources.
* [New] Play background music across all scenes now.



**2023/08/14 - Sound Effects**

Add background music and sound effects.

* [New] Add background music in game scene.
* [New] Add different sound effects when player collides with pickup and enemy.
* [New] Add sound effect when clicking UI buttons.



**2023/08/13 - Scenes Manager**

Add Start/Settings/Store scenes and navigate between them.

* [New] Add new scenes.
* [New] Add replay function.



**2023/08/13 - Jump**

Add new Input Action to handle jump by pressing Space bar.

* [New] Add basket ball texture to player ball, in order to show it's rolling.
* [New] Add collision handler when the player collides with pickup.
* [New] Add custom jump Input Action to player.



**2023/08/13 - Spawn Manager**

* [New] Add new enemy role. The score decrease by 2 when player collides with enemy.
* [New] Add SpawnManager, to generate pickups and enemies in random positions.



**2023/08/13 - Sweet Start**

Initial version, same as Unity's tutorial project.
* [New] Moving player with Input System
* [New] Camera follow with player
* [New] Creating and collecting collectibles
* [New] Display score and result text

