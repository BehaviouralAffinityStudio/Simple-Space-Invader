# Simple-Space-Invader
WORK QUALITY NOTE

... First game "Completed"


... DATE OF PRODUCTION
... ... Winter 2020 
... ... ~ unknown hours
... ... ... As part of a first year school's cohort game jam with theme "Reproduce Space Invader"


... CODE QUALITY
... ... Second semester studying programmation
... ... Code may therefore be unpolished or just plain weird in term of logic choice


... LAST MINUTE CHANGES FOR PORTFOLIO -LESS JARRING EXPERIENCE-
... ... Renamed items in hierarchy for readability
... ... Sorted Project's folders for readability
... ... Playerpref added for high score
... ... Added an existing script on enemy so that they can destroy building's blocks OnTriggerEnter2D()
... ... Added cursor lock and set visibility to false because it's just terrible to have it on.
... ... Added "Lazy Border XXX" on right and left sides of camera view to show the game world's boundaries
... ... Changed animator which didn't proceed with whole animation (exit time was 0 -newbie me was a dumb dumb-)
... ... Canvas were set with proper anchors

... DESIGN LOGIC
... ... The goal was to instantiate and place by code most of the assets to the screen
... ... ... Lives, buildings, enemies
... ... For loop was used to reproduce the old ways (or so I believe) of moving the enemies on the screen
... ... ... A modifier is applied to the speed of execution for each enemy death
... ... Buildings are made out of 1x1 squares and their positions are dictated by a char[,] and a for loop


... CREDITS
... ... All sprites were made by the owner of the game
