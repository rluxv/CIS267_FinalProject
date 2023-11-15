# GameManager.cs

The game manager is the root for our entire game, it will hold global state that we will need to access between scripts and/or scenes.

## Methods

| Method Name     | Params | Return              | Description                                                       |
| --------------- | ------ | ------------------- | ----------------------------------------------------------------- |
| OnGameLoad      | `()`   | `void`              | Called when you want to load the game from the current save file. |
| OnCreateNewSave | `()`   | `void`              | Creates a new game save file and saves the file.                  |
| GetPlayer       | `()`   | `PlayerManager`     | Return the player manager instance.                               |
| GetSave         | `()`   | `GameSave_Template` | Return the current save instance.                                 |
