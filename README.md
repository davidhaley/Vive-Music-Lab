# Music Lab

##### This project is currently in development and is a continuation of the Google Cardboard version found [here](https://github.com/davidhaley/Udacity-VR-Nano-Degree-Project-5-Museum "Museum").

### [See how I made this project](http://www.davidhaley.io/portfolio/vr/music-lab).

Music Lab is a virtual reality application for HTC Vive containing a compilation of experiments using real-time spatial audio and player interactions.

So far, the application features:

1. A stage with speakers and spatial audio sources which reflect sound in real-time, and adjust their perceived volume depending on how close you are to the speakers. The stage also allows the user to turn off the lights in the room, subsequently providing them with a flashlight to explore the place.  
2. A canvas with buttons that when activated with the laser attached to the player's controller, play audio loops in sync, allowing the player to create music in real-time. I synchronized the audio using Ableton Live by warping each loop to the same BPM, before importing into Unity. Then, I synchronize each audio track by assiging the time samples of each track to a muted master drum track. The player can then enable or disable sounds as they wish, and the sounds will be kept in time.  
3. An audio sequencer structured in a 5 row by 4 column grid (5 audio samples, and four-beats-to-one-bar grid). The player can enable or disable the buttons using their hands, and when the audio sequencer (120 beats per minute) detects the enabled button, it plays the sound.  
4. An audio visualizer. I partitioned the audio into seven frequency bands. Each group represents a different frequency range (bass for example). Then, I convert each group's amplitude to a value ranging between 0 and 1 and assign the values to shapes, which move/dance according to those values.  
5. A 'Modulation Contaminate Funnel.' The player can solve the puzzle, by throwing a cube into a large solid funnel, and the cube becomes "contaminated" with modulation (the same technique used for the audio visualizer). Then, when the player places the contaminated cube onto the dance floor, and turns on the music and turns off the lights, the cube will dance to the music.  

#### Screenshots (March 8th 2017)

![alt text](https://cloud.githubusercontent.com/assets/11729897/23720137/11fe6bec-03fb-11e7-9735-a62548b546e3.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720145/17938786-03fb-11e7-8d8f-d321933a88cc.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720148/1a7814bc-03fb-11e7-929e-f456151fb023.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720152/1f3901e6-03fb-11e7-8e27-6a15e77e17b1.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720159/272fa184-03fb-11e7-9e4f-c35c04796e88.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720166/2db28738-03fb-11e7-89e9-b92a1062ed73.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720173/39a3fc84-03fb-11e7-8f03-24e31c1b08f9.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720181/40fd1ace-03fb-11e7-8e50-7c34e64bcece.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720186/43f63288-03fb-11e7-8591-f747ef8171b2.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720194/48119c18-03fb-11e7-815d-abbdc2d06413.png)
![alt text](https://cloud.githubusercontent.com/assets/11729897/23720204/4c7d270e-03fb-11e7-8f16-6a53fed3335c.png)

#### Project Dependencies

The Lab Renderer v1.0 - https://www.assetstore.unity3d.com/en/#!/content/63141  
SteamVR Unity Plugin - https://www.assetstore.unity3d.com/en/#!/content/32647  
Steam Audio (Phonon) - https://valvesoftware.github.io/steam-audio/  
Unity 5.6.0b11 - https://unity3d.com/unity/beta  
