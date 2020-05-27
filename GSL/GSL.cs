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
public class CreateGSLButtons5 : MonoBehaviour 
{

	/*****************************************
	Start of Arrays variable declarations
	*****************************************/

	    //creates an array of arrays. Grouped by lessons. 
        //0th value is the word 
        //1st value is video URL.

static 
string [][][] GSLlessons = {
new string[][]{//Lesson 1(Daily Use)
new string[]{"Hello","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4"},
new string[]{"How (are) You","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4"},
new string[]{"What's Up?","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4"},
new string[]{"What's Up? (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4"},
new string[]{"Nice (to) Meet You","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4"},
new string[]{"Good","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4"},
new string[]{"Bad","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4"},
new string[]{"Yes","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4"},
new string[]{"No","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4"},
new string[]{"So-So","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4"},
new string[]{"Sick","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4"},
new string[]{"Sick (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4"},
new string[]{"Hurt","https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4"},
new string[]{"You're Welcome","https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4"},
new string[]{"Goodbye","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4"},
new string[]{"Good Morning","https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4"},
new string[]{"Good Afternoon","https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4"},
new string[]{"Good Evening","https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4"},
new string[]{"Good Night","https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4"},
new string[]{"See You Later","https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4"},
new string[]{"Please","https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4"},
new string[]{"Sorry","https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4"},
new string[]{"Forget","https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4"},
new string[]{"Sleep / Sleepy","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4"},
new string[]{"Bed","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4"},
new string[]{"Jump / Change World","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4"},
new string[]{"Thank You","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4"},
new string[]{"I Love You","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4"},
new string[]{"ILY (I Love You)",""},
new string[]{"Go Away","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4"},
new string[]{"Going To","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4"},
new string[]{"Follow","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4"},
new string[]{"Come","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4"},
new string[]{"Hearing (Person)","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4"},
new string[]{"Deaf","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4"},
new string[]{"Deaf (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4"},
new string[]{"Hard of Hearing","https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4"},
new string[]{"Mute","https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4"},
new string[]{"Write Slow","https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4"},
new string[]{"Can't Read","https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4"},
new string[]{"Away",""},
},
new string[][]{//Lesson 2(Pointing use Question / Answer)
new string[]{"I (Me)","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4"},
new string[]{"My","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4"},
new string[]{"Your","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4"},
new string[]{"His","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4"},
new string[]{"Her","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4"},
new string[]{"We","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4"},
new string[]{"They","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4"},
new string[]{"Their","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4"},
new string[]{"Over There","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4"},
new string[]{"Our","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4"},
new string[]{"It's","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4"},
new string[]{"Inside","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4"},
new string[]{"Outside",""},
new string[]{"Outside (Outdoors)","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4"},
new string[]{"Hidden","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4"},
new string[]{"Behind","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4"},
new string[]{"Above","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4"},
new string[]{"Below","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4"},
new string[]{"Here","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4"},
new string[]{"Beside","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4"},
new string[]{"Back","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4"},
new string[]{"Front","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4"},
new string[]{"Who","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4"},
new string[]{"Where","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4"},
new string[]{"When","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4"},
new string[]{"Why","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4"},
new string[]{"Which","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4"},
new string[]{"What","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4"},
new string[]{"What (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4"},
new string[]{"How","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4"},
new string[]{"How (Variant 2)",""},
new string[]{"How Many","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4"},
new string[]{"How Many (Variant 2)",""},
new string[]{"Can","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4"},
new string[]{"Can't","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4"},
new string[]{"Want","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4"},
new string[]{"Have","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4"},
new string[]{"Get","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4"},
new string[]{"Will / Future","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4"},
new string[]{"Take (Up)","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4"},
new string[]{"Need","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4"},
new string[]{"Must",""},
new string[]{"Not","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4"},
new string[]{"Or","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4"},
new string[]{"And","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4"},
new string[]{"For","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4"},
new string[]{"At","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4"},
new string[]{"At (Variant 2)",""},
},
new string[][]{//Lesson 3(Common)
new string[]{"Teach","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4"},
new string[]{"Learn","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4"},
new string[]{"Person","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4"},
new string[]{"Student","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4"},
new string[]{"Teacher","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4"},
new string[]{"Friend","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4"},
new string[]{"Sign","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4"},
new string[]{"Language","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4"},
new string[]{"Understand","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4"},
new string[]{"Know","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4"},
new string[]{"Don't Know","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4"},
new string[]{"Be Right Back (BRB)","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4"},
new string[]{"Accept","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4"},
new string[]{"Denied","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4"},
new string[]{"Name","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4"},
new string[]{"New","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4"},
new string[]{"Old","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4"},
new string[]{"Very","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4"},
new string[]{"Jokes","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4"},
new string[]{"Funny","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4"},
new string[]{"Play","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4"},
new string[]{"Favorite","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4"},
new string[]{"Draw","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4"},
new string[]{"Stop","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4"},
new string[]{"Read","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4"},
new string[]{"Make","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4"},
new string[]{"Write","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4"},
new string[]{"Again / Repeat","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4"},
new string[]{"Slow","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4"},
new string[]{"Fast","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4"},
new string[]{"Rude","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4"},
new string[]{"Eat","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4"},
new string[]{"Drink","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4"},
new string[]{"Watch","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4"},
new string[]{"Work","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4"},
new string[]{"Live",""},
new string[]{"Live (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4"},
new string[]{"Play Game","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4"},
new string[]{"Same","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4"},
new string[]{"Alright","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4"},
new string[]{"People","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4"},
new string[]{"Browsing the Internet","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4"},
new string[]{"Movie","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4"},
},
new string[][]{//Lesson 4(People)
new string[]{"Family","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4"},
new string[]{"Boy","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4"},
new string[]{"Girl","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4"},
new string[]{"Brother","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4"},
new string[]{"Sister","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4"},
new string[]{"Brother-in-law","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4"},
new string[]{"Sister-in-law","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4"},
new string[]{"Father","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4"},
new string[]{"Grandpa","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4"},
new string[]{"Mother","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4"},
new string[]{"Grandma","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4"},
new string[]{"Baby","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4"},
new string[]{"Child","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4"},
new string[]{"Teen","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4"},
new string[]{"Adult","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4"},
new string[]{"Aunt","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4"},
new string[]{"Uncle","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4"},
new string[]{"Stranger","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4"},
new string[]{"Acquaintance","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4"},
new string[]{"Parents","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4"},
new string[]{"Born","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4"},
new string[]{"Dead","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4"},
new string[]{"Marriage","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4"},
new string[]{"Divorce","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4"},
new string[]{"Single","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4"},
new string[]{"Young","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4"},
new string[]{"Old","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4"},
new string[]{"Age","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4"},
new string[]{"Birthday","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4"},
new string[]{"Celebrate","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4"},
new string[]{"Enemy","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4"},
new string[]{"Interpreter","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4"},
new string[]{"No One","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4"},
new string[]{"Anyone","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4"},
new string[]{"Someone","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4"},
new string[]{"Everyone","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4"},
},
new string[][]{//Lesson 5(Feelings / Reactions)
new string[]{"Like","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4"},
new string[]{"Hate","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4"},
new string[]{"Fine","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4"},
new string[]{"Tired","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4"},
new string[]{"Sleep / Sleepy","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4"},
new string[]{"Confused","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4"},
new string[]{"Smart","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4"},
new string[]{"Attention / Focus","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4"},
new string[]{"Nevermind","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4"},
new string[]{"Angry","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4"},
new string[]{"Laughing","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4"},
new string[]{"LOL","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4"},
new string[]{"Curious","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4"},
new string[]{"In Love","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4"},
new string[]{"Awesome","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4"},
new string[]{"Great","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4"},
new string[]{"Nice","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4"},
new string[]{"Cute","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4"},
new string[]{"Feel","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4"},
new string[]{"Pity","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4"},
new string[]{"Envy","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4"},
new string[]{"Hungry","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4"},
new string[]{"Alive","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4"},
new string[]{"Bored","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4"},
new string[]{"Cry","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4"},
new string[]{"Happy","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4"},
new string[]{"Sad","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4"},
new string[]{"Suffering","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4"},
new string[]{"Surprised","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4"},
new string[]{"Careful","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4"},
new string[]{"Enjoy","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4"},
new string[]{"Disgusted","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4"},
new string[]{"Embarrassed","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4"},
new string[]{"Shy","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4"},
new string[]{"Lonely","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4"},
new string[]{"Stressed","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4"},
new string[]{"Scared","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4"},
new string[]{"Excited","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4"},
new string[]{"Shame","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4"},
new string[]{"Struggle","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4"},
new string[]{"Friendly","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4"},
new string[]{"Mean","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4"},
},
new string[][]{//Lesson 6(Value)
new string[]{"More","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4"},
new string[]{"Less","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4"},
new string[]{"Big","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4"},
new string[]{"Small / A Little","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4"},
new string[]{"Full","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4"},
new string[]{"Empty","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4"},
new string[]{"Half","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4"},
new string[]{"Quarter","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4"},
new string[]{"Long","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4"},
new string[]{"Short (Time)","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4"},
new string[]{"A Lot / Many","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4"},
new string[]{"Unlimited","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4"},
new string[]{"Limited","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4"},
new string[]{"All","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4"},
new string[]{"All (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4"},
new string[]{"Nothing","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4"},
new string[]{"Ever","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4"},
new string[]{"Everything","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4"},
new string[]{"Everytime","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4"},
new string[]{"Always","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4"},
new string[]{"Often","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4"},
new string[]{"Sometimes","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4"},
new string[]{"Heavy","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4"},
new string[]{"Lightweight","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4"},
new string[]{"Hard","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4"},
new string[]{"Soft","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4"},
new string[]{"Strong","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4"},
new string[]{"Weak","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4"},
new string[]{"First","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4"},
new string[]{"Second","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4"},
new string[]{"Third","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4"},
new string[]{"Next","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4"},
new string[]{"Last","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4"},
new string[]{"Before","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4"},
new string[]{"After","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4"},
new string[]{"Busy","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4"},
new string[]{"Free","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4"},
new string[]{"High","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4"},
new string[]{"Low","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4"},
new string[]{"Fat","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4"},
new string[]{"Thin","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4"},
new string[]{"Value","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4"},
},
new string[][]{//Lesson 7(Time)
new string[]{"Time","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4"},
new string[]{"Year","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4"},
new string[]{"Season","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4"},
new string[]{"Month","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4"},
new string[]{"Week","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4"},
new string[]{"Day","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4"},
new string[]{"Weekend","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4"},
new string[]{"Hours","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4"},
new string[]{"Minutes","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4"},
new string[]{"Seconds","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4"},
new string[]{"Today","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4"},
new string[]{"Tomorrow","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4"},
new string[]{"Yesterday","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4"},
new string[]{"Morning","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4"},
new string[]{"Afternoon","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4"},
new string[]{"Evening","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4"},
new string[]{"Night","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4"},
new string[]{"Sunrise","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4"},
new string[]{"Sunset","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4"},
new string[]{"All Day","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4"},
new string[]{"All Day (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4"},
new string[]{"All Night","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4"},
new string[]{"All Night (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4"},
new string[]{"Sunday","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4"},
new string[]{"Monday","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4"},
new string[]{"Tuesday","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4"},
new string[]{"Wednesday","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4"},
new string[]{"Thursday","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4"},
new string[]{"Friday","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4"},
new string[]{"Saturday","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4"},
new string[]{"Autumn","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4"},
new string[]{"Winter","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4"},
new string[]{"Spring","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4"},
new string[]{"Summer","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4"},
new string[]{"Now","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4"},
new string[]{"Never","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4"},
new string[]{"Soon","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4"},
new string[]{"Later","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4"},
new string[]{"Past","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4"},
new string[]{"Future","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4"},
new string[]{"Earlier","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4"},
new string[]{"Midweek","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4"},
new string[]{"Next Week","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4"},
},
new string[][]{//Lesson 8(VRChat)
new string[]{"Gestures","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4"},
new string[]{"World","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4"},
new string[]{"Record","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4"},
new string[]{"Discord","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4"},
new string[]{"Streaming","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4"},
new string[]{"Headset (VR)","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4"},
new string[]{"Desktop","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4"},
new string[]{"Computer","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4"},
new string[]{"Instance","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4"},
new string[]{"Public","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4"},
new string[]{"Invite","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4"},
new string[]{"Private","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4"},
new string[]{"Add Friend","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4"},
new string[]{"Menu","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4"},
new string[]{"Recharge","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4"},
new string[]{"Visit","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4"},
new string[]{"Request","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4"},
new string[]{"Login","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4"},
new string[]{"Logout","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4"},
new string[]{"Schedule","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4"},
new string[]{"Event","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4"},
new string[]{"Online","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4"},
new string[]{"Offline","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4"},
new string[]{"Cancel","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4"},
new string[]{"Portal","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4"},
new string[]{"Camera","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4"},
new string[]{"Avatar","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4"},
new string[]{"Photo","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4"},
new string[]{"Join","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4"},
new string[]{"Leave","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4"},
new string[]{"Climbing","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4"},
new string[]{"Falling","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4"},
new string[]{"Walk","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4"},
new string[]{"Hide","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4"},
new string[]{"Block","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4"},
new string[]{"Crash","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4"},
new string[]{"Lagging","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4"},
new string[]{"Restart","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4"},
new string[]{"Send","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4"},
new string[]{"Receive","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4"},
new string[]{"Security","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4"},
new string[]{"Donation","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4"},
},
new string[][]{//Lesson 9(Alphabet / Numbers (Fingerspelling))
new string[]{"Spell / Fingerspell","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4"},
new string[]{"Spell / Fingerspell (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4"},
new string[]{"A","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4"},
new string[]{"B","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4"},
new string[]{"B (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4"},
new string[]{"C","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4"},
new string[]{"D","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4"},
new string[]{"E","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4"},
new string[]{"F","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4"},
new string[]{"F (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4"},
new string[]{"G","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4"},
new string[]{"H","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4"},
new string[]{"I","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4"},
new string[]{"I (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4"},
new string[]{"J","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4"},
new string[]{"J (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4"},
new string[]{"K","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4"},
new string[]{"K (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4"},
new string[]{"L","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4"},
new string[]{"M","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4"},
new string[]{"M (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4"},
new string[]{"N","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4"},
new string[]{"N (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4"},
new string[]{"O","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4"},
new string[]{"P","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4"},
new string[]{"Q","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4"},
new string[]{"R","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4"},
new string[]{"S","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4"},
new string[]{"T","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4"},
new string[]{"U","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4"},
new string[]{"U (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4"},
new string[]{"V","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4"},
new string[]{"V (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4"},
new string[]{"W","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4"},
new string[]{"W (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4"},
new string[]{"X","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4"},
new string[]{"X (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4"},
new string[]{"Y","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4"},
new string[]{"Y (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4"},
new string[]{"Z","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4"},
new string[]{"Comma","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4"},
new string[]{"Space","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4"},
new string[]{"@",""},
new string[]{"Number",""},
new string[]{"0","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4"},
new string[]{"1","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4"},
new string[]{"2","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4"},
new string[]{"3","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4"},
new string[]{"4","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4"},
new string[]{"5","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4"},
new string[]{"6","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4"},
new string[]{"7","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4"},
new string[]{"8","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4"},
new string[]{"9","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4"},
new string[]{"10","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4"},
new string[]{"100","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4"},
new string[]{"1000","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4"},
new string[]{"1000000","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4"},
},
new string[][]{//Lesson 10(Verbs & Actions p1)
new string[]{"Overlook","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4"},
new string[]{"Punish","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4"},
new string[]{"Edit","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4"},
new string[]{"Erase","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4"},
new string[]{"Write","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4"},
new string[]{"Proposal","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4"},
new string[]{"Add","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4"},
new string[]{"Remove","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4"},
new string[]{"Agree","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4"},
new string[]{"Disagree","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4"},
new string[]{"Admit","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4"},
new string[]{"Allow","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4"},
new string[]{"Attack","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4"},
new string[]{"Fight","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4"},
new string[]{"Defend","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4"},
new string[]{"Defeat (Overcome)","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4"},
new string[]{"Win","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4"},
new string[]{"Lose","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4"},
new string[]{"Draw / Tie (Game)","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4"},
new string[]{"Give Up","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4"},
new string[]{"Skip","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4"},
new string[]{"Ask",""},
new string[]{"Attach","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4"},
new string[]{"Assistant","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4"},
new string[]{"Assist / Help",""},
new string[]{"Bait","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4"},
new string[]{"Battle","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4"},
new string[]{"Beat (Overcome)","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4"},
new string[]{"Become","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4"},
new string[]{"Beg","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4"},
new string[]{"Begin / Start","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4"},
new string[]{"Behave","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4"},
new string[]{"Believe","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4"},
new string[]{"Blame","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4"},
new string[]{"Blow","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4"},
new string[]{"Blush","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4"},
new string[]{"Bother / Harass","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4"},
},
new string[][]{//Lesson 11(Verbs & Actions p2: Ben-Cor)
new string[]{"Bend","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4"},
new string[]{"Bow","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4"},
new string[]{"Break","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4"},
new string[]{"Breathe","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4"},
new string[]{"Bring","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4"},
new string[]{"Build / Construct","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4"},
new string[]{"Bully","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4"},
new string[]{"Burn","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4"},
new string[]{"Buy","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4"},
new string[]{"Call","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4"},
new string[]{"Cancel","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4"},
new string[]{"Care","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4"},
new string[]{"Carry","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4"},
new string[]{"Catch","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4"},
new string[]{"Cause","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4"},
new string[]{"Challenge","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4"},
new string[]{"Chance","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4"},
new string[]{"Cheat","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4"},
new string[]{"Check","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4"},
new string[]{"Choose","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4"},
new string[]{"Claim","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4"},
new string[]{"Clean","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4"},
new string[]{"Clear","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4"},
new string[]{"Close","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4"},
new string[]{"Comfort","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4"},
new string[]{"Command","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4"},
new string[]{"Communicate","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4"},
new string[]{"Compare","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4"},
new string[]{"Complain","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4"},
new string[]{"Compliment","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4"},
new string[]{"Concentrate","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4"},
new string[]{"Construct / Build","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4"},
new string[]{"Control","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4"},
new string[]{"Cook","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4"},
new string[]{"Copy","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4"},
new string[]{"Correct","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4"},
},
new string[][]{//Lesson 12(Verbs & Actions p3: Cou-Esc)
new string[]{"Cough","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4"},
new string[]{"Count","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4"},
new string[]{"Create","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4"},
new string[]{"Cuddle","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4"},
new string[]{"Cut","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4"},
new string[]{"Dab","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4"},
new string[]{"Dance","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4"},
new string[]{"Dare","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4"},
new string[]{"Date","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4"},
new string[]{"Deal","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4"},
new string[]{"Deliver","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4"},
new string[]{"Depend","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4"},
new string[]{"Describe","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4"},
new string[]{"Dirty","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4"},
new string[]{"Disappear","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4"},
new string[]{"Disappoint","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4"},
new string[]{"Disapprove","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4"},
new string[]{"Discuss","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4"},
new string[]{"Disguise","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4"},
new string[]{"Disgust","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4"},
new string[]{"Dismiss","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4"},
new string[]{"Disturb","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4"},
new string[]{"Doubt","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4"},
new string[]{"Dream","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4"},
new string[]{"Dress","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4"},
new string[]{"Drunk","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4"},
new string[]{"Drop","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4"},
new string[]{"Drown","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4"},
new string[]{"Dry","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4"},
new string[]{"Dump","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4"},
new string[]{"Dust","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4"},
new string[]{"Earn","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4"},
new string[]{"Effect","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4"},
new string[]{"End","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4"},
new string[]{"Escape","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4"},
new string[]{"Escort","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4"},
},
new string[][]{//Lesson 13(Verbs & Actions p4: Exc-Ins)
new string[]{"Excuse","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4"},
new string[]{"Expose","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4"},
new string[]{"Exist","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4"},
new string[]{"Fail","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4"},
new string[]{"Faint","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4"},
new string[]{"Fake","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4"},
new string[]{"Fart","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4"},
new string[]{"Fear","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4"},
new string[]{"Fill","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4"},
new string[]{"Find","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4"},
new string[]{"Finish","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4"},
new string[]{"Fix","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4"},
new string[]{"Flip","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4"},
new string[]{"Flirt","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4"},
new string[]{"Fly","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4"},
new string[]{"Forbid","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4"},
new string[]{"Forgive","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4"},
new string[]{"Gain","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4"},
new string[]{"Give","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4"},
new string[]{"Glow","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4"},
new string[]{"Grab","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4"},
new string[]{"Grow","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4"},
new string[]{"Guard","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4"},
new string[]{"Guess","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4"},
new string[]{"Guide","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4"},
new string[]{"Harass / Bother","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4"},
new string[]{"Harm","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4"},
new string[]{"Hit","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4"},
new string[]{"Hold","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4"},
new string[]{"Hop","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4"},
new string[]{"Hope","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4"},
new string[]{"Hunt","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4"},
new string[]{"Ignore","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4"},
new string[]{"Imagine","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4"},
new string[]{"Imitate","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4"},
new string[]{"Insult","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4"},
},
new string[][]{//Lesson 14(Verbs & Actions p5: Int-Pas)
new string[]{"Interact","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4"},
new string[]{"Interfere","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4"},
new string[]{"Judge","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4"},
new string[]{"Jump","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4"},
new string[]{"Justify","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4"},
new string[]{"Just Kidding","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4"},
new string[]{"Keep","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4"},
new string[]{"Kick","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4"},
new string[]{"Kill","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4"},
new string[]{"Knock","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4"},
new string[]{"Lead","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4"},
new string[]{"Lick","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4"},
new string[]{"Lock","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4"},
new string[]{"Manipulate","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4"},
new string[]{"Melt","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4"},
new string[]{"Mess","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4"},
new string[]{"Miss","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4"},
new string[]{"Mistake","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4"},
new string[]{"Mount","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4"},
new string[]{"Move","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4"},
new string[]{"Murder","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4"},
new string[]{"Nod","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4"},
new string[]{"Note","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4"},
new string[]{"Notice","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4"},
new string[]{"Obey","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4"},
new string[]{"Obsess","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4"},
new string[]{"Obtain","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4"},
new string[]{"Occupy","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4"},
new string[]{"Offend","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4"},
new string[]{"Offer","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4"},
new string[]{"Okay","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4"},
new string[]{"Open","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4"},
new string[]{"Order","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4"},
new string[]{"Owe","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4"},
new string[]{"Own","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4"},
new string[]{"Pass","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4"},
},
new string[][]{//Lesson 15(Verbs & Actions p6: Pat-Sav)
new string[]{"Pat","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4"},
new string[]{"Party","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4"},
new string[]{"Pet","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4"},
new string[]{"Pick","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4"},
new string[]{"Plug","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4"},
new string[]{"Point","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4"},
new string[]{"Poke","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4"},
new string[]{"Pray","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4"},
new string[]{"Prepare","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4"},
new string[]{"Present","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4"},
new string[]{"Pretend","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4"},
new string[]{"Protect","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4"},
new string[]{"Prove","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4"},
new string[]{"Publish","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4"},
new string[]{"Puke","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4"},
new string[]{"Puke (Variant 2)","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4"},
new string[]{"Pull","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4"},
new string[]{"Punch","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4"},
new string[]{"Put","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4"},
new string[]{"Push","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4"},
new string[]{"Question","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4"},
new string[]{"Questions","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4"},
new string[]{"Quit","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4"},
new string[]{"Quote","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4"},
new string[]{"Race","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4"},
new string[]{"React","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4"},
new string[]{"Recommended","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4"},
new string[]{"Refuse","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4"},
new string[]{"Regret","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4"},
new string[]{"Remember","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4"},
new string[]{"Replace","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4"},
new string[]{"Report","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4"},
new string[]{"Reset","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4"},
new string[]{"Ride","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4"},
new string[]{"Rub","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4"},
new string[]{"Rule","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4"},
new string[]{"Run","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4"},
new string[]{"Save","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4"},
},
new string[][]{//Lesson 16(Verbs & Actions p7: Say-Try)
new string[]{"Say","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4"},
new string[]{"Search","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4"},
new string[]{"See","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4"},
new string[]{"Share","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4"},
new string[]{"Shock","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4"},
new string[]{"Shop (Store)","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4"},
new string[]{"Show","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4"},
new string[]{"Shut Up","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4"},
new string[]{"Shut Down","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4"},
new string[]{"Sing","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4"},
new string[]{"Sit","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4"},
new string[]{"Smell","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4"},
new string[]{"Smile","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4"},
new string[]{"Smoke (Airborn)","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4"},
new string[]{"Speak / Talk","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4"},
new string[]{"Spell / Fingerspell","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4"},
new string[]{"Spit","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4"},
new string[]{"Stand","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4"},
new string[]{"Start","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4"},
new string[]{"Stay","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4"},
new string[]{"Steal","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4"},
new string[]{"Stop","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4"},
new string[]{"Study","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4"},
new string[]{"Suffer","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4"},
new string[]{"Swim","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4"},
new string[]{"Switch","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4"},
new string[]{"Take (From)","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4"},
new string[]{"Communicate","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4"},
new string[]{"Tell","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4"},
new string[]{"Test","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4"},
new string[]{"Text","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4"},
new string[]{"Think","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4"},
new string[]{"Throw","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4"},
new string[]{"Tie","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4"},
new string[]{"Truth","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4"},
new string[]{"Try","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4"},
},
new string[][]{//Lesson 17(Verbs & Actions p8)
new string[]{"Type","https://vrsignlanguage.net/ASL_videos/sheet17/17-01.mp4"},
new string[]{"Turn","https://vrsignlanguage.net/ASL_videos/sheet17/17-02.mp4"},
new string[]{"Upset","https://vrsignlanguage.net/ASL_videos/sheet17/17-03.mp4"},
new string[]{"Use","https://vrsignlanguage.net/ASL_videos/sheet17/17-04.mp4"},
new string[]{"View","https://vrsignlanguage.net/ASL_videos/sheet17/17-05.mp4"},
new string[]{"Vomit","https://vrsignlanguage.net/ASL_videos/sheet17/17-06.mp4"},
new string[]{"Wait","https://vrsignlanguage.net/ASL_videos/sheet17/17-07.mp4"},
new string[]{"Wake Up","https://vrsignlanguage.net/ASL_videos/sheet17/17-08.mp4"},
new string[]{"War","https://vrsignlanguage.net/ASL_videos/sheet17/17-09.mp4"},
new string[]{"Warn","https://vrsignlanguage.net/ASL_videos/sheet17/17-10.mp4"},
new string[]{"Waste","https://vrsignlanguage.net/ASL_videos/sheet17/17-11.mp4"},
new string[]{"Wash","https://vrsignlanguage.net/ASL_videos/sheet17/17-12.mp4"},
new string[]{"Watch","https://vrsignlanguage.net/ASL_videos/sheet17/17-13.mp4"},
new string[]{"Wear","https://vrsignlanguage.net/ASL_videos/sheet17/17-14.mp4"},
new string[]{"Wobble","https://vrsignlanguage.net/ASL_videos/sheet17/17-15.mp4"},
new string[]{"Wonder","https://vrsignlanguage.net/ASL_videos/sheet17/17-16.mp4"},
new string[]{"Worry","https://vrsignlanguage.net/ASL_videos/sheet17/17-17.mp4"},
new string[]{"Work","https://vrsignlanguage.net/ASL_videos/sheet17/17-18.mp4"},
new string[]{"Hug","https://vrsignlanguage.net/ASL_videos/sheet17/17-19.mp4"},
new string[]{"Touch","https://vrsignlanguage.net/ASL_videos/sheet17/17-20.mp4"},
new string[]{"Kiss","https://vrsignlanguage.net/ASL_videos/sheet17/17-21.mp4"},
new string[]{"Trust","https://vrsignlanguage.net/ASL_videos/sheet17/17-22.mp4"},
new string[]{"True","https://vrsignlanguage.net/ASL_videos/sheet17/17-23.mp4"},
new string[]{"Lie","https://vrsignlanguage.net/ASL_videos/sheet17/17-24.mp4"},
new string[]{"Serve","https://vrsignlanguage.net/ASL_videos/sheet17/17-25.mp4"},
new string[]{"Calculate","https://vrsignlanguage.net/ASL_videos/sheet17/17-26.mp4"},
new string[]{"Shower","https://vrsignlanguage.net/ASL_videos/sheet17/17-27.mp4"},
new string[]{"Bathe","https://vrsignlanguage.net/ASL_videos/sheet17/17-28.mp4"},
new string[]{"Socialize","https://vrsignlanguage.net/ASL_videos/sheet17/17-29.mp4"},
new string[]{"Help / Assist","https://vrsignlanguage.net/ASL_videos/sheet17/17-30.mp4"},
new string[]{"Support","https://vrsignlanguage.net/ASL_videos/sheet17/17-31.mp4"},
new string[]{"Take Care","https://vrsignlanguage.net/ASL_videos/sheet17/17-32.mp4"},
new string[]{"Drive","https://vrsignlanguage.net/ASL_videos/sheet17/17-33.mp4"},
new string[]{"Travel","https://vrsignlanguage.net/ASL_videos/sheet17/17-34.mp4"},
new string[]{"Trip","https://vrsignlanguage.net/ASL_videos/sheet17/17-35.mp4"},
new string[]{"Fiction","https://vrsignlanguage.net/ASL_videos/sheet17/17-36.mp4"},
},
new string[][]{//Lesson 18(Food)
new string[]{"Custard",""},
new string[]{"Corn",""},
new string[]{"Vegtable",""},
new string[]{"Cookie",""},
new string[]{"Cake",""},
new string[]{"Yogurt",""},
new string[]{"Lemon",""},
new string[]{"Nuts",""},
new string[]{"Grapes",""},
new string[]{"Peas",""},
new string[]{"Beans",""},
new string[]{"Pear",""},
new string[]{"Butter",""},
new string[]{"Banana",""},
new string[]{"Pumpkin",""},
new string[]{"Fruit",""},
new string[]{"Apple",""},
new string[]{"Tomato",""},
new string[]{"Orange",""},
new string[]{"Bread",""},
new string[]{"Cheese",""},
new string[]{"Water",""},
new string[]{"Hamburger",""},
new string[]{"Hot Dog",""},
new string[]{"Curry",""},
new string[]{"Rice",""},
new string[]{"Noodles",""},
new string[]{"Eggs",""},
new string[]{"Salt",""},
new string[]{"Meat",""},
new string[]{"Carrot",""},
new string[]{"Cabbage",""},
new string[]{"Spaghetti",""},
new string[]{"Pizza",""},
new string[]{"Sushi",""},
new string[]{"Potato",""},
new string[]{"Juice",""},
new string[]{"Cola",""},
new string[]{"Beer",""},
new string[]{"Wine",""},
new string[]{"Champagne",""},
new string[]{"Milk",""},
new string[]{"Sugar",""},
},
new string[][]{//Lesson 19(Animals / Machines)
new string[]{"Dog",""},
new string[]{"Cat",""},
new string[]{"Fox",""},
new string[]{"Cow",""},
new string[]{"Sheep",""},
new string[]{"Duck",""},
new string[]{"Fly",""},
new string[]{"Chicken",""},
new string[]{"Owl",""},
new string[]{"Bird",""},
new string[]{"Mouse",""},
new string[]{"Bear",""},
new string[]{"Lion",""},
new string[]{"Cricket",""},
new string[]{"Dragon",""},
new string[]{"Rabbit",""},
new string[]{"Turtle",""},
new string[]{"Pig",""},
new string[]{"Squirrel",""},
new string[]{"Raccoon",""},
new string[]{"Fish",""},
new string[]{"Rocket",""},
new string[]{"Generator",""},
new string[]{"Car",""},
new string[]{"Truck",""},
new string[]{"Bike",""},
new string[]{"Motorcycle",""},
new string[]{"Train",""},
new string[]{"Robot",""},
new string[]{"Spaceship",""},
new string[]{"Aircraft",""},
new string[]{"Helicopter",""},
new string[]{"Bus",""},
new string[]{"Ship",""},
new string[]{"Bulldozer",""},
new string[]{"Crane",""},
new string[]{"Machine",""},
new string[]{"Drilling Machine",""},
new string[]{"Elevator",""},
new string[]{"Cyborg",""},
new string[]{"Tank",""},
new string[]{"Submarine",""},
},
new string[][]{//Lesson 20(Places)
new string[]{"Bathroom",""},
new string[]{"Room",""},
new string[]{"City",""},
new string[]{"House",""},
new string[]{"Skyscraper",""},
new string[]{"Apartment",""},
new string[]{"Tower",""},
new string[]{"Village",""},
new string[]{"Sewer",""},
new string[]{"Cellar",""},
new string[]{"Storage",""},
new string[]{"Pool",""},
new string[]{"Sea",""},
new string[]{"Island",""},
new string[]{"Sun",""},
new string[]{"Moon",""},
new string[]{"Sky",""},
new string[]{"Space",""},
new string[]{"Milky Way",""},
new string[]{"Heaven",""},
new string[]{"Hell",""},
new string[]{"Graveyard",""},
new string[]{"Garden",""},
new string[]{"Beach",""},
new string[]{"Coast",""},
new string[]{"Sea",""},
new string[]{"Garbage Dump",""},
new string[]{"Castle",""},
new string[]{"Cathedral",""},
new string[]{"Church",""},
new string[]{"Store",""},
new string[]{"Butchery",""},
new string[]{"Prison",""},
new string[]{"Police Station",""},
new string[]{"Hospital",""},
new string[]{"Firestation",""},
new string[]{"Hotel",""},
new string[]{"Airport",""},
new string[]{"Harbor",""},
new string[]{"Road",""},
new string[]{"Crossing",""},
new string[]{"Railway",""},
},
new string[][]{//Lesson 21(Stuff / Weather)
new string[]{"Wood",""},
new string[]{"Metal",""},
new string[]{"Glass",""},
new string[]{"Liquid",""},
new string[]{"Electricity",""},
new string[]{"Powder",""},
new string[]{"Feather",""},
new string[]{"Box",""},
new string[]{"Container",""},
new string[]{"Paper",""},
new string[]{"Pencil",""},
new string[]{"Eraser",""},
new string[]{"Book",""},
new string[]{"Ruler",""},
new string[]{"Hammer",""},
new string[]{"Saw",""},
new string[]{"Sander",""},
new string[]{"Scissors",""},
new string[]{"Pincer",""},
new string[]{"Stick",""},
new string[]{"Rake",""},
new string[]{"Shovel",""},
new string[]{"Axe",""},
new string[]{"Hook",""},
new string[]{"Chain",""},
new string[]{"Storm",""},
new string[]{"Hurricane",""},
new string[]{"Earthquake",""},
new string[]{"Dark",""},
new string[]{"Light",""},
new string[]{"Clouds",""},
new string[]{"Fire",""},
new string[]{"Ice",""},
new string[]{"Rain",""},
new string[]{"Flood",""},
new string[]{"Smoke",""},
new string[]{"Fog",""},
new string[]{"Snow",""},
new string[]{"Freeze",""},
new string[]{"Hot",""},
new string[]{"Humidity",""},
new string[]{"Lighting",""},
},
new string[][]{//Lesson 22(Clothes / Equipment)
new string[]{"Dress",""},
new string[]{"Pants",""},
new string[]{"Jeans",""},
new string[]{"Shorts",""},
new string[]{"Swimming Trunks",""},
new string[]{"Bikini",""},
new string[]{"Miniskirt",""},
new string[]{"Underwear",""},
new string[]{"Bra",""},
new string[]{"Diapers",""},
new string[]{"Shirt",""},
new string[]{"Sweater",""},
new string[]{"Hat",""},
new string[]{"High Heels",""},
new string[]{"Scarf",""},
new string[]{"Raincoat",""},
new string[]{"Jacket",""},
new string[]{"Umbrella",""},
new string[]{"Gloves",""},
new string[]{"Uniform",""},
new string[]{"Overalls",""},
new string[]{"Mask",""},
new string[]{"Cap",""},
new string[]{"Glasses",""},
new string[]{"Goggles",""},
new string[]{"Helmet",""},
new string[]{"Socks",""},
new string[]{"Shoes",""},
new string[]{"Boots",""},
new string[]{"Sandals",""},
new string[]{"Backpack",""},
new string[]{"Bag",""},
new string[]{"Suitcase",""},
new string[]{"Belt",""},
new string[]{"Sportswear",""},
new string[]{"Jumpsuit",""},
new string[]{"Jewelry",""},
new string[]{"Ring",""},
new string[]{"Bracelet",""},
new string[]{"Badge",""},
new string[]{"Necklace",""},
new string[]{"Earring",""},
},
new string[][]{//Lesson 23(Fantasy / Characters)
new string[]{"Sword",""},
new string[]{"Shield",""},
new string[]{"Weapon",""},
new string[]{"Cannon",""},
new string[]{"Stick",""},
new string[]{"Magic",""},
new string[]{"Money",""},
new string[]{"Ghost",""},
new string[]{"Zombie",""},
new string[]{"Undead",""},
new string[]{"Soldier",""},
new string[]{"Police",""},
new string[]{"Nurse",""},
new string[]{"Fireman",""},
new string[]{"Wizard",""},
new string[]{"Sorcerer",""},
new string[]{"Hunter",""},
new string[]{"Male",""},
new string[]{"Female",""},
new string[]{"Human",""},
new string[]{"Dwarf",""},
new string[]{"Elf",""},
new string[]{"Orc",""},
new string[]{"Tauren",""},
new string[]{"Monster",""},
new string[]{"Gnome",""},
new string[]{"Troll",""},
new string[]{"Health",""},
new string[]{"Mana",""},
new string[]{"Energy",""},
new string[]{"Power",""},
new string[]{"Armor",""},
new string[]{"Resistance",""},
new string[]{"Resurrect",""},
new string[]{"Rage",""},
new string[]{"Casting",""},
new string[]{"Shooting",""},
new string[]{"Damage",""},
new string[]{"Healing",""},
new string[]{"Melee",""},
new string[]{"Ammo",""},
new string[]{"Ranged",""},
},
new string[][]{//Lesson 24(Holidays / Special Days)
new string[]{"Holiday",""},
new string[]{"Pentecost",""},
new string[]{"Christmas",""},
new string[]{"Easter",""},
new string[]{"New Year's Day",""},
new string[]{"New Year's Eve",""},
new string[]{"Ascension Day",""},
new string[]{"Labor Day",""},
new string[]{"Columbus Day",""},
new string[]{"Veterans Day",""},
new string[]{"Thanksgiving Day",""},
new string[]{"Memorial Day",""},
new string[]{"M. Luther King, Jr. Day",""},
new string[]{"Presidents' Day",""},
new string[]{"St. Andrew's Day",""},
new string[]{"St. David's Day",""},
new string[]{"Father's Day",""},
new string[]{"Mother's Day",""},
new string[]{"Independence Day",""},
new string[]{"National Day",""},
new string[]{"Valentine's Day",""},
new string[]{"White Day",""},
new string[]{"Black Friday",""},
new string[]{"Cyber Monday",""},
new string[]{"Golden Week",""},
new string[]{"Doll's Festival (Hina Matsuri)",""},
new string[]{"Coming of Age Day",""},
new string[]{"Culture Day",""},
new string[]{"Children's Day",""},
new string[]{"Seollal Holiday",""},
new string[]{"Chinese New Year",""},
new string[]{"Groundhog Day",""},
new string[]{"Carnival",""},
new string[]{"Holloween",""},
new string[]{"St. Patrick's Day",""},
new string[]{"Parent's Day",""},
},
new string[][]{//Lesson 25(Home stuff)
new string[]{"Chair",""},
new string[]{"Bench",""},
new string[]{"Couch",""},
new string[]{"Table",""},
new string[]{"Desk",""},
new string[]{"Closet",""},
new string[]{"Toilet",""},
new string[]{"Door",""},
new string[]{"Window",""},
new string[]{"Ceiling",""},
new string[]{"Floor",""},
new string[]{"Rack",""},
new string[]{"Safe",""},
new string[]{"Stairs",""},
new string[]{"Television",""},
new string[]{"Radio",""},
new string[]{"Speakers",""},
new string[]{"Microphone",""},
new string[]{"Guitar",""},
new string[]{"Guitar (Variant 2)",""},
new string[]{"Drum Kit",""},
new string[]{"Headphone",""},
new string[]{"Headphone",""},
new string[]{"Washing Machine",""},
new string[]{"Refrigerator",""},
new string[]{"Dryer",""},
new string[]{"Broom",""},
new string[]{"Sweeper",""},
new string[]{"Vacuum Cleaner",""},
new string[]{"Sink",""},
new string[]{"Dishwasher",""},
new string[]{"Cooking Pan",""},
new string[]{"Oven",""},
new string[]{"Fork",""},
new string[]{"Knife",""},
new string[]{"Spoon",""},
new string[]{"Bowl",""},
new string[]{"Plate",""},
new string[]{"Wall Outlet",""},
new string[]{"Bath",""},
new string[]{"Shower",""},
new string[]{"Fireplace",""},
new string[]{"Fireplace (Variant 2)",""},
new string[]{"Air Conditioner",""},
new string[]{"Parasol",""},
},
new string[][]{//Lesson 26(Nature / Environment)
new string[]{"Nature",""},
new string[]{"Environment",""},
new string[]{"Flower",""},
new string[]{"Grass",""},
new string[]{"Tree",""},
new string[]{"Sand",""},
new string[]{"Soil",""},
new string[]{"Waterfall",""},
new string[]{"Hills",""},
new string[]{"Cave",""},
new string[]{"Pine",""},
new string[]{"Oak",""},
new string[]{"Sunflower",""},
new string[]{"Bush",""},
new string[]{"Dam",""},
new string[]{"Bridge",""},
new string[]{"Ocean",""},
new string[]{"Lake",""},
new string[]{"Pond",""},
new string[]{"River",""},
new string[]{"Rainbow",""},
new string[]{"Forest",""},
new string[]{"Wilderness",""},
new string[]{"Geology",""},
new string[]{"Ecology",""},
new string[]{"Evolution",""},
new string[]{"Matter",""},
new string[]{"Lava",""},
new string[]{"Structure",""},
new string[]{"Rocks",""},
new string[]{"Atmosphere",""},
new string[]{"Climate",""},
new string[]{"Oxygen",""},
new string[]{"Hydrogen",""},
new string[]{"Water Vapor",""},
new string[]{"Ecosystem",""},
new string[]{"Life",""},
new string[]{"Biology",""},
new string[]{"Organisms",""},
new string[]{"Reproduction",""},
new string[]{"Growth",""},
new string[]{"Microbes",""},
},
new string[][]{//Lesson 27(Talk / Asking exercises)
new string[]{"Can you teach me?",""},
new string[]{"Sorry, I don't understand.",""},
new string[]{"I want to learn sign language.",""},
new string[]{"My name is.",""},
new string[]{"Please wait for it.",""},
new string[]{"My friend wants to join.",""},
new string[]{"I want to play with you.",""},
new string[]{"I'm slow at learning.",""},
new string[]{"Can you repeat it?",""},
new string[]{"Shall we begin?",""},
new string[]{"I'm busy streaming.",""},
new string[]{"Please don't distrub me.",""},
new string[]{"Can you stop that?",""},
new string[]{"Please follow me.",""},
new string[]{"I want to change the world.",""},
new string[]{"Can you write it down?",""},
new string[]{"Please don't speak.",""},
new string[]{"I can't hear you.",""},
new string[]{"What are the rules?",""},
new string[]{"Can you explain that to me?",""},
new string[]{"Can you help me?",""},
new string[]{"Please lead me.",""},
new string[]{"I have a good idea.",""},
new string[]{"I'm not feeling good.",""},
new string[]{"How old are you?",""},
new string[]{"Where do you come from?",""},
new string[]{"Do you want to be my friend?",""},
new string[]{"I'm going to sleep.",""},
new string[]{"I have to work soon.",""},
new string[]{"What is your Discord?",""},
new string[]{"Can we talk on Discord?",""},
new string[]{"Check your Discord.",""},
new string[]{"I am lost here.",""},
new string[]{"I'm going to my friend's.",""},
new string[]{"I have some free time now.",""},
new string[]{"I don't have much time.",""},
},
new string[][]{//Lesson 28(Name sign users)
new string[]{"Sio","https://vrsignlanguage.net/ASL_videos/sheet28/28-01.mp4"},
new string[]{"MrDummy_NED","https://vrsignlanguage.net/ASL_videos/sheet28/28-02.mp4"},
new string[]{"Wardragon","https://vrsignlanguage.net/ASL_videos/sheet28/28-03.mp4"},
new string[]{"QQuentin","https://vrsignlanguage.net/ASL_videos/sheet28/28-04.mp4"},
new string[]{"Ray_is_deaf","https://vrsignlanguage.net/ASL_videos/sheet28/28-05.mp4"},
new string[]{"CTLucina","https://vrsignlanguage.net/ASL_videos/sheet28/28-06.mp4"},
new string[]{"Fazzion","https://vrsignlanguage.net/ASL_videos/sheet28/28-07.mp4"},
new string[]{"Jenny0629","https://vrsignlanguage.net/ASL_videos/sheet28/28-08.mp4"},
new string[]{"Wubbles","https://vrsignlanguage.net/ASL_videos/sheet28/28-09.mp4"},
new string[]{"Sqweekslj","https://vrsignlanguage.net/ASL_videos/sheet28/28-10.mp4"},
new string[]{"Freddex1337","https://vrsignlanguage.net/ASL_videos/sheet28/28-11.mp4"},
new string[]{"Max DEAF FR","https://vrsignlanguage.net/ASL_videos/sheet28/28-12.mp4"},
new string[]{"Korea_Saro","https://vrsignlanguage.net/ASL_videos/sheet28/28-13.mp4"},
new string[]{"_MINT_","https://vrsignlanguage.net/ASL_videos/sheet28/28-14.mp4"},
new string[]{"Divamage","https://vrsignlanguage.net/ASL_videos/sheet28/28-15.mp4"},
new string[]{"DeafDragon22","https://vrsignlanguage.net/ASL_videos/sheet28/28-16.mp4"},
new string[]{"Cha714_Deaf","https://vrsignlanguage.net/ASL_videos/sheet28/28-17.mp4"},
new string[]{"AlexDeafHero","https://vrsignlanguage.net/ASL_videos/sheet28/28-18.mp4"},
new string[]{"Papa Thelius","https://vrsignlanguage.net/ASL_videos/sheet28/28-19.mp4"},
new string[]{"DalekTheGamer","https://vrsignlanguage.net/ASL_videos/sheet28/28-20.mp4"},
new string[]{"Fearlesskoolaid","https://vrsignlanguage.net/ASL_videos/sheet28/28-21.mp4"},
new string[]{"Korea_Yujin","https://vrsignlanguage.net/ASL_videos/sheet28/28-22.mp4"},
new string[]{"Mute Raven","https://vrsignlanguage.net/ASL_videos/sheet28/28-23.mp4"},
new string[]{"Ailuro","https://vrsignlanguage.net/ASL_videos/sheet28/28-24.mp4"},
new string[]{"Robyn / QueenHidi","https://vrsignlanguage.net/ASL_videos/sheet28/28-25.mp4"},
new string[]{"CraftyHayley","https://vrsignlanguage.net/ASL_videos/sheet28/28-26.mp4"},
new string[]{"[ DEAF-2030 ]","https://vrsignlanguage.net/ASL_videos/sheet28/28-27.mp4"},
new string[]{"Catman2010","https://vrsignlanguage.net/ASL_videos/sheet28/28-28.mp4"},
new string[]{"Danyy59","https://vrsignlanguage.net/ASL_videos/sheet28/28-29.mp4"},
new string[]{"Darkers","https://vrsignlanguage.net/ASL_videos/sheet28/28-30.mp4"},
new string[]{"Yun Big Eater","https://vrsignlanguage.net/ASL_videos/sheet28/28-31.mp4"},
new string[]{"Deaf_Daninelo_89","https://vrsignlanguage.net/ASL_videos/sheet28/28-32.mp4"},
new string[]{"UnrealPanda","https://vrsignlanguage.net/ASL_videos/sheet28/28-33.mp4"},
new string[]{"Mr_Voodoo","https://vrsignlanguage.net/ASL_videos/sheet28/28-34.mp4"},
new string[]{"GT4tube","https://vrsignlanguage.net/ASL_videos/sheet28/28-35.mp4"},
new string[]{"CathDeafGamer","https://vrsignlanguage.net/ASL_videos/sheet28/28-36.mp4"},
new string[]{"Angél","https://vrsignlanguage.net/ASL_videos/sheet28/28-37.mp4"},
new string[]{"RomainDEAF","https://vrsignlanguage.net/ASL_videos/sheet28/28-38.mp4"},
new string[]{"Peppers","https://vrsignlanguage.net/ASL_videos/sheet28/28-39.mp4"},
},
new string[][]{//Lesson 29(Countries)
new string[]{"World",""},
new string[]{"Europe",""},
new string[]{"Asia",""},
new string[]{"Country",""},
new string[]{"North America",""},
new string[]{"Central America",""},
new string[]{"South America",""},
new string[]{"America / USA",""},
new string[]{"Canada",""},
new string[]{"Mexico",""},
new string[]{"Spain",""},
new string[]{"France",""},
new string[]{"England",""},
new string[]{"Netherlands",""},
new string[]{"Germany",""},
new string[]{"Scandinavia",""},
new string[]{"Middle East",""},
new string[]{"Australia",""},
new string[]{"Japan",""},
new string[]{"China",""},
new string[]{"South Korea",""},
new string[]{"Russia",""},
new string[]{"New Zealand",""},
new string[]{"Brazil",""},
new string[]{"Poland",""},
new string[]{"Turkey",""},
new string[]{"Israel",""},
new string[]{"Egypt",""},
new string[]{"Africa",""},
new string[]{"South Africa",""},
new string[]{"Norway",""},
new string[]{"Sweden",""},
new string[]{"Finland",""},
new string[]{"Austria",""},
new string[]{"Italy",""},
new string[]{"Portugal",""},
new string[]{"Romania",""},
new string[]{"Saudi Arabia",""},
new string[]{"Ireland",""},
new string[]{"Scotland",""},
},
new string[][]{//Lesson 30(Colors)
new string[]{"Color",""},
new string[]{"White",""},
new string[]{"Black",""},
new string[]{"Red",""},
new string[]{"Blue",""},
new string[]{"Green",""},
new string[]{"Brown",""},
new string[]{"Pink",""},
new string[]{"Purple",""},
new string[]{"Yellow",""},
new string[]{"Orange",""},
new string[]{"Gold",""},
new string[]{"Silver",""},
new string[]{"Transparent",""},
new string[]{"Gray",""},
new string[]{"Light",""},
new string[]{"Dark",""},
new string[]{"Light Blue",""},
new string[]{"Dark Blue",""},
new string[]{"Tan",""},
new string[]{"Blond",""},
new string[]{"Gas",""},
new string[]{"Oil",""},
new string[]{"Glow",""},
new string[]{"Wood",""},
new string[]{"Metal",""},
new string[]{"Aluminium",""},
new string[]{"Fabric",""},
new string[]{"Glass",""},
new string[]{"Paper",""},
new string[]{"Plastic",""},
new string[]{"Rubber",""},
new string[]{"Foil",""},
new string[]{"Clay",""},
new string[]{"Water",""},
new string[]{"Gel",""},
new string[]{"Sticker",""},
new string[]{"Rope",""},
new string[]{"Wire",""},
new string[]{"Cotton",""},
new string[]{"Air",""},
},
new string[][]{//Lesson 31(Medical)
new string[]{"Doctor",""},
new string[]{"Nurse",""},
new string[]{"Hospital",""},
new string[]{"Sick",""},
new string[]{"Hurt",""},
new string[]{"Fever",""},
new string[]{"Diarrhea",""},
new string[]{"Vomit",""},
new string[]{"Healthy",""},
new string[]{"Better",""},
new string[]{"Recover",""},
new string[]{"Pill",""},
new string[]{"Dead (Variant 2)",""},
new string[]{"Brain",""},
new string[]{"Receipt",""},
new string[]{"Headache",""},
new string[]{"Stomachache",""},
new string[]{"Pain",""},
new string[]{"Bone Fracture",""},
new string[]{"Wheelchair",""},
new string[]{"Stretcher",""},
new string[]{"Dentist",""},
new string[]{"Band Aid",""},
new string[]{"Bandage",""},
new string[]{"Wound",""},
new string[]{"Blood",""},
new string[]{"Crutch",""},
new string[]{"Eye",""},
new string[]{"Ears",""},
new string[]{"Nose",""},
new string[]{"Arm",""},
new string[]{"Legs",""},
new string[]{"Breast",""},
new string[]{"Belly",""},
new string[]{"Mouth",""},
new string[]{"Finger",""},
new string[]{"Elbow",""},
new string[]{"Knee",""},
new string[]{"Ankle",""},
new string[]{"Spine",""},
new string[]{"Skeleton",""},
new string[]{"Skin",""},
}};

    //string [][][,] AllLessons = { ASLlessons, BSLlessons }; //if multi-languages are ever implimented
    static string [][][][] AllLessons = { GSLlessons}; //adds array of arrays into another array for easy looping. 

	static string [][] lessonnames ={
	new string[]{//array of lesson names - can be unique per language.
	"Daily Use","Pointing use Question/Answer","Common",
	"People","Feelings/Reactions","Value","Time","VRChat","Alphabet/Numbers (Fingerspelling)","Verbs & Actions p1","Verbs & Actions p2: Ben-Cor",
	"Verbs & Actions p3: Cou-Esc","Verbs & Actions p4: Exc-Ins","Verbs & Actions p5: Int-Pas","Verbs & Actions p6: Pat-Sav","Verbs & Actions p7: Say-Try",
	"Verbs & Actions p8","Food",
	"Animals/Machines","Places","Stuff/Weather","Clothes/Equipment","Fantasy/Characters","Holidays/Special Days","Home stuff","Nature/Environment","Talk/Asking exercises",
	"Name sign users","Countries","Colors","Medical"}
	};
	static string [][] signlanguagenames = {
		new string[]{"GSL","German Sign Language"}
		};

	[MenuItem("ASLWorld/ButtonV5")]
	static void ButtonV5()
	{
	int layer=8;
	Vector2 zerovector2=new Vector2(0,0);
	DefaultControls.Resources txtresources = new DefaultControls.Resources();
	DefaultControls.Resources rootpanelresources = new DefaultControls.Resources();
	rootpanelresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
   	//Declare some variables + settings.
	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None;

	GameObject rootmenu = new GameObject("Menu Root");
	//create sign display canvas/panel/text
	GameObject rootmenucanvas = new GameObject("Menu Root Canvas");//create canvas for current sign display
	rootmenucanvas.transform.SetParent(rootmenu.transform, false); 
	rootmenucanvas.layer = layer;
	rootmenucanvas.GetOrAddComponent<RectTransform> ().localPosition = new Vector3(.5f,.135f,16);
	rootmenucanvas.GetOrAddComponent<RectTransform> ().sizeDelta = new Vector2(2000,265);
	rootmenucanvas.transform.localScale = new Vector3(.001f,.001f,.001f);
	rootmenucanvas.GetOrAddComponent<RectTransform> ().anchorMin = new Vector2(.5f,.5f);
	rootmenucanvas.GetOrAddComponent<RectTransform> ().anchorMax = new Vector2(.5f,.5f);
	rootmenucanvas.GetOrAddComponent<RectTransform> ().pivot = new Vector2(.5f,.5f);
	rootmenucanvas.GetOrAddComponent<Canvas> (); //adds canvas to root canvas gameobject
	rootmenucanvas.GetOrAddComponent<Canvas> ().renderMode = RenderMode.WorldSpace;
	rootmenucanvas.GetOrAddComponent<CanvasScaler>();
	rootmenucanvas.GetOrAddComponent<GraphicRaycaster>();
	rootmenucanvas.GetOrAddComponent<VRC_UiShape>();
	GameObject rootmenucanvaspanel = DefaultControls.CreatePanel(rootpanelresources);
	rootmenucanvaspanel.transform.SetParent(rootmenucanvas.transform, false);
	rootmenucanvaspanel.layer=layer;
	rootmenucanvaspanel.name="Current Sign Panel";
	rootmenucanvaspanel.GetOrAddComponent<Image> ().color = new Color(1,1,1,1);
	rootmenucanvaspanel.GetOrAddComponent<RectTransform> ().localPosition = new Vector3(0,0,0);
	rootmenucanvaspanel.GetOrAddComponent<RectTransform> ().sizeDelta = new Vector2(2000,265);
	rootmenucanvaspanel.GetOrAddComponent<RectTransform> ().anchorMin = new Vector2(.5f,.5f);
	rootmenucanvaspanel.GetOrAddComponent<RectTransform> ().anchorMax = new Vector2(.5f,.5f);
	rootmenucanvaspanel.GetOrAddComponent<RectTransform> ().pivot = new Vector2(.5f,.5f);
	GameObject rootmenucanvaspaneltext = DefaultControls.CreateText(txtresources);
	rootmenucanvaspaneltext.transform.SetParent(rootmenucanvaspanel.transform, false);
	rootmenucanvaspaneltext.name="Current Sign Text";
	rootmenucanvaspaneltext.layer=layer;
	rootmenucanvaspaneltext.GetOrAddComponent<RectTransform> ().localPosition = new Vector3(0,0,0);
	rootmenucanvaspaneltext.GetOrAddComponent<RectTransform> ().sizeDelta = new Vector2(2000,265);
	rootmenucanvaspaneltext.GetOrAddComponent<RectTransform> ().anchorMin = new Vector2(.5f,.5f);
	rootmenucanvaspaneltext.GetOrAddComponent<RectTransform> ().anchorMax = new Vector2(.5f,.5f);
	rootmenucanvaspaneltext.GetOrAddComponent<Text>().text="The sign that's currently playing will show here.";
	rootmenucanvaspaneltext.GetOrAddComponent<Text>().alignment=TextAnchor.MiddleCenter;
	rootmenucanvaspaneltext.GetOrAddComponent<Text>().fontSize=75;
	rootmenucanvaspaneltext.GetOrAddComponent<Text>().resizeTextForBestFit=true;

//"/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text"

	//why create two copies? Too hard to sync all the different active/inactive gameobjects if everyone isn't on the same "page".
	GameObject globalmenu = CreateMenu(rootmenu,"Global");
	GameObject localmenu = CreateMenu(rootmenu,"Local");


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

	GameObject videocontainer = new GameObject(mode +" Video Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
	//videocontainer.transform.position = new Vector3(-1f, 1, 0);
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
					var defaultcolors = b.colors;
					defaultcolors.normalColor = new Color32( 0xFF, 0x98, 0x98, 0xFF ); //FF9898FF light red
					b.colors = defaultcolors;
					/*
					if((lessonnum+1)<2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0x98, 0xFF, 0x98, 0xFF ); //FF9898FF light green
						b.colors = colors;
					}
					if((lessonnum+1)>=2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0xFF, 0x98, 0xFF ); //FF9898FF light yellow
						b.colors = colors;
					}*/
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
					GameObject buttonoffgo=createbutton2(parent=lessongo, name:signlanguagenames[languagenum][0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off",
					sizedelta:buttonsize,localPosition:new Vector3(columnoffset +(wordcolumn*columnseperation),(menusizey-headersizey-textpadding-buttonsizey-100-(wordrow*rowseperation)),0),
					text:"          "+ (wordnum+1)+ ") " + AllLessons[languagenum][lessonnum][wordnum][0],txtsizedelta:new Vector2 (900, 100),txtanchoredPosition:new Vector2 (0,0), alignment:TextAnchor.MiddleLeft,
					nav:no_nav,layer:layer);
//Don't forget to create the "selected" button with checkmark (optional)

					VRC_Trigger buttontriggers = buttonoffgo.AddComponent<VRC_Trigger>();
					//I need to add triggers to nagivate late-joiners to the current menu by disabling earlier menus and enabling the lesson menu.

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
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0],
										ParameterObject = GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text")
									}
								}
							}
						); 
					
					if(AllLessons[languagenum][lessonnum][wordnum][1]!=""){ //if url is blank, then don't create video.
						//creates the video gameobjects
						GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
						videogo.name=signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
						videogo.layer = layer;
						videogo.transform.position = new Vector3(-1f, 0.934f, 0);
						videogo.transform.localScale = new Vector3(2, 1.33f, 1);
						videogo.transform.SetParent(videolessoncontainer.transform, false);
						videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat",typeof(Material));
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url=AllLessons[languagenum][lessonnum][wordnum][1];
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



					if(AllLessons[languagenum][lessonnum][wordnum][1]!=""){ //if url is blank, then don't create video.

						//creates the video gameobjects
						GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
						videogo.name=signlanguagenames[languagenum][0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
						videogo.layer = layer;
						videogo.transform.position = new Vector3(-1f, 0.934f, 0);
						videogo.transform.localScale = new Vector3(2, 1.33f, 1);
						videogo.transform.SetParent(videolessoncontainer.transform, false);
						videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat",typeof(Material));
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url=AllLessons[languagenum][lessonnum][wordnum][1];
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping=true;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode=VideoRenderMode.MaterialOverride;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode=VideoAudioOutputMode.None;
						videogo.SetActive(false);
						UnityEventTools.AddPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videogo//the target of the action
						, "set_active") as UnityAction<bool>);
						}
					
					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,(lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum][0]);

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

				//enable the lesson select
				UnityAction<bool> enablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), lessonmenu, "SetActive") as UnityAction<bool>;
				UnityEventTools.AddBoolPersistentListener(backbutton.onClick, enablelessonmenu, true);

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
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "",
										ParameterObject = GameObject.Find ("/Menu Root/Menu Root Canvas/Current Sign Panel/Current Sign Text")
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