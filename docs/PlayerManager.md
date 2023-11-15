# PlayerManager.cs

Player manager holds all properties about the player and allows you to manipulate any part of the player state that you might need when you have access to this manager. It can be obtained from the game object or direcrly through the game manager.

## Public Properties

| Property Name | Description                                                                                                                   |
| ------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| obj           | This returns the player `GameObject` for you to manipulate. Thing such as the position or rotation of the player game object. |

## Methods

| Method Name | Params           | Return  | Description                                                                                          |
| ----------- | ---------------- | ------- | ---------------------------------------------------------------------------------------------------- |
| SetHealth   | `(float health)` | `void`  | Set the players health, this does not subtract from the heath just directly sets the players health. |
| GetHealth   | `()`             | `float` | Get the players health.                                                                              |
