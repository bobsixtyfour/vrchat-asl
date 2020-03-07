using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using VRCSDK2;
using UnityEngine.Events;
using UnityEditor.Events;

public class HH_HQ : MonoBehaviour {
	[MenuItem("ASLWorld/KoolaidButtons")]
	static void KoolaidButtons(){
        string [][,] ASLlessons = { //creates an array of arrays
			new string[,]{//lesson 1
            {"Hello/Hi","안녕하세요","Allo"},{"Bye","안녕(작별)","Au Revoir"},{"How","어떻게","Comment"},{"You","너","Toi/Tu"},{"How are you?","어떻게 지냈어?","Comment vas-tu?"},{"Nice","멋지다","Agréable"},
            {"Meet","만나다","Rencontrer"},{"Nice to meet you","만나서 반가워","Ravis de te rencontrer."},{"Good","좋아","Bon"},{"Bad","나빠","Mal"},{"Fine","괜찮아","Bien"},{"Who","누구","Qui"},{"What","무엇을","Quoi"},
            {"When","언제","Quand"},{"Where","어디","Où"},{"Why","왜","Pourquoi"},{"Which","어떤것","Lequel"},{"Understand","이해하다","Comprendre"},{"Don’t Understand","이해를 못했다","Ne pas comprendre"},{"Yes","네","Oui"},
            {"No","아니","Non"},{"Please","부탁","S’il vous plaît"},{"Thanks","고마워","Merci"},{"Sorry","미안","Désolé"},{"Deaf","청각장애인(농아인)","Sourd"},{"Hard of Hearing","청력이 약하다","Dur d’oreille"},
            {"Hearing","청력","Entendant"},{"Mute","말하지 않는다","Muet"}
            }/*,
			new string[,]{//lesson 2+ below
            {"Hello/Hi","안녕하세요","Allo"},{"Bye","안녕(작별)","Au Revoir"},{"How","어떻게","Comment"},{"You","너","Toi/Tu"},{"How are you?","어떻게 지냈어?","Comment vas-tu?"},{"Nice","멋지다","Agréable"},
            {"Meet","만나다","Rencontrer"},{"Nice to meet you","만나서 반가워","Ravis de te rencontrer."},{"Good","좋아","Bon"},{"Bad","나빠","Mal"},{"Fine","괜찮아","Bien"},{"Who","누구","Qui"},{"What","무엇을","Quoi"},
            {"When","언제","Quand"},{"Where","어디","Où"},{"Why","왜","Pourquoi"},{"Which","어떤것","Lequel"},{"Understand","이해하다","Comprendre"},{"Don’t Understand","이해를 못했다","Ne pas comprendre"},{"Yes","네","Oui"},
            {"No","아니","Non"},{"Please","부탁","S’il vous plaît"},{"Thanks","고마워","Merci"},{"Sorry","미안","Désolé"},{"Deaf","청각장애인(농아인)","Sourd"},{"Hard of Hearing","청력이 약하다","Dur d’oreille"},
            {"Hearing","청력","Entendant"},{"Mute","말하지 않는다","Muet"}
            }/*if this is the last lesson, don't put a comma after
				*/
        };
		string [] lessonnames = new string[]{//array of lesson names - I guess rename to Lesson 1, Lesson 2 and so on if you don't have names
		"Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Alphabet / Numbers","Verbs & Actions p1","Verbs & Actions p2","Verbs & Actions p3",
		"Verbs & Actions p4","Verbs & Actions p5","Verbs & Actions p6","Verbs & Actions p7","Verbs & Actions p8","Food","Animals / Machines","Places","Stuff / Weather","Clothes / Equipment","Fantasy / Characters",
		"Holidays / Special Days","Home stuff","Nature / Environment","Talk / Asking exercises","Name sign users","Countries","Colors","Medical"};
		
		int layer=0;
		int rowoffset=860;
		int columnoffset=200;

		int projectionsizex=6400;
		int projectionsizey=4800;
		
		int teachermenusizex=2700;
		int teachermenusizey=1000;

        GameObject menuroot = new GameObject("HH Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
		menuroot.transform.position = new Vector3(0, 0, 0);
		menuroot.layer = layer;
			GameObject rootcanvas = createandreturncanvas("Root Canvas",menuroot,teachermenusizex,teachermenusizey,layer);
			createpanel(rootcanvas,teachermenusizex,teachermenusizey,layer); //Creates panel under rootcanvas.
			
            GameObject displaycanvas = createandreturncanvas("MainDisplay",menuroot,projectionsizex,projectionsizey,layer);
			displaycanvas.transform.position = new Vector3(0, 2, 0);
            createpanel(displaycanvas,projectionsizex, projectionsizey,layer);

			DefaultControls.Resources resources = new DefaultControls.Resources();
			GameObject displaytext = DefaultControls.CreateText(resources);
			displaytext.transform.SetParent (displaycanvas.transform, false);
			displaytext.name="DisplayText";
			displaytext.layer = layer;
			displaytext.GetComponent<Text> ().text = "";
			displaytext.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font; //change font file here
			displaytext.GetComponent<Text> ().fontStyle = FontStyle.Bold;
			displaytext.GetComponent<Text> ().fontSize = 250;		
			displaytext.GetComponent<Text> ().color = Color.black; 
			displaytext.GetComponent<Text> ().alignment = TextAnchor.MiddleCenter;
			displaytext.GetComponent<RectTransform> ().sizeDelta = new Vector2 (projectionsizex/2, projectionsizey/2);
			displaytext.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().localScale=new Vector3(2,2,1);

			
			GameObject aslroot= new GameObject("ASL Root");
			aslroot.transform.SetParent(rootcanvas.transform, false);
				GameObject asllessonmenu = new GameObject("ASL Lesson Menu");
				asllessonmenu.transform.SetParent(rootcanvas.transform, false);
				asllessonmenu.layer = layer;
				for (int x = 0; x < ASLlessons.Length; x++)
				{
					createlessonboard(aslroot,ASLlessons[x],lessonnames[x],"ASL",x,rootcanvas,rowoffset,columnoffset,80,850,layer);//Loops and creates lesson boards for all initialized lessons in the lessonarray.
				}
				 createmenu(aslroot,"ASL",lessonnames,ASLlessons,asllessonmenu,840,100,800,160,100,1000,layer); //creates the lesson chooser menu
	}
static GameObject createbutton2(GameObject parent, string name,int sizedeltax,int sizedeltay,int rotatex,int rotatey,int rotatez,int anchoredPositionx,int anchoredPositiony,string text,int fontSize,int txtsizeDeltax,int txtsizeDeltay,int txtanchoredPositionx,int txtanchoredPositiony, TextAnchor alignment,int layer){
		Navigation no_nav = new Navigation();
	no_nav.mode=Navigation.Mode.None; 

    DefaultControls.Resources resources = new DefaultControls.Resources();
    //Set the Button Background Image someBgSprite;
    resources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
	GameObject go = DefaultControls.CreateButton(resources);
	go.layer = layer;
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
	go.transform.Find("Text").gameObject.GetComponent<Text>().alignment = alignment;
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (txtsizeDeltax, txtsizeDeltay);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (txtanchoredPositionx,txtanchoredPositiony);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
	go.transform.Find("Text").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
	return go;
}
	static GameObject createandreturncanvas(string name,GameObject parent,int sizedeltax,int sizedeltay,int layer){//creates and returns canvas gameobject
		GameObject go = new GameObject (name);
		go.transform.SetParent(parent.transform, false);
		go.layer = layer;
		go.transform.localScale = new Vector3 (.001f,.001f,.001f);
		go.AddComponent<RectTransform> ();
		go.GetComponent<RectTransform> ().localPosition = new Vector3(0,0,0);
		go.GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizedeltax, sizedeltay);
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
	static GameObject createpanel(GameObject parent,int sizedeltax,int sizedeltay,int layer){//creates and returns panel gameobject
		DefaultControls.Resources resources = new DefaultControls.Resources();
		resources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
		GameObject go = DefaultControls.CreatePanel(resources);
		go.transform.SetParent(parent.transform, false);
		go.layer = layer;
		go.GetComponent<RectTransform> ().sizeDelta = new Vector2(sizedeltax, sizedeltay);
		go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
		go.GetComponent<Image> ().color = new Color(1,1,1,1);
		return go;
	}

static GameObject createheadertext(GameObject parent, string txt,int sizedeltax,int sizedeltay,int anchoredPositionx,int anchoredPositiony,int layer){

		DefaultControls.Resources resources = new DefaultControls.Resources();
		GameObject go = DefaultControls.CreateText(resources);
		go.transform.SetParent (parent.transform, false);
		go.name="Header";
		go.layer = layer;
		go.GetComponent<Text> ().text = txt;
		go.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		go.GetComponent<Text> ().fontStyle = FontStyle.Bold;
		go.GetComponent<Text> ().fontSize = 50;		
		go.GetComponent<Text> ().color = Color.black;
		go.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
		go.GetComponent<RectTransform> ().sizeDelta = new Vector2 (sizedeltax, sizedeltay);
		go.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (anchoredPositionx, anchoredPositiony);
		go.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
		go.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
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

static GameObject createmenu(GameObject parent, string lang, string[] lessonname,string[][,] ASLlessons, GameObject menu,int buttonsizex,int buttonsizey,int rowoffset,int columnoffset,int rowseperation,int columnseperation,int layer){	
			Navigation no_nav = new Navigation();
		no_nav.mode=Navigation.Mode.None; 

	createheadertext(menu,"Lesson Menu",3000,60,160,920,layer);//Add menu header text:
		int column = 0;
		int row = 0;
		for (int x = 0; x < ASLlessons.Length; x++) //this is the main loop that processes the array and creates + organizes the buttons in rows+columns.
		{
			if(x != 0){
				if (x % 9 == 0){ //display 9 items per column
					column++;
					row=0;
				}
			}
			
			GameObject go = createbutton2(menu,lang+" L" + (x+1) + "("+lessonname[x]+") - Button",buttonsizex,buttonsizey,0,0,0,(columnoffset +(column*columnseperation)),(rowoffset+(row*-rowseperation)),(x+1)+ ") " + lessonname[x],50,880,100,20,0,TextAnchor.MiddleLeft,layer);
			Button b = go.GetOrAddComponent<Button>();
			b.onClick = new Button.ButtonClickedEvent();
					
			UnityAction<bool> enablelesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson "+(x+1)), "SetActive") as UnityAction<bool>;
            UnityEventTools.AddBoolPersistentListener(b.onClick, enablelesson, true);

			UnityAction<bool> disablemenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), menu, "SetActive") as UnityAction<bool>;
            UnityEventTools.AddBoolPersistentListener(b.onClick, disablemenu, false);


			row++;
		}
		//menu.SetActive(false);
		return menu;
}

	static void createlessonboard(GameObject parent, string[,] signarray,string ASLlessonnames, string lang, int lessonnum,GameObject rootcanvas,int rowoffset,int columnoffset,int rowseperation,int columnseperation,int layer) //, int arraypos, int anchoredposx, int anchoredposy, string alignment, int layernum, string text, int posx, int posy
	{
		Navigation no_nav = new Navigation();
		no_nav.mode=Navigation.Mode.None; //disables navigation so people can't operate ui by moving avatar.
		GameObject lessongo = new GameObject(lang+" Lesson "+(lessonnum+1));
		lessongo.transform.SetParent(parent.transform, false);
		createheadertext(lessongo,"Lesson " + (lessonnum+1) + " - "+ASLlessonnames,3000,60,160,920,layer);

		int column = 0;
		int row = 0;
		for (int x = 0; x < signarray.GetLength(0); x++) //this is the main loop that processes the array and creates + organizes the buttons in rows+columns.
		{
			if(x != 0){
				if (x % 10 == 0){
					column++;
					row=0;
				}
			}
			
			//create the sign trigger helper first otherwise toggle has no target
			GameObject go = new GameObject(lang+" L" + (lessonnum+1) + " - S" + (x+1) +"("+signarray[x,0]+") - Trigger");//helper gameobject with vrc_trigger. needed for toggle?
			go.transform.SetParent (lessongo.transform, false);
			go.layer = layer;
			go.AddComponent<VRC_Trigger>();

			VRC_Trigger trigComponent = go.AddComponent<VRC_Trigger>();
			trigComponent.UsesAdvancedOptions = true;
			VRC_Trigger.TriggerEvent customTrig = new VRC_Trigger.TriggerEvent ();
			customTrig.BroadcastType = VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne;
			customTrig.TriggerType = VRC_Trigger.TriggerType.OnEnable;
			customTrig.TriggerIndividuals = true;

			VRC_EventHandler.VrcEvent eventAction;
			eventAction = new VRC_EventHandler.VrcEvent ();
			eventAction.EventType = VRC_EventHandler.VrcEventType.SetUIText;
			eventAction.ParameterString = signarray[x,0]+"\n"+signarray[x,1]+"\n"+signarray[x,2];
			eventAction.ParameterObject = GameObject.Find ("/HH Root/MainDisplay/DisplayText");
			customTrig.Events.Add (eventAction); //this eventaction sets uitext on current sign text

			trigComponent.Triggers.Add(customTrig); //adds all event actions to the trigger for this helper gameobject.
			go.SetActive(false); //disables the gameobject since the UI toggle with enable them to activate the triggers.

			//declare toggle resource settings
			DefaultControls.Resources toggleresources = new DefaultControls.Resources();
			//Set the Toggle Background Image someBgSprite;
			toggleresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
			//Set the Toggle Checkmark Image someCheckmarkSprite;
			toggleresources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Checkmark.psd");
			GameObject uiToggle = DefaultControls.CreateToggle(toggleresources);
			Toggle t = uiToggle.GetOrAddComponent<Toggle>();
			uiToggle.gameObject.name = lang+" L" + (lessonnum+1) + " - S" + (x+1) +"("+signarray[x,0]+") - Toggle";				
			uiToggle.transform.SetParent(lessongo.transform, false);
			uiToggle.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
			uiToggle.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((columnoffset+(column*columnseperation)),(rowoffset+(row*-rowseperation)));
			//Debug.Log("Position: " + column + ", " + row + ", arraynum" + x + " ArrayValue: " + lesson1signarray[x] + " pos: " + (70 +(column*1000)) + "," + (1400+(row*-150)));
			uiToggle.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
			uiToggle.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
			uiToggle.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
            uiToggle.layer=layer;
			t.navigation = no_nav;
			t.isOn = false;
			t.transition= Selectable.Transition.None;
			t.toggleTransition= Toggle.ToggleTransition.None;
			t.group=rootcanvas.gameObject.GetComponent<ToggleGroup>();
            t.onValueChanged = new Toggle.ToggleEvent();
			
			UnityEventTools.AddPersistentListener(t.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), go, "SetActive") as UnityAction<bool>);
			
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (80, 80);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-40,-40);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=layer;

			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().text =" "+ (x+1)+ ") " + signarray[x,0];
			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().fontSize = 50;
			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (750, 100);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (40,-50);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.layer=layer;
			
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (80, 80);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=layer;

			row++;
		}
//makes back button
	GameObject backtolessongo = createbutton2(lessongo,"Return to VR-" + lang + " Lesson Menu",900,100,0,0,90,100,0,"Return to Lesson Menu",50,900,100,0,0,TextAnchor.MiddleCenter,layer);
	Button b = backtolessongo.GetOrAddComponent<Button>();
	b.onClick = new Button.ButtonClickedEvent();

	//disable the current active lesson when clicked
	UnityAction<bool> disablecurrentlesson = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson "+(lessonnum+1)), "SetActive") as UnityAction<bool>;
	UnityEventTools.AddBoolPersistentListener(b.onClick, disablecurrentlesson, false);

	//enable the lesson select
	UnityAction<bool> enablelessonmenu = System.Delegate.CreateDelegate(typeof(UnityAction<bool>), FindInActiveObjectByName(lang+" Lesson Menu"), "SetActive") as UnityAction<bool>;
	UnityEventTools.AddBoolPersistentListener(b.onClick, enablelessonmenu, true);
	lessongo.SetActive(false);
	}
}