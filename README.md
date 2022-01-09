# WSCADCodeChallenge2022

Hi,
I have to write some explanation about the project.

First
4. As X and Y can be any valid float numbers and window size is limited to a screen resolution, all
primitives should be automatically and proportionally scaled to be fit for the window.

Unfortunately I couldn`t accomplished it. 
Need to use Canvas and even though I use viewBox to wrap it , it didnt work at all. I wrote a custom canvas class again I couldnt do it.
I gave up on Canvas, I tried to use Grid for resizing the shapes but I couldnt do it again.
I spent 2 nights for it but there are not enough documentation or example for it on web.

Infact I am a freshman on WPF technology maybe it is because I couldnt do that.

Sorry about that.

The other thing first I draw a polygon for triangle than I desided to use lines because to the DrawToMainWindow method more generic. 
(polygon is not added to the path)

Lastly first I used json properties for deserilizing the shapes however than I desided to do project for the parser classes 
because I think the reusability matters for parsing the json.
then there is a circle dependency btw shapes and parser. I choose reusability. 

Have a nice day
Melike.
