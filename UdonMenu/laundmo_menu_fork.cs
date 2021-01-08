using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class menu : UdonSharpBehaviour
{

    public string [][][] buttonStates; 
    public string[][] animations;
    public string [] credits = {"This sign was recorded by: GT4tube", "This sign was recorded by: Placeholder", "No Data Yet.","This sign was verified by: Ray_is_Deaf"};
    public GameObject[] unityButtons =new GameObject[56]; // list of all the unity button objects for editeing text etc.
    public Text[] unityButtonsText = new Text[56]; //the text corrisponding to those buttons
    public GameObject[] backButtons = new GameObject[2];
    public Text[] backButtonstext = new Text[2];
    public GameObject[] indexicons = new GameObject[56];
    public GameObject[] regvricons = new GameObject[56];
    public GameObject[] bothvricons = new GameObject[56];
    public int currentPage = 0;
    public int currentWord = 0;
    public int currentLanguage = 0;
    public Animator nana = GameObject.Find ("/Nana Avatar").GetComponent<Animator>();
    public Text currentsigntext = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>();
    public Text speechbubbletext = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text").GetComponent<Text>();
    public Text signcredittext = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text").GetComponent<Text>();
    public Text descriptiontext = GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text").GetComponent<Text>();
    public Text menuheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header").GetComponent<Text>();
    public GameObject nextButton = GameObject.Find("Udon Menu System/Root Canvas/Menu Buttons/NextButton");
    public GameObject prevButton = GameObject.Find("Udon Menu System/Root Canvas/Menu Buttons/PrevButton");
    public InputField videoURL = GameObject.Find("/VideoCanvas/Player").GetComponent<InputField>();
    public Animator videoPlayEvent = GameObject.Find("/VideoCanvas/Player/PlayEvent").GetComponent<Animator>();
    public Animator videoStopEvent = GameObject.Find("/VideoCanvas/Player/StopEvent").GetComponent<Animator>();
	string [] menuheadername = new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language.
	"VR Sign Language Select Menu","VR-ASL Lesson Menu","Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Alphabet/Numbers (Fingerspelling)",
    "Verbs & Actions p1","Verbs & Actions p2: Ben-Cor","Verbs & Actions p3: Cou-Esc","Verbs & Actions p4: Exc-Ins","Verbs & Actions p5: Int-Pas","Verbs & Actions p6: Pat-Sav",
    "Verbs & Actions p7: Say-Try","Verbs & Actions p8","Food","Animals/Machines","Places","Stuff/Weather","Clothes/Equipment","Fantasy/Characters",	"Holidays/Special Days","Home Stuff","Nature/Environment","Talk/Asking Exercises",
	"Sign Names","Countries","Colors","Medical"};
    string [][] signlanguagenames;

    void Start()
    {
        signlanguagenames= new string[][]{
            new string[]{"ASL","American Sign Language"},
            new string[]{"BSL","British Sign Language"},
        };
        buttonStates = new string[][][]{ //think of this as pages on the existing menu.
new string[][]{//lang select
new string[]{"b","0","Back Button","0"},
new string[]{"b","1","American Sign Language","0"},
},
new string[][]{//Lesson Menu
new string[]{"b","0","Back Button","0"},
new string[]{"b","2","Daily Use","0"},
new string[]{"b","3","Pointing use Question/Answer","0"},      
new string[]{"b","4","Common","0"},
new string[]{"b","5","People","0"},
new string[]{"b","6","Feelings/Reactions","0"},
new string[]{"b","7","Value","0"},
new string[]{"b","8","Time","0"},
new string[]{"b","9","VRChat","0"},
new string[]{"b","10","Alphabet/Numbers (Fingerspelling)","0"},
new string[]{"b","11","Verbs & Actions p1","0"},
new string[]{"b","12","Verbs & Actions p2: Ben-Cor","0"},
new string[]{"b","13","Verbs & Actions p3: Cou-Esc","0"},
new string[]{"b","14","Verbs & Actions p4: Exc-Ins","0"},
new string[]{"b","15","Verbs & Actions p5: Int-Pas","0"},
new string[]{"b","16","Verbs & Actions p6: Pat-Sav","0"},
new string[]{"b","17","Verbs & Actions p7: Say-Try","0"},
new string[]{"b","18","Common (Signed by GT4tube)","0"},
},
new string[][]{//Word Menu for Lesson 1 - Daily Use
new string[]{"b","0","Back Button","1"},
new string[]{"a","1","Hello","0"},
new string[]{"a","2","How (are) You","0"},
new string[]{"a","3","What's Up?","0"},
new string[]{"a","4","What's Up? (Variant 2)","0"},
new string[]{"a","5","Nice (to) Meet You","0"},
new string[]{"a","6","Good","0"},
new string[]{"a","7","Bad","0"},
new string[]{"a","8","Yes","0"},
new string[]{"a","9","No","0"},
new string[]{"a","10","So-So","0"},
new string[]{"a","11","Sick","0"},
new string[]{"a","12","Sick","0"},
new string[]{"a","13","Hurt","0"},
new string[]{"a","14","You're Welcome","0"},
new string[]{"a","15","Goodbye","0"},
new string[]{"a","16","Good Morning","0"},
new string[]{"a","17","Good Afternoon","0"},
new string[]{"a","18","Good Evening","0"},
new string[]{"a","19","Good Night","0"},
new string[]{"a","20","See You Later","0"},
new string[]{"a","21","Please","0"},
new string[]{"a","22","Sorry","0"},
new string[]{"a","23","Forget","0"},
new string[]{"a","24","Sleep","0"},
new string[]{"a","25","Bed","0"},
new string[]{"a","26","Jump/Change World","0"},
new string[]{"a","27","Thank You","0"},
new string[]{"a","28","I Love You","0"},
new string[]{"a","29","ILY (I Love You)","0"},
new string[]{"a","30","Go Away","0"},
new string[]{"a","31","Going To","0"},
new string[]{"a","32","Follow","0"},
new string[]{"a","33","Come","0"},
new string[]{"a","34","Hearing (Person)","0"},
new string[]{"a","35","Deaf","0"},
new string[]{"a","36","Deaf (Variant 2)","0"},
new string[]{"a","37","Hard of Hearing","0"},
new string[]{"a","38","Mute","0"},
new string[]{"a","39","Write Slow","0"},
new string[]{"a","40","Can't Read","0"},
new string[]{"a","41","Away","0"},
},
new string[][]{//Word Menu for Lesson 2 - Pointing use Question/Answer
new string[]{"b","0","Back Button","1"},
new string[]{"a","42","I (Me)","0"},
new string[]{"a","43","My","0"},
new string[]{"a","44","Your","0"},
new string[]{"a","45","His","0"},
new string[]{"a","46","Her","0"},
new string[]{"a","47","We","0"},
new string[]{"a","48","They","0"},
new string[]{"a","49","Their","0"},
new string[]{"a","50","Over There","0"},
new string[]{"a","51","Our","0"},
new string[]{"a","52","It's","0"},
new string[]{"a","53","Inside","0"},
new string[]{"a","54","Outside","0"},
new string[]{"a","55","Outside (Outdoors)","0"},
new string[]{"a","56","Hidden","0"},
new string[]{"a","57","Behind","0"},
new string[]{"a","58","Above","0"},
new string[]{"a","59","Below","0"},
new string[]{"a","60","Here","0"},
new string[]{"a","61","Beside","0"},
new string[]{"a","62","Back","0"},
new string[]{"a","63","Front","0"},
new string[]{"a","64","Who","0"},
new string[]{"a","65","Where","0"},
new string[]{"a","66","When","0"},
new string[]{"a","67","Why","0"},
new string[]{"a","68","Which","0"},
new string[]{"a","69","What","0"},
new string[]{"a","70","What (Variant 2)","0"},
new string[]{"a","71","How","0"},
new string[]{"a","72","How (Variant 2)","0"},
new string[]{"a","73","How Many","0"},
new string[]{"a","74","How Many (Variant 2)","0"},
new string[]{"a","75","Can","0"},
new string[]{"a","76","Can't","0"},
new string[]{"a","77","Want","0"},
new string[]{"a","78","Have","0"},
new string[]{"a","79","Get","0"},
new string[]{"a","80","Will/Future","0"},
new string[]{"a","81","Take (Up)","0"},
new string[]{"a","82","Need","0"},
new string[]{"a","83","Must","0"},
new string[]{"a","84","Not","0"},
new string[]{"a","85","Or","0"},
new string[]{"a","86","And","0"},
new string[]{"a","87","For","0"},
new string[]{"a","88","At","0"},
new string[]{"a","89","At (Variant 2)","0"},
},
new string[][]{//Word Menu for Lesson 3 - Common
new string[]{"b","0","Back Button","1"},
new string[]{"a","90","Teach","0"},
new string[]{"a","91","Learn","0"},
new string[]{"a","92","Person","0"},
new string[]{"a","93","Student","0"},
new string[]{"a","94","Teacher","0"},
new string[]{"a","95","Friend","0"},
new string[]{"a","96","Sign","0"},
new string[]{"a","97","Language","0"},
new string[]{"a","98","Understand","0"},
new string[]{"a","99","Know","0"},
new string[]{"a","100","Don't Know","0"},
new string[]{"a","101","Be Right Back (BRB)","0"},
new string[]{"a","102","Accept","0"},
new string[]{"a","103","Denied","0"},
new string[]{"a","104","Name","0"},
new string[]{"a","105","New","0"},
new string[]{"a","106","Old","0"},
new string[]{"a","107","Very","0"},
new string[]{"a","108","Jokes","0"},
new string[]{"a","109","Funny","0"},
new string[]{"a","110","Play","0"},
new string[]{"a","111","Favorite","0"},
new string[]{"a","112","Draw","0"},
new string[]{"a","113","Stop","0"},
new string[]{"a","114","Read","0"},
new string[]{"a","115","Make","0"},
new string[]{"a","116","Write","0"},
new string[]{"a","117","Again/Repeat","0"},
new string[]{"a","118","Slow","0"},
new string[]{"a","119","Fast","0"},
new string[]{"a","120","Rude","0"},
new string[]{"a","121","Eat","0"},
new string[]{"a","122","Drink","0"},
new string[]{"a","123","Watch","0"},
new string[]{"a","124","Work","0"},
new string[]{"a","125","Live","0"},
new string[]{"a","126","Play Game","0"},
new string[]{"a","127","Same","0"},
new string[]{"a","128","Alright","0"},
new string[]{"a","129","People","0"},
new string[]{"a","130","Browsing the Internet","0"},
new string[]{"a","131","Movie","0"},
},
new string[][]{//Word Menu for Lesson 4 - People
new string[]{"b","0","Back Button","1"},
new string[]{"a","132","Family","0"},
new string[]{"a","133","Boy","0"},
new string[]{"a","134","Girl","0"},
new string[]{"a","135","Brother","0"},
new string[]{"a","136","Sister","0"},
new string[]{"a","137","Brother-in-law","0"},
new string[]{"a","138","Sister-in-law","0"},
new string[]{"a","139","Father","0"},
new string[]{"a","140","Grandpa","0"},
new string[]{"a","141","Mother","0"},
new string[]{"a","142","Grandma","0"},
new string[]{"a","143","Baby","0"},
new string[]{"a","144","Child","0"},
new string[]{"a","145","Teen","0"},
new string[]{"a","146","Adult","0"},
new string[]{"a","147","Aunt","0"},
new string[]{"a","148","Uncle","0"},
new string[]{"a","149","Stranger","0"},
new string[]{"a","150","Acquaintance","0"},
new string[]{"a","151","Parents","0"},
new string[]{"a","152","Born","0"},
new string[]{"a","153","Dead","0"},
new string[]{"a","154","Marriage","0"},
new string[]{"a","155","Divorce","0"},
new string[]{"a","156","Single","0"},
new string[]{"a","157","Young","0"},
new string[]{"a","158","Old","0"},
new string[]{"a","159","Age","0"},
new string[]{"a","160","Birthday","0"},
new string[]{"a","161","Celebrate","0"},
new string[]{"a","162","Enemy","0"},
new string[]{"a","163","Interpreter","0"},
new string[]{"a","164","No One","0"},
new string[]{"a","165","Anyone","0"},
new string[]{"a","166","Someone","0"},
new string[]{"a","167","Everyone","0"},
},
new string[][]{//Word Menu for Lesson 5 - Feelings/Reactions
new string[]{"b","0","Back Button","1"},
new string[]{"a","168","Like","0"},
new string[]{"a","169","Hate","0"},
new string[]{"a","170","Fine","0"},
new string[]{"a","171","Tired","0"},
new string[]{"a","172","Sleepy","0"},
new string[]{"a","173","Confused","0"},
new string[]{"a","174","Smart","0"},
new string[]{"a","175","Attention/Focus","0"},
new string[]{"a","176","Nevermind","0"},
new string[]{"a","177","Angry","0"},
new string[]{"a","178","Laughing","0"},
new string[]{"a","179","LOL","0"},
new string[]{"a","180","Curious","0"},
new string[]{"a","181","In Love","0"},
new string[]{"a","182","Awesome","0"},
new string[]{"a","183","Great","0"},
new string[]{"a","184","Nice","0"},
new string[]{"a","185","Cute","0"},
new string[]{"a","186","Feel","0"},
new string[]{"a","187","Pity","0"},
new string[]{"a","188","Envy","0"},
new string[]{"a","189","Hungry","0"},
new string[]{"a","190","Alive","0"},
new string[]{"a","191","Bored","0"},
new string[]{"a","192","Cry","0"},
new string[]{"a","193","Happy","0"},
new string[]{"a","194","Sad","0"},
new string[]{"a","195","Suffering","0"},
new string[]{"a","196","Surprised","0"},
new string[]{"a","197","Careful","0"},
new string[]{"a","198","Enjoy","0"},
new string[]{"a","199","Disgusted","0"},
new string[]{"a","200","Embarassed","0"},
new string[]{"a","201","Shy","0"},
new string[]{"a","202","Lonely","0"},
new string[]{"a","203","Stressed","0"},
new string[]{"a","204","Scared","0"},
new string[]{"a","205","Excited","0"},
new string[]{"a","206","Shame","0"},
new string[]{"a","207","Struggle","0"},
new string[]{"a","208","Friendly","0"},
new string[]{"a","209","Mean","0"},
},
new string[][]{//Word Menu for Lesson 6 - Value
new string[]{"b","0","Back Button","1"},
new string[]{"a","210","More","0"},
new string[]{"a","211","Less","0"},
new string[]{"a","212","Big","0"},
new string[]{"a","213","Small/A Little","0"},
new string[]{"a","214","Full","0"},
new string[]{"a","215","Empty","0"},
new string[]{"a","216","Half","0"},
new string[]{"a","217","Quarter","0"},
new string[]{"a","218","Long","0"},
new string[]{"a","219","Short (Time)","0"},
new string[]{"a","220","A Lot/Many","0"},
new string[]{"a","221","Unlimited","0"},
new string[]{"a","222","Limited","0"},
new string[]{"a","223","All","0"},
new string[]{"a","224","Nothing","0"},
new string[]{"a","225","Ever","0"},
new string[]{"a","226","Everything","0"},
new string[]{"a","227","Everytime","0"},
new string[]{"a","228","Always","0"},
new string[]{"a","229","Often","0"},
new string[]{"a","230","Sometimes","0"},
new string[]{"a","231","Heavy","0"},
new string[]{"a","232","Lightweight","0"},
new string[]{"a","233","Hard","0"},
new string[]{"a","234","Soft","0"},
new string[]{"a","235","Strong","0"},
new string[]{"a","236","Weak","0"},
new string[]{"a","237","First","0"},
new string[]{"a","238","Second","0"},
new string[]{"a","239","Third","0"},
new string[]{"a","240","Next","0"},
new string[]{"a","241","Last","0"},
new string[]{"a","242","Before","0"},
new string[]{"a","243","After","0"},
new string[]{"a","244","Busy","0"},
new string[]{"a","245","Free","0"},
new string[]{"a","246","High","0"},
new string[]{"a","247","Low","0"},
new string[]{"a","248","Fat","0"},
new string[]{"a","249","Thin","0"},
new string[]{"a","250","Value","0"},
},
new string[][]{//Word Menu for Lesson 7 - Time
new string[]{"b","0","Back Button","1"},
new string[]{"a","251","Time","0"},
new string[]{"a","252","Year","0"},
new string[]{"a","253","Season","0"},
new string[]{"a","254","Month","0"},
new string[]{"a","255","Week","0"},
new string[]{"a","256","Day","0"},
new string[]{"a","257","Weekend","0"},
new string[]{"a","258","Hours","0"},
new string[]{"a","259","Minutes","0"},
new string[]{"a","260","Seconds","0"},
new string[]{"a","261","Today","0"},
new string[]{"a","262","Tomorrow","0"},
new string[]{"a","263","Yesterday","0"},
new string[]{"a","264","Morning","0"},
new string[]{"a","265","Afternoon","0"},
new string[]{"a","266","Evening","0"},
new string[]{"a","267","Night","0"},
new string[]{"a","268","Sunrise","0"},
new string[]{"a","269","Sunset","0"},
new string[]{"a","270","All Night","0"},
new string[]{"a","271","All Day","0"},
new string[]{"a","272","Sunday","0"},
new string[]{"a","273","Monday","0"},
new string[]{"a","274","Tuesday","0"},
new string[]{"a","275","Wednesday","0"},
new string[]{"a","276","Thursday","0"},
new string[]{"a","277","Friday","0"},
new string[]{"a","278","Saturday","0"},
new string[]{"a","279","Autumn","0"},
new string[]{"a","280","Winter","0"},
new string[]{"a","281","Spring","0"},
new string[]{"a","282","Summer","0"},
new string[]{"a","283","Now","0"},
new string[]{"a","284","Never","0"},
new string[]{"a","285","Soon","0"},
new string[]{"a","286","Later","0"},
new string[]{"a","287","Past","0"},
new string[]{"a","288","Future","0"},
new string[]{"a","289","Earlier","0"},
new string[]{"a","290","Midweek","0"},
new string[]{"a","291","Next Week","0"},
},
new string[][]{//Word Menu for Lesson 8 - VRChat
new string[]{"b","0","Back Button","1"},
new string[]{"a","292","Gestures","0"},
new string[]{"a","293","World","0"},
new string[]{"a","294","Record","0"},
new string[]{"a","295","Discord","0"},
new string[]{"a","296","Streaming","0"},
new string[]{"a","297","Headset (VR)","0"},
new string[]{"a","298","Desktop","0"},
new string[]{"a","299","Computer","0"},
new string[]{"a","300","Instance","0"},
new string[]{"a","301","Public","0"},
new string[]{"a","302","Invite","0"},
new string[]{"a","303","Private","0"},
new string[]{"a","304","Add Friend","0"},
new string[]{"a","305","Menu","0"},
new string[]{"a","306","Recharge","0"},
new string[]{"a","307","Visit","0"},
new string[]{"a","308","Request","0"},
new string[]{"a","309","Login","0"},
new string[]{"a","310","Logout","0"},
new string[]{"a","311","Schedule","0"},
new string[]{"a","312","Event","0"},
new string[]{"a","313","Online","0"},
new string[]{"a","314","Offline","0"},
new string[]{"a","315","Cancel","0"},
new string[]{"a","316","Portal","0"},
new string[]{"a","317","Camera","0"},
new string[]{"a","318","Avatar","0"},
new string[]{"a","319","Photo","0"},
new string[]{"a","320","Join","0"},
new string[]{"a","321","Leave","0"},
new string[]{"a","322","Climbing","0"},
new string[]{"a","323","Falling","0"},
new string[]{"a","324","Walk","0"},
new string[]{"a","325","Hide","0"},
new string[]{"a","326","Block","0"},
new string[]{"a","327","Crash","0"},
new string[]{"a","328","Lagging","0"},
new string[]{"a","329","Restart","0"},
new string[]{"a","330","Send","0"},
new string[]{"a","331","Receive","0"},
new string[]{"a","332","Security","0"},
new string[]{"a","333","Donation","0"},
},
new string[][]{//Word Menu for Lesson 9 - Alphabet/Numbers (Fingerspelling)
new string[]{"b","0","Back Button","1"},
new string[]{"a","334","Fingerspell","0"},
new string[]{"a","335","Fingerspell (Variant 2)","0"},
new string[]{"a","336","A","0"},
new string[]{"a","337","B","0"},
new string[]{"a","338","B (Variant 2)","0"},
new string[]{"a","339","C","0"},
new string[]{"a","340","D","0"},
new string[]{"a","341","E","0"},
new string[]{"a","342","F","0"},
new string[]{"a","343","F (Variant 2)","0"},
new string[]{"a","344","G","0"},
new string[]{"a","345","H","0"},
new string[]{"a","346","I","0"},
new string[]{"a","347","I (Variant 2)","0"},
new string[]{"a","348","J","0"},
new string[]{"a","349","J (Variant 2)","0"},
new string[]{"a","350","K","0"},
new string[]{"a","351","K (Variant 2)","0"},
new string[]{"a","352","L","0"},
new string[]{"a","353","M","0"},
new string[]{"a","354","M (Variant 2)","0"},
new string[]{"a","355","N","0"},
new string[]{"a","356","N","0"},
new string[]{"a","357","O","0"},
new string[]{"a","358","P","0"},
new string[]{"a","359","Q","0"},
new string[]{"a","360","R","0"},
new string[]{"a","361","S","0"},
new string[]{"a","362","T","0"},
new string[]{"a","363","U","0"},
new string[]{"a","364","U (Variant 2)","0"},
new string[]{"a","365","V","0"},
new string[]{"a","366","V (Variant 2)","0"},
new string[]{"a","367","W","0"},
new string[]{"a","368","W (Variant 2)","0"},
new string[]{"a","369","X","0"},
new string[]{"a","370","X (Variant 2)","0"},
new string[]{"a","371","Y","0"},
new string[]{"a","372","Y (Variant 2)","0"},
new string[]{"a","373","Z","0"},
new string[]{"a","374","Comma","0"},
new string[]{"a","375","Space","0"},
new string[]{"a","376","@","0"},
new string[]{"a","377","Number","0"},
new string[]{"a","378","0","0"},
new string[]{"a","379","1","0"},
new string[]{"a","380","2","0"},
new string[]{"a","381","3","0"},
new string[]{"a","382","4","0"},
new string[]{"a","383","5","0"},
new string[]{"a","384","6","0"},
new string[]{"a","385","7","0"},
new string[]{"a","386","8","0"},
new string[]{"a","387","9","0"},
new string[]{"a","388","10","0"},
new string[]{"a","389","100","0"},
new string[]{"a","390","1000","0"},
new string[]{"a","391","1000000","0"},
},
new string[][]{//Word Menu for Lesson 10 - Verbs & Actions p1
new string[]{"b","0","Back Button","1"},
new string[]{"a","392","Overlook","0"},
new string[]{"a","393","Punish","0"},
new string[]{"a","394","Edit","0"},
new string[]{"a","395","Erase","0"},
new string[]{"a","396","Write","0"},
new string[]{"a","397","Proposal","0"},
new string[]{"a","398","Add","0"},
new string[]{"a","399","Remove","0"},
new string[]{"a","400","Agree","0"},
new string[]{"a","401","Disagree","0"},
new string[]{"a","402","Admit","0"},
new string[]{"a","403","Allow","0"},
new string[]{"a","404","Attack","0"},
new string[]{"a","405","Fight","0"},
new string[]{"a","406","Defend","0"},
new string[]{"a","407","Defeat (Overcome)","0"},
new string[]{"a","408","Win","0"},
new string[]{"a","409","Lose","0"},
new string[]{"a","410","Draw/Tie (Game)","0"},
new string[]{"a","411","Give Up","0"},
new string[]{"a","412","Skip","0"},
new string[]{"a","413","Ask","0"},
new string[]{"a","414","Attach","0"},
new string[]{"a","415","Assist","0"},
new string[]{"a","416","Bait","0"},
new string[]{"a","417","Battle","0"},
new string[]{"a","418","Beat (Overcome)","0"},
new string[]{"a","419","Become","0"},
new string[]{"a","420","Beg","0"},
new string[]{"a","421","Begin","0"},
new string[]{"a","422","Behave","0"},
new string[]{"a","423","Believe","0"},
new string[]{"a","424","Blame","0"},
new string[]{"a","425","Blow","0"},
new string[]{"a","426","Blush","0"},
new string[]{"a","427","Bother/Harass","0"},
},
new string[][]{//Word Menu for Lesson 11 - Verbs & Actions p2: Ben-Cor
new string[]{"b","0","Back Button","1"},
new string[]{"a","428","Bend","0"},
new string[]{"a","429","Bow","0"},
new string[]{"a","430","Break","0"},
new string[]{"a","431","Breathe","0"},
new string[]{"a","432","Bring","0"},
new string[]{"a","433","Build/Construct","0"},
new string[]{"a","434","Bully","0"},
new string[]{"a","435","Burn","0"},
new string[]{"a","436","Buy","0"},
new string[]{"a","437","Call","0"},
new string[]{"a","438","Cancel","0"},
new string[]{"a","439","Care","0"},
new string[]{"a","440","Carry","0"},
new string[]{"a","441","Catch","0"},
new string[]{"a","442","Cause","0"},
new string[]{"a","443","Challenge","0"},
new string[]{"a","444","Chance","0"},
new string[]{"a","445","Cheat","0"},
new string[]{"a","446","Check","0"},
new string[]{"a","447","Choose","0"},
new string[]{"a","448","Claim","0"},
new string[]{"a","449","Clean","0"},
new string[]{"a","450","Clear","0"},
new string[]{"a","451","Close","0"},
new string[]{"a","452","Comfort","0"},
new string[]{"a","453","Command","0"},
new string[]{"a","454","Communicate","0"},
new string[]{"a","455","Compare","0"},
new string[]{"a","456","Complain","0"},
new string[]{"a","457","Compliment","0"},
new string[]{"a","458","Concentrate","0"},
new string[]{"a","459","Construct/Build","0"},
new string[]{"a","460","Control","0"},
new string[]{"a","461","Cook","0"},
new string[]{"a","462","Copy","0"},
new string[]{"a","463","Correct","0"},
},
new string[][]{//Word Menu for Lesson 12 - Verbs & Actions p3: Cou-Esc
new string[]{"b","0","Back Button","1"},
new string[]{"a","464","Cough","0"},
new string[]{"a","465","Count","0"},
new string[]{"a","466","Create","0"},
new string[]{"a","467","Cuddle","0"},
new string[]{"a","468","Cut","0"},
new string[]{"a","469","Dab","0"},
new string[]{"a","470","Dance","0"},
new string[]{"a","471","Dare","0"},
new string[]{"a","472","Date","0"},
new string[]{"a","473","Deal","0"},
new string[]{"a","474","Deliver","0"},
new string[]{"a","475","Depend","0"},
new string[]{"a","476","Describe","0"},
new string[]{"a","477","Dirty","0"},
new string[]{"a","478","Disappear","0"},
new string[]{"a","479","Disappoint","0"},
new string[]{"a","480","Disapprove","0"},
new string[]{"a","481","Discuss","0"},
new string[]{"a","482","Disguise","0"},
new string[]{"a","483","Disgust","0"},
new string[]{"a","484","Dismiss","0"},
new string[]{"a","485","Disturb","0"},
new string[]{"a","486","Doubt","0"},
new string[]{"a","487","Dream","0"},
new string[]{"a","488","Dress","0"},
new string[]{"a","489","Drunk","0"},
new string[]{"a","490","Drop","0"},
new string[]{"a","491","Drown","0"},
new string[]{"a","492","Dry","0"},
new string[]{"a","493","Dump","0"},
new string[]{"a","494","Dust","0"},
new string[]{"a","495","Earn","0"},
new string[]{"a","496","Effect","0"},
new string[]{"a","497","End","0"},
new string[]{"a","498","Escape","0"},
new string[]{"a","499","Escort","0"},
},
new string[][]{//Word Menu for Lesson 13 - Verbs & Actions p4: Exc-Ins
new string[]{"b","0","Back Button","1"},
new string[]{"a","500","Excuse","0"},
new string[]{"a","501","Expose","0"},
new string[]{"a","502","Exist","0"},
new string[]{"a","503","Fail","0"},
new string[]{"a","504","Faint","0"},
new string[]{"a","505","Fake","0"},
new string[]{"a","506","Fart","0"},
new string[]{"a","507","Fear","0"},
new string[]{"a","508","Fill","0"},
new string[]{"a","509","Find","0"},
new string[]{"a","510","Finish","0"},
new string[]{"a","511","Fix","0"},
new string[]{"a","512","Flip","0"},
new string[]{"a","513","Flirt","0"},
new string[]{"a","514","Fly","0"},
new string[]{"a","515","Forbid","0"},
new string[]{"a","516","Forgive","0"},
new string[]{"a","517","Gain","0"},
new string[]{"a","518","Give","0"},
new string[]{"a","519","Glow","0"},
new string[]{"a","520","Grab","0"},
new string[]{"a","521","Grow","0"},
new string[]{"a","522","Guard","0"},
new string[]{"a","523","Guess","0"},
new string[]{"a","524","Guide","0"},
new string[]{"a","525","Harass/Bother","0"},
new string[]{"a","526","Harm","0"},
new string[]{"a","527","Hit","0"},
new string[]{"a","528","Hold","0"},
new string[]{"a","529","Hop","0"},
new string[]{"a","530","Hope","0"},
new string[]{"a","531","Hunt","0"},
new string[]{"a","532","Ignore","0"},
new string[]{"a","533","Imagine","0"},
new string[]{"a","534","Imitate","0"},
new string[]{"a","535","Insult","0"},
},
new string[][]{//Word Menu for Lesson 14 - Verbs & Actions p5: Int-Pas
new string[]{"b","0","Back Button","1"},
new string[]{"a","536","Interact","0"},
new string[]{"a","537","Interfere","0"},
new string[]{"a","538","Judge","0"},
new string[]{"a","539","Jump","0"},
new string[]{"a","540","Justify","0"},
new string[]{"a","541","Just Kidding","0"},
new string[]{"a","542","Keep","0"},
new string[]{"a","543","Kick","0"},
new string[]{"a","544","Kill","0"},
new string[]{"a","545","Knock","0"},
new string[]{"a","546","Lead","0"},
new string[]{"a","547","Lick","0"},
new string[]{"a","548","Lock","0"},
new string[]{"a","549","Manipulate","0"},
new string[]{"a","550","Melt","0"},
new string[]{"a","551","Mess","0"},
new string[]{"a","552","Miss","0"},
new string[]{"a","553","Mistake","0"},
new string[]{"a","554","Mount","0"},
new string[]{"a","555","Move","0"},
new string[]{"a","556","Murder","0"},
new string[]{"a","557","Nod","0"},
new string[]{"a","558","Note","0"},
new string[]{"a","559","Notice","0"},
new string[]{"a","560","Obey","0"},
new string[]{"a","561","Obsess","0"},
new string[]{"a","562","Obtain","0"},
new string[]{"a","563","Occupy","0"},
new string[]{"a","564","Offend","0"},
new string[]{"a","565","Offer","0"},
new string[]{"a","566","Okay","0"},
new string[]{"a","567","Open","0"},
new string[]{"a","568","Order","0"},
new string[]{"a","569","Owe","0"},
new string[]{"a","570","Own","0"},
new string[]{"a","571","Pass","0"},
},
new string[][]{//Word Menu for Lesson 15 - Verbs & Actions p6: Pat-Sav
new string[]{"b","0","Back Button","1"},
new string[]{"a","572","Pat","0"},
new string[]{"a","573","Party","0"},
new string[]{"a","574","Pet","0"},
new string[]{"a","575","Pick","0"},
new string[]{"a","576","Plug","0"},
new string[]{"a","577","Point","0"},
new string[]{"a","578","Poke","0"},
new string[]{"a","579","Pray","0"},
new string[]{"a","580","Prepare","0"},
new string[]{"a","581","Present","0"},
new string[]{"a","582","Pretend","0"},
new string[]{"a","583","Protect","0"},
new string[]{"a","584","Prove","0"},
new string[]{"a","585","Publish","0"},
new string[]{"a","586","Puke","0"},
new string[]{"a","587","Puke (Variant 2)","0"},
new string[]{"a","588","Pull","0"},
new string[]{"a","589","Punch","0"},
new string[]{"a","590","Put","0"},
new string[]{"a","591","Push","0"},
new string[]{"a","592","Question","0"},
new string[]{"a","593","Questions","0"},
new string[]{"a","594","Quit","0"},
new string[]{"a","595","Quote","0"},
new string[]{"a","596","Race","0"},
new string[]{"a","597","React","0"},
new string[]{"a","598","Recommended","0"},
new string[]{"a","599","Refuse","0"},
new string[]{"a","600","Regret","0"},
new string[]{"a","601","Remember","0"},
new string[]{"a","602","Replace","0"},
new string[]{"a","603","Report","0"},
new string[]{"a","604","Reset","0"},
new string[]{"a","605","Ride","0"},
new string[]{"a","606","Rub","0"},
new string[]{"a","607","Rule","0"},
new string[]{"a","608","Run","0"},
new string[]{"a","609","Save","0"},
},
new string[][]{//Word Menu for Lesson 16 - Verbs & Actions p7: Say-Try
new string[]{"b","0","Back Button","1"},
new string[]{"a","610","Say","0"},
new string[]{"a","611","Search","0"},
new string[]{"a","612","See","0"},
new string[]{"a","613","Share","0"},
new string[]{"a","614","Shock","0"},
new string[]{"a","615","Shop (Store)","0"},
new string[]{"a","616","Show","0"},
new string[]{"a","617","Shut Up","0"},
new string[]{"a","618","Shut Down","0"},
new string[]{"a","619","Sing","0"},
new string[]{"a","620","Sit","0"},
new string[]{"a","621","Smell","0"},
new string[]{"a","622","Smile","0"},
new string[]{"a","623","Smoke (Airborn)","0"},
new string[]{"a","624","Speak/Talk","0"},
new string[]{"a","625","Spell (Fingerspelling)","0"},
new string[]{"a","626","Spit","0"},
new string[]{"a","627","Stand","0"},
new string[]{"a","628","Start","0"},
new string[]{"a","629","Stay","0"},
new string[]{"a","630","Steal","0"},
new string[]{"a","631","Stop","0"},
new string[]{"a","632","Study","0"},
new string[]{"a","633","Suffer","0"},
new string[]{"a","634","Swim","0"},
new string[]{"a","635","Switch","0"},
new string[]{"a","636","Take (From)","0"},
new string[]{"a","637","Communicate","0"},
new string[]{"a","638","Tell","0"},
new string[]{"a","639","Test","0"},
new string[]{"a","640","Text","0"},
new string[]{"a","641","Think","0"},
new string[]{"a","642","Throw","0"},
new string[]{"a","643","Tie","0"},
new string[]{"a","644","Truth","0"},
new string[]{"a","645","Try","0"},
},
};
animations = new string [][]{
new string []{"Hello", "1","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4",""},
new string []{"How (are) You", "2","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4",""},
new string []{"What's Up?", "3","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4",""},
new string []{"What's Up? (Variant 2)", "4","1","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4",""},
new string []{"Nice (to) Meet You", "5","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4",""},
new string []{"Good", "6","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4",""},
new string []{"Bad", "7","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4","1-handed version. Also can be done with two hands - see the sign for 'Good' note the palm direction."},
new string []{"Yes", "8","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4",""},
new string []{"No", "9","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4",""},
new string []{"So-So", "10","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4",""},
new string []{"Sick", "11","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4",""},
new string []{"Sick", "12","1","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4",""},
new string []{"Hurt", "13","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4",""},
new string []{"You're Welcome", "14","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4",""},
new string []{"Goodbye", "15","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4",""},
new string []{"Good Morning", "16","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4",""},
new string []{"Good Afternoon", "17","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4",""},
new string []{"Good Evening", "18","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4",""},
new string []{"Good Night", "19","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4",""},
new string []{"See You Later", "20","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4",""},
new string []{"Please", "21","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4",""},
new string []{"Sorry", "22","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4",""},
new string []{"Forget", "23","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4",""},
new string []{"Sleep", "24","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4",""},
new string []{"Bed", "25","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4",""},
new string []{"Jump/Change World", "26","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4",""},
new string []{"Thank You", "27","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4",""},
new string []{"I Love You", "28","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4",""},
new string []{"ILY (I Love You)", "29","0","","This sign is the combinations of the letters I, L, and Y. It's the abbreviated version of I Love You."},
new string []{"Go Away", "30","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4",""},
new string []{"Going To", "31","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4","This is a directional sign. You point to where you're going."},
new string []{"Follow", "32","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4",""},
new string []{"Come", "33","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4",""},
new string []{"Hearing (Person)", "34","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4","Use this when discussing a person that can hear."},
new string []{"Deaf", "35","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4",""},
new string []{"Deaf (Variant 2)", "36","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4",""},
new string []{"Hard of Hearing", "37","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4",""},
new string []{"Mute", "38","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4",""},
new string []{"Write Slow", "39","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4",""},
new string []{"Can't Read", "40","0","https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4",""},
new string []{"Away", "41","0","",""},
new string []{"I (Me)", "42","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4",""},
new string []{"My", "43","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4","Open palm implies possessive. eg: That wallet is mine."},
new string []{"Your", "44","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4","A possessive form of 'you'. eg: That's your wallet."},
new string []{"His", "45","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4",""},
new string []{"Her", "46","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4",""},
new string []{"We", "47","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4",""},
new string []{"They", "48","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4","You sweep your pointer over the people you're referring to."},
new string []{"Their", "49","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4","Possessive form of they. eg: This is their house."},
new string []{"Over There", "50","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4",""},
new string []{"Our", "51","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4",""},
new string []{"It's", "52","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4",""},
new string []{"Inside", "53","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4",""},
new string []{"Outside", "54","0","","General version of outside."},
new string []{"Outside (Outdoors)", "55","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4",""},
new string []{"Hidden", "56","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4",""},
new string []{"Behind", "57","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4",""},
new string []{"Above", "58","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4",""},
new string []{"Below", "59","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4",""},
new string []{"Here", "60","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4",""},
new string []{"Beside", "61","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4",""},
new string []{"Back", "62","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4",""},
new string []{"Front", "63","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4",""},
new string []{"Who", "64","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4",""},
new string []{"Where", "65","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4",""},
new string []{"When", "66","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4",""},
new string []{"Why", "67","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4",""},
new string []{"Which", "68","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4",""},
new string []{"What", "69","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","This variant is perferred over variant 2, as variant 2 is a Signed Exact English Variant"},
new string []{"What (Variant 2)", "70","1","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","A Signed Exact English variant of What."},
new string []{"How", "71","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4",""},
new string []{"How (Variant 2)", "72","0","","This version is done with two A-hands next to each other and a twisting motion of your dominate hand."},
new string []{"How Many", "73","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4",""},
new string []{"How Many (Variant 2)", "74","1","",""},
new string []{"Can", "75","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4",""},
new string []{"Can't", "76","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4",""},
new string []{"Want", "77","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4",""},
new string []{"Have", "78","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4",""},
new string []{"Get", "79","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4",""},
new string []{"Will/Future", "80","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4","This is also the sign for Future"},
new string []{"Take (Up)", "81","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4","Take as in 'take-up a class' or 'take-up a child (like you're adopting one)'"},
new string []{"Need", "82","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4","Like the sign for 'Must' except with a double motion."},
new string []{"Must", "83","0","","Like the sign for 'Need', except with a single strong movement."},
new string []{"Not", "84","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4",""},
new string []{"Or", "85","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4","This is just O and R fingerspelled."},
new string []{"And", "86","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4",""},
new string []{"For", "87","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4",""},
new string []{"At", "88","0","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4",""},
new string []{"At (Variant 2)", "89","0","",""},
new string []{"Teach", "90","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4",""},
new string []{"Learn", "91","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4",""},
new string []{"Person", "92","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4",""},
new string []{"Student", "93","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4",""},
new string []{"Teacher", "94","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4",""},
new string []{"Friend", "95","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4",""},
new string []{"Sign", "96","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4",""},
new string []{"Language", "97","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4",""},
new string []{"Understand", "98","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4",""},
new string []{"Know", "99","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4",""},
new string []{"Don't Know", "100","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4",""},
new string []{"Be Right Back (BRB)", "101","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4",""},
new string []{"Accept", "102","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4",""},
new string []{"Denied", "103","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4",""},
new string []{"Name", "104","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4",""},
new string []{"New", "105","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4",""},
new string []{"Old", "106","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4",""},
new string []{"Very", "107","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4",""},
new string []{"Jokes", "108","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4",""},
new string []{"Funny", "109","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4",""},
new string []{"Play", "110","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4",""},
new string []{"Favorite", "111","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4",""},
new string []{"Draw", "112","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4",""},
new string []{"Stop", "113","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4",""},
new string []{"Read", "114","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4",""},
new string []{"Make", "115","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4",""},
new string []{"Write", "116","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4",""},
new string []{"Again/Repeat", "117","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4",""},
new string []{"Slow", "118","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4",""},
new string []{"Fast", "119","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4",""},
new string []{"Rude", "120","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4",""},
new string []{"Eat", "121","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4",""},
new string []{"Drink", "122","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4",""},
new string []{"Watch", "123","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4",""},
new string []{"Work", "124","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4",""},
new string []{"Live", "125","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4",""},
new string []{"Play Game", "126","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4",""},
new string []{"Same", "127","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4","This is a directional sign."},
new string []{"Alright", "128","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4",""},
new string []{"People", "129","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4",""},
new string []{"Browsing the Internet", "130","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4",""},
new string []{"Movie", "131","1","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4",""},
new string []{"Family", "132","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4",""},
new string []{"Boy", "133","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4",""},
new string []{"Girl", "134","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4",""},
new string []{"Brother", "135","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4",""},
new string []{"Sister", "136","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4",""},
new string []{"Brother-in-law", "137","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4",""},
new string []{"Sister-in-law", "138","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4",""},
new string []{"Father", "139","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4",""},
new string []{"Grandpa", "140","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4",""},
new string []{"Mother", "141","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4",""},
new string []{"Grandma", "142","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4",""},
new string []{"Baby", "143","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4",""},
new string []{"Child", "144","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4",""},
new string []{"Teen", "145","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4",""},
new string []{"Adult", "146","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4",""},
new string []{"Aunt", "147","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4",""},
new string []{"Uncle", "148","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4",""},
new string []{"Stranger", "149","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4",""},
new string []{"Acquaintance", "150","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4","A person you know."},
new string []{"Parents", "151","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4",""},
new string []{"Born", "152","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4",""},
new string []{"Dead", "153","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4",""},
new string []{"Marriage", "154","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4",""},
new string []{"Divorce", "155","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4",""},
new string []{"Single", "156","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4",""},
new string []{"Young", "157","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4",""},
new string []{"Old", "158","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4",""},
new string []{"Age", "159","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4",""},
new string []{"Birthday", "160","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4",""},
new string []{"Celebrate", "161","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4",""},
new string []{"Enemy", "162","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4",""},
new string []{"Interpreter", "163","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4",""},
new string []{"No One", "164","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4",""},
new string []{"Anyone", "165","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4",""},
new string []{"Someone", "166","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4","Similar motion to 'Always'. Someone is done with a small circle."},
new string []{"Everyone", "167","1","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4",""},
new string []{"Like", "168","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4",""},
new string []{"Hate", "169","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4",""},
new string []{"Fine", "170","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4",""},
new string []{"Tired", "171","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4",""},
new string []{"Sleepy", "172","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4",""},
new string []{"Confused", "173","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4",""},
new string []{"Smart", "174","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4",""},
new string []{"Attention/Focus", "175","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4",""},
new string []{"Nevermind", "176","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4",""},
new string []{"Angry", "177","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4",""},
new string []{"Laughing", "178","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4",""},
new string []{"LOL", "179","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4",""},
new string []{"Curious", "180","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4",""},
new string []{"In Love", "181","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4",""},
new string []{"Awesome", "182","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4",""},
new string []{"Great", "183","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4",""},
new string []{"Nice", "184","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4",""},
new string []{"Cute", "185","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4",""},
new string []{"Feel", "186","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4",""},
new string []{"Pity", "187","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4",""},
new string []{"Envy", "188","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4",""},
new string []{"Hungry", "189","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4",""},
new string []{"Alive", "190","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4",""},
new string []{"Bored", "191","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4",""},
new string []{"Cry", "192","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4",""},
new string []{"Happy", "193","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4",""},
new string []{"Sad", "194","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4",""},
new string []{"Suffering", "195","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4",""},
new string []{"Surprised", "196","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4",""},
new string []{"Careful", "197","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4",""},
new string []{"Enjoy", "198","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4",""},
new string []{"Disgusted", "199","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4",""},
new string []{"Embarassed", "200","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4",""},
new string []{"Shy", "201","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4",""},
new string []{"Lonely", "202","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4",""},
new string []{"Stressed", "203","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4",""},
new string []{"Scared", "204","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4",""},
new string []{"Excited", "205","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4",""},
new string []{"Shame", "206","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4",""},
new string []{"Struggle", "207","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4",""},
new string []{"Friendly", "208","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4",""},
new string []{"Mean", "209","1","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4",""},
new string []{"More", "210","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4",""},
new string []{"Less", "211","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4",""},
new string []{"Big", "212","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4",""},
new string []{"Small/A Little", "213","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4",""},
new string []{"Full", "214","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4",""},
new string []{"Empty", "215","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4",""},
new string []{"Half", "216","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4",""},
new string []{"Quarter", "217","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4",""},
new string []{"Long", "218","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4",""},
new string []{"Short (Time)", "219","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4",""},
new string []{"A Lot/Many", "220","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4",""},
new string []{"Unlimited", "221","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4",""},
new string []{"Limited", "222","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4",""},
new string []{"All", "223","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4",""},
new string []{"Nothing", "224","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4",""},
new string []{"Ever", "225","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4",""},
new string []{"Everything", "226","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4",""},
new string []{"Everytime", "227","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4",""},
new string []{"Always", "228","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4",""},
new string []{"Often", "229","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4",""},
new string []{"Sometimes", "230","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4",""},
new string []{"Heavy", "231","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4",""},
new string []{"Lightweight", "232","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4",""},
new string []{"Hard", "233","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4",""},
new string []{"Soft", "234","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4",""},
new string []{"Strong", "235","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4",""},
new string []{"Weak", "236","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4",""},
new string []{"First", "237","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4",""},
new string []{"Second", "238","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4",""},
new string []{"Third", "239","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4",""},
new string []{"Next", "240","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4",""},
new string []{"Last", "241","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4",""},
new string []{"Before", "242","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4",""},
new string []{"After", "243","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4",""},
new string []{"Busy", "244","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4",""},
new string []{"Free", "245","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4","Signed Exact English variant"},
new string []{"High", "246","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4",""},
new string []{"Low", "247","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4",""},
new string []{"Fat", "248","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4",""},
new string []{"Thin", "249","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4",""},
new string []{"Value", "250","1","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4",""},
new string []{"Time", "251","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4",""},
new string []{"Year", "252","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4",""},
new string []{"Season", "253","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4",""},
new string []{"Month", "254","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4",""},
new string []{"Week", "255","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4",""},
new string []{"Day", "256","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4",""},
new string []{"Weekend", "257","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4",""},
new string []{"Hours", "258","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4",""},
new string []{"Minutes", "259","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4",""},
new string []{"Seconds", "260","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4",""},
new string []{"Today", "261","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4",""},
new string []{"Tomorrow", "262","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4",""},
new string []{"Yesterday", "263","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4",""},
new string []{"Morning", "264","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4",""},
new string []{"Afternoon", "265","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4",""},
new string []{"Evening", "266","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4",""},
new string []{"Night", "267","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4",""},
new string []{"Sunrise", "268","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4",""},
new string []{"Sunset", "269","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4",""},
new string []{"All Night", "270","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4",""},
new string []{"All Day", "271","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4",""},
new string []{"Sunday", "272","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4",""},
new string []{"Monday", "273","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4",""},
new string []{"Tuesday", "274","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4",""},
new string []{"Wednesday", "275","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4",""},
new string []{"Thursday", "276","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4",""},
new string []{"Friday", "277","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4",""},
new string []{"Saturday", "278","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4",""},
new string []{"Autumn", "279","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4",""},
new string []{"Winter", "280","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4",""},
new string []{"Spring", "281","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4",""},
new string []{"Summer", "282","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4",""},
new string []{"Now", "283","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4",""},
new string []{"Never", "284","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4",""},
new string []{"Soon", "285","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4",""},
new string []{"Later", "286","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4",""},
new string []{"Past", "287","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4",""},
new string []{"Future", "288","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4",""},
new string []{"Earlier", "289","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4",""},
new string []{"Midweek", "290","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4",""},
new string []{"Next Week", "291","1","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4",""},
new string []{"Gestures", "292","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4",""},
new string []{"World", "293","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4",""},
new string []{"Record", "294","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4",""},
new string []{"Discord", "295","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4",""},
new string []{"Streaming", "296","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4",""},
new string []{"Headset (VR)", "297","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4",""},
new string []{"Desktop", "298","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4",""},
new string []{"Computer", "299","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4",""},
new string []{"Instance", "300","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4",""},
new string []{"Public", "301","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4",""},
new string []{"Invite", "302","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4",""},
new string []{"Private", "303","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4",""},
new string []{"Add Friend", "304","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4",""},
new string []{"Menu", "305","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4",""},
new string []{"Recharge", "306","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4",""},
new string []{"Visit", "307","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4",""},
new string []{"Request", "308","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4",""},
new string []{"Login", "309","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4",""},
new string []{"Logout", "310","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4",""},
new string []{"Schedule", "311","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4",""},
new string []{"Event", "312","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4",""},
new string []{"Online", "313","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4",""},
new string []{"Offline", "314","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4",""},
new string []{"Cancel", "315","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4",""},
new string []{"Portal", "316","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4",""},
new string []{"Camera", "317","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4",""},
new string []{"Avatar", "318","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4",""},
new string []{"Photo", "319","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4",""},
new string []{"Join", "320","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4",""},
new string []{"Leave", "321","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4",""},
new string []{"Climbing", "322","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4",""},
new string []{"Falling", "323","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4",""},
new string []{"Walk", "324","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4",""},
new string []{"Hide", "325","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4",""},
new string []{"Block", "326","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4",""},
new string []{"Crash", "327","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4",""},
new string []{"Lagging", "328","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4",""},
new string []{"Restart", "329","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4",""},
new string []{"Send", "330","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4",""},
new string []{"Receive", "331","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4",""},
new string []{"Security", "332","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4",""},
new string []{"Donation", "333","1","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4",""},
new string []{"Fingerspell", "334","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4",""},
new string []{"Fingerspell (Variant 2)", "335","2","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4",""},
new string []{"A", "336","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4",""},
new string []{"B", "337","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4",""},
new string []{"B (Variant 2)", "338","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4",""},
new string []{"C", "339","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4",""},
new string []{"D", "340","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4",""},
new string []{"E", "341","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4",""},
new string []{"F", "342","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4",""},
new string []{"F (Variant 2)", "343","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4",""},
new string []{"G", "344","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4",""},
new string []{"H", "345","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4",""},
new string []{"I", "346","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4",""},
new string []{"I (Variant 2)", "347","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4",""},
new string []{"J", "348","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","Trace out a 'J' midair with your pinky using a rotation of your wrist"},
new string []{"J (Variant 2)", "349","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","Indicate your pinky is out, then trace out a 'J' midair with your pinky using a rotation of your wrist"},
new string []{"K", "350","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4",""},
new string []{"K (Variant 2)", "351","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4",""},
new string []{"L", "352","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4",""},
new string []{"M", "353","1","",""},
new string []{"M (Variant 2)", "354","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4",""},
new string []{"N", "355","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4",""},
new string []{"N", "356","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4",""},
new string []{"O", "357","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4",""},
new string []{"P", "358","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4",""},
new string []{"Q", "359","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4",""},
new string []{"R", "360","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4",""},
new string []{"S", "361","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4",""},
new string []{"T", "362","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4",""},
new string []{"U", "363","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4",""},
new string []{"U (Variant 2)", "364","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","The 'Peace Sign' on Regular VR looks like a V, so emphasise U shape by moving it in the shape of a U."},
new string []{"V", "365","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","The 'Peace Sign' on the Index looks like a U, so emphhasise a V shape by moving it in the shape of a V."},
new string []{"V (Variant 2)", "366","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4",""},
new string []{"W", "367","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4",""},
new string []{"W (Variant 2)", "368","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4",""},
new string []{"X", "369","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4",""},
new string []{"X (Variant 2)", "370","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4",""},
new string []{"Y", "371","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4",""},
new string []{"Y (Variant 2)", "372","2","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4",""},
new string []{"Z", "373","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4",""},
new string []{"Comma", "374","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4",""},
new string []{"Space", "375","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4","To indicate a space between fingerspelled words, you simply insert a very small pause between letters."},
new string []{"@", "376","1","","Use for the symbol @, like in an email address."},
new string []{"Number", "377","1","","Pinch fingers together"},
new string []{"0", "378","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4",""},
new string []{"1", "379","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4",""},
new string []{"2", "380","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4",""},
new string []{"3", "381","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4",""},
new string []{"4", "382","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4",""},
new string []{"5", "383","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4",""},
new string []{"6", "384","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4",""},
new string []{"7", "385","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4",""},
new string []{"8", "386","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4",""},
new string []{"9", "387","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4",""},
new string []{"10", "388","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4",""},
new string []{"100", "389","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4",""},
new string []{"1000", "390","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4",""},
new string []{"1000000", "391","1","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4",""},
new string []{"Overlook", "392","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4",""},
new string []{"Punish", "393","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4",""},
new string []{"Edit", "394","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4",""},
new string []{"Erase", "395","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4",""},
new string []{"Write", "396","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4",""},
new string []{"Proposal", "397","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4",""},
new string []{"Add", "398","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4",""},
new string []{"Remove", "399","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4",""},
new string []{"Agree", "400","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4",""},
new string []{"Disagree", "401","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4",""},
new string []{"Admit", "402","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4",""},
new string []{"Allow", "403","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4",""},
new string []{"Attack", "404","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4",""},
new string []{"Fight", "405","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4",""},
new string []{"Defend", "406","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4",""},
new string []{"Defeat (Overcome)", "407","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4",""},
new string []{"Win", "408","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4",""},
new string []{"Lose", "409","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4",""},
new string []{"Draw/Tie (Game)", "410","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4","Draw or Tie, as in the same score at the end of a game."},
new string []{"Give Up", "411","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4",""},
new string []{"Skip", "412","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4",""},
new string []{"Ask", "413","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-22.mp4",""},
new string []{"Attach", "414","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4",""},
new string []{"Assist", "415","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4",""},
new string []{"Bait", "416","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4",""},
new string []{"Battle", "417","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4",""},
new string []{"Beat (Overcome)", "418","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4",""},
new string []{"Become", "419","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4",""},
new string []{"Beg", "420","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4",""},
new string []{"Begin", "421","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4",""},
new string []{"Behave", "422","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4",""},
new string []{"Believe", "423","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4",""},
new string []{"Blame", "424","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4",""},
new string []{"Blow", "425","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4",""},
new string []{"Blush", "426","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4",""},
new string []{"Bother/Harass", "427","1","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4",""},
new string []{"Bend", "428","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4",""},
new string []{"Bow", "429","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4",""},
new string []{"Break", "430","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4",""},
new string []{"Breathe", "431","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4",""},
new string []{"Bring", "432","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4","This is a directional sign."},
new string []{"Build/Construct", "433","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4",""},
new string []{"Bully", "434","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4",""},
new string []{"Burn", "435","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4",""},
new string []{"Buy", "436","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4",""},
new string []{"Call", "437","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4",""},
new string []{"Cancel", "438","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4",""},
new string []{"Care", "439","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4",""},
new string []{"Carry", "440","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4",""},
new string []{"Catch", "441","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4",""},
new string []{"Cause", "442","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4",""},
new string []{"Challenge", "443","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4",""},
new string []{"Chance", "444","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4","C Handshape. This sign is the Signed Exact English variant."},
new string []{"Cheat", "445","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4",""},
new string []{"Check", "446","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4",""},
new string []{"Choose", "447","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4",""},
new string []{"Claim", "448","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4",""},
new string []{"Clean", "449","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4",""},
new string []{"Clear", "450","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4",""},
new string []{"Close", "451","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4","Close as in 'near'"},
new string []{"Comfort", "452","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4",""},
new string []{"Command", "453","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4",""},
new string []{"Communicate", "454","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4","This sign is the Signed Exact English variant."},
new string []{"Compare", "455","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4",""},
new string []{"Complain", "456","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4",""},
new string []{"Compliment", "457","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4",""},
new string []{"Concentrate", "458","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4",""},
new string []{"Construct/Build", "459","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4",""},
new string []{"Control", "460","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4",""},
new string []{"Cook", "461","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4",""},
new string []{"Copy", "462","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4",""},
new string []{"Correct", "463","1","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4",""},
new string []{"Cough", "464","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4",""},
new string []{"Count", "465","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4",""},
new string []{"Create", "466","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4",""},
new string []{"Cuddle", "467","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4",""},
new string []{"Cut", "468","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4",""},
new string []{"Dab", "469","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4",""},
new string []{"Dance", "470","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4",""},
new string []{"Dare", "471","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4",""},
new string []{"Date", "472","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4",""},
new string []{"Deal", "473","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4",""},
new string []{"Deliver", "474","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4",""},
new string []{"Depend", "475","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4",""},
new string []{"Describe", "476","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4",""},
new string []{"Dirty", "477","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4",""},
new string []{"Disappear", "478","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4",""},
new string []{"Disappoint", "479","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4",""},
new string []{"Disapprove", "480","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4",""},
new string []{"Discuss", "481","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4",""},
new string []{"Disguise", "482","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4",""},
new string []{"Disgust", "483","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4",""},
new string []{"Dismiss", "484","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4",""},
new string []{"Disturb", "485","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4",""},
new string []{"Doubt", "486","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4",""},
new string []{"Dream", "487","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4",""},
new string []{"Dress", "488","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4",""},
new string []{"Drunk", "489","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4",""},
new string []{"Drop", "490","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4",""},
new string []{"Drown", "491","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4",""},
new string []{"Dry", "492","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4",""},
new string []{"Dump", "493","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4",""},
new string []{"Dust", "494","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4",""},
new string []{"Earn", "495","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4",""},
new string []{"Effect", "496","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4",""},
new string []{"End", "497","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4",""},
new string []{"Escape", "498","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4",""},
new string []{"Escort", "499","1","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4",""},
new string []{"Excuse", "500","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4",""},
new string []{"Expose", "501","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4",""},
new string []{"Exist", "502","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4",""},
new string []{"Fail", "503","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4",""},
new string []{"Faint", "504","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4",""},
new string []{"Fake", "505","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4",""},
new string []{"Fart", "506","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4",""},
new string []{"Fear", "507","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4",""},
new string []{"Fill", "508","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4",""},
new string []{"Find", "509","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4",""},
new string []{"Finish", "510","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4",""},
new string []{"Fix", "511","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4",""},
new string []{"Flip", "512","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4",""},
new string []{"Flirt", "513","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4",""},
new string []{"Fly", "514","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4",""},
new string []{"Forbid", "515","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4",""},
new string []{"Forgive", "516","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4",""},
new string []{"Gain", "517","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4",""},
new string []{"Give", "518","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4",""},
new string []{"Glow", "519","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4",""},
new string []{"Grab", "520","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4",""},
new string []{"Grow", "521","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4",""},
new string []{"Guard", "522","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4",""},
new string []{"Guess", "523","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4",""},
new string []{"Guide", "524","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4",""},
new string []{"Harass/Bother", "525","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4",""},
new string []{"Harm", "526","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4",""},
new string []{"Hit", "527","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4",""},
new string []{"Hold", "528","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4",""},
new string []{"Hop", "529","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4",""},
new string []{"Hope", "530","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4",""},
new string []{"Hunt", "531","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4",""},
new string []{"Ignore", "532","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4",""},
new string []{"Imagine", "533","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4",""},
new string []{"Imitate", "534","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4",""},
new string []{"Insult", "535","1","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4",""},
new string []{"Interact", "536","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4",""},
new string []{"Interfere", "537","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4",""},
new string []{"Judge", "538","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4",""},
new string []{"Jump", "539","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4",""},
new string []{"Justify", "540","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4",""},
new string []{"Just Kidding", "541","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4",""},
new string []{"Keep", "542","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4",""},
new string []{"Kick", "543","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4",""},
new string []{"Kill", "544","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4",""},
new string []{"Knock", "545","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4",""},
new string []{"Lead", "546","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4",""},
new string []{"Lick", "547","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4",""},
new string []{"Lock", "548","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4",""},
new string []{"Manipulate", "549","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4",""},
new string []{"Melt", "550","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4",""},
new string []{"Mess", "551","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4",""},
new string []{"Miss", "552","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4",""},
new string []{"Mistake", "553","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4",""},
new string []{"Mount", "554","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4",""},
new string []{"Move", "555","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4",""},
new string []{"Murder", "556","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4",""},
new string []{"Nod", "557","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4",""},
new string []{"Note", "558","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4",""},
new string []{"Notice", "559","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4",""},
new string []{"Obey", "560","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4",""},
new string []{"Obsess", "561","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4",""},
new string []{"Obtain", "562","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4",""},
new string []{"Occupy", "563","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4",""},
new string []{"Offend", "564","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4",""},
new string []{"Offer", "565","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4",""},
new string []{"Okay", "566","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4",""},
new string []{"Open", "567","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4",""},
new string []{"Order", "568","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4",""},
new string []{"Owe", "569","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4",""},
new string []{"Own", "570","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4",""},
new string []{"Pass", "571","1","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4",""},
new string []{"Pat", "572","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4",""},
new string []{"Party", "573","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4",""},
new string []{"Pet", "574","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4",""},
new string []{"Pick", "575","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4",""},
new string []{"Plug", "576","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4",""},
new string []{"Point", "577","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4",""},
new string []{"Poke", "578","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4",""},
new string []{"Pray", "579","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4",""},
new string []{"Prepare", "580","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4",""},
new string []{"Present", "581","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4",""},
new string []{"Pretend", "582","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4",""},
new string []{"Protect", "583","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4",""},
new string []{"Prove", "584","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4",""},
new string []{"Publish", "585","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4",""},
new string []{"Puke", "586","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4",""},
new string []{"Puke (Variant 2)", "587","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4",""},
new string []{"Pull", "588","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4",""},
new string []{"Punch", "589","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4",""},
new string []{"Put", "590","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4",""},
new string []{"Push", "591","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4",""},
new string []{"Question", "592","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4",""},
new string []{"Questions", "593","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4",""},
new string []{"Quit", "594","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4",""},
new string []{"Quote", "595","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4",""},
new string []{"Race", "596","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4",""},
new string []{"React", "597","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4",""},
new string []{"Recommended", "598","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4",""},
new string []{"Refuse", "599","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4",""},
new string []{"Regret", "600","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4",""},
new string []{"Remember", "601","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4",""},
new string []{"Replace", "602","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4",""},
new string []{"Report", "603","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4",""},
new string []{"Reset", "604","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4",""},
new string []{"Ride", "605","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4",""},
new string []{"Rub", "606","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4",""},
new string []{"Rule", "607","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4",""},
new string []{"Run", "608","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4",""},
new string []{"Save", "609","1","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4",""},
new string []{"Say", "610","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4",""},
new string []{"Search", "611","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4",""},
new string []{"See", "612","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4",""},
new string []{"Share", "613","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4",""},
new string []{"Shock", "614","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4",""},
new string []{"Shop (Store)", "615","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4",""},
new string []{"Show", "616","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4","This is a directional sign."},
new string []{"Shut Up", "617","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4","IRL: Starts with a V hand and transitions to an U hand."},
new string []{"Shut Down", "618","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4",""},
new string []{"Sing", "619","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4",""},
new string []{"Sit", "620","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4",""},
new string []{"Smell", "621","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4",""},
new string []{"Smile", "622","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4",""},
new string []{"Smoke (Airborn)", "623","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4",""},
new string []{"Speak/Talk", "624","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4",""},
new string []{"Spell (Fingerspelling)", "625","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4",""},
new string []{"Spit", "626","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4",""},
new string []{"Stand", "627","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4",""},
new string []{"Start", "628","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4",""},
new string []{"Stay", "629","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4",""},
new string []{"Steal", "630","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4",""},
new string []{"Stop", "631","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4",""},
new string []{"Study", "632","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4",""},
new string []{"Suffer", "633","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4",""},
new string []{"Swim", "634","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4",""},
new string []{"Switch", "635","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4",""},
new string []{"Take (From)", "636","0","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4","Like taking candy from a baby"},
new string []{"Communicate", "637","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4",""},
new string []{"Tell", "638","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4",""},
new string []{"Test", "639","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4",""},
new string []{"Text", "640","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4",""},
new string []{"Think", "641","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4",""},
new string []{"Throw", "642","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4",""},
new string []{"Tie", "643","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4",""},
new string []{"Truth", "644","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4",""},
new string []{"Try", "645","1","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4",""},
};

        for (int i = 0; i < unityButtons.Length; i++){
            unityButtons[i]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(i+1));
            unityButtonsText[i]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(i+1)+"/Text").GetComponent<Text>();
            indexicons[i]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(i+1)+"/Index VR Icon");
            regvricons[i]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(i+1)+"/Regular VR Icon");
            bothvricons[i]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(i+1)+"/Both VR Icon");
        }
        backButtons[0]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Left Back Button");
        backButtons[1]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Right Back Button");
        backButtonstext[0]=backButtons[0].GetComponent<Text>();
        backButtonstext[1]=backButtons[1].GetComponent<Text>();
        changePage(0);
    }

    void changePage(int newButtonState){ //changes to the target page
    Debug.Log("entered changeButtons with newButtonState: "+newButtonState);
    //at this point, it shoud already know where it's going.
/*
    public string [][][] buttonStates = { //think of this as pages on the existing menu.
        new string [][]{ //buttonStates[0] //a single page on the menu -lang select
            new string[]{"b", "0","Back Button","0"},
            new string[]{"b", "1", "ASL","0"}, // what each button does
            //string[0] = array it moves to b=buttonStates array, a=animations array
            //string[1] = index on the array it moves to based on string[0].
            //string[3] = text on the button
            //string[4] = icon that appear. 0=no icon, 1=both vr icon, 2=reg vr icon, 3=index icon
            //new string[]{"b", "1", "BSL"}, //string[1] needs to be unique, since it'll invariably point to a different range of buttonStates.
        },
        new string[][]{//buttonStates[1] - Lesson Menu
                new string[]{"b", "0","Back Button","0"},
                new string[]{"b", "1","Daily Use","0"},
                new string[]{"b", "2","Pointing use Question/Answer","0"},
                new string[]{"b", "3","Common","0"},
                new string[]{"b", "4","People","0"},
                new string[]{"b", "5","Feelings / Reactions","0"},
                new string[]{"b", "6","Value","0"},
                new string[]{"b", "7","Time","0"},
                new string[]{"b", "8","VRChat","0"},
                new string[]{"b", "9","Alphabet/Numbers (Fingerspelling)","0"},
                new string[]{"b", "10","Verbs & Actions p1","0"},
                new string[]{"b", "11","Verbs & Actions p2: Ben-Cor","0"},
                new string[]{"b", "12","Verbs & Actions p3: Cou-Esc","0"},
                new string[]{"b", "13","Verbs & Actions p4: Exc-Ins","0"},
                new string[]{"b", "14","Verbs & Actions p5: Int-Pas","0"},
                new string[]{"b", "15","Verbs & Actions p6: Pat-Sav","0"},
                new string[]{"b", "16","Verbs & Actions p7: Say-Try","0"},
        },
*/


        string[][] newButtons = buttonStates[newButtonState];
        string[] button;
        GameObject u_button;
        Text u_button_text;

        if(newButtonState==0){
            backButtons[0].SetActive(false);
            backButtons[1].SetActive(false);
        }else{
            backButtons[0].SetActive(true);
            backButtons[1].SetActive(true);
        }
        menuheadertext.text=menuheadername[newButtonState];
       

        for (int i = 1; i < unityButtons.Length+1; i++){ //loops through all the buttons. 
        //Debug.Log("i: "+i);
            
                u_button = unityButtons[i-1];
                u_button_text = unityButtonsText[i-1];
                //Debug.Log("newButtons.Length"+newButtons.Length);
                if (i < newButtons.Length){ // this button is defined by buttonStates
                    button = newButtons[i]; //since 0 is the back button, get the data from the next "row". {"b", "5","Feelings / Reactions","0"},
                    //set header text?
                    
                    u_button.SetActive(true);//unityButtons[i]
                    
                    switch(button[3]){ //0=no icon, 1=both vr icon, 2=reg vr icon, 3=index icon
                        case "0": //no icons are displayed
                        indexicons[i-1].SetActive(false);
                        regvricons[i-1].SetActive(false);
                        bothvricons[i-1].SetActive(false);
                        u_button_text.text = "          "+button[2];
                        break;
                        case "1": //both icon displayed
                        indexicons[i-1].SetActive(false);
                        regvricons[i-1].SetActive(false);
                        bothvricons[i-1].SetActive(true);
                        u_button_text.text = "          "+button[2];
                        break;
                        case "2": //reg vr icon
                        indexicons[i-1].SetActive(false);
                        regvricons[i-1].SetActive(true);
                        bothvricons[i-1].SetActive(false);
                        u_button_text.text = "          "+button[2];
                        break;
                        case "3": //index icon
                        indexicons[i-1].SetActive(true);
                        regvricons[i-1].SetActive(false);
                        bothvricons[i-1].SetActive(false);
                        u_button_text.text = "          "+button[2];
                        break;
                        default:
                        Debug.Log("Warning: Icon number "+button[4]+" is invalid.");
                        break;
                    }
                
                }else{ // this button should be inactive since buttonStates does not define it 
                    u_button.SetActive(false);
                }

        }
        currentsigntext.text = "The sign that's currently playing will show here.";
        speechbubbletext.text ="";
        nana.SetInteger("sign",0);
        videoURL.text = ""; //not sure what happens if I play a blank url - maybe just disable the gameobject?
        videoStopEvent.SetTrigger("trigger"); //stop the video? 
        signcredittext.text = "";
        descriptiontext.text = "";
        prevButton.SetActive(false);
        nextButton.SetActive(false);
        currentPage = newButtonState; 
    }
    void changeAnimation(int newAnimationState){
        Debug.Log("entered changeAnimation with newAnimationState: "+newAnimationState);
        string[] animation = animations[newAnimationState];
        //string[0]=name of sign
        //string[1]=animationint
        //string[2]=credit text key
        //string[3]=url
        //string[4]=description of sign
        currentsigntext.text = animation[0];
        speechbubbletext.text = animation[0];
        nana.SetInteger("sign",int.Parse(animation[1]));
        Debug.Log("trying to set url to: "+animation[3]);
        videoURL.text = animation[3];
        Debug.Log("url set to: "+videoURL.text);
        videoPlayEvent.SetTrigger("trigger"); //plays the video? 
        signcredittext.text = credits[int.Parse(animation[2])];
        descriptiontext.text = animation[4];
        if((newAnimationState-1) >= 0){
            prevButton.SetActive(true);
        }else{
            prevButton.SetActive(false); //if the index is smaller or equal to 0, disable the prev button
        }
        
        if((newAnimationState+1) <= animations.Length){
            nextButton.SetActive(true);
        }else{
            nextButton.SetActive(false); //if the index exceeds the # of animations, disable the next button
        }
        currentWord = newAnimationState;
    } 
    void onButtonPressed(int pressedButtonIndex){  //pressed button index starts at 0-55
    Debug.Log("entered onButtonPressed with pressedButtonIndex: "+pressedButtonIndex + " currentpage: "+currentPage);
        string[] button = buttonStates[currentPage][pressedButtonIndex]; //{"b", "2", "Daily Use"}, 
        //Debug.Log("button[0]:"+button[0]+" button[1]:"+button[1]+" button[2]:"+button[2]+" button[3]:"+button[3]);
        int newIndex = int.Parse(button[1]);
        //Debug.Log("newIndex: "+newIndex);
        switch (button[0]){
            case "b": //button
                changePage(newIndex);
                break;
            case "a": //animation (word)
                changeAnimation(newIndex-1);//because non-animations have a back button
                break;
        }
    }



//I'm going to keep my ghetto button handling thing until there's a better way to pass which button got pushed?
public void NextB()
{
Debug.Log("Next pushed");
changeAnimation(currentWord+1);
}
public void PrevB()
{
changeAnimation(currentWord-1);
}
public void BackB()
{
Debug.Log("Back pushed");
onButtonPressed(0);
}
public void B1()   
{
    Debug.Log("B1 pushed");
onButtonPressed(1);
}
public void B2()   
{
onButtonPressed(2);
}
public void B3()   
{
onButtonPressed(3);
}
public void B4()
{
onButtonPressed(4);
}
public void B5()
{
onButtonPressed(5);
}
public void B6()
{
onButtonPressed(6);
}
public void B7()
{
onButtonPressed(7);
}
public void B8()
{
onButtonPressed(8);
}
public void B9()
{
onButtonPressed(9);
}
public void B10()
{
onButtonPressed(10);
}
public void B11()
{
onButtonPressed(11);
}
public void B12()
{
onButtonPressed(12);
}
public void B13()
{
onButtonPressed(13);
}
public void B14()
{
onButtonPressed(14);
}
public void B15()
{
onButtonPressed(15);
}
public void B16()
{
onButtonPressed(16);
}
public void B17()
{
onButtonPressed(17);
}
public void B18()
{
onButtonPressed(18);
}
public void B19()
{
onButtonPressed(19);
}
public void B20()
{
onButtonPressed(20);
}
public void B21()
{
onButtonPressed(21);
}
public void B22()
{
onButtonPressed(22);
}
public void B23()
{
onButtonPressed(23);
}
public void B24()
{
onButtonPressed(24);
}
public void B25()
{
onButtonPressed(25);
}
public void B26()
{
onButtonPressed(26);
}
public void B27()
{
onButtonPressed(27);
}
public void B28()
{
onButtonPressed(28);
}
public void B29()
{
onButtonPressed(29);
}
public void B30()
{
onButtonPressed(30);
}
public void B31()
{
onButtonPressed(31);
}
public void B32()
{
onButtonPressed(32);
}
public void B33()
{
onButtonPressed(33);
}
public void B34()
{
onButtonPressed(34);
}
public void B35()
{
onButtonPressed(35);
}
public void B36()
{
onButtonPressed(36);
}
public void B37()
{
onButtonPressed(37);
}
public void B38()
{
onButtonPressed(38);
}
public void B39()
{
onButtonPressed(39);
}
public void B40()
{
onButtonPressed(40);
}
public void B41()
{
onButtonPressed(41);
}
public void B42()
{
onButtonPressed(42);
}
public void B43()
{
onButtonPressed(43);
}
public void B44()
{
onButtonPressed(44);
}
public void B45()
{
onButtonPressed(45);
}
public void B46()
{
onButtonPressed(46);
}
public void B47()
{
onButtonPressed(47);
}
public void B48()
{
onButtonPressed(48);
}
public void B49()
{
onButtonPressed(49);
}
public void B50()
{
onButtonPressed(50);
}
public void B51()
{
onButtonPressed(51);
}
public void B52()
{
onButtonPressed(52);
}
public void B53()
{
onButtonPressed(53);
}
public void B54()
{
onButtonPressed(54);
}
public void B55()
{
onButtonPressed(55);
}
public void B56()
{
onButtonPressed(56);
}


}
