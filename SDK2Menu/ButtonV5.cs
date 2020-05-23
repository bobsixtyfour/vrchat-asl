// Do not load this script when building
#if UNITY_EDITOR
//using System.Collections;
using System.Collections.Generic; //for lists if I ever use em.
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using VRCSDK2;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine.Video;
using UnityEngine.Audio;

/*
VRC_Trigger vrctrigtest = new VRC_Trigger{
	Triggers=new List<VRC_Trigger.TriggerEvent>(){
		new VRC_Trigger.TriggerEvent{
			BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
			TriggerType = VRC_Trigger.TriggerType.OnEnable,
			TriggerIndividuals = true,
			Events=new List<VRC_EventHandler.VrcEvent>(){
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
					ParameterObjects=new GameObject[] {testgo},
					ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
				}
			}
		}
	}
};
*/


namespace Bobsaslshit {
public class CreateASLButtons5 : MonoBehaviour 
{

	/*****************************************
	Start of Arrays variable declarations
	*****************************************/

	        //creates an array of arrays. Grouped by lessons. 
        //0th value is the word 
        //1st value is the name of the animation state (Used in the animation controller populator script to generate transitions - needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
        //2nd value is mocap credits. 
        //3rd value is video URL.
        //4th value is VR index or regular 0=indexonly , 1=generalvr,2=both
        //5th value is Sign description string

static 
string [][][] ASLlessons = {
new string[][]{//Lesson 1 (Daily Use)
new string[]{"Hello","ASL-Hello","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4","2",""},
new string[]{"How (are) You","ASL-How (are) You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4","2",""},
new string[]{"What's Up?","ASL-What's Up?","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","0",""},
new string[]{"What's Up? (Variant 2)","ASL-What's Up? (Variant 2)","Bob64","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","2",""},
new string[]{"Nice (to) Meet You","ASL-Nice (to) Meet You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4","2",""},
new string[]{"Good","ASL-Good","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4","2",""},
new string[]{"Bad","ASL-Bad","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4","2","1-handed version. Also can be done with two hands - see the sign for 'Good' note the palm direction."},
new string[]{"Yes","ASL-Yes","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4","2",""},
new string[]{"No","ASL-No","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4","2",""},
new string[]{"So-So","ASL-So-So","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4","2",""},
new string[]{"Sick","ASL-Sick","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","0",""},
new string[]{"Sick (Variant 2)","ASL-Sick (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","2",""},
new string[]{"Hurt","ASL-Hurt","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4","2",""},
new string[]{"You're Welcome","ASL-You're Welcome","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4","2",""},
new string[]{"Goodbye","ASL-Goodbye","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4","2",""},
new string[]{"Good Morning","ASL-Good Morning","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4","2",""},
new string[]{"Good Afternoon","ASL-Good Afternoon","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4","2",""},
new string[]{"Good Evening","ASL-Good Evening","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4","2",""},
new string[]{"Good Night","ASL-Good Night","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4","2",""},
new string[]{"See You Later","ASL-See You Later","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4","2",""},
new string[]{"Please","ASL-Please","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4","2",""},
new string[]{"Sorry","ASL-Sorry","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4","2",""},
new string[]{"Forget","ASL-Forget","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4","2",""},
new string[]{"Sleep / Sleepy","ASL-Sleep / Sleepy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4","2","Single motion for sleep. Do a double-motion for sleepy."},
new string[]{"Bed","ASL-Bed","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4","2",""},
new string[]{"Jump / Change World","ASL-Jump / Change World","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4","2",""},
new string[]{"Thank You","ASL-Thank You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4","2",""},
new string[]{"I Love You","ASL-I Love You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4","2",""},
new string[]{"ILY (I Love You)","ASL-ILY (I Love You)","GT4tube","","0","This sign is the combinations of the letters I, L, and Y. It's the abbreviated version of I Love You."},
new string[]{"Go Away","ASL-Go Away","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4","2",""},
new string[]{"Going To","ASL-Going To","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4","2","This is a directional sign. You point to where you're going."},
new string[]{"Follow","ASL-Follow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4","2",""},
new string[]{"Come","ASL-Come","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4","2",""},
new string[]{"Hearing (Person)","ASL-Hearing (Person)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4","2","Use this when discussing a person that can hear."},
new string[]{"Deaf","ASL-Deaf","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","2",""},
new string[]{"Deaf (Variant 2)","ASL-Deaf (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","2",""},
new string[]{"Hard of Hearing","ASL-Hard of Hearing","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4","2",""},
new string[]{"Mute","ASL-Mute","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4","2",""},
new string[]{"Write Slow","ASL-Write Slow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4","2",""},
new string[]{"Can't Read","ASL-Can't Read","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4","2",""},
new string[]{"Away","ASL-Away","GT4tube","","2",""}
},
new string[][]{//Lesson 2 (Pointing use Question/Answer)
new string[]{"I (Me)","ASL-I (Me)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4","2",""},
new string[]{"My","ASL-My","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4","2","Open palm implies possessive. eg: That wallet is mine."},
new string[]{"Your","ASL-Your","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4","2","A possessive form of 'you'. eg: That's your wallet."},
new string[]{"His","ASL-His","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4","2",""},
new string[]{"Her","ASL-Her","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4","2",""},
new string[]{"We","ASL-We","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4","2",""},
new string[]{"They","ASL-They","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4","2","You sweep your pointer over the people you're referring to."},
new string[]{"Their","ASL-Their","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4","2","Possessive form of they. eg: This is their house."},
new string[]{"Over There","ASL-Over There","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4","2",""},
new string[]{"Our","ASL-Our","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4","2",""},
new string[]{"It's","ASL-It's","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4","0",""},
new string[]{"Inside","ASL-Inside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4","2",""},
new string[]{"Outside","ASL-Outside","GT4tube","","2","General version of outside."},
new string[]{"Outside (Outdoors)","ASL-Outside (Outdoors)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4","2",""},
new string[]{"Hidden","ASL-Hidden","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4","2",""},
new string[]{"Behind","ASL-Behind","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4","2",""},
new string[]{"Above","ASL-Above","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4","2",""},
new string[]{"Below","ASL-Below","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4","2",""},
new string[]{"Here","ASL-Here","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4","2",""},
new string[]{"Beside","ASL-Beside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4","2",""},
new string[]{"Back","ASL-Back","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4","2",""},
new string[]{"Front","ASL-Front","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4","2",""},
new string[]{"Who","ASL-Who","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4","2",""},
new string[]{"Where","ASL-Where","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4","2",""},
new string[]{"When","ASL-When","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4","2",""},
new string[]{"Why","ASL-Why","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4","2",""},
new string[]{"Which","ASL-Which","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4","2",""},
new string[]{"What","ASL-What","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","2","This variant is perferred over variant 2, as variant 2 is a Signed Exact English Variant"},
new string[]{"What (Variant 2)","ASL-What (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","2","A Signed Exact English variant of What."},
new string[]{"How","ASL-How","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4","2",""},
new string[]{"How (Variant 2)","ASL-How (Variant 2)","GT4tube","","2","This version is done with two A-hands next to each other and a twisting motion of your dominate hand."},
new string[]{"How Many","ASL-How Many","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4","2",""},
new string[]{"How Many (Variant 2)","ASL-How Many (Variant 2)","Anonymous","","2",""},
new string[]{"Can","ASL-Can","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4","2",""},
new string[]{"Can't","ASL-Can't","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4","2",""},
new string[]{"Want","ASL-Want","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4","2",""},
new string[]{"Have","ASL-Have","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4","2",""},
new string[]{"Get","ASL-Get","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4","2",""},
new string[]{"Will / Future","ASL-Will / Future","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4","2",""},
new string[]{"Take (Up)","ASL-Take (Up)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4","2","Take as in 'Take (up) a class' or 'Take (up) a child. Like you're adopting one.'"},
new string[]{"Need","ASL-Need","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4","0","Like the sign for 'Must' except with a double motion."},
new string[]{"Must","ASL-Must","GT4tube","","0","Like the sign for 'Need', except with a single strong movement."},
new string[]{"Not","ASL-Not","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4","2",""},
new string[]{"Or","ASL-Or","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4","2","This is just 'O' and 'R' fingerspelled."},
new string[]{"And","ASL-And","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4","2",""},
new string[]{"For","ASL-For","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4","2",""},
new string[]{"At","ASL-At","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","2",""},
new string[]{"At (Variant 2)","ASL-At (Variant 2)","GT4tube","","2",""}
},
new string[][]{//Lesson 3 (Common) DarkEternal
new string[]{"Teach","ASL-Teach","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4","2","This sign can use either a double movement or a single movement. Both are fine."},
new string[]{"Learn","ASL-Learn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4","2",""},
new string[]{"Person","ASL-Person","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4","2",""},
new string[]{"Student","ASL-Student","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4","2",""},
new string[]{"Teacher","ASL-Teacher","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4","2",""},
new string[]{"Friend","ASL-Friend","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4","2","The IRL sign has your two index fingers hooking around the other."},
new string[]{"Sign","ASL-Sign","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4","2",""},
new string[]{"Language","ASL-Language","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4","2",""},
new string[]{"Understand","ASL-Understand","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4","2",""},
new string[]{"Know","ASL-Know","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4","2",""},
new string[]{"Don't Know","ASL-Don't Know","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4","2",""},
new string[]{"Be Right Back (BRB)","ASL-Be Right Back (BRB)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4","2",""},
new string[]{"Accept","ASL-Accept","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4","2",""},
new string[]{"Denied","ASL-Denied","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4","2",""},
new string[]{"Name","ASL-Name","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4","2",""},
new string[]{"New","ASL-New","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4","2",""},
new string[]{"Old","ASL-Old","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4","2",""},
new string[]{"Very","ASL-Very","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4","2",""},
new string[]{"Jokes","ASL-Jokes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4","0",""},
new string[]{"Funny","ASL-Funny","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4","2",""},
new string[]{"Play","ASL-Play","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4","0",""},
new string[]{"Favorite","ASL-Favorite","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4","0",""},
new string[]{"Draw","ASL-Draw","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4","2",""},
new string[]{"Stop","ASL-Stop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4","2",""},
new string[]{"Read","ASL-Read","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4","2",""},
new string[]{"Make","ASL-Make","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4","2",""},
new string[]{"Write","ASL-Write","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4","2",""},
new string[]{"Again / Repeat","ASL-Again / Repeat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4","2",""},
new string[]{"Slow","ASL-Slow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4","2",""},
new string[]{"Fast","ASL-Fast","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4","2",""},
new string[]{"Rude","ASL-Rude","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4","0",""},
new string[]{"Eat","ASL-Eat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4","2",""},
new string[]{"Drink","ASL-Drink","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4","2",""},
new string[]{"Watch","ASL-Watch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4","0",""},
new string[]{"Work","ASL-Work","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4","2",""},
new string[]{"Live","ASL-Live","Anonymous","","2","This version is done with 'A' handshapes on both hands."},
new string[]{"Live (Variant 2)","ASL-GT4tube-Live","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4","2","Initialized variant, done with 'L' handshapes on both hands."},
new string[]{"Play Game","ASL-Play Game","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4","0",""},
new string[]{"Same","ASL-Same","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4","0","This is a directional sign."},
new string[]{"Alright","ASL-Alright","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4","2",""},
new string[]{"People","ASL-People","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4","0",""},
new string[]{"Browsing the Internet","ASL-Browsing the Internet","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4","0",""},
new string[]{"Movie","ASL-Movie","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4","2",""}
},
new string[][]{//Lesson 4 (People)
new string[]{"Family","ASL-Family","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4","0",""},
new string[]{"Boy","ASL-Boy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4","2",""},
new string[]{"Girl","ASL-Girl","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4","2",""},
new string[]{"Brother","ASL-Brother","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4","2",""},
new string[]{"Sister","ASL-Sister","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4","2",""},
new string[]{"Brother-in-law","ASL-Brother-in-law","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4","2",""},
new string[]{"Sister-in-law","ASL-Sister-in-law","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4","2",""},
new string[]{"Father","ASL-Father","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4","2",""},
new string[]{"Grandpa","ASL-Grandpa","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4","2",""},
new string[]{"Mother","ASL-Mother","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4","2",""},
new string[]{"Grandma","ASL-Grandma","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4","0",""},
new string[]{"Baby","ASL-Baby","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4","2",""},
new string[]{"Child","ASL-Child","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4","2",""},
new string[]{"Teen","ASL-Teen","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4","2",""},
new string[]{"Adult","ASL-Adult","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4","2",""},
new string[]{"Aunt","ASL-Aunt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4","2",""},
new string[]{"Uncle","ASL-Uncle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4","2",""},
new string[]{"Stranger","ASL-Stranger","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4","2",""},
new string[]{"Acquaintance","ASL-Acquaintance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4","2","A person you know."},
new string[]{"Parents","ASL-Parents","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4","2",""},
new string[]{"Born","ASL-Born","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4","2",""},
new string[]{"Dead","ASL-Dead","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4","2",""},
new string[]{"Marriage","ASL-Marriage","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4","2",""},
new string[]{"Divorce","ASL-Divorce","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4","2",""},
new string[]{"Single","ASL-Single","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4","2",""},
new string[]{"Young","ASL-Young","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4","2",""},
new string[]{"Old","ASL-Old","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4","2",""},
new string[]{"Age","ASL-Age","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4","2",""},
new string[]{"Birthday","ASL-Birthday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4","0",""},
new string[]{"Celebrate","ASL-Celebrate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4","0",""},
new string[]{"Enemy","ASL-Enemy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4","2",""},
new string[]{"Interpreter","ASL-Interpreter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4","0",""},
new string[]{"No One","ASL-No One","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4","2",""},
new string[]{"Anyone","ASL-Anyone","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4","2",""},
new string[]{"Someone","ASL-Someone","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4","0","Similar motion to 'Always'. Someone is done with a small circle."},
new string[]{"Everyone","ASL-Everyone","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4","0",""}
},
new string[][]{//Lesson 5 (Feelings/Reactions)
new string[]{"Like","ASL-Like","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4","0",""},
new string[]{"Hate","ASL-Hate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4","0",""},
new string[]{"Fine","ASL-Fine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4","2",""},
new string[]{"Tired","ASL-Tired","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4","2",""},
new string[]{"Sleep / Sleepy","ASL-Sleep / Sleepy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4","2","Single motion for sleep. Do a double-motion for sleepy."},
new string[]{"Confused","ASL-Confused","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4","2",""},
new string[]{"Smart","ASL-Smart","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4","0",""},
new string[]{"Attention / Focus","ASL-Attention / Focus","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4","2",""},
new string[]{"Nevermind","ASL-Nevermind","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4","2",""},
new string[]{"Angry","ASL-Angry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4","2",""},
new string[]{"Laughing","ASL-Laughing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4","2",""},
new string[]{"LOL","ASL-LOL","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4","2",""},
new string[]{"Curious","ASL-Curious","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4","0",""},
new string[]{"In Love","ASL-In Love","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4","2",""},
new string[]{"Awesome","ASL-Awesome","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4","2",""},
new string[]{"Great","ASL-Great","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4","2",""},
new string[]{"Nice","ASL-Nice","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4","2",""},
new string[]{"Cute","ASL-Cute","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4","2",""},
new string[]{"Feel","ASL-Feel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4","0",""},
new string[]{"Pity","ASL-Pity","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4","0",""},
new string[]{"Envy","ASL-Envy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4","2",""},
new string[]{"Hungry","ASL-Hungry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4","2",""},
new string[]{"Alive","ASL-Alive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4","2",""},
new string[]{"Bored","ASL-Bored","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4","2",""},
new string[]{"Cry","ASL-Cry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4","2",""},
new string[]{"Happy","ASL-Happy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4","2",""},
new string[]{"Sad","ASL-Sad","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4","2",""},
new string[]{"Suffering","ASL-Suffering","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4","2",""},
new string[]{"Surprised","ASL-Surprised","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4","2",""},
new string[]{"Careful","ASL-Careful","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4","0",""},
new string[]{"Enjoy","ASL-Enjoy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4","2",""},
new string[]{"Disgusted","ASL-Disgusted","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4","2",""},
new string[]{"Embarassed","ASL-Embarassed","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4","2",""},
new string[]{"Shy","ASL-Shy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4","2",""},
new string[]{"Lonely","ASL-Lonely","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4","2",""},
new string[]{"Stressed","ASL-Stressed","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4","2",""},
new string[]{"Scared","ASL-Scared","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4","2",""},
new string[]{"Excited","ASL-Excited","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4","0",""},
new string[]{"Shame","ASL-Shame","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4","2",""},
new string[]{"Struggle","ASL-Struggle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4","2",""},
new string[]{"Friendly","ASL-Friendly","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4","2",""},
new string[]{"Mean","ASL-Mean","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4","2",""}
},
new string[][]{//Lesson 6 (Value) 
new string[]{"More","ASL-More","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4","2",""},
new string[]{"Less","ASL-Less","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4","2",""},
new string[]{"Big","ASL-Big","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4","2",""},
new string[]{"Small / A Little","ASL-Small / A Little","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4","2",""},
new string[]{"Full","ASL-Full","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4","2",""},
new string[]{"Empty","ASL-Empty","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4","0",""},
new string[]{"Half","ASL-Half","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4","2",""},
new string[]{"Quarter","ASL-Quarter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4","0",""},
new string[]{"Long","ASL-Long","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4","2",""},
new string[]{"Short (Time)","ASL-Short (Time)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4","0",""},
new string[]{"A Lot / Many","ASL-A Lot / Many","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4","2",""},
new string[]{"Unlimited","ASL-Unlimited","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4","2",""},
new string[]{"Limited","ASL-Limited","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4","2",""},
new string[]{"All","ASL-All","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","2",""},
new string[]{"All (Variant 2)","ASL-All (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","2","This lexicalized variant fingerspells A-L-L while doing the motion."},
new string[]{"Nothing","ASL-Nothing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4","2",""},
new string[]{"Ever","ASL-Ever","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4","2",""},
new string[]{"Everything","ASL-Everything","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4","2",""},
new string[]{"Everytime","ASL-Everytime","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4","2",""},
new string[]{"Always","ASL-Always","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4","2",""},
new string[]{"Often","ASL-Often","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4","2",""},
new string[]{"Sometimes","ASL-Sometimes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4","2",""},
new string[]{"Heavy","ASL-Heavy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4","2",""},
new string[]{"Lightweight","ASL-Lightweight","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4","0",""},
new string[]{"Hard","ASL-Hard","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4","0",""},
new string[]{"Soft","ASL-Soft","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4","2",""},
new string[]{"Strong","ASL-Strong","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4","2",""},
new string[]{"Weak","ASL-Weak","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4","2",""},
new string[]{"First","ASL-First","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4","2",""},
new string[]{"Second","ASL-Second","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4","2",""},
new string[]{"Third","ASL-Third","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4","0",""},
new string[]{"Next","ASL-Next","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4","2",""},
new string[]{"Last","ASL-Last","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4","0",""},
new string[]{"Before","ASL-Before","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4","2",""},
new string[]{"After","ASL-After","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4","2",""},
new string[]{"Busy","ASL-Busy","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4","2",""},
new string[]{"Free","ASL-Free","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4","2","'F' handshape initialized variant."},
new string[]{"High","ASL-High","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4","2",""},
new string[]{"Low","ASL-Low","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4","2",""},
new string[]{"Fat","ASL-Fat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4","2",""},
new string[]{"Thin","ASL-Thin","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4","0",""},
new string[]{"Value","ASL-Value","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4","0","Similar to 'Important', but initialized with a 'V' handshape."}
},
new string[][]{//Lesson 7 (Time)
new string[]{"Time","ASL-Time","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4","2",""},
new string[]{"Year","ASL-Year","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4","2",""},
new string[]{"Season","ASL-Season","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4","2",""},
new string[]{"Month","ASL-Month","GT4Tube","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4","2",""},
new string[]{"Week","ASL-Week","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4","2",""},
new string[]{"Day","ASL-Day","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4","2",""},
new string[]{"Weekend","ASL-Weekend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4","2",""},
new string[]{"Hours","ASL-Hours","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4","2",""},
new string[]{"Minutes","ASL-Minutes","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4","2",""},
new string[]{"Seconds","","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4","2",""},
new string[]{"Today","ASL-Today","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4","0",""},
new string[]{"Tomorrow","ASL-Tomorrow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4","2",""},
new string[]{"Yesterday","ASL-Yesterday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4","0","'Y' handshape initialized variant. Can also be done with an 'A' handshape."},
new string[]{"Morning","ASL-Morning","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4","2",""},
new string[]{"Afternoon","ASL-Afternoon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4","2",""},
new string[]{"Evening","ASL-Evening","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4","2",""},
new string[]{"Night","ASL-Night","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4","2",""},
new string[]{"Sunrise","ASL-Sunrise","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4","2","Can also be done with a 'C' handshape."},
new string[]{"Sunset","ASL-Sunset","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4","2","Can also be done with a 'C' handshape."},
new string[]{"All Day","ASL-All Day","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","2",""},
new string[]{"All Day (Variant 2)","ASL-All Day (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","2",""},
new string[]{"All Night","ASL-All Night","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","2",""},
new string[]{"All Night (Variant 2)","ASL-All Night (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","2",""},
new string[]{"Sunday","ASL-Sunday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4","2",""},
new string[]{"Monday","ASL-Monday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4","2","IRL this is done with a 'M' handshape"},
new string[]{"Tuesday","ASL-Tuesday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4","2","IRL this is done with a 'T' handshape"},
new string[]{"Wednesday","ASL-Wednesday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4","0","'W' handshape."},
new string[]{"Thursday","ASL-Thursday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4","2","'H'handshape."},
new string[]{"Friday","ASL-Friday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4","0","'F' handshape."},
new string[]{"Saturday","ASL-Saturday","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4","2","'S' handshape."},
new string[]{"Autumn","ASL-Autumn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4","2",""},
new string[]{"Winter","ASL-Winter","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4","0",""},
new string[]{"Spring","ASL-Spring","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4","2",""},
new string[]{"Summer","ASL-Summer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4","2",""},
new string[]{"Now","ASL-Now","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4","0",""},
new string[]{"Never","ASL-Never","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4","0",""},
new string[]{"Soon","ASL-Soon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4","0",""},
new string[]{"Later","ASL-Later","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4","2",""},
new string[]{"Past","ASL-Past","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4","2",""},
new string[]{"Future","ASL-Future","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4","0","'F' handshape Initialized variant."},
new string[]{"Earlier","ASL-Earlier","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4","0",""},
new string[]{"Midweek","ASL-Midweek","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4","0","Middle + Week."},
new string[]{"Next Week","ASL-Next Week","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4","2",""}
},
new string[][]{//Lesson 8 (VRChat)
new string[]{"Gestures","ASL-Gestures","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4","2",""},
new string[]{"World","ASL-World","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4","0",""},
new string[]{"Record","ASL-Record","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4","0","Record as in an audio recording."},
new string[]{"Discord","ASL-Discord","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4","2",""},
new string[]{"Streaming","ASL-Streaming","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4","2",""},
new string[]{"Headset (VR)","ASL-Headset (VR)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4","2",""},
new string[]{"Desktop","ASL-Desktop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4","2","As in desk. Ray signs desktop computer in the video."},
new string[]{"Computer","ASL-Computer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4","2",""},
new string[]{"Instance","ASL-Instance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4","2",""},
new string[]{"Public","ASL-Public","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4","2",""},
new string[]{"Invite","ASL-Invite","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4","2",""},
new string[]{"Private","ASL-Private","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4","2",""},
new string[]{"Add Friend","ASL-Add Friend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4","2",""},
new string[]{"Menu","ASL-Menu","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4","2",""},
new string[]{"Recharge","ASL-Recharge","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4","2",""},
new string[]{"Visit","ASL-Visit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4","2",""},
new string[]{"Request","ASL-Request","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4","2",""},
new string[]{"Login","ASL-Login","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4","2",""},
new string[]{"Logout","ASL-Logout","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4","2",""},
new string[]{"Schedule","ASL-Schedule","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4","2",""},
new string[]{"Event","ASL-Event","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4","0",""},
new string[]{"Online","ASL-Online","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4","0",""},
new string[]{"Offline","ASL-Offline","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4","0",""},
new string[]{"Cancel","ASL-Cancel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4","2",""},
new string[]{"Portal","ASL-Portal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4","2",""},
new string[]{"Camera","ASL-Camera","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4","2",""},
new string[]{"Avatar","ASL-Avatar","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4","2",""},
new string[]{"Photo","ASL-Photo","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4","2",""},
new string[]{"Join","ASL-Join","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4","2",""},
new string[]{"Leave","ASL-Leave","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4","2",""},
new string[]{"Climbing","ASL-Climbing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4","2",""},
new string[]{"Falling","ASL-Falling","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4","2",""},
new string[]{"Walk","ASL-Walk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4","2",""},
new string[]{"Hide","ASL-Hide","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4","2",""},
new string[]{"Block","ASL-Block","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4","2",""},
new string[]{"Crash","ASL-Crash","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4","2",""},
new string[]{"Lagging","ASL-Lagging","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4","2",""},
new string[]{"Restart","ASL-Restart","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4","2",""},
new string[]{"Send","ASL-Send","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4","2",""},
new string[]{"Receive","ASL-Receive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4","2",""},
new string[]{"Security","ASL-Security","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4","2  ",""},
new string[]{"Donation","ASL-Donation","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4","0",""}
},
new string[][]{//Alphabet/Numbers (fingerspelling) (lesson9)
new string[]{"Spell / Fingerspell","ASL-Spell / Fingerspell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0",""},
new string[]{"Spell / Fingerspell (Variant 2)","ASL-Spell / Fingerspell (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","1",""},
new string[]{"A","ASL-A","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4","2",""},
new string[]{"B","ASL-B","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","0",""},
new string[]{"B (Variant 2)","ASL-B (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","1",""},
new string[]{"C","ASL-C","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4","2",""},
new string[]{"D","ASL-D","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4","2",""},
new string[]{"E","ASL-E","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4","2",""},
new string[]{"F","ASL-F","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","0",""},
new string[]{"F (Variant 2)","ASL-F (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","1",""},
new string[]{"G","ASL-G","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4","2",""},
new string[]{"H","ASL-H","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4","2",""},
new string[]{"I","ASL-I","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","0",""},
new string[]{"I (Variant 2)","ASL-I (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","1",""},
new string[]{"J","ASL-J","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","0","Trace out a 'J' midair with your pinky using a rotation of your wrist."},
new string[]{"J (Variant 2)","ASL-J (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","1","Indicate your pinky is out, then trace out a 'J' midair with your pinky using a rotation of your wrist."},
new string[]{"K","ASL-K","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","0",""},
new string[]{"K (Variant 2)","ASL-K (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","2",""},
new string[]{"L","ASL-L","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4","2",""},
new string[]{"M","ASL-M","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","2","The finger is supposed to indicate that the thumb is between the pinky at the rest of the fingers."},
new string[]{"M (Variant 2)","ASL-M (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","2",""},
new string[]{"N","ASL-N","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","2","The finger is supposed to indicate that the thumb is between the ring and middle finger."},
new string[]{"N (Variant 2)","ASL-N (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","2",""},
new string[]{"O","ASL-O","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4","2",""},
new string[]{"P","ASL-P","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4","2",""},
new string[]{"Q","ASL-Q","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4","2",""},
new string[]{"R","ASL-R","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4","2",""},
new string[]{"S","ASL-S","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4","2",""},
new string[]{"T","ASL-T","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4","2",""},
new string[]{"U","ASL-U","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","0",""},
new string[]{"U (Variant 2)","ASL-U (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","1","The 'Peace Sign' on Regular VR looks like a V, so emphasise U shape by moving it in the shape of a U."},
new string[]{"V","ASL-V","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","0","The 'Peace Sign' on the Index looks like a U, so emphhasise a V shape by moving it in the shape of a V."},
new string[]{"V (Variant 2)","ASL-V (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","1",""},
new string[]{"W","ASL-W","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","0",""},
new string[]{"W (Variant 2)","ASL-W (Variant 2)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","2",""},
new string[]{"X","ASL-X","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","0",""},
new string[]{"X (Variant 2)","ASL-X (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","2",""},
new string[]{"Y","ASL-Y","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","0",""},
new string[]{"Y (Variant 2)","ASL-Y (Variant 2)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","1",""},
new string[]{"Z","ASL-Z","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4","0",""},
new string[]{"Comma","ASL-Comma","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4","0",""},
new string[]{"Space","ASL-Space","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4","0","To indicate a space between fingerspelled words, you simply insert a very small pause between letters."},
new string[]{"@","ASL-@","Anonymous","","2","Use for the symbol @, like in an email address."},
new string[]{"Number","ASL-Number","Anonymous","","2","Pinch fingers together"},
new string[]{"0","ASL-0","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4","0",""},
new string[]{"1","ASL-1","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4","0",""},
new string[]{"2","ASL-2","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4","0",""},
new string[]{"3","ASL-3","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4","0",""},
new string[]{"4","ASL-4","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4","0",""},
new string[]{"5","ASL-5","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4","0",""},
new string[]{"6","ASL-6","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4","0",""},
new string[]{"7","ASL-7","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4","0",""},
new string[]{"8","ASL-8","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4","0",""},
new string[]{"9","ASL-9","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4","0",""},
new string[]{"10","ASL-10","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4","0",""},
new string[]{"100","ASL-100","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4","0",""},
new string[]{"1000","ASL-1000","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4","0",""},
new string[]{"1000000","ASL-1000000","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4","0",""}
},
new string[][]{//Lesson 10 (Verbs & Actions p1)
new string[]{"Overlook","ASL-Overlook","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4","2",""},
new string[]{"Punish","ASL-Punish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4","2",""},
new string[]{"Edit","ASL-Edit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4","2",""},
new string[]{"Erase","ASL-Erase","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4","2",""},
new string[]{"Write","ASL-Write","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4","2",""},
new string[]{"Proposal","ASL-Proposal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4","2",""},
new string[]{"Add","ASL-Add","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4","2",""},
new string[]{"Remove","ASL-Remove","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4","2",""},
new string[]{"Agree","ASL-Agree","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4","2",""},
new string[]{"Disagree","ASL-Disagree","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4","2",""},
new string[]{"Admit","ASL-Admit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4","2",""},
new string[]{"Allow","ASL-Allow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4","2",""},
new string[]{"Attack","ASL-Attack","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4","2",""},
new string[]{"Fight","ASL-Fight","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4","2",""},
new string[]{"Defend","ASL-Defend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4","2",""},
new string[]{"Defeat (Overcome)","ASL-Defeat (Overcome)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4","2",""},
new string[]{"Win","ASL-Win","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4","2",""},
new string[]{"Lose","ASL-Lose","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4","2",""},
new string[]{"Draw / Tie (Game)","ASL-Draw / Tie (Game)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4","2","Draw or Tie, as in the same score at the end of a game."},
new string[]{"Give Up","ASL-Give Up","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4","2",""},
new string[]{"Skip","ASL-Skip","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4","2",""},
new string[]{"Ask","ASL-Ask","Anonymous","","0","Less formal version of request."},//Vid is for request
new string[]{"Attach","ASL-Attach","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4","0",""},
new string[]{"Assist","ASL-Assist","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4","0",""},
new string[]{"Bait","ASL-Bait","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4","0",""},
new string[]{"Battle","ASL-Battle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4","0",""},
new string[]{"Beat (Overcome)","ASL-Beat (Overcome)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4","0",""},
new string[]{"Become","ASL-Become","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4","0",""},
new string[]{"Beg","ASL-Beg","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4","0",""},
new string[]{"Begin","ASL-Begin","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4","0",""},
new string[]{"Behave","ASL-Behave","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4","0",""},
new string[]{"Believe","ASL-Believe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4","0",""},
new string[]{"Blame","ASL-Blame","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4","0",""},
new string[]{"Blow","ASL-Blow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4","0",""},
new string[]{"Blush","ASL-Blush","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4","0",""},
new string[]{"Bother / Harass","ASL-Bother / Harass","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4","0",""}
},
new string[][]{//Lesson 11 (Verbs & Actions p2)
new string[]{"Bend","ASL-Bend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4","0",""},
new string[]{"Bow","ASL-Bow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4","0",""},
new string[]{"Break","ASL-Break","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4","0",""},
new string[]{"Breathe","ASL-Breathe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4","0",""},
new string[]{"Bring","ASL-Bring","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4","0","This is a directional sign."},
new string[]{"Build / Construct","ASL-Build / Construct","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4","0",""},
new string[]{"Bully","ASL-Bully","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4","0",""},
new string[]{"Burn","ASL-Burn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4","0",""},
new string[]{"Buy","ASL-Buy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4","0",""},
new string[]{"Call","ASL-Call","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4","0",""},
new string[]{"Cancel","ASL-Cancel","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4","0",""},
new string[]{"Care","ASL-Care","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4","0",""},
new string[]{"Carry","ASL-Carry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4","0",""},
new string[]{"Catch","ASL-Catch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4","0",""},
new string[]{"Cause","ASL-Cause","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4","0",""},
new string[]{"Challenge","ASL-Challenge","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4","0",""},
new string[]{"Chance","ASL-Chance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4","0","'C' handshape. This sign is the Signed Exact English variant."},
new string[]{"Cheat","ASL-Cheat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4","0",""},
new string[]{"Check","ASL-Check","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4","0",""},
new string[]{"Choose","ASL-Choose","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4","0",""},
new string[]{"Claim","ASL-Claim","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4","0",""},
new string[]{"Clean","ASL-Clean","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4","0",""},
new string[]{"Clear","ASL-Clear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4","0",""},
new string[]{"Close","ASL-Close","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4","0","Close as in 'near'"},
new string[]{"Comfort","ASL-Comfort","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4","0",""},
new string[]{"Command","ASL-Command","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4","0",""},
new string[]{"Communicate","ASL-Communicate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4","0","This sign is the Signed Exact English variant."},
new string[]{"Compare","ASL-Compare","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4","0",""},
new string[]{"Complain","ASL-Complain","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4","0",""},
new string[]{"Compliment","ASL-Compliment","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4","0",""},
new string[]{"Concentrate","ASL-Concentrate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4","0",""},
new string[]{"Construct / Build","ASL-Construct / Build","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4","0",""},
new string[]{"Control","ASL-Control","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4","0",""},
new string[]{"Cook","ASL-Cook","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4","0",""},
new string[]{"Copy","ASL-Copy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4","0",""},
new string[]{"Correct","ASL-Correct","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4","0",""}
},
new string[][]{//Lesson 12 (Verbs & Actions p3)
new string[]{"Cough","ASL-Cough","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4","0",""},
new string[]{"Count","ASL-Count","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4","0",""},
new string[]{"Create","ASL-Create","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4","0",""},
new string[]{"Cuddle","ASL-Cuddle","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4","0",""},
new string[]{"Cut","ASL-Cut","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4","0",""},
new string[]{"Dab","ASL-Dab","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4","0",""},
new string[]{"Dance","ASL-Dance","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4","0",""},
new string[]{"Dare","ASL-Dare","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4","0",""},
new string[]{"Date","ASL-Date","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4","0",""},
new string[]{"Deal","ASL-Deal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4","0",""},
new string[]{"Deliver","ASL-Deliver","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4","0",""},
new string[]{"Depend","ASL-Depend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4","0",""},
new string[]{"Describe","ASL-Describe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4","0",""},
new string[]{"Dirty","ASL-Dirty","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4","0",""},
new string[]{"Disappear","ASL-Disappear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4","0",""},
new string[]{"Disappoint","ASL-Disappoint","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4","0",""},
new string[]{"Disapprove","ASL-Disapprove","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4","0",""},
new string[]{"Discuss","ASL-Discuss","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4","0",""},
new string[]{"Disguise","ASL-Disguise","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4","0",""},
new string[]{"Disgust","ASL-Disgust","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4","0",""},
new string[]{"Dismiss","ASL-Dismiss","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4","0",""},
new string[]{"Disturb","ASL-Disturb","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4","0",""},
new string[]{"Doubt","ASL-Doubt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4","0",""},
new string[]{"Dream","ASL-Dream","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4","0",""},
new string[]{"Dress","ASL-Dress","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4","0",""},
new string[]{"Drunk","ASL-Drunk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4","0",""},
new string[]{"Drop","ASL-Drop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4","0",""},
new string[]{"Drown","ASL-Drown","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4","0",""},
new string[]{"Dry","ASL-Dry","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4","0",""},
new string[]{"Dump","ASL-Dump","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4","0",""},
new string[]{"Dust","ASL-Dust","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4","0",""},
new string[]{"Earn","ASL-Earn","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4","0",""},
new string[]{"Effect","ASL-Effect","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4","0",""},
new string[]{"End","ASL-End","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4","0",""},
new string[]{"Escape","ASL-Escape","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4","0",""},
new string[]{"Escort","ASL-Escort","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4","0",""}
},
new string[][]{//Lesson 13 (Verbs & Actions p4)
new string[]{"Excuse","ASL-Excuse","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4","0",""},
new string[]{"Expose","ASL-Expose","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4","0",""},
new string[]{"Exist","ASL-Exist","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4","0",""},
new string[]{"Fail","ASL-Fail","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4","0",""},
new string[]{"Faint","ASL-Faint","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4","0",""},
new string[]{"Fake","ASL-Fake","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4","0",""},
new string[]{"Fart","ASL-Fart","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4","0",""},
new string[]{"Fear","ASL-Fear","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4","0",""},
new string[]{"Fill","ASL-Fill","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4","0",""},
new string[]{"Find","ASL-Find","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4","0",""},
new string[]{"Finish","ASL-Finish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4","0",""},
new string[]{"Fix","ASL-Fix","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4","0",""},
new string[]{"Flip","ASL-Flip","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4","0",""},
new string[]{"Flirt","ASL-Flirt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4","0",""},
new string[]{"Fly","ASL-Fly","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4","0",""},
new string[]{"Forbid","ASL-Forbid","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4","0",""},
new string[]{"Forgive","ASL-Forgive","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4","0",""},
new string[]{"Gain","ASL-Gain","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4","0",""},
new string[]{"Give","ASL-Give","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4","0",""},
new string[]{"Glow","ASL-Glow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4","0",""},
new string[]{"Grab","ASL-Grab","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4","0",""},
new string[]{"Grow","ASL-Grow","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4","0",""},
new string[]{"Guard","ASL-Guard","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4","0",""},
new string[]{"Guess","ASL-Guess","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4","0",""},
new string[]{"Guide","ASL-Guide","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4","0",""},
new string[]{"Harass / Bother","ASL-Harass / Bother","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4","0",""},
new string[]{"Harm","ASL-Harm","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4","0",""},
new string[]{"Hit","ASL-Hit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4","0",""},
new string[]{"Hold","ASL-Hold","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4","0",""},
new string[]{"Hop","ASL-Hop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4","0",""},
new string[]{"Hope","ASL-Hope","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4","0",""},
new string[]{"Hunt","ASL-Hunt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4","0",""},
new string[]{"Ignore","ASL-Ignore","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4","0",""},
new string[]{"Imagine","ASL-Imagine","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4","0",""},
new string[]{"Imitate","ASL-Imitate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4","0",""},
new string[]{"Insult","ASL-Insult","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4","0",""}
},
new string[][]{//Lesson 14 (Verbs & Actions p5)
new string[]{"Interact","ASL-Interact","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4","0",""},
new string[]{"Interfere","ASL-Interfere","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4","0",""},
new string[]{"Judge","ASL-Judge","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4","0",""},
new string[]{"Jump","ASL-Jump","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4","0",""},
new string[]{"Justify","ASL-Justify","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4","0",""},
new string[]{"Just Kidding","ASL-Just Kidding","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4","0",""},
new string[]{"Keep","ASL-Keep","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4","0",""},
new string[]{"Kick","ASL-Kick","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4","0",""},
new string[]{"Kill","ASL-Kill","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4","0",""},
new string[]{"Knock","ASL-Knock","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4","0",""},
new string[]{"Lead","ASL-Lead","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4","0",""},
new string[]{"Lick","ASL-Lick","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4","0",""},
new string[]{"Lock","ASL-Lock","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4","0",""},
new string[]{"Manipulate","ASL-Manipulate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4","0",""},
new string[]{"Melt","ASL-Melt","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4","0",""},
new string[]{"Mess","ASL-Mess","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4","0",""},
new string[]{"Miss","ASL-Miss","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4","0",""},
new string[]{"Mistake","ASL-Mistake","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4","0",""},
new string[]{"Mount","ASL-Mount","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4","0",""},
new string[]{"Move","ASL-Move","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4","0",""},
new string[]{"Murder","ASL-Murder","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4","0",""},
new string[]{"Nod","ASL-Nod","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4","0",""},
new string[]{"Note","ASL-Note","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4","0",""},
new string[]{"Notice","ASL-Notice","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4","0",""},
new string[]{"Obey","ASL-Obey","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4","0",""},
new string[]{"Obsess","ASL-Obsess","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4","0",""},
new string[]{"Obtain","ASL-Obtain","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4","0",""},
new string[]{"Occupy","ASL-Occupy","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4","0",""},
new string[]{"Offend","ASL-Offend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4","0",""},
new string[]{"Offer","ASL-Offer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4","0",""},
new string[]{"Okay","ASL-Okay","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4","0",""},
new string[]{"Open","ASL-Open","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4","0",""},
new string[]{"Order","ASL-Order","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4","0",""},
new string[]{"Owe","ASL-Owe","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4","0",""},
new string[]{"Own","ASL-Own","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4","0",""},
new string[]{"Pass","ASL-Pass","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4","0",""}
},
new string[][]{//Lesson 15 (Verbs & Actions p6)
new string[]{"Pat","ASL-Pat","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4","2",""},
new string[]{"Party","ASL-Party","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4","0",""},
new string[]{"Pet","ASL-Pet","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4","2",""},
new string[]{"Pick","ASL-Pick","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4","2",""},
new string[]{"Plug","ASL-Plug","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4","2",""},
new string[]{"Point","ASL-Point","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4","2",""},
new string[]{"Poke","ASL-Poke","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4","2",""},
new string[]{"Pray","ASL-Pray","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4","2",""},
new string[]{"Prepare","ASL-Prepare","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4","2",""},
new string[]{"Present","ASL-Present","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4","0",""},
new string[]{"Pretend","ASL-Pretend","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4","2",""},
new string[]{"Protect","ASL-Protect","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4","2",""},
new string[]{"Prove","ASL-Prove","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4","2",""},
new string[]{"Publish","ASL-Publish","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4","2",""},
new string[]{"Puke","ASL-Puke","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","2",""},
new string[]{"Puke (Variant 2)","ASL-Puke (Variant 2)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","2",""},
new string[]{"Pull","ASL-Pull","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4","2",""},
new string[]{"Punch","ASL-Punch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4","2",""},
new string[]{"Put","ASL-Put","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4","2",""},
new string[]{"Push","ASL-Push","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4","2",""},
new string[]{"Question","ASL-Question","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","2",""},
new string[]{"Questions","ASL-Questions","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","2",""},
new string[]{"Quit","ASL-Quit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4","2",""},
new string[]{"Quote","ASL-Quote","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4","0",""},
new string[]{"Race","ASL-Race","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4","2",""},
new string[]{"React","ASL-React","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4","2",""},
new string[]{"Recommended","ASL-Recommended","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4","0",""},
new string[]{"Refuse","ASL-Refuse","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4","2",""},
new string[]{"Regret","ASL-Regret","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4","0",""},
new string[]{"Remember","ASL-Remember","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4","2",""},
new string[]{"Replace","ASL-Replace","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4","0",""},
new string[]{"Report","ASL-Report","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4","2",""},
new string[]{"Reset","ASL-Reset","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4","2",""},
new string[]{"Ride","ASL-Ride","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4","2",""},
new string[]{"Rub","ASL-Rub","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4","2",""},
new string[]{"Rule","ASL-Rule","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4","2",""},
new string[]{"Run","ASL-Run","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4","0",""},
new string[]{"Save","ASL-Save","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4","2",""}
},
new string[][]{//Lesson 16 (Verbs & Actions p7)
new string[]{"Say","ASL-Say","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4","2",""},
new string[]{"Search","ASL-Search","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4","2",""},
new string[]{"See","ASL-See","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4","2",""},
new string[]{"Share","ASL-Share","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4","2",""},
new string[]{"Shock","ASL-Shock","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4","2",""},
new string[]{"Shop (Store)","ASL-Shop (Store)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4","2",""},
new string[]{"Show","ASL-Show","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4","2","This is a directional sign."},
new string[]{"Shut Up","ASL-Shut Up","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4","2","IRL: Starts with a V hand and transitions to an U hand."},
new string[]{"Shut Down","ASL-Shut Down","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4","2",""},
new string[]{"Sing","ASL-Sing","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4","2",""},
new string[]{"Sit","ASL-Sit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4","2",""},
new string[]{"Smell","ASL-Smell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4","2",""},
new string[]{"Smile","ASL-Smile","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4","2",""},
new string[]{"Smoke (Airborn)","ASL-Smoke (Airborn)","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4","2","This does not refer to smoking."},
new string[]{"Speak / Talk","ASL-Speak / Talk","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4","0",""},
new string[]{"Spell / Fingerspell","ASL-Spell / Fingerspell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0",""},
new string[]{"Spit","ASL-Spit","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4","0",""},
new string[]{"Stand","ASL-Stand","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4","2",""},
new string[]{"Start","ASL-Start","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4","2",""},
new string[]{"Stay","ASL-Stay","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4","0",""},
new string[]{"Steal","ASL-Steal","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4","0",""},
new string[]{"Stop","ASL-Stop","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4","2",""},
new string[]{"Study","ASL-Study","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4","2",""},
new string[]{"Suffer","ASL-Suffer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4","2",""},
new string[]{"Swim","ASL-Swim","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4","2",""},
new string[]{"Switch","ASL-Switch","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4","2",""},
new string[]{"Take (From)","ASL-Take (From)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4","2","Take as in physically taking candy from a baby. Contrast with Take (Up) as in taking ASL class."},
new string[]{"Communicate","ASL-Communicate","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4","2",""},
new string[]{"Tell","ASL-Tell","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4","2",""},
new string[]{"Test","ASL-Test","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4","2",""},
new string[]{"Text","ASL-Text","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4","2",""},
new string[]{"Think","ASL-Think","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4","2",""},
new string[]{"Throw","ASL-Throw","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4","2",""},
new string[]{"Tie","ASL-Tie","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4","2",""},
new string[]{"Truth","ASL-Truth","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4","2",""},
new string[]{"Try","ASL-Try","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4","2",""},
},
new string[][]{//Lesson 17 (Verbs & Actions p8)
new string[]{"Type","ASL-Type","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-01.mp4","1",""},
new string[]{"Turn","ASL-Turn","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-02.mp4","2",""},
new string[]{"Upset","ASL-Upset","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-03.mp4","2",""},
new string[]{"Use","ASL-Use","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-04.mp4","2",""},
new string[]{"View","ASL-View","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-05.mp4","2","View as in point of view."},
new string[]{"Vomit","ASL-Vomit","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-06.mp4","2",""},
new string[]{"Wait","ASL-Wait","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-07.mp4","0",""},
new string[]{"Wake Up","ASL-Wake Up","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-08.mp4","2",""},
new string[]{"War","ASL-War","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-09.mp4","2",""},
new string[]{"Warn","ASL-Warn","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-10.mp4","2","Slap back of hand twice."},
new string[]{"Waste","ASL-Waste","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-11.mp4","2",""},
new string[]{"Wash","ASL-Wash","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-12.mp4","2",""},
new string[]{"Watch","ASL-Watch","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-13.mp4","2",""},
new string[]{"Wear","ASL-Wear","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-14.mp4","2",""},
new string[]{"Wobble","ASL-Wobble","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-15.mp4","2",""},
new string[]{"Wonder","ASL-Wonder","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-16.mp4","2",""},
new string[]{"Worry","ASL-Worry","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-17.mp4","2",""},
new string[]{"Work","ASL-Work","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-18.mp4","2",""},
new string[]{"Hug","ASL-Hug","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-19.mp4","2",""},
new string[]{"Touch","ASL-Touch","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-20.mp4","0",""},
new string[]{"Kiss","ASL-Kiss","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-21.mp4","2",""},
new string[]{"Trust","ASL-Trust","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-22.mp4","2",""},
new string[]{"True","ASL-True","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-23.mp4","2",""},
new string[]{"Lie","ASL-Lie","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-24.mp4","2",""},
new string[]{"Serve","ASL-Serve","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-25.mp4","2",""},
new string[]{"Calculate","ASL-Calculate","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-26.mp4","0",""},
new string[]{"Shower","ASL-Shower","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-27.mp4","2",""},
new string[]{"Bathe","ASL-Bathe","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-28.mp4","2",""},
new string[]{"Socialize","ASL-Socialize","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-29.mp4","2",""},
new string[]{"Help","ASL-Help","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-30.mp4","2",""},
new string[]{"Support","ASL-Support","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-31.mp4","2",""},
new string[]{"Take Care","ASL-Take Care","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-32.mp4","2",""},
new string[]{"Drive","ASL-Drive","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-33.mp4","2",""},
new string[]{"Travel","ASL-Travel","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-34.mp4","2",""},
new string[]{"Trip","ASL-Trip","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-35.mp4","2",""},
new string[]{"Fiction","ASL-Fiction","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet17/17-36.mp4","2",""},
},
new string[][]{//Lesson 18 (Food)
new string[]{"Custard","Idle","No Data Yet.","","2",""},
new string[]{"Corn","Idle","No Data Yet.","","2",""},
new string[]{"Vegtable","Idle","No Data Yet.","","2",""},
new string[]{"Cookie","Idle","No Data Yet.","","2",""},
new string[]{"Cake","Idle","No Data Yet.","","2",""},
new string[]{"Yogurt","Idle","No Data Yet.","","2",""},
new string[]{"Lemon","Idle","No Data Yet.","","2",""},
new string[]{"Nuts","Idle","No Data Yet.","","2",""},
new string[]{"Grapes","Idle","No Data Yet.","","2",""},
new string[]{"Peas","Idle","No Data Yet.","","2",""},
new string[]{"Beans","Idle","No Data Yet.","","2",""},
new string[]{"Pear","Idle","No Data Yet.","","2",""},
new string[]{"Butter","Idle","No Data Yet.","","2",""},
new string[]{"Banana","Idle","No Data Yet.","","2",""},
new string[]{"Pumpkin","Idle","No Data Yet.","","2",""},
new string[]{"Fruit","Idle","No Data Yet.","","2",""},
new string[]{"Apple","Idle","No Data Yet.","","2",""},
new string[]{"Tomato","Idle","No Data Yet.","","2",""},
new string[]{"Orange","Idle","No Data Yet.","","2",""},
new string[]{"Bread","Idle","No Data Yet.","","2",""},
new string[]{"Cheese","Idle","No Data Yet.","","2",""},
new string[]{"Water","Idle","No Data Yet.","","2",""},
new string[]{"Hamburger","Idle","No Data Yet.","","2",""},
new string[]{"Hot Dog","Idle","No Data Yet.","","2",""},
new string[]{"Curry","Idle","No Data Yet.","","2",""},
new string[]{"Rice","Idle","No Data Yet.","","2",""},
new string[]{"Noodles","Idle","No Data Yet.","","2",""},
new string[]{"Eggs","Idle","No Data Yet.","","2",""},
new string[]{"Salt","Idle","No Data Yet.","","2",""},
new string[]{"Meat","Idle","No Data Yet.","","2",""},
new string[]{"Carrot","Idle","No Data Yet.","","2",""},
new string[]{"Cabbage","Idle","No Data Yet.","","2",""},
new string[]{"Spaghetti","Idle","No Data Yet.","","2",""},
new string[]{"Pizza","Idle","No Data Yet.","","2",""},
new string[]{"Sushi","Idle","No Data Yet.","","2",""},
new string[]{"Potato","Idle","No Data Yet.","","2",""},
new string[]{"Juice","Idle","No Data Yet.","","2",""},
new string[]{"Cola","Idle","No Data Yet.","","2",""},
new string[]{"Beer","Idle","No Data Yet.","","2",""},
new string[]{"Wine","Idle","No Data Yet.","","2",""},
new string[]{"Champagne","Idle","No Data Yet.","","2",""},
new string[]{"Milk","Idle","No Data Yet.","","2",""},
new string[]{"Sugar","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 19 (Animals / Machines)
new string[]{"Dog","Idle","No Data Yet.","","2",""},
new string[]{"Cat","Idle","No Data Yet.","","2",""},
new string[]{"Fox","Idle","No Data Yet.","","2",""},
new string[]{"Cow","Idle","No Data Yet.","","2",""},
new string[]{"Sheep","Idle","No Data Yet.","","2",""},
new string[]{"Duck","Idle","No Data Yet.","","2",""},
new string[]{"Fly","Idle","No Data Yet.","","2",""},
new string[]{"Chicken","Idle","No Data Yet.","","2",""},
new string[]{"Owl","Idle","No Data Yet.","","2",""},
new string[]{"Bird","Idle","No Data Yet.","","2",""},
new string[]{"Mouse","Idle","No Data Yet.","","2",""},
new string[]{"Bear","Idle","No Data Yet.","","2",""},
new string[]{"Lion","Idle","No Data Yet.","","2",""},
new string[]{"Cricket","Idle","No Data Yet.","","2",""},
new string[]{"Dragon","Idle","No Data Yet.","","2",""},
new string[]{"Rabbit","Idle","No Data Yet.","","2",""},
new string[]{"Turtle","Idle","No Data Yet.","","2",""},
new string[]{"Pig","Idle","No Data Yet.","","2",""},
new string[]{"Squirrel","Idle","No Data Yet.","","2",""},
new string[]{"Raccoon","Idle","No Data Yet.","","2",""},
new string[]{"Fish","Idle","No Data Yet.","","2",""},
new string[]{"Rocket","Idle","No Data Yet.","","2",""},
new string[]{"Generator","Idle","No Data Yet.","","2",""},
new string[]{"Car","Idle","No Data Yet.","","2",""},
new string[]{"Truck","Idle","No Data Yet.","","2",""},
new string[]{"Bike","Idle","No Data Yet.","","2",""},
new string[]{"Motorcycle","Idle","No Data Yet.","","2",""},
new string[]{"Train","Idle","No Data Yet.","","2",""},
new string[]{"Robot","Idle","No Data Yet.","","2",""},
new string[]{"Spaceship","Idle","No Data Yet.","","2",""},
new string[]{"Aircraft","Idle","No Data Yet.","","2",""},
new string[]{"Helicopter","Idle","No Data Yet.","","2",""},
new string[]{"Bus","Idle","No Data Yet.","","2",""},
new string[]{"Ship","Idle","No Data Yet.","","2",""},
new string[]{"Bulldozer","Idle","No Data Yet.","","2",""},
new string[]{"Crane","Idle","No Data Yet.","","2",""},
new string[]{"Machine","Idle","No Data Yet.","","2",""},
new string[]{"Drilling Machine","Idle","No Data Yet.","","2",""},
new string[]{"Elevator","Idle","No Data Yet.","","2",""},
new string[]{"Cyborg","Idle","No Data Yet.","","2",""},
new string[]{"Tank","Idle","No Data Yet.","","2",""},
new string[]{"Submarine","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 20 (Places)
new string[]{"Bathroom","Idle","No Data Yet.","","2",""},
new string[]{"Room","Idle","No Data Yet.","","2",""},
new string[]{"City","Idle","No Data Yet.","","2",""},
new string[]{"House","Idle","No Data Yet.","","2",""},
new string[]{"Skyscraper","Idle","No Data Yet.","","2",""},
new string[]{"Apartment","Idle","No Data Yet.","","2",""},
new string[]{"Tower","Idle","No Data Yet.","","2",""},
new string[]{"Village","Idle","No Data Yet.","","2",""},
new string[]{"Sewer","Idle","No Data Yet.","","2",""},
new string[]{"Cellar","Idle","No Data Yet.","","2",""},
new string[]{"Storage","Idle","No Data Yet.","","2",""},
new string[]{"Pool","Idle","No Data Yet.","","2",""},
new string[]{"Sea","Idle","No Data Yet.","","2",""},
new string[]{"Island","Idle","No Data Yet.","","2",""},
new string[]{"Sun","Idle","No Data Yet.","","2",""},
new string[]{"Moon","Idle","No Data Yet.","","2",""},
new string[]{"Sky","Idle","No Data Yet.","","2",""},
new string[]{"Space","Idle","No Data Yet.","","2",""},
new string[]{"Milky Way","Idle","No Data Yet.","","2",""},
new string[]{"Heaven","Idle","No Data Yet.","","2",""},
new string[]{"Hell","Idle","No Data Yet.","","2",""},
new string[]{"Graveyard","Idle","No Data Yet.","","2",""},
new string[]{"Garden","Idle","No Data Yet.","","2",""},
new string[]{"Beach","Idle","No Data Yet.","","2",""},
new string[]{"Coast","Idle","No Data Yet.","","2",""},
new string[]{"Sea","Idle","No Data Yet.","","2",""},
new string[]{"Garbage Dump","Idle","No Data Yet.","","2",""},
new string[]{"Castle","Idle","No Data Yet.","","2",""},
new string[]{"Cathedral","Idle","No Data Yet.","","2",""},
new string[]{"Church","Idle","No Data Yet.","","2",""},
new string[]{"Store","Idle","No Data Yet.","","2",""},
new string[]{"Butchery","Idle","No Data Yet.","","2",""},
new string[]{"Prison","Idle","No Data Yet.","","2",""},
new string[]{"Police Station","Idle","No Data Yet.","","2",""},
new string[]{"Hospital","Idle","No Data Yet.","","2",""},
new string[]{"Firestation","Idle","No Data Yet.","","2",""},
new string[]{"Hotel","Idle","No Data Yet.","","2",""},
new string[]{"Airport","Idle","No Data Yet.","","2",""},
new string[]{"Harbor","Idle","No Data Yet.","","2",""},
new string[]{"Road","Idle","No Data Yet.","","2",""},
new string[]{"Crossing","Idle","No Data Yet.","","2",""},
new string[]{"Railway","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 21 (Stuff / Weather)
new string[]{"Wood","Idle","No Data Yet.","","2",""},
new string[]{"Metal","Idle","No Data Yet.","","2",""},
new string[]{"Glass","Idle","No Data Yet.","","2",""},
new string[]{"Liquid","Idle","No Data Yet.","","2",""},
new string[]{"Electricity","Idle","No Data Yet.","","2",""},
new string[]{"Powder","Idle","No Data Yet.","","2",""},
new string[]{"Feather","Idle","No Data Yet.","","2",""},
new string[]{"Box","Idle","No Data Yet.","","2",""},
new string[]{"Container","Idle","No Data Yet.","","2",""},
new string[]{"Paper","Idle","No Data Yet.","","2",""},
new string[]{"Pencil","Idle","No Data Yet.","","2",""},
new string[]{"Eraser","Idle","No Data Yet.","","2",""},
new string[]{"Book","Idle","No Data Yet.","","2",""},
new string[]{"Ruler","Idle","No Data Yet.","","2",""},
new string[]{"Hammer","Idle","No Data Yet.","","2",""},
new string[]{"Saw","Idle","No Data Yet.","","2",""},
new string[]{"Sander","Idle","No Data Yet.","","2",""},
new string[]{"Scissors","Idle","No Data Yet.","","2",""},
new string[]{"Pincer","Idle","No Data Yet.","","2",""},
new string[]{"Stick","Idle","No Data Yet.","","2",""},
new string[]{"Rake","Idle","No Data Yet.","","2",""},
new string[]{"Shovel","Idle","No Data Yet.","","2",""},
new string[]{"Axe","Idle","No Data Yet.","","2",""},
new string[]{"Hook","Idle","No Data Yet.","","2",""},
new string[]{"Chain","Idle","No Data Yet.","","2",""},
new string[]{"Storm","Idle","No Data Yet.","","2",""},
new string[]{"Hurricane","Idle","No Data Yet.","","2",""},
new string[]{"Earthquake","Idle","No Data Yet.","","2",""},
new string[]{"Dark","Idle","No Data Yet.","","2",""},
new string[]{"Light","Idle","No Data Yet.","","2",""},
new string[]{"Clouds","Idle","No Data Yet.","","2",""},
new string[]{"Fire","Idle","No Data Yet.","","2",""},
new string[]{"Ice","Idle","No Data Yet.","","2",""},
new string[]{"Rain","Idle","No Data Yet.","","2",""},
new string[]{"Flood","Idle","No Data Yet.","","2",""},
new string[]{"Smoke","Idle","No Data Yet.","","2",""},
new string[]{"Fog","Idle","No Data Yet.","","2",""},
new string[]{"Snow","Idle","No Data Yet.","","2",""},
new string[]{"Freeze","Idle","No Data Yet.","","2",""},
new string[]{"Hot","Idle","No Data Yet.","","2",""},
new string[]{"Humidity","Idle","No Data Yet.","","2",""},
new string[]{"Lighting","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 22 (Clothes / Equipment)
new string[]{"Dress","Idle","No Data Yet.","","2",""},
new string[]{"Pants","Idle","No Data Yet.","","2",""},
new string[]{"Jeans","Idle","No Data Yet.","","2",""},
new string[]{"Shorts","Idle","No Data Yet.","","2",""},
new string[]{"Swimming Trunks","Idle","No Data Yet.","","2",""},
new string[]{"Bikini","Idle","No Data Yet.","","2",""},
new string[]{"Miniskirt","Idle","No Data Yet.","","2",""},
new string[]{"Underwear","Idle","No Data Yet.","","2",""},
new string[]{"Bra","Idle","No Data Yet.","","2",""},
new string[]{"Diapers","Idle","No Data Yet.","","2",""},
new string[]{"Shirt","Idle","No Data Yet.","","2",""},
new string[]{"Sweater","Idle","No Data Yet.","","2",""},
new string[]{"Hat","Idle","No Data Yet.","","2",""},
new string[]{"High Heels","Idle","No Data Yet.","","2",""},
new string[]{"Scarf","Idle","No Data Yet.","","2",""},
new string[]{"Raincoat","Idle","No Data Yet.","","2",""},
new string[]{"Jacket","Idle","No Data Yet.","","2",""},
new string[]{"Umbrella","Idle","No Data Yet.","","2",""},
new string[]{"Gloves","Idle","No Data Yet.","","2",""},
new string[]{"Uniform","Idle","No Data Yet.","","2",""},
new string[]{"Overalls","Idle","No Data Yet.","","2",""},
new string[]{"Mask","Idle","No Data Yet.","","2",""},
new string[]{"Cap","Idle","No Data Yet.","","2",""},
new string[]{"Glasses","Idle","No Data Yet.","","2",""},
new string[]{"Goggles","Idle","No Data Yet.","","2",""},
new string[]{"Helmet","Idle","No Data Yet.","","2",""},
new string[]{"Socks","Idle","No Data Yet.","","2",""},
new string[]{"Shoes","Idle","No Data Yet.","","2",""},
new string[]{"Boots","Idle","No Data Yet.","","2",""},
new string[]{"Sandals","Idle","No Data Yet.","","2",""},
new string[]{"Backpack","Idle","No Data Yet.","","2",""},
new string[]{"Bag","Idle","No Data Yet.","","2",""},
new string[]{"Suitcase","Idle","No Data Yet.","","2",""},
new string[]{"Belt","Idle","No Data Yet.","","2",""},
new string[]{"Sportswear","Idle","No Data Yet.","","2",""},
new string[]{"Jumpsuit","Idle","No Data Yet.","","2",""},
new string[]{"Jewelry","Idle","No Data Yet.","","2",""},
new string[]{"Ring","Idle","No Data Yet.","","2",""},
new string[]{"Bracelet","Idle","No Data Yet.","","2",""},
new string[]{"Badge","Idle","No Data Yet.","","2",""},
new string[]{"Necklace","Idle","No Data Yet.","","2",""},
new string[]{"Earring","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 23 (Fantasy / Characters)
new string[]{"Sword","Idle","No Data Yet.","","2",""},
new string[]{"Shield","Idle","No Data Yet.","","2",""},
new string[]{"Weapon","Idle","No Data Yet.","","2",""},
new string[]{"Cannon","Idle","No Data Yet.","","2",""},
new string[]{"Stick","Idle","No Data Yet.","","2",""},
new string[]{"Magic","Idle","No Data Yet.","","2",""},
new string[]{"Money","Idle","No Data Yet.","","2",""},
new string[]{"Ghost","Idle","No Data Yet.","","2",""},
new string[]{"Zombie","Idle","No Data Yet.","","2",""},
new string[]{"Undead","Idle","No Data Yet.","","2",""},
new string[]{"Soldier","Idle","No Data Yet.","","2",""},
new string[]{"Police","Idle","No Data Yet.","","2",""},
new string[]{"Nurse","Idle","No Data Yet.","","2",""},
new string[]{"Fireman","Idle","No Data Yet.","","2",""},
new string[]{"Wizard","Idle","No Data Yet.","","2",""},
new string[]{"Sorcerer","Idle","No Data Yet.","","2",""},
new string[]{"Hunter","Idle","No Data Yet.","","2",""},
new string[]{"Male","Idle","No Data Yet.","","2",""},
new string[]{"Female","Idle","No Data Yet.","","2",""},
new string[]{"Human","Idle","No Data Yet.","","2",""},
new string[]{"Dwarf","Idle","No Data Yet.","","2",""},
new string[]{"Elf","Idle","No Data Yet.","","2",""},
new string[]{"Orc","Idle","No Data Yet.","","2",""},
new string[]{"Tauren","Idle","No Data Yet.","","2",""},
new string[]{"Monster","Idle","No Data Yet.","","2",""},
new string[]{"Gnome","Idle","No Data Yet.","","2",""},
new string[]{"Troll","Idle","No Data Yet.","","2",""},
new string[]{"Health","Idle","No Data Yet.","","2",""},
new string[]{"Mana","Idle","No Data Yet.","","2",""},
new string[]{"Energy","Idle","No Data Yet.","","2",""},
new string[]{"Power","Idle","No Data Yet.","","2",""},
new string[]{"Armor","Idle","No Data Yet.","","2",""},
new string[]{"Resistance","Idle","No Data Yet.","","2",""},
new string[]{"Resurrect","Idle","No Data Yet.","","2",""},
new string[]{"Rage","Idle","No Data Yet.","","2",""},
new string[]{"Casting","Idle","No Data Yet.","","2",""},
new string[]{"Shooting","Idle","No Data Yet.","","2",""},
new string[]{"Damage","Idle","No Data Yet.","","2",""},
new string[]{"Healing","Idle","No Data Yet.","","2",""},
new string[]{"Melee","Idle","No Data Yet.","","2",""},
new string[]{"Ammo","Idle","No Data Yet.","","2",""},
new string[]{"Ranged","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 24 (Holidays / Special Days)
new string[]{"Holiday","Idle","No Data Yet.","","2",""},
new string[]{"Pentecost","Idle","No Data Yet.","","2",""},
new string[]{"Christmas","Idle","No Data Yet.","","2",""},
new string[]{"Easter","Idle","No Data Yet.","","2",""},
new string[]{"New Year's Day","Idle","No Data Yet.","","2",""},
new string[]{"New Year's Eve","Idle","No Data Yet.","","2",""},
new string[]{"Ascension Day","Idle","No Data Yet.","","2",""},
new string[]{"Labor Day","Idle","No Data Yet.","","2",""},
new string[]{"Columbus Day","Idle","No Data Yet.","","2",""},
new string[]{"Veterans Day","Idle","No Data Yet.","","2",""},
new string[]{"Thanksgiving Day","Idle","No Data Yet.","","2",""},
new string[]{"Memorial Day","Idle","No Data Yet.","","2",""},
new string[]{"M. Luther King, Jr. Day","Idle","No Data Yet.","","2",""},
new string[]{"Presidents' Day","Idle","No Data Yet.","","2",""},
new string[]{"St. Andrew's Day","Idle","No Data Yet.","","2",""},
new string[]{"St. David's Day","Idle","No Data Yet.","","2",""},
new string[]{"Father's Day","Idle","No Data Yet.","","2",""},
new string[]{"Mother's Day","Idle","No Data Yet.","","2",""},
new string[]{"Independence Day","Idle","No Data Yet.","","2",""},
new string[]{"National Day","Idle","No Data Yet.","","2",""},
new string[]{"Valentine's Day","Idle","No Data Yet.","","2",""},
new string[]{"White Day","Idle","No Data Yet.","","2",""},
new string[]{"Black Friday","Idle","No Data Yet.","","2",""},
new string[]{"Cyber Monday","Idle","No Data Yet.","","2",""},
new string[]{"Golden Week","Idle","No Data Yet.","","2",""},
new string[]{"Doll's Festival (Hina Matsuri)","Idle","No Data Yet.","","2",""},
new string[]{"Coming of Age Day","Idle","No Data Yet.","","2",""},
new string[]{"Culture Day","Idle","No Data Yet.","","2",""},
new string[]{"Children's Day","Idle","No Data Yet.","","2",""},
new string[]{"Seollal Holiday","Idle","No Data Yet.","","2",""},
new string[]{"Chinese New Year","Idle","No Data Yet.","","2",""},
new string[]{"Groundhog Day","Idle","No Data Yet.","","2",""},
new string[]{"Carnival","Idle","No Data Yet.","","2",""},
new string[]{"Holloween","Idle","No Data Yet.","","2",""},
new string[]{"St. Patrick's Day","Idle","No Data Yet.","","2",""},
new string[]{"Parent's Day","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 25 (Home stuff)
new string[]{"Chair","Idle","No Data Yet.","","2",""},
new string[]{"Bench","Idle","No Data Yet.","","2",""},
new string[]{"Lounger","Idle","No Data Yet.","","2",""},
new string[]{"Table","Idle","No Data Yet.","","2",""},
new string[]{"Desk","Idle","No Data Yet.","","2",""},
new string[]{"Closet","Idle","No Data Yet.","","2",""},
new string[]{"Lavatory","Idle","No Data Yet.","","2",""},
new string[]{"Door","Idle","No Data Yet.","","2",""},
new string[]{"Window","Idle","No Data Yet.","","2",""},
new string[]{"Carpet","Idle","No Data Yet.","","2",""},
new string[]{"Floor","Idle","No Data Yet.","","2",""},
new string[]{"Rack","Idle","No Data Yet.","","2",""},
new string[]{"Safe","Idle","No Data Yet.","","2",""},
new string[]{"Stairs","Idle","No Data Yet.","","2",""},
new string[]{"Television","Idle","No Data Yet.","","2",""},
new string[]{"Radio","Idle","No Data Yet.","","2",""},
new string[]{"Receiver","Idle","No Data Yet.","","2",""},
new string[]{"Speakers","Idle","No Data Yet.","","2",""},
new string[]{"Microphone","Idle","No Data Yet.","","2",""},
new string[]{"Guitar","Idle","No Data Yet.","","2",""},
new string[]{"Drum Kit","Idle","No Data Yet.","","2",""},
new string[]{"Headphone","Idle","No Data Yet.","","2",""},
new string[]{"Washing Machine","Idle","No Data Yet.","","2",""},
new string[]{"Regrigerator","Idle","No Data Yet.","","2",""},
new string[]{"Freezer","Idle","No Data Yet.","","2",""},
new string[]{"Broom","Idle","No Data Yet.","","2",""},
new string[]{"Sweeper","Idle","No Data Yet.","","2",""},
new string[]{"Stove","Idle","No Data Yet.","","2",""},
new string[]{"Sink","Idle","No Data Yet.","","2",""},
new string[]{"Dishwasher","Idle","No Data Yet.","","2",""},
new string[]{"Pan","Idle","No Data Yet.","","2",""},
new string[]{"Plate","Idle","No Data Yet.","","2",""},
new string[]{"Fork","Idle","No Data Yet.","","2",""},
new string[]{"Knife","Idle","No Data Yet.","","2",""},
new string[]{"Spoon","Idle","No Data Yet.","","2",""},
new string[]{"Wall Outlet","Idle","No Data Yet.","","2",""},
new string[]{"Bath","Idle","No Data Yet.","","2",""},
new string[]{"Shower","Idle","No Data Yet.","","2",""},
new string[]{"Crane","Idle","No Data Yet.","","2",""},
new string[]{"Heating","Idle","No Data Yet.","","2",""},
new string[]{"Air Conditioner","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 26 (Nature / Environment)
new string[]{"Nature","Idle","No Data Yet.","","2",""},
new string[]{"Environment","Idle","No Data Yet.","","2",""},
new string[]{"Flower","Idle","No Data Yet.","","2",""},
new string[]{"Grass","Idle","No Data Yet.","","2",""},
new string[]{"Tree","Idle","No Data Yet.","","2",""},
new string[]{"Sand","Idle","No Data Yet.","","2",""},
new string[]{"Soil","Idle","No Data Yet.","","2",""},
new string[]{"Waterfall","Idle","No Data Yet.","","2",""},
new string[]{"Hills","Idle","No Data Yet.","","2",""},
new string[]{"Cave","Idle","No Data Yet.","","2",""},
new string[]{"Pine","Idle","No Data Yet.","","2",""},
new string[]{"Oak","Idle","No Data Yet.","","2",""},
new string[]{"Sunflower","Idle","No Data Yet.","","2",""},
new string[]{"Bush","Idle","No Data Yet.","","2",""},
new string[]{"Dam","Idle","No Data Yet.","","2",""},
new string[]{"Bridge","Idle","No Data Yet.","","2",""},
new string[]{"Ocean","Idle","No Data Yet.","","2",""},
new string[]{"Lake","Idle","No Data Yet.","","2",""},
new string[]{"Pond","Idle","No Data Yet.","","2",""},
new string[]{"River","Idle","No Data Yet.","","2",""},
new string[]{"Rainbow","Idle","No Data Yet.","","2",""},
new string[]{"Forest","Idle","No Data Yet.","","2",""},
new string[]{"Wilderness","Idle","No Data Yet.","","2",""},
new string[]{"Geology","Idle","No Data Yet.","","2",""},
new string[]{"Ecology","Idle","No Data Yet.","","2",""},
new string[]{"Evolution","Idle","No Data Yet.","","2",""},
new string[]{"Matter","Idle","No Data Yet.","","2",""},
new string[]{"Lava","Idle","No Data Yet.","","2",""},
new string[]{"Structure","Idle","No Data Yet.","","2",""},
new string[]{"Rocks","Idle","No Data Yet.","","2",""},
new string[]{"Atmosphere","Idle","No Data Yet.","","2",""},
new string[]{"Climate","Idle","No Data Yet.","","2",""},
new string[]{"Oxygen","Idle","No Data Yet.","","2",""},
new string[]{"Hydrogen","Idle","No Data Yet.","","2",""},
new string[]{"Water Vapor","Idle","No Data Yet.","","2",""},
new string[]{"Ecosystem","Idle","No Data Yet.","","2",""},
new string[]{"Life","Idle","No Data Yet.","","2",""},
new string[]{"Biology","Idle","No Data Yet.","","2",""},
new string[]{"Organisms","Idle","No Data Yet.","","2",""},
new string[]{"Reproduction","Idle","No Data Yet.","","2",""},
new string[]{"Growth","Idle","No Data Yet.","","2",""},
new string[]{"Microbes","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 27 (Talk / Asking exercises)
new string[]{"Can you teach me?","Idle","No Data Yet.","","2",""},
new string[]{"Sorry, I don't understand.","Idle","No Data Yet.","","2",""},
new string[]{"I want to learn sign language.","Idle","No Data Yet.","","2",""},
new string[]{"My name is…","Idle","No Data Yet.","","2",""},
new string[]{"Please wait for it.","Idle","No Data Yet.","","2",""},
new string[]{"My friend wants to join.","Idle","No Data Yet.","","2",""},
new string[]{"I want to play with you.","Idle","No Data Yet.","","2",""},
new string[]{"I'm slow at learning.","Idle","No Data Yet.","","2",""},
new string[]{"Can you repeat it?","Idle","No Data Yet.","","2",""},
new string[]{"Shall we begin?","Idle","No Data Yet.","","2",""},
new string[]{"I'm busy streaming.","Idle","No Data Yet.","","2",""},
new string[]{"Please don't distrub me.","Idle","No Data Yet.","","2",""},
new string[]{"Can you stop that?","Idle","No Data Yet.","","2",""},
new string[]{"Please follow me.","Idle","No Data Yet.","","2",""},
new string[]{"I want to change the world.","Idle","No Data Yet.","","2",""},
new string[]{"Can you write it down?","Idle","No Data Yet.","","2",""},
new string[]{"Please don't speak.","Idle","No Data Yet.","","2",""},
new string[]{"I can't hear you.","Idle","No Data Yet.","","2",""},
new string[]{"What are the rules?","Idle","No Data Yet.","","2",""},
new string[]{"Can you explain that to me?","Idle","No Data Yet.","","2",""},
new string[]{"Can you help me?","Idle","No Data Yet.","","2",""},
new string[]{"Please lead me.","Idle","No Data Yet.","","2",""},
new string[]{"I have a good idea.","Idle","No Data Yet.","","2",""},
new string[]{"I'm not feeling good.","Idle","No Data Yet.","","2",""},
new string[]{"How old are you?","Idle","No Data Yet.","","2",""},
new string[]{"Where do you come from?","Idle","No Data Yet.","","2",""},
new string[]{"Do you want to be my friend?","Idle","No Data Yet.","","2",""},
new string[]{"I'm going to sleep.","Idle","No Data Yet.","","2",""},
new string[]{"I have to work soon.","Idle","No Data Yet.","","2",""},
new string[]{"What is your Discord?","Idle","No Data Yet.","","2",""},
new string[]{"Can we talk on Discord?","Idle","No Data Yet.","","2",""},
new string[]{"Check your Discord.","Idle","No Data Yet.","","2",""},
new string[]{"I am lost here.","Idle","No Data Yet.","","2",""},
new string[]{"I'm going to my friend's.","Idle","No Data Yet.","","2",""},
new string[]{"I have some free time now.","Idle","No Data Yet.","","2",""},
new string[]{"I don't have much time.","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 28 (Name sign users)
new string[]{"Sio","ASL-Sio","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-01.mp4","2",""},
new string[]{"MrDummy_NED","ASL-MrDummy_NED","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-02.mp4","2",""},
new string[]{"Wardragon","ASL-Wardragon","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-03.mp4","2",""},
new string[]{"QQuentin","ASL-QQuentin","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-04.mp4","2",""},
new string[]{"Ray_is_deaf","ASL-Ray_is_deaf","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-05.mp4","2",""},
new string[]{"CTLucina","ASL-CTLucina","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-06.mp4","2",""},
new string[]{"Fazzion","ASL-Fazzion","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-07.mp4","2",""},
new string[]{"Jenny0629","ASL-Jenny0629","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-08.mp4","2",""},
new string[]{"Wubbles","ASL-Wubbles","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-09.mp4","2",""},
new string[]{"Sqweekslj","ASL-Sqweekslj","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-10.mp4","2",""},
new string[]{"Freddex1337","ASL-Freddex1337","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-11.mp4","2",""},
new string[]{"Max DEAF FR","ASL-Max DEAF FR","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-12.mp4","2",""},
new string[]{"Korea_Saro","ASL-Korea_Saro","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-13.mp4","2",""},
new string[]{"_MINT_","ASL-_MINT_","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-14.mp4","2",""},
new string[]{"Divamage","ASL-Divamage","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-15.mp4","2",""},
new string[]{"DeafDragon22","ASL-DeafDragon22","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-16.mp4","2",""},
new string[]{"Cha714_Deaf","ASL-Cha714_Deaf","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-17.mp4","2",""},
new string[]{"AlexDeafHero","ASL-AlexDeafHero","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-18.mp4","2",""},
new string[]{"Papa Thelius","ASL-Papa Thelius","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-19.mp4","2",""},
new string[]{"DalekTheGamer","ASL-DalekTheGamer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-20.mp4","2",""},
new string[]{"Fearlesskoolaid","ASL-Fearlesskoolaid","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-21.mp4","2",""},
new string[]{"Korea_Yujin","ASL-Korea_Yujin","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-22.mp4","2",""},

new string[]{"Ailuro","ASL-Ailuro","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-24.mp4","2",""},
new string[]{"Robyn / QueenHidi","ASL-Robyn / QueenHidi","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-25.mp4","2",""},
new string[]{"CraftyHayley","ASL-CraftyHayley","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-26.mp4","2",""},
new string[]{"[ DEAF-2030 ]","ASL-[ DEAF-2030 ]","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-27.mp4","2",""},
new string[]{"Catman2010","ASL-Catman2010","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-28.mp4","2",""},
new string[]{"Danyy59","ASL-Danyy59","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-29.mp4","2",""},
new string[]{"Darkers","ASL-Darkers","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-30.mp4","2",""},
new string[]{"Yun Big Eater","ASL-Yun Big Eater","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-31.mp4","2",""},

new string[]{"UnrealPanda","ASL-UnrealPanda","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-33.mp4","2",""},
new string[]{"Mr_Voodoo","ASL-Mr_Voodoo","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-34.mp4","2",""},
new string[]{"GT4tube","ASL-GT4tube","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-35.mp4","2",""},
new string[]{"CathDeafGamer","ASL-CathDeafGamer","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-36.mp4","2",""},
new string[]{"Angél","ASL-Angél","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-37.mp4","2",""},
new string[]{"RomainDEAF","ASL-RomainDEAF","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-38.mp4","2",""},
new string[]{"Peppers","ASL-Peppers","Anonymous","https://vrsignlanguage.net/ASL_videos/sheet28/28-39.mp4","2",""},
},
new string[][]{//Lesson 29 (Countries)
new string[]{"World","Idle","No Data Yet.","","2",""},
new string[]{"Europe","Idle","No Data Yet.","","2",""},
new string[]{"Asia","Idle","No Data Yet.","","2",""},
new string[]{"Country","Idle","No Data Yet.","","2",""},
new string[]{"North America","Idle","No Data Yet.","","2",""},
new string[]{"Central America","Idle","No Data Yet.","","2",""},
new string[]{"South America","Idle","No Data Yet.","","2",""},
new string[]{"America/USA","Idle","No Data Yet.","","2",""},
new string[]{"Canada","Idle","No Data Yet.","","2",""},
new string[]{"Mexico","Idle","No Data Yet.","","2",""},
new string[]{"Spain","Idle","No Data Yet.","","2",""},
new string[]{"France","Idle","No Data Yet.","","2",""},
new string[]{"England","Idle","No Data Yet.","","2",""},
new string[]{"Netherlands","Idle","No Data Yet.","","2",""},
new string[]{"Germany","Idle","No Data Yet.","","2",""},
new string[]{"Scandinavia","Idle","No Data Yet.","","2",""},
new string[]{"Middle East","Idle","No Data Yet.","","2",""},
new string[]{"Austrailia","Idle","No Data Yet.","","2",""},
new string[]{"Japan","Idle","No Data Yet.","","2",""},
new string[]{"China","Idle","No Data Yet.","","2",""},
new string[]{"South Korea","Idle","No Data Yet.","","2",""},
new string[]{"Russia","Idle","No Data Yet.","","2",""},
new string[]{"New Zealand","Idle","No Data Yet.","","2",""},
new string[]{"Brazil","Idle","No Data Yet.","","2",""},
new string[]{"Poland","Idle","No Data Yet.","","2",""},
new string[]{"Turkey","Idle","No Data Yet.","","2",""},
new string[]{"Isreal","Idle","No Data Yet.","","2",""},
new string[]{"Egypt","Idle","No Data Yet.","","2",""},
new string[]{"Africa","Idle","No Data Yet.","","2",""},
new string[]{"South Africa","Idle","No Data Yet.","","2",""},
new string[]{"Norway","Idle","No Data Yet.","","2",""},
new string[]{"Sweden","Idle","No Data Yet.","","2",""},
new string[]{"Finland","Idle","No Data Yet.","","2",""},
new string[]{"Austria","Idle","No Data Yet.","","2",""},
new string[]{"Italy","Idle","No Data Yet.","","2",""},
new string[]{"Portugal","Idle","No Data Yet.","","2",""},
new string[]{"Romania","Idle","No Data Yet.","","2",""},
new string[]{"Saudi Arabia","Idle","No Data Yet.","","2",""},
new string[]{"Ireland","Idle","No Data Yet.","","2",""},
new string[]{"Scotland","Idle","No Data Yet.","","2",""},
},
new string[][]{//Lesson 30 (Colors)
new string[]{"Color","ASL-Color","Anonymous","","2",""},
new string[]{"White","ASL-White","Anonymous","","2",""},
new string[]{"Black","ASL-Black","Anonymous","","2",""},
new string[]{"Red","ASL-Red","Anonymous","","2",""},
new string[]{"Blue","ASL-Blue","Anonymous","","2",""},
new string[]{"Green","ASL-Green","Anonymous","","2",""},
new string[]{"Brown","ASL-Brown","Anonymous","","2",""},
new string[]{"Pink","ASL-Pink","Anonymous","","2",""},
new string[]{"Purple","ASL-Purple","Anonymous","","2",""},
new string[]{"Yellow","ASL-Yellow","Anonymous","","2",""},
new string[]{"Orange","ASL-Orange","Anonymous","","2",""},
new string[]{"Gold","ASL-Gold","Anonymous","","2",""},
new string[]{"Silver","ASL-Silver","Anonymous","","2",""},
new string[]{"Transparent","ASL-Transparent","Anonymous","","2",""},
new string[]{"Gray","ASL-Gray","Anonymous","","2",""},
new string[]{"Light","ASL-Light","Anonymous","","2",""},
new string[]{"Dark","ASL-Dark","Anonymous","","2",""},
new string[]{"Light Blue","ASL-Light Blue","Anonymous","","2",""},
new string[]{"Dark Blue","ASL-Dark Blue","Anonymous","","2",""},
new string[]{"Tan","ASL-Tan","Anonymous","","2",""},
new string[]{"Blond","ASL-Blond","Anonymous","","2",""},
new string[]{"Gas","ASL-Gas","Anonymous","","2",""},
new string[]{"Oil","ASL-Oil","Anonymous","","2",""},
new string[]{"Glow","ASL-Glow","Anonymous","","2",""},
new string[]{"Wood","ASL-Wood","Anonymous","","2",""},
new string[]{"Metal","ASL-Metal","Anonymous","","2",""},
new string[]{"Aluminium","ASL-Aluminium","Anonymous","","2",""},
new string[]{"Fabric","ASL-Fabric","Anonymous","","2",""},
new string[]{"Glass","ASL-Glass","Anonymous","","2",""},
new string[]{"Paper","ASL-Paper","Anonymous","","2",""},
new string[]{"Plastic","ASL-Plastic","Anonymous","","2",""},
new string[]{"Rubber","ASL-Rubber","Anonymous","","2",""},
new string[]{"Foil","ASL-Foil","Anonymous","","2",""},
new string[]{"Clay","ASL-Clay","Anonymous","","2",""},
new string[]{"Water","ASL-Water","Anonymous","","2",""},
new string[]{"Gel","ASL-Gel","Anonymous","","2",""},
new string[]{"Sticker","ASL-Sticker","Anonymous","","2",""},
new string[]{"Rope","ASL-Rope","Anonymous","","2",""},
new string[]{"Wire","ASL-Wire","Anonymous","","2",""},
new string[]{"Cotton","ASL-Cotton","Anonymous","","2",""},
new string[]{"Air","ASL-Air","Anonymous","","2",""},
},
new string[][]{//Lesson 31 (Medical)
new string[]{"Doctor","ASL-Doctor","Anonymous","","2",""},
new string[]{"Nurse","ASL-Nurse","Anonymous","","2",""},
new string[]{"Hospital","ASL-Hospital","Anonymous","","2",""},
new string[]{"Sick","ASL-Sick","Anonymous","","2",""},
new string[]{"Hurt","ASL-Hurt","Anonymous","","2",""},
new string[]{"Feaver","ASL-Feaver","Anonymous","","2",""},
new string[]{"Diarrhea","ASL-Diarrhea","Anonymous","","2",""},
new string[]{"Vomit","ASL-Vomit","Anonymous","","2",""},
new string[]{"Healthy","ASL-Healthy","Anonymous","","2",""},
new string[]{"Better","ASL-Better","Anonymous","","2",""},
new string[]{"Recover","ASL-Recover","Anonymous","","2",""},
new string[]{"Pill","ASL-Pill","Anonymous","","2",""},
new string[]{"Dead (Variant 2)","ASL-Dead (Variant 2)","Anonymous","","2",""},
new string[]{"Brain","ASL-Brain","Anonymous","","2",""},
new string[]{"Receipt","ASL-Receipt","Anonymous","","2",""},
new string[]{"Headache","ASL-Headache","Anonymous","","2",""},
new string[]{"Stomachache","ASL-Stomachache","Anonymous","","2",""},
new string[]{"Pain","ASL-Pain","Anonymous","","2",""},
new string[]{"Bone Fracture","ASL-Bone Fracture","Anonymous","","2",""},
new string[]{"Wheelchair","ASL-Wheelchair","Anonymous","","2",""},
new string[]{"Stretcher","ASL-Stretcher","Anonymous","","2",""},
new string[]{"Dentist","ASL-Dentist","Anonymous","","2",""},
new string[]{"Band Aid","ASL-Band Aid","Anonymous","","2",""},
new string[]{"Bandage","ASL-Bandage","Anonymous","","2",""},
new string[]{"Wound","ASL-Wound","Anonymous","","2",""},
new string[]{"Blood","ASL-Blood","Anonymous","","2",""},
new string[]{"Crutch","ASL-Crutch","Anonymous","","2",""},
new string[]{"Eye","ASL-Eye","Anonymous","","2",""},
new string[]{"Ears","ASL-Ears","Anonymous","","2",""},
new string[]{"Nose","ASL-Nose","Anonymous","","2",""},
new string[]{"Arm","ASL-Arm","Anonymous","","2",""},
new string[]{"Legs","ASL-Legs","Anonymous","","2",""},
new string[]{"Breast","ASL-Breast","Anonymous","","2",""},
new string[]{"Belly","ASL-Belly","Anonymous","","2",""},
new string[]{"Mouth","ASL-Mouth","Anonymous","","2",""},
new string[]{"Finger","ASL-Finger","Anonymous","","2",""},
new string[]{"Elbow","ASL-Elbow","Anonymous","","2",""},
new string[]{"Knee","ASL-Knee","Anonymous","","2",""},
new string[]{"Ankle","ASL-Ankle","Anonymous","","2",""},
new string[]{"Spine","ASL-Spine","Anonymous","","2",""},
new string[]{"Skeleton","ASL-Skeleton","Anonymous","","2",""},
new string[]{"Skin","ASL-Skin","Anonymous","","2",""},
}};

    //string [][][,] AllLessons = { ASLlessons, BSLlessons }; //if multi-languages are ever implimented
    static string [][][][] AllLessons = { ASLlessons}; //adds array of arrays into another array for easy looping. 

	static string [][] lessonnames ={
	new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language.
	"Daily Use","Pointing use Question/Answer","Common",
	"People","Feelings/Reactions","Value","Time","VRChat","Alphabet/Numbers (Fingerspelling)","Verbs & Actions p1","Verbs & Actions p2: Ben-Cor",
	"Verbs & Actions p3: Cou-Esc","Verbs & Actions p4: Exc-Ins","Verbs & Actions p5: Int-Pas","Verbs & Actions p6: Pat-Sav","Verbs & Actions p7: Say-Try",
	"Verbs & Actions p8","Food",
	"Animals/Machines","Places","Stuff/Weather","Clothes/Equipment","Fantasy/Characters","Holidays/Special Days","Home stuff","Nature/Environment","Talk/Asking exercises",
	"Name sign users","Countries","Colors","Medical"}
	};
	static string [][] signlanguagenames = {
		new string[]{"ASL","American Sign Language"},
		new string[]{"BSL","British Sign Language"},
		new string[]{"GSL","German Sign Language"}
		};

	[MenuItem("ASLWorld/ButtonV5")]
	static void ButtonV5()
	{

   	//Declare some variables + settings.
	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None;
	GameObject nanapc = FindInActiveObjectByName("Nana Avatar");
	GameObject nanaquest = FindInActiveObjectByName("Nana Quest");
	nanapc.SetActive(true);
	nanaquest.SetActive(true);

	//why create two copies? Too hard to sync all the different active/inactive gameobjects if everyone isn't on the same "page".
	GameObject rootmenu = new GameObject("Menu Root");
	GameObject globalmenu = CreateMenu(rootmenu,"Global");
	GameObject localmenu = CreateMenu(rootmenu,"Local");


/*****************************************
Update menu system to point to newly created objects.
*****************************************/
//recreate toggle to fix reference? 

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
					EventType=VRC_EventHandler.VrcEventType.AnimationInt,
					ParameterObject=nanapc,
					ParameterString="sign",
					ParameterInt=-1, //animation transitions over-ride local mode, so when switching back, it must be set to something invalid.
				},
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
					ParameterObject=nanapc,
					ParameterString="Idle"
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "The sign that's currently playing will show here.",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
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
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationInt,
					ParameterObject=nanaquest,
					ParameterString="sign",
					ParameterInt=-1, //animation transitions over-ride local mode, so when switching back, it must be set to something invalid.
				},
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
					ParameterObject=nanaquest,
					ParameterString="Idle"
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "The sign that's currently playing will show here.",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "Do not use this world to learn yet. These motions are a Anonymous",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "Description of movements here. (Slowly being added)",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
				}
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
					EventType=VRC_EventHandler.VrcEventType.AnimationInt,
					ParameterObject=nanapc,
					ParameterString="sign",
					ParameterInt=-1, //animation transitions over-ride local mode, so when switching back, it must be set to something invalid.
				},
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
					ParameterObject=nanapc,
					ParameterString="Idle"
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "The sign that's currently playing will show here.",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
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
				},
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationInt,
					ParameterObject=nanaquest,
					ParameterString="sign",
					ParameterInt=-1, //animation transitions over-ride local mode, so when switching back, it must be set to something invalid.
				},
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
					ParameterObject=nanaquest,
					ParameterString="Idle"
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "The sign that's currently playing will show here.",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "Don't use this world to learn yet.",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "Description of movements here. (Slowly being added)",
					ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
				}
			}
		}
	};
	nanapc.SetActive(true);
	nanaquest.SetActive(true);
	globalmenu.SetActive(false);

    }
    static GameObject CreateMenu(GameObject parent, string mode){



	//declare toggle resource settings
	DefaultControls.Resources toggleresources = new DefaultControls.Resources();
	//Set the Toggle Background Image someBgSprite;
	toggleresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
	//Set the Toggle Checkmark Image someCheckmarkSprite;
	toggleresources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
	DefaultControls.Resources rootpanelresources = new DefaultControls.Resources();
	rootpanelresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
	DefaultControls.Resources txtresources = new DefaultControls.Resources();

	int layer=8;
	//int rowoffset=860;
	int columnoffset=200;

	int rowseperation=100;
	int columnseperation=1000;
	int togglesizedelta=80;
	int numberpercolumn = 14;
	int menusizex = 5200;
	int menusizey = 1600;
	int headersizey=60;
	int textpadding=10;
	int headerbuttonspacing=100;
	int buttonsizey=100;
	int buttonsizex=900;
	int menubuttonystart=textpadding+headersizey+buttonsizey + 80;
	Vector2 backbuttonsize=new Vector2(menusizey-headersizey-textpadding-headerbuttonspacing,buttonsizey);

	Vector2 buttonsize=new Vector2(buttonsizex,buttonsizey);
	Vector2 menusize=new Vector2(menusizex,menusizey);
	Vector3 menurootposition = new Vector3(1.5f, 0, 16);
	Vector3 canvasscale=new Vector3(.001f,.001f,.001f);
	Vector2 zerovector2=new Vector2(0,0);
	Vector3 zerovector3=new Vector3(0,0,0);

	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; 



/*****************************************
START OF PROGRAM
*****************************************/

GameObject menuroot = new GameObject(mode +" Menu Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
menuroot.transform.position = menurootposition;
menuroot.transform.SetParent(parent.transform, false);
menuroot.layer = layer;

	GameObject triggercontainer = new GameObject(mode +" Trigger Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
	triggercontainer.transform.SetParent(menuroot.transform, false);//maybe this needs to reparented to menuroot?
	triggercontainer.layer = layer;
	/*
	VRC_Trigger triggercontainertrigger = triggercontainer.AddComponent<VRC_Trigger>();
	triggercontainertrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){};
	*/

	/*
	triggercontainertrigger.Triggers.Add(
		new VRC_Trigger.TriggerEvent{
			BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
			Name="localtrigger",
			TriggerType = VRC_Trigger.TriggerType.Custom,
			TriggerIndividuals = true,
			Events=new List<VRC_EventHandler.VrcEvent>(){
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
					ParameterObject=menuroot,
					ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
				}
			}
		}
	);
	*/


	GameObject videocontainer = new GameObject(mode +" Video Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
	videocontainer.transform.position = new Vector3(-3.75f, 1, 0);
	videocontainer.transform.SetParent(menuroot.transform, false);
	videocontainer.layer = layer;

	GameObject rootcanvas = new GameObject (mode +" Root Canvas");
	rootcanvas.transform.SetParent(menuroot.transform, false);
	rootcanvas.layer = layer;
	rootcanvas.transform.localScale = canvasscale;
	rootcanvas.AddComponent<RectTransform> ();
	rootcanvas.GetComponent<RectTransform> ().localPosition = zerovector3;
	rootcanvas.GetComponent<RectTransform> ().sizeDelta = menusize;
	rootcanvas.GetComponent<RectTransform> ().anchorMax = zerovector2;
	rootcanvas.GetComponent<RectTransform> ().anchorMin = zerovector2;
	rootcanvas.GetComponent<RectTransform> ().pivot = zerovector2;
	rootcanvas.AddComponent<Canvas> (); //adds canvas to root canvas gameobject
	rootcanvas.GetComponent<Canvas> ().renderMode = RenderMode.WorldSpace;
	rootcanvas.AddComponent<CanvasScaler>();
	rootcanvas.AddComponent<GraphicRaycaster>();
	rootcanvas.AddComponent<VRC_UiShape>();
	ToggleGroup rootcanvastogglegroup = rootcanvas.AddComponent<ToggleGroup>();
	rootcanvastogglegroup.allowSwitchOff=true;

		GameObject rootpanel = DefaultControls.CreatePanel(rootpanelresources);
		rootpanel.transform.SetParent(rootcanvas.transform, false);
		rootpanel.layer = layer;
		rootpanel.GetComponent<RectTransform> ().sizeDelta = menusize;
		rootpanel.GetComponent<RectTransform> ().anchorMax = zerovector2;
		rootpanel.GetComponent<RectTransform> ().anchorMin = zerovector2;
		rootpanel.GetComponent<RectTransform> ().pivot = zerovector2;
		//rootpanel.GetComponent<Image> ().color = new Color(1,1,1,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
		if(mode=="Global"){
			rootpanel.GetComponent<Image> ().color = new Color(1,.90f,.90f,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
		}
		else{
			rootpanel.GetComponent<Image> ().color = new Color(.90f,.90f,1,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
		}
		
		GameObject langselectmenu = new GameObject("VR Sign Language Select Menu");
		langselectmenu.transform.SetParent(rootcanvas.transform, false);
		langselectmenu.layer = layer;
		
		GameObject langselectmenuheader = DefaultControls.CreateText(txtresources);
		langselectmenuheader.transform.SetParent (langselectmenu.transform, false);
		langselectmenuheader.name="VR Sign Language Select Menu Header";
		langselectmenuheader.layer = layer;
		langselectmenuheader.GetComponent<Text> ().text = "VR Sign Language Select Menu - "+mode;
		langselectmenuheader.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		langselectmenuheader.GetComponent<Text> ().fontStyle = FontStyle.Bold;
		langselectmenuheader.GetComponent<Text> ().fontSize = 50;		
		langselectmenuheader.GetComponent<Text> ().color = Color.black;
		langselectmenuheader.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
		langselectmenuheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
		langselectmenuheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-headersizey-textpadding);
		langselectmenuheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
		langselectmenuheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
		langselectmenuheader.GetComponent<RectTransform> ().pivot = zerovector2;

/*****************************************
MAIN LANGUAGE LOOP HERE
*****************************************/
        for (int languagenum=0; languagenum<AllLessons.Length;languagenum++) //for every language in signlanguages do this once:
        {


			        var wordlookup = new Dictionary<string, int>();
                    //int dictlessonnum=1;
                    //int dictwordnum=1;
                    int dictwordnumber=1;//since idle=0
                    foreach(var lesson in AllLessons[languagenum]){
                        foreach(var word in lesson){
                            int value;
                            if (!wordlookup.TryGetValue("ASL-"+word[0], out value)) {
                                wordlookup.Add("ASL-"+word[0],dictwordnumber);
								//Debug.Log("Added: "+"ASL-"+word[0]);
                                dictwordnumber++;
                            }else{
                                Debug.Log("Warning when building dictionary: Word already exists: "+"ASL-"+word[0]);
                            }

                            //dictwordnum++;
                        }
                        //dictlessonnum++;
                    }

			GameObject languagetriggercontainer = new GameObject(signlanguagenames[languagenum][0]+" Trigger Container"); //create language container for a given language to house global triggers. 
			languagetriggercontainer.transform.SetParent(triggercontainer.transform, false);
			languagetriggercontainer.layer = layer;
			VRC_Trigger languagetriggercontainertrigger = languagetriggercontainer.AddComponent<VRC_Trigger>();
			languagetriggercontainertrigger.Triggers=new List<VRC_Trigger.TriggerEvent>();
			if(mode=="Local"){
				DestroyImmediate(languagetriggercontainer);
			}

			GameObject langvideocontainer = new GameObject(signlanguagenames[languagenum][0]+" Video Container");
			langvideocontainer.transform.position = new Vector3(0, 0, 0);
			langvideocontainer.transform.SetParent(videocontainer.transform, false);
			langvideocontainer.layer = layer;

			//create a root gameobject for each language
			GameObject langroot = new GameObject(signlanguagenames[languagenum][0]+" Root"); //creates language container for a given language.
			langroot.transform.SetParent(rootcanvas.transform, false);
			langroot.layer = layer;

			//create language select button
			GameObject langselectgo = createbutton2(parent:langselectmenu, name:signlanguagenames[languagenum][1], sizedelta:buttonsize,
            localPosition: new Vector3(columnoffset+(languagenum*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(languagenum*rowseperation),0),
            text: signlanguagenames[languagenum][1], fontSize:50, txtsizedelta:buttonsize, txtanchoredPosition:new Vector2(20,0),
            alignment:TextAnchor.MiddleLeft, nav:no_nav, layer:layer);

				//Create lesson sub-menu for nested loop to parent buttons to.
				GameObject lessonmenu = new GameObject(signlanguagenames[languagenum][0]+" Lesson Menu");
				lessonmenu.transform.SetParent(langroot.transform, false);
				lessonmenu.layer = layer;
					//Create lesson menu header
					GameObject lessonselectmenuheader = DefaultControls.CreateText(txtresources);
					lessonselectmenuheader.transform.SetParent (lessonmenu.transform, false);
					lessonselectmenuheader.name=signlanguagenames[languagenum][0]+" Lesson Menu Header";
					lessonselectmenuheader.layer = layer;
					lessonselectmenuheader.GetComponent<Text> ().text = "VR-"+signlanguagenames[languagenum][0]+" Sign Language - Lesson Menu (Green = contains \"verified\" motion data.) (Yellow = contains \"Unverified\" motion data) (Red = no motion data) - "+mode;
					lessonselectmenuheader.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
					lessonselectmenuheader.GetComponent<Text> ().fontStyle = FontStyle.Bold;
					lessonselectmenuheader.GetComponent<Text> ().fontSize = 50;		
					lessonselectmenuheader.GetComponent<Text> ().color = Color.black;
					lessonselectmenuheader.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
					lessonselectmenuheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
					lessonselectmenuheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-headersizey-textpadding);
					lessonselectmenuheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
					lessonselectmenuheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
					lessonselectmenuheader.GetComponent<RectTransform> ().pivot = zerovector2;
/*****************************************
MAIN LESSON LOOP HERE
*****************************************/
					int menucolumn=0;
					int menurow=0;
				for (int lessonnum = 0; lessonnum < AllLessons[languagenum].Length; lessonnum++){ //for every lesson inside of ASLlessons do:

			GameObject lessontriggercontainer = new GameObject(signlanguagenames[languagenum][0]+" L"+(lessonnum+1)+" Trigger Container"); //create lesson container for a given language to house global triggers. 
			
			lessontriggercontainer.layer = layer;
			VRC_Trigger lessontriggercontainertrigger = lessontriggercontainer.AddComponent<VRC_Trigger>();
			lessontriggercontainertrigger.Triggers=new List<VRC_Trigger.TriggerEvent>();
			if(mode=="Global"){
				lessontriggercontainer.transform.SetParent(languagetriggercontainer.transform, false);
			}
			else{
				DestroyImmediate(lessontriggercontainer);
			}


				if (lessonnum != 0){
					if (lessonnum % numberpercolumn == 0){ //display 9 items per column
					menucolumn++;
					menurow=0;
					}
				}
					//create lesson menu button here for lessonmenu.-one at a time
					GameObject lessonbgo = createbutton2(parent:lessonmenu, name:signlanguagenames[languagenum][0]+" L"+(lessonnum+1)+"("+lessonnames[languagenum][lessonnum]+") - Button", sizedelta:buttonsize,
					//anchoredPosition: new Vector2(columnoffset+(menucolumn*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(menurow*rowseperation)),
					localPosition: new Vector3(columnoffset+(menucolumn*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(menurow*rowseperation),0),
					text: (lessonnum+1)+ ") " + lessonnames[languagenum][lessonnum], fontSize:50, txtsizedelta:buttonsize, txtanchoredPosition:new Vector2(20,0),
					alignment:TextAnchor.MiddleLeft, nav:no_nav, layer:layer);
					Button b = lessonbgo.GetOrAddComponent<Button>();
					b.onClick = new Button.ButtonClickedEvent();
					//colors the buttons to indicate what's working and what's not.
					/*
					if(lessonnum<2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0x98, 0x98, 0xFF ); //FF9898FF light red
						b.colors = colors;
					}
					if(lessonnum>1 & lessonnum<=3){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0xFF, 0x98, 0xFF ); //FF9898FF light yellow
						b.colors = colors;
					}
					if(lessonnum>=4){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0x98, 0x98, 0xFF ); //FF9898FF light red
						b.colors = colors;
					}
					*/
					if(lessonnum<2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0x98, 0xFF, 0x98, 0xFF ); //FF9898FF light green
						b.colors = colors;
					}
					if(lessonnum>=2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0xFF, 0x98, 0xFF ); //FF9898FF light yellow
						b.colors = colors;
					}
					if(lessonnum>=17){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0x98, 0x98, 0xFF ); //FF9898FF light red
						b.colors = colors;
					}
					if(lessonnum>=29){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0xFF, 0x98, 0xFF ); //FF9898FF light yellow
						b.colors = colors;
					}
					menurow++;
					//create lesson x gameobject eg: ASL Lesson x
					GameObject lessongo = new GameObject(signlanguagenames[languagenum][0]+" Lesson "+(lessonnum+1));
					lessongo.transform.SetParent(langroot.transform, false);
					lessongo.layer = layer;
					
					//create lesson x header
					GameObject lessongoheader = DefaultControls.CreateText(txtresources);
					lessongoheader.transform.SetParent (lessongo.transform, false);
					lessongoheader.name=signlanguagenames[languagenum][0]+" Lesson "+(lessonnum+1) + "- Header"; //ASL Lesson X Lesson Header
					lessongoheader.layer = layer;
					lessongoheader.GetComponent<Text> ().text = "VR-"+signlanguagenames[languagenum][0]+" Sign Language - Lesson " + (lessonnum+1) + " - " + lessonnames[languagenum][lessonnum]+" - "+mode;
					lessongoheader.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
					lessongoheader.GetComponent<Text> ().fontStyle = FontStyle.Bold;
					lessongoheader.GetComponent<Text> ().fontSize = 50;		
					lessongoheader.GetComponent<Text> ().color = Color.black;
					lessongoheader.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
					lessongoheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
					lessongoheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-headersizey-textpadding);
					lessongoheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
					lessongoheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
					lessongoheader.GetComponent<RectTransform> ().pivot = zerovector2;
					
					//create video lesson container
					GameObject videolessoncontainer = new GameObject(signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1));
					videolessoncontainer.transform.SetParent(langvideocontainer.transform, false);
					videolessoncontainer.layer=layer;

if(mode=="Global"){
//adds a broadcast trigger to the lesson button, which activates a trigger on a trigger container (which hopefully is active if global mode is on?)
					VRC_Trigger lessonbuttonvrctrigger = lessonbgo.AddComponent<VRC_Trigger>();
					lessonbuttonvrctrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
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
		new VRC_Trigger.TriggerEvent{
			BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
			Name="L"+(lessonnum+1),
			TriggerType = VRC_Trigger.TriggerType.Custom,
			TriggerIndividuals = true,
			Events=new List<VRC_EventHandler.VrcEvent>(){
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
			System.Delegate.CreateDelegate(typeof(UnityAction<string>), lessonbuttonvrctrigger,"ExecuteCustomTrigger") as UnityAction<string>
			,"globaltrigger");

}else if(mode=="Local"){

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
                    for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].Length; wordnum++){ //gets total rows in lesson.
						if (wordnum != 0){
							if (wordnum % numberpercolumn == 0){ //display 9 items per column
								wordcolumn++;
								wordrow=0;
							}
						}
						
//create previous next button paren
/*
if(wordnum!=0){
	
	//GameObject prevbutton = new GameObject(signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Prevbutton");
	//prevbutton.transform.SetParent(lessongo.transform, false);
	

					GameObject prevbutton=createbutton2(parent=lessongo, name:signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Prevbutton",
					sizedelta:buttonsize,localPosition:new Vector3 (-2125,600,-2000),
					text:"Previous Sign",txtsizedelta:new Vector2 (625, 100),txtanchoredPosition:new Vector2 (0,0), alignment:TextAnchor.MiddleCenter,
					nav:no_nav,layer:layer);


}
if(wordnum!=AllLessons[languagenum][lessonnum].GetLength(0)){
					GameObject nextbutton=createbutton2(parent=lessongo, name:signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Prevbutton",
					sizedelta:buttonsize,localPosition:new Vector3 (-1500,600,-2000),
					text:"Next Sign",txtsizedelta:new Vector2 (625, 100),txtanchoredPosition:new Vector2 (0,0), alignment:TextAnchor.MiddleCenter,
					nav:no_nav,layer:layer);
}
*/

			GameObject wordtriggercontainer = new GameObject(signlanguagenames[languagenum][0]+" L"+(lessonnum+1)+"-W"+(wordnum+1)+" Trigger Container"); //create lesson container for a given language to house global triggers. 

			wordtriggercontainer.layer = layer;
			VRC_Trigger wordtriggercontainertrigger = wordtriggercontainer.AddComponent<VRC_Trigger>();
			wordtriggercontainertrigger.Triggers=new List<VRC_Trigger.TriggerEvent>();

			if(mode=="Global"){
			wordtriggercontainer.transform.SetParent(lessontriggercontainer.transform, false);
			}
			else{
				DestroyImmediate(wordtriggercontainer);
			}

					if(mode=="Global"){
							int value=0;
							int animationint=0;
                            if (wordlookup.TryGetValue("ASL-"+AllLessons[languagenum][lessonnum][wordnum][0], out value)) {
                                animationint=value;
								//Debug.Log("Word lookup for: "+"ASL-"+AllLessons[languagenum][lessonnum][wordnum][0] + " returned: "+animationint);
                            }else{
                                Debug.Log("Warning: Word lookup failed for: "+"ASL-"+AllLessons[languagenum][lessonnum][wordnum][0]);
                            }

					GameObject buttonoffgo=createbutton2(parent=lessongo, name:signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off",
					sizedelta:buttonsize,localPosition:new Vector3(columnoffset +(wordcolumn*columnseperation),(menusizey-headersizey-textpadding-buttonsizey-100-(wordrow*rowseperation)),0),
					text:"          "+ (wordnum+1)+ ") " + AllLessons[languagenum][lessonnum][wordnum][0],txtsizedelta:new Vector2 (900, 100),txtanchoredPosition:new Vector2 (0,0), alignment:TextAnchor.MiddleLeft,
					nav:no_nav,layer:layer);
//Don't forget to create the "selected" button with checkmark (optional)
/*
					switch (AllLessons[languagenum][lessonnum][wordnum][])
					{
						case "0":
							//no icon for normal signs?
							break;
						case "1": //homesign
							GameObject homeicongo = new GameObject("Home Icon");
							homeicongo.transform.SetParent(buttonoffgo.transform, false);
							homeicongo.layer=layer;
							homeicongo.AddComponent<RectTransform> ();
							homeicongo.GetComponent<RectTransform> ().localPosition = new Vector3(450,68,0);
							homeicongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							homeicongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							homeicongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							homeicongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image homeicon= homeicongo.AddComponent<Image>();
							homeicon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/homeicon3.png");
							break;
					}
					*/
					//5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
					switch (AllLessons[languagenum][lessonnum][wordnum][4])
					{
						case "0": //indexvr
							GameObject indexicongo = new GameObject("Index VR Icon");
							indexicongo.transform.SetParent(buttonoffgo.transform, false);
							indexicongo.layer=layer;
							indexicongo.AddComponent<RectTransform> ();
							indexicongo.GetComponent<RectTransform> ().localPosition = new Vector3(514,68,0);
							indexicongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							indexicongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							indexicongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							indexicongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image indexicon= indexicongo.AddComponent<Image>();
							indexicon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/left_index_controller.png");
							break;
						case "1": //general vr
							GameObject vricongo = new GameObject("Regular VR Icon");
							vricongo.transform.SetParent(buttonoffgo.transform, false);
							vricongo.layer=layer;
							vricongo.AddComponent<RectTransform> ();
							vricongo.GetComponent<RectTransform> ().localPosition = new Vector3(514,68,0);
							vricongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							vricongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							vricongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							vricongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image vricon= vricongo.AddComponent<Image>();
							vricon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/left_htc_controller.png");
							break;
						case "2":
							GameObject allvricongo = new GameObject("Both VR Icon");
							allvricongo.transform.SetParent(buttonoffgo.transform, false);
							allvricongo.layer=layer;
							allvricongo.AddComponent<RectTransform> ();
							allvricongo.GetComponent<RectTransform> ().localPosition = new Vector3(514,68,0);
							allvricongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							allvricongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							allvricongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							allvricongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image allvricon= allvricongo.AddComponent<Image>();
							allvricon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/bothvricon.png");
							break;
					}//end switch

					VRC_Trigger buttontriggers = buttonoffgo.AddComponent<VRC_Trigger>();
					//I need to add triggers to nagivate late-joiners to the current menu by disabling earlier menus and enabling the lesson menu.


					if(AllLessons[languagenum][lessonnum][wordnum][2]=="No Data Yet."){//If no data yet, stop playing the existing shit.
						wordtriggercontainertrigger.Triggers.Add(
							new VRC_Trigger.TriggerEvent{
								BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
								Name="L"+(lessonnum+1)+"-W"+(wordnum+1),
								TriggerType = VRC_Trigger.TriggerType.Custom,
								TriggerIndividuals = true,
								Events=new List<VRC_EventHandler.VrcEvent>(){
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
										ParameterObject=lessonmenu,
										ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
										ParameterObject=lessongo,
										ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=0,
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="Idle"
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "No Data Yet",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum][2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][5],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="sign",
										ParameterInt=0,
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="Idle"
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "No Data Yet",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum][2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][5],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
									}

								}
							}
						);
					}
					else{
						
						wordtriggercontainertrigger.Triggers.Add(
							new VRC_Trigger.TriggerEvent{
								BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
								Name="L"+(lessonnum+1)+"-W"+(wordnum+1),
								TriggerType = VRC_Trigger.TriggerType.Custom,
								TriggerIndividuals = true,
								Events=new List<VRC_EventHandler.VrcEvent>(){
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
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,//maybe I should use animation intergers... less of a pain in the add to disable.
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=animationint
										//ParameterInt=int.Parse((languagenum+1)+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum+1))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum][2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][5],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="sign",
										ParameterInt=animationint
										//ParameterInt=int.Parse((languagenum+1)+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum+1))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum][2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][5],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
									}
								}
							}
						); 
					}//end else
					if(AllLessons[languagenum][lessonnum][wordnum][3]!=""){ //if url is blank, then don't create video.
						//creates the video gameobjects
						GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
						videogo.name=signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
						videogo.layer = layer;
						videogo.transform.SetParent(videolessoncontainer.transform, false);
						videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat",typeof(Material));
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url=AllLessons[languagenum][lessonnum][wordnum][3];
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping=true;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode=VideoRenderMode.MaterialOverride;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode=VideoAudioOutputMode.None;
						videogo.SetActive(false);
						wordtriggercontainertrigger.Triggers[0].Events.Add(//there should only be one trigger to add events to on this list.					
							new VRC_EventHandler.VrcEvent{
								EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
								ParameterObject=videogo,
								ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
							}
						);
					}

			//assign unity triggers to button 
			Button buttonoffbutton = buttonoffgo.GetOrAddComponent<Button>();
			buttonoffbutton.onClick = new Button.ButtonClickedEvent();
			UnityAction<string> worduiaction = System.Delegate.CreateDelegate(typeof(UnityAction<string>), buttontriggers,"ExecuteCustomTrigger") as UnityAction<string>;
			UnityEventTools.AddStringPersistentListener(buttonoffbutton.onClick, worduiaction,"L"+(lessonnum+1)+"-W"+(wordnum+1)+" globaltrigger");

			buttontriggers.Triggers.Add(
				new VRC_Trigger.TriggerEvent{
					BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered,
					TriggerType = VRC_Trigger.TriggerType.Custom,
					TriggerIndividuals = true,
					Name="L"+(lessonnum+1)+"-W"+(wordnum+1)+" globaltrigger",
					Events=new List<VRC_EventHandler.VrcEvent>(){
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

if(mode=="Local"){
					//create lesson toggles
					GameObject uiToggle = DefaultControls.CreateToggle(toggleresources);
					Toggle t = uiToggle.GetOrAddComponent<Toggle>();
					uiToggle.gameObject.name = signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Toggle";				
					uiToggle.transform.SetParent(lessongo.transform, false);
					uiToggle.layer=layer;
					uiToggle.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
					uiToggle.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((columnoffset +(wordcolumn*columnseperation)),(menusizey-headersizey-textpadding-buttonsizey-togglesizedelta/2-(wordrow*rowseperation)));
					uiToggle.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
					uiToggle.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
					uiToggle.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
					t.navigation = no_nav;
					t.isOn = false;
					t.transition= Selectable.Transition.None;
					t.toggleTransition= Toggle.ToggleTransition.None;
					t.group=rootcanvas.gameObject.GetComponent<ToggleGroup>();
					t.onValueChanged = new Toggle.ToggleEvent();
					uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (64, 64);
					uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-32,-32);
					uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
					uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
					uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
					uiToggle.transform.Find("Background").gameObject.layer=layer;

					uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().text ="          "+ (wordnum+1)+ ") " + AllLessons[languagenum][lessonnum][wordnum][0];
					uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().fontSize = 50;
					uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
					uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (750, 100);//maybe ,64
					uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (32,-50); //maybe ,-32
					uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
					uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
					uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
					uiToggle.transform.Find("Label").gameObject.layer=layer;
					
					uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (64, 64);
					uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,0);
					uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
					uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
					uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
					uiToggle.transform.Find("Background").gameObject.layer=layer;

					//0th value is the word 
					//1st value is the name of the animation trigger (needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
					//2nd value is mocap credits. 
					//3rd value is video URL.
					//4th value is home sign indicator 0 = normal, 1=homesign
					//5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
					//6th value is Sign description string
					/*
					switch (AllLessons[languagenum][lessonnum][wordnum][])
					{
						case "0":
							//no icon for normal signs?
							break;
						case "1": //homesign
							GameObject homeicongo = new GameObject("Home Icon");
							homeicongo.transform.SetParent(uiToggle.transform, false);
							homeicongo.layer=layer;
							homeicongo.AddComponent<RectTransform> ();
							homeicongo.GetComponent<RectTransform> ().localPosition = new Vector3(40,-32,0);
							homeicongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							homeicongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							homeicongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							homeicongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image homeicon= homeicongo.AddComponent<Image>();
							homeicon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/homeicon3.png");
							break;
					}
					*/
					//5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
					switch (AllLessons[languagenum][lessonnum][wordnum][4])
					{
						case "0": //indexvr
							GameObject indexicongo = new GameObject("Index VR Icon");
							indexicongo.transform.SetParent(uiToggle.transform, false);
							indexicongo.layer=layer;
							indexicongo.AddComponent<RectTransform> ();
							indexicongo.GetComponent<RectTransform> ().localPosition = new Vector3(104,-32,0);
							indexicongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							indexicongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							indexicongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							indexicongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image indexicon= indexicongo.AddComponent<Image>();
							indexicon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/left_index_controller.png");
							break;
						case "1": //general vr
							GameObject vricongo = new GameObject("Regular VR Icon");
							vricongo.transform.SetParent(uiToggle.transform, false);
							vricongo.layer=layer;
							vricongo.AddComponent<RectTransform> ();
							vricongo.GetComponent<RectTransform> ().localPosition = new Vector3(104,-32,0);
							vricongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							vricongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							vricongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							vricongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image vricon= vricongo.AddComponent<Image>();
							vricon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/left_htc_controller.png");
							break;
						case "2":
							GameObject allvricongo = new GameObject("Both VR Icon");
							allvricongo.transform.SetParent(uiToggle.transform, false);
							allvricongo.layer=layer;
							allvricongo.AddComponent<RectTransform> ();
							allvricongo.GetComponent<RectTransform> ().localPosition = new Vector3(104,-32,0);
							allvricongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							allvricongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							allvricongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							allvricongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image allvricon= allvricongo.AddComponent<Image>();
							allvricon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/bothvricon.png");
							break;
					}//end switch
					//

//since I'm forking the wordlists from Mr.Dummy, there will be a scenario where there is no video.
					if(AllLessons[languagenum][lessonnum][wordnum][3]!=""){ //if url is blank, then don't create video.

						//creates the video gameobjects
						GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
						videogo.name=signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
						videogo.layer = layer;
						videogo.transform.SetParent(videolessoncontainer.transform, false);
						videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat",typeof(Material));
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url=AllLessons[languagenum][lessonnum][wordnum][3];
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping=true;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode=VideoRenderMode.MaterialOverride;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode=VideoAudioOutputMode.None;
						videogo.SetActive(false);
						UnityEventTools.AddPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videogo//the target of the action
						, "set_active") as UnityAction<bool>);
						}
					
					if(AllLessons[languagenum][lessonnum][wordnum][2]=="No Data Yet."){
					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar").GetComponent<Animator>()//the target of the action
					, "Play") as UnityAction<string>,"Idle");
					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Quest").GetComponent<Animator>()//the target of the action
					, "Play") as UnityAction<string>,"Idle");
					}else{
						UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar").GetComponent<Animator>()//the target of the action
					, "Play") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum][1]);
						UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Quest").GetComponent<Animator>()//the target of the action
					, "Play") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum][1]);
					}
					
					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,(lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum][0]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,"This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum][2]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum][5]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,(lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum][0]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,"This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum][2]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum][5]);

					wordrow++;
}
                    } //end local
					/*****************************************
					End of word loop.
					*****************************************/


				if(mode=="Global"){
				//I need another loop to add all the triggers to deactivate videos for global mode
				//these triggers belong on the helper gameobjects.
					for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].Length; wordnum++){ //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.
					List<GameObject> listofvideos = new List<GameObject>();
					//i need another for loop to add every single video gameobject EXCEPT the current word.
						for(int x=0;x<AllLessons[languagenum][lessonnum].Length; x++){
							if(x!=wordnum){//exclude the one I want to play- build list of all others in the lesson.
								if(GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Video Container/"+signlanguagenames[languagenum][0]+" Video Container/"+
								signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1)+"/"+
								signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1) +" S"+(x+1))){//if it's not null then add it
									listofvideos.Add(GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Video Container/"+signlanguagenames[languagenum][0]+" Video Container/"+
									signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1)+"/"+
									signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1) +" S"+(x+1)));
								}
								//add disable triggers to non-selected animators
								/*
							GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Root Canvas/" +signlanguagenames[languagenum][0]+ " Root/"+ signlanguagenames[languagenum][0] + " Lesson " + (lessonnum+1)+"/"+
							signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off").
							GetComponent<VRC_Trigger>().Triggers[0].Events.Add(
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationBool,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString=AllLessons[languagenum][lessonnum][x,1],
										ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
									}
								);
								*/
							}//end exclusion loop
						}//end for loop
							//disables nonselected videos
							GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Trigger Container/" +signlanguagenames[languagenum][0]+ " Trigger Container/"
							+ signlanguagenames[languagenum][0] + " L" + (lessonnum+1)+" Trigger Container/"+
							signlanguagenames[languagenum][0]+" L" + (lessonnum+1) + "-W" + (wordnum+1) +" Trigger Container").
							GetComponent<VRC_Trigger>().Triggers[0].Events.Add(
								new VRC_EventHandler.VrcEvent{
									EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
									ParameterObjects=listofvideos.ToArray(),
									ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
								}
							);
/*
//prev/next button here assign trigger
//
if((wordnum+1) < AllLessons[languagenum][lessonnum].GetLength(0)){
VRC_Trigger nextbuttontrigger = GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Root Canvas/"+signlanguagenames[languagenum][0]+" Root/"
+signlanguagenames[languagenum][0]+" Lesson "+(lessonnum+1)+
	signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Nextbutton").GetOrAddComponent<VRC_Trigger>();
	nextbuttontrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
		new VRC_Trigger.TriggerEvent{
			BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
			TriggerType = VRC_Trigger.TriggerType.OnEnable,
			TriggerIndividuals = true,
			Events=new List<VRC_EventHandler.VrcEvent>(){
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=int.Parse((languagenum+1)+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum+2))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum+1,0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum+1,2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][5],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="sign",
										ParameterInt=int.Parse((languagenum+1)+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum+2))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum+1,0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum+1,2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum+1,6],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
									}

			}
		}
	};

}

if((wordnum-1) !=0){
VRC_Trigger prevbuttontrigger = GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Root Canvas/"+signlanguagenames[languagenum][0]+" Root/"
+signlanguagenames[languagenum][0]+" Lesson "+(lessonnum+1)+
	signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Prevbutton").GetOrAddComponent<VRC_Trigger>();
	prevbuttontrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
		new VRC_Trigger.TriggerEvent{
			BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
			TriggerType = VRC_Trigger.TriggerType.OnEnable,
			TriggerIndividuals = true,
			Events=new List<VRC_EventHandler.VrcEvent>(){
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=int.Parse((languagenum+1)+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum-1,0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum-1,2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][5],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="sign",
										ParameterInt=int.Parse((languagenum+1)+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum-1,0],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum-1,2],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum-1,6],
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
									}

			}
		}
	};

}
*/

					}; //end for loop
				} //endif global

				//Create back button
				GameObject backtolessongo = createbutton2(parent:lessongo, name:"Return to VR-" + signlanguagenames[languagenum][0] + " Lesson Menu", sizedelta:backbuttonsize,
				localPosition: new Vector3(buttonsizey, 0,0),
				text: "Return to VR-" + signlanguagenames[languagenum][0] + " Lesson Menu", fontSize:50, txtsizedelta:backbuttonsize, txtanchoredPosition:new Vector2(20,0), 
				alignment:TextAnchor.MiddleCenter, nav:no_nav,rotatez:90, layer:layer);

				Button backbutton = backtolessongo.GetOrAddComponent<Button>();
				backbutton.onClick = new Button.ButtonClickedEvent();
				
				if(mode=="Local"){
				//try disabling all the checkboxes first before doing anything else?
				UnityAction disablealltoggles = System.Delegate.CreateDelegate(typeof(UnityAction), rootcanvastogglegroup,"SetAllTogglesOff") as UnityAction;
				UnityEventTools.AddPersistentListener(backbutton.onClick, disablealltoggles);

				//disable the current active lesson when clicked
				UnityAction<bool> disablecurrentlesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessongo, "SetActive") as UnityAction<bool>;
				UnityEventTools.AddBoolPersistentListener(backbutton.onClick, disablecurrentlesson, false);

				//reset animator
					UnityEventTools.AddStringPersistentListener(backbutton.onClick, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Signing Avatars/Nana Avatar").GetComponent<Animator>()//the target of the action
					, "Play") as UnityAction<string>,"Idle");

				//enable the lesson select
				UnityAction<bool> enablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessonmenu, "SetActive") as UnityAction<bool>;
				UnityEventTools.AddBoolPersistentListener(backbutton.onClick, enablelessonmenu, true);

				//UnityAction<bool> disablevideolessoncontainer = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find("/Menu Root/Video Container/"+lang+" Video Container/"+lang+" Video L"+(lessonnum+1)), "SetActive") as UnityAction<bool>;
				UnityAction<bool> disablevideolessoncontainer = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videolessoncontainer, "SetActive") as UnityAction<bool>;
				UnityEventTools.AddBoolPersistentListener(backbutton.onClick, disablevideolessoncontainer, false);
				}else if(mode=="Global")
				{
					VRC_Trigger vrcbacktolessontrigger = backtolessongo.GetOrAddComponent<VRC_Trigger>();
					
					vrcbacktolessontrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
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
							new VRC_Trigger.TriggerEvent{
							BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
							Name="L"+(lessonnum+1)+" back button",
							TriggerType = VRC_Trigger.TriggerType.Custom,
							TriggerIndividuals = true,
							Events=new List<VRC_EventHandler.VrcEvent>(){
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
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=0,
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Avatar"),
										ParameterString="Idle"
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Avatar/Canvas/Description Panel/Description Text")
								},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="sign",
										ParameterInt=0,
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
										ParameterObject=GameObject.Find ("/Signing Avatars/Nana Quest"),
										ParameterString="Idle"
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Signing Avatars/Nana Quest/Canvas/Description Panel/Description Text")
									}
							}
						}//add something to disable all videos in the lesson
);

					UnityEventTools.AddStringPersistentListener(backbutton.onClick, 
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), vrcbacktolessontrigger,"ExecuteCustomTrigger") as UnityAction<string>,
					"L"+(lessonnum+1)+" globaltrigger");
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
			if(mode=="Local"){
			UnityAction<bool> enableaslroot = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum][0]+" Root"), "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enableaslroot, true);

			UnityAction<bool> enableaslmenuselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum][0]+" Lesson Menu"), "SetActive") as UnityAction<bool>;//GameObject.Find("Menu Root/Root Canvas/ASL Root/ASL Lesson Menu")
			UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enableaslmenuselect, true);

			UnityAction<bool> disablelanguageselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), langselectmenu, "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, disablelanguageselect, false);
			//activates video container for specific language
			UnityAction<bool> enablevideolanguage = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), langvideocontainer, "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enablevideolanguage, true);
			}else if(mode=="Global")
			{
				VRC_Trigger vrclangselecttrigger = langselectgo.GetOrAddComponent<VRC_Trigger>();
				
				vrclangselecttrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
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
					new VRC_Trigger.TriggerEvent{
						BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
						Name=signlanguagenames[languagenum][0]+" Trigger",
						TriggerType = VRC_Trigger.TriggerType.Custom,
						TriggerIndividuals = true,
						Events=new List<VRC_EventHandler.VrcEvent>(){
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
				System.Delegate.CreateDelegate(typeof(UnityAction<string>), vrclangselecttrigger,"ExecuteCustomTrigger") as UnityAction<string>,
				"globaltrigger");
			}
			
			//Create return to Language Menu
			GameObject backtolanguagemenu = createbutton2(parent:lessonmenu, name:"Return to Language Menu", sizedelta:backbuttonsize,
			localPosition: new Vector3(buttonsizey, 0,0),
			text: "Return to Language Menu", fontSize:50, txtsizedelta:backbuttonsize, txtanchoredPosition:new Vector2(20,0), 
			alignment:TextAnchor.MiddleCenter, nav:no_nav,rotatez:90, layer:layer);

			Button languagebackbutton = backtolanguagemenu.GetOrAddComponent<Button>();
			languagebackbutton.onClick = new Button.ButtonClickedEvent();

			if(mode=="Local"){
			//disable the current active lesson when back button clicked
			UnityAction<bool> disablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessonmenu, "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(languagebackbutton.onClick, disablelessonmenu, false);

			//enable the lesson select  when back button clicked
			UnityAction<bool> enablelangmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), langselectmenu, "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(languagebackbutton.onClick, enablelangmenu, true);
			}else if(mode=="Global")
			{
				VRC_Trigger backtolanguagemenutrigger = backtolanguagemenu.GetOrAddComponent<VRC_Trigger>();
				
				backtolanguagemenutrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
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
					new VRC_Trigger.TriggerEvent{
						BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
						Name="backtolangselectfrom"+signlanguagenames[languagenum][0],
						TriggerType = VRC_Trigger.TriggerType.Custom,
						TriggerIndividuals = true,
						Events=new List<VRC_EventHandler.VrcEvent>(){
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
				System.Delegate.CreateDelegate(typeof(UnityAction<string>), backtolanguagemenutrigger,"ExecuteCustomTrigger") as UnityAction<string>,
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


static GameObject FindInActiveObjectByName(string name){
    Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    for (int i = 0; i < objs.Length; i++){
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].name == name){
                return objs[i].gameObject;
            }
        }
    }
return null;
}

//the latest button creation code. now with default values - allowing for optional arguments
static GameObject createbutton2(GameObject parent, string name,Vector2 sizedelta,Vector3 localPosition,//Vector2 anchoredPosition
string text,Vector2 txtsizedelta,Vector2 txtanchoredPosition, TextAnchor alignment,Navigation nav,int layer,int rotatex=0,int rotatey=0,int rotatez=0,int fontSize=50){

DefaultControls.Resources buttonresources = new DefaultControls.Resources();
buttonresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
//toggleresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
GameObject go = DefaultControls.CreateButton(buttonresources);
go.layer = layer;
go.transform.SetParent(parent.transform, false);
go.name = name;	
Button b = go.GetOrAddComponent<Button>();
b.navigation = nav;
go.GetComponent<RectTransform> ().sizeDelta = sizedelta;
go.GetComponent<RectTransform> ().eulerAngles = new Vector3(rotatex, rotatey, rotatez);//x,y,z
//go.GetComponent<RectTransform> ().anchoredPosition = anchoredPosition;
go.GetComponent<RectTransform> ().localPosition = localPosition;
go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
go.transform.Find("Text").gameObject.GetComponent<Text>().text = text;
go.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = fontSize;
go.transform.Find("Text").gameObject.GetComponent<Text>().alignment = alignment;
go.transform.Find("Text").gameObject.GetComponent<RectTransform>().sizeDelta = txtsizedelta;
go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchoredPosition = txtanchoredPosition;
go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
go.transform.Find("Text").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
return go;
}
}
}
#endif