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
							UsesAdvancedOptions=true,
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
public class CreateASLButtons4 : MonoBehaviour {
	[MenuItem("ASLWorld/ButtonV4")]
	static void ButtonV4()
	{
	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; //why create two copies? Too hard to sync all the different active/inactive gameobjects if everyone isn't on the same "page".


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
			BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
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
				}
			}
		},
		new VRC_Trigger.TriggerEvent{
			BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
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
					ParameterObject=GameObject.Find ("/Nana Avatar"),
					ParameterString="sign",
					ParameterInt=-1,
				},
				new VRC_EventHandler.VrcEvent{
					EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
					ParameterObject=GameObject.Find ("/Nana Avatar"),
					ParameterString="Idle"
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "",
					ParameterObject = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "The sign that's currently playing will show here.",
					ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "Do not use this world to learn yet. These motions are a placeholder.",
					ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text")
				},
				new VRC_EventHandler.VrcEvent{
					EventType = VRC_EventHandler.VrcEventType.SetUIText,
					ParameterString = "Description of movements here. (Slowly being added)",
					ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text")
				}
			}
		}
	};
						

	
globalmenu.SetActive(false);


    }
    static GameObject CreateMenu(GameObject parent, string mode){
	
    	//Declare some variables + settings.


/*****************************************
Start of Arrays variable declarations
*****************************************/

        //creates an array of arrays. Grouped by lessons. 
        //0th value is the word 
        //1st value is the name of the animation state (Used in the animation controller populator script to generate transitions - needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
        //2nd value is mocap credits. 
        //3rd value is video URL.
        //4th value is home sign indicator 0 = normal, 1=homesign
        //5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
        //6th value is Sign description string
string [][,] ASLlessons = {
new string[,]{//Fingerspelling
{"Fingerspell","ASL-Fingerspell","Placeholder.","","0","0",""},{"Fingerspell (Variant 2)","ASL-Fingerspell2","No Data Yet.","","0","1",""},{"A","ASL-A","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4","1","2",""},{"B","ASL-B","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","0","0",""},{"B (Variant 2)","ASL-B2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","1","1",""},{"C","ASL-C","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4","0","2",""},{"D","ASL-D","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4","0","2",""},{"E","ASL-E","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4","1","2",""},{"F","ASL-F","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","0","0",""},{"F (Variant 2)","ASL-F2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","1","1",""},{"G","ASL-G","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4","0","2",""},{"H","ASL-H","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4","0","2",""},{"I","ASL-I","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","0","0",""},{"I (Variant 2)","ASL-I2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","1","1",""},{"J","ASL-J","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","0","0","Trace out a 'J' midair with your pinky using a rotation of your wrist"},{"J (Variant 2)","ASL-J2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","1","1","Indicate your pinky is out, then trace out a 'J' midair with your pinky using a rotation of your wrist"},{"K","ASL-K","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","1","0",""},{"K (Variant 2)","ASL-K2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","1","2",""},{"L","ASL-L","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4","0","2",""},{"M","ASL-M","Placeholder.","","1","2",""},{"M (Variant 2)","ASL-M2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","1","2",""},{"N","ASL-N","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","1","2",""},{"O","ASL-O","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4","0","2",""},{"P","ASL-P","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4","0","2",""},{"Q","ASL-Q","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4","0","2",""},{"R","ASL-R","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4","1","2",""},{"S","ASL-S","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4","0","2",""},{"T","ASL-T","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4","1","2",""},{"U","ASL-U","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","0","0",""},{"U (Variant 2)","ASL-U2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","1","1","The 'Peace Sign' on Regular VR looks like a V, so emphasise U shape by moving it in the shape of a U."},{"V","ASL-V","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","1","0","The 'Peace Sign' on the Index looks like a U, so emphhasise a V shape by moving it in the shape of a V."},{"V (Variant 2)","ASL-V2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","0","1",""},{"W","ASL-W","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","0","0",""},{"W (Variant 2)","ASL-W2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","1","2",""},{"X","ASL-X","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","0","0",""},{"X (Variant 2)","ASL-X2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","1","2",""},{"Y","ASL-Y","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","0","0",""},{"Y (Variant 2)","ASL-Y2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","1","1",""},{"Z","ASL-Z","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4","0","0",""},{"Comma","ASL-Comma","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4","0","0",""},{"Space","ASL-Space","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4","0","0","To indicate a space between fingerspelled words, you simply insert a very small pause between letters."},{"@","ASL-@","Placeholder.","","0","2","Use for the symbol @, like in an email address."}},
new string[,]{//Numbers
{"Number","ASL-Number","Placeholder.","","0","2","Pinch fingers together"},{"0","ASL-0","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4","0","0",""},{"1","ASL-1","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4","0","0",""},{"2","ASL-2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4","0","0",""},{"3","ASL-3","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4","0","0",""},{"4","ASL-4","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4","0","0",""},{"5","ASL-5","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4","0","0",""},{"6","ASL-6","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4","0","0",""},{"7","ASL-7","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4","0","0",""},{"8","ASL-8","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4","0","0",""},{"9","ASL-9","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4","0","0",""},{"10","ASL-10","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4","0","0",""},{"100","ASL-100","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4","0","0",""},{"1000","ASL-1000","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4","0","0",""},{"1000000","ASL-1000000","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4","0","0",""}},
new string[,]{//Lesson 1 (Daily Use)
{"Hello","ASL-Hello","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4","0","2",""},{"How (are) You","ASL-How Are You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4","0","2",""},{"What's Up?","ASL-What's Up?","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","0","0",""},{"What's Up? (Variant 2)","ASL-What's Up?2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","1","2",""},{"Nice (to) Meet You","ASL-Nice (to) Meet You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4","0","2",""},{"Good","ASL-Good","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4","0","2",""},{"Bad","ASL-Bad","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4","0","2",""},{"Yes","ASL-Yes","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4","0","2",""},{"No","ASL-No","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4","0","2",""},{"So-So","ASL-So-So","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4","0","2",""},{"Sick","ASL-Sick","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","0","1",""},{"Sick","ASL-Sick(vrversion)","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","0","2",""},{"Hurt","ASL-Hurt","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4","0","2",""},{"You're Welcome","ASL-You're Welcome","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4","0","2",""},{"Goodbye","ASL-Goodbye","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4","0","2",""},{"Good Morning","ASL-Good Morning","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4","0","2",""},{"Good Afternoon","ASL-Good Afternoon","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4","0","2",""},{"Good Evening","ASL-Good Evening","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4","0","2",""},{"Good Night","ASL-Good Night","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4","0","2",""},{"See You Later","ASL-See You Later","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4","0","2",""},{"Please","ASL-Please","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4","0","2",""},{"Sorry","ASL-Sorry","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4","0","2",""},{"Forget","ASL-Forget","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4","0","2",""},{"Sleep","ASL-Sleep","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4","0","2",""},{"Bed","ASL-Bed","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4","0","2",""},{"Jump/Change World","ASL-Jump/Change World","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4","0","2",""},{"Thank You","ASL-Thank You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4","0","2",""},{"I Love You","ASL-I Love You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4","0","2",""},{"ILK (I Love You)","ASL-ILY","No Data Yet.","","0","0","This sign is the combinations of the letters I, L, and Y. It's the compact version of I Love You."},{"Go Away","ASL-Go Away","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4","0","2",""},{"Going To","ASL-Going To","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4","0","2","Directional Sign, you point to where you're going."},{"Follow","ASL-Follow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4","0","2",""},{"Come","ASL-Come","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4","0","2",""},{"Hearing (Person)","ASL-Hearing (Person)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4","0","2","Use this when discussing a person that can hear."},{"Deaf","ASL-Deaf","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","0","2",""},{"Deaf (Variant 2)","ASL-Deaf2","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","0","2",""},{"Hard of Hearing","ASL-Hard of Hearing","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4","0","2",""},{"Mute","ASL-Mute","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4","0","2",""},{"Write Slow","ASL-Write Slow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4","0","2",""},{"Can't Read","ASL-Can't Read","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4","0","2",""}},
new string[,]{//Lesson 2 (Pointing use Question/Answer)
{"I (Me)","ASL-I (Me)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4","0","2",""},{"My","ASL-My","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4","0","2","Open palm implies possessive. eg: That wallet is mine."},{"Your","ASL-Your","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4","0","2","A possessive form of 'you'. eg: That's your wallet."},{"His","ASL-His","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4","0","2",""},{"Her","ASL-Her","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4","0","2",""},{"We","ASL-We","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4","0","2",""},{"They","ASL-They","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4","0","2","You sweep your pointer over the people you're referring to."},{"Their","ASL-Their","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4","0","2","Possessive form of they. eg: This is their house."},{"Over There","ASL-Over There","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4","0","2",""},{"Our","ASL-Our","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4","0","2",""},{"It's","ASL-It's","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4","0","1",""},{"Inside","ASL-Inside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4","0","2",""},{"Outside","ASL-Outside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4","0","2",""},{"Hidden","ASL-Hidden","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4","0","2",""},{"Behind","ASL-Behind","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4","0","2",""},{"Above","ASL-Above","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4","0","2",""},{"Below","ASL-Below","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4","0","2",""},{"Here","ASL-Here","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4","0","2",""},{"Beside","ASL-Beside","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4","0","2",""},{"Back","ASL-Back","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4","0","2",""},{"Front","ASL-Front","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4","0","2",""},{"Who","ASL-Who","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4","0","2",""},{"Where","ASL-Where","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4","0","2",""},{"When","ASL-When","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4","0","2",""},{"Why","ASL-Why","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4","0","2",""},{"Which","ASL-Which","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4","0","2",""},{"What","ASL-What","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","0","1","This variant is perferred over variant 2, as variant 2 is a Signed Exact English Variant"},{"What (Variant 2)","ASL-What2","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","0","0","A Signed Exact English variant of What."},{"How","ASL-How","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4","0","2",""},{"How (Variant 2)","ASL-How2","No Data Yet.","","0","2","The two A-hand version."},{"How Many","ASL-How Many","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4","0","2",""},{"Can","ASL-Can","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4","0","2",""},{"Can't","ASL-Can't","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4","0","2",""},{"Want","ASL-Want","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4","0","2",""},{"Have","ASL-Have","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4","0","2",""},{"Get","ASL-Get","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4","0","2",""},{"Will/Future","ASL-Will","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4","0","2","This is also the sign for Future"},{"Take","ASL-Take","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4","0","2",""},{"Need","ASL-Need","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4","0","2",""},{"Not","ASL-Not","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4","0","0",""},{"Or","ASL-Or","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4","0","0","This is just O and R fingerspelled."},{"And","ASL-And","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4","0","0",""},{"For","ASL-For","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4","0","0",""},{"At","ASL-At","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","0","0",""},{"At (Variant 2)","ASL-At2","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","0","0",""}},
new string[,]{//Lesson 3 (Common)
{"Teach","ASL-Teach","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4","0","0",""},{"Learn","ASL-Learn","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4","0","0",""},{"Person","ASL-Person","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4","0","0",""},{"Student","ASL-Student","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4","0","0",""},{"Teacher","ASL-Teacher","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4","0","0",""},{"Friend","ASL-Friend","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4","0","0",""},{"Sign","ASL-Sign","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4","0","0",""},{"Language","ASL-Language","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4","0","0",""},{"Understand","ASL-Understand","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4","0","0",""},{"Know","ASL-Know","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4","0","0",""},{"Don't Know","ASL-Don't Know","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4","0","0",""},{"Be Right Back (BRB)","ASL-Be Right Back (BRB)","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4","0","0",""},{"Accept","ASL-Accept","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4","0","0",""},{"Denied","ASL-Denied","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4","0","0",""},{"Name","ASL-Name","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4","0","0",""},{"New","ASL-New","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4","0","0",""},{"Old","ASL-Old2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4","0","0",""},{"Very","ASL-Very","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4","0","0",""},{"Jokes","ASL-Jokes","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4","0","0",""},{"Funny","ASL-Funny","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4","0","0",""},{"Play","ASL-Play","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4","0","0",""},{"Favorite","ASL-Favorite","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4","0","0",""},{"Draw (Pencil)","ASL-Draw (Pencil)","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4","0","0",""},{"Stop","ASL-Stop","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4","0","0",""},{"Read","ASL-Read","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4","0","0",""},{"Make","ASL-Make","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4","0","0",""},{"Write","ASL-Write2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4","0","0",""},{"Again / Repeat","ASL-Again / Repeat","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4","0","0",""},{"Slow","ASL-Slow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4","0","0",""},{"Fast","ASL-Fast","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4","0","0",""},{"Rude","ASL-Rude","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4","0","0",""},{"Eat","ASL-Eat","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4","0","0",""},{"Drink","ASL-Drink","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4","0","0",""},{"Watch","ASL-Watch","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4","0","0",""},{"Work","ASL-Work","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4","0","0",""},{"Live","ASL-Live","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4","0","0",""},{"Play Game","ASL-Play Game","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4","0","0",""},{"Same","ASL-Same","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4","0","0",""},{"All Right","ASL-All Right","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4","0","0",""},{"People","ASL-People","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4","0","0",""},{"Browsing the Internet","ASL-Browsing the Internet","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4","0","0",""},{"Movie","ASL-Movie","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4","0","0",""}},
new string[,]{//Lesson 4 (People)
{"Family","ASL-Family","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4","0","0",""},{"Boy","ASL-Boy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4","0","0",""},{"Girl","ASL-Girl","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4","0","0",""},{"Brother","ASL-Brother","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4","0","0",""},{"Sister","ASL-Sister","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4","0","0",""},{"Brother-in-law","ASL-Brother-in-law","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4","0","0",""},{"Sister-in-law","ASL-Sister-in-law","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4","0","0",""},{"Father","ASL-Father","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4","0","0",""},{"Grandpa","ASL-Grandpa","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4","0","0",""},{"Mother","ASL-Mother","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4","0","0",""},{"Grandma","ASL-Grandma","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4","0","0",""},{"Baby","ASL-Baby","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4","0","0",""},{"Child","ASL-Child","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4","0","0",""},{"Teen","ASL-Teen","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4","0","0",""},{"Adult","ASL-Adult","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4","0","0",""},{"Aunt","ASL-Aunt","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4","0","0",""},{"Uncle","ASL-Uncle","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4","0","0",""},{"Stranger","ASL-Stranger","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4","0","0",""},{"Acquaintance","ASL-Acquaintance","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4","0","0",""},{"Parents","ASL-Parents","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4","0","0",""},{"Born","ASL-Born","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4","0","0",""},{"Dead","ASL-Dead","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4","0","0",""},{"Marriage","ASL-Marriage","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4","0","0",""},{"Divorce","ASL-Divorce","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4","0","0",""},{"Single","ASL-Single","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4","0","0",""},{"Young","ASL-Young","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4","0","0",""},{"Old","ASL-Old","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4","0","0",""},{"Age","ASL-Age","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4","0","0",""},{"Birthday","ASL-Birthday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4","0","0",""},{"Celebrate","ASL-Celebrate","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4","0","0",""},{"Enemy","ASL-Enemy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4","0","0",""},{"Interpreter","ASL-Interpreter","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4","0","0",""},{"No One","ASL-No One","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4","0","0",""},{"Anyone","ASL-Anyone","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4","0","0",""},{"Someone","ASL-Someone","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4","0","0",""},{"Everyone","ASL-Everyone","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4","0","0",""}},
new string[,]{//Lesson 5 (Feelings / Reactions)
{"Like","ASL-Like","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4","0","0",""},{"Hate","ASL-Hate","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4","0","0",""},{"Fine","ASL-Fine","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4","0","0",""},{"Tired","ASL-Tired","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4","0","0",""},{"Sleepy","ASL-Sleep2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4","0","0",""},{"Confused","ASL-Confused","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4","0","0",""},{"Smart","ASL-Smart","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4","0","0",""},{"Attention / Focus","ASL-Attention / Focus","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4","0","0",""},{"Nevermind","ASL-Nevermind","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4","0","0",""},{"Angry","ASL-Angry","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4","0","0",""},{"Laughing","ASL-Laughing","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4","0","0",""},{"LOL","ASL-LOL","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4","0","0",""},{"Curious","ASL-Curious","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4","0","0",""},{"In Love","ASL-In Love","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4","0","0",""},{"Awesome","ASL-Awesome","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4","0","0",""},{"Great","ASL-Great","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4","0","0",""},{"Nice","ASL-Nice","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4","0","0",""},{"Cute","ASL-Cute","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4","0","0",""},{"Feel","ASL-Feel","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4","0","0",""},{"Pity","ASL-Pity","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4","0","0",""},{"Envy","ASL-Envy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4","0","0",""},{"Hungry","ASL-Hungry","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4","0","0",""},{"Alive","ASL-Alive","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4","0","0",""},{"Bored","ASL-Bored","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4","0","0",""},{"Cry","ASL-Cry","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4","0","0",""},{"Happy","ASL-Happy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4","0","0",""},{"Sad","ASL-Sad","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4","0","0",""},{"Suffering","ASL-Suffering","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4","0","0",""},{"Surprised","ASL-Surprised","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4","0","0",""},{"Careful","ASL-Careful","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4","0","0",""},{"Enjoy","ASL-Enjoy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4","0","0",""},{"Disgusted","ASL-Disgusted","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4","0","0",""},{"Embarassed","ASL-Embarassed","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4","0","0",""},{"Shy","ASL-Shy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4","0","0",""},{"Lonely","ASL-Lonely","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4","0","0",""},{"Stressed","ASL-Stressed","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4","0","0",""},{"Scared","ASL-Scared","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4","0","0",""},{"Excited","ASL-Excited","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4","0","0",""},{"Shame","ASL-Shame","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4","0","0",""},{"Struggle","ASL-Struggle","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4","0","0",""},{"Friendly","ASL-Friendly","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4","0","0",""},{"Mean","ASL-Mean","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4","0","0",""}},
new string[,]{//Lesson 6 (Value) 
{"More","ASL-More","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4","0","0",""},{"Less","ASL-Less","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4","0","0",""},{"Big","ASL-Big","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4","0","0",""},{"Small/A Little","ASL-Small","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4","0","0",""},{"Full","ASL-Full","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4","0","0",""},{"Empty","ASL-Empty","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4","0","0",""},{"Half","ASL-Half","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4","0","0",""},{"Quarter","ASL-Quarter","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4","0","0",""},{"Long","ASL-Long","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4","0","0",""},{"Short (Time)","ASL-Short (Time)","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4","0","0",""},{"A Lot/Many","ASL-A Lot/Many","Placeholder.","","0","0",""},{"Unlimited","ASL-Unlimited","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4","0","0",""},{"Limited","ASL-Limited","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4","0","0",""},{"All","ASL-All","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","0","0",""},{"Nothing","ASL-Nothing","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4","0","0",""},{"Ever","ASL-Ever","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4","0","0",""},{"Everything","ASL-Everything","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4","0","0",""},{"Everytime","ASL-Everytime","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4","0","0",""},{"Always","ASL-Always","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4","0","0",""},{"Often","ASL-Often","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4","0","0",""},{"Sometimes","ASL-Sometimes","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4","0","0",""},{"Heavy","ASL-Heavy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4","0","0",""},{"Lightweight","ASL-Lightweight","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4","0","0",""},{"Hard","ASL-Hard","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4","0","0",""},{"Soft","ASL-Soft","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4","0","0",""},{"Strong","ASL-Strong","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4","0","0",""},{"Weak","ASL-Weak","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4","0","0",""},{"First","ASL-First","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4","0","0",""},{"Second","ASL-Second","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4","0","0",""},{"Third","ASL-Third","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4","0","0",""},{"Next","ASL-Next","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4","0","0",""},{"Last","ASL-Last","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4","0","0",""},{"Before","ASL-Before","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4","0","0",""},{"After","ASL-After","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4","0","0",""},{"Busy","ASL-Busy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4","0","0",""},{"Free","ASL-Free","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4","0","0","Signed Exact English variant"},{"High","ASL-High","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4","0","0",""},{"Low","ASL-Low","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4","0","0",""},{"Fat","ASL-Fat","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4","0","0",""},{"Thin","ASL-Thin","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4","0","0",""},{"Value","ASL-Value","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4","0","0",""}},
new string[,]{//Lesson 7 (Time)
{"Time","ASL-Time","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4","0","0",""},{"Year","ASL-Year","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4","0","0",""},{"Season","ASL-Season","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4","0","0",""},{"Month","ASL-Month","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4","0","0",""},{"Week","ASL-Week","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4","0","0",""},{"Day","ASL-Day","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4","0","0",""},{"Weekend","ASL-Weekend","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4","0","0",""},{"Hours","ASL-Hours","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4","0","0",""},{"Minutes","ASL-Minutes","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4","0","0",""},{"Seconds","ASL-Seconds","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4","0","0",""},{"Today","ASL-Today","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4","0","0",""},{"Tomorrow","ASL-Tomorrow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4","0","0",""},{"Yesterday","ASL-Yesterday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4","0","0",""},{"Morning","ASL-Morning","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4","0","0",""},{"Afternoon","ASL-Afternoon","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4","0","0",""},{"Evening","ASL-Evening","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4","0","0",""},{"Night","ASL-Night","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4","0","0",""},{"Sunrise","ASL-Sunrise","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4","0","0",""},{"Sunset","ASL-Sunset","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4","0","0",""},{"All Night","ASL-All Night","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","0","0",""},{"All Day","ASL-All Day","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","0","0",""},{"Sunday","ASL-Sunday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4","0","0",""},{"Monday","ASL-Monday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4","0","0",""},{"Tuesday","ASL-Tuesday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4","0","0",""},{"Wednesday","ASL-Wednesday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4","0","0",""},{"Thursday","ASL-Thursday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4","0","0",""},{"Friday","ASL-Friday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4","0","0",""},{"Saturday","ASL-Saturday","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4","0","0",""},{"Autumn","ASL-Autumn","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4","0","0",""},{"Winter","ASL-Winter","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4","0","0",""},{"Spring","ASL-Spring","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4","0","0",""},{"Summer","ASL-Summer","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4","0","0",""},{"Now","ASL-Now","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4","0","0",""},{"Never","ASL-Never","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4","0","0",""},{"Soon","ASL-Soon","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4","0","0",""},{"Later","ASL-Later","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4","0","0",""},{"Past","ASL-Past","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4","0","0",""},{"Future","ASL-Future","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4","0","0",""},{"Earlier","ASL-Earlier","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4","0","0",""},{"Midweek","ASL-Midweek","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4","0","0",""},{"Next Week","ASL-Next Week","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4","0","0",""}},
new string[,]{//Lesson 8 (VRChat)
{"Gestures","ASL-Gestures","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4","0","0",""},{"World","ASL-World","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4","1","2",""},{"Record","ASL-Record","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4","0","0",""},{"Discord","ASL-Discord","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4","1","0",""},{"Streaming","ASL-Streaming","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4","0","0",""},{"Headset (VR)","ASL-Headset (VR)","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4","1","2",""},{"Desktop","ASL-Desktop","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4","0","0",""},{"Computer","ASL-Computer","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4","0","0",""},{"Instance","ASL-Instance","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4","0","0",""},{"Public","ASL-Public","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4","0","0",""},{"Invite","ASL-Invite","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4","0","0",""},{"Private","ASL-Private","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4","0","0",""},{"Add Friend","ASL-Add Friend","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4","0","0",""},{"Menu","ASL-Menu","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4","0","0",""},{"Recharge","ASL-Recharge","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4","0","0",""},{"Visit","ASL-Visit","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4","0","0",""},{"Request","ASL-Request","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4","0","0",""},{"Login","ASL-Login","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4","0","0",""},{"Logout","ASL-Logout","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4","0","0",""},{"Schedule","ASL-Schedule","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4","0","0",""},{"Event","ASL-Event","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4","0","0",""},{"Online","ASL-Online","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4","0","0",""},{"Offline","ASL-Offline","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4","0","0",""},{"Cancel","ASL-Cancel","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4","0","0",""},{"Portal","ASL-Portal","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4","1","2",""},{"Camera","ASL-Camera","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4","0","0",""},{"Avatar","ASL-Avatar","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4","1","2",""},{"Photo","ASL-Photo","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4","0","0",""},{"Join","ASL-Join","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4","0","0",""},{"Leave","ASL-Leave","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4","0","0",""},{"Climbing","ASL-Climbing","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4","0","0",""},{"Falling","ASL-Falling","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4","0","0",""},{"Walk","ASL-Walk","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4","0","0",""},{"Hide","ASL-Hide","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4","0","0",""},{"Block","ASL-Block","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4","0","0",""},{"Crash","ASL-Crash","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4","0","0",""},{"Lagging","ASL-Lagging","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4","1","2",""},{"Restart","ASL-Restart","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4","0","0",""},{"Send","ASL-Send","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4","0","0",""},{"Receive","ASL-Receive","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4","0","0",""},{"Security","ASL-Security","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4","0","0",""},{"Donation","ASL-Donation","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4","0","0",""}},
new string[,]{//Lesson 10 (Verbs & Actions p1)
{"Overlook","ASL-Overlook","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4","0","0",""},{"Punish","ASL-Punish","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4","0","0",""},{"Edit","ASL-Edit","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4","0","0",""},{"Erase","ASL-Erase","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4","0","0",""},{"Write","ASL-Write","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4","0","0",""},{"Proposal","ASL-Proposal","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4","0","0",""},{"Add","ASL-Add","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4","0","0",""},{"Remove","ASL-Remove","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4","0","0",""},{"Agree","ASL-Agree","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4","0","0",""},{"Disagree","ASL-Disagree","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4","0","0",""},{"Admit","ASL-Admit","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4","0","0",""},{"Allow","ASL-Allow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4","0","0",""},{"Attack","ASL-Attack","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4","0","0",""},{"Fight","ASL-Fight","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4","0","0",""},{"Defend","ASL-Defend","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4","0","0",""},{"Defeat (Overcome)","ASL-Defeat (Overcome)","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4","0","0",""},{"Win","ASL-Win","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4","0","0",""},{"Lose","ASL-Lose","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4","0","0",""},{"Draw (Game)","ASL-Draw (Game)","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4","0","0",""},{"Give up","ASL-Give up","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4","0","0",""},{"Skip","ASL-Skip","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4","0","0",""},{"Ask","ASL-Ask","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-22.mp4","0","0",""},{"Attach","ASL-Attach","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4","0","0",""},{"Assist","ASL-Assist","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4","0","0",""},{"Bait","ASL-Bait","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4","0","0",""},{"Battle","ASL-Battle","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4","0","0",""},{"Beat","ASL-Beat","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4","0","0",""},{"Become","ASL-Become","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4","0","0",""},{"Beg","ASL-Beg","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4","0","0",""},{"Begin","ASL-Begin","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4","0","0",""},{"Behave","ASL-Behave","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4","0","0",""},{"Believe","ASL-Believe","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4","0","0",""},{"Blame","ASL-Blame","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4","0","0",""},{"Blow","ASL-Blow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4","0","0",""},{"Blush","ASL-Blush","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4","0","0",""},{"Bother/Harass","ASL-Bother/Harass","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4","0","0",""}},
new string[,]{//Lesson 11 (Verbs & Actions p2)
{"Bend","ASL-Bend","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4","0","0",""},{"Bow","ASL-Bow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4","0","0",""},{"Break","ASL-Break","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4","0","0",""},{"Breathe","ASL-Breathe","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4","0","0",""},{"Bring","ASL-Bring","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4","0","0","(Directional Sign)"},{"Build/Construct","ASL-Build/Construct","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4","0","0",""},{"Bully","ASL-Bully","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4","0","0",""},{"Burn","ASL-Burn","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4","0","0",""},{"Buy","ASL-Buy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4","0","0",""},{"Call","ASL-Call","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4","0","0",""},{"Cancel","ASL-Cancel2","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4","0","0",""},{"Care","ASL-Care","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4","0","0",""},{"Carry","ASL-Carry","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4","0","0",""},{"Catch","ASL-Catch","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4","0","0",""},{"Cause","ASL-Cause","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4","0","0",""},{"Challenge","ASL-Challenge","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4","0","0",""},{"Chance","ASL-Chance","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4","0","0","C Handshape. This sign is the Signed Exact English variant."},{"Cheat","ASL-Cheat","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4","0","0",""},{"Check","ASL-Check","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4","0","0",""},{"Choose","ASL-Choose","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4","0","0",""},{"Claim","ASL-Claim","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4","0","0",""},{"Clean","ASL-Clean","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4","0","0",""},{"Clear","ASL-Clear","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4","0","0",""},{"Close","ASL-Close","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4","0","0","Close as in \"near\""},{"Comfort","ASL-Comfort","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4","0","0",""},{"Command","ASL-Command","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4","0","0",""},{"Communicate","ASL-Communicate","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4","0","0","This sign is the Signed Exact English variant."},{"Compare","ASL-Compare","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4","0","0",""},{"Complain","ASL-Complain","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4","0","0",""},{"Compliment","ASL-Compliment","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4","0","0",""},{"Concentrate","ASL-Concentrate","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4","0","0",""},{"Construct/Build","ASL-Construct/Build","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4","0","0",""},{"Control","ASL-Control","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4","0","0",""},{"Cook","ASL-Cook","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4","0","0",""},{"Copy","ASL-Copy","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4","0","0",""},{"Correct","ASL-Correct","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4","0","0",""}},
new string[,]{//Lesson 12 (Verbs & Actions p3)
{"Cough","ASL-Cough","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4","0","0",""},{"Count","ASL-Count","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4","0","0",""},{"Create","ASL-Create","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4","0","0",""},{"Cuddle","ASL-Cuddle","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4","0","0",""},{"Cut","ASL-Cut","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4","0","0",""},{"Dab","ASL-Dab","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4","0","0",""},{"Dance","ASL-Dance","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4","0","0",""},{"Dare","ASL-Dare","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4","0","0",""},{"Date","ASL-Date","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4","0","0",""},{"Deal","ASL-Deal","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4","0","0",""},{"Deliver","ASL-Deliver","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4","0","0",""},{"Depend","ASL-Depend","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4","0","0",""},{"Describe","ASL-Describe","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4","0","0",""},{"Dirty","ASL-Dirty","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4","0","0",""},{"Disappear","ASL-Disappear","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4","0","0",""},{"Disappoint","ASL-Disappoint","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4","0","0",""},{"Disapprove","ASL-Disapprove","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4","0","0",""},{"Discuss","ASL-Discuss","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4","0","0",""},{"Disguise","ASL-Disguise","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4","0","0",""},{"Disgust","ASL-Disgust","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4","0","0",""},{"Dismiss","ASL-Dismiss","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4","0","0",""},{"Disturb","ASL-Disturb","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4","0","0",""},{"Doubt","ASL-Doubt","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4","0","0",""},{"Dream","ASL-Dream","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4","0","0",""},{"Dress","ASL-Dress","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4","0","0",""},{"Drunk","ASL-Drunk","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4","0","0",""},{"Drop","ASL-Drop","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4","0","0",""},{"Drown","ASL-Drown","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4","0","0",""},{"Dry","ASL-Dry","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4","0","0",""},{"Dump","ASL-Dump","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4","0","0",""},{"Dust","ASL-Dust","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4","0","0",""},{"Earn","ASL-Earn","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4","0","0",""},{"Effect","ASL-Effect","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4","0","0",""},{"End","ASL-End","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4","0","0",""},{"Escape","ASL-Escape","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4","0","0",""},{"Escort","ASL-Escort","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4","0","0",""}},
new string[,]{//Lesson 13 (Verbs & Actions p4)
{"Excuse","ASL-Excuse","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4","0","0",""},{"Expose","ASL-Expose","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4","0","0",""},{"Exist","ASL-Exist","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4","0","0",""},{"Fail","ASL-Fail","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4","0","0",""},{"Faint","ASL-Faint","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4","0","0",""},{"Fake","ASL-Fake","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4","0","0",""},{"Fart","ASL-Fart","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4","0","0",""},{"Fear","ASL-Fear","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4","0","0",""},{"Fill","ASL-Fill","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4","0","0",""},{"Find","ASL-Find","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4","0","0",""},{"Finish","ASL-Finish","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4","0","0",""},{"Fix","ASL-Fix","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4","0","0",""},{"Flip","ASL-Flip","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4","0","0",""},{"Flirt","ASL-Flirt","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4","0","0",""},{"Fly","ASL-Fly","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4","0","0",""},{"Forbid","ASL-Forbid","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4","0","0",""},{"Forgive","ASL-Forgive","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4","0","0",""},{"Gain","ASL-Gain","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4","0","0",""},{"Give","ASL-Give","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4","0","0",""},{"Glow","ASL-Glow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4","0","0",""},{"Grab","ASL-Grab","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4","0","0",""},{"Grow","ASL-Grow","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4","0","0",""},{"Guard","ASL-Guard","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4","0","0",""},{"Guess","ASL-Guess","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4","0","0",""},{"Guide","ASL-Guide","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4","0","0",""},{"Harass/Bother","ASL-Harass/Bother","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4","0","0",""},{"Harm","ASL-Harm","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4","0","0",""},{"Hit","ASL-Hit","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4","0","0",""},{"Hold","ASL-Hold","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4","0","0",""},{"Hop","ASL-Hop","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4","0","0",""},{"Hope","ASL-Hope","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4","0","0",""},{"Hunt","ASL-Hunt","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4","0","0",""},{"Ignore","ASL-Ignore","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4","0","0",""},{"Imagine","ASL-Imagine","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4","0","0",""},{"Imitate","ASL-Imitate","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4","0","0",""},{"Insult","ASL-Insult","Placeholder.","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4","0","0",""}},
new string[,]{//Lesson 14 (Verbs & Actions p5)
{"Interact","ASL-Interact","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4","0","0",""},{"Interfere","ASL-Interfere","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4","0","0",""},{"Judge","ASL-Judge","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4","0","0",""},{"Jump","ASL-Jump","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4","0","0",""},{"Justify","ASL-Justify","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4","0","0",""},{"Just kidding","ASL-Just kidding","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4","0","0",""},{"Keep","ASL-Keep","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4","0","0",""},{"Kick","ASL-Kick","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4","0","0",""},{"Kill","ASL-Kill","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4","0","0",""},{"Knock","ASL-Knock","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4","0","0",""},{"Lead","ASL-Lead","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4","0","0",""},{"Lick","ASL-Lick","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4","0","0",""},{"Lock","ASL-Lock","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4","0","0",""},{"Manipulate","ASL-Manipulate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4","0","0",""},{"Melt","ASL-Melt","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4","0","0",""},{"Mess","ASL-Mess","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4","0","0",""},{"Miss","ASL-Miss","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4","0","0",""},{"Mistake","ASL-Mistake","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4","0","0",""},{"Mount","ASL-Mount","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4","0","0",""},{"Move","ASL-Move","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4","0","0",""},{"Murder","ASL-Murder","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4","0","0",""},{"Nod","ASL-Nod","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4","0","0",""},{"Note","ASL-Note","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4","0","0",""},{"Notice","ASL-Notice","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4","0","0",""},{"Obey","ASL-Obey","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4","0","0",""},{"Obsess","ASL-Obsess","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4","0","0",""},{"Obtain","ASL-Obtain","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4","0","0",""},{"Occupy","ASL-Occupy","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4","0","0",""},{"Offend","ASL-Offend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4","0","0",""},{"Offer","ASL-Offer","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4","0","0",""},{"Okay","ASL-Okay","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4","0","0",""},{"Open","ASL-Open","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4","0","0",""},{"Order","ASL-Order","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4","0","0",""},{"Owe","ASL-Owe","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4","0","0",""},{"Own","ASL-Own","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4","0","0",""},{"Pass","ASL-Pass","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4","0","0",""}},
new string[,]{//Lesson 15 (Verbs & Actions p6)
{"Pat","ASL-Pat","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4","0","0",""},{"Party","ASL-Party","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4","0","0",""},{"Pet","ASL-Pet","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4","0","0",""},{"Pick","ASL-Pick","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4","0","0",""},{"Plug","ASL-Plug","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4","0","0",""},{"Point","ASL-Point","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4","0","0",""},{"Poke","ASL-Poke","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4","0","0",""},{"Pray","ASL-Pray","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4","0","0",""},{"Prepare","ASL-Prepare","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4","0","0",""},{"Present","ASL-Present","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4","0","0",""},{"Pretend","ASL-Pretend","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4","0","0",""},{"Protect","ASL-Protect","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4","0","0",""},{"Prove","ASL-Prove","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4","0","0",""},{"Publish","ASL-Publish","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4","0","0",""},{"Puke","ASL-Puke","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","0","0",""},{"Pull","ASL-Pull","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4","0","0",""},{"Punch","ASL-Punch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4","0","0",""},{"Put","ASL-Put","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4","0","0",""},{"Push","ASL-Push","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4","0","0",""},{"Question","ASL-Question","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","0","0",""},{"Quit","ASL-Quit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4","0","0",""},{"Quote","ASL-Quote","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4","0","0",""},{"Race","ASL-Race","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4","0","0",""},{"React","ASL-React","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4","0","0",""},{"Recommended","ASL-Recommended","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4","0","0",""},{"Refuse","ASL-Refuse","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4","0","0",""},{"Regret","ASL-Regret","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4","0","0",""},{"Remember","ASL-Remember","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4","0","0",""},{"Replace","ASL-Replace","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4","0","0",""},{"Report","ASL-Report","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4","0","0",""},{"Reset","ASL-Reset","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4","0","0",""},{"Ride","ASL-Ride","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4","0","0",""},{"Rub","ASL-Rub","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4","0","0",""},{"Rule","ASL-Rule","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4","0","0",""},{"Run","ASL-Run","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4","0","0",""},{"Save","ASL-Save","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4","0","0",""}},
new string[,]{//Lesson 16 (Verbs & Actions p7)
{"Say","ASL-Say","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4","0","0",""},{"Search","ASL-Search","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4","0","0",""},{"See","ASL-See","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4","0","0",""},{"Share","ASL-Share","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4","0","0",""},{"Shock","ASL-Shock","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4","0","0",""},{"Shop","ASL-Shop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4","0","0",""},{"Show","ASL-Show","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4","0","0",""},{"Shut up","ASL-Shut up","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4","0","0",""},{"Shut down","ASL-Shut down","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4","0","0",""},{"Sing","ASL-Sing","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4","0","0",""},{"Sit","ASL-Sit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4","0","0",""},{"Smell","ASL-Smell","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4","0","0",""},{"Smile","ASL-Smile","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4","0","0",""},{"Smoke","ASL-Smoke","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4","0","0",""},{"Speak","ASL-Speak","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4","0","0",""},{"Spell","ASL-Spell","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0","0",""},{"Spit","ASL-Spit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4","0","0",""},{"Stand","ASL-Stand","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4","0","0",""},{"Start","ASL-Start","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4","0","0",""},{"Stay","ASL-Stay","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4","0","0",""},{"Steal","ASL-Steal","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4","0","0",""},{"Stop","ASL-Stop","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4","0","0",""},{"Study","ASL-Study","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4","0","0",""},{"Suffer","ASL-Suffer","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4","0","0",""},{"Swim","ASL-Swim","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4","0","0",""},{"Switch","ASL-Switch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4","0","0",""},{"Take","ASL-Take","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4","0","0",""},{"Talk","ASL-Talk","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4","0","0",""},{"Tell","ASL-Tell","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4","0","0",""},{"Test","ASL-Test","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4","0","0",""},{"Text","ASL-Text","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4","0","0",""},{"Think","ASL-Think","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4","0","0",""},{"Throw","ASL-Throw","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4","0","0",""},{"Tie","ASL-Tie","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4","0","0",""},{"Truth","ASL-Truth","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4","0","0",""},{"Try","ASL-Try","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4","0","0",""}
}};


    //string [][][,] AllLessons = { ASLlessons, BSLlessons }; //if multi-languages are ever implimented
    string [][][,] AllLessons = { ASLlessons}; //adds array of arrays into another array for easy looping.

	string [] lessonnames = new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language.
	"Alphabet (Fingerspelling)","Numbers","Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Verbs & Actions p1","Verbs & Actions p2","Verbs & Actions p3",
	"Verbs & Actions p4","Verbs & Actions p5","Verbs & Actions p6","Verbs & Actions p7","Verbs & Actions p8","Food","Animals / Machines","Places","Stuff / Weather","Clothes / Equipment","Fantasy / Characters",
	"Holidays / Special Days","Home stuff","Nature / Environment","Talk / Asking exercises","Name sign users","Countries","Colors","Medical"};
	string [,] signlanguagenames = new string[,]{{"ASL","American Sign Language"},{"BSL","British Sign Language"}};


	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None;

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
	int menusizex = 4900;
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

/*****************************************
START OF PROGRAM
*****************************************/

GameObject menuroot = new GameObject(mode +" Menu Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
menuroot.transform.position = menurootposition;
menuroot.transform.SetParent(parent.transform, false);
menuroot.layer = layer;
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
			GameObject langvideocontainer = new GameObject(signlanguagenames[languagenum,0]+" Video Container");
			langvideocontainer.transform.position = new Vector3(0, 0, 0);
			langvideocontainer.transform.SetParent(videocontainer.transform, false);
			langvideocontainer.layer = layer;

			//create a root gameobject for each language
			GameObject langroot = new GameObject(signlanguagenames[languagenum,0]+" Root"); //creates language container for a given language.
			langroot.transform.SetParent(rootcanvas.transform, false);
			langroot.layer = layer;
			//Debug.Log(signlanguages.Length + " " +languages);

			//create language select button
			GameObject langselectgo = createbutton2(parent:langselectmenu, name:signlanguagenames[languagenum,1], sizedelta:buttonsize,
            anchoredPosition: new Vector2(columnoffset+(languagenum*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(languagenum*rowseperation)),
            text: signlanguagenames[languagenum,1], fontSize:50, txtsizedelta:buttonsize, txtanchoredPosition:new Vector2(20,0),
            alignment:TextAnchor.MiddleLeft, nav:no_nav, layer:layer);

				//Create lesson sub-menu for nested loop to parent buttons to.
				GameObject lessonmenu = new GameObject(signlanguagenames[languagenum,0]+" Lesson Menu");
				lessonmenu.transform.SetParent(langroot.transform, false);
				lessonmenu.layer = layer;
					//Create lesson menu header
					GameObject lessonselectmenuheader = DefaultControls.CreateText(txtresources);
					lessonselectmenuheader.transform.SetParent (lessonmenu.transform, false);
					lessonselectmenuheader.name=signlanguagenames[languagenum,0]+" Lesson Menu Header";
					lessonselectmenuheader.layer = layer;
					lessonselectmenuheader.GetComponent<Text> ().text = "VR-"+signlanguagenames[languagenum,0]+" Sign Language - Lesson Menu (Green = contains \"verified\" motion data.) (Yellow = contains \"Unverified\" motion data and verified videos) (Red = no motion data, but contains verified videos) - "+mode;
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

				if (lessonnum != 0){
					if (lessonnum % numberpercolumn == 0){ //display 9 items per column
					menucolumn++;
					menurow=0;
					}
				}
				//Debug.Log(" menusizey="+menusizey+" headersizey="+headersizey+" textpadding="+textpadding+" buttonsizey="+buttonsizey+" menurow="+menurow+" rowseperation="+rowseperation+" menusizey-headersizey-textpadding-buttonsizex-(menurow*rowseperation)="+(menusizey-headersizey-textpadding-buttonsizex-(menurow*rowseperation)));
					//create lesson menu button here for lessonmenu.-one at a time
					GameObject lessonbgo = createbutton2(parent:lessonmenu, name:signlanguagenames[languagenum,0]+" L"+(lessonnum+1)+"("+lessonnames[lessonnum]+") - Button", sizedelta:buttonsize,
					//anchoredPosition: new Vector2(columnoffset+(menucolumn*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(menurow*rowseperation)),
					anchoredPosition: new Vector2(columnoffset+(menucolumn*columnseperation), menusizey-headersizey-textpadding-buttonsizey-headerbuttonspacing-(menurow*rowseperation)),
					text: (lessonnum+1)+ ") " + lessonnames[lessonnum], fontSize:50, txtsizedelta:buttonsize, txtanchoredPosition:new Vector2(20,0),
					alignment:TextAnchor.MiddleLeft, nav:no_nav, layer:layer);
					Button b = lessonbgo.GetOrAddComponent<Button>();
					b.onClick = new Button.ButtonClickedEvent();
					//colors the buttons to indicate what's working and what's not.
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


					menurow++;
					//create lesson x gameobject eg: ASL Lesson x
					GameObject lessongo = new GameObject(signlanguagenames[languagenum,0]+" Lesson "+(lessonnum+1));
					lessongo.transform.SetParent(langroot.transform, false);
					lessongo.layer = layer;
					
					//create lesson x header
					GameObject lessongoheader = DefaultControls.CreateText(txtresources);
					lessongoheader.transform.SetParent (lessongo.transform, false);
					lessongoheader.name=signlanguagenames[languagenum,0]+" Lesson "+(lessonnum+1) + "- Header"; //ASL Lesson X Lesson Header
					lessongoheader.layer = layer;
					lessongoheader.GetComponent<Text> ().text = "VR-"+signlanguagenames[languagenum,0]+" Sign Language - Lesson " + (lessonnum+1) + " - " + lessonnames[lessonnum]+" - "+mode;
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
					GameObject videolessoncontainer = new GameObject(signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1));
					videolessoncontainer.transform.SetParent(langvideocontainer.transform, false);
					videolessoncontainer.layer=layer;


if(mode=="Global"){

					VRC_Trigger lessonbuttonvrctrigger = lessonbgo.AddComponent<VRC_Trigger>();
					


					lessonbuttonvrctrigger.Triggers=new List<VRC_Trigger.TriggerEvent>(){
						new VRC_Trigger.TriggerEvent{
							BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
							TriggerType = VRC_Trigger.TriggerType.Custom,
							TriggerIndividuals = true,
							Name="globaltrigger",
							Events=new List<VRC_EventHandler.VrcEvent>(){
								new VRC_EventHandler.VrcEvent{
									EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
									ParameterObject=lessonbgo,
									ParameterString="localtrigger",
								}
							}
						},
						new VRC_Trigger.TriggerEvent{
							BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
							Name="localtrigger",
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
					};


			
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
                    for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].GetLength(0); wordnum++){ //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.
						if (wordnum != 0){
							if (wordnum % numberpercolumn == 0){ //display 9 items per column
								wordcolumn++;
								wordrow=0;
							}
						}

					if(mode=="Global"){
					GameObject buttonoffgo=createbutton2(parent=lessongo, name:signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off",
					sizedelta:buttonsize,anchoredPosition:new Vector2 (columnoffset +(wordcolumn*columnseperation),(menusizey-headersizey-textpadding-buttonsizey-100-(wordrow*rowseperation))),
					text:"          "+ (wordnum+1)+ ") " + AllLessons[languagenum][lessonnum][wordnum,0],txtsizedelta:new Vector2 (750, 100),txtanchoredPosition:new Vector2 (32,0), alignment:TextAnchor.MiddleLeft,
					nav:no_nav,layer:layer);
//Don't forget to create the "selected" button with checkmark

					switch (AllLessons[languagenum][lessonnum][wordnum,4])
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
					//5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
					switch (AllLessons[languagenum][lessonnum][wordnum,5])
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
					

					if(AllLessons[languagenum][lessonnum][wordnum,2]=="No Data Yet."){//If no data yet, stop playing the existing shit.
						buttontriggers.Triggers=new List<VRC_Trigger.TriggerEvent>(){
							new VRC_Trigger.TriggerEvent{
								BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
								Name="localtrigger",
								TriggerType = VRC_Trigger.TriggerType.Custom,
								TriggerIndividuals = true,
								Events=new List<VRC_EventHandler.VrcEvent>(){
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,
										ParameterObject=GameObject.Find ("/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=-1,
									},
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationTrigger,
										ParameterObject=GameObject.Find ("/Nana Avatar"),
										ParameterString="Idle"
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "No Data Yet",
										ParameterObject = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum,0],
										ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum,2],
										ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum,6],
										ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text")
									}

								}
							}
						};
					}
					else{
						buttontriggers.Triggers=new List<VRC_Trigger.TriggerEvent>(){
							new VRC_Trigger.TriggerEvent{
								BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
								Name="localtrigger",
								TriggerType = VRC_Trigger.TriggerType.Custom,
								TriggerIndividuals = true,
								Events=new List<VRC_EventHandler.VrcEvent>(){
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationInt,//maybe I should use animation intergers... less of a pain in the add to disable.
										ParameterObject=GameObject.Find ("/Nana Avatar"),
										ParameterString="sign",
										ParameterInt=int.Parse("1"+string.Format("{0:D2}",lessonnum+1)+string.Format("{0:D2}",wordnum+1))
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum,0],
										ParameterObject = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = (lessonnum+1)+"-"+(wordnum+1)+": "+AllLessons[languagenum][lessonnum][wordnum,0],
										ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = "This sign was recorded by: " + AllLessons[languagenum][lessonnum][wordnum,2],
										ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text")
									},
									new VRC_EventHandler.VrcEvent{
										EventType = VRC_EventHandler.VrcEventType.SetUIText,
										ParameterString = AllLessons[languagenum][lessonnum][wordnum,6],
										ParameterObject = GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text")
									}
								}
							}
						}; 
					}//end else
					if(AllLessons[languagenum][lessonnum][wordnum,3]!=""){ //if url is blank, then don't create video.
						//creates the video gameobjects
						GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
						videogo.name=signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
						videogo.layer = layer;
						videogo.transform.SetParent(videolessoncontainer.transform, false);
						videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat",typeof(Material));
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url=AllLessons[languagenum][lessonnum][wordnum,3];
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping=true;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode=VideoRenderMode.MaterialOverride;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode=VideoAudioOutputMode.None;
						videogo.SetActive(false);
						buttontriggers.Triggers[0].Events.Add(//there should only be one trigger to add events to on this list.					
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
			UnityEventTools.AddStringPersistentListener(buttonoffbutton.onClick, worduiaction,"globaltrigger");

			buttontriggers.Triggers.Add(
				new VRC_Trigger.TriggerEvent{
					BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
					TriggerType = VRC_Trigger.TriggerType.Custom,
					TriggerIndividuals = true,
					Name="globaltrigger",
					Events=new List<VRC_EventHandler.VrcEvent>(){
						new VRC_EventHandler.VrcEvent{
							EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
							ParameterObject=buttonoffgo,
							ParameterString="localtrigger",
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
					uiToggle.gameObject.name = signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Toggle";				
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

					uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().text ="          "+ (wordnum+1)+ ") " + AllLessons[languagenum][lessonnum][wordnum,0];
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
					switch (AllLessons[languagenum][lessonnum][wordnum,4])
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
					//5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
					switch (AllLessons[languagenum][lessonnum][wordnum,5])
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
					if(AllLessons[languagenum][lessonnum][wordnum,3]!=""){ //if url is blank, then don't create video.

						//creates the video gameobjects
						GameObject videogo = GameObject.CreatePrimitive(PrimitiveType.Quad);
						videogo.name=signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1) +" S"+(wordnum+1);
						videogo.layer = layer;
						videogo.transform.SetParent(videolessoncontainer.transform, false);
						videogo.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Sample Assets/Materials/Screen.mat",typeof(Material));
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url=AllLessons[languagenum][lessonnum][wordnum,3];
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping=true;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode=VideoRenderMode.MaterialOverride;
						videogo.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode=VideoAudioOutputMode.None;
						videogo.SetActive(false);
						UnityEventTools.AddPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videogo//the target of the action
						, "set_active") as UnityAction<bool>);
						}
						
					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Nana Avatar").GetComponent<Animator>()//the target of the action
					, "Play") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum,1]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum,0]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum,2]);

					UnityEventTools.AddStringPersistentListener(t.onValueChanged, //the button/toggle that triggers the action
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text").GetComponent<Text>()//the target of the action
					, "set_text") as UnityAction<string>,AllLessons[languagenum][lessonnum][wordnum,6]);







					wordrow++;
}
                    } //end local
					/*****************************************
					End of word loop.
					*****************************************/

					/*
			if(mode=="Global"){	
				//I need another loop to add all the triggers to deactivate videos for global mode
				//these triggers belong on the helper gameobjects.
					for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].GetLength(0); wordnum++){ //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.
Button wordtoggle = GameObject.Find(mode+" Menu Root/"+mode+" Root Canvas/"+signlanguagenames[languagenum,0]+" Root/"+signlanguagenames[languagenum,0]+" Lesson " +(lessonnum+1)+"/"
+signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off").GetComponent<Button>();
					//i need another for loop to add every single video gameobject EXCEPT the current word.
						for(int x=0;x<AllLessons[languagenum][lessonnum].GetLength(0); x++){
							if(x!=wordnum){//exclude the one I want to play- build list of all others in the lesson.
							GameObject a = GameObject.Find(mode+" Menu Root/"+mode+" Video Container/"+signlanguagenames[languagenum,0]+" Video Container/"+
								signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1)+"/"+signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1) +" S"+(x+1));
								if(a)
								{//if it's not null then add it
									UnityEventTools.AddBoolPersistentListener(wordtoggle.onClick, //the button/toggle that triggers the action
									System.Delegate.CreateDelegate(typeof(UnityAction<bool>), a//the target of the action
									, "SetActive") as UnityAction<bool>, false);
								}//end null check
							}//end exclusion loop
						}//end for loop
					}; //end for loop
				}//end local check
*/
				if(mode=="Global"){
				//I need another loop to add all the triggers to deactivate videos for global mode
				//these triggers belong on the helper gameobjects.
					for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].GetLength(0); wordnum++){ //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.
					List<GameObject> listofvideos = new List<GameObject>();
					//i need another for loop to add every single video gameobject EXCEPT the current word.
						for(int x=0;x<AllLessons[languagenum][lessonnum].GetLength(0); x++){
							if(x!=wordnum){//exclude the one I want to play- build list of all others in the lesson.
								if(GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Video Container/"+signlanguagenames[languagenum,0]+" Video Container/"+
								signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1)+"/"+
								signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1) +" S"+(x+1))){//if it's not null then add it
									listofvideos.Add(GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Video Container/"+signlanguagenames[languagenum,0]+" Video Container/"+
									signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1)+"/"+
									signlanguagenames[languagenum,0]+" Video L"+(lessonnum+1) +" S"+(x+1)));
								}
								//add disable triggers to non-selected animators
							GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Root Canvas/" +signlanguagenames[languagenum,0]+ " Root/"+ signlanguagenames[languagenum,0] + " Lesson " + (lessonnum+1)+"/"+
							signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off").
							GetComponent<VRC_Trigger>().Triggers[0].Events.Add(
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationBool,
										ParameterObject=GameObject.Find ("/Nana Avatar"),
										ParameterString=AllLessons[languagenum][lessonnum][x,1],
										ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
									}
								);
							}//end exclusion loop
						}//end for loop
							//disables nonselected videos
							GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Root Canvas/" +signlanguagenames[languagenum,0]+ " Root/"+ signlanguagenames[languagenum,0] + " Lesson " + (lessonnum+1)+"/"+
							signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off").
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
				GameObject backtolessongo = createbutton2(parent:lessongo, name:"Return to VR-" + signlanguagenames[languagenum,0] + " Lesson Menu", sizedelta:backbuttonsize,
				anchoredPosition: new Vector2(buttonsizey, 0),
				text: "Return to VR-" + signlanguagenames[languagenum,0] + " Lesson Menu", fontSize:50, txtsizedelta:backbuttonsize, txtanchoredPosition:new Vector2(20,0), 
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
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Nana Avatar").GetComponent<Animator>()//the target of the action
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
							BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
							TriggerType = VRC_Trigger.TriggerType.Custom,
							TriggerIndividuals = true,
							Name="globaltrigger",
							Events=new List<VRC_EventHandler.VrcEvent>(){
								new VRC_EventHandler.VrcEvent{
									EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
									ParameterObject=backtolessongo,
									ParameterString="localtrigger",
								}
							}
						},
						new VRC_Trigger.TriggerEvent{
							BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
							Name="localtrigger",
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
								}
							}
						}
					};
/*
					List<GameObject> listofvideos = new List<GameObject>();
					for (int wordnum = 0; wordnum < AllLessons[languagenum][lessonnum].GetLength(0); wordnum++){ //gets total rows in lesson. getlength(1) gets total columns, which is unneeded since we're using both columns at once.
						GameObject.Find("/Menu Root/"+mode+" Menu Root/"+mode+" Root Canvas/" +signlanguagenames[languagenum,0]+ " Root/"+ signlanguagenames[languagenum,0] + " Lesson " + (lessonnum+1)+"/"+
						signlanguagenames[languagenum,0]+" " + (lessonnum+1) + "-" + (wordnum+1) +" - Button Off").
						GetComponent<VRC_Trigger>().Triggers[1].Events.Add(
									new VRC_EventHandler.VrcEvent{
										EventType=VRC_EventHandler.VrcEventType.AnimationBool,
										ParameterObject=GameObject.Find ("/Nana Avatar"),
										ParameterString=AllLessons[languagenum][lessonnum][wordnum,1],
										ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.False
									}
								);
							}
							*/

					UnityEventTools.AddStringPersistentListener(backbutton.onClick, 
					System.Delegate.CreateDelegate(typeof(UnityAction<string>), vrcbacktolessontrigger,"ExecuteCustomTrigger") as UnityAction<string>,
					"globaltrigger");
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
			UnityAction<bool> enableaslroot = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum,0]+" Root"), "SetActive") as UnityAction<bool>;
			UnityEventTools.AddBoolPersistentListener(langselectbutton.onClick, enableaslroot, true);

			UnityAction<bool> enableaslmenuselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguagenames[languagenum,0]+" Lesson Menu"), "SetActive") as UnityAction<bool>;//GameObject.Find("Menu Root/Root Canvas/ASL Root/ASL Lesson Menu")
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
						BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
						TriggerType = VRC_Trigger.TriggerType.Custom,
						TriggerIndividuals = true,
						Name="globaltrigger",
						Events=new List<VRC_EventHandler.VrcEvent>(){
							new VRC_EventHandler.VrcEvent{
								EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
								ParameterObject=langselectgo,
								ParameterString="localtrigger",
							}
						}
					},
					new VRC_Trigger.TriggerEvent{
						BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
						Name="localtrigger",
						TriggerType = VRC_Trigger.TriggerType.Custom,
						TriggerIndividuals = true,
						Events=new List<VRC_EventHandler.VrcEvent>(){
							new VRC_EventHandler.VrcEvent{
								EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
								ParameterObject=FindInActiveObjectByName(signlanguagenames[languagenum,0]+" Root"),
								ParameterBoolOp=VRC_EventHandler.VrcBooleanOp.True
							},
							new VRC_EventHandler.VrcEvent{
								EventType=VRC_EventHandler.VrcEventType.SetGameObjectActive,
								ParameterObject=FindInActiveObjectByName(signlanguagenames[languagenum,0]+" Lesson Menu"),
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
				};
				UnityEventTools.AddStringPersistentListener(langselectbutton.onClick, 
				System.Delegate.CreateDelegate(typeof(UnityAction<string>), vrclangselecttrigger,"ExecuteCustomTrigger") as UnityAction<string>,
				"globaltrigger");
			}
			


			//Create return to Language Menu
			GameObject backtolanguagemenu = createbutton2(parent:lessonmenu, name:"Return to Language Menu", sizedelta:backbuttonsize,
			anchoredPosition: new Vector2(buttonsizey, 0),
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
						BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne,
						TriggerType = VRC_Trigger.TriggerType.Custom,
						TriggerIndividuals = true,
						Name="globaltrigger",
						Events=new List<VRC_EventHandler.VrcEvent>(){
							new VRC_EventHandler.VrcEvent{
								EventType=VRC_EventHandler.VrcEventType.ActivateCustomTrigger,
								ParameterObject=backtolanguagemenu,
								ParameterString="localtrigger",
							}
						}
					},
					new VRC_Trigger.TriggerEvent{
						BroadcastType = VRC_EventHandler.VrcBroadcastType.Local,
						Name="localtrigger",
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
				};


				//UnityAction<string> disablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<string>), backtolanguagemenu,"ExecuteCustomTrigger") as UnityAction<string>;
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


/*
	Toggle oldglobaltoggle = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Global Mode").GetOrAddComponent<Toggle>();
	DestroyImmediate(oldglobaltoggle);
	Toggle newglobaltoggle = GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Global Mode").GetOrAddComponent<Toggle>();
	newglobaltoggle.navigation = no_nav;
	newglobaltoggle.isOn = false;
	newglobaltoggle.graphic=newglobaltoggle.transform.Find("Background").gameObject.transform.Find("Checkmark").GetComponent<Image>();
	newglobaltoggle.transition= Selectable.Transition.None;
	newglobaltoggle.toggleTransition= Toggle.ToggleTransition.None;
	newglobaltoggle.onValueChanged = new Toggle.ToggleEvent();
	UnityEventTools.AddPersistentListener(newglobaltoggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find("/Preferencesv2/Preferencesv2 Canvas/Left Panel/Global Helper"), "SetActive") as UnityAction<bool>);
	//UnityEventTools.AddPersistentListener(newglobaltoggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), localtriggercontainer, "SetActive") as UnityAction<bool>);
*/
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
static GameObject createbutton2(GameObject parent, string name,Vector2 sizedelta,Vector2 anchoredPosition,
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
#endif