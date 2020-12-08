﻿using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using System;
using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDK3.Video.Components.Base;


#if !COMPILER_UDONSHARP && UNITY_EDITOR
using UnityEditor;
using UdonSharpEditor;
#endif


public class MenuControl : UdonSharpBehaviour
{
/*
0th value is the word 
1st value is the name of the animation state (Used in the animation controller populator script to generate transitions - needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
2nd value is mocap credits. 
3rd value is video URL.
4th value is VR index or regular 0=indexonly , 1=generalvr,2=both
5th value is Sign description string
6th value is sign validation true/false
7th value is sign validated by
*/
public string [][][][] AllLessons = 
new string[][][][]{ //all languages
new string[][][]{//asl lessons
new string[][]{//Lesson 1 (Daily Use)
new string[]{"Hello","ASL-Hello","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"How (are) You","ASL-How (are) You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"What's Up?","ASL-What's Up?","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","0","","TRUE","ShadeAxas"},
new string[]{"What's Up? (Variant 2)","ASL-What's Up? (Variant 2)","Bob64","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Nice (to) Meet You","ASL-Nice (to) Meet You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Good","ASL-Good","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bad","ASL-Bad","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4","2","1-handed version. Also can be done with two hands - see the sign for 'Good' note the palm direction.","TRUE","ShadeAxas"},
new string[]{"Yes","ASL-Yes","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"No","ASL-No","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"So-So","ASL-So-So","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sick","ASL-Sick","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Sick (Variant 2)","ASL-Sick (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hurt","ASL-Hurt","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"You're Welcome","ASL-You're Welcome","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Goodbye","ASL-Goodbye","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Good Morning","ASL-Good Morning","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Good Afternoon","ASL-Good Afternoon","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4","2","","FALSE",""},
new string[]{"Good Evening","ASL-Good Evening","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Good Night","ASL-Good Night","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"See You Later","ASL-See You Later","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Please","ASL-Please","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sorry","ASL-Sorry","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Forget","ASL-Forget","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sleep / Sleepy","ASL-Sleep / Sleepy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4","2","Single motion for sleep. Do a double-motion for sleepy.","TRUE","ShadeAxas"},
new string[]{"Bed","ASL-Bed","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Jump / Change World","ASL-Jump / Change World","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4","2","","FALSE",""},
new string[]{"Thank You","ASL-Thank You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"I Love You","ASL-I Love You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"ILY (I Love You)","ASL-ILY (I Love You)","GT4tube","","0","This sign is the combinations of the letters I, L, and Y. It's the abbreviated version of I Love You.","TRUE","ShadeAxas"},
new string[]{"Go Away","ASL-Go Away","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Going To","ASL-Going To","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4","2","This is a directional sign. You point to where you're going.","FALSE",""},
new string[]{"Follow","ASL-Follow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Come","ASL-Come","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hearing (Person)","ASL-Hearing (Person)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4","2","Use this when discussing a person that can hear.","TRUE","ShadeAxas"},
new string[]{"Deaf","ASL-Deaf","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Deaf (Variant 2)","ASL-Deaf (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hard of Hearing","ASL-Hard of Hearing","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mute","ASL-Mute","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Write Slow","ASL-Write Slow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Can't Read","ASL-Can't Read","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Away","ASL-Away","GT4tube","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 2 (Pointing use Question/Answer)
new string[]{"I (Me)","ASL-I (Me)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"My","ASL-My","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4","2","Open palm implies possessive. eg: That wallet is mine.","TRUE","ShadeAxas"},
new string[]{"Your","ASL-Your","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4","2","A possessive form of 'you'. eg: That's your wallet.","TRUE","ShadeAxas"},
new string[]{"His","ASL-His","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4","2","","FALSE",""},
new string[]{"Her","ASL-Her","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4","2","","FALSE",""},
new string[]{"We","ASL-We","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"They","ASL-They","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4","2","You sweep your pointer over the people you're referring to.","TRUE","ShadeAxas"},
new string[]{"Their","ASL-Their","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4","2","Possessive form of they. eg: This is their house.","TRUE","ShadeAxas"},
new string[]{"Over There","ASL-Over There","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4","2","","FALSE",""},
new string[]{"Our","ASL-Our","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"It's","ASL-It's","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Inside","ASL-Inside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Outside","ASL-Outside","GT4tube","","2","General version of outside.","TRUE","ShadeAxas"},
new string[]{"Outside (Outdoors)","ASL-Outside (Outdoors)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hidden","ASL-Hidden","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Behind","ASL-Behind","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Above","ASL-Above","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Below","ASL-Below","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Here","ASL-Here","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Beside","ASL-Beside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Back","ASL-Back","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Front","ASL-Front","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Who","ASL-Who","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Where","ASL-Where","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"When","ASL-When","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Why","ASL-Why","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Which","ASL-Which","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"What","ASL-What","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","2","This variant is perferred over variant 2, as variant 2 is a Signed Exact English Variant","TRUE","ShadeAxas"},
new string[]{"What (Variant 2)","ASL-What (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","2","A Signed Exact English variant of What.","TRUE","ShadeAxas"},
new string[]{"How","ASL-How","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"How (Variant 2)","ASL-How (Variant 2)","GT4tube","","2","This version is done with two A-hands next to each other and a twisting motion of your dominate hand.","TRUE","ShadeAxas"},
new string[]{"How Many","ASL-How Many","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4","2","","FALSE",""},
new string[]{"How Many (Variant 2)","ASL-How Many (Variant 2)","Anonymous","","2","","FALSE",""},
new string[]{"Can","ASL-Can","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Can't","ASL-Can't","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Want","ASL-Want","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Have","ASL-Have","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Get","ASL-Get","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Will / Future","ASL-Will / Future","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Take (Up)","ASL-Take (Up)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4","2","Take as in 'Take (up) a class' or 'Take (up) a child. Like you're adopting one.'","TRUE","ShadeAxas"},
new string[]{"Need","ASL-Need","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4","0","Like the sign for 'Must' except with a double motion.","TRUE","ShadeAxas"},
new string[]{"Must","ASL-Must","GT4tube","","0","Like the sign for 'Need', except with a single strong movement.","TRUE","ShadeAxas"},
new string[]{"Not","ASL-Not","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Or","ASL-Or","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4","2","This is just 'O' and 'R' fingerspelled.","TRUE","ShadeAxas"},
new string[]{"And","ASL-And","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4","2","","TRUE","ShadeAxas"},
new string[]{"For","ASL-For","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4","2","","TRUE","ShadeAxas"},
//new string[]{"At","ASL-At","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","2",""},
//new string[]{"At (Variant 2)","ASL-At (Variant 2)","GT4tube","","2",""}
},
new string[][]{//Lesson 3 (Common)
new string[]{"Teach","ASL-Teach","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4","2","This sign can use either a double movement or a single movement. Both are fine.","TRUE","ShadeAxas"},
new string[]{"Learn","ASL-Learn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Person","ASL-Person","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Student","ASL-Student","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Teacher","ASL-Teacher","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Friend","ASL-Friend","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4","2","The IRL sign has your two index fingers hooking around the other.","TRUE","ShadeAxas"},
new string[]{"Sign","ASL-Sign","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Language","ASL-Language","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Understand","ASL-Understand","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Know","ASL-Know","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Don't Know","ASL-Don't Know","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Be Right Back (BRB)","ASL-Be Right Back (BRB)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Accept","ASL-Accept","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Denied","ASL-Denied","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4","2","","FALSE",""},
new string[]{"Name","ASL-Name","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"New","ASL-New","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Old","ASL-Old","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Very","ASL-Very","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Jokes","ASL-Jokes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Funny","ASL-Funny","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Play","ASL-Play","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Favorite","ASL-Favorite","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Draw","ASL-Draw","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4","2","","FALSE",""},
new string[]{"Stop","ASL-Stop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Read","ASL-Read","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4","2","","FALSE",""},
new string[]{"Make","ASL-Make","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Write","ASL-Write","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Again / Repeat","ASL-Again / Repeat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Slow","ASL-Slow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fast","ASL-Fast","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Rude","ASL-Rude","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Eat","ASL-Eat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4","2","","FALSE",""},
new string[]{"Drink","ASL-Drink","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Watch","ASL-Watch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Work","ASL-Work","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Live","ASL-Live","Anonymous","","2","This version is done with 'A' handshapes on both hands.","TRUE","ShadeAxas"},
new string[]{"Live (Variant 2)","ASL-Live (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4","2","Initialized variant, done with 'L' handshapes on both hands.","TRUE","ShadeAxas"},
new string[]{"Play Game","ASL-Play Game","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Same","ASL-Same","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4","0","This is a directional sign.","TRUE","ShadeAxas"},
new string[]{"Allright","ASL-Allright","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4","2","","TRUE","ShadeAxas"},
new string[]{"People","ASL-People","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Browsing the Internet","ASL-Browsing the Internet","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Movie","ASL-Movie","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4","2","}","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 4 (People)
new string[]{"Family","ASL-Family","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Boy","ASL-Boy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Girl","ASL-Girl","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Brother","ASL-Brother","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sister","ASL-Sister","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Brother-in-law","ASL-Brother-in-law","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sister-in-law","ASL-Sister-in-law","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Father","ASL-Father","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4","2","","FALSE",""},
new string[]{"Grandpa","ASL-Grandpa","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mother","ASL-Mother","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4","2","","FALSE",""},
new string[]{"Grandma","ASL-Grandma","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Baby","ASL-Baby","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Child","ASL-Child","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4","2","","FALSE",""},
new string[]{"Teen","ASL-Teen","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4","2","","FALSE",""},
new string[]{"Adult","ASL-Adult","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Aunt","ASL-Aunt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Uncle","ASL-Uncle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Stranger","ASL-Stranger","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Acquaintance","ASL-Acquaintance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4","2","A person you know.","TRUE","ShadeAxas"},
new string[]{"Parents","ASL-Parents","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Born","ASL-Born","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4","2","","FALSE",""},
new string[]{"Dead","ASL-Dead","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4","2","","FALSE",""},
new string[]{"Marriage","ASL-Marriage","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Divorce","ASL-Divorce","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Single","ASL-Single","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Young","ASL-Young","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Old","ASL-Old","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Age","ASL-Age","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Birthday","ASL-Birthday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Celebrate","ASL-Celebrate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Enemy","ASL-Enemy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Interpreter","ASL-Interpreter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4","0","","TRUE","ShadeAxas"},
new string[]{"No One","ASL-No One","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4","2","","FALSE",""},
new string[]{"Anyone","ASL-Anyone","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4","2","","FALSE",""},
new string[]{"Someone","ASL-Someone","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4","0","Similar motion to 'Always'. Someone is done with a small circle.","FALSE",""},
new string[]{"Everyone","ASL-Everyone","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4","0","","FALSE",""},
},
new string[][]{//Lesson 5 (Feelings/Reactions)
new string[]{"Like","ASL-Like","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Hate","ASL-Hate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Fine","ASL-Fine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Tired","ASL-Tired","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sleep / Sleepy","ASL-Sleep / Sleepy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4","2","Single motion for sleep. Do a double-motion for sleepy.","TRUE","ShadeAxas"},
new string[]{"Confused","ASL-Confused","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Smart","ASL-Smart","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Attention / Focus","ASL-Attention / Focus","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Nevermind","ASL-Nevermind","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4","2","","FALSE",""},
new string[]{"Angry","ASL-Angry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Laughing","ASL-Laughing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"LOL","ASL-LOL","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Curious","ASL-Curious","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4","0","","TRUE","ShadeAxas"},
new string[]{"In Love","ASL-In Love","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Awesome","ASL-Awesome","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4","2","","FALSE",""},
new string[]{"Great","ASL-Great","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4","2","","FALSE",""},
new string[]{"Nice","ASL-Nice","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cute","ASL-Cute","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Feel","ASL-Feel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Pity","ASL-Pity","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Envy","ASL-Envy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4","2","","FALSE",""},
new string[]{"Hungry","ASL-Hungry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Alive","ASL-Alive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bored","ASL-Bored","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cry","ASL-Cry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Happy","ASL-Happy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sad","ASL-Sad","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Suffering","ASL-Suffering","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Surprised","ASL-Surprised","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Careful","ASL-Careful","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Enjoy","ASL-Enjoy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Disgusted","ASL-Disgusted","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Embarrassed","ASL-Embarrassed","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Shy","ASL-Shy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lonely","ASL-Lonely","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4","2","","FALSE",""},
new string[]{"Stressed","ASL-Stressed","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Scared","ASL-Scared","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Excited","ASL-Excited","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Shame","ASL-Shame","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Struggle","ASL-Struggle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Friendly","ASL-Friendly","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mean","ASL-Mean","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 6 (Value) 
new string[]{"More","ASL-More","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4","2","","FALSE",""},
new string[]{"Less","ASL-Less","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Big","ASL-Big","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Small / A Little","ASL-Small / A Little","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Full","ASL-Full","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Empty","ASL-Empty","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4","0","","FALSE",""},
new string[]{"Half","ASL-Half","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Quarter","ASL-Quarter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Long","ASL-Long","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Short (Time)","ASL-Short (Time)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4","0","","TRUE","ShadeAxas"},
new string[]{"A Lot / Many","ASL-A Lot / Many","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Unlimited","ASL-Unlimited","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Limited","ASL-Limited","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"All","ASL-All","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"All (Variant 2)","ASL-All (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","2","This lexicalized variant fingerspells A-L-L while doing the motion.","TRUE","ShadeAxas"},
new string[]{"Nothing","ASL-Nothing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Ever","ASL-Ever","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4","2","","FALSE",""},
new string[]{"Everything","ASL-Everything","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Everytime","ASL-Everytime","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Always","ASL-Always","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Often","ASL-Often","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sometimes","ASL-Sometimes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Heavy","ASL-Heavy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lightweight","ASL-Lightweight","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Hard","ASL-Hard","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4","0","","FALSE",""},
new string[]{"Soft","ASL-Soft","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Strong","ASL-Strong","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Weak","ASL-Weak","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"First","ASL-First","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Second","ASL-Second","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4","2","As in the order of something. 2nd place.","TRUE","ShadeAxas"},
new string[]{"Third","ASL-Third","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Next","ASL-Next","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Last","ASL-Last","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Before","ASL-Before","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"After","ASL-After","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4","2","","FALSE",""},
new string[]{"Busy","ASL-Busy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Free","ASL-Free","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4","2","F' handshape initialized variant.","TRUE","ShadeAxas"},
new string[]{"High","ASL-High","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Low","ASL-Low","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fat","ASL-Fat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Thin","ASL-Thin","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Value","ASL-Value","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4","0","Similar to 'Important', but initialized with a 'V' handshape.","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 7 (Time)
new string[]{"Time","ASL-Time","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Year","ASL-Year","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Season","ASL-Season","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4","2","","FALSE",""},
new string[]{"Month","ASL-Month","GT4Tube","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Week","ASL-Week","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Day","ASL-Day","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Weekend","ASL-Weekend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4","2","","FALSE",""},
new string[]{"Hours","ASL-Hours","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Minutes","ASL-Minutes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4","2","","TRUE","ShadeAxas"},
//new string[]{"Seconds","ASL-Seconds","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4","2","As in the unit of time. A small mistake in the editing of the video: Catman signs SEC + minute sign for seconds of time. Ray signs Second, as in something is in second place in the video.","FALSE",""},
new string[]{"Today","ASL-Today","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Tomorrow","ASL-Tomorrow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Yesterday","ASL-Yesterday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4","0","Y' handshape initialized variant. Can also be done with an 'A' handshape.","TRUE","ShadeAxas"},
new string[]{"Morning","ASL-Morning","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Afternoon","ASL-Afternoon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Evening","ASL-Evening","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Night","ASL-Night","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sunrise","ASL-Sunrise","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4","2","Can also be done with a 'C' handshape.","TRUE","ShadeAxas"},
new string[]{"Sunset","ASL-Sunset","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4","2","Can also be done with a 'C' handshape.","TRUE","ShadeAxas"},
new string[]{"All Day","ASL-All Day","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"All Day (Variant 2)","ASL-All Day (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"All Night","ASL-All Night","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"All Night (Variant 2)","ASL-All Night (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sunday","ASL-Sunday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Monday","ASL-Monday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4","2","IRL this is done with a 'M' handshape","FALSE",""},
new string[]{"Tuesday","ASL-Tuesday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4","2","IRL this is done with a 'T' handshape","FALSE",""},
new string[]{"Wednesday","ASL-Wednesday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4","0","W' handshape.","TRUE","ShadeAxas"},
new string[]{"Thursday","ASL-Thursday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4","2","H'handshape.","TRUE","ShadeAxas"},
new string[]{"Friday","ASL-Friday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4","0","F' handshape.","TRUE","ShadeAxas"},
new string[]{"Saturday","ASL-Saturday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4","2","S' handshape.","TRUE","ShadeAxas"},
new string[]{"Autumn","ASL-Autumn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Winter","ASL-Winter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Spring","ASL-Spring","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Summer","ASL-Summer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Now","ASL-Now","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Never","ASL-Never","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Soon","ASL-Soon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Later","ASL-Later","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Past","ASL-Past","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Future","ASL-Future","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4","0","F' handshape Initialized variant.","FALSE",""},
new string[]{"Earlier","ASL-Earlier","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Midweek","ASL-Midweek","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4","0","Middle + Week.","TRUE","ShadeAxas"},
new string[]{"Next Week","ASL-Next Week","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4","2","}","FALSE",""},
},
new string[][]{//Lesson 8 (VRChat)
new string[]{"Gestures","ASL-Gestures","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4","2","","FALSE",""},
new string[]{"World","ASL-World","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4","0","","FALSE",""},
new string[]{"Record","ASL-Record","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4","0","Record as in an audio recording.","FALSE",""},
new string[]{"Discord","ASL-Discord","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4","2","","FALSE",""},
new string[]{"Streaming","ASL-Streaming","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4","2","","FALSE",""},
new string[]{"Headset (VR)","ASL-Headset (VR)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4","2","","FALSE",""},
new string[]{"Desktop","ASL-Desktop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4","2","As in desk. Ray signs desktop computer in the video.","FALSE",""},
new string[]{"Computer","ASL-Computer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4","2","","FALSE",""},
new string[]{"Instance","ASL-Instance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4","2","","FALSE",""},
new string[]{"Public","ASL-Public","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4","2","","FALSE",""},
new string[]{"Invite","ASL-Invite","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4","2","","FALSE",""},
new string[]{"Private","ASL-Private","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4","2","","FALSE",""},
new string[]{"Add Friend","ASL-Add Friend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4","2","","FALSE",""},
new string[]{"Menu","ASL-Menu","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4","2","","FALSE",""},
new string[]{"Recharge","ASL-Recharge","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4","2","","FALSE",""},
new string[]{"Visit","ASL-Visit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4","2","","FALSE",""},
new string[]{"Request","ASL-Request","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4","2","","FALSE",""},
new string[]{"Login","ASL-Login","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4","2","","FALSE",""},
new string[]{"Logout","ASL-Logout","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4","2","","FALSE",""},
new string[]{"Schedule","ASL-Schedule","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4","2","","FALSE",""},
new string[]{"Event","ASL-Event","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4","0","","FALSE",""},
new string[]{"Online","ASL-Online","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4","0","","FALSE",""},
new string[]{"Offline","ASL-Offline","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4","0","","FALSE",""},
new string[]{"Cancel","ASL-Cancel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4","2","","FALSE",""},
new string[]{"Portal","ASL-Portal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4","2","","FALSE",""},
new string[]{"Camera","ASL-Camera","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4","2","","FALSE",""},
new string[]{"Avatar","ASL-Avatar","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4","2","","FALSE",""},
new string[]{"Photo","ASL-Photo","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4","2","","FALSE",""},
new string[]{"Join","ASL-Join","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4","2","","FALSE",""},
new string[]{"Leave","ASL-Leave","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4","2","","FALSE",""},
new string[]{"Climbing","ASL-Climbing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4","2","","FALSE",""},
new string[]{"Falling","ASL-Falling","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4","2","","FALSE",""},
new string[]{"Walk","ASL-Walk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4","2","","FALSE",""},
new string[]{"Hide","ASL-Hide","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4","2","","FALSE",""},
new string[]{"Block","ASL-Block","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4","2","","FALSE",""},
new string[]{"Crash","ASL-Crash","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4","2","","FALSE",""},
new string[]{"Lagging","ASL-Lagging","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4","2","","FALSE",""},
new string[]{"Restart","ASL-Restart","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4","2","","FALSE",""},
new string[]{"Send","ASL-Send","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4","2","","FALSE",""},
new string[]{"Receive","ASL-Receive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4","2","","FALSE",""},
new string[]{"Security","ASL-Security","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4","2","","FALSE",""},
new string[]{"Donation","ASL-Donation","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4","0","}","FALSE",""},
},
new string[][]{//Alphabet/Numbers (fingerspelling) (lesson9)
new string[]{"Spell / Fingerspell","ASL-Spell / Fingerspell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Spell / Fingerspell (Variant 2)","ASL-Spell / Fingerspell (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","1","","TRUE","ShadeAxas"},
new string[]{"A","ASL-A","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"B","ASL-B","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","0","","TRUE","ShadeAxas"},
new string[]{"B (Variant 2)","ASL-B (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","1","","TRUE","ShadeAxas"},
new string[]{"C","ASL-C","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"D","ASL-D","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"E","ASL-E","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"F","ASL-F","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","0","","TRUE","ShadeAxas"},
new string[]{"F (Variant 2)","ASL-F (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","1","","TRUE","ShadeAxas"},
new string[]{"G","ASL-G","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"H","ASL-H","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"I","ASL-I","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","0","","TRUE","ShadeAxas"},
new string[]{"I (Variant 2)","ASL-I (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","1","","TRUE","ShadeAxas"},
new string[]{"J","ASL-J","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","0","Trace out a 'J' midair with your pinky using a rotation of your wrist.","TRUE","ShadeAxas"},
new string[]{"J (Variant 2)","ASL-J (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","1","Indicate your pinky is out, then trace out a 'J' midair with your pinky using a rotation of your wrist.","TRUE","ShadeAxas"},
new string[]{"K","ASL-K","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","0","","TRUE","ShadeAxas"},
new string[]{"K (Variant 2)","ASL-K (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"L","ASL-L","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"M","ASL-M","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","2","The finger is supposed to indicate that the thumb is between the pinky at the rest of the fingers.","TRUE","ShadeAxas"},
new string[]{"M (Variant 2)","ASL-M (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"N","ASL-N","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","2","The finger is supposed to indicate that the thumb is between the ring and middle finger.","TRUE","ShadeAxas"},
new string[]{"N (Variant 2)","ASL-N (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"O","ASL-O","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"P","ASL-P","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Q","ASL-Q","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"R","ASL-R","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"S","ASL-S","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"T","ASL-T","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"U","ASL-U","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","0","","TRUE","ShadeAxas"},
new string[]{"U (Variant 2)","ASL-U (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","1","The 'Peace Sign' on Regular VR looks like a V, so emphasize a U shape by moving it in the shape of a U.","TRUE","ShadeAxas"},
new string[]{"V","ASL-V","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","0","The 'Peace Sign' on the Index looks like a U, so emphasize a V shape by moving it in the shape of a V.","TRUE","ShadeAxas"},
new string[]{"V (Variant 2)","ASL-V (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","1","","TRUE","ShadeAxas"},
new string[]{"W","ASL-W","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","0","","TRUE","ShadeAxas"},
new string[]{"W (Variant 2)","ASL-W (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"X","ASL-X","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","0","","TRUE","ShadeAxas"},
new string[]{"X (Variant 2)","ASL-X (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Y","ASL-Y","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Y (Variant 2)","ASL-Y (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","1","","TRUE","ShadeAxas"},
new string[]{"Z","ASL-Z","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Comma","ASL-Comma","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Space","ASL-Space","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4","0","To indicate a space between fingerspelled words, you simply insert a very small pause between letters.","FALSE",""},
new string[]{"@","ASL-@","Anonymous","","2","Use for the symbol @, like in an email address.","TRUE","ShadeAxas"},
new string[]{"Number","ASL-Number","Anonymous","","2","Pinch fingers together","FALSE",""},
new string[]{"0","ASL-0","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4","0","","TRUE","ShadeAxas"},
new string[]{"1","ASL-1","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4","0","","TRUE","ShadeAxas"},
new string[]{"2","ASL-2","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4","0","","TRUE","ShadeAxas"},
new string[]{"3","ASL-3","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4","0","","TRUE","ShadeAxas"},
new string[]{"4","ASL-4","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4","0","","TRUE","ShadeAxas"},
new string[]{"5","ASL-5","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4","0","","TRUE","ShadeAxas"},
new string[]{"6","ASL-6","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4","0","","TRUE","ShadeAxas"},
new string[]{"7","ASL-7","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4","0","","TRUE","ShadeAxas"},
new string[]{"8","ASL-8","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4","0","","TRUE","ShadeAxas"},
new string[]{"9","ASL-9","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4","0","","TRUE","ShadeAxas"},
new string[]{"10","ASL-10","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4","0","","TRUE","ShadeAxas"},
new string[]{"100","ASL-100","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4","0","","TRUE","ShadeAxas"},
new string[]{"1000","ASL-1000","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4","0","","TRUE","ShadeAxas"},
new string[]{"1000000","ASL-1000000","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4","0","}","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 10 (Verbs & Actions p1)
new string[]{"Overlook","ASL-Overlook","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Punish","ASL-Punish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Edit","ASL-Edit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4","2","","FALSE",""},
new string[]{"Erase","ASL-Erase","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Write","ASL-Write","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Proposal","ASL-Proposal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Add","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4","2","","FALSE",""},
new string[]{"Increase","ASL-Increase","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Remove","ASL-Remove","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Agree","ASL-Agree","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4","2","","FALSE",""},
new string[]{"Disagree","ASL-Disagree","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Admit","ASL-Admit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Allow","ASL-Allow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Attack","ASL-Attack","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fight","ASL-Fight","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Defend","ASL-Defend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4","2","","FALSE",""},
new string[]{"Defeat (Overcome)","ASL-Defeat (Overcome)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Win","ASL-Win","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lose","ASL-Lose","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Draw / Tie (Game)","ASL-Draw / Tie (Game)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4","2","Draw or Tie, as in the same score at the end of a game.","TRUE","ShadeAxas"},
new string[]{"Give Up","ASL-Give Up","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Skip","ASL-Skip","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Ask","ASL-Ask","Anonymous","","0","Less formal version of request.//video shows request","TRUE","ShadeAxas"},
new string[]{"Attach","ASL-Attach","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Assistant","ASL-Assistant","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4","2","","FALSE",""},
new string[]{"Assist / Help","ASL-Assist / Help","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Bait","ASL-Bait","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4","2","","FALSE",""},
new string[]{"Battle","ASL-Battle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Beat (Overcome)","ASL-Beat (Overcome)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Become","ASL-Become","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Beg","ASL-Beg","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Begin / Start","ASL-Begin / Start","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4","2","","FALSE",""},
new string[]{"Behave","ASL-Behave","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Believe","ASL-Believe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Blame","ASL-Blame","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Blow","ASL-Blow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Blush","ASL-Blush","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bother / Harass","ASL-Bother / Harass","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4","2","This is a directional sign. When the sign is repeated, it means someone is actively and continuously interrupting or disturbing someone.}","FALSE",""},
},
new string[][]{//Lesson 11 (Verbs & Actions p2)
new string[]{"Bend","ASL-Bend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bow","ASL-Bow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Break","ASL-Break","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Breathe","ASL-Breathe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bring","ASL-Bring","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4","2","This is a directional sign.","FALSE",""},
new string[]{"Build / Construct","ASL-Build / Construct","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bully","ASL-Bully","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4","0","","FALSE",""},
new string[]{"Burn","ASL-Burn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Buy","ASL-Buy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Call","ASL-Call","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4","0","This is a directional sign.","TRUE","ShadeAxas"},
new string[]{"Cancel","ASL-Cancel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Care","ASL-Care","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Carry","ASL-Carry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Catch","ASL-Catch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cause","ASL-Cause","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Challenge","ASL-Challenge","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Chance","ASL-Chance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4","2","C' handshape. This sign is the Signed Exact English variant.","TRUE","ShadeAxas"},
new string[]{"Cheat","ASL-Cheat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4","2","","FALSE",""},
new string[]{"Check","ASL-Check","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Choose","ASL-Choose","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Claim","ASL-Claim","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Clean","ASL-Clean","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Clear","ASL-Clear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4","2","","FALSE",""},
new string[]{"Close","ASL-Close","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4","2","Close as in 'near'","FALSE",""},
new string[]{"Comfort","ASL-Comfort","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Command","ASL-Command","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Communicate","ASL-Communicate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4","2","This sign is the Signed Exact English variant.","FALSE",""},
new string[]{"Compare","ASL-Compare","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Complain","ASL-Complain","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Compliment","ASL-Compliment","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Concentrate","ASL-Concentrate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Construct / Build","ASL-Construct / Build","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Control","ASL-Control","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cook","ASL-Cook","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Copy","ASL-Copy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Correct","ASL-Correct","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4","2","}","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 12 (Verbs & Actions p3)
new string[]{"Cough","ASL-Cough","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Count","ASL-Count","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Create / Make","ASL-Create","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cuddle","ASL-Cuddle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cut","ASL-Cut","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dab","ASL-Dab","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dance","ASL-Dance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dare","ASL-Dare","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4","2","","FALSE",""},
new string[]{"Date","ASL-Date","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Deal","ASL-Deal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Deliver","ASL-Deliver","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Depend","ASL-Depend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4","2","","FALSE",""},
new string[]{"Describe","ASL-Describe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Dirty","ASL-Dirty","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Disappear","ASL-Disappear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Disappoint","ASL-Disappoint","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4","2","","FALSE",""},
new string[]{"Disapprove","ASL-Disapprove","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Discuss","ASL-Discuss","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Disguise","ASL-Disguise","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Disgust","ASL-Disgust","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dismiss","ASL-Dismiss","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Don't Disturb","ASL-Don't Disturb","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4","2","Wardragon signs an example of usage here.","TRUE","ShadeAxas"},
new string[]{"Doubt","ASL-Doubt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dream","ASL-Dream","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dress","ASL-Dress","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Drunk","ASL-Drunk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4","2","","FALSE",""},
new string[]{"Drop","ASL-Drop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Drown","ASL-Drown","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dry","ASL-Dry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dump","ASL-Dump","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dust","ASL-Dust","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4","2","","FALSE",""},
new string[]{"Earn","ASL-Earn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Effect","ASL-Effect","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"End","ASL-End","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Escape","ASL-Escape","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Escort","ASL-Escort","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4","2","}","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 13 (Verbs & Actions p4)
new string[]{"Excuse","ASL-Excuse","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Expose","ASL-Expose","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Exist","ASL-Alive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4","2","Same sign as alive//same sign as alive","TRUE","ShadeAxas"},
new string[]{"Fail","ASL-Fail","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Faint","ASL-Faint","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4","2","","FALSE",""},
new string[]{"Fake","ASL-Fake","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fart","ASL-Fart","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4","2","","FALSE",""},
new string[]{"Fear","ASL-Fear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4","2","","FALSE",""},
new string[]{"Fill","ASL-Fill","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Find","ASL-Find","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Finish","ASL-Finish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fix","ASL-Fix","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Flip","ASL-Flip","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Flirt","ASL-Flirt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Fly","ASL-Fly","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4","2","This is for winged creatures. Not for the act of flying on an airplane","TRUE","ShadeAxas"},
new string[]{"Forbid","ASL-Forbid","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Forgive","ASL-Forgive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Gain","ASL-Gain","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4","2","","FALSE",""},
new string[]{"Give","ASL-Give","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Glow","ASL-Glow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4","2","","FALSE",""},
new string[]{"Grab","ASL-Grab","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Grow","ASL-Grow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4","2","","FALSE",""},
new string[]{"Guard","ASL-Guard","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Guess","ASL-Guess","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Guide","ASL-Guide","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Harass / Bother","ASL-Harass / Bother","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Harm","ASL-Harm","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hit","ASL-Hit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4","2","","FALSE",""},
new string[]{"Hold","ASL-Hold","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hop","ASL-Hop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hope","ASL-Hope","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hunt","ASL-Hunt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Ignore","ASL-Ignore","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Imagine","ASL-Imagine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Imitate","ASL-Imitate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4","2","","FALSE",""},
new string[]{"Insult","ASL-Insult","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4","2","}","FALSE",""},
},
new string[][]{//Lesson 14 (Verbs & Actions p5)
new string[]{"Interact","ASL-Interact","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Interfere","ASL-Interfere","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4","2","","FALSE",""},
new string[]{"Judge","ASL-Judge","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Jump","ASL-Jump","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Justify","ASL-Justify","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Just Kidding","ASL-Just Kidding","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Keep","ASL-Keep","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Kick","ASL-Kick","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Kill","ASL-Kill","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Knock","ASL-Knock","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lead","ASL-Lead","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lick","ASL-Lick","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lock","ASL-Lock","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Manipulate","ASL-Manipulate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Melt","ASL-Melt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mess","ASL-Mess","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Miss","ASL-Miss","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mistake","ASL-Mistake","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mount","ASL-Mount","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4","2","","FALSE",""},
new string[]{"Move","ASL-Move","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Murder","ASL-Murder","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Nod","ASL-Nod","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Note","ASL-Note","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4","2","","FALSE",""},
new string[]{"Notice","ASL-Notice","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Obey","ASL-Obey","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4","2","","FALSE",""},
new string[]{"Obsess","ASL-Obsess","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Obtain","ASL-Obtain","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Occupy","ASL-Occupy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Offend","ASL-Offend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4","2","","FALSE",""},
new string[]{"Offer","ASL-Offer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Okay","ASL-Okay","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4","2","","FALSE",""},
new string[]{"Open","ASL-Open","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Order","ASL-Order","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Owe","ASL-Owe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Own","ASL-Own","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pass","ASL-Pass","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4","2","}","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 15 (Verbs & Actions p6)
new string[]{"Pat","ASL-Pat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Party","ASL-Party","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Pet","ASL-Pet","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pick","ASL-Pick","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Plug","ASL-Plug","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Point","ASL-Point","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Poke","ASL-Poke","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pray","ASL-Pray","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Prepare","ASL-Prepare","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4","2","","FALSE",""},
new string[]{"Present","ASL-Present","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4","0","As in a gift/donation.","TRUE","ShadeAxas"},
new string[]{"Pretend","ASL-Pretend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Protect","ASL-Protect","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Prove","ASL-Prove","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Publish","ASL-Publish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Puke","ASL-Puke","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Puke (Variant 2)","ASL-Puke (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pull","ASL-Pull","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Punch","ASL-Punch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Put","ASL-Put","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Push","ASL-Push","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Question","ASL-Question","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Questions","ASL-Questions","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Quit","ASL-Quit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Quote","ASL-Quote","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Race","ASL-Race","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"React","ASL-React","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4","2","","FALSE",""},
new string[]{"Recommended","ASL-Recommended","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Refuse","ASL-Refuse","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Regret","ASL-Regret","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Remember","ASL-Remember","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Replace","ASL-Replace","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Report","ASL-Report","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Reset","ASL-Reset","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Ride","ASL-Ride","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Rub","ASL-Rub","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Rule","ASL-Rule","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4","2","","FALSE",""},
new string[]{"Run","ASL-Run","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Save","ASL-Save","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4","2","}","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 16 (Verbs & Actions p7)
new string[]{"Say","ASL-Say","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Search","ASL-Search","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"See","ASL-See","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Share","ASL-Share","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Shock","ASL-Shock","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4","2","","FALSE",""},
new string[]{"Shop (Store)","ASL-Shop (Store)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4","2","","FALSE",""},
new string[]{"Show","ASL-Show","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4","2","This is a directional sign.","TRUE","ShadeAxas"},
new string[]{"Shut Up","ASL-Shut Up","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4","2","IRL: Starts with a V hand and transitions to an U hand.","FALSE",""},
new string[]{"Shut Down","ASL-Shut Down","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4","2","","FALSE",""},
new string[]{"Sing","ASL-Sing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sit","ASL-Sit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Smell","ASL-Smell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Smile","ASL-Smile","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Smoke (Airborn)","ASL-Smoke (Airborn)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4","2","This does not refer to smoking, but rather smoke in the air.","TRUE","ShadeAxas"},
new string[]{"Speak / Talk","ASL-Speak / Talk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Spell / Fingerspell","ASL-Spell / Fingerspell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Spit","ASL-Spit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Stand","ASL-Stand","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Start","ASL-Start","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Stay","ASL-Stay","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Steal","ASL-Steal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4","0","","FALSE",""},
new string[]{"Stop","ASL-Stop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Study","ASL-Study","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Suffer","ASL-Suffer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Swim","ASL-Swim","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Switch","ASL-Switch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Take (From)","ASL-Take (From)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4","2","Take as in physically taking candy from a baby. Contrast with Take (Up) as in taking ASL class.","TRUE","ShadeAxas"},
new string[]{"Communicate","ASL-Communicate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4","2","","FALSE",""},
new string[]{"Tell","ASL-Tell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Test","ASL-Test","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Text","ASL-Text","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Think","ASL-Think","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Throw","ASL-Throw","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Tie","ASL-Tie","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Truth","ASL-Truth","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Try","ASL-Try","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 17 (Verbs & Actions p8)
new string[]{"Type","ASL-Type","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-01.mp4","1","","TRUE","ShadeAxas"},
new string[]{"Turn","ASL-Turn","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Upset","ASL-Upset","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Use","ASL-Use","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"View","ASL-View","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-05.mp4","2","View as in point of view.","FALSE",""},
new string[]{"Vomit","ASL-Vomit","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Wait","ASL-Wait","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-07.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Wake Up","ASL-Wake Up","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"War","ASL-War","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Warn","ASL-Warn","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-10.mp4","2","Slap back of hand twice.","TRUE","ShadeAxas"},
new string[]{"Waste","ASL-Waste","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Wash","ASL-Wash","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-12.mp4","2","","FALSE",""},
new string[]{"Watch","ASL-Watch","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Wear","ASL-Wear","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Wobble","ASL-Wobble","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Wonder","ASL-Wonder","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Worry","ASL-Worry","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Work","ASL-Work","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hug","ASL-Hug","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Touch","ASL-Touch","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-20.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Kiss","ASL-Kiss","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Trust","ASL-Trust","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-22.mp4","2","","FALSE",""},
new string[]{"True","ASL-True","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lie","ASL-Lie","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Serve","ASL-Serve","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Calculate","ASL-Calculate","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-26.mp4","0","","TRUE","ShadeAxas"},
new string[]{"Shower","ASL-Shower","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bathe","ASL-Bathe","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Socialize","ASL-Socialize","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-29.mp4","2","","FALSE",""},
new string[]{"Help / Assist","ASL-Help / Assist","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Support","ASL-Support","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Take Care","ASL-Take Care","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-32.mp4","2","","FALSE",""},
new string[]{"Drive","ASL-Drive","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Travel","ASL-Travel","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Trip","ASL-Trip","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fiction","ASL-Fiction","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-36.mp4","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 18 (Food)
new string[]{"Corn","ASL-Corn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Vegetable","ASL-Vegetable","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cookie","ASL-Cookie","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cake","ASL-Cake","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-04.mp4","2","","FALSE",""},
new string[]{"Yogurt","ASL-Yogurt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Lemon","ASL-Lemon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Nuts","ASL-Nuts","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-07.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Grapes","ASL-Grapes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-08.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Peas","ASL-Peas","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Icecream","ASL-Icecream","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pear","ASL-Pear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-11.mp4","2","","FALSE",""},
new string[]{"Butter","ASL-Butter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-12.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Banana","ASL-Banana","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pumpkin","ASL-Pumpkin","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fruit","ASL-Fruit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Apple","ASL-Apple","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Tomato","ASL-Tomato","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Orange (Fruit)","ASL-Orange (Fruit)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-18.mp4","2","","FALSE",""},
new string[]{"Bread","ASL-Bread","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cheese","ASL-Cheese","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Water","ASL-Water","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hamburger","ASL-Hamburger","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Hot Dog","ASL-Hot Dog","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sandwich","ASL-Sandwich","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Taco","ASL-Taco","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-25.mp4","2","","FALSE",""},
new string[]{"Noodles","ASL-Noodles","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Eggs","ASL-Eggs","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Salt","ASL-Salt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Meat","ASL-Meat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Carrot","ASL-Carrot","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cabbage","ASL-Cabbage","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Spaghetti","ASL-Spaghetti","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pizza","ASL-Pizza","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-33.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sushi","ASL-Sushi","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Potato","ASL-Potato","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Juice","ASL-Juice","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-36.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cola","ASL-Cola","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-37.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Beer","ASL-Beer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-38.mp4","2","","FALSE",""},
new string[]{"Wine","ASL-Wine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-39.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Champagne","ASL-Champagne","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-40.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Milk","ASL-Milk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-41.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sugar","ASL-Sugar","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet18/18-42.mp4","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 19 (Animals / Machines)
new string[]{"Dog","ASL-Dog","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-01.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cat","ASL-Cat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-02.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fox","ASL-Fox","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-03.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cow","ASL-Cow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-04.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Sheep","ASL-Sheep","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-05.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Duck","ASL-Duck","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-06.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Turkey (Bird)","ASL-Turkey (Bird)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-07.mp4","2","The food, not the country.","TRUE","ShadeAxas"},
new string[]{"Fly (Insect)","ASL-Fly (Insect)","Anonymous","","2","","FALSE",""},
new string[]{"Chicken","ASL-Chicken","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-08.mp4","2","","FALSE",""},
new string[]{"Owl","ASL-Owl","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-09.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bird","ASL-Bird","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-10.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Mouse","ASL-Mouse","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-11.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bear","ASL-Bear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-12.mp4","2","","FALSE",""},
new string[]{"Lion","ASL-Lion","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-13.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cricket","ASL-Cricket","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-14.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Dragon","ASL-Dragon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-15.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Rabbit","ASL-Rabbit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-16.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Turtle","ASL-Turtle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-17.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Pig","ASL-Pig","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-18.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Squirrel","ASL-Squirrel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-19.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Raccoon","ASL-Raccoon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-20.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Fish","ASL-Fish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-21.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Rocket","ASL-Rocket","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-22.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Generator","ASL-Generator","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-23.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Car","ASL-Car","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-24.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Truck","ASL-Truck","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-25.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bike","ASL-Bike","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-26.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Motorcycle","ASL-Motorcycle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-27.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Train","ASL-Train","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-28.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Robot","ASL-Robot","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-29.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Spaceship","ASL-Spaceship","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-30.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Aircraft","ASL-Aircraft","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-31.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Helicopter","ASL-Helicopter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-32.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bus","ASL-Bus","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-33.mp4","2","","FALSE",""},
new string[]{"Ship","ASL-Ship","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-34.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Bulldozer","ASL-Bulldozer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-35.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Crane","ASL-Crane","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-36.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Machine","ASL-Machine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-37.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Drilling Machine","ASL-Drilling Machine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-38.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Elevator","ASL-Elevator","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-39.mp4","2","","TRUE","ShadeAxas"},
new string[]{"Cyborg","ASL-Cyborg","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-40.mp4","2","","FALSE",""},
new string[]{"Tank","ASL-Tank","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-41.mp4","2","","FALSE",""},
new string[]{"Submarine","ASL-Submarine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet19/19-42.mp4","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 20 (Places)
new string[]{"Bathroom","ASL-Bathroom","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Room","ASL-Room","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"City","ASL-City","Anonymous","","2","","FALSE",""},
new string[]{"House","ASL-House","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Skyscraper","ASL-Skyscraper","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Apartment","ASL-Apartment","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Tower","ASL-Tower","Anonymous","","2","","FALSE",""},
new string[]{"Village","ASL-Village","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sewer","ASL-Sewer","Anonymous","","2","","FALSE",""},
new string[]{"Cellar","ASL-Cellar","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Storage","ASL-Storage","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pool","ASL-Pool","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sea","ASL-Sea","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Island","ASL-Island","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sun","ASL-Sun","Anonymous","","2","","FALSE",""},
new string[]{"Moon","ASL-Moon","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sky","ASL-Sky","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Outer Space","ASL-Outer Space","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Milky Way","ASL-Milky Way","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Heaven","ASL-Heaven","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hell","ASL-Hell","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Graveyard","ASL-Graveyard","Anonymous","","2","","FALSE",""},
new string[]{"Garden","ASL-Garden","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Beach","ASL-Beach","Anonymous","","2","","FALSE",""},
new string[]{"Coast","ASL-Coast","Anonymous","","2","","FALSE",""},
new string[]{"Sea","ASL-Sea","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Garbage Dump","ASL-Garbage Dump","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Castle","ASL-Castle","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Cathedral","ASL-Cathedral","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Church","ASL-Church","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Store","ASL-Store","Anonymous","","2","","FALSE",""},
new string[]{"Butchery","ASL-Butchery","Anonymous","","2","","FALSE",""},
new string[]{"Prison","ASL-Prison","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Police Station","ASL-Police Station","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hospital","ASL-Hospital","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Firestation","ASL-Firestation","Anonymous","","2","","FALSE",""},
new string[]{"Hotel","ASL-Hotel","Anonymous","","2","","FALSE",""},
new string[]{"Airport","ASL-Airport","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Harbor","ASL-Harbor","Anonymous","","2","","FALSE",""},
new string[]{"Road","ASL-Road","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Crossing","ASL-Crossing","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Railway","ASL-Railway","Anonymous","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 21 (Stuff / Weather)
new string[]{"Wood","ASL-Wood","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Metal","ASL-Metal","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Glass","ASL-Glass","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Liquid","ASL-Liquid","Anonymous","","2","","FALSE",""},
//new string[]{"Electricity","ASL-Electricity","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Powder","ASL-Powder","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Feather","ASL-Feather","Anonymous","","2","","FALSE",""},
new string[]{"Box","ASL-Box","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Container","ASL-Container","Anonymous","","2","","FALSE",""},
new string[]{"Paper","ASL-Paper","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pencil","ASL-Pencil","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Eraser","ASL-Eraser","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Book","ASL-Book","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Ruler","ASL-Ruler","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hammer","ASL-Hammer","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Saw","ASL-Saw","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sander","ASL-Sander","Anonymous","","2","","FALSE",""},
new string[]{"Scissors","ASL-Scissors","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pincer","ASL-Pincer","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Stick","ASL-Stick","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Rake","ASL-Rake","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Shovel","ASL-Shovel","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Axe","ASL-Axe","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hook","ASL-Hook","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Chain","ASL-Chain","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Storm","ASL-Storm","Anonymous","","2","","FALSE",""},
new string[]{"Hurricane","ASL-Hurricane","Anonymous","","2","","FALSE",""},
new string[]{"Earthquake","ASL-Earthquake","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Dark","ASL-Dark","Anonymous","","2","","FALSE",""},
new string[]{"Light","ASL-Light","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Clouds","ASL-Clouds","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Fire","ASL-Fire","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Ice","ASL-Ice","Anonymous","","2","","FALSE",""},
new string[]{"Rain","ASL-Rain","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Flood","ASL-Flood","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Smoke (Airborn)","ASL-Smoke (Airborn)","Anonymous","","2","Not referring to smoking a cigar.","TRUE","ShadeAxas"},
new string[]{"Fog","ASL-Fog","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Snow","ASL-Snow","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Freeze","ASL-Freeze","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hot","ASL-Hot","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Humidity","ASL-Humidity","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Lightning","ASL-Lightning","Anonymous","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 22 (Clothes / Equipment)
new string[]{"Dress","ASL-Dress","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pants","ASL-Pants","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Jeans","ASL-Jeans","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Shorts","ASL-Shorts","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Swimming Trunks","ASL-Swimming Trunks","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Bikini","ASL-Bikini","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Miniskirt","ASL-Miniskirt","Anonymous","","2","","FALSE",""},
new string[]{"Underwear","ASL-Underwear","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Bra","ASL-Bra","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Diapers","ASL-Diapers","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Shirt","ASL-Shirt","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sweater","ASL-Sweater","Anonymous","","2","","FALSE",""},
new string[]{"Hat","ASL-Hat","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"High Heels","ASL-High Heels","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Scarf","ASL-Scarf","Anonymous","","2","","FALSE",""},
new string[]{"Raincoat","ASL-Raincoat","Anonymous","","0","","FALSE",""},
new string[]{"Jacket","ASL-Jacket","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Umbrella","ASL-Umbrella","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Gloves","ASL-Gloves","Anonymous","","2","","FALSE",""},
new string[]{"Uniform","ASL-Uniform","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Overalls","ASL-Overalls","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Mask","ASL-Mask","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Cap","ASL-Cap","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Glasses","ASL-Glasses","Anonymous","","2","","FALSE",""},
new string[]{"Goggles","ASL-Goggles","Anonymous","","2","","FALSE",""},
new string[]{"Helmet","ASL-Helmet","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Socks","ASL-Socks","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Shoes","ASL-Shoes","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Boots","ASL-Boots","Anonymous","","2","","FALSE",""},
new string[]{"Sandals","ASL-Sandals","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Backpack","ASL-Backpack","Anonymous","","2","","FALSE",""},
new string[]{"Bag","ASL-Bag","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Suitcase","ASL-Suitcase","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Belt","ASL-Belt","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sportswear","ASL-Sportswear","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Jumpsuit","ASL-Jumpsuit","Anonymous","","2","","FALSE",""},
new string[]{"Jewelry","ASL-Jewelry","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Ring","ASL-Ring","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Bracelet","ASL-Bracelet","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Badge","ASL-Badge","Anonymous","","0","","TRUE","ShadeAxas"},
new string[]{"Necklace","ASL-Necklace","Anonymous","","2","","FALSE",""},
new string[]{"Earring","ASL-Earring","Anonymous","","0","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 23 (Fantasy / Characters)
new string[]{"Sword","ASL-Sword","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Shield","ASL-Shield","Anonymous","","2","","TRUE","ShadeAxas"},
//new string[]{"Weapon","ASL-Weapon","Anonymous","","2","","FALSE",""},
new string[]{"Cannon","ASL-Cannon","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Stick","ASL-Stick","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Magic","ASL-Magic","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Money","ASL-Money","Anonymous","","2","","FALSE",""},
new string[]{"Ghost","ASL-Ghost","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Zombie","ASL-Zombie","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"//Undead","ASL-Undead","Anonymous","","2","","FALSE",""},
new string[]{"Soldier","ASL-Soldier","Anonymous","","2","","FALSE",""},
new string[]{"Police","ASL-Police","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Nurse","ASL-Nurse","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Fireman","ASL-Fireman","Anonymous","","2","","FALSE",""},
new string[]{"Wizard","ASL-Wizard","Anonymous","","2","","FALSE",""},
new string[]{"Sorcerer","ASL-Sorcerer","Anonymous","","2","","FALSE",""},
new string[]{"Hunter","ASL-Hunter","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Male","ASL-Male","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Female","ASL-Female","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Human","ASL-Human","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Dwarf","ASL-Dwarf","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Elf","ASL-Elf","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Orc","ASL-Orc","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Tauren","ASL-Tauren","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Monster","ASL-Monster","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Gnome","ASL-Gnome","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Troll","ASL-Troll","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Health","ASL-Health","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Mana","ASL-Mana","Anonymous","","2","","FALSE",""},
new string[]{"Energy","ASL-Energy","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Power","ASL-Power","Anonymous","","2","","FALSE",""},
new string[]{"Armor","ASL-Armor","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Resistance","ASL-Resistance","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Resurrect","ASL-Resurrect","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Rage","ASL-Rage","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Casting","ASL-Casting","Anonymous","","2","","FALSE",""},
new string[]{"Shooting","ASL-Shooting","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Damage","ASL-Damage","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Healing","ASL-Healing","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Melee","ASL-Melee","Anonymous","","2","","FALSE",""},
new string[]{"Ammo","ASL-Ammo","Anonymous","","2","","FALSE",""},
new string[]{"Ranged","ASL-Ranged","Anonymous","","2","","FALSE",""},
},
new string[][]{//Lesson 24 (Holidays / Special Days)
new string[]{"Holiday","ASL-Holiday","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pentecost","ASL-Pentecost","Anonymous","","2","","FALSE",""},
new string[]{"Christmas","ASL-Christmas","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Easter","ASL-Easter","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"New Year's Day","ASL-New Year's Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"New Year's Eve","ASL-New Year's Eve","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Ascension Day","ASL-Ascension Day","Anonymous","","2","","FALSE",""},
new string[]{"Labor Day","ASL-Labor Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Columbus Day","ASL-Columbus Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Veterans Day","ASL-Veterans Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Thanksgiving Day","ASL-Thanksgiving Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Memorial Day","ASL-Memorial Day","Anonymous","","2","","FALSE",""},
new string[]{"Martin Luther King Jr. Day","ASL-Martin Luther King Jr Day","Anonymous","","2","","FALSE",""},
new string[]{"Presidents' Day","ASL-Presidents' Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"St. Andrew's Day","ASL-St Andrew's Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"St. David's Day","ASL-St David's Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Father's Day","ASL-Father's Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Mother's Day","ASL-Mother's Day","Anonymous","","2","","FALSE",""},
new string[]{"Independence Day","ASL-Independence Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"National Day","ASL-National Day","Anonymous","","2","","FALSE",""},
new string[]{"Valentine's Day","ASL-Valentine's Day","Anonymous","","2","","FALSE",""},
new string[]{"White Day","ASL-White Day","Anonymous","","2","","FALSE",""},
new string[]{"Black Friday","ASL-Black Friday","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Cyber Monday","ASL-Cyber Monday","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Golden Week","ASL-Golden Week","Anonymous","","2","","FALSE",""},
new string[]{"Doll's Festival (Hina Matsuri)","ASL-Doll's Festival (Hina Matsuri)","Anonymous","","2","JSL Sign","FALSE",""},
new string[]{"Coming of Age Day","ASL-Coming of Age Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Culture Day","ASL-Culture Day","Anonymous","","2","","FALSE",""},
new string[]{"Children's Day","ASL-Children's Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Seollal Holiday","ASL-Seollal Holiday","Anonymous","","2","KSL sign","FALSE",""},
new string[]{"Chinese New Year","ASL-Chinese New Year","Anonymous","","2","","FALSE",""},
new string[]{"Groundhog Day","ASL-Groundhog Day","Anonymous","","2","","FALSE",""},
new string[]{"Carnival","ASL-Carnival","Anonymous","","2","","FALSE",""},
new string[]{"Halloween","ASL-Halloween","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"St. Patrick's Day","ASL-St Patrick's Day","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Parent's Day","ASL-Parent's Day","Anonymous","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 25 (Home stuff)
new string[]{"Chair","ASL-Chair","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Bench","ASL-Bench","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Couch","ASL-Couch","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Table","ASL-Table","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Desktop Computer","ASL-Desktop Computer","GT4tube","","2","","FALSE",""},
new string[]{"Closet","ASL-Closet","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Toilet","ASL-Toilet","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Door","ASL-Door","GT4tube","","2","","FALSE",""},
new string[]{"Window","ASL-Window","GT4tube","","2","","TRUE","ShadeAxas"},
//new string[]{"Ceiling","Idle","No Data Yet.","","2","","",""},
new string[]{"Roof","ASL-Roof","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Floor / Carpet","ASL-Floor / Carpet","GT4tube","","2","","TRUE","ShadeAxas"},
//new string[]{"Rack","Idle","No Data Yet.","","2","","",""},
new string[]{"Safe","ASL-Safe","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Stairs","ASL-Stairs","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Television","ASL-Television","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Radio","ASL-Radio","GT4tube","","2","","TRUE","ShadeAxas"},
//new string[]{"Speakers","Idle","No Data Yet.","","2","","",""},
new string[]{"Microphone","ASL-Microphone","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Guitar","ASL-Guitar","GT4tube","","0","F-hand variant, like your holding a guitar pick.","TRUE","ShadeAxas"},
new string[]{"Guitar (Variant 2)","ASL-Guitar (Variant 2)","GT4tube","","2","Open-hand variant.","TRUE","ShadeAxas"},
new string[]{"Drum Kit","ASL-Drum Kit","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Headphones","ASL-Headphones","GT4tube","","2","Just mime the act of putting on headphones. The cupping motion is supposed to be where your ears are.","FALSE",""},
new string[]{"Headphones (Variant 2)","ASL-Headphones (Variant 2)","GT4tube","","2","","FALSE",""},
new string[]{"Washing Machine","ASL-Washing Machine","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Refrigerator","ASL-Refrigerator","GT4tube","","2","","FALSE",""},
//new string[]{"Dryer","Idle","No Data Yet.","","2","","",""},
new string[]{"Broom","ASL-Broom","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Sweeper","ASL-Sweeper","GT4tube","","2","","TRUE","ShadeAxas"},
//new string[]{"Vacuum Cleaner","Idle","No Data Yet.","","2","","",""},
//new string[]{"Sink","ASL-Sink","No Data Yet.","","2","","",""},
new string[]{"Dishwasher","ASL-Dishwasher","GT4tube","","2","","FALSE",""},
new string[]{"Cooking Pan","Idle","No Data Yet.","","2","","",""},
new string[]{"Oven","ASL-Oven","GT4tube","","2","","FALSE",""},
new string[]{"Fork","ASL-Fork","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Knife","ASL-Knife","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Spoon","ASL-Spoon","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Bowl","ASL-Bowl","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Plate","ASL-Plate","GT4tube","","2","","FALSE",""},
new string[]{"Wall Outlet","ASL-Wall Outlet","GT4tube","","2","","FALSE",""},
new string[]{"Bath","ASL-Bath","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Shower","ASL-Shower","GT4tube","","2","","TRUE","ShadeAxas"},
new string[]{"Fireplace","ASL-Fireplace","GT4tube","","0","","FALSE",""},
new string[]{"Fireplace (Variant 2)","ASL-Fireplace (Variant 2)","GT4tube","","2","General VR Variant","FALSE",""},
new string[]{"Air Conditioner","ASL-Air Conditioner","GT4tube","","2","","TRUE","ShadeAxas"},
//new string[]{"Parasol","Idle","No Data Yet.","","2","","",""},
},
new string[][]{//Lesson 26 (Nature / Environment)
new string[]{"Nature","ASL-Nature","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Environment","ASL-Environment","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Flower","ASL-Flower","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Grass","ASL-Grass","Anonymous","","2","","FALSE",""},
new string[]{"Tree","ASL-Tree","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sand","ASL-Sand","Anonymous","","2","","FALSE",""},
new string[]{"Soil","ASL-Soil","Anonymous","","2","","FALSE",""},
new string[]{"Waterfall","ASL-Waterfall","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hills","ASL-Hills","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Cave","ASL-Cave","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pine","ASL-Pine","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Oak","ASL-Oak","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sunflower","ASL-Sunflower","Anonymous","","2","","FALSE",""},
new string[]{"Bush","ASL-Bush","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Dam","ASL-Dam","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Bridge","ASL-Bridge","Anonymous","","2","","FALSE",""},
new string[]{"Ocean","ASL-Ocean","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Lake","ASL-Lake","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pond","ASL-Pond","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"River","ASL-River","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Rainbow","ASL-Rainbow","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Forest","ASL-Forest","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Wilderness","ASL-Wilderness","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Geology","ASL-Geology","Anonymous","","2","","FALSE",""},
new string[]{"Ecology","ASL-Ecology","Anonymous","","2","","FALSE",""},
new string[]{"Evolution","ASL-Evolution","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Matter","ASL-Matter","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Lava","ASL-Lava","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Structure","ASL-Structure","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Rocks","ASL-Rocks","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Atmosphere","ASL-Atmosphere","Anonymous","","2","","FALSE",""},
new string[]{"Climate","ASL-Climate","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Oxygen","ASL-Oxygen","Anonymous","","2","","FALSE",""},
//new string[]{"Hydrogen","ASL-Hydrogen","Anonymous","","2","","",""},
new string[]{"Water Vapor","ASL-Water Vapor","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Ecosystem","ASL-Ecosystem","Anonymous","","2","","FALSE",""},
new string[]{"Life","ASL-Life","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Biology","ASL-Biology","Anonymous","","2","","FALSE",""},
new string[]{"Organisms","ASL-Organisms","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Reproduction","ASL-Reproduction","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Growth","ASL-Growth","Anonymous","","2","","FALSE",""},
new string[]{"Microbes","ASL-Microbes","Anonymous","","2","","FALSE",""},
},
new string[][]{//Lesson 27 (Talk / Asking exercises)
new string[]{"Can you teach me?","ASL-Can you teach me?","Anonymous","","2","","FALSE",""},
new string[]{"Sorry, I don't understand.","ASL-Sorry, I don't understand","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I want to learn sign language.","ASL-I want to learn sign language","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"My name is...","ASL-My name is","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Please wait for it.","ASL-Please wait for it","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"My friend wants to join.","ASL-My friend wants to join","Anonymous","","2","","FALSE",""},
new string[]{"I want to play with you.","ASL-I want to play with you","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I'm slow at learning.","ASL-I'm slow at learning","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Can you sign again please?","ASL-Can you repeat it?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Shall we begin?","ASL-Shall we begin?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I'm busy streaming.","ASL-I'm busy streaming","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Please don't disturb me.","ASL-Please don't disturb me","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Can you stop that?","ASL-Can you stop that?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Please follow me.","ASL-Please follow me","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I want to change the world.","ASL-I want to change the world","Anonymous","","2","","FALSE",""},
new string[]{"Can you write it down?","ASL-Can you write it down?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Please don't speak.","ASL-Please don't speak","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I can't hear you.","ASL-I can't hear you","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"What are the rules?","ASL-What are the rules?","Anonymous","","2","","FALSE",""},
new string[]{"Can you explain that to me?","ASL-Can you explain that to me?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Can you help me?","ASL-Can you help me?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Please lead me.","ASL-Please lead me","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I have a good idea.","ASL-I have a good idea","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I'm not feeling good.","ASL-I'm not feeling good","Anonymous","","2","","FALSE",""},
new string[]{"How old are you?","ASL-How old are you?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Where are you from?","ASL-Where are you from?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"You want to become friends?","ASL-You want to become friends?","Anonymous","","2","","FALSE",""},
new string[]{"I'm going to sleep.","ASL-I'm going to sleep","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I have to work soon.","ASL-I have to work soon","Anonymous","","2","","FALSE",""},
new string[]{"What is your Discord?","ASL-What is your Discord?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Can we talk on Discord?","ASL-Can we talk on Discord?","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Check your Discord.","ASL-Check your Discord","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I'm lost here.","ASL-I'm lost here","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I'm going to my friend's.","ASL-I'm going to my friend's","Anonymous","","2","","FALSE",""},
//new string[]{"I have some free time now.","ASL-I have some free time now","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"I don't have much time.","ASL-I don't have much time","Anonymous","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 28 (Name sign users)
new string[]{"Sio","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-01.mp4","2","","FALSE",""},
new string[]{"MrDummy_NED","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-02.mp4","2","","FALSE",""},
new string[]{"Wardragon","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-03.mp4","2","","FALSE",""},
new string[]{"QQuentin","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-04.mp4","2","","FALSE",""},
new string[]{"Ray_is_deaf","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-05.mp4","2","","FALSE",""},
new string[]{"CTLucina","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-06.mp4","2","","FALSE",""},
new string[]{"Fazzion","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-07.mp4","2","","FALSE",""},
new string[]{"Jenny0629","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-08.mp4","2","","FALSE",""},
new string[]{"Wubbles","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-09.mp4","2","","FALSE",""},
new string[]{"Sqweekslj","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-10.mp4","2","","FALSE",""},
new string[]{"Freddex1337","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-11.mp4","2","","FALSE",""},
new string[]{"Max DEAF FR","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-12.mp4","2","","FALSE",""},
new string[]{"Korea_Saro","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-13.mp4","2","","FALSE",""},
new string[]{"_MINT_","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-14.mp4","2","","FALSE",""},
new string[]{"Divamage","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-15.mp4","2","","FALSE",""},
new string[]{"DeafDragon22","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-16.mp4","2","","FALSE",""},
new string[]{"Cha714_Deaf","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-17.mp4","2","","FALSE",""},
new string[]{"AlexDeafHero","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-18.mp4","2","","FALSE",""},
new string[]{"Papa Thelius","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-19.mp4","2","","FALSE",""},
new string[]{"DalekTheGamer","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-20.mp4","2","","FALSE",""},
new string[]{"Fearlesskoolaid","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-21.mp4","2","","FALSE",""},
new string[]{"Korea_Yujin","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-22.mp4","2","","FALSE",""},
new string[]{"Mute Raven","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-23.mp4","2","","FALSE",""},
new string[]{"Ailuro","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-24.mp4","2","","FALSE",""},
new string[]{"Robyn / QueenHidi","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-25.mp4","2","","FALSE",""},
new string[]{"CraftyHayley","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-26.mp4","2","","FALSE",""},
new string[]{"[ DEAF-2030 ]","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-27.mp4","2","","FALSE",""},
new string[]{"Catman2010","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-28.mp4","2","","FALSE",""},
new string[]{"Danyy59","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-29.mp4","2","","FALSE",""},
new string[]{"Darkers","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-30.mp4","2","","FALSE",""},
new string[]{"Yun Big Eater","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-31.mp4","2","","FALSE",""},
new string[]{"Deaf_Danielo_89","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-32.mp4","2","","FALSE",""},
new string[]{"UnrealPanda","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-33.mp4","2","","FALSE",""},
new string[]{"Mr_Voodoo","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-34.mp4","2","","FALSE",""},
new string[]{"GT4tube","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-35.mp4","2","","FALSE",""},
new string[]{"CathDeafGamer","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-36.mp4","2","","FALSE",""},
new string[]{"Angél","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-37.mp4","2","","FALSE",""},
new string[]{"RomainDEAF","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-38.mp4","2","","FALSE",""},
new string[]{"Peppers","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-39.mp4","2","","FALSE",""},
new string[]{"Taboot62","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-40.mp4","2","","FALSE",""},
new string[]{"Ja_Hyuni","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-41.mp4","2","","FALSE",""},
new string[]{"MrRikuG935","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-42.mp4","2","","FALSE",""},
new string[]{"Deany","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-43.mp4","2","","FALSE",""},
new string[]{"hppedeaf","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-44.mp4","2","","FALSE",""},
new string[]{"0kami SweetFang","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet28/28-45.mp4","2","","FALSE",""},
new string[]{"CrossVadar","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/crossvadar.mp4","2","","FALSE",""},
new string[]{"Roineru_FR","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/Roineru_FR.mp4","2","","FALSE",""},
new string[]{"HOH mikka","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/HOH_mikka_.mp4","2","","FALSE",""},
new string[]{"GMARISSTUFF","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/GMARISSTUFF.mp4","2","","FALSE",""},
new string[]{"COBALTMOON ☪","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/COBALTMOON.mp4","2","","FALSE",""},
new string[]{"THESONOFSAM","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/THESONOFSAM.mp4","2","","FALSE",""},
new string[]{"ReinaRei","Idle","No Data Yet.","https://vrchat.germany-sl.com/name-sign/reinarei2.mp4","2","","FALSE",""},
},
new string[][]{//Lesson 29 (Countries)
new string[]{"World","ASL-World","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Europe","ASL-Europe","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Asia","ASL-Asia","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Country","ASL-Country","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"North America","ASL-North America","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Central America","ASL-Central America","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"South America","ASL-South America","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"America / USA","ASL-America / USA","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Canada","ASL-Canada","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Mexico","ASL-Mexico","Anonymous","","2","","FALSE",""},
new string[]{"Spain","ASL-Spain","Anonymous","","2","","FALSE",""},
new string[]{"France","ASL-France","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"England","ASL-England","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Netherlands","ASL-Netherlands","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Germany","ASL-Germany","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Scandinavia","ASL-Scandinavia","Anonymous","","2","","FALSE",""},
new string[]{"Middle East","ASL-Middle East","Anonymous","","2","","FALSE",""},
new string[]{"Australia","ASL-Australia","Anonymous","","2","","FALSE",""},
new string[]{"Japan","ASL-Japan","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"China","ASL-China","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"South Korea","ASL-South Korea","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Russia","ASL-Russia","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"New Zealand","ASL-New Zealand","Anonymous","","2","","FALSE",""},
new string[]{"Brazil","ASL-Brazil","Anonymous","","2","","FALSE",""},
new string[]{"Poland","ASL-Poland","Anonymous","","2","","FALSE",""},
new string[]{"Turkey","ASL-Turkey","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Israel","ASL-Israel","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Egypt","ASL-Egypt","Anonymous","","2","","FALSE",""},
new string[]{"Africa","ASL-Africa","Anonymous","","2","","FALSE",""},
new string[]{"South Africa","ASL-South Africa","Anonymous","","2","","FALSE",""},
new string[]{"Norway","ASL-Norway","Anonymous","","2","","FALSE",""},
new string[]{"Sweden","ASL-Sweden","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Finland","ASL-Finland","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Austria","ASL-Austria","Anonymous","","2","","FALSE",""},
new string[]{"Italy","ASL-Italy","Anonymous","","2","","FALSE",""},
new string[]{"Portugal","ASL-Portugal","Anonymous","","2","","FALSE",""},
new string[]{"Romania","ASL-Romania","Anonymous","","2","","FALSE",""},
new string[]{"Saudi Arabia","ASL-Saudi Arabia","Anonymous","","2","","FALSE",""},
new string[]{"Ireland","ASL-Ireland","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Scotland","ASL-Scotland","Anonymous","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 30 (Colors)
new string[]{"Color","ASL-Color","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"White","ASL-White","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Black","ASL-Black","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Red","ASL-Red","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Blue","ASL-Blue","Anonymous","","2","","FALSE",""},
new string[]{"Green","ASL-Green","Anonymous","","2","","FALSE",""},
new string[]{"Brown","ASL-Brown","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pink","ASL-Pink","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Purple","ASL-Purple","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Yellow","ASL-Yellow","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Orange","ASL-Orange","Anonymous","","2","","FALSE",""},
new string[]{"Gold","ASL-Gold","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Silver","ASL-Silver","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Transparent","ASL-Transparent","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Gray","ASL-Gray","Anonymous","","2","","FALSE",""},
new string[]{"Light","ASL-Light","Anonymous","","2","","FALSE",""},
new string[]{"Dark","ASL-Dark","Anonymous","","2","","FALSE",""},
new string[]{"Light Blue","ASL-Light Blue","Anonymous","","2","","FALSE",""},
new string[]{"Dark Blue","ASL-Dark Blue","Anonymous","","2","","FALSE",""},
new string[]{"Tan","ASL-Tan","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Blond","ASL-Blond","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Gas","ASL-Gas","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Oil","ASL-Oil","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Glow","ASL-Glow","Anonymous","","2","","FALSE",""},
new string[]{"Wood","ASL-Wood","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Metal","ASL-Metal","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Aluminium","ASL-Aluminium","Anonymous","","2","","FALSE",""},
new string[]{"Fabric","ASL-Fabric","Anonymous","","2","","FALSE",""},
new string[]{"Glass","ASL-Glass","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Paper","ASL-Paper","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Plastic","ASL-Plastic","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Rubber","ASL-Rubber","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Foil","ASL-Foil","Anonymous","","2","","FALSE",""},
new string[]{"Clay","ASL-Clay","Anonymous","","2","","FALSE",""},
new string[]{"Water","ASL-Water","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Gel","ASL-Gel","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sticker","ASL-Sticker","Anonymous","","2","","FALSE",""},
new string[]{"Rope","ASL-Rope","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Wire","ASL-Wire","Anonymous","","2","","FALSE",""},
new string[]{"Cotton","ASL-Cotton","Anonymous","","2","","FALSE",""},
new string[]{"Air","ASL-Air","Anonymous","","2","","TRUE","ShadeAxas"},
},
new string[][]{//Lesson 31 (Medical)
new string[]{"Doctor","ASL-Doctor","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Nurse","ASL-Nurse","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hospital","ASL-Hospital","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Sick","ASL-Sick","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Hurt","ASL-Hurt","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Fever","ASL-Fever","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Diarrhea","ASL-Diarrhea","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Vomit","ASL-Vomit","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Healthy","ASL-Healthy","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Better","ASL-Better","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Recover","ASL-Recover","Anonymous","","2","","FALSE",""},
new string[]{"Pill","ASL-Pill","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Dead (Variant 2)","ASL-Dead (Variant 2)","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Brain","ASL-Brain","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Receipt","ASL-Receipt","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Headache","ASL-Headache","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Stomachache","ASL-Stomachache","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Pain","ASL-Pain","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Bone Fracture","ASL-Bone Fracture","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Wheelchair","ASL-Wheelchair","Anonymous","","2","","TRUE","ShadeAxas"},
//new string[]{"Stretcher","ASL-Stretcher","Anonymous","","2","","",""},
new string[]{"Dentist","ASL-Dentist","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Band Aid","ASL-Band Aid","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Bandage","ASL-Bandage","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Wound","ASL-Wound","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Blood","ASL-Blood","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Crutch","ASL-Crutch","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Eye","ASL-Eye","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Ears","ASL-Ears","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Nose","ASL-Nose","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Arm","ASL-Arm","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Legs","ASL-Legs","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Breast","ASL-Breast","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Belly","ASL-Belly","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Mouth","ASL-Mouth","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Finger","ASL-Finger","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Elbow","ASL-Elbow","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Knee","ASL-Knee","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Ankle","ASL-Ankle","Anonymous","","2","","FALSE",""},
new string[]{"Spine","ASL-Spine","Anonymous","","2","","FALSE",""},
new string[]{"Skeleton","ASL-Skeleton","Anonymous","","2","","TRUE","ShadeAxas"},
new string[]{"Skin","ASL-Skin","Anonymous","","2","","FALSE",""},
}
},//end of asl lessons
new string[][][]{//bsl lessons
new string[][]{//Daily Use (Signed by CathDeathGamer)
new string[]{"Hello","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/1_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"How are you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/2_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"What's up?","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/3_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Nice to meet you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/4_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Good","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/5_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Bad","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/6_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Yes","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/7_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"No","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/8_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"So-So","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/9_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Sick","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/10_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Hurt","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/11_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"You're welcome","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/12_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Good bye","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/13_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Good morning","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/14_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Good afternoon","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/15_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Good evening","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/16_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Good night","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/17_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"See you later","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/18_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Please","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/19_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Sorry","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/20_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Forgotten","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/21_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Sleep","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/22_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Bed","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/23_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Jump/Change world","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/24_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Thank you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/25_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"I love you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/26_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Go away","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/27_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Going to","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/28_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Follow","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/29_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Come","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/30_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Hearing","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/31_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Deaf","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/32_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Hard of Hearing","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/33_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Mute","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/34_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Write slow","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/35_cath.mp4","2","","TRUE","CathDeathGamer"},
new string[]{"Cannot read","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/36_cath.mp4","2","","TRUE","CathDeathGamer"},
},
new string[][]{//Daily Use (Signed by Sheezy)
new string[]{"Hello","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/1_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"How are you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/2_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"What's up?","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/3_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Nice to meet you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/4_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Good","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/5_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Bad","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/6_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Yes","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/7_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"No","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/8_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"So-So","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/9_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Sick","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/10_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Hurt","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/11_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"You're welcome","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/12_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Good bye","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/13_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Good morning","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/14_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Good afternoon","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/15_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Good evening","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/16_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Good night","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/17_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"See you later","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/18_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Please","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/19_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Sorry","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/20_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Forgotten","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/21_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Sleep","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/22_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Bed","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/23_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Jump/Change world","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/24_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Thank you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/25_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"I love you","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/26_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Go away","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/27_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Going to","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/28_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Follow","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/29_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Come","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/30_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Hearing","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/31_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Deaf","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/32_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Hard of Hearing","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/33_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Mute","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/34_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Write slow","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/35_sheezy.mp4","2","","TRUE","Sheezy"},
new string[]{"Cannot read","Idle","No Data Yet.","https://vrsl.withdevon.xyz/cdn/videos/BSL/1/36_sheezy.mp4","2","","TRUE","Sheezy"},
}//end of bsl
},//end bsl lang
new string[][][]{//dsg lessons
new string[][]{//Lesson 1(Daily Use)
new string[]{"Hello","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/hallo.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"How (are) You","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/wiegehts.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"What's Up?","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/Wasgehts.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Nice (to) Meet You","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/freuemich.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Good","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/gut.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Bad","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/schlecht.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Yes","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/ja.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"No","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/nein.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"So-So","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/so-so.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Sick","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/krank.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Hurt","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/verletzt.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"You're Welcome","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/bitte.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Goodbye","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Good Morning","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/gutenmorgen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Good Afternoon","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/gutennachmittag.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Good Evening","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/gutenabend.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Good Night","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/gutennacht.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"See You Later","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/bisspaeter.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Please","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/bitte.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Sorry","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/Estutunsleid.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Forget","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/vergessen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Sleep / Sleepy","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/schlaf.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Bed","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/schlaf.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Jump / Change World","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Thank You","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/vielendank.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"I Love You","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/ichliebedich.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"ILY (I Love You)","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/ILY.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Go Away","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Going To","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/ichgehtes.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Follow","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/folgen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Come","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/kommensie.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Hearing (Person)","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/hoerer.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Deaf","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/gehoerlos.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Hard of Hearing","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/Hoerbehinderte.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Mute","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/stumm.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Write Slow","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/SchreibenSielangsam.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Can't Read","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/Kannnichtlesen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Away","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson01/weg.mp4","2","","TRUE","deaf_danielo_89"},
},//end of dgs-lesson 1
new string[][]{//Lesson 2(Pointing use Question / Answer)
new string[]{"I (Me)","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/ich.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"My","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/mein.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Your","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/dein.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"His","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Her","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/sie-ihr.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"We","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wir.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"They","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/sie-ihr.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Their","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/sie-ihr.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Our","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"It's","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Inside","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/innerrhalb.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Outside","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/draufen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Hidden","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/versteckt.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Behind","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/hinter.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Above","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/ueber.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Below","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/unter.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Here","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/hier.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Beside","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/neben.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Back","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/zuruerck.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Front","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/vorderseite.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Who","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wer.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Where","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wo.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"When","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wann.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Why","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/warum1.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Why (Variant 2)","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/warum2.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Which","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"What","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/was.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"How","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wie.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"How Many","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wievielen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Can","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/kann.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Can't","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/nichtkann.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Want","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/wollen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Have","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/haben.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Get","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Will / Future","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/willen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Take (Up)","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/aufnahmen.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Need","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/brauch2.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Must","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/muss.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Not","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/nicht.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"Or","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/or.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"And","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/und.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"For","Idle","No Data Yet.","https://vrchat.germany-sl.com/Lesson02/fuer.mp4","2","","TRUE","deaf_danielo_89"},
new string[]{"At","Idle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","2","","TRUE","deaf_danielo_89"},
}//end of dgs-lesson 2
}
};


//GameObject [][][][] videos;

	string[][] lessonnames = { //can be unique per language, as long as they match the number of array
		new string[] { //ASL lesson names - can be unique per language.
			"Daily Use",
			"Pointing use Question / Answer",
			"Common",
			"People",
			"Feelings / Reactions",
			"Value",
			"Time",
			"VRChat",
			"Alphabet / Numbers (Fingerspelling)",
			"Verbs & Actions p1",
			"Verbs & Actions p2: Ben-Cor",
			"Verbs & Actions p3: Cou-Esc",
			"Verbs & Actions p4: Exc-Ins",
			"Verbs & Actions p5: Int-Pas",
			"Verbs & Actions p6: Pat-Sav",
			"Verbs & Actions p7: Say-Try",
			"Verbs & Actions p8",
			"Food",
			"Animals / Machines",
			"Places",
			"Stuff / Weather",
			"Clothes / Equipment",
			"Fantasy / Characters",
			"Holidays / Special Days",
			"Home stuff",
			"Nature / Environment",
			"Talk / Asking exercises (SEE)",
			"Name sign users",
			"Countries",
			"Colors",
			"Medical"
		},
		new string[] { //BSL lesson names
			"Daily Use (Signed by CathDeathGamer)",
			"Daily Use (Signed by Sheezy93)"
		},
		new string[] { //DGS lesson names
			"Daily Use",
			"Pointing use Question / Answer"
		},

	};
	string[][] signlanguagenames = {
		new string[] {
			"ASL",
			"American Sign Language"
		},
		new string[] {
			"BSL",
			"British Sign Language"
		},
		new string[] {
			"DGS",
			"German Sign Language (Deutsche Gebärdensprache)"
		},
		//new string[]{"DGS","Deutsche Gebärdensprache (German Sign Language)"}
	};
	public Animator nana;
	//public Animator nanapc;
	//public Animator nanaquest;
	GameObject signingavatars;
	Text currentsigntext;
	Text speechbubbletext;
	Text signcredittext;
	Text descriptiontext;
	/*
	public Text currentsigntextpc;
	public Text speechbubbletextpc;
	public Text signcredittextpc;
	public Text descriptiontextpc;
	public Text currentsigntextquest;
	public Text speechbubbletextquest;
	public Text signcredittextquest;
	public Text descriptiontextquest;
	*/
	GameObject[] buttons = new GameObject[70];
	GameObject[] backbuttons = new GameObject[2];
	GameObject[] indexicons = new GameObject[70];
	GameObject[] regvricons = new GameObject[70];
	GameObject[] bothvricons = new GameObject[70];
	Text[] buttontext = new Text[70];
	int numofbuttons=70;
    //int previousboard=0;//tracks which board it's on. 0=lang select, 1=lesson select, 2=word select
    int currentboard=0;//tracks which board it's on. 0=lang select, 1=lesson select, 2=word select
    int currentlang=0;//tracks which language is currently selected.
    int currentlesson=0;//tracks which lesson is currently selected.
    int currentword=0;
	Text menuheadertext;
	GameObject menuheader;
    GameObject nextButton;
    GameObject prevButton;

	GameObject videocontainer;
	GameObject videoplayer;
	VRCUnityVideoPlayer vrcplayercomponent;
	public VRCUrl[][][] langurls;
	bool quizmode=false;
	bool globalmode=false;
	Slider avatarscaleslider;
	Toggle HandToggle;
	Toggle GlobalToggle;

	/***************************************************************************************************************************
	Assigns variables for use. Initializes menu by calling DisplayLanguageSelectMenu();
	***************************************************************************************************************************/
	void Start() {


HandToggle=GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Hand Toggle").GetComponent<Toggle>();
GlobalToggle=GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Global Mode").GetComponent<Toggle>();
avatarscaleslider=GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Avatar Scale Slider").GetComponent<Slider>();


		signingavatars = GameObject.Find("/Signing Avatars");
		if(signingavatars.transform.Find("Nana Avatar").gameObject.activeInHierarchy){
			Debug.Log("PC active");
			nana=signingavatars.transform.Find("Nana Avatar").GetComponent<Animator>();
			speechbubbletext = signingavatars.transform.Find("Nana Avatar/Armature/Canvas/Bubble/text").GetComponent < Text > ();
		}
		if(signingavatars.transform.Find("Nana Quest").gameObject.activeInHierarchy){
			Debug.Log("Quest active");
			nana=signingavatars.transform.Find("Nana Quest").GetComponent<Animator>();
			speechbubbletext = signingavatars.transform.Find("Nana Quest/Armature/Canvas/Bubble/text").GetComponent < Text > ();
		}
		currentsigntext = signingavatars.transform.Find("Canvas/Current Sign Panel/Current Sign Text").GetComponent < Text > ();
		signcredittext = signingavatars.transform.Find("Canvas/Credit Panel/Credit Text").GetComponent < Text > ();
		descriptiontext = signingavatars.transform.Find("Canvas/Description Panel/Description Text").GetComponent < Text > ();
		nextButton = signingavatars.transform.Find("Canvas/NextButton").gameObject;
    	prevButton = signingavatars.transform.Find("Canvas/PrevButton").gameObject;
		menuheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header").GetComponent < Text > ();
		menuheader = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header");

		for (int x = 0; x < numofbuttons; x++) {
			buttons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x));
			buttontext[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Text").GetComponent < Text > ();
			indexicons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Index VR Icon");
			regvricons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Regular VR Icon");
			bothvricons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Both VR Icon");
		}
		backbuttons[0] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Left Back Button");
		backbuttons[1] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Right Back Button");

		videocontainer = GameObject.Find("/Video Container");
		videoplayer = GameObject.Find("/Video Container/Video");
		vrcplayercomponent=((VRCUnityVideoPlayer)videoplayer.GetComponent(typeof(VRCUnityVideoPlayer)));
		//VRCUrl urls = videocontainer.AddUdonSharpComponent<VRCUrl>();
		DisplayLanguageSelectMenu();
	}


	/***************************************************************************************************************************
	Changes the menu so it displays the language select menu.
	***************************************************************************************************************************/
	void DisplayLanguageSelectMenu() {
		menuheadertext.text = "VR Sign Language Select Menu";
		for (int x = 0; x < numofbuttons; x++) {
			if (signlanguagenames.Length > x) {
				buttontext[x].text = (x + 1) + ") " +  signlanguagenames[x][1];
				indexicons[x].SetActive(false);
				regvricons[x].SetActive(false);
				bothvricons[x].SetActive(false);
			} else {
				buttons[x].SetActive(false);
			}
		}

		backbuttons[0].SetActive(false);
		backbuttons[1].SetActive(false);
		nextButton.SetActive(false);
		prevButton.SetActive(false);
        //previousboard=currentboard;
        //previousboard=0;//can't think of a reason why we'd want a back button to another language's lesson menu?
        currentboard=0;
        currentlesson=0;
        currentword=-1;
	}

	/***************************************************************************************************************************
	Figures out what the button does, and sends to the approperate functions to update the menu.
	***************************************************************************************************************************/
	public void buttonpushed(int x) {
		//figure out what the current signnumber is based on x and prevsign (figure out previous screen first)
		Debug.Log("Entered Buttonpushed with button #"+x+" pushed and currentboard"+currentboard);
		switch (currentboard) {
		case 0: //button pushed on lang select, change to lesson select board.
        	DisplayLessonSelectMenu(x);//x=language number
        break;
        case 1://button pushed on lesson select, change to word select board.
        	DisplaySignSelectMenu(x);//need language and lesson number.
        break;
        case 2://button pushed on word select, display word selected.
			//turn off current playing video (if any)
			//TurnOffVideo();
			//do all the sign word change stuff
			changeword(x);
        break;
        default:
        Debug.Log("Button pushed, but I have no idea what board i'm on. currentboard: "+currentboard + "buttonpushed: "+x);
        break;
        }
	}

	/***************************************************************************************************************************
	Figures out where the back button goes based on the current board, and sends to the approperate functions to update the menu.
	***************************************************************************************************************************/
	void BackButtonClicked() {
		//figure out what the current signnumber is based on x and prevsign (figure out previous screen first)
		switch (currentboard) {
		case 0: //button pushed on lang select, change to lesson select board.
        	Debug.Log("Back button pushed, but the back button should have been enabled on lang select ");
        break;
        case 1://button pushed on lesson select, change to lang select board.
        	DisplayLanguageSelectMenu();//need language and lesson number.
        break;
        case 2://button pushed on word select, display lesson select board.
			DisplayLessonSelectMenu(currentlang);
		break;
        default:
        Debug.Log("Back button pushed, but I have no idea what board i'm on. currentboard: "+currentboard);
        break;
        }
	}

    /***************************************************************************************************************************
	Called before current variables are changed, to disable videos if any are active (based on presence of url being populated)
	***************************************************************************************************************************/
    void TurnOffVideo() {
		Debug.Log("Entering TurnOffVideo with currentword of: " + currentword);
		if (currentword!=-1){
			if (AllLessons[currentlang][currentlesson][currentword][3] != "") { //if url is not empty, turn off the video
				Debug.Log("/Udon Menu System/Video Container/"+signlanguagenames[currentlang][0]+" Video L"+(currentlesson+1) +" S"+(currentword+1));
				videocontainer.transform.Find(signlanguagenames[currentlang][0]+" Video L"+(currentlesson+1) +" S"+(currentword+1)).gameObject.SetActive(false);
			}
		}
    }
	/***************************************************************************************************************************
	Called to change everything needed to display a sign's motion data. Doesn't care if it's the same sign.
	***************************************************************************************************************************/
	void changeword(int buttonnumber) { //wordnum must not be 00.

			//turn off old video.
			if (currentword!=-1)
			{
				if (AllLessons[currentlang][currentlesson][currentword][3] == "") { //if url is empty, turn off the video
                vrcplayercomponent.Stop();
				//	Debug.Log("/Udon Menu System/Video Container/"+signlanguagenames[currentlang][0]+" Video L"+(currentlesson+1) +" S"+(currentword+1));
					//videocontainer.transform.Find(signlanguagenames[currentlang][0]+" Video L"+(currentlesson+1) +" S"+(currentword+1)).gameObject.SetActive(false);
				}
			}
		Debug.Log("Entering changeword with buttonbumber of: " + buttonnumber);
		//0th value is the word 
        //1st value is the name of the animation state (Used in the animation controller populator script to generate transitions - needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
        //2nd value is mocap credits. 
        //3rd value is video URL.
        //4th value is VR index or regular 0=indexonly , 1=generalvr,2=both
        //5th value is Sign description string
		currentsigntext.text=AllLessons[currentlang][currentlesson][buttonnumber][0];
		speechbubbletext.text=AllLessons[currentlang][currentlesson][buttonnumber][0];
		nana.Play(AllLessons[currentlang][currentlesson][buttonnumber][1]);//or do setinterger? But setinterger is hard to figure out unless i re-encode all the states to something easily derived from AllLessons
		signcredittext.text = AllLessons[currentlang][currentlesson][buttonnumber][2];
		
		if(AllLessons[currentlang][currentlesson][buttonnumber][3]!=""){//if url is blank, then don't look for the video
			vrcplayercomponent.PlayURL(langurls[currentlang][currentlesson][buttonnumber]);
		}
		descriptiontext.text = AllLessons[currentlang][currentlesson][buttonnumber][5];

		if(buttonnumber>0){
			prevButton.SetActive(true);
		}else{
			prevButton.SetActive(false);
		}
		if(buttonnumber<AllLessons[currentlang][currentlesson].Length){
			nextButton.SetActive(true);
		}else{
			nextButton.SetActive(false);
		}
	currentword=buttonnumber;
	    
	}

	void DisplayLessonSelectMenu(int languagenumber) { //I don't need the lesson number here because I'm displaying all lessons.
		Debug.Log("Now entering DisplayLessonSelectMenu with a language number of " + languagenumber);
		menuheadertext.text = signlanguagenames[languagenumber][0] + " Lesson Menu";
		//Debug.Log("header set?");

		for (int x = 0; x < numofbuttons; x++) {
			if (x < AllLessons[languagenumber].Length) {
				if (lessonnames[languagenumber].Length > x) {
					buttontext[x].text = (x + 1) + ") " + lessonnames[languagenumber][x];
					buttons[x].SetActive(true);
					indexicons[x].SetActive(false);
					regvricons[x].SetActive(false);
					bothvricons[x].SetActive(false);
				}
			}else {
				buttons[x].SetActive(false);
			}
		}
		nextButton.SetActive(false);
		prevButton.SetActive(false);
		backbuttons[0].SetActive(true);
		backbuttons[1].SetActive(true);
		//maybe need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function...
		currentlang=languagenumber;
		currentboard=1;
		currentword=-1;
	}

	void DisplaySignSelectMenu(int lessonnum) {
		Debug.Log("Now entering DisplaySignSelectMenu with a language number of " + currentlang + " and a lessonnum of " + lessonnum);
		//  string[][][] AllLessons = new string[1][][];
		//   AllLessons[0]=ASLlessons;
		menuheadertext.text = signlanguagenames[currentlang][0] + " - " + lessonnames[currentlang][lessonnum];

		for (int x = 0; x < numofbuttons; x++) { //update all the buttons in the menu
			//Debug.Log("x="+x+" AllLessons[currentlang][lessonnum].Length="+AllLessons[currentlang][lessonnum].Length);
			if (AllLessons[currentlang][lessonnum].Length > x) { //for all signs in the lesson
				buttons[x].SetActive(true);
				buttontext[x].text = "          " + (x + 1) + ") " + AllLessons[currentlang][lessonnum][x][0];
				speechbubbletext.text=AllLessons[currentlang][lessonnum][x][0];
				currentsigntext.text=speechbubbletext.text=AllLessons[currentlang][lessonnum][x][0];
				signcredittext.text="The motion data for this sign was signed by: " + AllLessons[currentlang][lessonnum][x][2];
				descriptiontext.text=AllLessons[currentlang][lessonnum][x][5];
				//Debug.Log("switching on AllLessons[currentlang][lessonnum][x][4]:" + AllLessons[currentlang][lessonnum][x][4]);
				switch (AllLessons[currentlang][lessonnum][x][4]) { //populate vr icons
				case "0": //index icon
					indexicons[x].SetActive(true);
					regvricons[x].SetActive(false);
					bothvricons[x].SetActive(false);
					break;
				case "1": //regular vr icon
					indexicons[x].SetActive(false);
					regvricons[x].SetActive(true);
					bothvricons[x].SetActive(false);
					break;
				case "2": //both vr icon
					indexicons[x].SetActive(false);
					regvricons[x].SetActive(false);
					bothvricons[x].SetActive(true);
					break;
				default: //uhh how am I here? Is it null somehow? Maybe should set to both by default...
					indexicons[x].SetActive(false);
					regvricons[x].SetActive(false);
					bothvricons[x].SetActive(false);
					break;
				}

			}else { //disable buttons that are outside of the lesson
				buttons[x].SetActive(false);
			}
		}
		backbuttons[0].SetActive(true);
		backbuttons[1].SetActive(true);
		//also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function... 
		currentboard=2;
		currentlesson=lessonnum;
	}
	/***************************************************************************************************************************
	Called to scale signing avatar gameobject
	***************************************************************************************************************************/
	public void AvatarScaleSliderValueChanged()
    {
		signingavatars.transform.localScale= new Vector3(avatarscaleslider.value,avatarscaleslider.value,avatarscaleslider.value);
    }
	/***************************************************************************************************************************
	Called to switch the signing avatar's mirror animation parameter and set the toggle box state.
	***************************************************************************************************************************/
	public void ToggleHand()
    {
		if(!nana.GetBool("Mirror")){ //if mirror checkbox is off
			nana.SetBool("Mirror",true);
			HandToggle.GetComponent<Toggle>().isOn=true;
		}else{
			nana.SetBool("Mirror",false);
			HandToggle.GetComponent<Toggle>().isOn=false;

		}
		
    }

	/***************************************************************************************************************************
	Called to switch the board to global mode and set the toggle box state
	***************************************************************************************************************************/
	public void ToggleGlobal()
    {
		if(!globalmode){
			globalmode=true;
			GlobalToggle.GetComponent<Toggle>().isOn=true;
		}else{
			globalmode=false;
			GlobalToggle.GetComponent<Toggle>().isOn=true;
		}
    }


	/***************************************************************************************************************************
	Called to switch the board to quiz mode and set the toggle box state
	***************************************************************************************************************************/
	public void ToggleQuizMode()
    {
    }
	public void NextB()
	{
	Debug.Log("Next pushed");
	//Changeword should have checked if +1 would exceed the current words in the lesson and disabled the next/previous button.
		//TurnOffVideo();
		changeword(currentword+1);
	}
	public void PrevB()
	{
		//TurnOffVideo();
		changeword(currentword-1);
	}
	public void BackB()
	{
	Debug.Log("Back pushed");
	BackButtonClicked();
	}
	public void B0() {
		buttonpushed(0);
	}
	public void B1() {
		buttonpushed(1);
	}
	public void B2() {
		buttonpushed(2);
	}
	public void B3() {
		buttonpushed(3);
	}
	public void B4() {
		buttonpushed(4);
	}
	public void B5() {
		buttonpushed(5);
	}
	public void B6() {
		buttonpushed(6);
	}
	public void B7() {
		buttonpushed(7);
	}
	public void B8() {
		buttonpushed(8);
	}
	public void B9() {
		buttonpushed(9);
	}
	public void B10() {
		buttonpushed(10);
	}
	public void B11() {
		buttonpushed(11);
	}
	public void B12() {
		buttonpushed(12);
	}
	public void B13() {
		buttonpushed(13);
	}
	public void B14() {
		buttonpushed(14);
	}
	public void B15() {
		buttonpushed(15);
	}
	public void B16() {
		buttonpushed(16);
	}
	public void B17() {
		buttonpushed(17);
	}
	public void B18() {
		buttonpushed(18);
	}
	public void B19() {
		buttonpushed(19);
	}
	public void B20() {
		buttonpushed(20);
	}
	public void B21() {
		buttonpushed(21);
	}
	public void B22() {
		buttonpushed(22);
	}
	public void B23() {
		buttonpushed(23);
	}
	public void B24() {
		buttonpushed(24);
	}
	public void B25() {
		buttonpushed(25);
	}
	public void B26() {
		buttonpushed(26);
	}
	public void B27() {
		buttonpushed(27);
	}
	public void B28() {
		buttonpushed(28);
	}
	public void B29() {
		buttonpushed(29);
	}
	public void B30() {
		buttonpushed(30);
	}
	public void B31() {
		buttonpushed(31);
	}
	public void B32() {
		buttonpushed(32);
	}
	public void B33() {
		buttonpushed(33);
	}
	public void B34() {
		buttonpushed(34);
	}
	public void B35() {
		buttonpushed(35);
	}
	public void B36() {
		buttonpushed(36);
	}
	public void B37() {
		buttonpushed(37);
	}
	public void B38() {
		buttonpushed(38);
	}
	public void B39() {
		buttonpushed(39);
	}
	public void B40() {
		buttonpushed(40);
	}
	public void B41() {
		buttonpushed(41);
	}
	public void B42() {
		buttonpushed(42);
	}
	public void B43() {
		buttonpushed(43);
	}
	public void B44() {
		buttonpushed(44);
	}
	public void B45() {
		buttonpushed(45);
	}
	public void B46() {
		buttonpushed(46);
	}
	public void B47() {
		buttonpushed(47);
	}
	public void B48() {
		buttonpushed(48);
	}
	public void B49() {
		buttonpushed(49);
	}
	public void B50() {
		buttonpushed(50);
	}
	public void B51() {
		buttonpushed(51);
	}
	public void B52() {
		buttonpushed(52);
	}
	public void B53() {
		buttonpushed(53);
	}
	public void B54() {
		buttonpushed(54);
	}
	public void B55() {
		buttonpushed(55);
	}

        public override void OnVideoError(VideoError videoError)
        {

            Debug.LogError("[USharpVideo] Video failed: ");

            switch (videoError)
            {
                case VideoError.RateLimited:
                    Debug.LogError("Rate limited, try again in a few seconds");
                    break;
                case VideoError.PlayerError:
                    Debug.LogError("Video player error");
                    break;
                case VideoError.InvalidURL:
                    Debug.LogError("Invalid URL");
                    break;
                case VideoError.AccessDenied:
                    Debug.LogError("Video blocked, enable untrusted URLs");
                    break;
                default:
                    Debug.LogError("Failed to load video");
                    break;
            }

        }
//    

#if !COMPILER_UDONSHARP && UNITY_EDITOR 
    [CustomEditor(typeof(MenuControl))]
    public class CustomInspectorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
			DrawDefaultInspector();
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;
            MenuControl inspectorBehaviour = (MenuControl)target;
            
            
			
            if(GUILayout.Button("Populate VRCUrls"))
            {
				//Debug.Log("AllLessons.Length: "+ inspectorBehaviour.AllLessons.Length);
				inspectorBehaviour.langurls = new VRCUrl[inspectorBehaviour.AllLessons.Length][][];
				for (int x = 0; x < inspectorBehaviour.AllLessons.Length; x++) {
					//Debug.Log("AllLessons[x].Length: "+ inspectorBehaviour.AllLessons[x].Length);
					VRCUrl[][] lessonurls = new VRCUrl[inspectorBehaviour.AllLessons[x].Length][];

					for (int y = 0; y < inspectorBehaviour.AllLessons[x].Length; y++) 
					{
						//Debug.Log("AllLessons[x][y].Length: "+ inspectorBehaviour.AllLessons[x][y].Length);
						VRCUrl[] wordurls = new VRCUrl[inspectorBehaviour.AllLessons[x][y].Length];
						for (int z = 0; z < inspectorBehaviour.AllLessons[x][y].Length; z++) {
							
							//Debug.Log("loop status x:"+x+" y:"+y+" z:"+ z);
							//Debug.Log("Alllessons 0: "+inspectorBehaviour.AllLessons[x][y][z][0]);
							//Debug.Log("Alllessons 1: "+inspectorBehaviour.AllLessons[x][y][z][1]);
							//Debug.Log("Alllessons 2: "+inspectorBehaviour.AllLessons[x][y][z][2]);
							//Debug.Log("Alllessons 3: "+inspectorBehaviour.AllLessons[x][y][z][3]);
							
							wordurls[z] = new VRCUrl(inspectorBehaviour.AllLessons[x][y][z][3]);
						}
						lessonurls[y] = wordurls;
					}
					inspectorBehaviour.langurls[x] = lessonurls;
				}
            }
	    }
    }
#endif


}
