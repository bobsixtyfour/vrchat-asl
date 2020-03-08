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
            },
			new string[,]{//lesson 2
			{"Person","사람","Personne"},{"Learn","배우다","Apprendre"},{"Student","학생","Étudiant"},{"Teach","가르치다","Enseigner"},{"Teacher","선생님","Enseignant"},{"Friend","친구","Ami"},
			{"Slow","느리다","Lent"},{"Fast","빠르다","Rapide"},{"Like","맘에 들다","Aimer"},{"Don’t Like","싫어하다","Ne pas aimer"},{"Want","원하다","Vouloir"},{"Don’t Want","원하지 않다","Ne pas vouloir"},
			{"Need","필요하다","Besoin"},{"Change","바꾸다","Changer"},{"Same","같다","Même"},{"Different","다르다","Different"},{"Can","할수있다","Pouvoir"},{"Can’t","못한다","Ne pas pouvoir"},
			{"Not","그것은 아니다","Pas"},{"Use","사용하다","Utiliser"},{"Follow","따라가다","Suivre"},{"Easy","쉽다","Facile"},{"Difficult","어렵다","Difficile"},{"Soft","부드럽다 ","Doux"},
			{"Hard","단단하다","Dure"},{"New","새롭다","Nouveau"},{"Old","늙다","Vieux"},{"Much/A lot","많다","Beaucoup"}
			},
			new string[,]{//lesson 3
			{"Time","시간","Temp"},{"Tomorrow","내일 ","Demain"},{"Yesterday","어제 ","Hier"},{"Today","오늘","Aujourd'hui"},{"Second","두번째","Seconde"},{"Minute","아주 작다","Minute"},
			{"Hour","시간","Heure"},{"Day","하루","Jour"},{"Week","일주일","Semaine"},{"Month","개월,달 ","Mois"},{"Year","년도","Année"},{"Past","과거","Passé"},{"Future/Will","미래","Future"},
			{"Before","그전","Avant"},{"Now","지금","Maintenant"},{"After","그후","Après"},{"Someday/Eventually","언젠가 ","Éventuellement"},{"Everyday","모두","Touts les jours"},
			{"Next","다음","Suivant"},{"Done/Finished","완료","Termier"},{"Later","나중에","Plustard"},{"Near","가까이","Près"},{"Far","멀어지다","Loin"},{"House","집","Maison"},
			{"Home","집","Maison"},{"Live","살다","Vivre"},{"True/Sure/Real","진실","Vrai"},{"Fake","거짓말, 가짜","Faux"}
			},
			new string[,]{//lesson 4
			{"Normal","평범,보통","Normale"},{"Any","조금도,아무것도","Tout"},{"Continue","계속","Continue"},{"Stay","계속 있다,머물러있다","Rester"},{"Still","아직도 , 계속","Encore"},{"Copy","복사","Copier"},
			{"Notice","공지, 안내","Remarquer"},{"Improve","개선","Ameliorer"},{"Gone","사라지다","Disparu"},{"Test","시험","Teste"},{"Visit","방문하다 ","Visiter"},{"With","와,과 함께","Avec"},
			{"Without","없이! ex: 없이 해보라","Sans"},{"Away","저리가,떨어져!","Au loin"},{"Weird","기괴,이상하다","Bizarre"},{"Turn","돌다, 돌리다","Tourner"},{"More Than","보다 많음","Plus que"},
			{"Less Than","오히려 적다 ","Moins que"},{"Correct","맞다","Correcte"},{"High","높다","Haut"},{"Low","낮다","Bas"},{"Way","방식","Chemin"},{"Wish","원하다, 바라다","Souhait"},{"Late","늦다","Tard"},
			{"Perfect","완벽","Parfait"},{"Fun","재미, 재밌어","Amusant"},{"Every","모든 , 모두","Touts"},{"Funny","웃김","Drôle"}
			},
			new string[,]{//lesson 5
			{"Jealous","질투","Jalous"},{"Idea","아이디어,발상","Idée"},{"Mountain","산,산더미","Montagne"},{"Blame","탓하다","Blame"},{"Babysitter","베이비시터","Guardienne d'enfants"},{"Behavior","행동 ","Agissement"},
			{"Butter","버터","Beurre"},{"Farm","농장","Ferme"},{"Fault","잘못,책임","Faute"},{"Fall","넘어지다,빠지다","Tomber"},{"Man","남자","Homme"},{"Woman","여자","Femme"},{"Mom","엄마","Mère"},{"Dad","아빠","Père"},
			{"Uncle","삼촌","Oncle"},{"Aunt","이모","Tante"},{"Grandma","할머니","Grand-mère"},{"Grandpa","할아버지","Grand-père"},{"Sister","언니","Sœur"},{"Brother","오빠","Frère"},{"Kid","새끼,어린이","Enfant"},
			{"Sunday","일요일","Dimanche"},{"Monday","월요일","Lundi"},{"Tuesday","화요일","Mardi"},{"Wednesday","수요일 ","Mercredi"},{"Thursday","목요일","Jeudi"},{"Friday","금요일","Vendredi"},{"Saturday","토요일","Samedi"}
			},
			new string[,]{//lesson 6
			{"Account","계좌","Compte"},{"Abandon","버리다","Abandonner"},{"Balance","균형(상태)","Balancer"},{"Bath","욕조(목욕)","Bain"},{"Baseball","야구","Baseball"},{"Because","왜냐면","Parce que"},
			{"Become","되다,적절하다","Devenir"},{"Call","불러","Appeler"},{"Careful","조심","Prudent"},{"Choose","선택","Choisir"},{"Red","빨강","Rouge"},{"Blue","파란색","Bleu"},{"Green","초록","Vert"},
			{"Yellow","노란색","Jaune"},{"Orange","오렌지","Orange"},{"Purple","보라","Purple"},{"Pink","분홍","Rose"},{"Black","검은색","Noir"},{"White","하얀색","Blanc"},{"Grey","회색","Gris"},
			{"Brown","갈색","Brun"},{"Tan","무두질하다","Bronzer"},{"Gold","황금","Doré"},{"Silver","은색","Argent"},{"Bright-(Color)","밝은","Claire"},{"Shiny-(Color)","빛나다","Brillant"},
			{"Light-(Color)","빛","Pale"},{"Dark-(Color)","어둡다","Foncé"}
			},
			new string[,]{//lesson 7
			{"Fly","날다","Voler"},{"Schedule","스케쥴","Horraire"},{"Frustrated","좌절하다","Frustré"},{"Don’t Worry","걱정 마(걱정안해도 된다)","Ne t'inquiète pas"},{"Embarrassed","당황하다","Embarassé"},{"Polite","공손하다","Poli"},
			{"Rude","무례하다","Rude"},{"Strong","강하다","Fort"},{"Brave","용감하다","Brave"},{"Experience","경험하다","Expérience"},{"Expensive","비싸다","Coûteux"},{"Curious","궁금하다","Curieux"},{"Money","돈","Argent"},
			{"Lazy","게으르다","Lâche"},{"Hungry","배고프다","Faim"},{"Important","중요하다","Important"},{"Family","가족","Famille"},{"Worry","걱정하다","Inquiêtude"},{"Worse","더 나쁘다,심하다","Pire"},{"Here","여기서","Ici"},
			{"Area","지역(구역)","Région"},{"E-Mail","전자 메일(이메일)","Couriel Electronic"},{"Discord","디스코드","Discorde"},{"Drama","드라마","Drame"},{"Hot","덥다","Chaud"},{"Cold","춥다","Froid"},{"Music","음악","Musique"},
			{"Avatar","아바타","Avatar"}
			},
			new string[,]{//lesson 8
			{"Cochlear Implant","인공와우","Implant Cochéaire"},{"Hearing Aid","보청기","Aide auditoire"},{"Disorder","엉망,어수선,장애","Désordre"},{"Together","함께 하다","Ensemble"},{"Nothing","아무것도 아니다","Rien"},
			{"Selective Mutism","불안장애","Mustisme sélectif"},{"Restaurant","레스토랑","Restaurant"},{"Order","순서,질서","Ordre"},{"Serve","제공,서비스","Service"},{"Buy","구매,사다","Acheter"},{"Sell","팔다","Vendre"},
			{"Taco","타코/옥수수반죽","Taco"},{"Burrito","버리토/옥수수가루","Burrito"},{"Hamburger","햄버거","Hamburger"},{"Spaghetti","스파게티","Spaghetti"},{"Pizza","피자","Pizza"},{"Ice Cream","아이스크림","Crème glacée"},
			{"Cake","케이크","Gâteaux"},{"Cookie","과자/쿠키","Biscuit"},{"Police","경찰","Police"},{"Fire Man","소방관","Pompier"},{"Doctor","의사","Docteur"},{"Wonder","궁금","se questionner"},{"Water","물","Eau"},
			{"Flower","꽃","Fleure"},{"Tree","나무","Arbre"},{"Sea","바다","Océan"},{"Rock","바위","Roche"}
			}/*if this is the last lesson, don't put a comma after the }
				*/
        };
		string [] lessonnames = new string[]{//array of lesson names - I guess rename to Lesson 1, Lesson 2 and so on if you don't have names
		"Lesson 1","Lesson 2","Lesson 3","Lesson 4","Lesson 5","Lesson 6","Lesson 7","Lesson 8","Lesson 9","Lesson 10","Lesson 11","Lesson 12","Lesson 13","Lesson 14","Lesson 15","Lesson 16","Lesson 17","Lesson 18","Lesson 19","Lesson 20"};
		
		int layer=0;
		int rowoffset=650;
		int columnoffset=100;

		int projectionsizex=5000;
		int projectionsizey=4000;
		
		int teachermenusizex=1100;
		int teachermenusizey=750;

        GameObject menuroot = new GameObject("HH Root"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
		menuroot.transform.position = new Vector3(0, 0, 0);
		menuroot.layer = layer;
			GameObject rootcanvas = createandreturncanvas("Root Canvas",menuroot,teachermenusizex,teachermenusizey,layer);
			rootcanvas.transform.position = new Vector3(-18.653f,-2.585f, -2.178f);
			
			//rootcanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0004149436f,.0007330904f,.001f);
			createpanel(rootcanvas,teachermenusizex,teachermenusizey,layer); //Creates panel under rootcanvas.
			
            GameObject displaycanvas = createandreturncanvas("MainDisplay",menuroot,projectionsizex,projectionsizey,layer);

			displaycanvas.transform.position = new Vector3(-19.881f, -1.307f, -1.453f);
			//displaycanvas.GetComponent<RectTransform> ().localScale=new Vector3(.0007777605f,.0008309863f,.001f);
            createpanel(displaycanvas,projectionsizex, projectionsizey,layer);
			GameObject.Find ("/HH Root/MainDisplay/Panel").GetComponent<Image>().color = new Color32( 0x21, 0x21, 0x21, 0xFF ); 

			DefaultControls.Resources resources = new DefaultControls.Resources();
			GameObject displaytext = DefaultControls.CreateText(resources);
			displaytext.transform.SetParent (displaycanvas.transform, false);
			displaytext.name="DisplayText";
			displaytext.layer = layer;
			displaytext.GetComponent<Text> ().text = "test";
			displaytext.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font; //change font file here
			displaytext.GetComponent<Text> ().fontStyle = FontStyle.Bold;
			displaytext.GetComponent<Text> ().fontSize = 250;		
			//displaytext.GetComponent<Text> ().color = Color.black; 
			displaytext.GetComponent<Text> ().color = new Color32( 0x6D, 0x9E, 0xEB, 0xFF ); // RGBA
			displaytext.GetComponent<Text> ().alignment = TextAnchor.MiddleCenter;
			displaytext.GetComponent<RectTransform> ().sizeDelta = new Vector2 (projectionsizex, projectionsizey);
			displaytext.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().pivot = new Vector2 (0, 0);
			displaytext.GetComponent<RectTransform> ().localScale=new Vector3(1,1,1);

			
			GameObject aslroot= new GameObject("ASL Root");
			aslroot.transform.SetParent(rootcanvas.transform, false);
				GameObject asllessonmenu = new GameObject("ASL Lesson Menu");
				asllessonmenu.transform.SetParent(rootcanvas.transform, false);
				asllessonmenu.layer = layer;
				for (int x = 0; x < ASLlessons.Length; x++)
				{
					createlessonboard(aslroot,ASLlessons[x],"ASL",x,rootcanvas,rowoffset,columnoffset,40,300,layer);//Loops and creates lesson boards for all initialized lessons in the lessonarray.
				}
				 createmenu(aslroot,"ASL",ASLlessons,asllessonmenu,teachermenusizex,teachermenusizey,300,40,(teachermenusizey-100),80,40,300,layer); //creates the lesson chooser menu

			rootcanvas.GetComponent<RectTransform> ().eulerAngles = new Vector3(0, 90, 0);//x,y,z
			displaycanvas.GetComponent<RectTransform> ().eulerAngles = new Vector3(0, -90, 0);//x,y,z
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
		go.GetComponent<Text> ().fontSize = 25;		
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

static GameObject createmenu(GameObject parent, string lang, string[][,] ASLlessons, GameObject menu,int canvassizex,int canvassizey,int buttonsizex,int buttonsizey,int rowoffset,int columnoffset,int rowseperation,int columnseperation,int layer){	
			Navigation no_nav = new Navigation();
		no_nav.mode=Navigation.Mode.None; 
int headerheight=60;
	createheadertext(menu,"Lesson Menu",canvassizex,headerheight,80,canvassizey-headerheight,layer);//Add menu header text:
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
			
			GameObject go = createbutton2(menu,lang+" Lesson " + (x+1) + " - Button",buttonsizex,buttonsizey,0,0,0,
			(columnoffset +(column*columnseperation)),(rowoffset+(row*-rowseperation)),"Lesson "+(x+1),25,buttonsizex,buttonsizey,20,0,TextAnchor.MiddleLeft,layer);
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

	static void createlessonboard(GameObject parent, string[,] signarray,string lang, int lessonnum,GameObject rootcanvas,int rowoffset,int columnoffset,int rowseperation,int columnseperation,int layer) //, int arraypos, int anchoredposx, int anchoredposy, string alignment, int layernum, string text, int posx, int posy
	{
		Navigation no_nav = new Navigation();
		no_nav.mode=Navigation.Mode.None; //disables navigation so people can't operate ui by moving avatar.
		GameObject lessongo = new GameObject(lang+" Lesson "+(lessonnum+1));
		lessongo.transform.SetParent(parent.transform, false);
		createheadertext(lessongo,"Lesson " + (lessonnum+1),1100,30,80,705,layer);

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
			
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (40, 40);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-20,-20);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=layer;

			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().text =" "+ (x+1)+ ") " + signarray[x,0];
			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().fontSize = 25;
			uiToggle.transform.Find("Label").gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (375, 50);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (20,-25);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Label").gameObject.layer=layer;
			
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (40, 40);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.transform.Find("Checkmark").gameObject.GetComponent<RectTransform>().pivot = new Vector2 (0, 0);
			uiToggle.transform.Find("Background").gameObject.layer=layer;

			row++;
		}
//makes back button
	GameObject backtolessongo = createbutton2(lessongo,"Return to VR-" + lang + " Lesson Menu",750,50,0,0,90,50,0,"Return to Lesson Menu",25,750,50,0,0,TextAnchor.MiddleCenter,layer);
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