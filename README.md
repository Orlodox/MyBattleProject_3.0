# MyBattleProject_3.0

General description:
This project is a simulated battle between two teams. It is made in the spirit of minimalism - that's why Units are circles, and extensions are figures.

Each unit has its own speed and distance, on which it can detect the enemy. Different commands have different parameters:
- In blue - less speed, but more coverage area locator.
- White has more speed, but less coverage area.

Also, each unit can be supplemented with three extensions at the beginning of the game.

Home screen interface:
It includes: a panel with extensions describing them, a panel for selecting the desired unit, a panel for the unit's design, and a button for starting the game.

To install an extension to a unit, you must select it and drag the extension to it. If the extension is not dragged to a circle, it will return to its original position. The presence and location of the extensions on each unit is remembered and can be edited as many times as necessary until the "GO" button is pressed.

After starting the game, all installed extensions appear on the units (and are displayed graphically, and the unit creates a child extension object that has its own behavior).

The battle process:
All units start moving in a random direction. When the enemy hits the unit's zone of vision, the unit makes a shot. If the enemy can not evade the bullet (the bullet has such a speed, which sometimes allows to evade), then one life is taken away from him.

Each unit has 3 lives. Find out how many lives this unit has left in its image in the game: 3 lives - the circle is painted completely, 2 lives - half full, 1 life - not painted.

The shot is produced at a frequency of 2 times per second, while one unit is in the scope of the other. After three hits a bullet in a unit, it is destroyed.
