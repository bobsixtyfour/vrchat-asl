// Do not load this script when building
#if UNITY_EDITOR
//using System.Collections;
using System.Collections.Generic; //for lists if I ever use em.
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UdonSharpEditor;
using VRC.SDKBase;
using TMPro;
using VRC.Udon;
using VRC.SDK3.Components;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine.Video;
using UnityEngine.Audio;


public class GenerateMenuButtons : MonoBehaviour {
	[MenuItem("ASLWorld/GenerateMenuButtons")]
	static void GenerateUdonMenu(){

		//Declare some variables + settings.
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
		//int togglesizedelta=80;
		int numberpercolumn = 14;
		int menusizex = 5300;
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

		GameObject menuroot = new GameObject("Udon Menu System"); //creates a new "Menu Root gameobject which will be the parent of all newly created objects in the script.
		menuroot.transform.position = menurootposition;
		menuroot.GetOrAddComponent<UdonBehaviour>().programSource = AssetDatabase.LoadAssetAtPath<AbstractUdonProgramSource>("Assets/UdonSharpSourceCode/MenuControl.asset");
		//menuroot.transform.SetParent(parent.transform, false);
		menuroot.layer = layer;


GameObject videocontainer = GameObject.Find("/VideoCanvas"); 

/*
		GameObject videocontainer = new GameObject("Video Container"); //container go to hold all videos. Allows a world option that turns on/off videos completely.
		videocontainer.transform.position = new Vector3(-3.75f, 1, 0);
		videocontainer.transform.SetParent(menuroot.transform, false);
		videocontainer.layer = layer;
		*/

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
		rootcanvas.AddComponent<VRCUiShape>(); //wtf
		ToggleGroup rootcanvastogglegroup = rootcanvas.AddComponent<ToggleGroup>();
		rootcanvastogglegroup.allowSwitchOff=true;
		GameObject rootpanel = DefaultControls.CreatePanel(rootpanelresources);
		rootpanel.transform.SetParent(rootcanvas.transform, false);
		rootpanel.layer = layer;
		rootpanel.GetComponent<RectTransform> ().sizeDelta = menusize;
		rootpanel.GetComponent<RectTransform> ().anchorMax = zerovector2;
		rootpanel.GetComponent<RectTransform> ().anchorMin = zerovector2;
		rootpanel.GetComponent<RectTransform> ().pivot = zerovector2;
		rootpanel.GetComponent<Image> ().color = new Color(0.07f,0.07f,0.07f,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
		/*
		if(mode=="Global"){
			rootpanel.GetComponent<Image> ().color = new Color(1,.90f,.90f,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
		}else{
			rootpanel.GetComponent<Image> ().color = new Color(.90f,.90f,1,1); //gets rid of transparency - also can change panel color if I want here. 1=255.
		}
		
		*/
		GameObject menubuttons = new GameObject("Menu Buttons");
		menubuttons.transform.SetParent(rootcanvas.transform, false);
		menubuttons.layer = layer;

		GameObject menubuttonsheader = DefaultControls.CreateText(txtresources);
		menubuttonsheader.transform.SetParent (rootcanvas.transform, false);
		menubuttonsheader.name="Menu Header";
		menubuttonsheader.layer = layer;
		menubuttonsheader.GetComponent<Text> ().text = "Header";
		menubuttonsheader.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		menubuttonsheader.GetComponent<Text> ().fontStyle = FontStyle.Bold;
		menubuttonsheader.GetComponent<Text> ().fontSize = 50;		
		menubuttonsheader.GetComponent<Text> ().color = Color.white;
		menubuttonsheader.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
		menubuttonsheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
		menubuttonsheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-headersizey-textpadding);
		menubuttonsheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
		menubuttonsheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
		menubuttonsheader.GetComponent<RectTransform> ().pivot = zerovector2;

		GameObject menubuttonssubheader = DefaultControls.CreateText(txtresources);
		menubuttonssubheader.transform.SetParent (rootcanvas.transform, false);
		menubuttonssubheader.name="SubHeader";
		menubuttonssubheader.layer = layer;
		menubuttonssubheader.GetComponent<Text> ().text = "SubHeader";
		menubuttonssubheader.GetComponent<Text> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		menubuttonssubheader.GetComponent<Text> ().fontStyle = FontStyle.Bold;
		menubuttonssubheader.GetComponent<Text> ().fontSize = 50;		
		menubuttonssubheader.GetComponent<Text> ().color = Color.white;
		menubuttonssubheader.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
		menubuttonssubheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
		menubuttonssubheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-(headersizey*2)-textpadding);
		menubuttonssubheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
		menubuttonssubheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
		menubuttonssubheader.GetComponent<RectTransform> ().pivot = zerovector2;

/*
		GameObject menubuttonsheader = new GameObject("Menu Header");
		menubuttonsheader.transform.SetParent (rootcanvas.transform, false);
		menubuttonsheader.layer = layer;
		menubuttonsheader.AddComponent<CanvasRenderer>();
		menubuttonsheader.AddComponent<TextMeshProUGUI> ().text="Header";
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().fontStyle = FontStyles.Bold;
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().fontSize = 50;		
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().color = Color.white;
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().alignment = TextAlignmentOptions.Left;
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().autoSizeTextContainer=true;
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().fontSizeMax=50;
		menubuttonsheader.GetComponent<TextMeshProUGUI> ().fontSizeMin=18;
		menubuttonsheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
		menubuttonsheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-headersizey-textpadding);
		menubuttonsheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
		menubuttonsheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
		menubuttonsheader.GetComponent<RectTransform> ().pivot = zerovector2;

GameObject menubuttonssubheader = DefaultControls.CreateText(txtresources);
		menubuttonssubheader.transform.SetParent (rootcanvas.transform, false);
		menubuttonssubheader.name="Menu SubHeader";
		menubuttonssubheader.layer = layer;
		DestroyImmediate(menubuttonssubheader.GetComponent<Text> ());
		menubuttonssubheader.GetOrAddComponent<TextMeshProUGUI> ().text="SubHeader";
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().text = "SubHeader";
		//menubuttonssubheader.GetComponent<TextMesh> ().font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().font = Resources.Load("LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().fontStyle = FontStyles.Bold;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().fontSize = 50;		
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().color = Color.white;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().alignment = TextAlignmentOptions.Left;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().autoSizeTextContainer=true;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().fontSizeMax=50;
		menubuttonssubheader.GetComponent<TextMeshProUGUI> ().fontSizeMin=18;
		menubuttonssubheader.GetComponent<RectTransform> ().sizeDelta = new Vector2 (menusizex, headersizey);
		menubuttonssubheader.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (textpadding, menusizey-(headersizey*2)-textpadding);
		menubuttonssubheader.GetComponent<RectTransform> ().anchorMax = zerovector2;
		menubuttonssubheader.GetComponent<RectTransform> ().anchorMin = zerovector2;
		menubuttonssubheader.GetComponent<RectTransform> ().pivot = zerovector2;
		*/
/*****************************************
Regenerates Next/Prev Button Events
*****************************************/

GameObject prevbutton=GameObject.Find("/Signing Avatars/Canvas/PrevButton");
GameObject nextbutton=GameObject.Find("/Signing Avatars/Canvas/NextButton");
					prevbutton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					nextbutton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					UnityEventTools.AddStringPersistentListener(prevbutton.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"PrevB");

					UnityEventTools.AddStringPersistentListener(nextbutton.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"NextB");


/*****************************************
Regenerates Quiz Button Events
*****************************************/

GameObject quizbuttona=GameObject.Find("/Signing Avatars/Canvas/QuizPanel/A");
GameObject quizbuttonb=GameObject.Find("/Signing Avatars/Canvas/QuizPanel/B");
GameObject quizbuttonc=GameObject.Find("/Signing Avatars/Canvas/QuizPanel/C");
GameObject quizbuttond=GameObject.Find("/Signing Avatars/Canvas/QuizPanel/D");
GameObject quizbuttonbig=GameObject.Find("/Signing Avatars/Canvas/QuizPanel/BigButton");
					quizbuttona.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					quizbuttonb.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					quizbuttonc.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					quizbuttond.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					quizbuttonbig.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					UnityEventTools.AddStringPersistentListener(quizbuttona.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"QuizA");
					UnityEventTools.AddStringPersistentListener(quizbuttonb.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"QuizB");
					UnityEventTools.AddStringPersistentListener(quizbuttonc.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"QuizC");
					UnityEventTools.AddStringPersistentListener(quizbuttond.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"QuizD");
					UnityEventTools.AddStringPersistentListener(quizbuttonbig.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"QuizBigButtonPushed");



/*****************************************
Regenerates Preferences Items
*****************************************/

Toggle HandToggle=GameObject.Find("/Preferencesv2/Canvas/Left Panel/Hand Toggle").GetComponent<Toggle>();
HandToggle.onValueChanged=new Toggle.ToggleEvent();
UnityEventTools.AddStringPersistentListener(HandToggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()
, "SendCustomEvent") as UnityAction<string>,"ToggleHand");

Toggle GlobalToggle=GameObject.Find("/Preferencesv2/Canvas/Left Panel/Global Mode").GetComponent<Toggle>();
GlobalToggle.onValueChanged=new Toggle.ToggleEvent();
UnityEventTools.AddStringPersistentListener(GlobalToggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()
, "SendCustomEvent") as UnityAction<string>,"ToggleGlobal");

Toggle QuizToggle=GameObject.Find("/Preferencesv2/Canvas/Left Panel/Quiz Mode").GetComponent<Toggle>();
QuizToggle.onValueChanged=new Toggle.ToggleEvent();
UnityEventTools.AddStringPersistentListener(QuizToggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()
, "SendCustomEvent") as UnityAction<string>,"ToggleQuiz");

Slider avatarscaleslider=GameObject.Find("/Preferencesv2/Canvas/Left Panel/Avatar Scale Slider").GetComponent<Slider>();
avatarscaleslider.onValueChanged=new Slider.SliderEvent();
UnityEventTools.AddStringPersistentListener(avatarscaleslider.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()
, "SendCustomEvent") as UnityAction<string>,"AvatarScaleSliderValueChanged");

Toggle DarkToggle=GameObject.Find("/Preferencesv2/Canvas/Right Panel/Dark Mode").GetComponent<Toggle>();
DarkToggle.onValueChanged=new Toggle.ToggleEvent();
UnityEventTools.AddStringPersistentListener(DarkToggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()
, "SendCustomEvent") as UnityAction<string>,"ToggleDark");



/*

					GameObject prevbutton=createbutton2(parent:menubuttons, name:"PrevButton",
					sizedelta:new Vector2(625,100),localPosition:new Vector3 (-2125,600,-2000),
					text:"Previous Sign",txtsizedelta:new Vector2 (625, 100),txtanchoredPosition:new Vector2 (0,0), alignment:TextAnchor.MiddleCenter,
					nav:no_nav,layer:layer);

						UnityEventTools.AddStringPersistentListener(prevbutton.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"PrevB");

					GameObject nextbutton=createbutton2(parent:menubuttons, name:"NextButton",
					sizedelta:new Vector2(625,100),localPosition:new Vector3 (-1500,600,-2000),
					text:"Next Sign",txtsizedelta:new Vector2 (625, 100),txtanchoredPosition:new Vector2 (0,0), alignment:TextAnchor.MiddleCenter,
					nav:no_nav,layer:layer);

						UnityEventTools.AddStringPersistentListener(nextbutton.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"NextB");

						*/

/*****************************************
Create the main array of buttons here
*****************************************/

					int menucolumn=0;
					int menurow=0;
			for (int x = 0; x < 70; x++){
				if (x != 0){
					if (x % numberpercolumn == 0){ //display 9 items per column
					menucolumn++;
					menurow=0;
					}
				}
					GameObject buttongo=createbutton2(parent:menubuttons, name:"Button "+(x), sizedelta:buttonsize,
					localPosition:new Vector2 (columnoffset +(menucolumn*columnseperation),(menusizey-headersizey-textpadding-buttonsizey-100-(menurow*rowseperation))),
					text: "   Button "+(x),txtsizedelta:new Vector2 (750, 100),txtanchoredPosition:new Vector2 (32,0), 
					alignment:TextAnchor.MiddleLeft, nav:no_nav,layer:layer);
					//alignment:TextAlignmentOptions.Left

					
						UnityEventTools.AddStringPersistentListener(buttongo.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"B"+(x));
						//var targetBehaviour = GameObject.Find("MyObject").GetComponent<UdonBehaviour>();
//						menuroot.GetOrAddComponent<UdonBehaviour>().publicVariables.TrySetVariableValue("",);
					//colors the buttons to indicate what's working and what's not.
					/*
					if(x<2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0xFF, 0x98, 0xFF ); //FF9898FF light yellow
						b.colors = colors;
					}
					if(x>=2){
						var colors = b.colors;
						colors.normalColor = new Color32( 0xFF, 0x98, 0x98, 0xFF ); //FF9898FF light red
						b.colors = colors;
					}*/
					

//Don't forget to create the "selected" button with checkmark (optional)
//Use color-changing buttons to indicated currently selected.
/*
							GameObject homeicongo = new GameObject("Home Icon");
							homeicongo.transform.SetParent(buttongo.transform, false);
							homeicongo.layer=layer;
							homeicongo.AddComponent<RectTransform> ();
							homeicongo.GetComponent<RectTransform> ().localPosition = new Vector3(450,68,0);
							homeicongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							homeicongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							homeicongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							homeicongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image homeicon= homeicongo.AddComponent<Image>();
							homeicon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/homeicon3.png");
							*/

					//5th value is VR index or regular 0=indexonly , 1=generalvr,2=both

							GameObject indexicongo = new GameObject("Index VR Icon");
							indexicongo.transform.SetParent(buttongo.transform, false);
							indexicongo.layer=layer;
							indexicongo.AddComponent<RectTransform> ();
							indexicongo.GetComponent<RectTransform> ().localPosition = new Vector3(450,68,0);
							indexicongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							indexicongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							indexicongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							indexicongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image indexicon= indexicongo.AddComponent<Image>();
							indexicon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/left_index_controllerdark.png");


							GameObject vricongo = new GameObject("Regular VR Icon");
							vricongo.transform.SetParent(buttongo.transform, false);
							vricongo.layer=layer;
							vricongo.AddComponent<RectTransform> ();
							vricongo.GetComponent<RectTransform> ().localPosition = new Vector3(450,68,0);
							vricongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							vricongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							vricongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							vricongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image vricon= vricongo.AddComponent<Image>();
							vricon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/left_htc_controllerdark.png");

							GameObject allvricongo = new GameObject("Both VR Icon");
							allvricongo.transform.SetParent(buttongo.transform, false);
							allvricongo.layer=layer;
							allvricongo.AddComponent<RectTransform> ();
							allvricongo.GetComponent<RectTransform> ().localPosition = new Vector3(450,68,0);
							allvricongo.GetComponent<RectTransform> ().sizeDelta = new Vector2(64,64);
							allvricongo.GetComponent<RectTransform> ().anchorMax = zerovector2;
							allvricongo.GetComponent<RectTransform> ().anchorMin = zerovector2;
							allvricongo.GetComponent<RectTransform> ().pivot = zerovector2;
							Image allvricon= allvricongo.AddComponent<Image>();
							allvricon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Icons/bothvricondark.png");
//indexicongo.SetActive(false);
//vricongo.SetActive(false);
//allvricongo.SetActive(false);

		menurow++;
				}

				//Create back button
				GameObject backtolessongo = createbutton2(parent:menubuttons, name:"Left Back Button", sizedelta:backbuttonsize,
				localPosition: new Vector2(buttonsizey, 0),
				text: "Back to Previous Menu", fontSize:50, txtsizedelta:backbuttonsize, txtanchoredPosition:new Vector2(20,0), 
				alignment:TextAnchor.MiddleCenter, nav:no_nav,rotatez:90, layer:layer);
				//alignment:TextAlignmentOptions.Center,


				//backtolessongo.GetOrAddComponent<Button>().onClick=new Button.ButtonClickedEvent();
						UnityEventTools.AddStringPersistentListener(backtolessongo.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"BackB");

				//Create back button
				GameObject backtolessongo2 = createbutton2(parent:menubuttons, name:"Right Back Button", sizedelta:backbuttonsize,
				localPosition: new Vector2(menusizex, 0),
				text: "Back to Previous Menu", fontSize:50, txtsizedelta:backbuttonsize, txtanchoredPosition:new Vector2(20,0), 
				alignment:TextAnchor.MiddleCenter, nav:no_nav,rotatez:90, layer:layer);
				//alignment:TextAlignmentOptions.Center,
				
				//backtolessongo.GetOrAddComponent<Button>().onClick=new Button.ButtonClickedEvent();
						UnityEventTools.AddStringPersistentListener(backtolessongo2.GetOrAddComponent<Button>().onClick, //the button/toggle that triggers the action
						System.Delegate.CreateDelegate(typeof(UnityAction<string>), menuroot.GetOrAddComponent<UdonBehaviour>()//the target of the action
						, "SendCustomEvent") as UnityAction<string>,"BackB");


/*****************************************
Update menu system to point to newly created objects.
*****************************************/
//recreate toggle to fix reference? 
/*
	Toggle oldvideotoggle = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Video Toggle").GetOrAddComponent<Toggle>();
	DestroyImmediate(oldvideotoggle);
	Toggle newvideotoggle = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Video Toggle").GetOrAddComponent<Toggle>();
	newvideotoggle.navigation = no_nav;
	newvideotoggle.isOn = true;
	newvideotoggle.graphic=newvideotoggle.transform.Find("Background").gameObject.transform.Find("Checkmark").GetComponent<Image>();
	newvideotoggle.transition= Selectable.Transition.None;
	newvideotoggle.toggleTransition= Toggle.ToggleTransition.None;
	newvideotoggle.onValueChanged = new Toggle.ToggleEvent();
	UnityEventTools.AddPersistentListener(newvideotoggle.onValueChanged, System.Delegate.CreateDelegate(typeof(UnityAction<bool>), 
	videocontainer, "SetActive") as UnityAction<bool>);
	*/
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
string text,Vector2 txtsizedelta,Vector2 txtanchoredPosition, TextAnchor alignment,//TextAlignmentOptions alignment
Navigation nav,int layer,int rotatex=0,int rotatey=0,int rotatez=0,int fontSize=50){

DefaultControls.Resources buttonresources = new DefaultControls.Resources();
buttonresources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/InputFieldBackground.psd");
//toggleresources.background = AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/Background.psd");
GameObject go = DefaultControls.CreateButton(buttonresources);
go.layer = layer;
go.transform.SetParent(parent.transform, false);
go.name = name;	
Button b = go.GetOrAddComponent<Button>();
ColorBlock colorVar = b.colors;
colorVar.normalColor = new Color( .25f, .25f, .25f);
colorVar.highlightedColor = new Color (.5f, .5f, .5f);
colorVar.pressedColor = new Color (.75f, .75f, .75f);
b.colors = colorVar;
b.navigation = nav;
RectTransform gort = go.GetComponent<RectTransform> ();
gort.sizeDelta = sizedelta;
gort.eulerAngles = new Vector3(rotatex, rotatey, rotatez);//x,y,z
//gort.anchoredPosition = anchoredPosition;
gort.localPosition = localPosition;
gort.anchorMax = new Vector2 (0, 0);
gort.anchorMin = new Vector2 (0, 0);
gort.pivot = new Vector2 (0, 0);

GameObject gotext = go.transform.Find("Text").gameObject;
Text gotmp = gotext.GetComponent<Text>();
gotmp.resizeTextForBestFit = true;
gotmp.text = text;
gotmp.color=Color.white;
gotmp.fontSize = fontSize;
gotmp.alignment = alignment;

RectTransform gotextrt = gotext.GetComponent<RectTransform>();
gotextrt.sizeDelta = txtsizedelta;
gotextrt.anchoredPosition = txtanchoredPosition;
gotextrt.anchorMax = new Vector2 (0, 0);
gotextrt.anchorMin = new Vector2 (0, 0);
gotextrt.pivot = new Vector2 (0, 0);

/*
GameObject gotext = go.transform.Find("Text").gameObject;

DestroyImmediate(gotext.GetComponent<Text> ());

TextMeshProUGUI gotmp = gotext.GetOrAddComponent<TextMeshProUGUI> ();
gotmp.text=text;
gotmp.font = Resources.Load("LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
gotmp.fontStyle = FontStyles.Bold;
gotmp.fontSize = fontSize;
gotmp.color = Color.white;
gotmp.alignment = alignment;
gotmp.autoSizeTextContainer=true;
gotmp.fontSizeMax=fontSize;
gotmp.fontSizeMin=18;

go.transform.Find("Text").GetComponent<RectTransform>().sizeDelta = txtsizedelta;
go.transform.Find("Text").GetComponent<RectTransform>().anchoredPosition = txtanchoredPosition;
go.transform.Find("Text").GetComponent<RectTransform>().anchorMax = new Vector2 (0, 0);
go.transform.Find("Text").GetComponent<RectTransform>().anchorMin = new Vector2 (0, 0);
go.transform.Find("Text").GetComponent<RectTransform>().pivot = new Vector2 (0, 0);*/
return go;
}
}
#endif
