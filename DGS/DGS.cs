// Do not load this script when building
#if UNITY_EDITOR && VRC_SDK_VRCSDK2
//using System.Collections;
using System.Collections.Generic; //for lists
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using VRCSDK2;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine.Video;
//using UnityEngine.Audio;

namespace BobsMenuSystem
{
    public class CreateGSLButtons6 : MonoBehaviour
    {

        /*****************************************
        Start of Arrays variable declarations
        *****************************************/

        //creates an array of arrays. Grouped by lessons.
        //0th value is the English translation of the word
        //1st value is the German translation of the word
        //2nd value is video URL.
        const string MODE_GLOBAL = "Global";
        const string MODE_LOCAL = "Local";
        static
        string[][][] DGSlessons = {
new string[][]{//Lesson 1(Daily Use)
new string[]{"Hello","Hallo","https://vrchat.germany-sl.com/Lesson01/hallo.mp4"},
new string[]{"How (are) You","Wie geht es Ihnen","https://vrchat.germany-sl.com/Lesson01/wiegehts.mp4"},
new string[]{"What's Up?","Was geht?","https://vrchat.germany-sl.com/Lesson01/Wasgehts.mp4"},
new string[]{"Nice (to) Meet You","Freut mich, dich kennenzulernen","https://vrchat.germany-sl.com/Lesson01/freuemich.mp4"},
new string[]{"Good","Gut","https://vrchat.germany-sl.com/Lesson01/gut.mp4"},
new string[]{"Bad","schlecht","https://vrchat.germany-sl.com/Lesson01/schlecht.mp4"},
new string[]{"Yes","Ja","https://vrchat.germany-sl.com/Lesson01/ja.mp4"},
new string[]{"No","Nein","https://vrchat.germany-sl.com/Lesson01/nein.mp4"},
new string[]{"So-So","So-So","https://vrchat.germany-sl.com/Lesson01/so-so.mp4"},
new string[]{"Sick","krank","https://vrchat.germany-sl.com/Lesson01/krank.mp4"},
new string[]{"Hurt","verletzt","https://vrchat.germany-sl.com/Lesson01/verletzt.mp4"},
new string[]{"You're Welcome","Bitte","https://vrchat.germany-sl.com/Lesson01/bitte.mp4"},
new string[]{"Goodbye","Auf Wiedersehen","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4"},
new string[]{"Good Morning","Guten Morgen","https://vrchat.germany-sl.com/Lesson01/gutenmorgen.mp4"},
new string[]{"Good Afternoon","Guten Nachmittag","https://vrchat.germany-sl.com/Lesson01/gutennachmittag.mp4"},
new string[]{"Good Evening","Guten Abend","https://vrchat.germany-sl.com/Lesson01/gutenabend.mp4"},
new string[]{"Good Night","Good Night","https://vrchat.germany-sl.com/Lesson01/gutennacht.mp4"},
new string[]{"See You Later","Bis später","https://vrchat.germany-sl.com/Lesson01/bisspaeter.mp4"},
new string[]{"Please","Bitte","https://vrchat.germany-sl.com/Lesson01/bitte.mp4"},
new string[]{"Sorry","Es tut uns leid","https://vrchat.germany-sl.com/Lesson01/Estutunsleid.mp4"},
new string[]{"Forget","Vergessen","https://vrchat.germany-sl.com/Lesson01/vergessen.mp4"},
new string[]{"Sleep / Sleepy","Schlaf / Schläfrig","https://vrchat.germany-sl.com/Lesson01/schlaf.mp4"},
new string[]{"Bed","Bett","https://vrchat.germany-sl.com/Lesson01/schlaf.mp4"},
new string[]{"Jump / Change World","Welt springen / verändern","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4"},
new string[]{"Thank You","vielen Dank","https://vrchat.germany-sl.com/Lesson01/vielendank.mp4"},
new string[]{"I Love You","Ich liebe dich","https://vrchat.germany-sl.com/Lesson01/ichliebedich.mp4"},
new string[]{"ILY (I Love You)","ILY (I Love You)","https://vrchat.germany-sl.com/Lesson01/ILY.mp4"},
new string[]{"Go Away","Geh weg","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4"},
new string[]{"Going To","Ich gehe zu","https://vrchat.germany-sl.com/Lesson01/ichgehtes.mp4"},
new string[]{"Follow","Folgen","https://vrchat.germany-sl.com/Lesson01/folgen.mp4"},
new string[]{"Come","Kommen Sie","https://vrchat.germany-sl.com/Lesson01/kommensie.mp4"},
new string[]{"Hearing (Person)","Hören (Person)","https://vrchat.germany-sl.com/Lesson01/hoerer.mp4"},
new string[]{"Deaf","Gehörlos","https://vrchat.germany-sl.com/Lesson01/gehoerlos.mp4"},
new string[]{"Hard of Hearing","Hörbehinderte","https://vrchat.germany-sl.com/Lesson01/Hoerbehinderte.mp4"},
new string[]{"Mute","Stumm","https://vrchat.germany-sl.com/Lesson01/stumm.mp4"},
new string[]{"Write Slow","Schreiben Sie langsam","https://vrchat.germany-sl.com/Lesson01/SchreibenSielangsam.mp4"},
new string[]{"Can't Read","Kann nicht lesen","https://vrchat.germany-sl.com/Lesson01/Kannnichtlesen.mp4"},
new string[]{"Away","Weg","https://vrchat.germany-sl.com/Lesson01/weg.mp4"},
},
new string[][]{//Lesson 2(Pointing use Question / Answer)
new string[]{"I (Me)","Ich (Mich)","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4"},
new string[]{"My","Mein","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4"},
new string[]{"Your","Dein","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4"},
new string[]{"His","Seine","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4"},
new string[]{"Her","Ihr","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4"},
new string[]{"We","Wir","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4"},
new string[]{"They","Sie","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4"},
new string[]{"Their","Ihr","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4"},
new string[]{"Over There","Da drüben","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4"},
new string[]{"Our","Unsere","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4"},
new string[]{"It's","Es ist","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4"},
new string[]{"Inside","Innerhalb","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4"},
new string[]{"Outside","Draußen","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4"},
new string[]{"Hidden","Versteckt","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4"},
new string[]{"Behind","Hinter","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4"},
new string[]{"Above","Über","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4"},
new string[]{"Below","Unten","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4"},
new string[]{"Here","Hier","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4"},
new string[]{"Beside","Neben","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4"},
new string[]{"Back","Zurück","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4"},
new string[]{"Front","Vorderseite","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4"},
new string[]{"Who","Who","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4"},
new string[]{"Where","Wo","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4"},
new string[]{"When","wann","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4"},
new string[]{"Why","Warum","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4"},
new string[]{"Which","Welche","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4"},
new string[]{"What","Was","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4"},
new string[]{"How","Wie","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4"},
new string[]{"How Many","Wie viele","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4"},
new string[]{"Can","Kann","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4"},
new string[]{"Can't","kann nicht","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4"},
new string[]{"Want","Wollen","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4"},
new string[]{"Have","Haben","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4"},
new string[]{"Get","Erhalten","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4"},
new string[]{"Will / Future","Wille / Zukunft","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4"},
new string[]{"Take (Up)","Aufnehmen","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4"},
new string[]{"Need","Brauchen","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4"},
new string[]{"Must","Muss",""},
new string[]{"Not","Nicht","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4"},
new string[]{"Or","oder","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4"},
new string[]{"And","und","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4"},
new string[]{"For","Für","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4"},
new string[]{"At","Beim","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4"},
},
new string[][]{//Lesson 3(Common)
new string[]{"Teach","Teach","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4"},
new string[]{"Learn","Learn","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4"},
new string[]{"Person","Person","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4"},
new string[]{"Student","Student","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4"},
new string[]{"Teacher","Teacher","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4"},
new string[]{"Friend","Friend","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4"},
new string[]{"Sign","Sign","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4"},
new string[]{"Language","Language","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4"},
new string[]{"Understand","Understand","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4"},
new string[]{"Know","Know","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4"},
new string[]{"Don't Know","Don't Know","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4"},
new string[]{"Be Right Back (BRB)","Be Right Back (BRB)","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4"},
new string[]{"Accept","Accept","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4"},
new string[]{"Denied","Denied","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4"},
new string[]{"Name","Name","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4"},
new string[]{"New","New","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4"},
new string[]{"Old","Old","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4"},
new string[]{"Very","Very","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4"},
new string[]{"Jokes","Jokes","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4"},
new string[]{"Funny","Funny","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4"},
new string[]{"Play","Play","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4"},
new string[]{"Favorite","Favorite","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4"},
new string[]{"Draw","Draw","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4"},
new string[]{"Stop","Stop","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4"},
new string[]{"Read","Read","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4"},
new string[]{"Make","Make","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4"},
new string[]{"Write","Write","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4"},
new string[]{"Again / Repeat","Again / Repeat","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4"},
new string[]{"Slow","Slow","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4"},
new string[]{"Fast","Fast","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4"},
new string[]{"Rude","Rude","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4"},
new string[]{"Eat","Eat","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4"},
new string[]{"Drink","Drink","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4"},
new string[]{"Watch","Watch","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4"},
new string[]{"Work","Work","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4"},
new string[]{"Live","Live",""},
new string[]{"Live (Variant 2)","Live (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4"},
new string[]{"Play Game","Play Game","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4"},
new string[]{"Same","Same","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4"},
new string[]{"Alright","Alright","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4"},
new string[]{"People","People","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4"},
new string[]{"Browsing the Internet","Browsing the Internet","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4"},
new string[]{"Movie","Movie","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4"},
},
new string[][]{//Lesson 4(People)
new string[]{"Family","Family","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4"},
new string[]{"Boy","Boy","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4"},
new string[]{"Girl","Girl","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4"},
new string[]{"Brother","Brother","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4"},
new string[]{"Sister","Sister","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4"},
new string[]{"Brother-in-law","Brother-in-law","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4"},
new string[]{"Sister-in-law","Sister-in-law","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4"},
new string[]{"Father","Father","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4"},
new string[]{"Grandpa","Grandpa","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4"},
new string[]{"Mother","Mother","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4"},
new string[]{"Grandma","Grandma","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4"},
new string[]{"Baby","Baby","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4"},
new string[]{"Child","Child","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4"},
new string[]{"Teen","Teen","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4"},
new string[]{"Adult","Adult","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4"},
new string[]{"Aunt","Aunt","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4"},
new string[]{"Uncle","Uncle","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4"},
new string[]{"Stranger","Stranger","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4"},
new string[]{"Acquaintance","Acquaintance","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4"},
new string[]{"Parents","Parents","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4"},
new string[]{"Born","Born","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4"},
new string[]{"Dead","Dead","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4"},
new string[]{"Marriage","Marriage","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4"},
new string[]{"Divorce","Divorce","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4"},
new string[]{"Single","Single","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4"},
new string[]{"Young","Young","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4"},
new string[]{"Old","Old","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4"},
new string[]{"Age","Age","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4"},
new string[]{"Birthday","Birthday","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4"},
new string[]{"Celebrate","Celebrate","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4"},
new string[]{"Enemy","Enemy","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4"},
new string[]{"Interpreter","Interpreter","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4"},
new string[]{"No One","No One","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4"},
new string[]{"Anyone","Anyone","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4"},
new string[]{"Someone","Someone","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4"},
new string[]{"Everyone","Everyone","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4"},
},
new string[][]{//Lesson 5(Feelings / Reactions)
new string[]{"Like","Like","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4"},
new string[]{"Hate","Hate","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4"},
new string[]{"Fine","Fine","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4"},
new string[]{"Tired","Tired","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4"},
new string[]{"Sleep / Sleepy","Sleep / Sleepy","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4"},
new string[]{"Confused","Confused","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4"},
new string[]{"Smart","Smart","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4"},
new string[]{"Attention / Focus","Attention / Focus","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4"},
new string[]{"Nevermind","Nevermind","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4"},
new string[]{"Angry","Angry","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4"},
new string[]{"Laughing","Laughing","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4"},
new string[]{"LOL","LOL","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4"},
new string[]{"Curious","Curious","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4"},
new string[]{"In Love","In Love","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4"},
new string[]{"Awesome","Awesome","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4"},
new string[]{"Great","Great","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4"},
new string[]{"Nice","Nice","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4"},
new string[]{"Cute","Cute","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4"},
new string[]{"Feel","Feel","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4"},
new string[]{"Pity","Pity","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4"},
new string[]{"Envy","Envy","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4"},
new string[]{"Hungry","Hungry","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4"},
new string[]{"Alive","Alive","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4"},
new string[]{"Bored","Bored","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4"},
new string[]{"Cry","Cry","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4"},
new string[]{"Happy","Happy","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4"},
new string[]{"Sad","Sad","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4"},
new string[]{"Suffering","Suffering","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4"},
new string[]{"Surprised","Surprised","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4"},
new string[]{"Careful","Careful","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4"},
new string[]{"Enjoy","Enjoy","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4"},
new string[]{"Disgusted","Disgusted","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4"},
new string[]{"Embarrassed","Embarrassed","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4"},
new string[]{"Shy","Shy","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4"},
new string[]{"Lonely","Lonely","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4"},
new string[]{"Stressed","Stressed","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4"},
new string[]{"Scared","Scared","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4"},
new string[]{"Excited","Excited","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4"},
new string[]{"Shame","Shame","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4"},
new string[]{"Struggle","Struggle","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4"},
new string[]{"Friendly","Friendly","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4"},
new string[]{"Mean","Mean","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4"},
},
new string[][]{//Lesson 6(Value)
new string[]{"More","More","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4"},
new string[]{"Less","Less","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4"},
new string[]{"Big","Big","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4"},
new string[]{"Small / A Little","Small / A Little","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4"},
new string[]{"Full","Full","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4"},
new string[]{"Empty","Empty","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4"},
new string[]{"Half","Half","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4"},
new string[]{"Quarter","Quarter","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4"},
new string[]{"Long","Long","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4"},
new string[]{"Short (Time)","Short (Time)","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4"},
new string[]{"A Lot / Many","A Lot / Many","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4"},
new string[]{"Unlimited","Unlimited","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4"},
new string[]{"Limited","Limited","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4"},
new string[]{"All","All","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4"},
new string[]{"All (Variant 2)","All (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4"},
new string[]{"Nothing","Nothing","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4"},
new string[]{"Ever","Ever","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4"},
new string[]{"Everything","Everything","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4"},
new string[]{"Everytime","Everytime","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4"},
new string[]{"Always","Always","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4"},
new string[]{"Often","Often","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4"},
new string[]{"Sometimes","Sometimes","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4"},
new string[]{"Heavy","Heavy","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4"},
new string[]{"Lightweight","Lightweight","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4"},
new string[]{"Hard","Hard","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4"},
new string[]{"Soft","Soft","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4"},
new string[]{"Strong","Strong","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4"},
new string[]{"Weak","Weak","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4"},
new string[]{"First","First","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4"},
new string[]{"Second","Second","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4"},
new string[]{"Third","Third","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4"},
new string[]{"Next","Next","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4"},
new string[]{"Last","Last","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4"},
new string[]{"Before","Before","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4"},
new string[]{"After","After","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4"},
new string[]{"Busy","Busy","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4"},
new string[]{"Free","Free","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4"},
new string[]{"High","High","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4"},
new string[]{"Low","Low","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4"},
new string[]{"Fat","Fat","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4"},
new string[]{"Thin","Thin","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4"},
new string[]{"Value","Value","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4"},
},
new string[][]{//Lesson 7(Time)
new string[]{"Time","Time","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4"},
new string[]{"Year","Year","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4"},
new string[]{"Season","Season","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4"},
new string[]{"Month","Month","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4"},
new string[]{"Week","Week","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4"},
new string[]{"Day","Day","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4"},
new string[]{"Weekend","Weekend","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4"},
new string[]{"Hours","Hours","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4"},
new string[]{"Minutes","Minutes","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4"},
new string[]{"Seconds","Seconds","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4"},
new string[]{"Today","Today","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4"},
new string[]{"Tomorrow","Tomorrow","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4"},
new string[]{"Yesterday","Yesterday","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4"},
new string[]{"Morning","Morning","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4"},
new string[]{"Afternoon","Afternoon","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4"},
new string[]{"Evening","Evening","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4"},
new string[]{"Night","Night","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4"},
new string[]{"Sunrise","Sunrise","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4"},
new string[]{"Sunset","Sunset","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4"},
new string[]{"All Day","All Day","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4"},
new string[]{"All Day (Variant 2)","All Day (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4"},
new string[]{"All Night","All Night","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4"},
new string[]{"All Night (Variant 2)","All Night (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4"},
new string[]{"Sunday","Sunday","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4"},
new string[]{"Monday","Monday","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4"},
new string[]{"Tuesday","Tuesday","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4"},
new string[]{"Wednesday","Wednesday","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4"},
new string[]{"Thursday","Thursday","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4"},
new string[]{"Friday","Friday","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4"},
new string[]{"Saturday","Saturday","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4"},
new string[]{"Autumn","Autumn","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4"},
new string[]{"Winter","Winter","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4"},
new string[]{"Spring","Spring","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4"},
new string[]{"Summer","Summer","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4"},
new string[]{"Now","Now","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4"},
new string[]{"Never","Never","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4"},
new string[]{"Soon","Soon","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4"},
new string[]{"Later","Later","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4"},
new string[]{"Past","Past","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4"},
new string[]{"Future","Future","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4"},
new string[]{"Earlier","Earlier","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4"},
new string[]{"Midweek","Midweek","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4"},
new string[]{"Next Week","Next Week","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4"},
},
new string[][]{//Lesson 8(VRChat)
new string[]{"Gestures","Gestures","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4"},
new string[]{"World","World","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4"},
new string[]{"Record","Record","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4"},
new string[]{"Discord","Discord","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4"},
new string[]{"Streaming","Streaming","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4"},
new string[]{"Headset (VR)","Headset (VR)","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4"},
new string[]{"Desktop","Desktop","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4"},
new string[]{"Computer","Computer","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4"},
new string[]{"Instance","Instance","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4"},
new string[]{"Public","Public","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4"},
new string[]{"Invite","Invite","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4"},
new string[]{"Private","Private","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4"},
new string[]{"Add Friend","Add Friend","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4"},
new string[]{"Menu","Menu","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4"},
new string[]{"Recharge","Recharge","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4"},
new string[]{"Visit","Visit","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4"},
new string[]{"Request","Request","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4"},
new string[]{"Login","Login","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4"},
new string[]{"Logout","Logout","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4"},
new string[]{"Schedule","Schedule","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4"},
new string[]{"Event","Event","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4"},
new string[]{"Online","Online","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4"},
new string[]{"Offline","Offline","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4"},
new string[]{"Cancel","Cancel","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4"},
new string[]{"Portal","Portal","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4"},
new string[]{"Camera","Camera","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4"},
new string[]{"Avatar","Avatar","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4"},
new string[]{"Photo","Photo","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4"},
new string[]{"Join","Join","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4"},
new string[]{"Leave","Leave","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4"},
new string[]{"Climbing","Climbing","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4"},
new string[]{"Falling","Falling","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4"},
new string[]{"Walk","Walk","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4"},
new string[]{"Hide","Hide","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4"},
new string[]{"Block","Block","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4"},
new string[]{"Crash","Crash","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4"},
new string[]{"Lagging","Lagging","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4"},
new string[]{"Restart","Restart","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4"},
new string[]{"Send","Send","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4"},
new string[]{"Receive","Receive","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4"},
new string[]{"Security","Security","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4"},
new string[]{"Donation","Donation","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4"},
},
new string[][]{//Lesson 9(Alphabet / Numbers (Fingerspelling))
new string[]{"Spell / Fingerspell","Spell / Fingerspell","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4"},
new string[]{"A","A","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4"},
new string[]{"B","B","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4"},
new string[]{"C","C","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4"},
new string[]{"D","D","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4"},
new string[]{"E","E","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4"},
new string[]{"F","F","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4"},
new string[]{"G","G","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4"},
new string[]{"H","H","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4"},
new string[]{"I","I","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4"},
new string[]{"J","J","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4"},
new string[]{"K","K","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4"},
new string[]{"L","L","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4"},
new string[]{"M","M","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4"},
new string[]{"N","N","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4"},
new string[]{"O","O","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4"},
new string[]{"P","P","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4"},
new string[]{"Q","Q","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4"},
new string[]{"R","R","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4"},
new string[]{"S","S","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4"},
new string[]{"T","T","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4"},
new string[]{"U","U","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4"},
new string[]{"V","V","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4"},
new string[]{"W","W","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4"},
new string[]{"X","X","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4"},
new string[]{"Y","Y","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4"},
new string[]{"Z","Z","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4"},
new string[]{"Comma","Comma","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4"},
new string[]{"Space","Space","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4"},
new string[]{"@","@",""},
new string[]{"Number","Number",""},
new string[]{"0","0","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4"},
new string[]{"1","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4"},
new string[]{"2","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4"},
new string[]{"3","3","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4"},
new string[]{"4","4","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4"},
new string[]{"5","5","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4"},
new string[]{"6","6","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4"},
new string[]{"7","7","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4"},
new string[]{"8","8","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4"},
new string[]{"9","9","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4"},
new string[]{"10","10","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4"},
new string[]{"100","100","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4"},
new string[]{"1000","1000","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4"},
new string[]{"1000000","1000000","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4"},
},
new string[][]{//Lesson 10(Verbs & Actions p1)
new string[]{"Overlook","Overlook","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4"},
new string[]{"Punish","Punish","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4"},
new string[]{"Edit","Edit","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4"},
new string[]{"Erase","Erase","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4"},
new string[]{"Write","Write","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4"},
new string[]{"Proposal","Proposal","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4"},
new string[]{"Add","Add","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4"},
new string[]{"Remove","Remove","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4"},
new string[]{"Agree","Agree","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4"},
new string[]{"Disagree","Disagree","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4"},
new string[]{"Admit","Admit","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4"},
new string[]{"Allow","Allow","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4"},
new string[]{"Attack","Attack","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4"},
new string[]{"Fight","Fight","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4"},
new string[]{"Defend","Defend","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4"},
new string[]{"Defeat (Overcome)","Defeat (Overcome)","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4"},
new string[]{"Win","Win","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4"},
new string[]{"Lose","Lose","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4"},
new string[]{"Draw / Tie (Game)","Draw / Tie (Game)","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4"},
new string[]{"Give Up","Give Up","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4"},
new string[]{"Skip","Skip","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4"},
new string[]{"Ask","Ask",""},
new string[]{"Attach","Attach","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4"},
new string[]{"Assistant","Assistant","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4"},
new string[]{"Assist / Help","Assist / Help",""},
new string[]{"Bait","Bait","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4"},
new string[]{"Battle","Battle","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4"},
new string[]{"Beat (Overcome)","Beat (Overcome)","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4"},
new string[]{"Become","Become","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4"},
new string[]{"Beg","Beg","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4"},
new string[]{"Begin / Start","Begin / Start","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4"},
new string[]{"Behave","Behave","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4"},
new string[]{"Believe","Believe","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4"},
new string[]{"Blame","Blame","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4"},
new string[]{"Blow","Blow","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4"},
new string[]{"Blush","Blush","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4"},
new string[]{"Bother / Harass","Bother / Harass","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4"},
},
new string[][]{//Lesson 11(Verbs & Actions p2: Ben-Cor)
new string[]{"Bend","Bend","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4"},
new string[]{"Bow","Bow","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4"},
new string[]{"Break","Break","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4"},
new string[]{"Breathe","Breathe","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4"},
new string[]{"Bring","Bring","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4"},
new string[]{"Build / Construct","Build / Construct","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4"},
new string[]{"Bully","Bully","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4"},
new string[]{"Burn","Burn","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4"},
new string[]{"Buy","Buy","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4"},
new string[]{"Call","Call","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4"},
new string[]{"Cancel","Cancel","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4"},
new string[]{"Care","Care","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4"},
new string[]{"Carry","Carry","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4"},
new string[]{"Catch","Catch","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4"},
new string[]{"Cause","Cause","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4"},
new string[]{"Challenge","Challenge","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4"},
new string[]{"Chance","Chance","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4"},
new string[]{"Cheat","Cheat","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4"},
new string[]{"Check","Check","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4"},
new string[]{"Choose","Choose","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4"},
new string[]{"Claim","Claim","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4"},
new string[]{"Clean","Clean","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4"},
new string[]{"Clear","Clear","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4"},
new string[]{"Close","Close","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4"},
new string[]{"Comfort","Comfort","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4"},
new string[]{"Command","Command","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4"},
new string[]{"Communicate","Communicate","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4"},
new string[]{"Compare","Compare","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4"},
new string[]{"Complain","Complain","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4"},
new string[]{"Compliment","Compliment","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4"},
new string[]{"Concentrate","Concentrate","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4"},
new string[]{"Construct / Build","Construct / Build","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4"},
new string[]{"Control","Control","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4"},
new string[]{"Cook","Cook","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4"},
new string[]{"Copy","Copy","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4"},
new string[]{"Correct","Correct","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4"},
},
new string[][]{//Lesson 12(Verbs & Actions p3: Cou-Esc)
new string[]{"Cough","Cough","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4"},
new string[]{"Count","Count","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4"},
new string[]{"Create","Create","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4"},
new string[]{"Cuddle","Cuddle","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4"},
new string[]{"Cut","Cut","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4"},
new string[]{"Dab","Dab","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4"},
new string[]{"Dance","Dance","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4"},
new string[]{"Dare","Dare","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4"},
new string[]{"Date","Date","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4"},
new string[]{"Deal","Deal","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4"},
new string[]{"Deliver","Deliver","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4"},
new string[]{"Depend","Depend","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4"},
new string[]{"Describe","Describe","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4"},
new string[]{"Dirty","Dirty","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4"},
new string[]{"Disappear","Disappear","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4"},
new string[]{"Disappoint","Disappoint","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4"},
new string[]{"Disapprove","Disapprove","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4"},
new string[]{"Discuss","Discuss","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4"},
new string[]{"Disguise","Disguise","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4"},
new string[]{"Disgust","Disgust","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4"},
new string[]{"Dismiss","Dismiss","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4"},
new string[]{"Disturb","Disturb","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4"},
new string[]{"Doubt","Doubt","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4"},
new string[]{"Dream","Dream","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4"},
new string[]{"Dress","Dress","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4"},
new string[]{"Drunk","Drunk","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4"},
new string[]{"Drop","Drop","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4"},
new string[]{"Drown","Drown","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4"},
new string[]{"Dry","Dry","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4"},
new string[]{"Dump","Dump","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4"},
new string[]{"Dust","Dust","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4"},
new string[]{"Earn","Earn","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4"},
new string[]{"Effect","Effect","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4"},
new string[]{"End","End","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4"},
new string[]{"Escape","Escape","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4"},
new string[]{"Escort","Escort","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4"},
},
new string[][]{//Lesson 13(Verbs & Actions p4: Exc-Ins)
new string[]{"Excuse","Excuse","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4"},
new string[]{"Expose","Expose","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4"},
new string[]{"Exist","Exist","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4"},
new string[]{"Fail","Fail","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4"},
new string[]{"Faint","Faint","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4"},
new string[]{"Fake","Fake","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4"},
new string[]{"Fart","Fart","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4"},
new string[]{"Fear","Fear","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4"},
new string[]{"Fill","Fill","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4"},
new string[]{"Find","Find","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4"},
new string[]{"Finish","Finish","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4"},
new string[]{"Fix","Fix","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4"},
new string[]{"Flip","Flip","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4"},
new string[]{"Flirt","Flirt","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4"},
new string[]{"Fly","Fly","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4"},
new string[]{"Forbid","Forbid","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4"},
new string[]{"Forgive","Forgive","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4"},
new string[]{"Gain","Gain","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4"},
new string[]{"Give","Give","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4"},
new string[]{"Glow","Glow","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4"},
new string[]{"Grab","Grab","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4"},
new string[]{"Grow","Grow","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4"},
new string[]{"Guard","Guard","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4"},
new string[]{"Guess","Guess","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4"},
new string[]{"Guide","Guide","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4"},
new string[]{"Harass / Bother","Harass / Bother","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4"},
new string[]{"Harm","Harm","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4"},
new string[]{"Hit","Hit","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4"},
new string[]{"Hold","Hold","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4"},
new string[]{"Hop","Hop","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4"},
new string[]{"Hope","Hope","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4"},
new string[]{"Hunt","Hunt","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4"},
new string[]{"Ignore","Ignore","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4"},
new string[]{"Imagine","Imagine","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4"},
new string[]{"Imitate","Imitate","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4"},
new string[]{"Insult","Insult","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4"},
},
new string[][]{//Lesson 14(Verbs & Actions p5: Int-Pas)
new string[]{"Interact","Interact","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4"},
new string[]{"Interfere","Interfere","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4"},
new string[]{"Judge","Judge","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4"},
new string[]{"Jump","Jump","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4"},
new string[]{"Justify","Justify","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4"},
new string[]{"Just Kidding","Just Kidding","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4"},
new string[]{"Keep","Keep","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4"},
new string[]{"Kick","Kick","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4"},
new string[]{"Kill","Kill","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4"},
new string[]{"Knock","Knock","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4"},
new string[]{"Lead","Lead","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4"},
new string[]{"Lick","Lick","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4"},
new string[]{"Lock","Lock","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4"},
new string[]{"Manipulate","Manipulate","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4"},
new string[]{"Melt","Melt","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4"},
new string[]{"Mess","Mess","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4"},
new string[]{"Miss","Miss","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4"},
new string[]{"Mistake","Mistake","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4"},
new string[]{"Mount","Mount","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4"},
new string[]{"Move","Move","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4"},
new string[]{"Murder","Murder","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4"},
new string[]{"Nod","Nod","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4"},
new string[]{"Note","Note","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4"},
new string[]{"Notice","Notice","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4"},
new string[]{"Obey","Obey","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4"},
new string[]{"Obsess","Obsess","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4"},
new string[]{"Obtain","Obtain","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4"},
new string[]{"Occupy","Occupy","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4"},
new string[]{"Offend","Offend","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4"},
new string[]{"Offer","Offer","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4"},
new string[]{"Okay","Okay","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4"},
new string[]{"Open","Open","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4"},
new string[]{"Order","Order","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4"},
new string[]{"Owe","Owe","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4"},
new string[]{"Own","Own","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4"},
new string[]{"Pass","Pass","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4"},
},
new string[][]{//Lesson 15(Verbs & Actions p6: Pat-Sav)
new string[]{"Pat","Pat","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4"},
new string[]{"Party","Party","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4"},
new string[]{"Pet","Pet","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4"},
new string[]{"Pick","Pick","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4"},
new string[]{"Plug","Plug","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4"},
new string[]{"Point","Point","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4"},
new string[]{"Poke","Poke","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4"},
new string[]{"Pray","Pray","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4"},
new string[]{"Prepare","Prepare","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4"},
new string[]{"Present","Present","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4"},
new string[]{"Pretend","Pretend","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4"},
new string[]{"Protect","Protect","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4"},
new string[]{"Prove","Prove","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4"},
new string[]{"Publish","Publish","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4"},
new string[]{"Puke","Puke","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4"},
new string[]{"Puke (Variant 2)","Puke (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4"},
new string[]{"Pull","Pull","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4"},
new string[]{"Punch","Punch","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4"},
new string[]{"Put","Put","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4"},
new string[]{"Push","Push","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4"},
new string[]{"Question","Question","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4"},
new string[]{"Questions","Questions","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4"},
new string[]{"Quit","Quit","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4"},
new string[]{"Quote","Quote","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4"},
new string[]{"Race","Race","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4"},
new string[]{"React","React","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4"},
new string[]{"Recommended","Recommended","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4"},
new string[]{"Refuse","Refuse","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4"},
new string[]{"Regret","Regret","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4"},
new string[]{"Remember","Remember","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4"},
new string[]{"Replace","Replace","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4"},
new string[]{"Report","Report","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4"},
new string[]{"Reset","Reset","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4"},
new string[]{"Ride","Ride","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4"},
new string[]{"Rub","Rub","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4"},
new string[]{"Rule","Rule","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4"},
new string[]{"Run","Run","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4"},
new string[]{"Save","Save","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4"},
},
new string[][]{//Lesson 16(Verbs & Actions p7: Say-Try)
new string[]{"Say","Say","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4"},
new string[]{"Search","Search","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4"},
new string[]{"See","See","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4"},
new string[]{"Share","Share","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4"},
new string[]{"Shock","Shock","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4"},
new string[]{"Shop (Store)","Shop (Store)","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4"},
new string[]{"Show","Show","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4"},
new string[]{"Shut Up","Shut Up","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4"},
new string[]{"Shut Down","Shut Down","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4"},
new string[]{"Sing","Sing","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4"},
new string[]{"Sit","Sit","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4"},
new string[]{"Smell","Smell","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4"},
new string[]{"Smile","Smile","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4"},
new string[]{"Smoke (Airborn)","Smoke (Airborn)","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4"},
new string[]{"Speak / Talk","Speak / Talk","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4"},
new string[]{"Spell / Fingerspell","Spell / Fingerspell","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4"},
new string[]{"Spit","Spit","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4"},
new string[]{"Stand","Stand","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4"},
new string[]{"Start","Start","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4"},
new string[]{"Stay","Stay","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4"},
new string[]{"Steal","Steal","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4"},
new string[]{"Stop","Stop","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4"},
new string[]{"Study","Study","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4"},
new string[]{"Suffer","Suffer","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4"},
new string[]{"Swim","Swim","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4"},
new string[]{"Switch","Switch","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4"},
new string[]{"Take (From)","Take (From)","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4"},
new string[]{"Communicate","Communicate","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4"},
new string[]{"Tell","Tell","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4"},
new string[]{"Test","Test","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4"},
new string[]{"Text","Text","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4"},
new string[]{"Think","Think","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4"},
new string[]{"Throw","Throw","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4"},
new string[]{"Tie","Tie","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4"},
new string[]{"Truth","Truth","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4"},
new string[]{"Try","Try","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4"},
},
new string[][]{//Lesson 17(Verbs & Actions p8)
new string[]{"Type","Type","https://vrsignlanguage.net/ASL_videos/sheet17/17-01.mp4"},
new string[]{"Turn","Turn","https://vrsignlanguage.net/ASL_videos/sheet17/17-02.mp4"},
new string[]{"Upset","Upset","https://vrsignlanguage.net/ASL_videos/sheet17/17-03.mp4"},
new string[]{"Use","Use","https://vrsignlanguage.net/ASL_videos/sheet17/17-04.mp4"},
new string[]{"View","View","https://vrsignlanguage.net/ASL_videos/sheet17/17-05.mp4"},
new string[]{"Vomit","Vomit","https://vrsignlanguage.net/ASL_videos/sheet17/17-06.mp4"},
new string[]{"Wait","Wait","https://vrsignlanguage.net/ASL_videos/sheet17/17-07.mp4"},
new string[]{"Wake Up","Wake Up","https://vrsignlanguage.net/ASL_videos/sheet17/17-08.mp4"},
new string[]{"War","War","https://vrsignlanguage.net/ASL_videos/sheet17/17-09.mp4"},
new string[]{"Warn","Warn","https://vrsignlanguage.net/ASL_videos/sheet17/17-10.mp4"},
new string[]{"Waste","Waste","https://vrsignlanguage.net/ASL_videos/sheet17/17-11.mp4"},
new string[]{"Wash","Wash","https://vrsignlanguage.net/ASL_videos/sheet17/17-12.mp4"},
new string[]{"Watch","Watch","https://vrsignlanguage.net/ASL_videos/sheet17/17-13.mp4"},
new string[]{"Wear","Wear","https://vrsignlanguage.net/ASL_videos/sheet17/17-14.mp4"},
new string[]{"Wobble","Wobble","https://vrsignlanguage.net/ASL_videos/sheet17/17-15.mp4"},
new string[]{"Wonder","Wonder","https://vrsignlanguage.net/ASL_videos/sheet17/17-16.mp4"},
new string[]{"Worry","Worry","https://vrsignlanguage.net/ASL_videos/sheet17/17-17.mp4"},
new string[]{"Work","Work","https://vrsignlanguage.net/ASL_videos/sheet17/17-18.mp4"},
new string[]{"Hug","Hug","https://vrsignlanguage.net/ASL_videos/sheet17/17-19.mp4"},
new string[]{"Touch","Touch","https://vrsignlanguage.net/ASL_videos/sheet17/17-20.mp4"},
new string[]{"Kiss","Kiss","https://vrsignlanguage.net/ASL_videos/sheet17/17-21.mp4"},
new string[]{"Trust","Trust","https://vrsignlanguage.net/ASL_videos/sheet17/17-22.mp4"},
new string[]{"True","True","https://vrsignlanguage.net/ASL_videos/sheet17/17-23.mp4"},
new string[]{"Lie","Lie","https://vrsignlanguage.net/ASL_videos/sheet17/17-24.mp4"},
new string[]{"Serve","Serve","https://vrsignlanguage.net/ASL_videos/sheet17/17-25.mp4"},
new string[]{"Calculate","Calculate","https://vrsignlanguage.net/ASL_videos/sheet17/17-26.mp4"},
new string[]{"Shower","Shower","https://vrsignlanguage.net/ASL_videos/sheet17/17-27.mp4"},
new string[]{"Bathe","Bathe","https://vrsignlanguage.net/ASL_videos/sheet17/17-28.mp4"},
new string[]{"Socialize","Socialize","https://vrsignlanguage.net/ASL_videos/sheet17/17-29.mp4"},
new string[]{"Help / Assist","Help / Assist","https://vrsignlanguage.net/ASL_videos/sheet17/17-30.mp4"},
new string[]{"Support","Support","https://vrsignlanguage.net/ASL_videos/sheet17/17-31.mp4"},
new string[]{"Take Care","Take Care","https://vrsignlanguage.net/ASL_videos/sheet17/17-32.mp4"},
new string[]{"Drive","Drive","https://vrsignlanguage.net/ASL_videos/sheet17/17-33.mp4"},
new string[]{"Travel","Travel","https://vrsignlanguage.net/ASL_videos/sheet17/17-34.mp4"},
new string[]{"Trip","Trip","https://vrsignlanguage.net/ASL_videos/sheet17/17-35.mp4"},
new string[]{"Fiction","Fiction","https://vrsignlanguage.net/ASL_videos/sheet17/17-36.mp4"},
},
new string[][]{//Lesson 18(Food)
new string[]{"Corn","Corn","https://vrsignlanguage.net/ASL_videos/sheet18/18-01.mp4"},
new string[]{"Vegetable","Vegetable","https://vrsignlanguage.net/ASL_videos/sheet18/18-02.mp4"},
new string[]{"Cookie","Cookie","https://vrsignlanguage.net/ASL_videos/sheet18/18-03.mp4"},
new string[]{"Cake","Cake","https://vrsignlanguage.net/ASL_videos/sheet18/18-04.mp4"},
new string[]{"Yogurt","Yogurt","https://vrsignlanguage.net/ASL_videos/sheet18/18-05.mp4"},
new string[]{"Lemon","Lemon","https://vrsignlanguage.net/ASL_videos/sheet18/18-06.mp4"},
new string[]{"Nuts","Nuts","https://vrsignlanguage.net/ASL_videos/sheet18/18-07.mp4"},
new string[]{"Grapes","Grapes","https://vrsignlanguage.net/ASL_videos/sheet18/18-08.mp4"},
new string[]{"Peas","Peas","https://vrsignlanguage.net/ASL_videos/sheet18/18-09.mp4"},
new string[]{"Icecream","Icecream","https://vrsignlanguage.net/ASL_videos/sheet18/18-10.mp4"},
new string[]{"Pear","Pear","https://vrsignlanguage.net/ASL_videos/sheet18/18-11.mp4"},
new string[]{"Butter","Butter","https://vrsignlanguage.net/ASL_videos/sheet18/18-12.mp4"},
new string[]{"Banana","Banana","https://vrsignlanguage.net/ASL_videos/sheet18/18-13.mp4"},
new string[]{"Pumpkin","Pumpkin","https://vrsignlanguage.net/ASL_videos/sheet18/18-14.mp4"},
new string[]{"Fruit","Fruit","https://vrsignlanguage.net/ASL_videos/sheet18/18-15.mp4"},
new string[]{"Apple","Apple","https://vrsignlanguage.net/ASL_videos/sheet18/18-16.mp4"},
new string[]{"Tomato","Tomato","https://vrsignlanguage.net/ASL_videos/sheet18/18-17.mp4"},
new string[]{"Orange","Orange","https://vrsignlanguage.net/ASL_videos/sheet18/18-18.mp4"},
new string[]{"Bread","Bread","https://vrsignlanguage.net/ASL_videos/sheet18/18-19.mp4"},
new string[]{"Cheese","Cheese","https://vrsignlanguage.net/ASL_videos/sheet18/18-20.mp4"},
new string[]{"Water","Water","https://vrsignlanguage.net/ASL_videos/sheet18/18-21.mp4"},
new string[]{"Hamburger","Hamburger","https://vrsignlanguage.net/ASL_videos/sheet18/18-22.mp4"},
new string[]{"Hot dog","Hot dog","https://vrsignlanguage.net/ASL_videos/sheet18/18-23.mp4"},
new string[]{"Sandwich","Sandwich","https://vrsignlanguage.net/ASL_videos/sheet18/18-24.mp4"},
new string[]{"Taco","Taco","https://vrsignlanguage.net/ASL_videos/sheet18/18-25.mp4"},
new string[]{"Noodles","Noodles","https://vrsignlanguage.net/ASL_videos/sheet18/18-26.mp4"},
new string[]{"Eggs","Eggs","https://vrsignlanguage.net/ASL_videos/sheet18/18-27.mp4"},
new string[]{"Salt","Salt","https://vrsignlanguage.net/ASL_videos/sheet18/18-28.mp4"},
new string[]{"Meat","Meat","https://vrsignlanguage.net/ASL_videos/sheet18/18-29.mp4"},
new string[]{"Carrot","Carrot","https://vrsignlanguage.net/ASL_videos/sheet18/18-30.mp4"},
new string[]{"Cabbage","Cabbage","https://vrsignlanguage.net/ASL_videos/sheet18/18-31.mp4"},
new string[]{"Spaghetti","Spaghetti","https://vrsignlanguage.net/ASL_videos/sheet18/18-32.mp4"},
new string[]{"Pizza","Pizza","https://vrsignlanguage.net/ASL_videos/sheet18/18-33.mp4"},
new string[]{"Sushi","Sushi","https://vrsignlanguage.net/ASL_videos/sheet18/18-34.mp4"},
new string[]{"Potato","Potato","https://vrsignlanguage.net/ASL_videos/sheet18/18-35.mp4"},
new string[]{"Juice","Juice","https://vrsignlanguage.net/ASL_videos/sheet18/18-36.mp4"},
new string[]{"Cola","Cola","https://vrsignlanguage.net/ASL_videos/sheet18/18-37.mp4"},
new string[]{"Beer","Beer","https://vrsignlanguage.net/ASL_videos/sheet18/18-38.mp4"},
new string[]{"Wine","Wine","https://vrsignlanguage.net/ASL_videos/sheet18/18-39.mp4"},
new string[]{"Champagne","Champagne","https://vrsignlanguage.net/ASL_videos/sheet18/18-40.mp4"},
new string[]{"Milk","Milk","https://vrsignlanguage.net/ASL_videos/sheet18/18-41.mp4"},
new string[]{"Sugar","Sugar","https://vrsignlanguage.net/ASL_videos/sheet18/18-42.mp4"},
},
new string[][]{//Lesson 19(Animals / Machines)
new string[]{"Dog","Dog",""},
new string[]{"Cat","Cat",""},
new string[]{"Fox","Fox",""},
new string[]{"Cow","Cow",""},
new string[]{"Sheep","Sheep",""},
new string[]{"Duck","Duck",""},
new string[]{"Fly","Fly",""},
new string[]{"Chicken","Chicken",""},
new string[]{"Owl","Owl",""},
new string[]{"Bird","Bird",""},
new string[]{"Mouse","Mouse",""},
new string[]{"Bear","Bear",""},
new string[]{"Lion","Lion",""},
new string[]{"Cricket","Cricket",""},
new string[]{"Dragon","Dragon",""},
new string[]{"Rabbit","Rabbit",""},
new string[]{"Turtle","Turtle",""},
new string[]{"Pig","Pig",""},
new string[]{"Squirrel","Squirrel",""},
new string[]{"Raccoon","Raccoon",""},
new string[]{"Fish","Fish",""},
new string[]{"Rocket","Rocket",""},
new string[]{"Generator","Generator",""},
new string[]{"Car","Car",""},
new string[]{"Truck","Truck",""},
new string[]{"Bike","Bike",""},
new string[]{"Motorcycle","Motorcycle",""},
new string[]{"Train","Train",""},
new string[]{"Robot","Robot",""},
new string[]{"Spaceship","Spaceship",""},
new string[]{"Aircraft","Aircraft",""},
new string[]{"Helicopter","Helicopter",""},
new string[]{"Bus","Bus",""},
new string[]{"Ship","Ship",""},
new string[]{"Bulldozer","Bulldozer",""},
new string[]{"Crane","Crane",""},
new string[]{"Machine","Machine",""},
new string[]{"Drilling Machine","Drilling Machine",""},
new string[]{"Elevator","Elevator",""},
new string[]{"Cyborg","Cyborg",""},
new string[]{"Tank","Tank",""},
new string[]{"Submarine","Submarine",""},
},
new string[][]{//Lesson 20(Places)
new string[]{"Bathroom","Bathroom",""},
new string[]{"Room","Room",""},
new string[]{"City","City",""},
new string[]{"House","House",""},
new string[]{"Skyscraper","Skyscraper",""},
new string[]{"Apartment","Apartment",""},
new string[]{"Tower","Tower",""},
new string[]{"Village","Village",""},
new string[]{"Sewer","Sewer",""},
new string[]{"Cellar","Cellar",""},
new string[]{"Storage","Storage",""},
new string[]{"Pool","Pool",""},
new string[]{"Sea","Sea",""},
new string[]{"Island","Island",""},
new string[]{"Sun","Sun",""},
new string[]{"Moon","Moon",""},
new string[]{"Sky","Sky",""},
new string[]{"Space","Space",""},
new string[]{"Milky Way","Milky Way",""},
new string[]{"Heaven","Heaven",""},
new string[]{"Hell","Hell",""},
new string[]{"Graveyard","Graveyard",""},
new string[]{"Garden","Garden",""},
new string[]{"Beach","Beach",""},
new string[]{"Coast","Coast",""},
new string[]{"Sea","Sea",""},
new string[]{"Garbage Dump","Garbage Dump",""},
new string[]{"Castle","Castle",""},
new string[]{"Cathedral","Cathedral",""},
new string[]{"Church","Church",""},
new string[]{"Store","Store",""},
new string[]{"Butchery","Butchery",""},
new string[]{"Prison","Prison",""},
new string[]{"Police Station","Police Station",""},
new string[]{"Hospital","Hospital",""},
new string[]{"Firestation","Firestation",""},
new string[]{"Hotel","Hotel",""},
new string[]{"Airport","Airport",""},
new string[]{"Harbor","Harbor",""},
new string[]{"Road","Road",""},
new string[]{"Crossing","Crossing",""},
new string[]{"Railway","Railway",""},
},
new string[][]{//Lesson 21(Stuff / Weather)
new string[]{"Wood","Wood",""},
new string[]{"Metal","Metal",""},
new string[]{"Glass","Glass",""},
new string[]{"Liquid","Liquid",""},
new string[]{"Electricity","Electricity",""},
new string[]{"Powder","Powder",""},
new string[]{"Feather","Feather",""},
new string[]{"Box","Box",""},
new string[]{"Container","Container",""},
new string[]{"Paper","Paper",""},
new string[]{"Pencil","Pencil",""},
new string[]{"Eraser","Eraser",""},
new string[]{"Book","Book",""},
new string[]{"Ruler","Ruler",""},
new string[]{"Hammer","Hammer",""},
new string[]{"Saw","Saw",""},
new string[]{"Sander","Sander",""},
new string[]{"Scissors","Scissors",""},
new string[]{"Pincer","Pincer",""},
new string[]{"Stick","Stick",""},
new string[]{"Rake","Rake",""},
new string[]{"Shovel","Shovel",""},
new string[]{"Axe","Axe",""},
new string[]{"Hook","Hook",""},
new string[]{"Chain","Chain",""},
new string[]{"Storm","Storm",""},
new string[]{"Hurricane","Hurricane",""},
new string[]{"Earthquake","Earthquake",""},
new string[]{"Dark","Dark",""},
new string[]{"Light","Light",""},
new string[]{"Clouds","Clouds",""},
new string[]{"Fire","Fire",""},
new string[]{"Ice","Ice",""},
new string[]{"Rain","Rain",""},
new string[]{"Flood","Flood",""},
new string[]{"Smoke","Smoke",""},
new string[]{"Fog","Fog",""},
new string[]{"Snow","Snow",""},
new string[]{"Freeze","Freeze",""},
new string[]{"Hot","Hot",""},
new string[]{"Humidity","Humidity",""},
new string[]{"Lighting","Lighting",""},
},
new string[][]{//Lesson 22(Clothes / Equipment)
new string[]{"Dress","Dress",""},
new string[]{"Pants","Pants",""},
new string[]{"Jeans","Jeans",""},
new string[]{"Shorts","Shorts",""},
new string[]{"Swimming Trunks","Swimming Trunks",""},
new string[]{"Bikini","Bikini",""},
new string[]{"Miniskirt","Miniskirt",""},
new string[]{"Underwear","Underwear",""},
new string[]{"Bra","Bra",""},
new string[]{"Diapers","Diapers",""},
new string[]{"Shirt","Shirt",""},
new string[]{"Sweater","Sweater",""},
new string[]{"Hat","Hat",""},
new string[]{"High Heels","High Heels",""},
new string[]{"Scarf","Scarf",""},
new string[]{"Raincoat","Raincoat",""},
new string[]{"Jacket","Jacket",""},
new string[]{"Umbrella","Umbrella",""},
new string[]{"Gloves","Gloves",""},
new string[]{"Uniform","Uniform",""},
new string[]{"Overalls","Overalls",""},
new string[]{"Mask","Mask",""},
new string[]{"Cap","Cap",""},
new string[]{"Glasses","Glasses",""},
new string[]{"Goggles","Goggles",""},
new string[]{"Helmet","Helmet",""},
new string[]{"Socks","Socks",""},
new string[]{"Shoes","Shoes",""},
new string[]{"Boots","Boots",""},
new string[]{"Sandals","Sandals",""},
new string[]{"Backpack","Backpack",""},
new string[]{"Bag","Bag",""},
new string[]{"Suitcase","Suitcase",""},
new string[]{"Belt","Belt",""},
new string[]{"Sportswear","Sportswear",""},
new string[]{"Jumpsuit","Jumpsuit",""},
new string[]{"Jewelry","Jewelry",""},
new string[]{"Ring","Ring",""},
new string[]{"Bracelet","Bracelet",""},
new string[]{"Badge","Badge",""},
new string[]{"Necklace","Necklace",""},
new string[]{"Earring","Earring",""},
},
new string[][]{//Lesson 23(Fantasy / Characters)
new string[]{"Sword","Sword",""},
new string[]{"Shield","Shield",""},
new string[]{"Weapon","Weapon",""},
new string[]{"Cannon","Cannon",""},
new string[]{"Stick","Stick",""},
new string[]{"Magic","Magic",""},
new string[]{"Money","Money",""},
new string[]{"Ghost","Ghost",""},
new string[]{"Zombie","Zombie",""},
new string[]{"Undead","Undead",""},
new string[]{"Soldier","Soldier",""},
new string[]{"Police","Police",""},
new string[]{"Nurse","Nurse",""},
new string[]{"Fireman","Fireman",""},
new string[]{"Wizard","Wizard",""},
new string[]{"Sorcerer","Sorcerer",""},
new string[]{"Hunter","Hunter",""},
new string[]{"Male","Male",""},
new string[]{"Female","Female",""},
new string[]{"Human","Human",""},
new string[]{"Dwarf","Dwarf",""},
new string[]{"Elf","Elf",""},
new string[]{"Orc","Orc",""},
new string[]{"Tauren","Tauren",""},
new string[]{"Monster","Monster",""},
new string[]{"Gnome","Gnome",""},
new string[]{"Troll","Troll",""},
new string[]{"Health","Health",""},
new string[]{"Mana","Mana",""},
new string[]{"Energy","Energy",""},
new string[]{"Power","Power",""},
new string[]{"Armor","Armor",""},
new string[]{"Resistance","Resistance",""},
new string[]{"Resurrect","Resurrect",""},
new string[]{"Rage","Rage",""},
new string[]{"Casting","Casting",""},
new string[]{"Shooting","Shooting",""},
new string[]{"Damage","Damage",""},
new string[]{"Healing","Healing",""},
new string[]{"Melee","Melee",""},
new string[]{"Ammo","Ammo",""},
new string[]{"Ranged","Ranged",""},
},
new string[][]{//Lesson 24(Holidays / Special Days)
new string[]{"Holiday","Holiday",""},
new string[]{"Pentecost","Pentecost",""},
new string[]{"Christmas","Christmas",""},
new string[]{"Easter","Easter",""},
new string[]{"New Year's Day","New Year's Day",""},
new string[]{"New Year's Eve","New Year's Eve",""},
new string[]{"Ascension Day","Ascension Day",""},
new string[]{"Labor Day","Labor Day",""},
new string[]{"Columbus Day","Columbus Day",""},
new string[]{"Veterans Day","Veterans Day",""},
new string[]{"Thanksgiving Day","Thanksgiving Day",""},
new string[]{"Memorial Day","Memorial Day",""},
new string[]{"M. Luther King, Jr. Day","M. Luther King, Jr. Day",""},
new string[]{"Presidents' Day","Presidents' Day",""},
new string[]{"St. Andrew's Day","St. Andrew's Day",""},
new string[]{"St. David's Day","St. David's Day",""},
new string[]{"Father's Day","Father's Day",""},
new string[]{"Mother's Day","Mother's Day",""},
new string[]{"Independence Day","Independence Day",""},
new string[]{"National Day","National Day",""},
new string[]{"Valentine's Day","Valentine's Day",""},
new string[]{"White Day","White Day",""},
new string[]{"Black Friday","Black Friday",""},
new string[]{"Cyber Monday","Cyber Monday",""},
new string[]{"Golden Week","Golden Week",""},
new string[]{"Doll's Festival (Hina Matsuri)","Doll's Festival (Hina Matsuri)",""},
new string[]{"Coming of Age Day","Coming of Age Day",""},
new string[]{"Culture Day","Culture Day",""},
new string[]{"Children's Day","Children's Day",""},
new string[]{"Seollal Holiday","Seollal Holiday",""},
new string[]{"Chinese New Year","Chinese New Year",""},
new string[]{"Groundhog Day","Groundhog Day",""},
new string[]{"Carnival","Carnival",""},
new string[]{"Holloween","Holloween",""},
new string[]{"St. Patrick's Day","St. Patrick's Day",""},
new string[]{"Parent's Day","Parent's Day",""},
},
new string[][]{//Lesson 25(Home stuff)
new string[]{"Chair","Chair",""},
new string[]{"Bench","Bench",""},
new string[]{"Couch","Couch",""},
new string[]{"Table","Table",""},
new string[]{"Desktop Computer","Desktop Computer",""},
new string[]{"Closet","Closet",""},
new string[]{"Toilet","Toilet",""},
new string[]{"Door","Door",""},
new string[]{"Window","Window",""},
new string[]{"Ceiling","Ceiling",""},
new string[]{"Roof","Roof",""},
new string[]{"Floor / Carpet","Floor / Carpet",""},
new string[]{"Safe","Safe",""},
new string[]{"Stairs","Stairs",""},
new string[]{"Television","Television",""},
new string[]{"Radio","Radio",""},
new string[]{"Microphone","Microphone",""},
new string[]{"Guitar","Guitar",""},
new string[]{"Guitar (Variant 2)","Guitar (Variant 2)",""},
new string[]{"Drum Kit","Drum Kit",""},
new string[]{"Headphones","Headphones",""},
new string[]{"Earbuds","Earbuds",""},
new string[]{"Washing Machine","Washing Machine",""},
new string[]{"Refrigerator","Refrigerator",""},
new string[]{"Dryer","Dryer",""},
new string[]{"Broom","Broom",""},
new string[]{"Sweeper","Sweeper",""},
new string[]{"Sink","Sink",""},
new string[]{"Dishwasher","Dishwasher",""},
new string[]{"Oven","Oven",""},
new string[]{"Fork","Fork",""},
new string[]{"Knife","Knife",""},
new string[]{"Spoon","Spoon",""},
new string[]{"Bowl","Bowl",""},
new string[]{"Plate","Plate",""},
new string[]{"Wall Outlet","Wall Outlet",""},
new string[]{"Bath","Bath",""},
new string[]{"Shower","Shower",""},
new string[]{"Fireplace","Fireplace",""},
new string[]{"Fireplace (Variant 2)","Fireplace (Variant 2)",""},
new string[]{"Air Conditioner","Air Conditioner",""},
},
new string[][]{//Lesson 26(Nature / Environment)
new string[]{"Nature","Nature",""},
new string[]{"Environment","Environment",""},
new string[]{"Flower","Flower",""},
new string[]{"Grass","Grass",""},
new string[]{"Tree","Tree",""},
new string[]{"Sand","Sand",""},
new string[]{"Soil","Soil",""},
new string[]{"Waterfall","Waterfall",""},
new string[]{"Hills","Hills",""},
new string[]{"Cave","Cave",""},
new string[]{"Pine","Pine",""},
new string[]{"Oak","Oak",""},
new string[]{"Sunflower","Sunflower",""},
new string[]{"Bush","Bush",""},
new string[]{"Dam","Dam",""},
new string[]{"Bridge","Bridge",""},
new string[]{"Ocean","Ocean",""},
new string[]{"Lake","Lake",""},
new string[]{"Pond","Pond",""},
new string[]{"River","River",""},
new string[]{"Rainbow","Rainbow",""},
new string[]{"Forest","Forest",""},
new string[]{"Wilderness","Wilderness",""},
new string[]{"Geology","Geology",""},
new string[]{"Ecology","Ecology",""},
new string[]{"Evolution","Evolution",""},
new string[]{"Matter","Matter",""},
new string[]{"Lava","Lava",""},
new string[]{"Structure","Structure",""},
new string[]{"Rocks","Rocks",""},
new string[]{"Atmosphere","Atmosphere",""},
new string[]{"Climate","Climate",""},
new string[]{"Oxygen","Oxygen",""},
new string[]{"Hydrogen","Hydrogen",""},
new string[]{"Water Vapor","Water Vapor",""},
new string[]{"Ecosystem","Ecosystem",""},
new string[]{"Life","Life",""},
new string[]{"Biology","Biology",""},
new string[]{"Organisms","Organisms",""},
new string[]{"Reproduction","Reproduction",""},
new string[]{"Growth","Growth",""},
new string[]{"Microbes","Microbes",""},
},
new string[][]{//Lesson 27(Talk / Asking exercises)
new string[]{"Can you teach me?","Can you teach me?",""},
new string[]{"Sorry, I don't understand.","Sorry, I don't understand.",""},
new string[]{"I want to learn sign language.","I want to learn sign language.",""},
new string[]{"My name is.","My name is.",""},
new string[]{"Please wait for it.","Please wait for it.",""},
new string[]{"My friend wants to join.","My friend wants to join.",""},
new string[]{"I want to play with you.","I want to play with you.",""},
new string[]{"I'm slow at learning.","I'm slow at learning.",""},
new string[]{"Can you repeat it?","Can you repeat it?",""},
new string[]{"Shall we begin?","Shall we begin?",""},
new string[]{"I'm busy streaming.","I'm busy streaming.",""},
new string[]{"Please don't distrub me.","Please don't distrub me.",""},
new string[]{"Can you stop that?","Can you stop that?",""},
new string[]{"Please follow me.","Please follow me.",""},
new string[]{"I want to change the world.","I want to change the world.",""},
new string[]{"Can you write it down?","Can you write it down?",""},
new string[]{"Please don't speak.","Please don't speak.",""},
new string[]{"I can't hear you.","I can't hear you.",""},
new string[]{"What are the rules?","What are the rules?",""},
new string[]{"Can you explain that to me?","Can you explain that to me?",""},
new string[]{"Can you help me?","Can you help me?",""},
new string[]{"Please lead me.","Please lead me.",""},
new string[]{"I have a good idea.","I have a good idea.",""},
new string[]{"I'm not feeling good.","I'm not feeling good.",""},
new string[]{"How old are you?","How old are you?",""},
new string[]{"Where do you come from?","Where do you come from?",""},
new string[]{"Do you want to be my friend?","Do you want to be my friend?",""},
new string[]{"I'm going to sleep.","I'm going to sleep.",""},
new string[]{"I have to work soon.","I have to work soon.",""},
new string[]{"What is your Discord?","What is your Discord?",""},
new string[]{"Can we talk on Discord?","Can we talk on Discord?",""},
new string[]{"Check your Discord.","Check your Discord.",""},
new string[]{"I am lost here.","I am lost here.",""},
new string[]{"I'm going to my friend's.","I'm going to my friend's.",""},
new string[]{"I have some free time now.","I have some free time now.",""},
new string[]{"I don't have much time.","I don't have much time.",""},
},
new string[][]{//Lesson 28(Name sign users)
new string[]{"Sio","Sio","https://vrsignlanguage.net/ASL_videos/sheet28/28-01.mp4"},
new string[]{"MrDummy_NED","MrDummy_NED","https://vrsignlanguage.net/ASL_videos/sheet28/28-02.mp4"},
new string[]{"Wardragon","Wardragon","https://vrsignlanguage.net/ASL_videos/sheet28/28-03.mp4"},
new string[]{"QQuentin","QQuentin","https://vrsignlanguage.net/ASL_videos/sheet28/28-04.mp4"},
new string[]{"Ray_is_deaf","Ray_is_deaf","https://vrsignlanguage.net/ASL_videos/sheet28/28-05.mp4"},
new string[]{"CTLucina","CTLucina","https://vrsignlanguage.net/ASL_videos/sheet28/28-06.mp4"},
new string[]{"Fazzion","Fazzion","https://vrsignlanguage.net/ASL_videos/sheet28/28-07.mp4"},
new string[]{"Jenny0629","Jenny0629","https://vrsignlanguage.net/ASL_videos/sheet28/28-08.mp4"},
new string[]{"Wubbles","Wubbles","https://vrsignlanguage.net/ASL_videos/sheet28/28-09.mp4"},
new string[]{"Sqweekslj","Sqweekslj","https://vrsignlanguage.net/ASL_videos/sheet28/28-10.mp4"},
new string[]{"Freddex1337","Freddex1337","https://vrsignlanguage.net/ASL_videos/sheet28/28-11.mp4"},
new string[]{"Max DEAF FR","Max DEAF FR","https://vrsignlanguage.net/ASL_videos/sheet28/28-12.mp4"},
new string[]{"Korea_Saro","Korea_Saro","https://vrsignlanguage.net/ASL_videos/sheet28/28-13.mp4"},
new string[]{"_MINT_","_MINT_","https://vrsignlanguage.net/ASL_videos/sheet28/28-14.mp4"},
new string[]{"Divamage","Divamage","https://vrsignlanguage.net/ASL_videos/sheet28/28-15.mp4"},
new string[]{"DeafDragon22","DeafDragon22","https://vrsignlanguage.net/ASL_videos/sheet28/28-16.mp4"},
new string[]{"Cha714_Deaf","Cha714_Deaf","https://vrsignlanguage.net/ASL_videos/sheet28/28-17.mp4"},
new string[]{"AlexDeafHero","AlexDeafHero","https://vrsignlanguage.net/ASL_videos/sheet28/28-18.mp4"},
new string[]{"Papa Thelius","Papa Thelius","https://vrsignlanguage.net/ASL_videos/sheet28/28-19.mp4"},
new string[]{"DalekTheGamer","DalekTheGamer","https://vrsignlanguage.net/ASL_videos/sheet28/28-20.mp4"},
new string[]{"Fearlesskoolaid","Fearlesskoolaid","https://vrsignlanguage.net/ASL_videos/sheet28/28-21.mp4"},
new string[]{"Korea_Yujin","Korea_Yujin","https://vrsignlanguage.net/ASL_videos/sheet28/28-22.mp4"},
new string[]{"Mute Raven","Mute Raven","https://vrsignlanguage.net/ASL_videos/sheet28/28-23.mp4"},
new string[]{"Ailuro","Ailuro","https://vrsignlanguage.net/ASL_videos/sheet28/28-24.mp4"},
new string[]{"Robyn / QueenHidi","Robyn / QueenHidi","https://vrsignlanguage.net/ASL_videos/sheet28/28-25.mp4"},
new string[]{"CraftyHayley","CraftyHayley","https://vrsignlanguage.net/ASL_videos/sheet28/28-26.mp4"},
new string[]{"[ DEAF-2030 ]","[ DEAF-2030 ]","https://vrsignlanguage.net/ASL_videos/sheet28/28-27.mp4"},
new string[]{"Catman2010","Catman2010","https://vrsignlanguage.net/ASL_videos/sheet28/28-28.mp4"},
new string[]{"Danyy59","Danyy59","https://vrsignlanguage.net/ASL_videos/sheet28/28-29.mp4"},
new string[]{"Darkers","Darkers","https://vrsignlanguage.net/ASL_videos/sheet28/28-30.mp4"},
new string[]{"Yun Big Eater","Yun Big Eater","https://vrsignlanguage.net/ASL_videos/sheet28/28-31.mp4"},
new string[]{"Deaf_Danielo_89","Deaf_Danielo_89","https://vrsignlanguage.net/ASL_videos/sheet28/28-32.mp4"},
new string[]{"UnrealPanda","UnrealPanda","https://vrsignlanguage.net/ASL_videos/sheet28/28-33.mp4"},
new string[]{"Mr_Voodoo","Mr_Voodoo","https://vrsignlanguage.net/ASL_videos/sheet28/28-34.mp4"},
new string[]{"GT4tube","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet28/28-35.mp4"},
new string[]{"CathDeafGamer","CathDeafGamer","https://vrsignlanguage.net/ASL_videos/sheet28/28-36.mp4"},
new string[]{"Angél","Angél","https://vrsignlanguage.net/ASL_videos/sheet28/28-37.mp4"},
new string[]{"RomainDEAF","RomainDEAF","https://vrsignlanguage.net/ASL_videos/sheet28/28-38.mp4"},
new string[]{"Peppers","Peppers","https://vrsignlanguage.net/ASL_videos/sheet28/28-39.mp4"},
new string[]{"Taboot62","Taboot62","https://vrsignlanguage.net/ASL_videos/sheet28/28-40.mp4"},
new string[]{"Ja_Hyuni","Ja_Hyuni","https://vrsignlanguage.net/ASL_videos/sheet28/28-41.mp4"},
new string[]{"MrRikuG935","MrRikuG935","https://vrsignlanguage.net/ASL_videos/sheet28/28-42.mp4"},
},
new string[][]{//Lesson 29(Countries)
new string[]{"World","World",""},
new string[]{"Europe","Europe",""},
new string[]{"Asia","Asia",""},
new string[]{"Country","Country",""},
new string[]{"North America","North America",""},
new string[]{"Central America","Central America",""},
new string[]{"South America","South America",""},
new string[]{"America / USA","America / USA",""},
new string[]{"Canada","Canada",""},
new string[]{"Mexico","Mexico",""},
new string[]{"Spain","Spain",""},
new string[]{"France","France",""},
new string[]{"England","England",""},
new string[]{"Netherlands","Netherlands",""},
new string[]{"Germany","Germany",""},
new string[]{"Scandinavia","Scandinavia",""},
new string[]{"Middle East","Middle East",""},
new string[]{"Australia","Australia",""},
new string[]{"Japan","Japan",""},
new string[]{"China","China",""},
new string[]{"South Korea","South Korea",""},
new string[]{"Russia","Russia",""},
new string[]{"New Zealand","New Zealand",""},
new string[]{"Brazil","Brazil",""},
new string[]{"Poland","Poland",""},
new string[]{"Turkey","Turkey",""},
new string[]{"Israel","Israel",""},
new string[]{"Egypt","Egypt",""},
new string[]{"Africa","Africa",""},
new string[]{"South Africa","South Africa",""},
new string[]{"Norway","Norway",""},
new string[]{"Sweden","Sweden",""},
new string[]{"Finland","Finland",""},
new string[]{"Austria","Austria",""},
new string[]{"Italy","Italy",""},
new string[]{"Portugal","Portugal",""},
new string[]{"Romania","Romania",""},
new string[]{"Saudi Arabia","Saudi Arabia",""},
new string[]{"Ireland","Ireland",""},
new string[]{"Scotland","Scotland",""},
},
new string[][]{//Lesson 30(Colors)
new string[]{"Color","Color",""},
new string[]{"White","White",""},
new string[]{"Black","Black",""},
new string[]{"Red","Red",""},
new string[]{"Blue","Blue",""},
new string[]{"Green","Green",""},
new string[]{"Brown","Brown",""},
new string[]{"Pink","Pink",""},
new string[]{"Purple","Purple",""},
new string[]{"Yellow","Yellow",""},
new string[]{"Orange","Orange",""},
new string[]{"Gold","Gold",""},
new string[]{"Silver","Silver",""},
new string[]{"Transparent","Transparent",""},
new string[]{"Gray","Gray",""},
new string[]{"Light","Light",""},
new string[]{"Dark","Dark",""},
new string[]{"Light Blue","Light Blue",""},
new string[]{"Dark Blue","Dark Blue",""},
new string[]{"Tan","Tan",""},
new string[]{"Blond","Blond",""},
new string[]{"Gas","Gas",""},
new string[]{"Oil","Oil",""},
new string[]{"Glow","Glow",""},
new string[]{"Wood","Wood",""},
new string[]{"Metal","Metal",""},
new string[]{"Aluminium","Aluminium",""},
new string[]{"Fabric","Fabric",""},
new string[]{"Glass","Glass",""},
new string[]{"Paper","Paper",""},
new string[]{"Plastic","Plastic",""},
new string[]{"Rubber","Rubber",""},
new string[]{"Foil","Foil",""},
new string[]{"Clay","Clay",""},
new string[]{"Water","Water",""},
new string[]{"Gel","Gel",""},
new string[]{"Sticker","Sticker",""},
new string[]{"Rope","Rope",""},
new string[]{"Wire","Wire",""},
new string[]{"Cotton","Cotton",""},
new string[]{"Air","Air",""},
},
new string[][]{//Lesson 31(Medical)
new string[]{"Doctor","Doctor",""},
new string[]{"Nurse","Nurse",""},
new string[]{"Hospital","Hospital",""},
new string[]{"Sick","Sick",""},
new string[]{"Hurt","Hurt",""},
new string[]{"Fever","Fever",""},
new string[]{"Diarrhea","Diarrhea",""},
new string[]{"Vomit","Vomit",""},
new string[]{"Healthy","Healthy",""},
new string[]{"Better","Better",""},
new string[]{"Recover","Recover",""},
new string[]{"Pill","Pill",""},
new string[]{"Dead (Variant 2)","Dead (Variant 2)",""},
new string[]{"Brain","Brain",""},
new string[]{"Receipt","Receipt",""},
new string[]{"Headache","Headache",""},
new string[]{"Stomachache","Stomachache",""},
new string[]{"Pain","Pain",""},
new string[]{"Bone Fracture","Bone Fracture",""},
new string[]{"Wheelchair","Wheelchair",""},
new string[]{"Stretcher","Stretcher",""},
new string[]{"Dentist","Dentist",""},
new string[]{"Band Aid","Band Aid",""},
new string[]{"Bandage","Bandage",""},
new string[]{"Wound","Wound",""},
new string[]{"Blood","Blood",""},
new string[]{"Crutch","Crutch",""},
new string[]{"Eye","Eye",""},
new string[]{"Ears","Ears",""},
new string[]{"Nose","Nose",""},
new string[]{"Arm","Arm",""},
new string[]{"Legs","Legs",""},
new string[]{"Breast","Breast",""},
new string[]{"Belly","Belly",""},
new string[]{"Mouth","Mouth",""},
new string[]{"Finger","Finger",""},
new string[]{"Elbow","Elbow",""},
new string[]{"Knee","Knee",""},
new string[]{"Ankle","Ankle",""},
new string[]{"Spine","Spine",""},
new string[]{"Skeleton","Skeleton",""},
new string[]{"Skin","Skin",""},
}};
        static string[][][][] AllLessons = { DGSlessons }; //adds array of arrays into another array for easy looping.

        //lessonnames[x][y][z]
        //x=languagenumber
        //y=lessonnumber
        //z=lessonname translation, 0=english, 1=german

        //0th value is the English translation of the lesson
        //1st value is the German translation of the lesson
        static string[][][] lessonnames ={
    new string[][]{
        new string[]{"Daily Use","Täglicher Gebrauch"},
        new string[]{"Pointing use Question / Answer","Hinweis auf Frage / Antwort"},
        new string[]{"Common","Allgemein"},
        new string[]{"People","Menschen"},
        new string[]{"Feelings / Reactions","Gefühle / Reaktionen"},
        new string[]{"Value","Wert"},
        new string[]{"Time","Zeit"},
        new string[]{"VRChat","VRChat"},
        new string[]{"Alphabet/Numbers","Alphabet / Zahlen"},
        new string[]{"Verbs & Actions p1","Verben & Aktionen p1"},
        new string[]{"Verbs & Actions p2: Ben-Cor","Verben & Aktionen p2: Ben-Cor"},
        new string[]{"Verbs & Actions p3: Cou-Esc","Verben & Aktionen p3: Cou-Esc"},
        new string[]{"Verbs & Actions p4: Exc-Ins","Verben & Aktionen p4: Exc-Ins"},
        new string[]{"Verbs & Actions p5: Int-Pas","Verben & Aktionen p5: Int-Pas"},
        new string[]{"Verbs & Actions p6: Pat-Sav","Verben & Aktionen p6: Pat-Sav"},
        new string[]{"Verbs & Actions p7: Say-Try","Verben & Aktionen p7: Say-Try "},
        new string[]{"Verbs & Actions p8","Verben & Aktionen p8"},
        new string[]{"Food","Essen"},
        new string[]{"Animals / Machines","Tiere / Maschinen"},
        new string[]{"Places","Orte"},
        new string[]{"Stuff / Weather","Sachen / Wetter"},
        new string[]{"Clothes / Equipment","Kleidung / Ausrüstung"},
        new string[]{"Fantasy / Characters","Fantasie / Charaktere"},
        new string[]{"Holidays/Special Days","Feiertage / besondere Tage"},
        new string[]{"Home stuff","Heimzeug"},
        new string[]{"Nature / Environment","Natur / Umwelt"},
        new string[]{"Talk/Asking exercises","Sprech- / Fragübungen"},
        new string[]{"Name sign users","Namensschildbenutzer"},
        new string[]{"Countries","Länder"},
        new string[]{"Colors","Farben"},
        new string[]{"Medical","Medizin"},
    }
};
        static string[][] signlanguagenames = {
        new string[]{"DGS","German Sign Language\nDeutsche Gebärdensprache"}
        };

        [MenuItem("ASLWorld/DGSButtonV5")]
        static void DGSButtonV5()
        {
            //declare uiresource settings
            DefaultControls.Resources uiresources = new DefaultControls.Resources();
            uiresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
            //uiresources.checkmark=AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
            uiresources.checkmark = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Great_32.png");
            uiresources.dropdown = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/DropdownArrow.psd");
            uiresources.inputField = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
            uiresources.knob = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");
            uiresources.mask = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UIMask.psd");
            uiresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");



            Vector3 menurootpos = new Vector3(-29.45f, 4.5f, 25);
            int layer = 8;
            Vector2 zerovector2 = new Vector2(0, 0);

            //DefaultControls.Resources txtresources = new DefaultControls.Resources();
            //DefaultControls.Resources rootpanelresources = new DefaultControls.Resources();
            //rootpanelresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
            //Declare some variables + settings.
            Navigation no_nav = new Navigation();
            no_nav.mode = Navigation.Mode.None;

            GameObject rootmenu = new GameObject("Menu Root");
            //create sign display canvas/panel/text
            GameObject rootmenucanvas = new GameObject("Menu Root Canvas");//create canvas for current sign display
            rootmenucanvas.transform.SetParent(rootmenu.transform, false);
            rootmenucanvas.layer = layer;
            rootmenucanvas.GetOrAddComponent<RectTransform>().localPosition = new Vector3(.5f, .135f, 16);
            rootmenucanvas.GetOrAddComponent<RectTransform>().sizeDelta = new Vector2(2000, 265);
            rootmenucanvas.transform.localScale = new Vector3(.001f, .001f, .001f);
            rootmenucanvas.GetOrAddComponent<RectTransform>().anchorMin = new Vector2(.5f, .5f);
            rootmenucanvas.GetOrAddComponent<RectTransform>().anchorMax = new Vector2(.5f, .5f);
            rootmenucanvas.GetOrAddComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
            rootmenucanvas.GetOrAddComponent<Canvas>(); //adds canvas to root canvas gameobject
            rootmenucanvas.GetOrAddComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            rootmenucanvas.GetOrAddComponent<CanvasScaler>();
            rootmenucanvas.GetOrAddComponent<GraphicRaycaster>();
            rootmenucanvas.GetOrAddComponent<VRC_UiShape>();
            GameObject rootmenucanvaspanel = DefaultControls.CreatePanel(uiresources);
            rootmenucanvaspanel.transform.SetParent(rootmenucanvas.transform, false);
            rootmenucanvaspanel.layer = layer;
            rootmenucanvaspanel.name = "Current Sign Panel";
            rootmenucanvaspanel.GetOrAddComponent<Image>().color = new Color(1, 1, 1, 1);
            rootmenucanvaspanel.GetOrAddComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            rootmenucanvaspanel.GetOrAddComponent<RectTransform>().sizeDelta = new Vector2(2000, 265);
            rootmenucanvaspanel.GetOrAddComponent<RectTransform>().anchorMin = new Vector2(.5f, .5f);
            rootmenucanvaspanel.GetOrAddComponent<RectTransform>().anchorMax = new Vector2(.5f, .5f);
            rootmenucanvaspanel.GetOrAddComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
            GameObject rootmenucanvaspaneltext = DefaultControls.CreateText(uiresources);
            rootmenucanvaspaneltext.transform.SetParent(rootmenucanvaspanel.transform, false);
            rootmenucanvaspaneltext.name = "Current Sign Text";
            rootmenucanvaspaneltext.layer = layer;
            rootmenucanvaspaneltext.GetOrAddComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            rootmenucanvaspaneltext.GetOrAddComponent<RectTransform>().sizeDelta = new Vector2(2000, 265);
            rootmenucanvaspaneltext.GetOrAddComponent<RectTransform>().anchorMin = new Vector2(.5f, .5f);
            rootmenucanvaspaneltext.GetOrAddComponent<RectTransform>().anchorMax = new Vector2(.5f, .5f);
            rootmenucanvaspaneltext.GetOrAddComponent<Text>().text = "The sign that's currently playing will show here.\nDas Zeichen, das gerade abgespielt wird, wird hier angezeigt.";
            rootmenucanvaspaneltext.GetOrAddComponent<Text>().alignment = TextAnchor.MiddleCenter;
            rootmenucanvaspaneltext.GetOrAddComponent<Text>().fontSize = 70;
            rootmenucanvaspaneltext.GetOrAddComponent<Text>().resizeTextMaxSize = 70;
            rootmenucanvaspaneltext.GetOrAddComponent<Text>().resizeTextMinSize = 50;
            rootmenucanvaspaneltext.GetOrAddComponent<Text>().resizeTextForBestFit = true;

            //"/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text"

            //why create two copies? Too hard to sync all the different active/inactive gameobjects if everyone isn't on the same "page".
            GameObject globalmenu = CreateMenu(rootmenu, MODE_GLOBAL);
            GameObject localmenu = CreateMenu(rootmenu, MODE_LOCAL);

            rootmenu.GetOrAddComponent<Transform>().localPosition = menurootpos;


            /*****************************************
            Update preferences menu to point to newly created objects.
            *****************************************/
            //recreate toggle to fix reference?
            /*
                Toggle oldvideotoggle = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Video Toggle").GetOrAddComponent<Toggle>();
                DestroyImmediate(oldvideotoggle);
                Toggle newvideotoggle = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Video Toggle").GetOrAddComponent<Toggle>();
                newvideotoggle.navigation = no_nav;
                newvideotoggle.isOn = true;
                newvideotoggle.graphic=newvideotoggle.transform.Find("Background").gameObject.transform.Find("Checkmark").GetComponent<Image>();
                newvideotoggle.transition= Selectable.Transition.None;
                newvideotoggle.toggleTransition= Toggle.ToggleTransition.None;
                newvideotoggle.onValueChanged = new Toggle.ToggleEvent();
                UnityEventTools.AddPersistentListener(newvideotoggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>),
                GameObject.Find("/Menu Root/Local Menu Root/Local Video Container"), "SetActive") as UnityAction<bool>);

                UnityEventTools.AddPersistentListener(newvideotoggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>),
                GameObject.Find("/Menu Root/Global Menu Root/Global Video Container"), "SetActive") as UnityAction<bool>);

                //Cleanup existing triggers to reference global/local container
                DestroyImmediate(GameObject.Find ("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Global Mode/Background/Global Helper").GetOrAddComponent<VRC_Trigger>());

                VRC_Trigger newglobalhelpertrigger = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Global Mode/Background/Global Helper").GetOrAddComponent<VRC_Trigger>();
                newglobalhelpertrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
                    new VRC_Trigger.TriggerEvent{
                        BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                        TriggerType = VRC_Trigger.TriggerType.OnEnable,
                        TriggerIndividuals = true,
                        Events=new List<VRC_EventHandler.VrcEvent>(){
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=localmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=globalmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                ParameterString = "The sign that's currently playing will show here.",
                                ParameterObject = GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text")
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                ParameterString = "Do not use this world to learn yet. These motions are a Anonymous",
                                ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                ParameterString = "Description of movements here. (Slowly being added)",
                                ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
                            },
                        }
                    },
                    new VRC_Trigger.TriggerEvent{
                        BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                        TriggerType = VRC_Trigger.TriggerType.OnDisable,
                        TriggerIndividuals = true,
                        Events=new List<VRC_EventHandler.VrcEvent>(){
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=localmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=globalmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                ParameterString = "The sign that's currently playing will show here.",
                                ParameterObject = GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text")
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                ParameterString = "Don't use this world to learn yet.",
                                ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                ParameterString = "Description of movements here. (Slowly being added)",
                                ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
                            }
                        }
                    }
                };*/

            globalmenu.SetActive(false);

        }
        static GameObject CreateMenu(GameObject parent, string mode)
        {
            //declare uiresource settings
            DefaultControls.Resources uiresources = new DefaultControls.Resources();
            uiresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
            //uiresources.checkmark=AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
            uiresources.checkmark = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/VRCSDK/Dependencies/VRChat/Resources/PerformanceIcons/Perf_Great_32.png");
            uiresources.dropdown = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/DropdownArrow.psd");
            uiresources.inputField = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
            uiresources.knob = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");
            uiresources.mask = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UIMask.psd");
            uiresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");

            /*
                //declare toggle resource settings
                DefaultControls.Resources toggleresources = new DefaultControls.Resources();
                //Set the Toggle Background Image someBgSprite;
                toggleresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
                //Set the Toggle Checkmark Image someCheckmarkSprite;
                toggleresources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
                DefaultControls.Resources rootpanelresources = new DefaultControls.Resources();
                rootpanelresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
                DefaultControls.Resources txtresources = new DefaultControls.Resources();
            */
            int layer = 8;
            //int rowoffset=860;
            int columnoffset = 200;

            int rowseperation = 150;
            int columnseperation = 1000;
            int togglesizedelta = 80;
            int numberpercolumn = 9;
            int menusizex = 5200;
            int menusizey = 1600;
            int headersizey = 60;
            int textpadding = 10;
            int headerbuttonspacing = 100;
            int buttonsizey = 130;
            int buttonsizex = 950;
            int menubuttonystart = textpadding + headersizey + buttonsizey + 80;
            Vector2 backbuttonsize = new Vector2(menusizey - headersizey - textpadding - headerbuttonspacing, 100);

            Vector2 buttonsize = new Vector2(buttonsizex, buttonsizey);
            Vector2 menusize = new Vector2(menusizex, menusizey);
            Vector3 menurootposition = new Vector3(1.5f, 0, 16);
            Vector3 canvasscale = new Vector3(.001f, .001f, .001f);
            Vector2 zerovector2 = new Vector2(0, 0);
            Vector3 zerovector3 = new Vector3(0, 0, 0);

            Navigation no_nav = new Navigation();
            no_nav.mode = Navigation.Mode.None;

            /*****************************************
            START OF PROGRAM
            *****************************************/

            GameObject menuroot = new GameObject(mode + " Menu Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
            menuroot.transform.position = menurootposition;
            menuroot.transform.SetParent(parent.transform, false);
            menuroot.layer = layer;

            GameObject triggercontainer = new GameObject(mode + " Trigger Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
            triggercontainer.transform.SetParent(menuroot.transform, false);//maybe this needs to reparented to menuroot?
            triggercontainer.layer = layer;

            GameObject videocontainer = new GameObject(mode + " Video Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
                                                                                   //videocontainer.transform.position = new Vector3(-1f, 1, 0);
            videocontainer.transform.SetParent(menuroot.transform, false);
            videocontainer.layer = layer;

            GameObject rootcanvas = new GameObject(mode + " Root Canvas");
            rootcanvas.transform.SetParent(menuroot.transform, false);
            rootcanvas.layer = layer;
            rootcanvas.transform.localScale = canvasscale;
            rootcanvas.AddComponent<RectTransform>();
            rootcanvas.GetComponent<RectTransform>().localPosition = zerovector3;
            rootcanvas.GetComponent<RectTransform>().sizeDelta = menusize;
            rootcanvas.GetComponent<RectTransform>().anchorMax = zerovector2;
            rootcanvas.GetComponent<RectTransform>().anchorMin = zerovector2;
            rootcanvas.GetComponent<RectTransform>().pivot = zerovector2;
            //rootcanvas.AddComponent<Canvas> (); //adds canvas to root canvas gameobject
            rootcanvas.GetOrAddComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            rootcanvas.AddComponent<CanvasScaler>();
            rootcanvas.AddComponent<GraphicRaycaster>();
            rootcanvas.AddComponent<VRC_UiShape>();
            ToggleGroup rootcanvastogglegroup = rootcanvas.AddComponent<ToggleGroup>();
            rootcanvastogglegroup.allowSwitchOff = true;

            GameObject rootpanel = DefaultControls.CreatePanel(uiresources);
            rootpanel.transform.SetParent(rootcanvas.transform, false);
            rootpanel.layer = layer;
            rootpanel.GetComponent<RectTransform>().sizeDelta = menusize;
            rootpanel.GetComponent<RectTransform>().anchorMax = zerovector2;
            rootpanel.GetComponent<RectTransform>().anchorMin = zerovector2;
            rootpanel.GetComponent<RectTransform>().pivot = zerovector2;
            //rootpanel.GetComponent<Image> ().color = new Color(1,1,1,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
            if (mode == MODE_GLOBAL)
            {
                rootpanel.GetComponent<Image>().color = new Color(1, .90f, .90f, 1); //gets rid of transparency - also can change panel color if I want here. 1=255.
            }
            else
            {
                rootpanel.GetComponent<Image>().color = new Color(.90f, .90f, 1, 1); //gets rid of transparency - also can change panel color if I want here. 1=255.
            }

            GameObject langselectmenu = new GameObject("VR Sign Language Select Menu");
            langselectmenu.transform.SetParent(rootcanvas.transform, false);
            langselectmenu.layer = layer;

            GameObject langselectmenuheader = DefaultControls.CreateText(uiresources);
            langselectmenuheader.transform.SetParent(langselectmenu.transform, false);
            langselectmenuheader.name = "VR Sign Language Select Menu Header";
            langselectmenuheader.layer = layer;
            langselectmenuheader.GetComponent<Text>().text = "VR Sign Language Select Menu - " + mode;
            langselectmenuheader.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            langselectmenuheader.GetComponent<Text>().fontStyle = FontStyle.Bold;
            langselectmenuheader.GetComponent<Text>().fontSize = 50;
            langselectmenuheader.GetComponent<Text>().color = Color.black;
            langselectmenuheader.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            langselectmenuheader.GetComponent<RectTransform>().sizeDelta = new Vector2(menusizex, headersizey);
            langselectmenuheader.GetComponent<RectTransform>().anchoredPosition = new Vector2(textpadding, menusizey - headersizey - textpadding);
            langselectmenuheader.GetComponent<RectTransform>().anchorMax = zerovector2;
            langselectmenuheader.GetComponent<RectTransform>().anchorMin = zerovector2;
            langselectmenuheader.GetComponent<RectTransform>().pivot = zerovector2;

            /*****************************************
            MAIN LANGUAGE LOOP HERE
            *****************************************/
            int langmenucolumn = 0;
            int langmenurow = 0;
            for (int languagenum = 0; languagenum < AllLessons.Length; languagenum++) //for every language in signlanguages do this once:
            {
                if (languagenum != 0)
                {
                    if (languagenum % numberpercolumn == 0)
                    { //display 9 items per column
                        langmenucolumn++;
                        langmenurow = 0;
                    }
                }
                /*
                                    var wordlookup = new Dictionary<string, int>();
                                    //int dictlessonnum=1;
                                    //int dictwordnum=1;
                                    int dictwordnumber=1;//since idle=0
                                    foreach(var lesson in AllLessons[languagenum]){
                                        foreach(var word in lesson){
                                            int value;
                                            if (!wordlookup.TryGetValue(word[0], out value)) {
                                                wordlookup.Add(word[0],dictwordnumber);
                                                //Debug.Log("Added: "+"ASL-"+word[0]);
                                                dictwordnumber++;
                                            }else{
                                                Debug.Log("Warning when building dictionary: Word already exists: "+word[0]);
                                            }

                                            //dictwordnum++;
                                        }
                                        //dictlessonnum++;
                                    }
                */
                GameObject languagetriggercontainer = new GameObject(signlanguagenames[languagenum][0] + " Trigger Container"); //create language container for a given language to house global triggers.
                languagetriggercontainer.transform.SetParent(triggercontainer.transform, false);
                languagetriggercontainer.layer = layer;
                VRC_Trigger languagetriggercontainertrigger = languagetriggercontainer.AddComponent<VRC_Trigger>();
                languagetriggercontainertrigger.Triggers = new List<VRC_Trigger.TriggerEvent>();
                if (mode == MODE_LOCAL)
                {
                    DestroyImmediate(languagetriggercontainer);
                }

                GameObject langvideocontainer = new GameObject(signlanguagenames[languagenum][0] + " Video Container");
                langvideocontainer.transform.position = new Vector3(0, 0, 0);
                langvideocontainer.transform.SetParent(videocontainer.transform, false);
                langvideocontainer.layer = layer;

                //create a root gameobject for each language
                GameObject langroot = new GameObject(signlanguagenames[languagenum][0] + " Root"); //creates language container for a given language.
                langroot.transform.SetParent(rootcanvas.transform, false);
                langroot.layer = layer;

                //create language select button
                GameObject langselectgo = createbutton2(mode: "numtext2", parent: langselectmenu, name: signlanguagenames[languagenum][1], sizedelta: buttonsize,
                localPosition: new Vector3(columnoffset + (langmenucolumn * columnseperation), menusizey - headersizey - textpadding - buttonsizey - headerbuttonspacing - (langmenurow * rowseperation), 0),
                text1: signlanguagenames[languagenum][1], fontSize: 50, txtsizedelta: buttonsize, txtanchoredPosition: new Vector2(20, 0),
                alignment: TextAnchor.MiddleLeft, nav: no_nav, layer: layer);

                //Create lesson sub-menu for nested loop to parent buttons to.
                GameObject lessonmenu = new GameObject(signlanguagenames[languagenum][0] + " Lesson Menu");
                lessonmenu.transform.SetParent(langroot.transform, false);
                lessonmenu.layer = layer;
                //Create lesson menu header
                GameObject lessonselectmenuheader = DefaultControls.CreateText(uiresources);
                lessonselectmenuheader.transform.SetParent(lessonmenu.transform, false);
                lessonselectmenuheader.name = signlanguagenames[languagenum][0] + " Lesson Menu Header";
                lessonselectmenuheader.layer = layer;
                lessonselectmenuheader.GetComponent<Text>().text = "VR-" + signlanguagenames[languagenum][0] + " Sign Language - Lesson Menu - " + mode + " (Green = Videos Available.) (Red = No Videos Yet)";
                lessonselectmenuheader.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                lessonselectmenuheader.GetComponent<Text>().fontStyle = FontStyle.Bold;
                lessonselectmenuheader.GetComponent<Text>().fontSize = 50;
                lessonselectmenuheader.GetComponent<Text>().color = Color.black;
                lessonselectmenuheader.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                lessonselectmenuheader.GetComponent<RectTransform>().sizeDelta = new Vector2(menusizex, headersizey);
                lessonselectmenuheader.GetComponent<RectTransform>().anchoredPosition = new Vector2(textpadding, menusizey - headersizey - textpadding);
                lessonselectmenuheader.GetComponent<RectTransform>().anchorMax = zerovector2;
                lessonselectmenuheader.GetComponent<RectTransform>().anchorMin = zerovector2;
                lessonselectmenuheader.GetComponent<RectTransform>().pivot = zerovector2;
                langmenurow++;
                /*****************************************
                MAIN LESSON LOOP HERE
                *****************************************/
                int menucolumn = 0;
                int menurow = 0;
                for (int lessonnum = 0; lessonnum < AllLessons[languagenum].Length; lessonnum++)
                { //for every lesson inside of ASLlessons do:

                    GameObject lessontriggercontainer = new GameObject(signlanguagenames[languagenum][0] + " L" + (lessonnum + 1) + " Trigger Container"); //create lesson container for a given language to house global triggers.

                    lessontriggercontainer.layer = layer;
                    VRC_Trigger lessontriggercontainertrigger = lessontriggercontainer.AddComponent<VRC_Trigger>();
                    lessontriggercontainertrigger.Triggers = new List<VRC_Trigger.TriggerEvent>();
                    if (mode == MODE_GLOBAL)
                    {
                        lessontriggercontainer.transform.SetParent(languagetriggercontainer.transform, false);
                    }
                    else
                    {
                        DestroyImmediate(lessontriggercontainer);
                    }


                    if (lessonnum != 0)
                    {
                        if (lessonnum % numberpercolumn == 0)
                        { //display 9 items per column
                            menucolumn++;
                            menurow = 0;
                        }
                    }
                    //create lesson menu button here for lessonmenu.-one at a time
                    GameObject lessonbgo = createbutton2(mode: "numtext2", parent: lessonmenu, name: signlanguagenames[languagenum][0] + " L" + (lessonnum + 1) + "(" + lessonnames[languagenum][lessonnum][0] + ") - Button", sizedelta: buttonsize,
                    //anchoredPosition: new Vector2(columnoffset+(menucolumn*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(menurow*rowseperation)),
                    localPosition: new Vector3(columnoffset + (menucolumn * columnseperation), menusizey - headersizey - textpadding - buttonsizey - headerbuttonspacing - (menurow * rowseperation), 0),
                    textnumber: (lessonnum + 1) + ")",
                    text1: lessonnames[languagenum][lessonnum][0] + "\n" + lessonnames[languagenum][lessonnum][1], fontSize: 50, txtsizedelta: buttonsize, txtanchoredPosition: new Vector2(120, 0),
                    alignment: TextAnchor.MiddleLeft, nav: no_nav, layer: layer);
                    Button b = lessonbgo.GetOrAddComponent<Button>();
                    b.onClick = new Button.ButtonClickedEvent();
                    //colors the buttons to indicate what's working and what's not.
                    var defaultcolors = b.colors;
                    defaultcolors.normalColor = new Color32(0xFF, 0x98, 0x98, 0xFF); //FF9898FF light red
                    b.colors = defaultcolors;

                    if ((lessonnum + 1) <= 2)
                    {
                        var colors = b.colors;
                        colors.normalColor = new Color32(0x98, 0xFF, 0x98, 0xFF); //FF9898FF light green
                        b.colors = colors;
                    }
                    /*
					if((lessonnum+1)>=2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0xFF, 0x98, 0xFF ); //FF9898FF light yellow
						b.colors = colors;
					}*/
                    menurow++;
                    //create lesson x gameobject eg: ASL Lesson x
                    GameObject lessongo = new GameObject(signlanguagenames[languagenum][0] + " Lesson " + (lessonnum + 1));
                    lessongo.transform.SetParent(langroot.transform, false);
                    lessongo.layer = layer;

                    //create lesson x header
                    GameObject lessongoheader = DefaultControls.CreateText(uiresources);
                    lessongoheader.transform.SetParent(lessongo.transform, false);
                    lessongoheader.name = signlanguagenames[languagenum][0] + " Lesson " + (lessonnum + 1) + "- Header"; //ASL Lesson X Lesson Header
                    lessongoheader.layer = layer;
                    lessongoheader.GetComponent<Text>().text = "VR-" + signlanguagenames[languagenum][0] + " Sign Language - Lesson " + (lessonnum + 1) + " - " + lessonnames[languagenum][lessonnum][0] + " - " + mode;
                    lessongoheader.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                    lessongoheader.GetComponent<Text>().fontStyle = FontStyle.Bold;
                    lessongoheader.GetComponent<Text>().fontSize = 50;
                    lessongoheader.GetComponent<Text>().color = Color.black;
                    lessongoheader.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                    lessongoheader.GetComponent<RectTransform>().sizeDelta = new Vector2(menusizex, headersizey);
                    lessongoheader.GetComponent<RectTransform>().anchoredPosition = new Vector2(textpadding, menusizey - headersizey - textpadding);
                    lessongoheader.GetComponent<RectTransform>().anchorMax = zerovector2;
                    lessongoheader.GetComponent<RectTransform>().anchorMin = zerovector2;
                    lessongoheader.GetComponent<RectTransform>().pivot = zerovector2;

                    //create video lesson container
                    GameObject videolessoncontainer = new GameObject(signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1));
                    videolessoncontainer.transform.SetParent(langvideocontainer.transform, false);
                    videolessoncontainer.layer = layer;

                    if (mode == MODE_GLOBAL)
                    {
                        //adds a broadcast trigger to the lesson button, which activates a trigger on a trigger container (which hopefully is active if global mode is on?)
                        VRC_Trigger lessonbuttonvrctrigger = lessonbgo.AddComponent<VRC_Trigger>();
                        lessonbuttonvrctrigger.Triggers = new List<VRC_Trigger.TriggerEvent>(){
                        new VRC_Trigger.TriggerEvent{
                            BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered,
                            TriggerType = VRC_Trigger.TriggerType.Custom,
                            TriggerIndividuals = true,
                            Name="globaltrigger",
                            Events=new List<VRC_EventHandler.VrcEvent>(){
                                new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                                    ParameterObject=lessontriggercontainer,
                                    ParameterString="L"+(lessonnum+1),
                                }
                            }
                        },
                    };

                        lessontriggercontainertrigger.Triggers.Add(
                            new VRC_Trigger.TriggerEvent
                            {
                                BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                                Name = "L" + (lessonnum + 1),
                                TriggerType = VRC_Trigger.TriggerType.Custom,
                                TriggerIndividuals = true,
                                Events = new List<VRC_EventHandler.VrcEvent>(){
                new VRC_EventHandler.VrcEvent{
                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                    ParameterObject=lessongo,
                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                },
                new VRC_EventHandler.VrcEvent{
                    EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive,
                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True,
                    ParameterObject = videolessoncontainer
                },
                new VRC_EventHandler.VrcEvent{
                    EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive,
                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False,
                    ParameterObject = lessonmenu
                }
                                }
                            }
                        );

                        UnityEventTools.AddStringPersistentListener(b.onClick,
                        System.Delegate.CreateDelegate(typeof(UnityAction<string>), lessonbuttonvrctrigger, "ExecuteCustomTrigger") as UnityAction<string>
                        , "globaltrigger");

                    }
                    else if (mode == MODE_LOCAL)
                    {

                        UnityAction<bool> enablelesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessongo, "SetActive") as UnityAction<bool>;
                        UnityEventTools.AddBoolPersistentListener(b.onClick, enablelesson, true);

                        UnityAction<bool> enablevideocontainerlesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videolessoncontainer, "SetActive") as UnityAction<bool>;
                        UnityEventTools.AddBoolPersistentListener(b.onClick, enablevideocontainerlesson, true);

                        UnityAction<bool> disablemenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessonmenu, "SetActive") as UnityAction<bool>;
                        UnityEventTools.AddBoolPersistentListener(b.onClick, disablemenu, false);
                    }

                    /*****************************************
                    MAIN WORD LOOP HERE
                    *****************************************/
                    //initialize row/columns at start of word processing to create lesson boards
                    int wordcolumn = 0;
                    int wordrow = 0;
                    for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].Length; wordnum++)
                    { //gets total rows in lesson.
                        if (wordnum != 0)
                        {

                            if ((lessonnum+1) != 28)
                            {
                                if (wordnum % numberpercolumn == 0)
                                { //display 9 items per column
                                    wordcolumn++;
                                    wordrow = 0;
                                }
                            }
                            else
                            {
                                if (wordnum % 13 == 0)
                                { //display 9 items per column
                                    wordcolumn++;
                                    wordrow = 0;
                                }
                            }
                        }

                        GameObject wordtriggercontainer = new GameObject(signlanguagenames[languagenum][0] + " L" + (lessonnum + 1) + "-W" + (wordnum + 1) + " Trigger Container"); //create lesson container for a given language to house global triggers.

                        wordtriggercontainer.layer = layer;
                        VRC_Trigger wordtriggercontainertrigger = wordtriggercontainer.AddComponent<VRC_Trigger>();
                        wordtriggercontainertrigger.Triggers = new List<VRC_Trigger.TriggerEvent>();

                        if (mode == MODE_GLOBAL)
                        {
                            wordtriggercontainer.transform.SetParent(lessontriggercontainer.transform, false);
                        }
                        else
                        {
                            DestroyImmediate(wordtriggercontainer);
                        }

                        if (mode == MODE_GLOBAL)
                        {
                            GameObject buttonoffgo;
                            if ((lessonnum + 1) == 28)
                            {//signle line
                                buttonoffgo = createbutton2(mode: "numtext", parent = lessongo, name: signlanguagenames[languagenum][0] + " " + (lessonnum + 1) + "-" + (wordnum + 1) + " - Button Off",
                                sizedelta: new Vector2(buttonsizex, 100),
                                localPosition: new Vector3(columnoffset + (wordcolumn * columnseperation), (menusizey - headersizey - textpadding - 100 - 100 - (wordrow * 100)), 0),
                                textnumber: (wordnum + 1) + ")",
                                text1: AllLessons[languagenum][lessonnum][wordnum][0],
                                txtsizedelta: new Vector2(900, 100), txtanchoredPosition: new Vector2(0, 0), alignment: TextAnchor.MiddleLeft,
                                nav: no_nav, layer: layer);
                            }
                            else
                            {//double line mode
                                buttonoffgo = createbutton2(mode: "numtext2", parent = lessongo, name: signlanguagenames[languagenum][0] + " " + (lessonnum + 1) + "-" + (wordnum + 1) + " - Button Off",
                                sizedelta: buttonsize,
                                localPosition: new Vector3(columnoffset + (wordcolumn * columnseperation), (menusizey - headersizey - textpadding - buttonsizey - 100 - (wordrow * rowseperation)), 0),
                                textnumber: (wordnum + 1) + ")",
                                text1: AllLessons[languagenum][lessonnum][wordnum][0],
                                text2: AllLessons[languagenum][lessonnum][wordnum][1],
                                txtsizedelta: new Vector2(900, 130), txtanchoredPosition: new Vector2(0, 0), alignment: TextAnchor.MiddleLeft,
                                nav: no_nav, layer: layer);
                            }


                            //Don't forget to create the "selected" button with checkmark (optional)

                            VRC_Trigger buttontriggers = buttonoffgo.AddComponent<VRC_Trigger>();
                            //I need to add triggers to nagivate late-joiners to the current menu by disabling earlier menus and enabling the lesson menu.

                            wordtriggercontainertrigger.Triggers.Add(
                                new VRC_Trigger.TriggerEvent
                                {
                                    BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                                    Name = "L" + (lessonnum + 1) + "-W" + (wordnum + 1),
                                    TriggerType = VRC_Trigger.TriggerType.Custom,
                                    TriggerIndividuals = true,
                                    Events = new List<VRC_EventHandler.VrcEvent>(){
                                    new VRC_EventHandler.VrcEvent{
                                        EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                        ParameterObject=langselectmenu,
                                        ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                                    },
                                    new VRC_EventHandler.VrcEvent{
                                        EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                        ParameterObject=langroot,
                                        ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                                    },
                                    new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObject=langvideocontainer,
                                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                                    },
                                    new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObject=videolessoncontainer,
                                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                                    },
                                    new VRC_EventHandler.VrcEvent{
                                        EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                        ParameterObject=lessonmenu,
                                        ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                                    },
                                    new VRC_EventHandler.VrcEvent{
                                        EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                        ParameterObject=lessongo,
                                        ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                                    },
                                    new VRC_EventHandler.VrcEvent{
                                        EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                        ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0],
                                        ParameterObject = GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text")
                                    }
                                    }
                                }
                            );

                            if (AllLessons[languagenum][lessonnum][wordnum][2] != "")
                            { //if url is blank, then don't create video.
                              //creates the video gameobjects
                                GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
                                videogo.name = signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1) + " S" + (wordnum + 1);
                                videogo.layer = layer;
                                videogo.transform.position = new Vector3(-1f, 0.934f, 0);
                                videogo.transform.localScale = new Vector3(2, 1.33f, 1);
                                videogo.transform.SetParent(videolessoncontainer.transform, false);
                                videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial = (Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat", typeof(Material));
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url = AllLessons[languagenum][lessonnum][wordnum][2];
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping = true;
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode = VideoRenderMode.MaterialOverride;
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode = VideoAudioOutputMode.None;
                                videogo.SetActive(false);
                                wordtriggercontainertrigger.Triggers[0].Events.Add(//there should only be one trigger to add events to on this list.
                                    new VRC_EventHandler.VrcEvent
                                    {
                                        EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                        ParameterObject = videogo,
                                        ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.True
                                    }
                                );
                            }

                            //assign unity triggers to button
                            Button buttonoffbutton = buttonoffgo.GetOrAddComponent<Button>();
                            buttonoffbutton.onClick = new Button.ButtonClickedEvent();
                            UnityAction<string> worduiaction = System.Delegate.CreateDelegate(typeof(UnityAction<string>), buttontriggers, "ExecuteCustomTrigger") as UnityAction<string>;
                            UnityEventTools.AddStringPersistentListener(buttonoffbutton.onClick, worduiaction, "L" + (lessonnum + 1) + "-W" + (wordnum + 1) + " globaltrigger");

                            buttontriggers.Triggers.Add(
                                new VRC_Trigger.TriggerEvent
                                {
                                    BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered,
                                    TriggerType = VRC_Trigger.TriggerType.Custom,
                                    TriggerIndividuals = true,
                                    Name = "L" + (lessonnum + 1) + "-W" + (wordnum + 1) + " globaltrigger",
                                    Events = new List<VRC_EventHandler.VrcEvent>(){
                        new VRC_EventHandler.VrcEvent{
                            EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                            ParameterObject=wordtriggercontainer,
                            ParameterString="L"+(lessonnum+1)+"-W"+(wordnum+1),
							//ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
						}
                                    }
                                }
                            );

                            wordrow++;

                        }//end Global word processing

                        if (mode == MODE_LOCAL)
                        {
                            //create lesson toggles
                            GameObject uiToggle = DefaultControls.CreateToggle(uiresources);
                            Toggle t = uiToggle.GetOrAddComponent<Toggle>();
                            uiToggle.gameObject.name = signlanguagenames[languagenum][0] + " " + (lessonnum + 1) + "-" + (wordnum + 1) + " - Toggle";
                            uiToggle.transform.SetParent(lessongo.transform, false);
                            uiToggle.layer = layer;
                            uiToggle.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                            uiToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2((columnoffset + (wordcolumn * columnseperation)), (menusizey - headersizey - textpadding - buttonsizey - togglesizedelta / 2 - (wordrow * rowseperation)));
                            uiToggle.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                            uiToggle.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                            uiToggle.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                            t.navigation = no_nav;
                            t.isOn = false;
                            t.transition = Selectable.Transition.None;
                            t.toggleTransition = Toggle.ToggleTransition.None;
                            t.group = rootcanvas.GetComponent<ToggleGroup>();
                            t.onValueChanged = new Toggle.ToggleEvent();
                            uiToggle.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(64, 64);
                            uiToggle.transform.Find("Background").GetComponent<RectTransform>().anchoredPosition = new Vector2(-32, -32);
                            uiToggle.transform.Find("Background").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").gameObject.layer = layer;

                            GameObject checkboxtextgo = new GameObject("Text");
                            checkboxtextgo.transform.SetParent(uiToggle.transform.Find("Background").transform, false);
                            Text checkboxtext = checkboxtextgo.AddComponent<Text>();
                            checkboxtextgo.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                            checkboxtextgo.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                            checkboxtextgo.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                            checkboxtextgo.GetComponent<RectTransform>().pivot = new Vector2(0, 0);

                            checkboxtext.alignment = TextAnchor.MiddleCenter;
                            checkboxtext.text = (wordnum + 1) + "";
                            checkboxtext.color = Color.black;
                            checkboxtext.fontSize = 40;
                            if (AllLessons[languagenum][lessonnum][wordnum][0] == AllLessons[languagenum][lessonnum][wordnum][0])
                            {
                                uiToggle.transform.Find("Label").GetComponent<Text>().text = AllLessons[languagenum][lessonnum][wordnum][0];
                            }
                            else
                            {
                                uiToggle.transform.Find("Label").GetComponent<Text>().text = AllLessons[languagenum][lessonnum][wordnum][0] + "\n" + AllLessons[languagenum][lessonnum][wordnum][1];
                            }
                            uiToggle.transform.Find("Label").GetComponent<Text>().fontSize = 50;
                            uiToggle.transform.Find("Label").GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                            uiToggle.transform.Find("Label").GetComponent<RectTransform>().sizeDelta = new Vector2(750, 130);//maybe ,64
                            uiToggle.transform.Find("Label").GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -65); //maybe ,-32
                            uiToggle.transform.Find("Label").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                            uiToggle.transform.Find("Label").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                            uiToggle.transform.Find("Label").GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                            uiToggle.transform.Find("Label").gameObject.layer = layer;

                            /*
                            GameObject label2=new GameObject("Label2");
                            label2.transform.SetParent(uiToggle.transform, false);
                            label2.layer=layer;
                            label2.GetOrAddComponent<Text>().text =AllLessons[languagenum][lessonnum][wordnum][0]+"\n"+AllLessons[languagenum][lessonnum][wordnum][1];
                            label2.GetComponent<Text>().fontSize = 50;
                            label2.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                            label2.GetOrAddComponent<RectTransform>().sizeDelta = new Vector2 (90, 130);//maybe ,64
                            label2.GetComponent<RectTransform>().anchoredPosition = new Vector2 (32,-65); //maybe ,-32
                            label2.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
                            label2.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
                            label2.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
                            */


                            uiToggle.transform.Find("Background").Find("Checkmark").GetComponent<RectTransform>().sizeDelta = new Vector2(64, 64);
                            uiToggle.transform.Find("Background").Find("Checkmark").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").Find("Checkmark").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").Find("Checkmark").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").Find("Checkmark").GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                            uiToggle.transform.Find("Background").gameObject.layer = layer;

                            uiToggle.transform.Find("Background").transform.Find("Checkmark").GetComponent<Image>().color = new Color(0, 0, 0, 1);

                            if (AllLessons[languagenum][lessonnum][wordnum][2] != "")
                            { //if url is blank, then don't create video.

                                //creates the video gameobjects
                                GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
                                videogo.name = signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1) + " S" + (wordnum + 1);
                                videogo.layer = layer;
                                videogo.transform.position = new Vector3(-1f, 0.934f, 0);
                                videogo.transform.localScale = new Vector3(2, 1.33f, 1);
                                videogo.transform.SetParent(videolessoncontainer.transform, false);
                                videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial = (Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat", typeof(Material));
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url = AllLessons[languagenum][lessonnum][wordnum][2];
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping = true;
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode = VideoRenderMode.MaterialOverride;
                                videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode = VideoAudioOutputMode.None;
                                videogo.SetActive(false);
                                UnityEventTools.AddPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
                                System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videogo//the target of the action
                                , "set_active") as UnityAction<bool>);
                            }

                            UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
                            System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>()//the target of the action
                            , "set_text") as UnityAction<string>, (lessonnum + 1) + "-" + (wordnum + 1) + ": " + AllLessons[languagenum][lessonnum][wordnum][0]);

                            wordrow++;
                        }
                    } //end local
                    /*****************************************
					End of word loop.
					*****************************************/


                    if (mode == MODE_GLOBAL)
                    {
                        //I need another loop to add all the triggers to deactivate videos for global mode
                        //these triggers belong on the helper gameobjects.
                        for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].Length; wordnum++)
                        { //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.
                            List<GameObject> listofvideos = new List<GameObject>();
                            //i need another for loop to add every single video gameobject EXCEPT the current word.
                            for (int x = 0; x < AllLessons[languagenum][lessonnum].Length; x++)
                            {
                                if (x != wordnum)
                                {//exclude the one I want to play- build list of all others in the lesson.
                                    if (GameObject.Find("/Menu Root/" + mode + " Menu Root/" + mode + " Video Container/" + signlanguagenames[languagenum][0] + " Video Container/" +
                                    signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1) + "/" +
                                    signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1) + " S" + (x + 1)))
                                    {//if it's not null then add it
                                        listofvideos.Add(GameObject.Find("/Menu Root/" + mode + " Menu Root/" + mode + " Video Container/" + signlanguagenames[languagenum][0] + " Video Container/" +
                                        signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1) + "/" +
                                        signlanguagenames[languagenum][0] + " Video L" + (lessonnum + 1) + " S" + (x + 1)));
                                    }
                                }//end exclusion loop
                            }//end for loop
                             //disables nonselected videos
                            GameObject.Find("/Menu Root/" + mode + " Menu Root/" + mode + " Trigger Container/" + signlanguagenames[languagenum][0] + " Trigger Container/"
                            + signlanguagenames[languagenum][0] + " L" + (lessonnum + 1) + " Trigger Container/" +
                            signlanguagenames[languagenum][0] + " L" + (lessonnum + 1) + "-W" + (wordnum + 1) + " Trigger Container").
                            GetComponent<VRC_Trigger>().Triggers[0].Events.Add(
                                new VRC_EventHandler.VrcEvent
                                {
                                    EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObjects = listofvideos.ToArray(),
                                    ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.False
                                }
                            );
                        }; //end for loop
                    } //endif global

                    //Create back button
                    GameObject backtolessongo = createbutton2(mode: "mainbutton", parent: lessongo, name: "Return to VR-" + signlanguagenames[languagenum][0] + " Lesson Menu", sizedelta: backbuttonsize,
                    localPosition: new Vector3(buttonsizey, 0, 0),
                    text1: "Return to VR-" + signlanguagenames[languagenum][0] + " Lesson Menu", fontSize: 50, txtsizedelta: backbuttonsize, txtanchoredPosition: new Vector2(20, 0),
                    alignment: TextAnchor.MiddleCenter, nav: no_nav, rotatez: 90, layer: layer);

                    Button backbutton = backtolessongo.GetOrAddComponent<Button>();
                    backbutton.onClick = new Button.ButtonClickedEvent();

                    if (mode == MODE_LOCAL)
                    {
                        //try disabling all the checkboxes first before doing anything else?
                        UnityAction disablealltoggles = System.Delegate.CreateDelegate(typeof(UnityAction), rootcanvastogglegroup, "SetAllTogglesOff") as UnityAction;
                        UnityEventTools.AddPersistentListener(backbutton.onClick, disablealltoggles);

                        //disable the current active lesson when clicked
                        UnityAction<bool> disablecurrentlesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessongo, "SetActive") as UnityAction<bool>;
                        UnityEventTools.AddBoolPersistentListener(backbutton.onClick, disablecurrentlesson, false);

                        //enable the lesson select
                        UnityAction<bool> enablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessonmenu, "SetActive") as UnityAction<bool>;
                        UnityEventTools.AddBoolPersistentListener(backbutton.onClick, enablelessonmenu, true);

                        UnityAction<bool> disablevideolessoncontainer = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videolessoncontainer, "SetActive") as UnityAction<bool>;
                        UnityEventTools.AddBoolPersistentListener(backbutton.onClick, disablevideolessoncontainer, false);
                    }
                    else if (mode == MODE_GLOBAL)
                    {
                        VRC_Trigger vrcbacktolessontrigger = backtolessongo.GetOrAddComponent<VRC_Trigger>();

                        vrcbacktolessontrigger.Triggers = new List<VRC_Trigger.TriggerEvent>(){
                        new VRC_Trigger.TriggerEvent{
                            BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered,
                            TriggerType = VRC_Trigger.TriggerType.Custom,
                            TriggerIndividuals = true,
                            Name="L"+(lessonnum+1)+" globaltrigger",
                            Events=new List<VRC_EventHandler.VrcEvent>(){
                                new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                                    ParameterObject=lessontriggercontainer,
                                    ParameterString="L"+(lessonnum+1)+" back button",
                                }
                            }
                        }
                    };
                        lessontriggercontainertrigger.Triggers.Add(
                                                    new VRC_Trigger.TriggerEvent
                                                    {
                                                        BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                                                        Name = "L" + (lessonnum + 1) + " back button",
                                                        TriggerType = VRC_Trigger.TriggerType.Custom,
                                                        TriggerIndividuals = true,
                                                        Events = new List<VRC_EventHandler.VrcEvent>(){
                                new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObject=lessongo,
                                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                                },
                                new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObject=lessonmenu,
                                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                                },
                                new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObject=videolessoncontainer,
                                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                                },
                                new VRC_EventHandler.VrcEvent{
                                    EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                    ParameterObject=langvideocontainer,
                                    ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                                },
                                    new VRC_EventHandler.VrcEvent{
                                        EventType = VRC_EventHandler.VrcEventType.SetUIText,
                                        ParameterString = "",
                                        ParameterObject = GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text")
                                    }
                                                    }
                                                    }//add something to disable all videos in the lesson
                        );

                        UnityEventTools.AddStringPersistentListener(backbutton.onClick,
                        System.Delegate.CreateDelegate(typeof(UnityAction<string>), vrcbacktolessontrigger, "ExecuteCustomTrigger") as UnityAction<string>,
                        "L" + (lessonnum + 1) + " globaltrigger");
                    }

                    langroot.SetActive(false);
                    lessongo.SetActive(false);
                    videolessoncontainer.SetActive(false);

                }
                /*****************************************
				End of lesson loop.
				*****************************************/

                //assign triggers after lessons created. Triggers for Language Chooser menu buttons.
                Button langselectbutton = langselectgo.GetOrAddComponent<Button>();
                langselectbutton.onClick = new Button.ButtonClickedEvent();
                if (mode == MODE_LOCAL)
                {
                    UnityAction<bool> enableaslroot = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum][0] + " Root"), "SetActive") as UnityAction<bool>;
                    UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enableaslroot, true);

                    UnityAction<bool> enableaslmenuselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum][0] + " Lesson Menu"), "SetActive") as UnityAction<bool>;//GameObject.Find("Menu Root/Root Canvas/ASL Root/ASL Lesson Menu")
                    UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enableaslmenuselect, true);

                    UnityAction<bool> disablelanguageselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), langselectmenu, "SetActive") as UnityAction<bool>;
                    UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, disablelanguageselect, false);
                    //activates video container for specific language
                    UnityAction<bool> enablevideolanguage = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), langvideocontainer, "SetActive") as UnityAction<bool>;
                    UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enablevideolanguage, true);
                }
                else if (mode == MODE_GLOBAL)
                {
                    VRC_Trigger vrclangselecttrigger = langselectgo.GetOrAddComponent<VRC_Trigger>();

                    vrclangselecttrigger.Triggers = new List<VRC_Trigger.TriggerEvent>(){
                    new VRC_Trigger.TriggerEvent{
                        BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered,
                        TriggerType = VRC_Trigger.TriggerType.Custom,
                        TriggerIndividuals = true,
                        Name="globaltrigger",
                        Events=new List<VRC_EventHandler.VrcEvent>(){
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                                ParameterObject=languagetriggercontainer,
                                ParameterString=signlanguagenames[languagenum][0]+" Trigger",
                            }
                        }
                    }
                };

                    languagetriggercontainertrigger.Triggers.Add(
                        new VRC_Trigger.TriggerEvent
                        {
                            BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                            Name = signlanguagenames[languagenum][0] + " Trigger",
                            TriggerType = VRC_Trigger.TriggerType.Custom,
                            TriggerIndividuals = true,
                            Events = new List<VRC_EventHandler.VrcEvent>(){
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=FindInActiveObjectByName(signlanguagenames[languagenum][0]+" Root"),
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=FindInActiveObjectByName(signlanguagenames[languagenum][0]+" Lesson Menu"),
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=langselectmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=langvideocontainer,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                            }
                            }
                        }
                    );
                    UnityEventTools.AddStringPersistentListener(langselectbutton.onClick,
                    System.Delegate.CreateDelegate(typeof(UnityAction<string>), vrclangselecttrigger, "ExecuteCustomTrigger") as UnityAction<string>,
                    "globaltrigger");
                }

                //Create return to Language Menu
                GameObject backtolanguagemenu = createbutton2(mode: "mainbutton", parent: lessonmenu, name: "Return to Language Menu", sizedelta: backbuttonsize,
                localPosition: new Vector3(buttonsizey, 0, 0),
                text1: "Return to Language Menu", fontSize: 50, txtsizedelta: backbuttonsize, txtanchoredPosition: new Vector2(20, 0),
                alignment: TextAnchor.MiddleCenter, nav: no_nav, rotatez: 90, layer: layer);

                Button languagebackbutton = backtolanguagemenu.GetOrAddComponent<Button>();
                languagebackbutton.onClick = new Button.ButtonClickedEvent();

                if (mode == MODE_LOCAL)
                {
                    //disable the current active lesson when back button clicked
                    UnityAction<bool> disablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessonmenu, "SetActive") as UnityAction<bool>;
                    UnityEventTools.AddBoolPersistentListener(languagebackbutton.onClick, disablelessonmenu, false);

                    //enable the lesson select  when back button clicked
                    UnityAction<bool> enablelangmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), langselectmenu, "SetActive") as UnityAction<bool>;
                    UnityEventTools.AddBoolPersistentListener(languagebackbutton.onClick, enablelangmenu, true);
                }
                else if (mode == MODE_GLOBAL)
                {
                    VRC_Trigger backtolanguagemenutrigger = backtolanguagemenu.GetOrAddComponent<VRC_Trigger>();

                    backtolanguagemenutrigger.Triggers = new List<VRC_Trigger.TriggerEvent>(){
                    new VRC_Trigger.TriggerEvent{
                        BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered,
                        TriggerType = VRC_Trigger.TriggerType.Custom,
                        TriggerIndividuals = true,
                        Name="globaltrigger",
                        Events=new List<VRC_EventHandler.VrcEvent>(){
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
                                ParameterObject=languagetriggercontainer,
                                ParameterString="backtolangselectfrom"+signlanguagenames[languagenum][0],
                            }
                        }
                    }
                };
                    languagetriggercontainertrigger.Triggers.Add(
                                        new VRC_Trigger.TriggerEvent
                                        {
                                            BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
                                            Name = "backtolangselectfrom" + signlanguagenames[languagenum][0],
                                            TriggerType = VRC_Trigger.TriggerType.Custom,
                                            TriggerIndividuals = true,
                                            Events = new List<VRC_EventHandler.VrcEvent>(){
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=langselectmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
                            },
                            new VRC_EventHandler.VrcEvent{
                                EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
                                ParameterObject=lessonmenu,
                                ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
                            }
                                            }
                                        }
                    );

                    UnityEventTools.AddStringPersistentListener(languagebackbutton.onClick,
                    System.Delegate.CreateDelegate(typeof(UnityAction<string>), backtolanguagemenutrigger, "ExecuteCustomTrigger") as UnityAction<string>,
                    "globaltrigger");
                }


                langvideocontainer.SetActive(false);
                //globaltriggercontainer.SetActive(false);

            }
            /*****************************************
            End of language loop.
            *****************************************/

            return menuroot;
        }//End of main program

        /*****************************************
        Helper Methods Below:
        *****************************************/


        static GameObject FindInActiveObjectByName(string name)
        {
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].name == name)
                    {
                        return objs[i].gameObject;
                    }
                }
            }
            return null;
        }

        //the latest button creation code. now with default values - allowing for optional arguments
        static GameObject createbutton2(string mode, GameObject parent, string name, Vector2 sizedelta, Vector3 localPosition,//Vector2 anchoredPosition
        string text1, Vector2 txtsizedelta, Vector2 txtanchoredPosition, TextAnchor alignment, Navigation nav, int layer, int rotatex = 0, int rotatey = 0, int rotatez = 0, int fontSize = 50, string textnumber = "", string text2 = "")
        {

            DefaultControls.Resources buttonresources = new DefaultControls.Resources();
            buttonresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
            //toggleresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
            GameObject go = DefaultControls.CreateButton(buttonresources);
            go.layer = layer;
            go.transform.SetParent(parent.transform, false);
            go.name = name;
            Button b = go.GetOrAddComponent<Button>();
            b.navigation = nav;

            go.GetComponent<RectTransform>().sizeDelta = sizedelta;

            go.GetComponent<RectTransform>().eulerAngles = new Vector3(rotatex, rotatey, rotatez);//x,y,z
                                                                                                  //go.GetComponent<RectTransform> ().anchoredPosition = anchoredPosition;
            go.GetComponent<RectTransform>().localPosition = localPosition;
            go.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
            go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            go.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
            switch (mode)
            {
                case "mainbutton":
                    {
						go.transform.Find("Text").GetComponent<Text>().resizeTextForBestFit = true;
                        go.transform.Find("Text").GetComponent<Text>().text = text1;
                        go.transform.Find("Text").GetComponent<Text>().fontSize = fontSize;
                        go.transform.Find("Text").GetComponent<Text>().alignment = alignment;
                        go.transform.Find("Text").GetComponent<Text>().color = Color.black;
                        go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = txtsizedelta;
                        go.transform.Find("Text").GetComponent<RectTransform>().anchoredPosition = txtanchoredPosition;
                        go.transform.Find("Text").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().pivot = new Vector2(0, 0);

                        break;
                    }
                case "numtext":
                    {
						go.transform.Find("Text").GetComponent<Text>().resizeTextForBestFit = true;
                        go.transform.Find("Text").GetComponent<Text>().text = textnumber;
                        go.transform.Find("Text").GetComponent<Text>().fontSize = 68;
                        go.transform.Find("Text").GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                        go.transform.Find("Text").GetComponent<Text>().color = Color.black;
                        go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = txtsizedelta;
                        go.transform.Find("Text").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<Text>().resizeTextForBestFit = true;
                        GameObject gotext = new GameObject("Text2");
                        gotext.layer = layer;
                        gotext.transform.SetParent(go.transform, false);
                        gotext.GetOrAddComponent<Text>().text = text1;
                        go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = txtsizedelta;
                        gotext.GetOrAddComponent<Text>().fontSize = fontSize;
                        gotext.GetOrAddComponent<Text>().alignment = alignment;
                        gotext.GetOrAddComponent<Text>().color = Color.black;
                        gotext.GetComponent<RectTransform>().sizeDelta = new Vector2(780, 100);
                        gotext.GetComponent<RectTransform>().anchoredPosition = new Vector2(120, 0);
                        gotext.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        gotext.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        gotext.GetComponent<RectTransform>().pivot = new Vector2(0, 0);

                        break;
                    }
                case "numtext2":
                    {
						go.transform.Find("Text").GetComponent<Text>().resizeTextForBestFit = true;
                        go.transform.Find("Text").GetComponent<Text>().text = textnumber;
                        go.transform.Find("Text").GetComponent<Text>().fontSize = 68;
                        go.transform.Find("Text").GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                        go.transform.Find("Text").GetComponent<Text>().color = Color.black;
                        go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = txtsizedelta;
                        go.transform.Find("Text").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<Text>().resizeTextForBestFit = true;
                        GameObject gotext = new GameObject("Text2");
                        gotext.layer = layer;
                        gotext.transform.SetParent(go.transform, false);
                        go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = new Vector2(100, 130);
                        gotext.GetOrAddComponent<Text>().text = text1 + "\n" + text2;
                        gotext.GetOrAddComponent<Text>().fontSize = fontSize;
                        gotext.GetOrAddComponent<Text>().alignment = alignment;
                        gotext.GetOrAddComponent<Text>().color = Color.black;
                        gotext.GetComponent<RectTransform>().sizeDelta = new Vector2(780, 130);
                        gotext.GetComponent<RectTransform>().anchoredPosition = new Vector2(120, 0);
                        gotext.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        gotext.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        gotext.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
                        go.transform.Find("Text").GetComponent<Text>().resizeTextForBestFit = true;
                        break;
                    }
                default:
                    break;
            }




            return go;
        }
    }
}
#endif
