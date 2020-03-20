//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using VRCSDK2;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine.Video;
using UnityEngine.Audio;

			/*
	detectionBufferedTrigger.Events.Add(
		new VRC_EventHandler.VrcEvent
		{
			EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive,
			ParameterObjects = new GameObject[] { obj },
			ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Toggle,
		}
	);
			*/


/*
int[][, ] jagged_arr1 = new int[4][, ] {new int[, ] {{1, 3}, {5, 7}}, 
new int[, ] {{0, 2}, {4, 6}, {8, 10}}, 
new int[, ] {{7, 8}, {3, 1}, {0, 6}}, 
new int[, ] {{11, 22}, {99, 88}, {0, 9}}}; 
  
// Display the array elements: 
// Length method returns the number of 
// arrays contained in the jagged array 
for (int i = 0; i < jagged_arr1.Length; i++) 
{ 
  
int x = 0; 
  
// GetLength method takes integer x which  
// specifies the dimension of the array 
for (int j = 0; j < jagged_arr1[i].GetLength(x); j++)  
{ 
  
// Rank is used to determine the total  
// dimensions of an array  
for (int k = 0; k < jagged_arr1[j].Rank; k++) 
Console.Write("Jagged_Array[" + i + "][" + j + ", " + k + "]: "
+ jagged_arr1[i][j, k] + " "); 
Console.WriteLine(); 
} 
x++; 
Console.WriteLine(); 
} 
} 
*/

public class CreateASLButtons2 : MonoBehaviour {
	[MenuItem("ASLWorld/ButtonV2")]
	static void ButtonV2()
	{
		//Declare some variables + settings.
		//Animator nanaanimator = GameObject.Find ("/Nana Avatar").GetComponent<Animator> (); //finds target avatar animator for mocap signs


/*****************************************
Start of Arrays variable declarations
*****************************************/



        //creates an array of arrays. Grouped by lessons. 
        //First value is the word 
        //Second value is the name of the animation trigger (needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
        //Third value is mocap credits. 
        //Fourth value is video URL.
        //home sign indicator 0 = normal, 1=homesign
        //VR index or regular 0=indexonly , 1=generalvr,2=both
        //Sign description string
string [][,] ASLlessons = {
new string[,]{//Lesson 1 (Daily Use)
{"Hello","ASL-Hello","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4","0","0",""},{"How are you","ASL-How are you","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4","0","0",""},{"What's up?","ASL-What's up?","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","0","0",""},{"Nice to meet you","ASL-Nice to meet you","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4","0","0",""},{"Good","ASL-Good","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4","0","0",""},{"Bad","ASL-Bad","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4","0","0",""},{"Yes","ASL-Yes","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4","0","0",""},{"No","ASL-No","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4","0","0",""},{"So-So","ASL-So-So","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4","0","0",""},{"Sick","ASL-Sick","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","0","0",""},{"Hurt","ASL-Hurt","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4","0","0",""},{"You're welcome","ASL-You're welcome","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4","0","0",""},{"Good bye","ASL-Good bye","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4","0","0",""},{"Good morning","ASL-Good morning","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4","0","0",""},{"Good afternoon","ASL-Good afternoon","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4","0","0",""},{"Good evening","ASL-Good evening","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4","0","0",""},{"Good night","ASL-Good night","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4","0","0",""},{"See you later","ASL-See you later","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4","0","0",""},{"Please","ASL-Please","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4","0","0",""},{"Sorry","ASL-Sorry","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4","0","0",""},{"Forgotten","ASL-Forgotten","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4","0","0",""},{"Sleep","ASL-Sleep","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4","0","0",""},{"Bed","ASL-Bed","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4","0","0",""},{"Jump/Change world","ASL-Jump/Change world","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4","0","0",""},{"Thank you","ASL-Thank you","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4","0","0",""},{"I love you","ASL-I love you","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4","0","0",""},{"Go away","ASL-Go away","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4","0","0",""},{"Going to","ASL-Going to","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4","0","0",""},{"Follow","ASL-Follow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4","0","0",""},{"Come","ASL-Come","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4","0","0",""},{"Hearing","ASL-Hearing","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4","0","0",""},{"Deaf","ASL-Deaf","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","0","0",""},{"Hard of Hearing","ASL-Hard of Hearing","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4","0","0",""},{"Mute","ASL-Mute","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4","0","0",""},{"Write slow","ASL-Write slow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4","0","0",""},{"Cannot read","ASL-Cannot read","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4","0","0",""}},
new string[,]{//Lesson 2 (Pointing use Question/Answer)
{"I (Me)","ASL-I (Me)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4","0","0",""},{"My","ASL-My","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4","0","0",""},{"Your","ASL-Your","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4","0","0",""},{"His","ASL-His","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4","0","0",""},{"Her","ASL-Her","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4","0","0",""},{"We","ASL-We","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4","0","0",""},{"They","ASL-They","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4","0","0",""},{"Their","ASL-Their","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4","0","0",""},{"Over there","ASL-Over there","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4","0","0",""},{"Our","ASL-Our","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4","0","0",""},{"It's","ASL-It's","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4","0","0",""},{"Inside","ASL-Inside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4","0","0",""},{"Outside","ASL-Outside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4","0","0",""},{"Hidden","ASL-Hidden","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4","0","0",""},{"Behind","ASL-Behind","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4","0","0",""},{"Above","ASL-Above","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4","0","0",""},{"Below","ASL-Below","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4","0","0",""},{"Here","ASL-Here","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4","0","0",""},{"Beside","ASL-Beside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4","0","0",""},{"Back","ASL-Back","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4","0","0",""},{"Front","ASL-Front","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4","0","0",""},{"Who","ASL-Who","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4","0","0",""},{"Where","ASL-Where","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4","0","0",""},{"When","ASL-When","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4","0","0",""},{"Why","ASL-Why","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4","0","0",""},{"Which","ASL-Which","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4","0","0",""},{"What","ASL-What","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","0","0",""},{"How","ASL-How","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4","0","0",""},{"How many","ASL-How many","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4","0","0",""},{"Can","ASL-Can","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4","0","0",""},{"Can't","ASL-Can't","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4","0","0",""},{"Want","ASL-Want","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4","0","0",""},{"Have","ASL-Have","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4","0","0",""},{"Get","ASL-Get","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4","0","0",""},{"Will","ASL-Will","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4","0","0",""},{"Take","ASL-Take","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4","0","0",""},{"Need","ASL-Need","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4","0","0",""},{"Not","ASL-Not","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4","0","0",""},{"Or","ASL-Or","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4","0","0",""},{"And","ASL-And","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4","0","0",""},{"For","ASL-For","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4","0","0",""},{"At","ASL-At","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","0","0",""}},
new string[,]{//Lesson 3 (Common)
{"Teach","ASL-Teach","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4","0","0",""},{"Learn","ASL-Learn","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4","0","0",""},{"Person","ASL-Person","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4","0","0",""},{"Student","ASL-Student","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4","0","0",""},{"Teacher","ASL-Teacher","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4","0","0",""},{"Friend","ASL-Friend","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4","0","0",""},{"Sign","ASL-Sign","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4","0","0",""},{"Language","ASL-Language","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4","0","0",""},{"Understand","ASL-Understand","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4","0","0",""},{"Know","ASL-Know","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4","0","0",""},{"Don't Know","ASL-Don't Know","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4","0","0",""},{"Be Right Back (BRB)","ASL-Be Right Back (BRB)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4","0","0",""},{"Accept","ASL-Accept","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4","0","0",""},{"Denied","ASL-Denied","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4","0","0",""},{"Name","ASL-Name","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4","0","0",""},{"New","ASL-New","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4","0","0",""},{"Old","ASL-Old","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4","0","0",""},{"Very","ASL-Very","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4","0","0",""},{"Jokes","ASL-Jokes","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4","0","0",""},{"Funny","ASL-Funny","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4","0","0",""},{"Play","ASL-Play","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4","0","0",""},{"Favorite","ASL-Favorite","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4","0","0",""},{"Draw (pencil)","ASL-Draw (pencil)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4","0","0",""},{"Stop","ASL-Stop","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4","0","0",""},{"Read","ASL-Read","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4","0","0",""},{"Make","ASL-Make","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4","0","0",""},{"Write","ASL-Write","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4","0","0",""},{"Again / Repeat","ASL-Again / Repeat","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4","0","0",""},{"Slow","ASL-Slow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4","0","0",""},{"Fast","ASL-Fast","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4","0","0",""},{"Rude","ASL-Rude","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4","0","0",""},{"Eat","ASL-Eat","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4","0","0",""},{"Drink","ASL-Drink","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4","0","0",""},{"Watch","ASL-Watch","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4","0","0",""},{"Work","ASL-Work","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4","0","0",""},{"Live","ASL-Live","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4","0","0",""},{"Play Game","ASL-Play Game","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4","0","0",""},{"Same","ASL-Same","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4","0","0",""},{"All Right","ASL-All Right","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4","0","0",""},{"People","ASL-People","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4","0","0",""},{"Browsing the Internet","ASL-Browsing the Internet","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4","0","0",""},{"Movie","ASL-Movie","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4","0","0",""}},
new string[,]{//Lesson 4 (People)
{"Family","ASL-Family","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4","0","0",""},{"Boy","ASL-Boy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4","0","0",""},{"Girl","ASL-Girl","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4","0","0",""},{"Brother","ASL-Brother","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4","0","0",""},{"Sister","ASL-Sister","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4","0","0",""},{"Brother-in-law","ASL-Brother-in-law","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4","0","0",""},{"Sister-in-law","ASL-Sister-in-law","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4","0","0",""},{"Father","ASL-Father","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4","0","0",""},{"Grandpa","ASL-Grandpa","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4","0","0",""},{"Mother","ASL-Mother","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4","0","0",""},{"Grandma","ASL-Grandma","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4","0","0",""},{"Baby","ASL-Baby","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4","0","0",""},{"Child","ASL-Child","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4","0","0",""},{"Teen","ASL-Teen","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4","0","0",""},{"Adult","ASL-Adult","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4","0","0",""},{"Aunt","ASL-Aunt","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4","0","0",""},{"Uncle","ASL-Uncle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4","0","0",""},{"Stranger","ASL-Stranger","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4","0","0",""},{"Acquaintance","ASL-Acquaintance","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4","0","0",""},{"Parents","ASL-Parents","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4","0","0",""},{"Born","ASL-Born","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4","0","0",""},{"Dead","ASL-Dead","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4","0","0",""},{"Marriage","ASL-Marriage","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4","0","0",""},{"Divorce","ASL-Divorce","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4","0","0",""},{"Single","ASL-Single","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4","0","0",""},{"Young","ASL-Young","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4","0","0",""},{"Old","ASL-Old","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4","0","0",""},{"Age","ASL-Age","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4","0","0",""},{"Birthday","ASL-Birthday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4","0","0",""},{"Celebrate","ASL-Celebrate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4","0","0",""},{"Enemy","ASL-Enemy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4","0","0",""},{"Interpreter","ASL-Interpreter","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4","0","0",""},{"No one","ASL-No one","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4","0","0",""},{"Anyone","ASL-Anyone","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4","0","0",""},{"Someone","ASL-Someone","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4","0","0",""},{"Everyone","ASL-Everyone","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4","0","0",""}},
new string[,]{//Lesson 5 (Feelings / Reactions)
{"Like","ASL-Like","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4","0","0",""},{"Hate","ASL-Hate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4","0","0",""},{"Fine","ASL-Fine","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4","0","0",""},{"Tired","ASL-Tired","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4","0","0",""},{"Sleepy","ASL-Sleepy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4","0","0",""},{"Confused","ASL-Confused","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4","0","0",""},{"Smart","ASL-Smart","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4","0","0",""},{"Attention / Focus","ASL-Attention / Focus","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4","0","0",""},{"Nevermind","ASL-Nevermind","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4","0","0",""},{"Angry","ASL-Angry","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4","0","0",""},{"Laughing","ASL-Laughing","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4","0","0",""},{"LOL","ASL-LOL","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4","0","0",""},{"Curious","ASL-Curious","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4","0","0",""},{"In Love","ASL-In Love","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4","0","0",""},{"Awesome","ASL-Awesome","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4","0","0",""},{"Great","ASL-Great","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4","0","0",""},{"Nice","ASL-Nice","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4","0","0",""},{"Cute","ASL-Cute","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4","0","0",""},{"Feel","ASL-Feel","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4","0","0",""},{"Pity","ASL-Pity","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4","0","0",""},{"Envy","ASL-Envy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4","0","0",""},{"Hungry","ASL-Hungry","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4","0","0",""},{"Alive","ASL-Alive","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4","0","0",""},{"Bored","ASL-Bored","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4","0","0",""},{"Cry","ASL-Cry","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4","0","0",""},{"Happy","ASL-Happy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4","0","0",""},{"Sad","ASL-Sad","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4","0","0",""},{"Suffering","ASL-Suffering","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4","0","0",""},{"Surprised","ASL-Surprised","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4","0","0",""},{"Careful","ASL-Careful","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4","0","0",""},{"Enjoy","ASL-Enjoy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4","0","0",""},{"Disgusted","ASL-Disgusted","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4","0","0",""},{"Embarassed","ASL-Embarassed","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4","0","0",""},{"Shy","ASL-Shy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4","0","0",""},{"Lonely","ASL-Lonely","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4","0","0",""},{"Stressed","ASL-Stressed","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4","0","0",""},{"Scared","ASL-Scared","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4","0","0",""},{"Excited","ASL-Excited","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4","0","0",""},{"Shame","ASL-Shame","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4","0","0",""},{"Struggle","ASL-Struggle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4","0","0",""},{"Friendly","ASL-Friendly","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4","0","0",""},{"Mean","ASL-Mean","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4","0","0",""}},
new string[,]{//Lesson 6 (Value)
{"More","ASL-More","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4","0","0",""},{"Less","ASL-Less","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4","0","0",""},{"Big","ASL-Big","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4","0","0",""},{"Small","ASL-Small","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4","0","0",""},{"Full","ASL-Full","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4","0","0",""},{"Empty","ASL-Empty","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4","0","0",""},{"Half","ASL-Half","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4","0","0",""},{"Quarter","ASL-Quarter","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4","0","0",""},{"Long","ASL-Long","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4","0","0",""},{"Short","ASL-Short","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4","0","0",""},{"A little / Small","ASL-A little / Small","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-11.mp4","0","0",""},{"A lot / Many","ASL-A lot / Many","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4","0","0",""},{"Unlimited","ASL-Unlimited","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4","0","0",""},{"Limited","ASL-Limited","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4","0","0",""},{"All","ASL-All","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","0","0",""},{"Nothing","ASL-Nothing","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4","0","0",""},{"Ever","ASL-Ever","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4","0","0",""},{"Everything","ASL-Everything","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4","0","0",""},{"Everytime","ASL-Everytime","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4","0","0",""},{"Always","ASL-Always","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4","0","0",""},{"Often","ASL-Often","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4","0","0",""},{"Sometimes","ASL-Sometimes","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4","0","0",""},{"Heavy","ASL-Heavy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4","0","0",""},{"Lightweight","ASL-Lightweight","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4","0","0",""},{"Hard","ASL-Hard","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4","0","0",""},{"Soft","ASL-Soft","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4","0","0",""},{"Strong","ASL-Strong","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4","0","0",""},{"Weak","ASL-Weak","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4","0","0",""},{"First","ASL-First","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4","0","0",""},{"Second","ASL-Second","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4","0","0",""},{"Third","ASL-Third","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4","0","0",""},{"Next","ASL-Next","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4","0","0",""},{"Last","ASL-Last","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4","0","0",""},{"Before","ASL-Before","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4","0","0",""},{"After","ASL-After","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4","0","0",""},{"Busy","ASL-Busy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4","0","0",""},{"Free","ASL-Free","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4","0","0",""},{"High","ASL-High","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4","0","0",""},{"Low","ASL-Low","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4","0","0",""},{"Fat","ASL-Fat","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4","0","0",""},{"Thin","ASL-Thin","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4","0","0",""},{"Value","ASL-Value","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4","0","0",""}},
new string[,]{//Lesson 7 (Time)
{"Time","ASL-Time","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4","0","0",""},{"Year","ASL-Year","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4","0","0",""},{"Season","ASL-Season","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4","0","0",""},{"Month","ASL-Month","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4","0","0",""},{"Week","ASL-Week","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4","0","0",""},{"Day","ASL-Day","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4","0","0",""},{"Weekend","ASL-Weekend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4","0","0",""},{"Hours","ASL-Hours","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4","0","0",""},{"Minutes","ASL-Minutes","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4","0","0",""},{"Seconds","ASL-Seconds","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4","0","0",""},{"Today","ASL-Today","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4","0","0",""},{"Tomorrow","ASL-Tomorrow","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4","0","0",""},{"Yesterday","ASL-Yesterday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4","0","0",""},{"Morning","ASL-Morning","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4","0","0",""},{"Afternoon","ASL-Afternoon","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4","0","0",""},{"Evening","ASL-Evening","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4","0","0",""},{"Night","ASL-Night","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4","0","0",""},{"Sunrise","ASL-Sunrise","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4","0","0",""},{"Sunset","ASL-Sunset","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4","0","0",""},{"All night","ASL-All night","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","0","0",""},{"All Day","ASL-All Day","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","0","0",""},{"Sunday","ASL-Sunday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4","0","0",""},{"Monday","ASL-Monday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4","0","0",""},{"Tuesday","ASL-Tuesday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4","0","0",""},{"Wednesday","ASL-Wednesday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4","0","0",""},{"Thursday","ASL-Thursday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4","0","0",""},{"Friday","ASL-Friday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4","0","0",""},{"Saturday","ASL-Saturday","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4","0","0",""},{"Autumn (Fall)","ASL-Autumn (Fall)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4","0","0",""},{"Winter","ASL-Winter","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4","0","0",""},{"Spring","ASL-Spring","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4","0","0",""},{"Summer","ASL-Summer","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4","0","0",""},{"Now","ASL-Now","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4","0","0",""},{"Never","ASL-Never","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4","0","0",""},{"Soon","ASL-Soon","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4","0","0",""},{"Later","ASL-Later","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4","0","0",""},{"Past","ASL-Past","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4","0","0",""},{"Future","ASL-Future","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4","0","0",""},{"Earlier","ASL-Earlier","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4","0","0",""},{"Midweek","ASL-Midweek","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4","0","0",""},{"Next Week","ASL-Next Week","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4","0","0",""},{"Late Afternoon","ASL-Late Afternoon","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet07/07-42.mp4","0","0",""}},
new string[,]{//Lesson 8 (VRChat)
{"Gestures","ASL-Gestures","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4","0","0",""},{"World","ASL-World","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4","0","0",""},{"Record","ASL-Record","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4","0","0",""},{"Discord","ASL-Discord","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4","0","0",""},{"Streaming","ASL-Streaming","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4","0","0",""},{"Headset (VR)","ASL-Headset (VR)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4","0","0",""},{"Desktop","ASL-Desktop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4","0","0",""},{"Computer","ASL-Computer","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4","0","0",""},{"Instance","ASL-Instance","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4","0","0",""},{"Public","ASL-Public","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4","0","0",""},{"Invite","ASL-Invite","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4","0","0",""},{"Private","ASL-Private","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4","0","0",""},{"Add friend","ASL-Add friend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4","0","0",""},{"Menu","ASL-Menu","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4","0","0",""},{"Recharge","ASL-Recharge","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4","0","0",""},{"Visit","ASL-Visit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4","0","0",""},{"Request","ASL-Request","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4","0","0",""},{"Login","ASL-Login","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4","0","0",""},{"Logout","ASL-Logout","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4","0","0",""},{"Schedule","ASL-Schedule","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4","0","0",""},{"Event","ASL-Event","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4","0","0",""},{"Online","ASL-Online","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4","0","0",""},{"Offline","ASL-Offline","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4","0","0",""},{"Cancel","ASL-Cancel","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4","0","0",""},{"Portal","ASL-Portal","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4","0","0",""},{"Camera","ASL-Camera","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4","0","0",""},{"Avatar","ASL-Avatar","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4","0","0",""},{"Photo","ASL-Photo","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4","0","0",""},{"Join","ASL-Join","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4","0","0",""},{"Leave","ASL-Leave","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4","0","0",""},{"Climbing","ASL-Climbing","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4","0","0",""},{"Falling","ASL-Falling","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4","0","0",""},{"Walk","ASL-Walk","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4","0","0",""},{"Hide","ASL-Hide","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4","0","0",""},{"Block","ASL-Block","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4","0","0",""},{"Crash","ASL-Crash","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4","0","0",""},{"Lagging","ASL-Lagging","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4","0","0",""},{"Restart","ASL-Restart","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4","0","0",""},{"Send","ASL-Send","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4","0","0",""},{"Receive","ASL-Receive","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4","0","0",""},{"Security","ASL-Security","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4","0","0",""},{"Donation","ASL-Donation","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4","0","0",""}},
new string[,]{//Lesson 9 (Alphabet / Numbers)
{"A","ASL-A","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4","0","0",""},{"B","ASL-B","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","0","0",""},{"C","ASL-C","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4","0","0",""},{"D","ASL-D","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4","0","0",""},{"E","ASL-E","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4","0","0",""},{"F","ASL-F","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","0","0",""},{"G","ASL-G","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4","0","0",""},{"H","ASL-H","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4","0","0",""},{"I","ASL-I","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","0","0",""},{"J","ASL-J","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","0","0",""},{"K","ASL-K","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","0","0",""},{"L","ASL-L","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4","0","0",""},{"M","ASL-M","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","0","0",""},{"N","ASL-N","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","0","0",""},{"O","ASL-O","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4","0","0",""},{"P","ASL-P","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4","0","0",""},{"Q","ASL-Q","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4","0","0",""},{"R","ASL-R","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4","0","0",""},{"S","ASL-S","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4","0","0",""},{"T","ASL-T","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4","0","0",""},{"U","ASL-U","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","0","0",""},{"V","ASL-V","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","0","0",""},{"W","ASL-W","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","0","0",""},{"X","ASL-X","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","0","0",""},{"Y","ASL-Y","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","0","0",""},{"Z","ASL-Z","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4","0","0",""},{"0","ASL-0","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4","0","0",""},{"1","ASL-1","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4","0","0",""},{"2","ASL-2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4","0","0",""},{"3","ASL-3","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4","0","0",""},{"4","ASL-4","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4","0","0",""},{"5","ASL-5","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4","0","0",""},{"6","ASL-6","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4","0","0",""},{"7","ASL-7","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4","0","0",""},{"8","ASL-8","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4","0","0",""},{"9","ASL-9","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4","0","0",""},{"10","ASL-10","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4","0","0",""},{"100","ASL-100","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4","0","0",""},{"1000","ASL-1000","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4","0","0",""},{"1000000","ASL-1000000","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4","0","0",""},{"Comma","ASL-Comma","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4","0","0",""},{"Space","ASL-Space","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4","0","0",""}},
new string[,]{//Lesson 10 (Verbs & Actions p1)
{"Overlook","ASL-Overlook","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4","0","0",""},{"Punish","ASL-Punish","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4","0","0",""},{"Edit","ASL-Edit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4","0","0",""},{"Erase","ASL-Erase","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4","0","0",""},{"Write","ASL-Write","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4","0","0",""},{"Proposal","ASL-Proposal","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4","0","0",""},{"Add","ASL-Add","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4","0","0",""},{"Remove","ASL-Remove","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4","0","0",""},{"Agree","ASL-Agree","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4","0","0",""},{"Disagree","ASL-Disagree","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4","0","0",""},{"Admit","ASL-Admit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4","0","0",""},{"Allow","ASL-Allow","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4","0","0",""},{"Attack","ASL-Attack","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4","0","0",""},{"Fight","ASL-Fight","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4","0","0",""},{"Defend","ASL-Defend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4","0","0",""},{"Defeat","ASL-Defeat","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4","0","0",""},{"Win","ASL-Win","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4","0","0",""},{"Lose","ASL-Lose","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4","0","0",""},{"Draw (game)","ASL-Draw (game)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4","0","0",""},{"Give up","ASL-Give up","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4","0","0",""},{"Skip","ASL-Skip","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4","0","0",""},{"Ask","ASL-Ask","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-22.mp4","0","0",""},{"Attach","ASL-Attach","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4","0","0",""},{"Assist","ASL-Assist","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4","0","0",""},{"Bait","ASL-Bait","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4","0","0",""},{"Battle","ASL-Battle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4","0","0",""},{"Beat","ASL-Beat","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4","0","0",""},{"Become","ASL-Become","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4","0","0",""},{"Beg","ASL-Beg","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4","0","0",""},{"Begin","ASL-Begin","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4","0","0",""},{"Behave","ASL-Behave","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4","0","0",""},{"Believe","ASL-Believe","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4","0","0",""},{"Blame","ASL-Blame","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4","0","0",""},{"Blow","ASL-Blow","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4","0","0",""},{"Blush","ASL-Blush","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4","0","0",""},{"Bother/Harass","ASL-Bother","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4","0","0",""}},
new string[,]{//Lesson 11 (Verbs & Actions p2)
{"Bend","ASL-Bend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4","0","0",""},{"Bow","ASL-Bow","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4","0","0",""},{"Break","ASL-Break","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4","0","0",""},{"Breathe","ASL-Breathe","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4","0","0",""},{"Bring","ASL-Bring","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4","0","0",""},{"Build","ASL-Build","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4","0","0",""},{"Bully","ASL-Bully","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4","0","0",""},{"Burn","ASL-Burn","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4","0","0",""},{"Buy","ASL-Buy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4","0","0",""},{"Call","ASL-Call","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4","0","0",""},{"Cancel","ASL-Cancel","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4","0","0",""},{"Care","ASL-Care","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4","0","0",""},{"Carry","ASL-Carry","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4","0","0",""},{"Catch","ASL-Catch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4","0","0",""},{"Cause","ASL-Cause","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4","0","0",""},{"Challenge","ASL-Challenge","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4","0","0",""},{"Chance","ASL-Chance","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4","0","0",""},{"Cheat","ASL-Cheat","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4","0","0",""},{"Check","ASL-Check","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4","0","0",""},{"Choose","ASL-Choose","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4","0","0",""},{"Claim","ASL-Claim","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4","0","0",""},{"Clean","ASL-Clean","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4","0","0",""},{"Clear","ASL-Clear","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4","0","0",""},{"Close","ASL-Close","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4","0","0",""},{"Comfort","ASL-Comfort","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4","0","0",""},{"Command","ASL-Command","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4","0","0",""},{"Communicate","ASL-Communicate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4","0","0",""},{"Compare","ASL-Compare","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4","0","0",""},{"Complain","ASL-Complain","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4","0","0",""},{"Compliment","ASL-Compliment","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4","0","0",""},{"Concentrate","ASL-Concentrate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4","0","0",""},{"Construct","ASL-Construct","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4","0","0",""},{"Control","ASL-Control","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4","0","0",""},{"Cook","ASL-Cook","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4","0","0",""},{"Copy","ASL-Copy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4","0","0",""},{"Correct","ASL-Correct","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4","0","0",""}},
new string[,]{//Lesson 12 (Verbs & Actions p3)
{"Cough","ASL-Cough","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4","0","0",""},{"Count","ASL-Count","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4","0","0",""},{"Create","ASL-Create","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4","0","0",""},{"Cuddle","ASL-Cuddle","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4","0","0",""},{"Cut","ASL-Cut","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4","0","0",""},{"Dab","ASL-Dab","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4","0","0",""},{"Dance","ASL-Dance","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4","0","0",""},{"Dare","ASL-Dare","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4","0","0",""},{"Date","ASL-Date","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4","0","0",""},{"Deal","ASL-Deal","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4","0","0",""},{"Deliver","ASL-Deliver","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4","0","0",""},{"Depend","ASL-Depend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4","0","0",""},{"Describe","ASL-Describe","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4","0","0",""},{"Dirty","ASL-Dirty","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4","0","0",""},{"Disappear","ASL-Disappear","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4","0","0",""},{"Disappoint","ASL-Disappoint","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4","0","0",""},{"Disapprove","ASL-Disapprove","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4","0","0",""},{"Discuss","ASL-Discuss","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4","0","0",""},{"Disguise","ASL-Disguise","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4","0","0",""},{"Disgust","ASL-Disgust","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4","0","0",""},{"Dismiss","ASL-Dismiss","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4","0","0",""},{"Disturb","ASL-Disturb","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4","0","0",""},{"Doubt","ASL-Doubt","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4","0","0",""},{"Dream","ASL-Dream","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4","0","0",""},{"Dress","ASL-Dress","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4","0","0",""},{"Drunk","ASL-Drunk","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4","0","0",""},{"Drop","ASL-Drop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4","0","0",""},{"Drown","ASL-Drown","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4","0","0",""},{"Dry","ASL-Dry","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4","0","0",""},{"Dump","ASL-Dump","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4","0","0",""},{"Dust","ASL-Dust","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4","0","0",""},{"Earn","ASL-Earn","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4","0","0",""},{"Effect","ASL-Effect","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4","0","0",""},{"End","ASL-End","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4","0","0",""},{"Escape","ASL-Escape","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4","0","0",""},{"Escort","ASL-Escort","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4","0","0",""}},
new string[,]{//Lesson 13 (Verbs & Actions p4)
{"Excuse","ASL-Excuse","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4","0","0",""},{"Expose","ASL-Expose","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4","0","0",""},{"Exist","ASL-Exist","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4","0","0",""},{"Fail","ASL-Fail","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4","0","0",""},{"Faint","ASL-Faint","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4","0","0",""},{"Fake","ASL-Fake","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4","0","0",""},{"Fart","ASL-Fart","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4","0","0",""},{"Fear","ASL-Fear","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4","0","0",""},{"Fill","ASL-Fill","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4","0","0",""},{"Find","ASL-Find","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4","0","0",""},{"Finish","ASL-Finish","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4","0","0",""},{"Fix","ASL-Fix","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4","0","0",""},{"Flip","ASL-Flip","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4","0","0",""},{"Flirt","ASL-Flirt","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4","0","0",""},{"Fly","ASL-Fly","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4","0","0",""},{"Forbid","ASL-Forbid","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4","0","0",""},{"Forgive","ASL-Forgive","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4","0","0",""},{"Gain","ASL-Gain","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4","0","0",""},{"Give","ASL-Give","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4","0","0",""},{"Glow","ASL-Glow","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4","0","0",""},{"Grab","ASL-Grab","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4","0","0",""},{"Grow","ASL-Grow","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4","0","0",""},{"Guard","ASL-Guard","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4","0","0",""},{"Guess","ASL-Guess","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4","0","0",""},{"Guide","ASL-Guide","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4","0","0",""},{"Harass/Bother","ASL-Harass","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4","0","0",""},{"Harm","ASL-Harm","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4","0","0",""},{"Hit","ASL-Hit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4","0","0",""},{"Hold","ASL-Hold","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4","0","0",""},{"Hop","ASL-Hop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4","0","0",""},{"Hope","ASL-Hope","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4","0","0",""},{"Hunt","ASL-Hunt","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4","0","0",""},{"Ignore","ASL-Ignore","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4","0","0",""},{"Imagine","ASL-Imagine","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4","0","0",""},{"Imitate","ASL-Imitate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4","0","0",""},{"Insult","ASL-Insult","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4","0","0",""}},
new string[,]{//Lesson 14 (Verbs & Actions p5)
{"Interact","ASL-Interact","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4","0","0",""},{"Interfere","ASL-Interfere","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4","0","0",""},{"Judge","ASL-Judge","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4","0","0",""},{"Jump","ASL-Jump","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4","0","0",""},{"Justify","ASL-Justify","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4","0","0",""},{"Just kidding","ASL-Just kidding","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4","0","0",""},{"Keep","ASL-Keep","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4","0","0",""},{"Kick","ASL-Kick","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4","0","0",""},{"Kill","ASL-Kill","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4","0","0",""},{"Knock","ASL-Knock","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4","0","0",""},{"Lead","ASL-Lead","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4","0","0",""},{"Lick","ASL-Lick","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4","0","0",""},{"Lock","ASL-Lock","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4","0","0",""},{"Manipulate","ASL-Manipulate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4","0","0",""},{"Melt","ASL-Melt","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4","0","0",""},{"Mess","ASL-Mess","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4","0","0",""},{"Miss","ASL-Miss","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4","0","0",""},{"Mistake","ASL-Mistake","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4","0","0",""},{"Mount","ASL-Mount","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4","0","0",""},{"Move","ASL-Move","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4","0","0",""},{"Murder","ASL-Murder","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4","0","0",""},{"Nod","ASL-Nod","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4","0","0",""},{"Note","ASL-Note","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4","0","0",""},{"Notice","ASL-Notice","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4","0","0",""},{"Obey","ASL-Obey","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4","0","0",""},{"Obsess","ASL-Obsess","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4","0","0",""},{"Obtain","ASL-Obtain","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4","0","0",""},{"Occupy","ASL-Occupy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4","0","0",""},{"Offend","ASL-Offend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4","0","0",""},{"Offer","ASL-Offer","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4","0","0",""},{"Okay","ASL-Okay","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4","0","0",""},{"Open","ASL-Open","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4","0","0",""},{"Order","ASL-Order","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4","0","0",""},{"Owe","ASL-Owe","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4","0","0",""},{"Own","ASL-Own","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4","0","0",""},{"Pass","ASL-Pass","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4","0","0",""}},
new string[,]{//Lesson 15 (Verbs & Actions p6)
{"Pat","ASL-Pat","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4","0","0",""},{"Party","ASL-Party","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4","0","0",""},{"Pet","ASL-Pet","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4","0","0",""},{"Pick","ASL-Pick","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4","0","0",""},{"Plug","ASL-Plug","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4","0","0",""},{"Point","ASL-Point","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4","0","0",""},{"Poke","ASL-Poke","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4","0","0",""},{"Pray","ASL-Pray","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4","0","0",""},{"Prepare","ASL-Prepare","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4","0","0",""},{"Present","ASL-Present","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4","0","0",""},{"Pretend","ASL-Pretend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4","0","0",""},{"Protect","ASL-Protect","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4","0","0",""},{"Prove","ASL-Prove","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4","0","0",""},{"Publish","ASL-Publish","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4","0","0",""},{"Puke","ASL-Puke","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","0","0",""},{"Pull","ASL-Pull","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4","0","0",""},{"Punch","ASL-Punch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4","0","0",""},{"Put","ASL-Put","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4","0","0",""},{"Push","ASL-Push","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4","0","0",""},{"Question","ASL-Question","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","0","0",""},{"Quit","ASL-Quit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4","0","0",""},{"Quote","ASL-Quote","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4","0","0",""},{"Race","ASL-Race","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4","0","0",""},{"React","ASL-React","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4","0","0",""},{"Recommended","ASL-Recommended","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4","0","0",""},{"Refuse","ASL-Refuse","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4","0","0",""},{"Regret","ASL-Regret","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4","0","0",""},{"Remember","ASL-Remember","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4","0","0",""},{"Replace","ASL-Replace","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4","0","0",""},{"Report","ASL-Report","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4","0","0",""},{"Reset","ASL-Reset","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4","0","0",""},{"Ride","ASL-Ride","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4","0","0",""},{"Rub","ASL-Rub","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4","0","0",""},{"Rule","ASL-Rule","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4","0","0",""},{"Run","ASL-Run","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4","0","0",""},{"Save","ASL-Save","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4","0","0",""}},
new string[,]{//Lesson 16 (Verbs & Actions p7)
{"Say","ASL-Say","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4","0","0",""},{"Search","ASL-Search","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4","0","0",""},{"See","ASL-See","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4","0","0",""},{"Share","ASL-Share","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4","0","0",""},{"Shock","ASL-Shock","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4","0","0",""},{"Shop","ASL-Shop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4","0","0",""},{"Show","ASL-Show","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4","0","0",""},{"Shut up","ASL-Shut up","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4","0","0",""},{"Shut down","ASL-Shut down","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4","0","0",""},{"Sing","ASL-Sing","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4","0","0",""},{"Sit","ASL-Sit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4","0","0",""},{"Smell","ASL-Smell","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4","0","0",""},{"Smile","ASL-Smile","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4","0","0",""},{"Smoke","ASL-Smoke","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4","0","0",""},{"Speak","ASL-Speak","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4","0","0",""},{"Spell","ASL-Spell","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0","0",""},{"Spit","ASL-Spit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4","0","0",""},{"Stand","ASL-Stand","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4","0","0",""},{"Start","ASL-Start","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4","0","0",""},{"Stay","ASL-Stay","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4","0","0",""},{"Steal","ASL-Steal","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4","0","0",""},{"Stop","ASL-Stop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4","0","0",""},{"Study","ASL-Study","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4","0","0",""},{"Suffer","ASL-Suffer","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4","0","0",""},{"Swim","ASL-Swim","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4","0","0",""},{"Switch","ASL-Switch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4","0","0",""},{"Take","ASL-Take","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4","0","0",""},{"Talk","ASL-Talk","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4","0","0",""},{"Tell","ASL-Tell","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4","0","0",""},{"Test","ASL-Test","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4","0","0",""},{"Text","ASL-Text","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4","0","0",""},{"Think","ASL-Think","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4","0","0",""},{"Throw","ASL-Throw","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4","0","0",""},{"Tie","ASL-Tie","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4","0","0",""},{"Truth","ASL-Truth","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4","0","0",""},{"Try","ASL-Try","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4","0","0",""}
}};
        /*
        string [][,] BSLlessons = { //creates BSL lesson array
            new string[,]{//lesson 1 (Daily Use) creates a multidimentional array. First value displays what you want to show on the UI, the 2nd is the name of the person recording mocap.
            {"Hello","GT4tube"},{"How are you","GT4tube"},{"What's up?","GT4tube"},{"Nice to meet you","GT4tube"},{"Good","GT4tube"},
            {"Bad","GT4tube"},{"Yes","GT4tube"},{"No","GT4tube"},{"So-So","GT4tube"},{"Sick","GT4tube"},
            {"Hurt","GT4tube"},{"You're welcome","GT4tube"},{"Good bye","GT4tube"},{"Good morning","GT4tube"},{"Good afternoon","GT4tube"},{"Good evening","GT4tube"},{"Good night","GT4tube"},
            {"See you later","GT4tube"},{"Please","GT4tube"},{"Sorry","GT4tube"},{"Forgotten","GT4tube"},{"Sleep","GT4tube"},{"Bed","GT4tube"},{"Jump/Change world","GT4tube"},{"Thank you","GT4tube"},
            {"I love you","GT4tube"},{"Go away","GT4tube"},{"Going to","GT4tube"},{"Follow","GT4tube"},{"Come","GT4tube"},{"Hearing","GT4tube"},{"Deaf","GT4tube"},{"Hard of Hearing","GT4tube"},
            {"Mute","GT4tube"},{"Write slow","GT4tube"},{"Cannot read","GT4tube"}}
        };
		*/

        //string [][][,] AllLessons = { ASLlessons, BSLlessons }; //if multi-languages are ever implimented
        string [][][,] AllLessons = { ASLlessons}; //adds array of arrays into another array for easy looping.


        string [] lessonnames = new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language.
        "Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Alphabet / Numbers","Verbs & Actions p1","Verbs & Actions p2","Verbs & Actions p3",
        "Verbs & Actions p4","Verbs & Actions p5","Verbs & Actions p6","Verbs & Actions p7","Verbs & Actions p8","Food","Animals / Machines","Places","Stuff / Weather","Clothes / Equipment","Fantasy / Characters",
        "Holidays / Special Days","Home stuff","Nature / Environment","Talk / Asking exercises","Name sign users","Countries","Colors","Medical"};
        string [,] signlanguagenames = new string[,]{{"ASL","American Sign Language"},{"BSL","British Sign Language"}};


	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None;

	int layer=8;
	int rowoffset=860;
	int columnoffset=200;



	int rowseperation=100;
	int columnseperation=1000;

int menusizex = 4900;
int menusizey = 1600;
int headersizey=60;
int textpadding=10;
int buttonsizey=100;
int buttonsizex=900;
int menubuttonystart=textpadding+headersizey+buttonsizey + 80;

Vector2 buttonsize=new Vector2(buttonsizex,buttonsizey);
Vector2 menusize=new Vector2(menusizex,menusizey);
Vector3 menurootposition = new Vector3(-6.5f, 0, 16);
Vector3 canvasscale=new Vector3(.001f,.001f,.001f);
Vector2 zerovector2=new Vector2(0,0);
Vector3 zerovector3=new Vector3(0,0,0);

/*
Debug.Log(ASLlessons.Length );//2 number of arrays inside
Debug.Log(ASLlessons[0].GetLength(0));//36 number of rows in first array
Debug.Log(ASLlessons[0].GetLength(1));//2 number of columns in first array
Debug.Log(ASLlessons[1].GetLength(0));//42
Debug.Log(ASLlessons[1].GetLength(1));//2
*/
//Debug.Log(ASLlessons.Length );//16 number of arrays inside
//Debug.Log(ASLlessons[0].GetLength(0) );//36number of arrays inside

/*****************************************
START OF PROGRAM
*****************************************/

GameObject menuroot = new GameObject("Menu Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
menuroot.transform.position = menurootposition;
menuroot.layer = layer;
	GameObject videocontainer = new GameObject("Video Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
	videocontainer.transform.position = new Vector3(8.75f, 1, 0);
	videocontainer.transform.SetParent(menuroot.transform, false);
	videocontainer.layer = layer;

	GameObject triggercontainer = new GameObject("Trigger Container"); //container go to hold all the triggers. Allows a world option that turns on/off global triggers.
	videocontainer.transform.SetParent(menuroot.transform, false);
	videocontainer.layer = layer;

		GameObject globaltriggercontainer = new GameObject("Global Trigger Container"); //container go to hold all the gloval triggers.
		globaltriggercontainer.transform.SetParent(triggercontainer.transform, false);
		globaltriggercontainer.layer = layer;

		GameObject localtriggercontainer = new GameObject("Local Trigger Container"); //container go to hold all the local triggers.
		localtriggercontainer.transform.SetParent(triggercontainer.transform, false);
		localtriggercontainer.layer = layer;


	GameObject rootcanvas = new GameObject ("Root Canvas");
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
	rootcanvas.AddComponent<ToggleGroup>();

		//GameObject rootpanel = new GameObject ("Root Panel"); //Creates panel under rootcanvas.
		DefaultControls.Resources rootpanelresources = new DefaultControls.Resources();
		rootpanelresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
		GameObject rootpanel = DefaultControls.CreatePanel(rootpanelresources);
		rootpanel.transform.SetParent(rootcanvas.transform, false);
		rootpanel.layer = layer;
		rootpanel.GetComponent<RectTransform> ().sizeDelta = menusize;
		rootpanel.GetComponent<RectTransform> ().anchorMax = zerovector2;
		rootpanel.GetComponent<RectTransform> ().anchorMin = zerovector2;
		rootpanel.GetComponent<RectTransform> ().pivot = zerovector2;
		rootpanel.GetComponent<Image> ().color = new Color(1,1,1,1); //gets rid of transparency - also can change panel color if I want here. 1=255.

		GameObject langselectmenu = new GameObject("VR Sign Language Select Menu");
		langselectmenu.transform.SetParent(rootcanvas.transform, false);
		langselectmenu.layer = layer;

		DefaultControls.Resources txtresources = new DefaultControls.Resources();
		GameObject langselectmenuheader = DefaultControls.CreateText(txtresources);
		langselectmenuheader.transform.SetParent (langselectmenu.transform, false);
		langselectmenuheader.name="VR Sign Language Select Menu Header";
		langselectmenuheader.layer = layer;
		langselectmenuheader.GetComponent<Text> ().text = "VR Sign Language Select Menu";
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
			//create a root gameobject for each language
			GameObject langroot = new GameObject(signlanguagenames[languagenum,0]+" Root"); //creates language container for a given language.
			langroot.transform.SetParent(rootcanvas.transform, false);
			langroot.layer = layer;
			//Debug.Log(signlanguages.Length + " " +languages);

			GameObject globallanguagetriggercontainer = new GameObject(signlanguagenames[languagenum,0]+" Global Trigger Container"); //create language container for a given language to house global triggers.
			globallanguagetriggercontainer.transform.SetParent(globaltriggercontainer.transform, false);
			globallanguagetriggercontainer.layer = layer;
			GameObject locallanguagetriggercontainer = new GameObject(signlanguagenames[languagenum,0]+" Global Trigger Container"); //create language container for a given language to house local triggers.
			globallanguagetriggercontainer.transform.SetParent(localtriggercontainer.transform, false);
			globallanguagetriggercontainer.layer = layer;
			//localtriggercontainer//globaltriggercontainer

			//create language select button
			GameObject bgo = createbutton2(parent:langselectmenu, name:signlanguagenames[languagenum,1], sizedelta:buttonsize,
            anchoredPosition: new Vector2(columnoffset+(languagenum*columnseperation), menubuttonystart-(languagenum*rowseperation)),
            text: signlanguagenames[languagenum,1], fontSize:50, txtsizedelta:buttonsize, txtanchoredPosition:new Vector2(20,0),
            alignment:TextAnchor.MiddleLeft, nav:no_nav, layer:layer);

				//Create lesson sub-menu for nested loop to parent buttons to.
				GameObject lessonmenu = new GameObject(signlanguagenames[languagenum,0]+" Lesson Menu");
				lessonmenu.transform.SetParent(langroot.transform, false);
				lessonmenu.layer = layer;
					//Create lesson menu header
					GameObject lessonselectmenuheader = DefaultControls.CreateText(txtresources);
					lessonselectmenuheader.transform.SetParent (rootcanvas.transform, false);
					lessonselectmenuheader.name=signlanguagenames[languagenum,0]+"Lesson Menu";
					lessonselectmenuheader.layer = layer;
					lessonselectmenuheader.GetComponent<Text> ().text = "VR-"+signlanguagenames[languagenum,0]+" Sign Language - Lesson Menu (Green = contains \"verified\" motion data.) (Yellow = contains \"Unverified\" motion data and verified videos) (Red = no motion data, but contains verified videos)";
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
				for (int lessonnum = 0; lessonnum < AllLessons[languagenum].Length; lessonnum++){ //for every lesson inside of ASLlessons do:
					

					
					//create lesson menu button here for lessonmenu.-one at a time
					GameObject leesonbgo = createbutton2(parent:lessonmenu, name:signlanguagenames[languagenum,1], sizedelta:buttonsize,
					anchoredPosition: new Vector2(columnoffset+(languagenum*columnseperation), menusizey-headersizey-textpadding-(lessonnum*rowseperation)),
					text: signlanguagenames[languagenum,0]+" L"+(lessonnum+1)+"("+lessonnames[lessonnum]+") - Button", fontSize:50, txtsizedelta:buttonsize, txtanchoredPosition:new Vector2(20,0),
					alignment:TextAnchor.MiddleLeft, nav:no_nav, layer:layer);

					//create lesson x gameobject eg: ASL Lesson x
					GameObject lessongo = new GameObject(signlanguagenames[languagenum,0]+" Lesson "+(lessonnum+1));
					lessongo.transform.SetParent(langroot.transform, false);
					lessongo.layer = layer;
					

					//create lesson x header
					GameObject lessongoheader = DefaultControls.CreateText(txtresources);
					lessongoheader.transform.SetParent (lessongo.transform, false);
					lessongoheader.name=signlanguagenames[languagenum,0]+" Lesson "+(lessonnum+1) + "- Header"; //ASL Lesson X Lesson Header
					lessongoheader.layer = layer;
					lessongoheader.GetComponent<Text> ().text = "VR-"+signlanguagenames[languagenum,0]+" Sign Language - Lesson " + (lessonnum+1) + " - " + lessonnames[lessonnum];
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
					
					GameObject videolessoncontainer = new GameObject(signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1));
					videolessoncontainer.transform.SetParent(videocontainer.transform, false);
					videolessoncontainer.layer=layer;
                    

					
                    //add a back button


/*****************************************
MAIN WORD LOOP HERE
*****************************************/
					//initialize row/columns at start of word processing to create lesson boards
					int column = 0;
					int row = 0;
                    for (int wordnum = 0; wordnum < ASLlessons[lessonnum].GetLength(0); wordnum++){ //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.

					//create two helpers, one under global, one under local
					GameObject localtrigger = new GameObject(signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Local Trigger");//helper gameobject with vrc_trigger. 
					localtrigger.transform.SetParent (locallanguagetriggercontainer.transform, false);
					localtrigger.layer = layer;
					

					GameObject globaltrigger = new GameObject(signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Global Trigger");//helper gameobject with vrc_trigger. 
					globaltrigger.transform.SetParent (globallanguagetriggercontainer.transform, false);
					globaltrigger.layer = layer;
					
					VRC_Trigger helperlocaltrigger = localtrigger.GetOrAddComponent<VRC_Trigger>();
					VRC_Trigger helperglobaltrigger = globaltrigger.GetOrAddComponent<VRC_Trigger>();
					helperglobaltrigger.UsesAdvancedOptions = true;
					helperlocaltrigger.UsesAdvancedOptions = true;

					VRC_Trigger.TriggerEvent customTrig = new VRC_Trigger.TriggerEvent ();
					customTrig.BroadcastType = VRC_EventHandler.VrcBroadcastType.Local;
					customTrig.TriggerType = VRC_Trigger.TriggerType.OnEnable;
					customTrig.TriggerIndividuals = true;

					VRC_EventHandler.VrcEvent setanimationtrigger;
					setanimationtrigger = new VRC_EventHandler.VrcEvent ();
					setanimationtrigger.EventType = VRC_EventHandler.VrcEventType.AnimationTrigger;
					setanimationtrigger.ParameterString = AllLessons[languagenum][lessonnum][wordnum,1];
					setanimationtrigger.ParameterObject = GameObject.Find ("/Nana Avatar");
					//eventAction.ParameterInt = 1;
					customTrig.Events.Add (setanimationtrigger); //this eventaction sets animation trigger on avatar controller
					
					VRC_EventHandler.VrcEvent setcurrentsigntext;
					setcurrentsigntext = new VRC_EventHandler.VrcEvent ();
					setcurrentsigntext.EventType = VRC_EventHandler.VrcEventType.SetUIText;
					setcurrentsigntext.ParameterString = AllLessons[languagenum][lessonnum][wordnum,0];
					setcurrentsigntext.ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text");
					customTrig.Events.Add (setcurrentsigntext); //this eventaction sets uitext on current sign text

					VRC_EventHandler.VrcEvent setspeechbubbletext;
					setspeechbubbletext = new VRC_EventHandler.VrcEvent ();
					setspeechbubbletext.EventType = VRC_EventHandler.VrcEventType.SetUIText;
					setspeechbubbletext.ParameterString = AllLessons[languagenum][lessonnum][wordnum,0];
					setspeechbubbletext.ParameterObject = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text");
					customTrig.Events.Add (setspeechbubbletext); //this eventaction sets uitext on avatar speech bubble text

					VRC_EventHandler.VrcEvent setcredittext;
					setcredittext = new VRC_EventHandler.VrcEvent ();
					setcredittext.EventType = VRC_EventHandler.VrcEventType.SetUIText;
					setcredittext.ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum,2];
					setcredittext.ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text");
					customTrig.Events.Add (setcredittext); //this eventaction sets uitext on avatar speech bubble text
					
					VRC_EventHandler.VrcEvent setdescription;
					setdescription = new VRC_EventHandler.VrcEvent ();
					setdescription.EventType = VRC_EventHandler.VrcEventType.SetUIText;
					setdescription.ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum,6];
					setdescription.ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text");
					customTrig.Events.Add (setdescription); //this eventaction sets uitext on avatar speech bubble text

					helperglobaltrigger.Triggers.Add(customTrig); //adds all event actions to the trigger for this helper gameobject.
					helperlocaltrigger.Triggers.Add(customTrig); //adds all event actions to the trigger for this helper gameobject.
					localtrigger.SetActive(false); //disables the gameobject since the UI toggle with enable them to activate the triggers.
					globaltrigger.SetActive(false); //disables the gameobject since the UI toggle with enable them to activate the triggers.
					//create lesson toggles
					
					//declare toggle resource settings
					DefaultControls.Resources toggleresources = new DefaultControls.Resources();
					//Set the Toggle Background Image someBgSprite;
					toggleresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
					//Set the Toggle Checkmark Image someCheckmarkSprite;
					toggleresources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
					GameObject uiToggle = DefaultControls.CreateToggle(toggleresources);
					Toggle t = uiToggle.GetOrAddComponent<Toggle>();
					uiToggle.gameObject.name = signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Toggle";				
					uiToggle.transform.SetParent(lessongo.transform, false);
					uiToggle.layer=layer;
					uiToggle.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
					uiToggle.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((columnoffset +(column*columnseperation)),(rowoffset+(row*rowseperation)));
					//uiToggle.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((240 +(column*1000)),(1400+(row*-150)));
					uiToggle.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
					uiToggle.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
					uiToggle.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
					t.navigation = no_nav;
					t.isOn = false;
					t.transition= Selectable.Transition.None;
					t.toggleTransition= Toggle.ToggleTransition.None;
					t.group=rootcanvas.gameObject.GetComponent<ToggleGroup>();
					t.onValueChanged = new Toggle.ToggleEvent();


					UnityEventTools.AddPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), localtrigger, "SetActive") as UnityAction<bool>);
					UnityEventTools.AddPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), globaltrigger, "SetActive") as UnityAction<bool>);
					GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
					videogo.name=signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
					videogo.layer = layer;
					videogo.transform.SetParent(videolessoncontainer.transform, false);
					//GameObject videogo = GameObject.Find("/Menu Root/Video Container/"+lang+" Video Container/"+lang+" Video L"+(lessonnum+1)+"/"+lang+" Video L"+(lessonnum+1)+" S"+(x+1));

                    } //end of word loop.

				//back button triggers?

				} //end of lesson loop.


			//assign triggers after lessons created. Triggers for Language Chooser menu buttons.
			Button b = bgo.GetOrAddComponent<Button>();
			b.onClick = new Button.ButtonClickedEvent();
			UnityAction<bool> enableaslroot = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum,0]+" Root"), "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(b.onClick, enableaslroot, true);

			UnityAction<bool> enableaslmenuselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum,0]+" Lesson Menu"), "SetActive") as UnityAction<bool>;//GameObject.Find("Menu Root/Root Canvas/ASL Root/ASL Lesson Menu")
			UnityEventTools.AddBoolPersistentListener(b.onClick, enableaslmenuselect, true);

			UnityAction<bool> disablelanguageselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find("Menu Root/Root Canvas/VR Sign Language Select Menu"), "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(b.onClick, disablelanguageselect, false);
			//activates video container for specific language
			UnityAction<bool> enablevideolanguage = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find("Menu Root/Video Container/"+signlanguagenames[languagenum,0]+" Video Container"), "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(b.onClick, enablevideolanguage, true);

			
	} //end of language loop

/*****************************************
Update menu system to point to newly created objects.
*****************************************/
//recreate toggle to fix reference?
			Toggle oldvideotoggle = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Video Toggle").GetOrAddComponent<Toggle>();
			DestroyImmediate(oldvideotoggle);
			Toggle newvideotoggle = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Video Toggle").GetOrAddComponent<Toggle>();
			newvideotoggle.navigation = no_nav;
			newvideotoggle.isOn = true;
			newvideotoggle.transition= Selectable.Transition.None;
			newvideotoggle.toggleTransition= Toggle.ToggleTransition.None;
			newvideotoggle.onValueChanged = new Toggle.ToggleEvent();
UnityEventTools.AddPersistentListener(newvideotoggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videocontainer, "SetActive") as UnityAction<bool>);




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
static GameObject createbutton2(GameObject parent, string name,Vector2 sizedelta,Vector2 anchoredPosition,
string text,Vector2 txtsizedelta,Vector2 txtanchoredPosition, TextAnchor alignment,Navigation nav,int layer,int rotatex=0,int rotatey=0,int rotatez=0,int fontSize=50){

DefaultControls.Resources buttonresources = new DefaultControls.Resources();
//Set the Button Background Image someBgSprite;
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
go.GetComponent<RectTransform> ().anchoredPosition = anchoredPosition;
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
