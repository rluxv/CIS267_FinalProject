# GameSave.cs

This static class will help you save a game and collect game saves. It supports multiple game saves and does all the saving work for you.

| Method Name  | Params                     | Return                    | Description                                                                                               |
| ------------ | -------------------------- | ------------------------- | --------------------------------------------------------------------------------------------------------- |
| SaveGame     | `(GameSave_Template save)` | `string Save ID`          | This will save any game save template you pass it. It will override existing game saves with the same id. |
| GetGameSaves | `()`                       | `List<GameSave_Template>` | Get a list of all game saves.                                                                             |
