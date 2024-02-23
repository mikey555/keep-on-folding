# Keep On Folding - simple word scramble game

![logo](https://github.com/mikey555/keep-on-folding/assets/983004/aa288f41-b435-442f-b154-377d53844ba9)

Play: https://mikitimik.itch.io/keep-on-folding<br/>
Artwork, animation - <a href="https://jsantos.work/">8bitsantos</a><br/>
Programming, music - mikitimik (me)<br/>


v1 - made for GMTK Jam 2022. I spent about 4 hours implementing a basic playable version.
- type and submit to solve
- skip puzzle
- endless

v2 - developed into a timed game with end state. I also significantly improved the readability and modularity of the code.
- implemented a timer with correct answer time bonus and skip penalty
- anagrams now accepted (e.g., resist, sister)
- streak counter
- hint button
- start screen, game over screen, animated transitions, replay game
- architecture redo - refactor singletons to an event-based architecture
- added a few SFX

## Architecture
I built v1 with singletons controlling most elements on the game’s logic and global state. For a game jam, this is all well and good, and allowed me to build it in a matter of hours. But when I wanted to add new features such as timers, animations, hints, and a streak counter, things got messy fast. 

For v2, I challenged myself to modularize all elements of the game and connect them with an event system. This has resulted in more focused classes, fewer dependencies, easier debugging, and also lays groundwork for smoother development of new features such as multiplayer.

## Input
I wanted to get to know Unity's Input System which allows for easy mapping of keys to actions, and simple enabling and disabling of actions. For example, the answer text shouldn't accept input during a puzzle transition, so I can switch off these actions during that time.

![Screenshot 2023-07-03 at 3 40 26 PM](https://github.com/mikey555/keep-on-folding/assets/983004/cb0cb7e9-c8a5-4b3a-b17b-6d48e9124af3)

## Transitions
Although my new event system was doing a good job of modularizing the project, it become burdensome when it came to adding animation between game states, and I found myself creating new events for the sole purpose of invoking another event. My first approach was to use a Director and Playable Timeline. This was quite cumbersome for simple transitions. I ended up writing a TransitionDirector component that would coordinate tweening (with DOTween) and game logic of switching between game states. 

## Anagrams
First I found a list of around 400 common 6-letter words. Then I feed the list to [getAnagrams.py](https://github.com/mikey555/keep-on-folding/blob/main/python/getAnagrams.py) which checks each word for possible anagrams by calling the [anagramica API](http://www.anagramica.com/api) and outputs a complete word list in json.

## Scene Hierarchy
<img style="align: left" src="https://github.com/mikey555/keep-on-folding/assets/983004/c635cff5-b861-45e9-9ac7-1f25fe5878b5">



