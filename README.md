# Night of the Nerds Escape Room

This project is a game for Night of the Nerds.

## Project status

The project is currently being actively worked on.
The project is in a playable state, however there are still some bugs.

## Roadmap

For what is being considered, being worked on and finished, check out the [online scrumboard](https://share.clickup.com/b/h/2ccww-155/19b3742998ccac9).

## Installation

Use Unity 2020.1.17f1 to open the project files itself by placing the whole project in a folder and selecting it in Unity Hub.

## Usage

Because the project uses WebGL, it can be played using any modern browser.
A link will be provided to try the game out soon.

PLEASE NOTE THE FOLLOWING:
A known bug in the editor causes the game to not progress to the lobby after the main menu.
This bug is caused by something unknown with the Proton Camera inside the prefab "FPPlayer". To get around it, please open the prefab and enable and disable the Main Camera in there, and then save the project.
Because of this make sure that when pushing to the git, DON'T push the file "FPPlayer" if you have not changed anything to it, or everyone will have this bug the next time.
This bug does not appear in release.

## Contributing

Contributing to this project is closed off for non-team members.

## License

TBA
