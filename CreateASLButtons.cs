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

public class CreateASLButtons : MonoBehaviour {
	[MenuItem("ASLWorld/CreateGameObjects")]
	static void CreateGameObjects()
	{
		//Declare some variables + settings.
		Animator nanaanimator = GameObject.Find ("/Nana Avatar").GetComponent<Animator> (); //finds target avatar animator for mocap signs

	string [][,] ASLlessons = { //creates an array of arrays
		new string[,]{//lesson 1 (Daily Use) creates a multidimentional array. First value displays what you want to show on the UI, the 2nd is the name of the person recording mocap.
			{"Hello","GT4tube"},{"How are you","GT4tube"},{"What's up?","GT4tube"},{"Nice to meet you","GT4tube"},{"Good","GT4tube"},
			{"Bad","GT4tube"},{"Yes","GT4tube"},{"No","GT4tube"},{"So-So","GT4tube"},{"Sick","Bob64"},
			{"Hurt","Bob64"},{"You're welcome","Bob64"},{"Good bye","Bob64"},{"Good morning","Bob64"},{"Good afternoon","Bob64"},{"Good evening","Bob64"},{"Good night","Bob64"},
			{"See you later","Bob64"},{"Please","Bob64"},{"Sorry","Bob64"},{"Forgotten","Bob64"},{"Sleep","Bob64"},{"Bed","Bob64"},{"Jump/Change world","Bob64"},{"Thank you","Bob64"},
			{"I love you","Bob64"},{"Go away","Bob64"},{"Going to","Bob64"},{"Follow","Bob64"},{"Come","Bob64"},{"Hearing","Bob64"},{"Deaf","Bob64"},{"Hard of Hearing","Bob64"},
			{"Mute","Bob64"},{"Write slow","Bob64"},{"Cannot read","Bob64"}},
		new string[,]{//lesson 2 (Pointing Use Question/Answer) creates a multidimentional array. First value displays what you want to show on the UI, the 2nd is the name of the person recording mocap.
			{"I (Me)","Bob64"},{"My","Bob64"},{"Your","Bob64"},{"His","Bob64"},{"Her","Bob64"},{"We","Bob64"},{"They","Bob64"},{"Their","Bob64"},{"Over there","Bob64"},{"Our","Bob64"},{"It's","Bob64"},
			{"Inside","Bob64"},{"Outside","Bob64"},{"Hidden","Bob64"},{"Behind","Bob64"},{"Above","Bob64"},{"Below","Bob64"},{"Here","Bob64"},{"Beside","Bob64"},{"Back","Bob64"},{"Front","Bob64"},
			{"Who","Bob64"},{"Where","Bob64"},{"When","Bob64"},{"Why","Bob64"},{"Which","Bob64"},{"What","Bob64"},{"How","Bob64"},{"How many","Bob64"},{"Can","Bob64"},{"Can't","Bob64"},{"Want","Bob64"},
			{"Have","Bob64"},{"Get","Bob64"},{"Will","Bob64"},{"Take","Bob64"},{"Need","Bob64"},{"Not","Bob64"},{"Or","Bob64"},{"And","Bob64"},{"For","Bob64"},{"At","Bob64"}}
		/* temp comment as other lessons do not have any placeholder motion data
		new string[,]{//lesson 3 (Common)
			{"Teach","GT4tube"},{"Learn","GT4tube"},{"Person","GT4tube"},{"Student","GT4tube"},{"Teacher","GT4tube"},{"Friend","GT4tube"},{"Sign","GT4tube"},{"Language","GT4tube"},{"Understand","GT4tube"},
			{"Know","GT4tube"},{"Don't Know","GT4tube"},{"Be Right Back (BRB)","GT4tube"},{"Accept","GT4tube"},{"Denied","GT4tube"},{"Name","GT4tube"},{"New","GT4tube"},{"Old","GT4tube"},{"Very","GT4tube"},
			{"Jokes","GT4tube"},{"Funny","GT4tube"},{"Play","GT4tube"},{"Favorite","GT4tube"},{"Draw (pencil)","GT4tube"},{"Stop","GT4tube"},{"Read","GT4tube"},{"Make","GT4tube"},{"Write","GT4tube"},
			{"Again / Repeat","GT4tube"},{"Slow","GT4tube"},{"Fast","GT4tube"},{"Rude","GT4tube"},{"Eat","GT4tube"},{"Drink","GT4tube"},{"Watch","GT4tube"},{"Work","GT4tube"},{"Live","GT4tube"},{"Play Game","GT4tube"},{"Same","GT4tube"},{"All Right","GT4tube"},{"People","GT4tube"},
			{"Browsing the Internet","GT4tube"},{"Movie","GT4tube"}
		} 
		//other lessons to be added below here
		*/
		};
		string [] ASLlessonnames = new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language.
		"Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Alphabet / Numbers","Verbs & Actions p1","Verbs & Actions p2","Verbs & Actions p3",
		"Verbs & Actions p4","Verbs & Actions p5","Verbs & Actions p6","Verbs & Actions p7","Verbs & Actions p8","Food","Animals / Machines","Places","Stuff / Weather","Clothes / Equipment","Fantasy / Characters",
		"Holidays / Special Days","Home stuff","Nature / Environment","Talk / Asking exercises","Name sign users","Countries","Colors","Medical"};
		string [,] signlanguages = new string[,]{{"ASL","American Sign Language"},{"BSL","British Sign Language"}};

			/*
			Debug.Log(ASLlessons.Length );//2 number of arrays inside

			Debug.Log(ASLlessons[0].GetLength(0));//36 number of rows in first array
			Debug.Log(ASLlessons[0].GetLength(1));//2 number of columns in first array
			Debug.Log(ASLlessons[1].GetLength(0));//42
			Debug.Log(ASLlessons[1].GetLength(1));//2

*/

		GameObject menuroot = new GameObject("Menu Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
			menuroot.transform.position = new Vector3(-7.25f, 0, 15);
			menuroot.layer = 8;
			//menuroot.SetActive(false); //once fully complete, uncomment this to set this active by default.

			GameObject rootcanvas = createandreturncanvas("Root Canvas",menuroot);
			createpanel(rootcanvas); //doesn't need a reference. Creates panel under rootcanvas.
			rootcanvas.layer=8;

				GameObject videocontainer = new GameObject("Video Container"); //create a world option that turns off videos completely.
				videocontainer.transform.position = new Vector3(10.25f, 0, 1);
				videocontainer.transform.SetParent(menuroot.transform, false);
				videocontainer.layer = 8;
								
				for (int x = 0; x < signlanguages.GetLength(0); x++) //lets process each language and pre-create all the damn gameobjects so I can find them later.
				{
				GameObject go = new GameObject(signlanguages[x,0]+" Root"); //creates ASL container for all ASL menu items.
				go.transform.SetParent(rootcanvas.transform, false);
				go.layer = 8;
					//createlessonboard(aslroot,ASLlessons[x],"ASL",x);//Loops and creates lesson boards for all initialized lessons in the lessonarray.
				}
				GameObject aslroot= GameObject.Find("/Menu Root/Root Canvas/ASL Root");//find and name the created languages so I can actually reference them later...
				GameObject bslroot= GameObject.Find("/Menu Root/Root Canvas/BSL Root");//find and name the created languages so I can actually reference them later...
				bslroot.SetActive(false);

				GameObject aslvideocontainer = createvideos(videocontainer,ASLlessons,"ASL");//creates the videos for a specified language...

				GameObject langselectmenu = new GameObject("VR Sign Language Select Menu");
				langselectmenu.transform.SetParent(rootcanvas.transform, false);
				langselectmenu.layer = 8;

				GameObject asllessonmenu = new GameObject("ASL Lesson Menu");
				asllessonmenu.transform.SetParent(aslroot.transform, false);
				asllessonmenu.layer = 8;
				for (int x = 0; x < ASLlessons.Length; x++)
				{
					createlessonboard(aslroot,ASLlessons[x],"ASL",x,asllessonmenu,rootcanvas);//Loops and creates lesson boards for all initialized lessons in the lessonarray.
				}
				
				 createmenu(aslroot,"ASL",ASLlessonnames,asllessonmenu,langselectmenu); //creates the lesson chooser menu
				//createlessonbackmenu(aslroot,"ASL"); //language issue. Does the triggers find all languages? Back menu all the way back to language select? Another back menu once on main menu to get to language select?
				createandreturnlanguageselect(langselectmenu,signlanguages); //creates main language selection menu
				aslvideocontainer.SetActive(false);
/*
			//Cleanup existing triggers to reference new menu root
			VRC_Trigger oldsignboardtrigger = GameObject.Find ("/UI Signboard Button").GetOrAddComponent<VRC_Trigger>();
			DestroyImmediate(oldsignboardtrigger);
			VRC_Trigger uisignboardtrigger = GameObject.Find ("/UI Signboard Button").GetOrAddComponent<VRC_Trigger>();
			uisignboardtrigger.UsesAdvancedOptions = true;
			uisignboardtrigger.proximity=4;
			uisignboardtrigger.interactText="Toggle Beta UI Menu System";
			VRC_Trigger.TriggerEvent uisignboardtriggerevent = new VRC_Trigger.TriggerEvent ();
			uisignboardtriggerevent.BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne;
			uisignboardtriggerevent.TriggerType = VRC_Trigger.TriggerType.OnInteract;
			uisignboardtriggerevent.TriggerIndividuals = true;
			VRC_EventHandler.VrcEvent eventAction4;
			eventAction4 = new VRC_EventHandler.VrcEvent ();
			eventAction4.EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive;
			eventAction4.ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Toggle;
			eventAction4.ParameterObject = menuroot;
			uisignboardtriggerevent.Events.Add (eventAction4);
			uisignboardtrigger.Triggers.Add(uisignboardtriggerevent);
			*/

			//Cleanup existing triggers to reference new video container in world preferences
			VRC_Trigger oldvideotrigger = GameObject.Find ("Preferences/World Options/Video Toggle").GetOrAddComponent<VRC_Trigger>();
			DestroyImmediate(oldvideotrigger);
			VRC_Trigger newvideotrigger = GameObject.Find ("Preferences/World Options/Video Toggle").GetOrAddComponent<VRC_Trigger>();
			newvideotrigger.UsesAdvancedOptions = true;
			newvideotrigger.proximity=4;
			newvideotrigger.interactText="Toggle Videos";
			VRC_Trigger.TriggerEvent videotriggerevent = new VRC_Trigger.TriggerEvent ();
			videotriggerevent.BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne;
			videotriggerevent.TriggerType = VRC_Trigger.TriggerType.OnInteract;
			videotriggerevent.TriggerIndividuals = true;
			VRC_EventHandler.VrcEvent togglevideos;
			togglevideos = new VRC_EventHandler.VrcEvent ();
			togglevideos.EventType = VRC_EventHandler.VrcEventType.SetGameObjectActive;
			togglevideos.ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Toggle;
			togglevideos.ParameterObject = GameObject.Find ("/Menu Root/Video Container");
			videotriggerevent.Events.Add (togglevideos);
			newvideotrigger.Triggers.Add(videotriggerevent);

			//menuroot.SetActive(false);
	}


static int[] getUniqueRandomArray(int min, int max, int count) {
    int[] result = new int[count];
    List<int> numbersInOrder = new List<int>();
    for (var x = min; x < max; x++) {
        numbersInOrder.Add(x);
    }
    for (var x = 0; x < count; x++) {
        var randomIndex = UnityEngine.Random.Range(0, numbersInOrder.Count);
        result[x] = numbersInOrder[randomIndex];
        numbersInOrder.RemoveAt(randomIndex);
    }

    return result;
}

static GameObject createbutton2(GameObject parent, string name,int sizedeltax,int sizedeltay,int rotatex,int rotatey,int rotatez,int anchoredPositionx,int anchoredPositiony,string text,int fontSize,int txtsizeDeltax,int txtsizeDeltay,int txtanchoredPositionx,int txtanchoredPositiony){
		Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; 

    DefaultControls.Resources resources = new DefaultControls.Resources();
    //Set the Button Background Image someBgSprite;
    resources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
	//toggleresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
    GameObject go = DefaultControls.CreateButton(resources);
	go.layer = 8;
    go.transform.SetParent(parent.transform, false);
	go.name = name;	
	Button b = go.GetOrAddComponent<Button>();
	b.navigation = no_nav;

	go.GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizedeltax, sizedeltay);
	go.GetComponent<RectTransform> ().eulerAngles = new Vector3(rotatex, rotatey, rotatez);//x,y,z
	go.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (anchoredPositionx,anchoredPositiony);
	go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
	go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
	go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
	go.transform.Find("Text").gameObject.GetComponent<Text>().text = text;
	go.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = fontSize;
	go.transform.Find("Text").gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (txtsizeDeltax, txtsizeDeltay);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (txtanchoredPositionx,txtanchoredPositiony);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
	return go;
}

static void createbackmenu(GameObject parent, string lang, string[] lessonname, string name){//try making a generic version "back to whatever" menu.
	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; 

	GameObject go = createbutton2(parent,"Return to VR-" + lang + " Lesson Menu",1500,100,0,0,90,100,0,"Return to VR-" + lang + " Lesson Menu",50,1500,100,0,0);
	Button b = go.GetOrAddComponent<Button>();
	b.onClick = new Button.ButtonClickedEvent();

	for (int x = 0; x < 2; x++)
		{
		UnityAction<bool> activeSetter = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson "+(x+1)), "SetActive") as UnityAction<bool>;
		UnityEventTools.AddBoolPersistentListener(b.onClick, activeSetter, false);
		}
	UnityAction<bool> activeSetter2 = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson Menu"), "SetActive") as UnityAction<bool>;
	UnityEventTools.AddBoolPersistentListener(b.onClick, activeSetter2, true);
go.SetActive(false);
}


	static GameObject createvideos(GameObject parent, string[][,] lessons,string lang){
		
		GameObject videocontainer = new GameObject(lang+" Video Container");
		videocontainer.transform.position = new Vector3(-1, 1, 0);
		videocontainer.transform.SetParent(parent.transform, false);
		videocontainer.layer = 8;

		for (int lessonnum = 0; lessonnum < lessons.Length; lessonnum++) //for each sub-array do:
			{
				for (int signnum = 0; signnum < lessons[lessonnum].GetLength(0); signnum++) //for each row in the subarray,
				{
					//Debug.Log("Sign Num L" + lessonnum+ " S" + signnum + " length"+lessons[lessonnum].GetLength(0));
					GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
					//go.layer = 8;
					go.name=lang+" Video L"+(lessonnum+1) +" S"+(signnum+1);
					//GameObject go = new GameObject("Video L"+(lessonnum+1) +" S"+(signnum+1));
					go.layer = 8;
					go.transform.SetParent(videocontainer.transform, false);
					//go.GetOrAddComponent<MeshFilter>().sharedMesh = quadGO.GetComponent<MeshFilter>().sharedMesh;
					//go.GetOrAddComponent<MeshFilter>().sharedMesh=myquad.GetComponent<MeshFilter>().mesh;
					//go.GetOrAddComponent<MeshFilter>().mesh = (Mesh)AssetDatabase.LoadAssetAtPath("Library/unity default resources/Quad",typeof(Mesh));
					go.GetOrAddComponent<MeshRenderer>().sharedMaterial=(Material)AssetDatabase.LoadAssetAtPath("Assets/VRCSDK/Examples/Sample Assets/Materials/Screen.mat",typeof(Material));
					//go.AddComponent<UnityEngine.Video.VideoPlayer>();
					go.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().url="https://vrsignlanguage.net/"+lang+"_videos/sheet"+string.Format("{0:D2}", (lessonnum+1))+"/"+string.Format("{0:D2}", (lessonnum+1))+"-"+string.Format("{0:D2}", (signnum+1))+".mp4";
					go.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().isLooping=true;
					go.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderMode=VideoRenderMode.MaterialOverride;
					go.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().audioOutputMode=VideoAudioOutputMode.None;
					//go.GetOrAddComponent<UnityEngine.Video.VideoPlayer>().renderer=
					//https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4
					go.SetActive(false);
				}
			}
		//quadGO.SetActive(false);
		return videocontainer;
	}
	static GameObject createandreturnlanguageselect(GameObject go,string[,] signlanguages){//

	Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; 

	GameObject menuheaderresourcesuitext = createheadertext(go,"VR Sign Language Select Menu");//Add menu header text:
	//for (int x = 0; x < signlanguages.GetLength(0); x++){
		//Debug.Log(signlanguages.GetLength(0) + " " +x);
		int x=0;
		GameObject bgo = createbutton2(go,signlanguages[x,1],900,100,0,0,0,200,1350-(x*150),signlanguages[x,1],50,900,100,20,0);
		Button b = bgo.GetOrAddComponent<Button>();
		b.onClick = new Button.ButtonClickedEvent();
		UnityAction<bool> enableaslroot = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguages[x,0]+" Root"), "SetActive") as UnityAction<bool>;
		UnityEventTools.AddBoolPersistentListener(b.onClick, enableaslroot, true);

		UnityAction<bool> enableaslmenuselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(signlanguages[x,0]+" Lesson Menu"), "SetActive") as UnityAction<bool>;//GameObject.Find("Menu Root/Root Canvas/ASL Root/ASL Lesson Menu")
		UnityEventTools.AddBoolPersistentListener(b.onClick, enableaslmenuselect, true);

		UnityAction<bool> disabelanguageselect = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find("Menu Root/Root Canvas/VR Sign Language Select Menu"), "SetActive") as UnityAction<bool>;
		UnityEventTools.AddBoolPersistentListener(b.onClick, disabelanguageselect, false);
		//activates video container for specific language
		UnityAction<bool> enablevideolanguage = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find("Menu Root/Video Container/"+signlanguages[x,0]+" Video Container"), "SetActive") as UnityAction<bool>;
		UnityEventTools.AddBoolPersistentListener(b.onClick, enablevideolanguage, true);


	//}
	return go;
	}
	static GameObject createandreturncanvas(string name,GameObject parent){//creates and returns canvas gameobject
		GameObject go = new GameObject (name);
		go.transform.SetParent(parent.transform, false);
		go.layer = 8;
		go.transform.localScale = new Vector3 (.001f,.001f,.001f);
		go.AddComponent<RectTransform> ();
		go.GetComponent<RectTransform> ().localPosition = new Vector3(0,0,0);
		go.GetComponent<RectTransform> ().sizeDelta = new Vector2 (4900, 1600);
		go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
		go.AddComponent<Canvas> (); //adds canvas to root canvas gameobject
		go.GetComponent<Canvas> ().renderMode = RenderMode.WorldSpace;
		go.AddComponent<CanvasScaler>();
		go.AddComponent<GraphicRaycaster>();
		go.AddComponent<VRC_UiShape>();
		go.AddComponent<ToggleGroup>();
		return go;
	}
	static GameObject createpanel(GameObject parent){//creates and returns panel gameobject
		DefaultControls.Resources resources = new DefaultControls.Resources();
		resources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
		GameObject go = DefaultControls.CreatePanel(resources);
		go.transform.SetParent(parent.transform, false);
		go.layer = 8;
		go.GetComponent<RectTransform> ().sizeDelta = new Vector2(4900, 1600);
		go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
		go.GetComponent<Image> ().color = new Color(1,1,1,1);

		return go;
	}

static GameObject createheadertext(GameObject parent, string txt){

		DefaultControls.Resources resources = new DefaultControls.Resources();
		GameObject go = DefaultControls.CreateText(resources);
		go.transform.SetParent (parent.transform, false);
		go.layer = 8;
		go.GetComponent<Text> ().text = txt;
		go.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		go.GetComponent<Text> ().fontStyle = FontStyle.Bold;
		go.GetComponent<Text> ().fontSize = 50;		
		go.GetComponent<Text> ().color = Color.black;
		go.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
		go.GetComponent<RectTransform> ().sizeDelta = new Vector2 (4900, 60);
		go.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (10, 1530);
		go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
	return go;
}
static GameObject createbutton(GameObject parent, string name){
		Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; 

    DefaultControls.Resources resources = new DefaultControls.Resources();
    //Set the Button Background Image someBgSprite;
    resources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
	//toggleresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
    GameObject go = DefaultControls.CreateButton(resources);
	go.layer = 8;
    go.transform.SetParent(parent.transform, false);
	go.name = name;	
	Button b = go.GetOrAddComponent<Button>();
	b.navigation = no_nav;
	return go;
}
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



static GameObject createmenu(GameObject parent, string lang, string[] lessonname, GameObject menu, GameObject langselectmenu){	
			Navigation no_nav = new Navigation();
		no_nav.mode=Navigation.Mode.None; 

	//GameObject lessonselectcanvas = createandreturncanvas("Lesson Select - " + lang,menuroot); //Create lesson select gameobject. 
	//GameObject menucanvaspanel= createpanel(lessonselectcanvas); //create panel background
	GameObject menuheaderresourcesuitext = createheadertext(menu,"VR-"+lang+" Sign Language - Lesson Menu");//Add menu header text:

		int column = 0;
		int row = 0;
		//for (int x = 0; x < lessonname.GetLength(0); x++) //this is the main loop that processes the array and creates + organizes the buttons in rows+columns.
		for (int x = 0; x < 2; x++)
		{
			if(x != 0){
				if (x % 9 == 0){ //display 9 items per column
					column++;
					row=0;
				}
			}
			//GameObject go = createbutton(menu,lang+" L" + (x+1) + "("+lessonname[x]+") - Button");
			GameObject go = createbutton2(menu,lang+" L" + (x+1) + "("+lessonname[x]+") - Button",900,100,0,0,0,(200 +(column*1000)),(1350+(row*-150)),(x+1)+ ") " + lessonname[x],50,880,100,20,0);
			//Debug.Log("Position: " + column + ", " + row + ", arraynum" + x + " ArrayValue: " + lesson1signarray[x] + " pos: " + (70 +(column*1000)) + "," + (1400+(row*-150)));
			Button b = go.GetOrAddComponent<Button>();
			b.onClick = new Button.ButtonClickedEvent();
			//Debug.Log("/Menu Root/Menu Root Canvas - "+lang+" Lesson "+(x+1));
			
			UnityAction<bool> enablelesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson "+(x+1)), "SetActive") as UnityAction<bool>;
            UnityEventTools.AddBoolPersistentListener(b.onClick, enablelesson, true);

			UnityAction<bool> disablemenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), menu, "SetActive") as UnityAction<bool>;
            UnityEventTools.AddBoolPersistentListener(b.onClick, disablemenu, false);

			//UnityAction<bool> enablebacktolessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName("Return to VR-"+lang+" Lesson Menu"), "SetActive") as UnityAction<bool>;
           // UnityEventTools.AddBoolPersistentListener(b.onClick, enablebacktolessonmenu, true);
			row++;
		}
		menu.SetActive(false);
		return menu;
}


	static void createlessonboard(GameObject parent, string[,] signarray, string lang, int lessonnum,GameObject lessonmenu,GameObject rootcanvas) //, int arraypos, int anchoredposx, int anchoredposy, string alignment, int layernum, string text, int posx, int posy
	{
		Navigation no_nav = new Navigation();
		no_nav.mode=Navigation.Mode.None; //disables navigation so people can't operate ui by moving avatar.
//createcanvas(menuroot,"Menu Root Canvas - " + lang + " Lesson " + lessonnum);
GameObject lessongo = new GameObject(lang + " Lesson " + (lessonnum+1));
lessongo.transform.SetParent(parent.transform, false);
createheadertext(lessongo,"VR-"+lang+" Sign Language for Index Controllers - Lesson " + (lessonnum+1) + " - Daily Use");



		int column = 0;
		int row = 0;
		for (int x = 0; x < signarray.GetLength(0); x++) //this is the main loop that processes the array and creates + organizes the buttons in rows+columns.
		{
			if(x != 0){
				if (x % 9 == 0){
					column++;
					row=0;
				}
			}
			
			//create the sign trigger helper first otherwise toggle has no target
			GameObject go = new GameObject(lang+" L" + lessonnum + " - S" + (x+1) +"("+signarray[x,0]+") - Trigger");//helper gameobject with vrc_trigger. needed for toggle?
			go.transform.SetParent (lessongo.transform, false);
			go.layer = 8;
			go.AddComponent<VRC_Trigger>();

			VRC_Trigger trigComponent = go.AddComponent<VRC_Trigger>();
			trigComponent.UsesAdvancedOptions = true;
			VRC_Trigger.TriggerEvent customTrig = new VRC_Trigger.TriggerEvent ();
			customTrig.BroadcastType = VRC_EventHandler.VrcBroadcastType.Local;
			customTrig.TriggerType = VRC_Trigger.TriggerType.OnEnable;
			customTrig.TriggerIndividuals = true;
			VRC_EventHandler.VrcEvent eventAction;
			eventAction = new VRC_EventHandler.VrcEvent ();
			eventAction.EventType = VRC_EventHandler.VrcEventType.AnimationTrigger;
			eventAction.ParameterString = signarray[x,0];
			eventAction.ParameterObject = GameObject.Find ("/Nana Avatar");
			//eventAction.ParameterInt = 1;
			customTrig.Events.Add (eventAction); //this eventaction sets animation trigger on avatar controller
			
			VRC_EventHandler.VrcEvent eventAction2;
			eventAction2 = new VRC_EventHandler.VrcEvent ();
			eventAction2.EventType = VRC_EventHandler.VrcEventType.SetUIText;
			eventAction2.ParameterString = signarray[x,0];
			eventAction2.ParameterObject = GameObject.Find ("/Nana Avatar/Currently Playing Canvas/Panel/Current Sign text");
			customTrig.Events.Add (eventAction2); //this eventaction sets uitext on current sign text

			VRC_EventHandler.VrcEvent eventAction3;
			eventAction3 = new VRC_EventHandler.VrcEvent ();
			eventAction3.EventType = VRC_EventHandler.VrcEventType.SetUIText;
			eventAction3.ParameterString = signarray[x,0];
			eventAction3.ParameterObject = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text");
			customTrig.Events.Add (eventAction3); //this eventaction sets uitext on avatar speech bubble text

			VRC_EventHandler.VrcEvent eventAction4;
			eventAction4 = new VRC_EventHandler.VrcEvent ();
			eventAction4.EventType = VRC_EventHandler.VrcEventType.SetUIText;
			eventAction4.ParameterString = "This sign was recorded by: " + signarray[x,1];
			eventAction4.ParameterObject = GameObject.Find ("/Nana Avatar/Sign Credits/Panel/Current Sign text");
			customTrig.Events.Add (eventAction4); //this eventaction sets uitext on avatar speech bubble text

			trigComponent.Triggers.Add(customTrig); //adds all 3 event actions to the trigger for this helper gameobject.
			go.SetActive(false); //disables the gameobject since the UI toggle with enable them to activate the triggers.
		
			//GameObject video1 = GameObject.Find ("/Direct MP4 Player/Videos/Video 1"); //.GetComponent<UnityEngine.Video.VideoPlayer>()


			
		//declare toggle resource settings
		DefaultControls.Resources toggleresources = new DefaultControls.Resources();
		//Set the Toggle Background Image someBgSprite;
		toggleresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
		//Set the Toggle Checkmark Image someCheckmarkSprite;
		toggleresources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
			GameObject uiToggle = DefaultControls.CreateToggle(toggleresources);
			Toggle t = uiToggle.GetOrAddComponent<Toggle>();
			uiToggle.gameObject.name = lang+" L" + lessonnum + " - S" + (x+1) +"("+signarray[x,0]+") - Toggle";				
			uiToggle.transform.SetParent(lessongo.transform, false);
			uiToggle.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
			uiToggle.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((240 +(column*1000)),(1400+(row*-150)));
			//Debug.Log("Position: " + column + ", " + row + ", arraynum" + x + " ArrayValue: " + lesson1signarray[x] + " pos: " + (70 +(column*1000)) + "," + (1400+(row*-150)));
			uiToggle.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
			uiToggle.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
			uiToggle.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
			t.navigation = no_nav;
			t.isOn = false;
			t.transition= Selectable.Transition.None;
			t.toggleTransition= Toggle.ToggleTransition.None;
			t.group=rootcanvas.gameObject.GetComponent<ToggleGroup>();
            t.onValueChanged = new Toggle.ToggleEvent();
			
			
//UnityAction<bool> activeSetter = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find ("/targetgo"), "SetActive") as UnityAction<bool>;
//UnityEventTools.AddBoolPersistentListener(uiToggle.GetComponent<Toggle>().onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find ("/targetgo"), "SetActive") as UnityAction<bool>, true);
//UnityEventTools.AddPersistentListener(uiToggle.GetComponent<Toggle>().onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), GameObject.Find ("/targetgo"), "SetActive") as UnityAction<bool>);
//UnityEventTools.AddStringPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<string>), GameObject.Find ("/Nana Avatar").GetComponent<Animator> (), "SetTrigger")as UnityAction<string>,lesson1signarray[x,1] );

			UnityEventTools.AddPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), go, "SetActive") as UnityAction<bool>);

		//GameObject videogo = GameObject.Find("/Menu Root/Videos Container/"+lang+" Video Container");
		GameObject videogo = GameObject.Find("/Menu Root/Video Container/"+lang+" Video Container/"+lang+" Video L"+(lessonnum+1)+" S"+(x+1));
		//Debug.Log("/Menu Root/Video Container/"+lang+" Video Container/"+lang+" Video L"+(lessonnum+1)+" S"+(x+1));
			UnityEventTools.AddPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), videogo, "SetActive") as UnityAction<bool>);
			

			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (80, 80);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-40,-40);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=8;

			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().text = x+1+ ") " + signarray[x,0];
			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().fontSize = 50;
			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (750, 100);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (80,-50);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.layer=8;
			
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (80, 80);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=8;
				//Debug.Log("Position: " + column + ", " + row + ", arraynum" + x + " ArrayValue: " + lesson1signarray[x]);
			row++;
		}

//static void createlessonbackmenu(GameObject parent, string lang){

	GameObject backtolessongo = createbutton(lessongo,"Return to VR-" + lang + " Lesson Menu");
	backtolessongo.layer = 8;
	backtolessongo.GetComponent<RectTransform> ().sizeDelta = new Vector2 (1500, 100);
	backtolessongo.GetComponent<RectTransform> ().eulerAngles = new Vector3(0, 0, 90);//x,y,z
	backtolessongo.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (100,0);
	backtolessongo.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
	backtolessongo.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
	backtolessongo.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
	Button b = backtolessongo.GetOrAddComponent<Button>();
	b.navigation = no_nav;
	b.onClick = new Button.ButtonClickedEvent();

	//disable the current active lesson when clicked
	UnityAction<bool> disablecurrentlesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson "+(lessonnum+1)), "SetActive") as UnityAction<bool>;
	UnityEventTools.AddBoolPersistentListener(b.onClick, disablecurrentlesson, false);

	//enable the lesson select ===problem because the lesson menu doesn't exist. 
	UnityAction<bool> enablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson Menu"), "SetActive") as UnityAction<bool>;
	UnityEventTools.AddBoolPersistentListener(b.onClick, enablelessonmenu, true);

	backtolessongo.transform.Find("Text").gameObject.GetComponent<Text>().text = "Return to VR-" + lang + " Lesson Menu";
	backtolessongo.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 50;
	backtolessongo.transform.Find("Text").gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
	backtolessongo.transform.Find("Text").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (1500, 100);
	backtolessongo.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,0);
	backtolessongo.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
	backtolessongo.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
	backtolessongo.transform.Find("Text").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
//backtolessongo.SetActive(false);
//}


		parent.SetActive(false);
		lessongo.SetActive(false);
	}


}
	//function example for later modularization.
	/*
	void CreateText(GameObject canvas, string text)
	{
		DefaultControls.Resources uiResources = new DefaultControls.Resources();
		GameObject uiText = DefaultControls.CreateText(uiResources);
		uiText.transform.SetParent(canvas.transform, false);
		uiText.GetComponent<Text>().text = text;

		//Change the Text position?
		//uiText.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 100f);
	}
	*/