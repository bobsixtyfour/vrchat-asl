using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;
using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDK3.Video.Components.Base;


#if !COMPILER_UDONSHARP && UNITY_EDITOR
using System.Linq; //for sorting
using System.Collections.Generic; //for lists if I ever use em.
using UnityEditor;
using UdonSharpEditor;
#endif


public class MenuControl : UdonSharpBehaviour
{
    /*
    // AllLessons[][][][0] = word 
    // AllLessons[][][][1] = mocap credits. 
    // AllLessons[][][][2] = video URL.
    // AllLessons[][][][3] = VR index icon? (Y). Blank defaults to both vr icon.
    // AllLessons[][][][4] = Sign description string
    // AllLessons[][][][5] = sign validation status 1 (red), 2 (yellow), 3 (green)
    // AllLessons[][][][6] = sign validation credits
    // AllLessons[][][][7] = sign validation comments
    */

    //if you get the bug where it doesn't recognize new array fields, make private, save/compile, make public again.
    string[][][][] AllLessons =
    new string[][][][]{ //all languages
new string[][][]{//asl lessons
new string[][]{//test lesson
new string[]{"Floss","","N/A","https://bob64.vrsignlanguage.net/ShaderMotion/Floss.mp4","0","","FALSE","",""},
new string[]{"Dark Test2","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/43 number.mp4","0","","FALSE","",""},
new string[]{"High Quality Test","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/high.mp4","0","","FALSE","Jenny0629",""},
new string[]{"Medium Quality Test","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/medium.mp4","0","","FALSE","Jenny0629",""},
new string[]{"Low Quality Test","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/low.mp4","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Mom_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Mom_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Dad_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Dad_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Baby_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Baby_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_daughter_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_daughter_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Son_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Son_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Jump_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Jump_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Karate_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Karate_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Spin_Pose_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Spin_Pose_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"Jen_test_Stretch_optimized","","Jenny0629","https://bob64.vrsignlanguage.net/ShaderMotion/Jen_test_Stretch_optimized.m4v","0","","FALSE","Jenny0629",""},
new string[]{"60_framerate_test","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/60_framerate_test.m4v","0","","FALSE","",""},
new string[]{"2021-08-29 16-30-40","","Bob64","https://bob64.vrsignlanguage.net/ShaderMotion/2021-08-29 16-30-40.mp4","0","","FALSE","",""},
new string[]{"TenriTest","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/TenriTest.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Spell / Fingerspell","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fingerspell.mp4","2","","FALSE","",""},
new string[]{"A","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/A.mp4","2","","FALSE","",""},
new string[]{"B","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/B.mp4","0","","FALSE","",""},
new string[]{"B (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/B (Variant 2).mp4","2","","FALSE","",""},
new string[]{"C","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/C.mp4","2","","FALSE","",""},
new string[]{"D","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/D.mp4","2","","FALSE","",""},
new string[]{"E","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/E.mp4","2","","FALSE","",""},
new string[]{"F","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/F.mp4","0","","FALSE","",""},
new string[]{"F (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/F (Variant 2).mp4","2","","FALSE","",""},
new string[]{"G","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/G.mp4","2","","FALSE","",""},
new string[]{"H","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/H.mp4","2","","FALSE","",""},
new string[]{"I","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I.mp4","0","","FALSE","",""},
new string[]{"I (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I (Variant 2).mp4","2","","FALSE","",""},
new string[]{"J","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/J.mp4","0","","FALSE","",""},
new string[]{"J (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/J (Variant 2).mp4","2","","FALSE","",""},
new string[]{"K","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/K.mp4","0","","FALSE","",""},
new string[]{"K (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/K (Variant 2).mp4","2","","FALSE","",""},
new string[]{"L","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/L.mp4","2","","FALSE","",""},
new string[]{"M","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/M.mp4","2","","FALSE","",""},
new string[]{"N","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/N.mp4","2","","FALSE","",""},
new string[]{"O","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/O.mp4","2","","FALSE","",""},
new string[]{"P","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/P.mp4","0","","FALSE","",""},
new string[]{"P (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/P (Variant 2).mp4","0","","FALSE","",""},
new string[]{"Q","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Q.mp4","2","","FALSE","",""},
new string[]{"R","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R.mp4","2","","FALSE","",""},
new string[]{"R (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R (Variant 2).mp4","2","","FALSE","",""},
new string[]{"S","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/S.mp4","2","","FALSE","",""},
new string[]{"T","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/T.mp4","2","","FALSE","",""},
new string[]{"U","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/U.mp4","2","","FALSE","",""},
new string[]{"V","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/V.mp4","0","","FALSE","",""},
new string[]{"W","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W.mp4","2","","FALSE","",""},
new string[]{"W (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W (Variant 2).mp4","2","","FALSE","",""},
new string[]{"X","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X.mp4","0","","FALSE","",""},
new string[]{"X (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X (Variant 2).mp4","2","","FALSE","",""},
new string[]{"Y","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y.mp4","0","","FALSE","",""},
new string[]{"Y (Variant 2)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y (Variant 2).mp4","2","","FALSE","",""},
new string[]{"Z","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Z.mp4","2","","FALSE","",""},
new string[]{"Number","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Number.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Hello","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hello.mp4","2","","FALSE","",""},
new string[]{"Meaning","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meaning.mp4","2","","FALSE","",""},
new string[]{"What does that mean?","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What does that mean.mp4","2","Meaning with body language to change it into a question","FALSE","",""},
new string[]{"Good Afternoon","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Good Afternoon.mp4","0","","FALSE","",""},
new string[]{"Goto Portal","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Goto Portal.mp4","0","","FALSE","",""},
new string[]{"Go Away","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Go Away.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Over There","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Over There.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Draw","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Draw.mp4","0","","FALSE","",""},
new string[]{"Read","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Read.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Father","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Father.mp4","0","","FALSE","",""},
new string[]{"Mother","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mother.mp4","0","","FALSE","",""},
new string[]{"Child","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Child.mp4","0","","FALSE","",""},
new string[]{"Teen","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teen.mp4","0","","FALSE","",""},
new string[]{"Born","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Born.mp4","0","","FALSE","",""},
new string[]{"No One","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/No One.mp4","0","","FALSE","",""},
new string[]{"Someone","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Someone.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Envy","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Envy.mp4","0","","FALSE","",""},
new string[]{"Lonely","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lonely.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"More","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/More.mp4","0","","FALSE","",""},
new string[]{"Empty","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Empty.mp4","0","","FALSE","",""},
new string[]{"Ever","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ever.mp4","0","","FALSE","",""},
new string[]{"Hard","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hard.mp4","0","","FALSE","",""},
},
new string[][]{
new string[]{"Monday","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Monday.mp4","0","","FALSE","",""},
new string[]{"Tuesday","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tuesday.mp4","0","","FALSE","",""},
new string[]{"Next Week","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Next Week.mp4","0","","FALSE","",""},
},
},
    };


    //GameObject [][][][] videos;

    string[][] lessonnames = { //can be unique per language, as long as they match the number of array
		new string[] { //ASL lesson names - can be unique per language.
			"Shadermotion Testing",
            "Alphabet / Numbers (Fingerspelling)",
            "Daily Use",
            "Indexing / Questions / Answer",
            "Common",
            "People",
            "Feelings / Reactions",
            "Value",
            "Time",
            "VRChat",
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
            "Materials",
            "Medical",
        },


    };
    string[][] signlanguagenames = {
        new string[] {
            "ASL",
            "American Sign Language"
        },

		//new string[]{"DGS","Deutsche Gebärdensprache (German Sign Language)"}
	};

    // MoCap Avatar Objects/Variables
    Animator nana;
    GameObject signingavatars;
    GameObject currentsign;
    GameObject signcredit;
    GameObject description;
    TextMeshProUGUI currentsigntext;
    TextMeshProUGUI speechbubbletext;
    TextMeshProUGUI signcredittext;
    TextMeshProUGUI descriptiontext;

    // Main Menu Objects/Variables
    TextMeshProUGUI menuheadertext;
    TextMeshProUGUI menusubheadertext;
    GameObject[] buttons = new GameObject[70];
    GameObject[] indexicons = new GameObject[70];
    GameObject[] regvricons = new GameObject[70];
    GameObject[] bothvricons = new GameObject[70];
    TextMeshProUGUI[] buttontext = new TextMeshProUGUI[70];
    int numofbuttons = 70;
    GameObject[] backbuttons = new GameObject[2];
    GameObject nextButton;
    GameObject prevButton;

    int currentboard = 0; // current page
    int currentlang = 0; // currently selected Language
    int currentlesson = -1; // currently selected Lesson
    int currentword = -1; // currently selected Word/Sign
    [UdonSynced] int globalboard;
    [UdonSynced] int globalcurrentlang;
    [UdonSynced] int globalcurrentlesson;
    [UdonSynced] int globalcurrentword;

    // VRCPlayer Objects/Variables
    GameObject videocontainer;
    GameObject videoplayer;
    VRCUnityVideoPlayer vrcplayercomponent;
    public VRCUrl[][][] langurls;

    // Quiz Menu Objects/Variables
    GameObject quizp;
    GameObject quiza;
    GameObject quizb;
    GameObject quizc;
    GameObject quizd;
    GameObject quizbig;
    GameObject quizreset;
    TextMeshProUGUI quiztext;
    TextMeshProUGUI quiztext2;
    TextMeshProUGUI quiztext3;
    bool[][] quizlessonselection; //stores which lessons are selected.
    int[][] quizwordmapping;//points to the mainarray [lang]
    bool[][][] quizwordselection;
    bool quizinprogress = false;
    int numofwordsselected = 0;
    int quizcounter = 0;
    int quizscore = 0;
    int quizanswer = 0;

    // Preference Menu Objects/Variables - Avatar/Visual Controls
    Slider avatarscaleslider;
    Toggle HandToggle;

    // Preference Menu Objects/Variables - Global/Local Mode
    Toggle GlobalToggle;
    bool globalmode;

    // Preference Menu Objects/Variables - Lookup/Quiz Mode
    Toggle QuizToggle;
    const int MODE_LOOKUP = 0;
    const int MODE_QUIZ = 1;
    int currentmode; // Tracks current mode (Lookup, Quiz, etc.)
    [UdonSynced] int globalcurrentmode;

    // Preference Menu Objects/Variables - Dark Mode
    Toggle DarkToggle;
    bool darkmode;
    ColorBlock verifieddark = new ColorBlock();
    Color black = Color.black;
    Color white = Color.white;
    Color gray = Color.gray;
    Color lightgray = new Color(.25f, .25f, .25f, 1);
    TextMeshPro[] worldtext;
    Image[] worldpanels;
    Button[] worldbuttons; //every button except the 70 menu button array
    Image[] worldcheckboxes;
    ColorBlock darkmodebutton;
    ColorBlock darkmodeselectedbutton;

    // General Constants
    const int NOT_SELECTED = -1;
    const int MENU_LANGUAGE = 0;
    const int MENU_LESSON = 1;
    const int MENU_WORD = 2;

    const int FORWARDS = 1;
    const int BACKWARDS = -1;
    int direction = FORWARDS;

    // Color Constants
    Color COLOR_WHITE = new Color(1, 1, 1, 1);
    Color COLOR_BLACK = new Color(0, 0, 0, 1);
    Color COLOR_GREY_DARK = new Color(.25f, .25f, .25f, 1);
    Color COLOR_GREY_MEDIUM = new Color(.5f, .5f, .5f, 1);
    Color COLOR_GREY_LIGHT = new Color(.75f, .75f, .75f, 1);
    Color COLOR_GREEN_DARK = new Color(.2f, .3f, .2f, 1);
    Color COLOR_GREEN_MEDIUM = new Color(.2f, .5f, .2f, 1);
    Color COLOR_GREEN_LIGHT = new Color(.75f, .75f, .75f, 1);
    Color COLOR_GREEN = new Color(.5f, 1, .5f, 1);
    Color COLOR_RED = new Color(1, .5f, .5f, 1);
    Color COLOR_YELLOW = new Color(1, 0.92f, 0.016f, 1);
    // Debug
    //Text debugtextbox;

    /***************************************************************************************************************************
	Assigns variables for use. Initializes menu by calling DisplayLocalLanguageSelectMenu();
	***************************************************************************************************************************/
    void Start()
    {
        // Initialize Displays
        _InitializeDarkMode();
        _InitializePreferenceMenu();

        _InitializeSigningAvatar();
        _InitializeMenu();
        _InitializeVideoPlayer();

        _InitializeQuizMenu();

        // Update Data - Modes
        currentmode = QuizToggle.GetComponent<Toggle>().isOn ? MODE_QUIZ : MODE_LOOKUP;
        globalmode = GlobalToggle.GetComponent<Toggle>().isOn;
        darkmode = DarkToggle.GetComponent<Toggle>().isOn;

        // Update Data - Quiz
        quizlessonselection = new bool[AllLessons.Length][];
        for (int langnum = 0; langnum < AllLessons.Length; langnum++)
        {
            quizlessonselection[langnum] = new bool[AllLessons[langnum].Length];
            for (int y = 0; y < AllLessons[langnum].Length; y++)
            {
                quizlessonselection[langnum][y] = false;
            }
        }

        // Update Data - Menu Defaults
        currentlang = NOT_SELECTED;
        currentlesson = NOT_SELECTED;
        currentword = NOT_SELECTED;


        // Update Display States
        _UpdateSigningAvatarState();
        _UpdateAllDisplays();

    }//end start


    /***************************************************************************************************************************
	Initialize Variables related to Dark Mode
	***************************************************************************************************************************/
    private void _InitializeDarkMode()
    {
        darkmodebutton = new ColorBlock();
        darkmodebutton.normalColor = COLOR_GREY_DARK;
        darkmodebutton.highlightedColor = COLOR_GREY_MEDIUM;
        darkmodebutton.pressedColor = COLOR_GREY_LIGHT;
        darkmodebutton.colorMultiplier = 1;
        darkmodebutton.fadeDuration = .1f;

        darkmodeselectedbutton = new ColorBlock();
        darkmodeselectedbutton.normalColor = COLOR_GREEN_DARK;
        darkmodeselectedbutton.highlightedColor = COLOR_GREEN_MEDIUM;
        darkmodeselectedbutton.pressedColor = COLOR_GREEN_LIGHT;
        darkmodeselectedbutton.colorMultiplier = 1;
        darkmodeselectedbutton.fadeDuration = .1f;

        //ColorBlock ver = new ColorBlock();
        //verifieddark.normalColor = new Color(.18f,.3f,.18f,1); //light green
        //verifieddark.highlightedColor = new Color(.4f,1,.4f,1); //darker light green
        //verifieddark.pressedColor = new Color(.4f,.7f,.4f,1); //darker green
    }

    /***************************************************************************************************************************
	Initialize Variables related to the Preferences Menu
	***************************************************************************************************************************/
    private void _InitializePreferenceMenu()
    {
        HandToggle = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Hand Toggle").GetComponent<Toggle>();
        GlobalToggle = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Global Mode").GetComponent<Toggle>();
        QuizToggle = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Quiz Mode").GetComponent<Toggle>();
        avatarscaleslider = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Avatar Scale Slider").GetComponent<Slider>();
        DarkToggle = GameObject.Find("/Preferencesv2/Canvas/Right Panel/Dark Mode").GetComponent<Toggle>();
    }

    /***************************************************************************************************************************
	Initialize Variables related to the MoCap Avatar (Nana)
	***************************************************************************************************************************/
    private void _InitializeSigningAvatar()
    {

        signingavatars = GameObject.Find("/Signing Avatars");
        var nanamats = signingavatars.transform.Find("Nana Avatar (SM)").GetComponent<MeshRenderer>().materials;
        //#if UNITY_ANDROID
        //material swaps here?

        //#else

        //#endif
        signingavatars = GameObject.Find("/Signing Avatars");
        speechbubbletext = signingavatars.transform.Find("Nana Avatar (SM)/Canvas/Bubble/Text (TMP)").GetComponent<TextMeshProUGUI>();
        /*
		if(signingavatars.transform.Find("Nana Avatar (SM)").gameObject.activeInHierarchy){
			Debug.Log("PC active");
			//nana=signingavatars.transform.Find("Nana Avatar (SM)").GetComponent<Animator>();
			speechbubbletext = signingavatars.transform.Find("Nana Avatar (SM)/Canvas/Bubble/Text (TMP)").GetComponent < TextMeshProUGUI > ();
		}
		if(signingavatars.transform.Find("Nana Quest").gameObject.activeInHierarchy){
			Debug.Log("Quest active");
			//nana=signingavatars.transform.Find("Nana Quest").GetComponent<Animator>();
			speechbubbletext = signingavatars.transform.Find("Nana Avatar (SM)/Canvas/Bubble/Text (TMP)").GetComponent < TextMeshProUGUI > ();
		}*/
        currentsign = signingavatars.transform.Find("Canvas/Current Sign Panel").gameObject;
        signcredit = signingavatars.transform.Find("Canvas/Credit Panel").gameObject;
        description = signingavatars.transform.Find("Canvas/Description Panel").gameObject;
        currentsigntext = currentsign.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        signcredittext = signcredit.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        descriptiontext = description.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        nextButton = signingavatars.transform.Find("Canvas/NextButton").gameObject;
        prevButton = signingavatars.transform.Find("Canvas/PrevButton").gameObject;
    }

    /***************************************************************************************************************************
	Initialize Variables related to the main Menu
	***************************************************************************************************************************/
    private void _InitializeMenu()
    {
        menuheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header").GetComponent<TextMeshProUGUI>();
        //menuheader = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header");
        menusubheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu SubHeader").GetComponent<TextMeshProUGUI>();

        for (int x = 0; x < numofbuttons; x++)
        {
            buttons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x));
            buttontext[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Text").GetComponent<TextMeshProUGUI>();
            indexicons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Index VR Icon");
            regvricons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Regular VR Icon");
            bothvricons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Both VR Icon");
        }
        backbuttons[0] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Left Back Button");
        backbuttons[1] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Right Back Button");

    }

    /***************************************************************************************************************************
	Initialize Variables related to the VRCPlayer
	***************************************************************************************************************************/
    private void _InitializeVideoPlayer()
    {
        videocontainer = GameObject.Find("/Video Container");
        videoplayer = GameObject.Find("/Video Container/Video");
        vrcplayercomponent = ((VRCUnityVideoPlayer)videoplayer.GetComponent(typeof(VRCUnityVideoPlayer)));
    }

    /***************************************************************************************************************************
	Initialize Variables related to the the Quiz Menu
	***************************************************************************************************************************/
    private void _InitializeQuizMenu()
    {
        quizp = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel");
        quiza = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel/A");
        quizb = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel/B");
        quizc = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel/C");
        quizd = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel/D");
        quizbig = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel/BigButton");
        quizreset = GameObject.Find("/Signing Avatars/QuizCanvas/QuizPanel/Reset");
        quiztext = quizp.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        quiztext2 = quizp.transform.Find("Text2 (TMP)").GetComponent<TextMeshProUGUI>();
        quiztext3 = quizp.transform.Find("Text3 (TMP)").GetComponent<TextMeshProUGUI>();
        quizp.SetActive(currentmode == MODE_QUIZ);

        /*
		quiza.SetActive(quizmode);
		quizb.SetActive(quizmode);
		quizc.SetActive(quizmode);
		quizd.SetActive(quizmode);
		quizbig.SetActive(!quizmode);
		*/
    }

    /***************************************************************************************************************************
	Toggle Variables related to the MoCap Avatar Menu based on current Mode
	***************************************************************************************************************************/
    private void _UpdateSigningAvatarState()
    {
        Debug.Log("Entered _UpdateSigningAvatarState");
        bool isActive = !(currentmode == MODE_QUIZ);
        nextButton.SetActive(isActive);
        prevButton.SetActive(isActive);
        currentsign.SetActive(isActive);
        signcredit.SetActive(isActive);
        description.SetActive(isActive);
    }

    /***************************************************************************************************************************
	Update Menu Variables used to control displays.
	***************************************************************************************************************************/
    private void _UpdateMenuVariables(int buttonIndex)
    {
        Debug.Log("Entered _UpdateMenuVariables with direction:" + direction);
        //_DebugMenuVariables();
        int currentmenu = _GetCurrentMenu();
        switch (direction)
        {
            case BACKWARDS:
                if (currentlang == NOT_SELECTED)
                { //on lang menu
                  //Do nothing, as it shouldn't be possible to hit a back button on the lang select
                }
                else
                {
                    if (currentlesson == NOT_SELECTED)
                    { //on lesson menu
                        currentlang = NOT_SELECTED; //go to lang menu
                    }
                    else
                    { //on word menu
                        currentlesson = NOT_SELECTED; //go to lesson menu
                    }
                }
                direction = FORWARDS;
                break;
            default: //forward
                switch (currentmenu)
                {
                    case MENU_LANGUAGE:
                        currentlang = buttonIndex;
                        currentlesson = NOT_SELECTED;
                        currentword = NOT_SELECTED;
                        break;
                    case MENU_LESSON:
                        if (currentmode == MODE_QUIZ)
                        {
                            quizlessonselection[currentlang][buttonIndex] = !quizlessonselection[currentlang][buttonIndex];
                        }
                        else
                        {
                            currentlesson = buttonIndex;
                        }
                        currentword = NOT_SELECTED;
                        break;
                    case MENU_WORD:
                        if (currentmode == MODE_QUIZ)
                        {
                            currentlesson = NOT_SELECTED;
                            currentword = NOT_SELECTED;
                        }
                        else
                        {
                            currentword = buttonIndex;
                        }

                        break;
                    default:
                        //Debug.Log("_UpdateMenuVariables() failed; currentmenu is: "+currentmenu+" buttonIndex:"+ buttonIndex);
                        //_DebugMenuVariables();
                        break;
                }
                break;
        }
        if (globalmode)
        {
            if (buttonIndex == NOT_SELECTED)
            {
                _GlobalModeVarSync();
            }
            else
            {
                TakeOwnership();
                _GlobalModeVarSync();
            }

        }

    }
    /***************************************************************************************************************************
	Sync Global Vars
	***************************************************************************************************************************/
    private void _GlobalModeVarSync()
    {
        bool isOwner = Networking.IsOwner(gameObject);
        if (isOwner)
        {
            globalcurrentlang = currentlang;
            globalcurrentlesson = currentlesson;
            globalcurrentword = currentword;
        }
        else
        {//not the owner, so update board vars from global vars
            currentlang = globalcurrentlang;
            currentlesson = globalcurrentlesson;
            currentword = globalcurrentword;
        }
    }

    /***************************************************************************************************************************
	Update all displays, including Menu, VRC Player, Nana, etc.
	***************************************************************************************************************************/
    private void _UpdateAllDisplays()
    {
        int currentmenu = _GetCurrentMenu();
        switch (currentmenu)
        {
            case MENU_LANGUAGE:
                _DisplayLanguageSelectMenu();
                break;
            case MENU_LESSON:
                _DisplayLessonSelectMenu();
                break;
            case MENU_WORD:
                _DisplayWordSelectMenu();
                _DisplaySign();
                _DisplayVideo();
                break;
            default:
                //Debug.Log("UpdateMenuDisplay() failed; currentmenu is: "+currentmenu+")");
                //_DebugMenuVariables();
                break;
        }

        // Update Subheader
        String text = globalmode ? "Global Mode" : "Local Mode";
        text = currentmode == MODE_QUIZ ? text + " - Quiz Mode" : text + " - Lookup Mode";
        menusubheadertext.text = text;
    }

    /***************************************************************************************************************************
	Calculate and return the current Menu state.
	***************************************************************************************************************************/
    private int _GetCurrentMenu()
    {
        int currentmenu = 0;
        if (currentlang == NOT_SELECTED)
        {
            currentmenu = MENU_LANGUAGE;
        }
        else
        {
            if (currentlesson == NOT_SELECTED)
            {
                currentmenu = MENU_LESSON;
            }
            else
            {
                currentmenu = MENU_WORD;
            }
        }
        return currentmenu;
    }


    /***************************************************************************************************************************
	Change Menu to display Language Selection.
	***************************************************************************************************************************/
    private void _DisplayLanguageSelectMenu()
    {
        // Handle Menu Header (Breadcrumb)
        menuheadertext.text = "VR Sign Language Select Menu";

        // Handle Selection Buttons
        for (int i = 0; i < numofbuttons; i++)
        {
            if (i < signlanguagenames.Length)
            {
                _DisplayButton(i, (i + 1) + ") " + signlanguagenames[i][1], false, false, "");
                _HideVRIcon(i);
            }
            else
            {
                _HideButton(i);
            }
        }

        // Handle Navigation Buttons
        backbuttons[0].SetActive(false);
        backbuttons[1].SetActive(false);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
    }

    /***************************************************************************************************************************
	Change Menu to display Lesson Selection.
	***************************************************************************************************************************/
    private void _DisplayLessonSelectMenu()
    {
        // Handle Menu Header (Breadcrumb)
        menuheadertext.text = signlanguagenames[currentlang][0] + " Lesson Menu";

        // Handle Selection Buttons
        bool isButtonSelected = false;
        for (int i = 0; i < numofbuttons; i++)
        {
            if (i < AllLessons[currentlang].Length)
            {
                if (lessonnames[currentlang].Length > i)
                {
                    isButtonSelected = currentmode == MODE_QUIZ && quizlessonselection[currentlang][i] ? true : false;
                    _DisplayButton(i, (i + 1) + ") " + lessonnames[currentlang][i], isButtonSelected, false, "");
                    _HideVRIcon(i);
                }
            }
            else
            {
                _HideButton(i);
            }
        }

        // Handle Navigation Buttons
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        backbuttons[0].SetActive(true);
        backbuttons[1].SetActive(true);
    }

    /***************************************************************************************************************************
	Change Menu to display Word Selection.
	***************************************************************************************************************************/
    private void _DisplayWordSelectMenu()
    {
        // Handle Menu Header (Breadcrumb)
        menuheadertext.text = signlanguagenames[currentlang][0] + " - " + lessonnames[currentlang][currentlesson];

        // Handle Selection Buttons
        string buttonText;
        bool isButtonSelected;
        //bool isWordValid;
        //Debug.Log("numofbuttons:" + numofbuttons);
        for (int i = 0; i < numofbuttons; i++)
        {
            //Debug.Log("give me the data for: AllLessons[0][27][58][0]" + AllLessons[0][27][58][0]);
            if (i < AllLessons[currentlang][currentlesson].Length)
            { //prevent crashing if udon doesn't find the array data for some reason - udon array variable bug i think.
                //Debug.Log("working on button number: " + i);
                buttonText = "    " + (i + 1) + ") " + AllLessons[currentlang][currentlesson][i][0];
                isButtonSelected = currentword == i;
                //isWordValid = AllLessons[currentlang][currentlesson][i][5] == "TRUE";
                _DisplayButton(i, buttonText, isButtonSelected, true, AllLessons[currentlang][currentlesson][i][5]);
                _DisplayVRIcon(i);
            }
            else
            {
                _HideButton(i);
            }
        }

        // Handle Navigation Buttons
        backbuttons[0].SetActive(true);
        backbuttons[1].SetActive(true);

        if (currentword > 0)
        {
            prevButton.SetActive(true);
        }
        else
        {
            prevButton.SetActive(false);
        }
        if ((currentword + 1) < AllLessons[currentlang][currentlesson].Length && currentword != NOT_SELECTED)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }

    }

    /***************************************************************************************************************************
	Display the VR Icon for the given Button/Word Index.
	***************************************************************************************************************************/
    private void _DisplayVRIcon(int index)
    {
        //Debug.Log("switching on AllLessons[currentlang][currentlesson][index][3]:" + AllLessons[currentlang][currentlesson][index][3]);
        switch (AllLessons[currentlang][currentlesson][index][3])
        { //populate vr icons
            case "Y": // Knuckles Controller icon
                indexicons[index].SetActive(true);
                regvricons[index].SetActive(false);
                bothvricons[index].SetActive(false);
                break;
                /*
            case "1": // Standard VR Controller icon
                indexicons[index].SetActive(false);
                regvricons[index].SetActive(true);
                bothvricons[index].SetActive(false);
                break;*/
            case "": // Both Controller Types icon
                indexicons[index].SetActive(false);
                regvricons[index].SetActive(false);
                bothvricons[index].SetActive(true);
                break;
            default: //uhh how am I here? Is it null somehow? Maybe should set to both by default...
                Debug.Log("_DisplayVRIcon(" + index + ") had an invalid VR Icon setting; update AllLessons[currentlang][currentlesson][index][3]");
                indexicons[index].SetActive(false);
                regvricons[index].SetActive(false);
                bothvricons[index].SetActive(true);
                break;
        }
    }

    /***************************************************************************************************************************
	Hide the display for a VR icon at a specific index.
	***************************************************************************************************************************/
    private void _HideVRIcon(int index)
    {
        indexicons[index].SetActive(false);
        regvricons[index].SetActive(false);
        bothvricons[index].SetActive(false);
    }


    /***************************************************************************************************************************
	Display a Menu button at a specific index, with the given parameters.
	***************************************************************************************************************************/
    private void _DisplayButton(int index, string text, bool isSelected, bool isColored, string isValid)
    {

        // Handle Validation Highlighting
        if (isColored)
        {
            switch (isValid)
            { 
                // AllLessons[][][][5] = sign validation status 1 (red), 2 (yellow), 3 (green)
                case "1":
                    buttontext[index].color = COLOR_RED;
                    break;
                case "2":
                    buttontext[index].color = COLOR_YELLOW;
                    break;
                case "3":
                    buttontext[index].color = COLOR_GREEN;
                    break;
                default:
                    break;
            }
            //buttontext[index].color = isValid ? COLOR_GREEN : COLOR_RED; // Validated
        }
        else
        {
            buttontext[index].color = COLOR_WHITE; // Standard
        }

        // Handle Selection Highlighting
        buttons[index].GetComponent<Button>().colors = isSelected ? darkmodeselectedbutton : darkmodebutton;

        // Handle Text
        buttontext[index].text = text;

        // Toggle Display
        buttons[index].SetActive(true);
    }

    /***************************************************************************************************************************
	Hide the specified button.
	***************************************************************************************************************************/
    private void _HideButton(int index)
    {
        buttons[index].SetActive(false);
    }

    /***************************************************************************************************************************
	Display the sign on the MoCap Avatar
	***************************************************************************************************************************/
    private void _DisplaySign()
    {
        if (currentword != NOT_SELECTED)
        {
            // Update MoCap Avatar Visuals (Nana)
            // AllLessons[][][][0] = word 
            // AllLessons[][][][1] = mocap credits. 
            // AllLessons[][][][2] = video URL.
            // AllLessons[][][][3] = VR index or regular 0=indexonly , 1=generalvr, 2=both
            // AllLessons[][][][4] = Sign description string
            // AllLessons[][][][5] = sign validation status (1-3)
            // AllLessons[][][][6] = sign validation credits
            // AllLessons[][][][7] = sign validation comments
            currentsigntext.text = (currentlesson + 1) + "-" + (currentword + 1) + " " + AllLessons[currentlang][currentlesson][currentword][0];
            speechbubbletext.text = AllLessons[currentlang][currentlesson][currentword][0];
            //nana.Play(AllLessons[currentlang][currentlesson][currentword][1]); // TODO Look into Animation Transitions
            signcredittext.text = "The motion data for this sign was signed by: " + AllLessons[currentlang][currentlesson][currentword][1];
            descriptiontext.text = AllLessons[currentlang][currentlesson][currentword][4];
        }
    }
    /***************************************************************************************************************************
    Display the sign on the Video Player.
    ***************************************************************************************************************************/
    private void _DisplayVideo()
    {
        if (currentword != NOT_SELECTED)
        {
            // Update VRCPlayer Visual
            if (AllLessons[currentlang][currentlesson][currentword][2] != "")
            { // if url is blank, then don't look for the video
                if (langurls.Length > 0)
                { //don't crash the script if i forget to build langurls lol...
                    vrcplayercomponent.PlayURL(langurls[currentlang][currentlesson][currentword]);
                }
            }
        }
    }

    /***************************************************************************************************************************
	Button Handler for Previous/Next navigation button clicks on Word Selection for main Menu.
	***************************************************************************************************************************/
    private void _PreviousNextWordButtonPushed(bool isIncrementingWord)
    {
        Debug.Log("Entered _PreviousNextWordButtonPushed");
        int nextword = isIncrementingWord ? currentword + 1 : currentword - 1;
        int lessonLength = AllLessons[currentlang][currentlesson].Length;
        if (nextword >= 0 && nextword < lessonLength)
        {
            currentword = nextword;
            _DisplayWordSelectMenu();
            _DisplaySign();
            _DisplayVideo();
        }
    }

    /***************************************************************************************************************************
	Button Handler for Back button click on Menu.
	***************************************************************************************************************************/
    private void _BackButtonPushed()
    {
        Debug.Log("Entered _BackButtonPushed");
        if (globalmode)
        {
            //SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ChangeState");
        }
        direction = BACKWARDS;
        _UpdateMenuVariables(NOT_SELECTED);
        _UpdateAllDisplays();
    }

    /***************************************************************************************************************************
	Figures out if the button pushed is the correct one. Displays corrisponding status screen if correct, or try again.
	***************************************************************************************************************************/
    public void _QuizResetButtonPushed()
    {
        Debug.Log("Entered _QuizResetButtonPushed");
        quiza.SetActive(false);
        quizb.SetActive(false);
        quizc.SetActive(false);
        quizd.SetActive(false);
        quizbig.SetActive(true);
        quizreset.SetActive(false);
        quizinprogress = false;
        quiztext.text = "Quiz";
        quiztext2.text = "Select lessons and then push the big button below to generate a quiz";
        quiztext3.text = "";
        quizp.transform.Find("Text3 (TMP)").gameObject.SetActive(false);
        quizbig.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Start Quiz";
    }


    /***************************************************************************************************************************
	Figures out if the button pushed is the correct one. Displays corrisponding status screen if correct, or try again.
	***************************************************************************************************************************/
    private void _QuizAnswerButtonPushed(int x)
    {
        Debug.Log("Entered _QuizAnswerButtonPushed with x:" + x);
        //Debug.Log("Quizcounter:"+quizcounter+" numofwordsselected:"+numofwordsselected);
        quiza.SetActive(false);
        quizb.SetActive(false);
        quizc.SetActive(false);
        quizd.SetActive(false);


        if (x == quizanswer)
        {
            //hide buttons, display correct + tally score/consequetive answer streak??
            //display continue button?
            quizscore++;
            quiztext.text = "Quiz Started. Progress: " + (quizcounter + 1) + " of " + numofwordsselected;
            quiztext2.text = "Score: " + quizscore;
            if (quizcounter != (numofwordsselected - 1))
            {
                quizbig.SetActive(true);
                quizbig.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Correct\n✓\nClick to continue";
            }
            else
            {
                quizbig.SetActive(false);
                quizp.transform.Find("Text3 (TMP)").gameObject.SetActive(true);
                quiztext.text = "Quiz Finished. Progress: " + (quizcounter + 1) + " of " + numofwordsselected;
                quiztext2.text = "Final Score: " + quizscore + " Percent Correct:" + (int)(((decimal)quizscore / (decimal)numofwordsselected) * 100) + "%";
                quiztext3.text = "Correct\n✓\nYou've reached the end of the quiz.\nYou can now change selected lessons and regenerate the quiz by pushing the reset quiz button.";
                //Debug.Log("quizscore:"+quizscore+" numofwordsselected:"+numofwordsselected+" quizscore/numofwordsselected:"+(int)(((decimal)quizscore/(decimal)numofwordsselected)*100));
                quizinprogress = false;
            }

        }
        else
        {
            if (quizcounter != (numofwordsselected - 1))
            {
                quizbig.SetActive(true);

                quizbig.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Incorrect - the correct answer was: " + AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0] + "\n✗\nClick to continue";
            }
            else
            {
                quizbig.SetActive(false);
                quizp.transform.Find("Text3 (TMP)").gameObject.SetActive(true);
                quiztext.text = "Quiz Finished. Progress: " + (quizcounter + 1) + " of " + numofwordsselected;
                quiztext2.text = "Final Score: " + quizscore + " Percent Correct:" + (int)(((decimal)quizscore / (decimal)numofwordsselected) * 100) + "%";
                quiztext3.text = "Incorrect - the correct answer was: " + AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0] + "\n✗\nYou've reached the end of the quiz.\nYou can now change selected lessons and regenerate the quiz by pushing the reset quiz button.";
                //Debug.Log("quizscore:"+quizscore+" numofwordsselected:"+numofwordsselected+" quizscore/numofwordsselected:"+(int)(((decimal)quizscore/(decimal)numofwordsselected)*100));
                quizinprogress = false;
            }
            //display incorrect. try again or move to next question? Perhaps marking which lessons/words they got wrong would be nice.
        }
        quizcounter++;
    }

    /***************************************************************************************************************************
	Generates list of words from selected lessons, starts the quiz
	***************************************************************************************************************************/
    public void _QuizBigButtonPushed()
    {
        Debug.Log("Entered QuizBigButtonPushed");

        //UnityEngine.Random.Range(0,quizarray.Length+1)


        if (!quizinprogress)
        {
            quizcounter = 0;
            quizscore = 0;
            //quizanswerstreak=0;
            numofwordsselected = 0;

            //for each selected language/lesson, loop through and count how many total valid signs, to init proper array size.
            for (int lang = 0; lang < quizlessonselection.Length; lang++)
            {
                //Debug.Log("AllLessons[x].Length: "+ inspectorBehaviour.AllLessons[x].Length);
                for (int lesson = 0; lesson < quizlessonselection[lang].Length; lesson++)
                {
                    for (int word = 0; word < AllLessons[lang][lesson].Length; word++)
                    {
                        if (quizlessonselection[lang][lesson] && //if the lesson exists
                        AllLessons[lang][lesson][word][5] == "3" && //and if the sign is validated
                        AllLessons[lang][lesson][word][2] != "") // and if the video url exists
                        {//if the lesson is selected
                         //add all words to the array if verified
                            numofwordsselected++;
                        }

                    }
                    //Debug.Log("lang num:"+lang + " lessonnum"+lesson + quizlessonselection[lang][lesson]);
                }
            }
            //Debug.Log("numofwordsselected:"+numofwordsselected);
            //now that we have the total number of signs, initialize the wordmapping array, and populate with pointers to the selected lessons.
            if (numofwordsselected != 0)
            {
                quizwordmapping = new int[numofwordsselected][];
                int x = 0;
                for (int lang = 0; lang < quizlessonselection.Length; lang++)
                {
                    //Debug.Log("AllLessons[x].Length: "+ inspectorBehaviour.AllLessons[x].Length);
                    for (int lesson = 0; lesson < quizlessonselection[lang].Length; lesson++)
                    {
                        for (int word = 0; word < AllLessons[lang][lesson].Length; word++)
                        {
                            if (quizlessonselection[lang][lesson] && //if the lesson exists
                            AllLessons[lang][lesson][word][5] == "3" && //and if the sign is validated
                            AllLessons[lang][lesson][word][2] != "") // and if the video url exists
                            {//if the lesson is selected
                             //add all words to the array if verified
                                quizwordmapping[x] = new int[3];
                                quizwordmapping[x][0] = lang;
                                quizwordmapping[x][1] = lesson;
                                quizwordmapping[x][2] = word;
                                x++;
                            }


                        }
                        //Debug.Log("lang num:"+lang + " lessonnum"+lesson + quizlessonselection[lang][lesson]);
                    }
                }
                for (int t = 0; t < quizwordmapping.Length; t++)// Knuth shuffle algorithm
                {
                    int[] tmp = quizwordmapping[t];
                    int r = UnityEngine.Random.Range(t, quizwordmapping.Length);
                    quizwordmapping[t] = quizwordmapping[r];
                    quizwordmapping[r] = tmp;
                }
                quizbig.SetActive(false);
                quizp.transform.Find("Text3 (TMP)").gameObject.SetActive(false);
                quizinprogress = true;
                /*
                Debug.Log("shuffled results:");
                for (int t = 0; t < quizwordmapping.Length; t++ )
                {
                    Debug.Log("number "+t+" values"+quizwordmapping[t][0]+"-"+quizwordmapping[t][01]+"-"+quizwordmapping[t][2]);
                }
                */
            }
            else
            {
                //Debug.Log("Exiting big button because no lessons are selected");
                quiztext2.text = "Error: No lessons/words selected.";
            }

        }
        if (quizinprogress)
        {
            quiztext.text = "Quiz Started. Progress: " + (quizcounter + 1) + " of " + numofwordsselected;
            quiztext2.text = "Score: " + quizscore;
            quiza.SetActive(true);
            quizb.SetActive(true);
            quizc.SetActive(true);
            quizd.SetActive(true);
            quizbig.SetActive(false);
            quizreset.SetActive(true);
            quizanswer = UnityEngine.Random.Range(0, 4);//pick one of the 4 boxes to have the answer 0-3
            int quizwrong1 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            int quizwrong2 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            int quizwrong3 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            //prevent the same answer on multiple boxes.
            while (
                quizwrong1 == quizcounter | //don't be the same as the answer
                AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0].Contains("Variant") | //todo, add "base word" for script to check against to avoid pulling variants.
                AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0].Contains("/") |
                AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0] //prevent the same answer on multiple boxes.
                )
            {
                quizwrong1 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            }
            while (quizwrong2 == quizcounter | //don't be the same as the answer
                quizwrong2 == quizwrong1 | //don't be the same as box 1
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0].Contains("Variant") |
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0].Contains("/") |
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0] //prevent the same answer on multiple boxes.
                )
            {
                quizwrong2 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            }
            while (quizwrong3 == quizcounter | //don't be the same as the answer
                quizwrong3 == quizwrong1 | //don't be the same as box 1
                quizwrong3 == quizwrong2 | //don't be the same as box 2
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0].Contains("Variant") |
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0].Contains("/") |
                AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][0] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0]  //prevent the same answer on multiple boxes.
                )
            {
                quizwrong3 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            }
            switch (quizanswer)//quizanswer is the box the answer is in. The answer is stored in quizcounter.
            {
                case 0:
                    quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0];
                    quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0];
                    quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0];
                    quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][0];
                    break;
                case 1:
                    quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0];
                    quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0];
                    quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0];
                    quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][0];
                    break;
                case 2:
                    quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0];
                    quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0];
                    quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0];
                    quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][0];
                    break;
                case 3:
                    quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][0];
                    quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][0];
                    quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][0];
                    quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][0];
                    break;
                default:
                    Debug.Log("How is quizanswer outside of the expected random range?");
                    break;
            }
            //nana.Play(AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][1]);
            //add something to hide the sidebar of videos here?
            if (quizwordmapping[quizcounter][0] != 0)
            {//if it's not ASL, play the video
                if (AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][2] != "")
                { // if url is blank, then don't look for the video
                    if (langurls.Length > 0)
                    { //don't crash the script if i forget to build langurls lol...
                        vrcplayercomponent.PlayURL(langurls[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]]);
                    }
                }
            }

        }

    }


    /***************************************************************************************************************************
	Update loop - if not the owner and global mode is enabled checks for updates to the global variables, and updates the board to follow.
	***************************************************************************************************************************/
    private void Update()
    {
        bool isOwner = Networking.IsOwner(gameObject);
        if (!isOwner & globalmode)
        { //only activate if global mode is on and if they're not the owner of the board.
            if (globalcurrentmode != currentmode ||
            globalcurrentlang != currentlang ||
            globalcurrentlesson != currentlesson ||
            globalcurrentword != currentword)
            {
                _UpdateMenuVariables(NOT_SELECTED);
                _UpdateAllDisplays();
            }
        }
        //_DebugMenuVariables();
    }

    /***************************************************************************************************************************
	Figures out what the button does, and sends to the approperate functions to update the menu.
	***************************************************************************************************************************/
    private void _buttonpushed(int buttonIndex)
    {
        Debug.Log("Entered _buttonpushed(" + buttonIndex + ")");

        // Update Data
        _UpdateMenuVariables(buttonIndex);

        // Update Display
        _UpdateAllDisplays();
    }

    /***************************************************************************************************************************
	Takes ownership of the board udonbehavior to update variables?
	***************************************************************************************************************************/
    public void TakeOwnership()
    {
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }
    }

    /***************************************************************************************************************************
	Changes selected array to true for given lesson. Change button color to indicate selected.
	***************************************************************************************************************************/
    private void _SelectQuizLesson(int x)
    { //I don't need the lesson number here because I'm displaying all lessons.
        Debug.Log("Now entering _SelectQuizLesson with a language number of " + currentlang + " and a button number of x:" + x);
        if (quizlessonselection[currentlang][x] == false)
        {
            buttons[x].GetComponent<Button>().colors = darkmodeselectedbutton;
            quizlessonselection[currentlang][x] = true;
        }
        else
        {
            buttons[x].GetComponent<Button>().colors = darkmodebutton;
            quizlessonselection[currentlang][x] = false;
        }

    }



    /***************************************************************************************************************************
	Outputs debug vars to log or panel
	***************************************************************************************************************************/
    private void _DebugMenuVariables()
    {
        //String _message = "";
        /*
		debugtextbox.text="Current Variable contents: " +
			"\nOwner: " + Networking.IsOwner(gameObject) + 
			"\ncurrentmode: " + currentmode + " globalcurrentmode: " + globalcurrentmode +
			"\ncurrentlang: " + currentlang + " globalcurrentlang: " + globalcurrentlang + 
			"\ncurrentlesson: " + currentlesson + " globalcurrentlesson: " + globalcurrentlesson + 
			"\ncurrentword: " + currentword + " globalcurrentword: " + globalcurrentword;

		

				*/
    }


    /***************************************************************************************************************************
	Handle VRCPlayer Error
	***************************************************************************************************************************/
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

    /***************************************************************************************************************************
	Called to scale signing avatar gameobject
	***************************************************************************************************************************/
    public void AvatarScaleSliderValueChanged()
    {
        signingavatars.transform.localScale = new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value);
    }


    /***************************************************************************************************************************
	Called to switch the signing avatar's mirror animation parameter and set the toggle box state. 
	***************************************************************************************************************************/
    public void ToggleHand()
    {
        if (!nana.GetBool("Mirror"))
        { //if mirror checkbox is off
            nana.SetBool("Mirror", true);
            videoplayer.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            nana.SetBool("Mirror", false);
            videoplayer.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    /***************************************************************************************************************************
	Called to switch the board to global mode and set the toggle box state
	***************************************************************************************************************************/
    public void ToggleGlobal()
    {
        globalmode = !globalmode;
        _UpdateMenuVariables(NOT_SELECTED);
        _UpdateAllDisplays();
    }


    /***************************************************************************************************************************
	Called to switch the board to quiz mode
	Handles enabling/disabling ui elements
	***************************************************************************************************************************/
    public void ToggleQuiz()
    {
        Debug.Log("Entered ToggleQuiz with quizmode: " + (currentmode == MODE_QUIZ));
        if (!(currentmode == MODE_QUIZ))
        {
            currentmode = MODE_QUIZ;
        }
        else
        {
            currentmode = MODE_LOOKUP;
        }
        currentlang = NOT_SELECTED;
        currentlesson = NOT_SELECTED;
        currentword = NOT_SELECTED;
        quizp.SetActive(currentmode == MODE_QUIZ);
        quiza.SetActive(!(currentmode == MODE_QUIZ));
        quizb.SetActive(!(currentmode == MODE_QUIZ));
        quizc.SetActive(!(currentmode == MODE_QUIZ));
        quizd.SetActive(!(currentmode == MODE_QUIZ));
        quizreset.SetActive(false);
        quizbig.SetActive(currentmode == MODE_QUIZ);

        if (signingavatars.transform.Find("Nana Avatar (SM)").gameObject.activeInHierarchy)
        {
            signingavatars.transform.Find("Nana Avatar (SM)/Canvas").gameObject.SetActive(!(currentmode == MODE_QUIZ));
        }

        nextButton.SetActive(!(currentmode == MODE_QUIZ));
        prevButton.SetActive(!(currentmode == MODE_QUIZ));
        currentsign.SetActive(!(currentmode == MODE_QUIZ));
        signcredit.SetActive(!(currentmode == MODE_QUIZ));
        description.SetActive(!(currentmode == MODE_QUIZ));
        nana.Play("Idle");
        quiztext.text = "Quiz";
        quiztext2.text = "Select lessons and then push the big button below to generate a quiz";
        quizbig.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Start Quiz";
        quizinprogress = false;

        _UpdateAllDisplays();
    }

    /***************************************************************************************************************************
	Register Button Handlers
	***************************************************************************************************************************/
    public void NextB()
    {
        _PreviousNextWordButtonPushed(true);
    }
    public void PrevB()
    {
        _PreviousNextWordButtonPushed(false);
    }
    public void BackB()
    {
        _BackButtonPushed();
    }
    public void _QuizA()
    {
        _QuizAnswerButtonPushed(0);
    }
    public void _QuizB()
    {
        _QuizAnswerButtonPushed(1);
    }
    public void _QuizC()
    {
        _QuizAnswerButtonPushed(2);
    }
    public void _QuizD()
    {
        _QuizAnswerButtonPushed(3);
    }
    public void B0()
    {
        _buttonpushed(0);
    }
    public void B1()
    {
        _buttonpushed(1);
    }
    public void B2()
    {
        _buttonpushed(2);
    }
    public void B3()
    {
        _buttonpushed(3);
    }
    public void B4()
    {
        _buttonpushed(4);
    }
    public void B5()
    {
        _buttonpushed(5);
    }
    public void B6()
    {
        _buttonpushed(6);
    }
    public void B7()
    {
        _buttonpushed(7);
    }
    public void B8()
    {
        _buttonpushed(8);
    }
    public void B9()
    {
        _buttonpushed(9);
    }
    public void B10()
    {
        _buttonpushed(10);
    }
    public void B11()
    {
        _buttonpushed(11);
    }
    public void B12()
    {
        _buttonpushed(12);
    }
    public void B13()
    {
        _buttonpushed(13);
    }
    public void B14()
    {
        _buttonpushed(14);
    }
    public void B15()
    {
        _buttonpushed(15);
    }
    public void B16()
    {
        _buttonpushed(16);
    }
    public void B17()
    {
        _buttonpushed(17);
    }
    public void B18()
    {
        _buttonpushed(18);
    }
    public void B19()
    {
        _buttonpushed(19);
    }
    public void B20()
    {
        _buttonpushed(20);
    }
    public void B21()
    {
        _buttonpushed(21);
    }
    public void B22()
    {
        _buttonpushed(22);
    }
    public void B23()
    {
        _buttonpushed(23);
    }
    public void B24()
    {
        _buttonpushed(24);
    }
    public void B25()
    {
        _buttonpushed(25);
    }
    public void B26()
    {
        _buttonpushed(26);
    }
    public void B27()
    {
        _buttonpushed(27);
    }
    public void B28()
    {
        _buttonpushed(28);
    }
    public void B29()
    {
        _buttonpushed(29);
    }
    public void B30()
    {
        _buttonpushed(30);
    }
    public void B31()
    {
        _buttonpushed(31);
    }
    public void B32()
    {
        _buttonpushed(32);
    }
    public void B33()
    {
        _buttonpushed(33);
    }
    public void B34()
    {
        _buttonpushed(34);
    }
    public void B35()
    {
        _buttonpushed(35);
    }
    public void B36()
    {
        _buttonpushed(36);
    }
    public void B37()
    {
        _buttonpushed(37);
    }
    public void B38()
    {
        _buttonpushed(38);
    }
    public void B39()
    {
        _buttonpushed(39);
    }
    public void B40()
    {
        _buttonpushed(40);
    }
    public void B41()
    {
        _buttonpushed(41);
    }
    public void B42()
    {
        _buttonpushed(42);
    }
    public void B43()
    {
        _buttonpushed(43);
    }
    public void B44()
    {
        _buttonpushed(44);
    }
    public void B45()
    {
        _buttonpushed(45);
    }
    public void B46()
    {
        _buttonpushed(46);
    }
    public void B47()
    {
        _buttonpushed(47);
    }
    public void B48()
    {
        _buttonpushed(48);
    }
    public void B49()
    {
        _buttonpushed(49);
    }
    public void B50()
    {
        _buttonpushed(50);
    }
    public void B51()
    {
        _buttonpushed(51);
    }
    public void B52()
    {
        _buttonpushed(52);
    }
    public void B53()
    {
        _buttonpushed(53);
    }
    public void B54()
    {
        _buttonpushed(54);
    }
    public void B55()
    {
        _buttonpushed(55);
    }
    public void B56()
    {
        _buttonpushed(56);
    }
    public void B57()
    {
        _buttonpushed(57);
    }
    public void B58()
    {
        _buttonpushed(58);
    }
    public void B59()
    {
        _buttonpushed(59);
    }
    public void B60()
    {
        _buttonpushed(60);
    }
    public void B61()
    {
        _buttonpushed(61);
    }
    public void B62()
    {
        _buttonpushed(62);
    }
    public void B63()
    {
        _buttonpushed(63);
    }
    public void B64()
    {
        _buttonpushed(64);
    }
    public void B65()
    {
        _buttonpushed(65);
    }
    public void B66()
    {
        _buttonpushed(66);
    }
    public void B67()
    {
        _buttonpushed(67);
    }
    public void B68()
    {
        _buttonpushed(68);
    }
    public void B69()
    {
        _buttonpushed(69);
    }


    /***************************************************************************************************************************
	Override the Inspector to populate VRC Urls and Generate a dictionary of signs/words
	***************************************************************************************************************************/

#if !COMPILER_UDONSHARP && UNITY_EDITOR
    [CustomEditor(typeof(MenuControl))]
    public class CustomInspectorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;
            MenuControl inspectorBehaviour = (MenuControl)target;

            if (GUILayout.Button("Populate VRCUrls"))
            {

                inspectorBehaviour.langurls = new VRCUrl[inspectorBehaviour.AllLessons.Length][][];
                for (int x = 0; x < inspectorBehaviour.AllLessons.Length; x++)
                {
                    //Debug.Log("AllLessons[x].Length: "+ inspectorBehaviour.AllLessons[x].Length);
                    VRCUrl[][] lessonurls = new VRCUrl[inspectorBehaviour.AllLessons[x].Length][];

                    for (int y = 0; y < inspectorBehaviour.AllLessons[x].Length; y++)
                    {

                        //Debug.Log("AllLessons[x][y].Length: "+ inspectorBehaviour.AllLessons[x][y].Length);
                        VRCUrl[] wordurls = new VRCUrl[inspectorBehaviour.AllLessons[x][y].Length];
                        for (int z = 0; z < inspectorBehaviour.AllLessons[x][y].Length; z++)
                        {
                            wordurls[z] = new VRCUrl(inspectorBehaviour.AllLessons[x][y][z][2]);
                        }
                        lessonurls[y] = wordurls;
                    }
                    inspectorBehaviour.langurls[x] = lessonurls;
                }
                Debug.Log("URLS populated");
                string erratatext = "";
                // Generate index of all words, sorted.
                List<List<String>> listofallwords = new List<List<string>>();

                //Debug.Log("AllLessons.Length: " + inspectorBehaviour.AllLessons[0].Length);
                for (int x = 0; x < inspectorBehaviour.AllLessons[0].Length; x++)
                {
                    erratatext = erratatext + "<b>Lesson " + (x + 1) + " - " + inspectorBehaviour.lessonnames[0][x] + "</b>\n";
                    //Debug.Log("x: "+x); 

                    //Debug.Log("whatlessonnum:" + x);
                    if ((x + 1) != 28)
                    {
                        //Debug.Log("awhatlessonnum:" + x);
                        for (int y = 0; y < inspectorBehaviour.AllLessons[0][x].Length; y++)
                        {
                            List<String> worddata = new List<String>();
                            worddata.Add(inspectorBehaviour.AllLessons[0][x][y][0]);
                            //Debug.Log(inspectorBehaviour.AllLessons[0][x][y][0]  + " L" + (x+1) + "-" + (y+1));
                            worddata.Add("L" + (x + 1) + "-" + (y + 1));
                            listofallwords.Add(worddata);

                            //add errata data
                            if (inspectorBehaviour.AllLessons[0][x][y][7] != "")
                            {
                                erratatext = erratatext + "\nL" + (x + 1) + "-" + (y + 1) + " [" + inspectorBehaviour.AllLessons[0][x][y][0] + "]: " + inspectorBehaviour.AllLessons[0][x][y][7];
                            }

                        }
                    }

                }

                listofallwords = listofallwords.OrderBy(l => l[0]).ToList();
                string dictionarytext = "";
                foreach (var word in listofallwords)
                {
                    dictionarytext = dictionarytext + word[0] + " " + word[1] + "\n";
                    //Console.Write(word[0]+" "+word[5]+"\n");
                }
                FindInActiveObjectByName("DictionaryText").GetOrAddComponent<TextMeshProUGUI>().text = dictionarytext;
                Debug.Log("Index Populated");

                FindInActiveObjectByName("ErrataText").GetOrAddComponent<TextMeshProUGUI>().text = erratatext;
                Debug.Log("Errata populated");
                //todo, if parameters are supported by buttons. Instantiate buttons instead of text, to allow jumping direct to a specific word.

            }
        }
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
#endif

}