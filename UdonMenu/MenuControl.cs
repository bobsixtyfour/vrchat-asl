
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Udonmenusystem : UdonSharpBehaviour
{

public string [][][][] Alllessons = {
new string [][][]{
new string[][]{//Lesson 1 (Daily Use)
new string[]{"Hello","ASL-Hello","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4","2",""},
new string[]{"How (are) You","ASL-How Are You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4","2",""},
new string[]{"What's Up?","ASL-What's Up?","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","0",""},
new string[]{"What's Up? (Variant 2)","ASL-What's Up?2","Bob64","https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4","2",""},
new string[]{"Nice (to) Meet You","ASL-Nice (to) Meet You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4","2",""},
new string[]{"Good","ASL-Good","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4","2",""},
new string[]{"Bad","ASL-Bad","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4","2","1-handed version. Also can be done with two hands - see the sign for 'Good' note the palm direction."},
new string[]{"Yes","ASL-Yes","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4","2",""},
new string[]{"No","ASL-No","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4","2",""},
new string[]{"So-So","ASL-So-So","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4","2",""},
new string[]{"Sick","ASL-Sick","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","0",""},
new string[]{"Sick","ASL-Sick2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4","2",""},
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
new string[]{"Sleep","ASL-Sleep","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4","2",""},
new string[]{"Bed","ASL-Bed","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4","2",""},
new string[]{"Jump/Change World","ASL-Jump/Change World","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4","2",""},
new string[]{"Thank You","ASL-Thank You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4","2",""},
new string[]{"I Love You","ASL-I Love You","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4","2",""},
new string[]{"ILY (I Love You)","ASL-ILY","GT4tube","","0","This sign is the combinations of the letters I, L, and Y. It's the abbreviated version of I Love You."},
new string[]{"Go Away","ASL-Go Away","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4","2",""},
new string[]{"Going To","ASL-Going To","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4","2","This is a directional sign. You point to where you're going."},
new string[]{"Follow","ASL-Follow","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4","2",""},
new string[]{"Come","ASL-Come","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4","2",""},
new string[]{"Hearing (Person)","ASL-Hearing (Person)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4","2","Use this when discussing a person that can hear."},
new string[]{"Deaf","ASL-Deaf","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","2",""},
new string[]{"Deaf (Variant 2)","ASL-Deaf2","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4","2",""},
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
new string[]{"What (Variant 2)","ASL-What2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4","2","A Signed Exact English variant of What."},
new string[]{"How","ASL-How","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4","2",""},
new string[]{"How (Variant 2)","ASL-How2","GT4tube","","2","This version is done with two A-hands next to each other and a twisting motion of your dominate hand."},
new string[]{"How Many","ASL-How Many","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4","2",""},
new string[]{"How Many (Variant 2)","ASL-How Many2","Anonymous.","","2",""},
new string[]{"Can","ASL-Can","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4","2",""},
new string[]{"Can't","ASL-Can't","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4","2",""},
new string[]{"Want","ASL-Want","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4","2",""},
new string[]{"Have","ASL-Have","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4","2",""},
new string[]{"Get","ASL-Get","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4","2",""},
new string[]{"Will/Future","ASL-Will","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4","2","This is also the sign for Future"},
new string[]{"Take (Up)","ASL-Take (Up)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4","2","Take as in 'take-up a class' or 'take-up a child (like you're adopting one)'"},
new string[]{"Need","ASL-Need","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4","0","Like the sign for 'Must' except with a double motion."},
new string[]{"Must","ASL-Must","GT4tube","","0","Like the sign for 'Need', except with a single strong movement."},
new string[]{"Not","ASL-Not","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4","2",""},
new string[]{"Or","ASL-Or","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4","2","This is just O and R fingerspelled."},
new string[]{"And","ASL-And","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4","2",""},
new string[]{"For","ASL-For","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4","2",""},
new string[]{"At","ASL-At","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4","2",""},
new string[]{"At (Variant 2)","ASL-At2","GT4tube","","2",""}
},
new string[][]{//Lesson 3 (Common) DarkEternal
new string[]{"Teach","ASL-Teach","GT4tube.","https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4","2","This sign can use either a double movement or a single movement. Both are fine."},
new string[]{"Learn","ASL-Learn","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4","2",""},
new string[]{"Person","ASL-Person","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4","2",""},
new string[]{"Student","ASL-Student","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4","2",""},
new string[]{"Teacher","ASL-Teacher","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4","2",""},
new string[]{"Friend","ASL-Friend","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4","2","The IRL sign has your two index fingers hooking around the other."},
new string[]{"Sign","ASL-Sign","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4","2",""},
new string[]{"Language","ASL-Language","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4","2",""},
new string[]{"Understand","ASL-Understand","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4","2",""},
new string[]{"Know","ASL-Know","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4","2",""},
new string[]{"Don't Know","ASL-Don't Know","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4","2",""},
new string[]{"Be Right Back (BRB)","ASL-Be Right Back (BRB)","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4","2",""},
new string[]{"Accept","ASL-Accept","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4","2",""},
new string[]{"Denied","ASL-Denied","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4","2",""},
new string[]{"Name","ASL-Name","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4","2",""},
new string[]{"New","ASL-New","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4","2",""},
new string[]{"Old","ASL-Old2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4","2",""},
new string[]{"Very","ASL-Very","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4","2",""},
new string[]{"Jokes","ASL-Jokes","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4","0",""},
new string[]{"Funny","ASL-Funny","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4","2",""},
new string[]{"Play","ASL-Play","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4","0",""},
new string[]{"Favorite","ASL-Favorite","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4","0",""},
new string[]{"Draw","ASL-Draw","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4","2",""},
new string[]{"Stop","ASL-Stop","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4","2",""},
new string[]{"Read","ASL-Read","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4","2",""},
new string[]{"Make","ASL-Make","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4","2",""},
new string[]{"Write","ASL-Write2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4","2",""},
new string[]{"Again/Repeat","ASL-Again/Repeat","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4","2",""},
new string[]{"Slow","ASL-Slow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4","2",""},
new string[]{"Fast","ASL-Fast","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4","2",""},
new string[]{"Rude","ASL-Rude","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4","0",""},
new string[]{"Eat","ASL-Eat","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4","2",""},
new string[]{"Drink","ASL-Drink","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4","2",""},
new string[]{"Watch","ASL-Watch","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4","0",""},
new string[]{"Work","ASL-Work","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4","2",""},
new string[]{"Live","ASL-Live","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4","2",""},
new string[]{"Play Game","ASL-Play Game","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4","0",""},
new string[]{"Same","ASL-Same","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4","0","This is a directional sign."},
new string[]{"Alright","ASL-Alright","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4","2",""},
new string[]{"People","ASL-People","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4","0",""},
new string[]{"Browsing the Internet","ASL-Browsing the Internet","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4","0",""},
new string[]{"Movie","ASL-Movie","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4","2",""}
},
new string[][]{//Lesson 4 (People)
new string[]{"Family","ASL-Family","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4","0",""},
new string[]{"Boy","ASL-Boy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4","2",""},
new string[]{"Girl","ASL-Girl","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4","2",""},
new string[]{"Brother","ASL-Brother","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4","2",""},
new string[]{"Sister","ASL-Sister","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4","2",""},
new string[]{"Brother-in-law","ASL-Brother-in-law","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4","2",""},
new string[]{"Sister-in-law","ASL-Sister-in-law","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4","2",""},
new string[]{"Father","ASL-Father","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4","2",""},
new string[]{"Grandpa","ASL-Grandpa","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4","2",""},
new string[]{"Mother","ASL-Mother","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4","2",""},
new string[]{"Grandma","ASL-Grandma","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4","0",""},
new string[]{"Baby","ASL-Baby","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4","2",""},
new string[]{"Child","ASL-Child","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4","2",""},
new string[]{"Teen","ASL-Teen","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4","2",""},
new string[]{"Adult","ASL-Adult","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4","2",""},
new string[]{"Aunt","ASL-Aunt","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4","2",""},
new string[]{"Uncle","ASL-Uncle","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4","2",""},
new string[]{"Stranger","ASL-Stranger","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4","2",""},
new string[]{"Acquaintance","ASL-Acquaintance","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4","2","A person you know."},
new string[]{"Parents","ASL-Parents","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4","2",""},
new string[]{"Born","ASL-Born","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4","2",""},
new string[]{"Dead","ASL-Dead","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4","2",""},
new string[]{"Marriage","ASL-Marriage","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4","2",""},
new string[]{"Divorce","ASL-Divorce","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4","2",""},
new string[]{"Single","ASL-Single","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4","2",""},
new string[]{"Young","ASL-Young","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4","2",""},
new string[]{"Old","ASL-Old","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4","2",""},
new string[]{"Age","ASL-Age","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4","2",""},
new string[]{"Birthday","ASL-Birthday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4","0",""},
new string[]{"Celebrate","ASL-Celebrate","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4","0",""},
new string[]{"Enemy","ASL-Enemy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4","2",""},
new string[]{"Interpreter","ASL-Interpreter","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4","0",""},
new string[]{"No One","ASL-No One","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4","2",""},
new string[]{"Anyone","ASL-Anyone","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4","2",""},
new string[]{"Someone","ASL-Someone","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4","0","Similar motion to 'Always'. Someone is done with a small circle."},
new string[]{"Everyone","ASL-Everyone","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4","0",""}
},
new string[][]{//Lesson 5 (Feelings/Reactions)
new string[]{"Like","ASL-Like","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4","0",""},
new string[]{"Hate","ASL-Hate","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4","0",""},
new string[]{"Fine","ASL-Fine","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4","2",""},
new string[]{"Tired","ASL-Tired","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4","2",""},
new string[]{"Sleepy","ASL-Sleep2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4","2",""},
new string[]{"Confused","ASL-Confused","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4","2",""},
new string[]{"Smart","ASL-Smart","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4","0",""},
new string[]{"Attention/Focus","ASL-Attention/Focus","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4","2",""},
new string[]{"Nevermind","ASL-Nevermind","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4","2",""},
new string[]{"Angry","ASL-Angry","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4","2",""},
new string[]{"Laughing","ASL-Laughing","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4","2",""},
new string[]{"LOL","ASL-LOL","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4","2",""},
new string[]{"Curious","ASL-Curious","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4","0",""},
new string[]{"In Love","ASL-In Love","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4","2",""},
new string[]{"Awesome","ASL-Awesome","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4","2",""},
new string[]{"Great","ASL-Great","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4","2",""},
new string[]{"Nice","ASL-Nice","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4","2",""},
new string[]{"Cute","ASL-Cute","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4","2",""},
new string[]{"Feel","ASL-Feel","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4","0",""},
new string[]{"Pity","ASL-Pity","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4","0",""},
new string[]{"Envy","ASL-Envy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4","2",""},
new string[]{"Hungry","ASL-Hungry","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4","2",""},
new string[]{"Alive","ASL-Alive","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4","2",""},
new string[]{"Bored","ASL-Bored","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4","2",""},
new string[]{"Cry","ASL-Cry","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4","2",""},
new string[]{"Happy","ASL-Happy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4","2",""},
new string[]{"Sad","ASL-Sad","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4","2",""},
new string[]{"Suffering","ASL-Suffering","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4","2",""},
new string[]{"Surprised","ASL-Surprised","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4","2",""},
new string[]{"Careful","ASL-Careful","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4","0",""},
new string[]{"Enjoy","ASL-Enjoy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4","2",""},
new string[]{"Disgusted","ASL-Disgusted","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4","2",""},
new string[]{"Embarassed","ASL-Embarassed","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4","2",""},
new string[]{"Shy","ASL-Shy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4","2",""},
new string[]{"Lonely","ASL-Lonely","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4","2",""},
new string[]{"Stressed","ASL-Stressed","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4","2",""},
new string[]{"Scared","ASL-Scared","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4","2",""},
new string[]{"Excited","ASL-Excited","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4","0",""},
new string[]{"Shame","ASL-Shame","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4","2",""},
new string[]{"Struggle","ASL-Struggle","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4","2",""},
new string[]{"Friendly","ASL-Friendly","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4","2",""},
new string[]{"Mean","ASL-Mean","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4","2",""}
},
new string[][]{//Lesson 6 (Value) 
new string[]{"More","ASL-More","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4","2",""},
new string[]{"Less","ASL-Less","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4","2",""},
new string[]{"Big","ASL-Big","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4","2",""},
new string[]{"Small/A Little","ASL-Small","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4","2",""},
new string[]{"Full","ASL-Full","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4","2",""},
new string[]{"Empty","ASL-Empty","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4","0",""},
new string[]{"Half","ASL-Half","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4","2",""},
new string[]{"Quarter","ASL-Quarter","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4","0",""},
new string[]{"Long","ASL-Long","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4","2",""},
new string[]{"Short (Time)","ASL-Short (Time)","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4","0",""},
new string[]{"A Lot/Many","ASL-A Lot/Many","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-12.mp4","0",""},
new string[]{"Unlimited","ASL-Unlimited","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4","0",""},
new string[]{"Limited","ASL-Limited","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4","0",""},
new string[]{"All","ASL-All","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4","0",""},
new string[]{"Nothing","ASL-Nothing","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4","0",""},
new string[]{"Ever","ASL-Ever","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4","0",""},
new string[]{"Everything","ASL-Everything","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4","0",""},
new string[]{"Everytime","ASL-Everytime","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4","0",""},
new string[]{"Always","ASL-Always","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4","0",""},
new string[]{"Often","ASL-Often","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4","0",""},
new string[]{"Sometimes","ASL-Sometimes","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4","0",""},
new string[]{"Heavy","ASL-Heavy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4","0",""},
new string[]{"Lightweight","ASL-Lightweight","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4","0",""},
new string[]{"Hard","ASL-Hard","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4","0",""},
new string[]{"Soft","ASL-Soft","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4","0",""},
new string[]{"Strong","ASL-Strong","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4","0",""},
new string[]{"Weak","ASL-Weak","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4","0",""},
new string[]{"First","ASL-First","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4","0",""},
new string[]{"Second","ASL-Second","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4","0",""},
new string[]{"Third","ASL-Third","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4","0",""},
new string[]{"Next","ASL-Next","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4","0",""},
new string[]{"Last","ASL-Last","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4","0",""},
new string[]{"Before","ASL-Before","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4","0",""},
new string[]{"After","ASL-After","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4","0",""},
new string[]{"Busy","ASL-Busy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4","0",""},
new string[]{"Free","ASL-Free","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4","0","Signed Exact English variant"},
new string[]{"High","ASL-High","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4","0",""},
new string[]{"Low","ASL-Low","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4","0",""},
new string[]{"Fat","ASL-Fat","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4","0",""},
new string[]{"Thin","ASL-Thin","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4","0",""},
new string[]{"Value","ASL-Value","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4","0",""}
},
new string[][]{//Lesson 7 (Time)
new string[]{"Time","ASL-Time","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4","0",""},
new string[]{"Year","ASL-Year","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4","0",""},
new string[]{"Season","ASL-Season","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4","0",""},
new string[]{"Month","ASL-Month","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4","0",""},
new string[]{"Week","ASL-Week","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4","0",""},
new string[]{"Day","ASL-Day","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4","0",""},
new string[]{"Weekend","ASL-Weekend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4","0",""},
new string[]{"Hours","ASL-Hours","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4","0",""},
new string[]{"Minutes","ASL-Minutes","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4","0",""},
new string[]{"Seconds","ASL-Seconds","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4","0",""},
new string[]{"Today","ASL-Today","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4","0",""},
new string[]{"Tomorrow","ASL-Tomorrow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4","0",""},
new string[]{"Yesterday","ASL-Yesterday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4","0",""},
new string[]{"Morning","ASL-Morning","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4","0",""},
new string[]{"Afternoon","ASL-Afternoon","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4","0",""},
new string[]{"Evening","ASL-Evening","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4","0",""},
new string[]{"Night","ASL-Night","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4","0",""},
new string[]{"Sunrise","ASL-Sunrise","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4","0",""},
new string[]{"Sunset","ASL-Sunset","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4","0",""},
new string[]{"All Night","ASL-All Night","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4","0",""},
new string[]{"All Day","ASL-All Day","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4","0",""},
new string[]{"Sunday","ASL-Sunday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4","0",""},
new string[]{"Monday","ASL-Monday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4","0",""},
new string[]{"Tuesday","ASL-Tuesday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4","0",""},
new string[]{"Wednesday","ASL-Wednesday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4","0",""},
new string[]{"Thursday","ASL-Thursday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4","0",""},
new string[]{"Friday","ASL-Friday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4","0",""},
new string[]{"Saturday","ASL-Saturday","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4","0",""},
new string[]{"Autumn","ASL-Autumn","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4","0",""},
new string[]{"Winter","ASL-Winter","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4","0",""},
new string[]{"Spring","ASL-Spring","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4","0",""},
new string[]{"Summer","ASL-Summer","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4","0",""},
new string[]{"Now","ASL-Now","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4","0",""},
new string[]{"Never","ASL-Never","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4","0",""},
new string[]{"Soon","ASL-Soon","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4","0",""},
new string[]{"Later","ASL-Later","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4","0",""},
new string[]{"Past","ASL-Past","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4","0",""},
new string[]{"Future","ASL-Future","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4","0",""},
new string[]{"Earlier","ASL-Earlier","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4","0",""},
new string[]{"Midweek","ASL-Midweek","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4","0",""},
new string[]{"Next Week","ASL-Next Week","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4","0",""}
},
new string[][]{//Lesson 8 (VRChat)
new string[]{"Gestures","ASL-Gestures","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4","0",""},
new string[]{"World","ASL-World","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4","2",""},
new string[]{"Record","ASL-Record","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4","0",""},
new string[]{"Discord","ASL-Discord","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4","0",""},
new string[]{"Streaming","ASL-Streaming","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4","0",""},
new string[]{"Headset (VR)","ASL-Headset (VR)","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4","2",""},
new string[]{"Desktop","ASL-Desktop","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4","0",""},
new string[]{"Computer","ASL-Computer","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4","0",""},
new string[]{"Instance","ASL-Instance","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4","0",""},
new string[]{"Public","ASL-Public","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4","0",""},
new string[]{"Invite","ASL-Invite","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4","0",""},
new string[]{"Private","ASL-Private","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4","0",""},
new string[]{"Add Friend","ASL-Add Friend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4","0",""},
new string[]{"Menu","ASL-Menu","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4","0",""},
new string[]{"Recharge","ASL-Recharge","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4","0",""},
new string[]{"Visit","ASL-Visit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4","0",""},
new string[]{"Request","ASL-Request","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4","0",""},
new string[]{"Login","ASL-Login","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4","0",""},
new string[]{"Logout","ASL-Logout","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4","0",""},
new string[]{"Schedule","ASL-Schedule","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4","0",""},
new string[]{"Event","ASL-Event","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4","0",""},
new string[]{"Online","ASL-Online","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4","0",""},
new string[]{"Offline","ASL-Offline","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4","0",""},
new string[]{"Cancel","ASL-Cancel","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4","0",""},
new string[]{"Portal","ASL-Portal","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4","2",""},
new string[]{"Camera","ASL-Camera","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4","0",""},
new string[]{"Avatar","ASL-Avatar","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4","2",""},
new string[]{"Photo","ASL-Photo","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4","0",""},
new string[]{"Join","ASL-Join","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4","0",""},
new string[]{"Leave","ASL-Leave","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4","0",""},
new string[]{"Climbing","ASL-Climbing","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4","0",""},
new string[]{"Falling","ASL-Falling","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4","0",""},
new string[]{"Walk","ASL-Walk","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4","0",""},
new string[]{"Hide","ASL-Hide","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4","0",""},
new string[]{"Block","ASL-Block","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4","0",""},
new string[]{"Crash","ASL-Crash","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4","0",""},
new string[]{"Lagging","ASL-Lagging","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4","2",""},
new string[]{"Restart","ASL-Restart","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4","0",""},
new string[]{"Send","ASL-Send","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4","0",""},
new string[]{"Receive","ASL-Receive","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4","0",""},
new string[]{"Security","ASL-Security","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4","0",""},
new string[]{"Donation","ASL-Donation","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4","0",""}
},
new string[][]{//Alphabet/Numbers (fingerspelling) (lesson9)
new string[]{"Fingerspell","ASL-Fingerspell","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0",""},
new string[]{"Fingerspell (Variant 2)","ASL-Fingerspell2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","1",""},
new string[]{"A","ASL-A","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4","2",""},
new string[]{"B","ASL-B","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","0",""},
new string[]{"B (Variant 2)","ASL-B2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4","1",""},
new string[]{"C","ASL-C","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4","2",""},
new string[]{"D","ASL-D","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4","2",""},
new string[]{"E","ASL-E","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4","2",""},
new string[]{"F","ASL-F","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","0",""},
new string[]{"F (Variant 2)","ASL-F2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4","1",""},
new string[]{"G","ASL-G","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4","2",""},
new string[]{"H","ASL-H","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4","2",""},
new string[]{"I","ASL-I","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","0",""},
new string[]{"I (Variant 2)","ASL-I2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4","1",""},
new string[]{"J","ASL-J","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","0","Trace out a 'J' midair with your pinky using a rotation of your wrist"},
new string[]{"J (Variant 2)","ASL-J2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4","1","Indicate your pinky is out, then trace out a 'J' midair with your pinky using a rotation of your wrist"},
new string[]{"K","ASL-K","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","0",""},
new string[]{"K (Variant 2)","ASL-K2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4","2",""},
new string[]{"L","ASL-L","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4","2",""},
new string[]{"M","ASL-M","Anonymous.","","1","2",""},
new string[]{"M (Variant 2)","ASL-M2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4","2",""},
new string[]{"N","ASL-N","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","2",""},
new string[]{"N","ASL-N2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4","2",""},
new string[]{"O","ASL-O","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4","2",""},
new string[]{"P","ASL-P","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4","2",""},
new string[]{"Q","ASL-Q","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4","2",""},
new string[]{"R","ASL-R","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4","2",""},
new string[]{"S","ASL-S","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4","2",""},
new string[]{"T","ASL-T","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4","2",""},
new string[]{"U","ASL-U","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","0",""},
new string[]{"U (Variant 2)","ASL-U2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4","1","The 'Peace Sign' on Regular VR looks like a V, so emphasise U shape by moving it in the shape of a U."},
new string[]{"V","ASL-V","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","0","The 'Peace Sign' on the Index looks like a U, so emphhasise a V shape by moving it in the shape of a V."},
new string[]{"V (Variant 2)","ASL-V2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4","1",""},
new string[]{"W","ASL-W","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","0",""},
new string[]{"W (Variant 2)","ASL-W2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4","2",""},
new string[]{"X","ASL-X","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","0",""},
new string[]{"X (Variant 2)","ASL-X2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4","2",""},
new string[]{"Y","ASL-Y","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","0",""},
new string[]{"Y (Variant 2)","ASL-Y2","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4","1",""},
new string[]{"Z","ASL-Z","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4","0",""},
new string[]{"Comma","ASL-Comma","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4","0",""},
new string[]{"Space","ASL-Space","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4","0","To indicate a space between fingerspelled words, you simply insert a very small pause between letters."},
new string[]{"@","ASL-@","Anonymous.","","2","Use for the symbol @, like in an email address."},
new string[]{"Number","ASL-Number","Anonymous.","","2","Pinch fingers together"},
new string[]{"0","ASL-0","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4","0",""},
new string[]{"1","ASL-1","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4","0",""},
new string[]{"2","ASL-2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4","0",""},
new string[]{"3","ASL-3","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4","0",""},
new string[]{"4","ASL-4","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4","0",""},
new string[]{"5","ASL-5","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4","0",""},
new string[]{"6","ASL-6","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4","0",""},
new string[]{"7","ASL-7","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4","0",""},
new string[]{"8","ASL-8","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4","0",""},
new string[]{"9","ASL-9","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4","0",""},
new string[]{"10","ASL-10","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4","0",""},
new string[]{"100","ASL-100","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4","0",""},
new string[]{"1000","ASL-1000","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4","0",""},
new string[]{"1000000","ASL-1000000","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4","0",""}
},
new string[][]{//Lesson 10 (Verbs & Actions p1)
new string[]{"Overlook","ASL-Overlook","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4","0",""},
new string[]{"Punish","ASL-Punish","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4","0",""},
new string[]{"Edit","ASL-Edit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4","0",""},
new string[]{"Erase","ASL-Erase","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4","0",""},
new string[]{"Write","ASL-Write","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4","0",""},
new string[]{"Proposal","ASL-Proposal","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4","0",""},
new string[]{"Add","ASL-Add","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4","0",""},
new string[]{"Remove","ASL-Remove","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4","0",""},
new string[]{"Agree","ASL-Agree","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4","0",""},
new string[]{"Disagree","ASL-Disagree","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4","0",""},
new string[]{"Admit","ASL-Admit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4","0",""},
new string[]{"Allow","ASL-Allow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4","0",""},
new string[]{"Attack","ASL-Attack","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4","0",""},
new string[]{"Fight","ASL-Fight","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4","0",""},
new string[]{"Defend","ASL-Defend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4","0",""},
new string[]{"Defeat (Overcome)","ASL-Defeat (Overcome)","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4","0",""},
new string[]{"Win","ASL-Win","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4","0",""},
new string[]{"Lose","ASL-Lose","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4","0",""},
new string[]{"Draw/Tie (Game)","ASL-Draw/Tie (Game)","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4","0","Draw or Tie, as in the same score at the end of a game."},
new string[]{"Give Up","ASL-Give Up","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4","0",""},
new string[]{"Skip","ASL-Skip","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4","0",""},
new string[]{"Ask","ASL-Ask","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-22.mp4","0",""},
new string[]{"Attach","ASL-Attach","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4","0",""},
new string[]{"Assist","ASL-Assist","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4","0",""},
new string[]{"Bait","ASL-Bait","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4","0",""},
new string[]{"Battle","ASL-Battle","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4","0",""},
new string[]{"Beat (Overcome)","ASL-Beat (Overcome)","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4","0",""},
new string[]{"Become","ASL-Become","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4","0",""},
new string[]{"Beg","ASL-Beg","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4","0",""},
new string[]{"Begin","ASL-Begin","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4","0",""},
new string[]{"Behave","ASL-Behave","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4","0",""},
new string[]{"Believe","ASL-Believe","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4","0",""},
new string[]{"Blame","ASL-Blame","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4","0",""},
new string[]{"Blow","ASL-Blow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4","0",""},
new string[]{"Blush","ASL-Blush","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4","0",""},
new string[]{"Bother/Harass","ASL-Bother/Harass","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4","0",""}
},
new string[][]{//Lesson 11 (Verbs & Actions p2)
new string[]{"Bend","ASL-Bend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4","0",""},
new string[]{"Bow","ASL-Bow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4","0",""},
new string[]{"Break","ASL-Break","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4","0",""},
new string[]{"Breathe","ASL-Breathe","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4","0",""},
new string[]{"Bring","ASL-Bring","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4","0","This is a directional sign."},
new string[]{"Build/Construct","ASL-Build/Construct","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4","0",""},
new string[]{"Bully","ASL-Bully","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4","0",""},
new string[]{"Burn","ASL-Burn","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4","0",""},
new string[]{"Buy","ASL-Buy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4","0",""},
new string[]{"Call","ASL-Call","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4","0",""},
new string[]{"Cancel","ASL-Cancel2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4","0",""},
new string[]{"Care","ASL-Care","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4","0",""},
new string[]{"Carry","ASL-Carry","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4","0",""},
new string[]{"Catch","ASL-Catch","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4","0",""},
new string[]{"Cause","ASL-Cause","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4","0",""},
new string[]{"Challenge","ASL-Challenge","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4","0",""},
new string[]{"Chance","ASL-Chance","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4","0","C Handshape. This sign is the Signed Exact English variant."},
new string[]{"Cheat","ASL-Cheat","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4","0",""},
new string[]{"Check","ASL-Check","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4","0",""},
new string[]{"Choose","ASL-Choose","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4","0",""},
new string[]{"Claim","ASL-Claim","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4","0",""},
new string[]{"Clean","ASL-Clean","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4","0",""},
new string[]{"Clear","ASL-Clear","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4","0",""},
new string[]{"Close","ASL-Close","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4","0","Close as in 'near'"},
new string[]{"Comfort","ASL-Comfort","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4","0",""},
new string[]{"Command","ASL-Command","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4","0",""},
new string[]{"Communicate","ASL-Communicate","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4","0","This sign is the Signed Exact English variant."},
new string[]{"Compare","ASL-Compare","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4","0",""},
new string[]{"Complain","ASL-Complain","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4","0",""},
new string[]{"Compliment","ASL-Compliment","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4","0",""},
new string[]{"Concentrate","ASL-Concentrate","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4","0",""},
new string[]{"Construct/Build","ASL-Construct/Build","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4","0",""},
new string[]{"Control","ASL-Control","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4","0",""},
new string[]{"Cook","ASL-Cook","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4","0",""},
new string[]{"Copy","ASL-Copy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4","0",""},
new string[]{"Correct","ASL-Correct","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4","0",""}
},
new string[][]{//Lesson 12 (Verbs & Actions p3)
new string[]{"Cough","ASL-Cough","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4","0",""},
new string[]{"Count","ASL-Count","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4","0",""},
new string[]{"Create","ASL-Create","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4","0",""},
new string[]{"Cuddle","ASL-Cuddle","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4","0",""},
new string[]{"Cut","ASL-Cut","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4","0",""},
new string[]{"Dab","ASL-Dab","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4","0",""},
new string[]{"Dance","ASL-Dance","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4","0",""},
new string[]{"Dare","ASL-Dare","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4","0",""},
new string[]{"Date","ASL-Date","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4","0",""},
new string[]{"Deal","ASL-Deal","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4","0",""},
new string[]{"Deliver","ASL-Deliver","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4","0",""},
new string[]{"Depend","ASL-Depend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4","0",""},
new string[]{"Describe","ASL-Describe","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4","0",""},
new string[]{"Dirty","ASL-Dirty","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4","0",""},
new string[]{"Disappear","ASL-Disappear","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4","0",""},
new string[]{"Disappoint","ASL-Disappoint","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4","0",""},
new string[]{"Disapprove","ASL-Disapprove","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4","0",""},
new string[]{"Discuss","ASL-Discuss","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4","0",""},
new string[]{"Disguise","ASL-Disguise","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4","0",""},
new string[]{"Disgust","ASL-Disgust","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4","0",""},
new string[]{"Dismiss","ASL-Dismiss","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4","0",""},
new string[]{"Disturb","ASL-Disturb","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4","0",""},
new string[]{"Doubt","ASL-Doubt","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4","0",""},
new string[]{"Dream","ASL-Dream","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4","0",""},
new string[]{"Dress","ASL-Dress","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4","0",""},
new string[]{"Drunk","ASL-Drunk","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4","0",""},
new string[]{"Drop","ASL-Drop","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4","0",""},
new string[]{"Drown","ASL-Drown","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4","0",""},
new string[]{"Dry","ASL-Dry","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4","0",""},
new string[]{"Dump","ASL-Dump","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4","0",""},
new string[]{"Dust","ASL-Dust","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4","0",""},
new string[]{"Earn","ASL-Earn","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4","0",""},
new string[]{"Effect","ASL-Effect","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4","0",""},
new string[]{"End","ASL-End","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4","0",""},
new string[]{"Escape","ASL-Escape","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4","0",""},
new string[]{"Escort","ASL-Escort","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4","0",""}
},
new string[][]{//Lesson 13 (Verbs & Actions p4)
new string[]{"Excuse","ASL-Excuse","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4","0",""},
new string[]{"Expose","ASL-Expose","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4","0",""},
new string[]{"Exist","ASL-Exist","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4","0",""},
new string[]{"Fail","ASL-Fail","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4","0",""},
new string[]{"Faint","ASL-Faint","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4","0",""},
new string[]{"Fake","ASL-Fake","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4","0",""},
new string[]{"Fart","ASL-Fart","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4","0",""},
new string[]{"Fear","ASL-Fear","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4","0",""},
new string[]{"Fill","ASL-Fill","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4","0",""},
new string[]{"Find","ASL-Find","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4","0",""},
new string[]{"Finish","ASL-Finish","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4","0",""},
new string[]{"Fix","ASL-Fix","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4","0",""},
new string[]{"Flip","ASL-Flip","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4","0",""},
new string[]{"Flirt","ASL-Flirt","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4","0",""},
new string[]{"Fly","ASL-Fly","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4","0",""},
new string[]{"Forbid","ASL-Forbid","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4","0",""},
new string[]{"Forgive","ASL-Forgive","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4","0",""},
new string[]{"Gain","ASL-Gain","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4","0",""},
new string[]{"Give","ASL-Give","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4","0",""},
new string[]{"Glow","ASL-Glow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4","0",""},
new string[]{"Grab","ASL-Grab","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4","0",""},
new string[]{"Grow","ASL-Grow","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4","0",""},
new string[]{"Guard","ASL-Guard","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4","0",""},
new string[]{"Guess","ASL-Guess","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4","0",""},
new string[]{"Guide","ASL-Guide","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4","0",""},
new string[]{"Harass/Bother","ASL-Harass/Bother","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4","0",""},
new string[]{"Harm","ASL-Harm","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4","0",""},
new string[]{"Hit","ASL-Hit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4","0",""},
new string[]{"Hold","ASL-Hold","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4","0",""},
new string[]{"Hop","ASL-Hop","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4","0",""},
new string[]{"Hope","ASL-Hope","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4","0",""},
new string[]{"Hunt","ASL-Hunt","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4","0",""},
new string[]{"Ignore","ASL-Ignore","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4","0",""},
new string[]{"Imagine","ASL-Imagine","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4","0",""},
new string[]{"Imitate","ASL-Imitate","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4","0",""},
new string[]{"Insult","ASL-Insult","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4","0",""}
},
new string[][]{//Lesson 14 (Verbs & Actions p5)
new string[]{"Interact","ASL-Interact","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4","0",""},
new string[]{"Interfere","ASL-Interfere","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4","0",""},
new string[]{"Judge","ASL-Judge","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4","0",""},
new string[]{"Jump","ASL-Jump","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4","0",""},
new string[]{"Justify","ASL-Justify","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4","0",""},
new string[]{"Just Kidding","ASL-Just Kidding","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4","0",""},
new string[]{"Keep","ASL-Keep","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4","0",""},
new string[]{"Kick","ASL-Kick","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4","0",""},
new string[]{"Kill","ASL-Kill","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4","0",""},
new string[]{"Knock","ASL-Knock","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4","0",""},
new string[]{"Lead","ASL-Lead","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4","0",""},
new string[]{"Lick","ASL-Lick","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4","0",""},
new string[]{"Lock","ASL-Lock","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4","0",""},
new string[]{"Manipulate","ASL-Manipulate","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4","0",""},
new string[]{"Melt","ASL-Melt","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4","0",""},
new string[]{"Mess","ASL-Mess","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4","0",""},
new string[]{"Miss","ASL-Miss","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4","0",""},
new string[]{"Mistake","ASL-Mistake","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4","0",""},
new string[]{"Mount","ASL-Mount","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4","0",""},
new string[]{"Move","ASL-Move","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4","0",""},
new string[]{"Murder","ASL-Murder","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4","0",""},
new string[]{"Nod","ASL-Nod","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4","0",""},
new string[]{"Note","ASL-Note","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4","0",""},
new string[]{"Notice","ASL-Notice","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4","0",""},
new string[]{"Obey","ASL-Obey","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4","0",""},
new string[]{"Obsess","ASL-Obsess","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4","0",""},
new string[]{"Obtain","ASL-Obtain","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4","0",""},
new string[]{"Occupy","ASL-Occupy","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4","0",""},
new string[]{"Offend","ASL-Offend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4","0",""},
new string[]{"Offer","ASL-Offer","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4","0",""},
new string[]{"Okay","ASL-Okay","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4","0",""},
new string[]{"Open","ASL-Open","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4","0",""},
new string[]{"Order","ASL-Order","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4","0",""},
new string[]{"Owe","ASL-Owe","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4","0",""},
new string[]{"Own","ASL-Own","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4","0",""},
new string[]{"Pass","ASL-Pass","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4","0",""}
},
new string[][]{//Lesson 15 (Verbs & Actions p6)
new string[]{"Pat","ASL-Pat","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4","2",""},
new string[]{"Party","ASL-Party","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4","0",""},
new string[]{"Pet","ASL-Pet","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4","2",""},
new string[]{"Pick","ASL-Pick","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4","2",""},
new string[]{"Plug","ASL-Plug","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4","2",""},
new string[]{"Point","ASL-Point","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4","2",""},
new string[]{"Poke","ASL-Poke","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4","2",""},
new string[]{"Pray","ASL-Pray","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4","2",""},
new string[]{"Prepare","ASL-Prepare","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4","2",""},
new string[]{"Present","ASL-Present","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4","0",""},
new string[]{"Pretend","ASL-Pretend","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4","2",""},
new string[]{"Protect","ASL-Protect","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4","2",""},
new string[]{"Prove","ASL-Prove","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4","2",""},
new string[]{"Publish","ASL-Publish","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4","2",""},
new string[]{"Puke","ASL-Puke","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","2",""},
new string[]{"Puke (Variant 2)","ASL-Puke2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4","2",""},
new string[]{"Pull","ASL-Pull","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4","2",""},
new string[]{"Punch","ASL-Punch","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4","2",""},
new string[]{"Put","ASL-Put","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4","2",""},
new string[]{"Push","ASL-Push","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4","2",""},
new string[]{"Question","ASL-Question","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","2",""},
new string[]{"Questions","ASL-Questions","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4","2",""},
new string[]{"Quit","ASL-Quit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4","2",""},
new string[]{"Quote","ASL-Quote","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4","0",""},
new string[]{"Race","ASL-Race","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4","2",""},
new string[]{"React","ASL-React","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4","2",""},
new string[]{"Recommended","ASL-Recommended","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4","0",""},
new string[]{"Refuse","ASL-Refuse","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4","2",""},
new string[]{"Regret","ASL-Regret","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4","0",""},
new string[]{"Remember","ASL-Remember","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4","2",""},
new string[]{"Replace","ASL-Replace","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4","0",""},
new string[]{"Report","ASL-Report","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4","2",""},
new string[]{"Reset","ASL-Reset","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4","2",""},
new string[]{"Ride","ASL-Ride","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4","2",""},
new string[]{"Rub","ASL-Rub","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4","2",""},
new string[]{"Rule","ASL-Rule","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4","2",""},
new string[]{"Run","ASL-Run","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4","0",""},
new string[]{"Save","ASL-Save","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4","2",""}
},
new string[][]{//Lesson 16 (Verbs & Actions p7)
new string[]{"Say","ASL-Say","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4","2",""},
new string[]{"Search","ASL-Search","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4","2",""},
new string[]{"See","ASL-See","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4","2",""},
new string[]{"Share","ASL-Share","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4","2",""},
new string[]{"Shock","ASL-Shock","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4","2",""},
new string[]{"Shop (Store)","ASL-Shop","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4","2",""},
new string[]{"Show","ASL-Show","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4","2","This is a directional sign."},
new string[]{"Shut Up","ASL-Shut Up","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4","2","IRL: Starts with a V hand and transitions to an U hand."},
new string[]{"Shut Down","ASL-Shut Down","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4","2",""},
new string[]{"Sing","ASL-Sing","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4","2",""},
new string[]{"Sit","ASL-Sit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4","2",""},
new string[]{"Smell","ASL-Smell","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4","2",""},
new string[]{"Smile","ASL-Smile","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4","2",""},
new string[]{"Smoke (Airborn)","ASL-Smoke","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4","2",""},
new string[]{"Speak/Talk","ASL-Speak/Talk","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4","0",""},
new string[]{"Spell (Fingerspelling)","ASL-Spell","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4","0",""},
new string[]{"Spit","ASL-Spit","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4","0",""},
new string[]{"Stand","ASL-Stand","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4","2",""},
new string[]{"Start","ASL-Start","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4","2",""},
new string[]{"Stay","ASL-Stay","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4","0",""},
new string[]{"Steal","ASL-Steal","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4","0",""},
new string[]{"Stop","ASL-Stop2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4","2",""},
new string[]{"Study","ASL-Study","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4","2",""},
new string[]{"Suffer","ASL-Suffer","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4","2",""},
new string[]{"Swim","ASL-Swim","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4","2",""},
new string[]{"Switch","ASL-Switch","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4","2",""},
new string[]{"Take (From)","ASL-Take (From)","GT4tube","https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4","2","Like taking candy from a baby"},
new string[]{"Communicate","ASL-Communicate2","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4","2",""},
new string[]{"Tell","ASL-Tell","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4","2",""},
new string[]{"Test","ASL-Test","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4","2",""},
new string[]{"Text","ASL-Text","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4","2",""},
new string[]{"Think","ASL-Think","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4","2",""},
new string[]{"Throw","ASL-Throw","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4","2",""},
new string[]{"Tie","ASL-Tie","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4","2",""},
new string[]{"Truth","ASL-Truth","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4","2",""},
new string[]{"Try","ASL-Try","Anonymous.","https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4","2",""},
},
new string[][]{
new string[]{"Type","ASL-Type","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-01.mp4","0",""},
new string[]{"Turn","ASL-Turn","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-02.mp4","0",""},
new string[]{"Upset","ASL-Upset","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-03.mp4","0",""},
new string[]{"Use","ASL-Use","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-04.mp4","0",""},
new string[]{"View","ASL-View","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-05.mp4","0",""},
new string[]{"Vomit","ASL-Vomit","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-06.mp4","0",""},
new string[]{"Wait","ASL-Wait","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-07.mp4","0",""},
new string[]{"Wake Up","ASL-Wake Up","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-08.mp4","0",""},
new string[]{"War","ASL-War","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-09.mp4","0",""},
new string[]{"Warn","ASL-Warn","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-10.mp4","0",""},
new string[]{"Waste","ASL-Waste","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-11.mp4","0",""},
new string[]{"Wash","ASL-Wash","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-12.mp4","0",""},
new string[]{"Watch","ASL-Watch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-13.mp4","0",""},
new string[]{"Wear","ASL-Wear","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-14.mp4","0",""},
new string[]{"Wobble","ASL-Wobble","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-15.mp4","0",""},
new string[]{"Wonder","ASL-Wonder","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-16.mp4","0",""},
new string[]{"Worry","ASL-Worry","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-17.mp4","0",""},
new string[]{"Work","ASL-Work","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-18.mp4","0",""},
new string[]{"Hug","ASL-Hug","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-19.mp4","0",""},
new string[]{"Touch","ASL-Touch","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-20.mp4","0",""},
new string[]{"Kiss","ASL-Kiss","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-21.mp4","0",""},
new string[]{"Trust","ASL-Trust","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-22.mp4","0",""},
new string[]{"True","ASL-True","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-23.mp4","0",""},
new string[]{"Lie","ASL-Lie","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-24.mp4","0",""},
new string[]{"Serve","ASL-Serve","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-25.mp4","0",""},
new string[]{"Calculate","ASL-Calculate","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-26.mp4","0",""},
new string[]{"Shower","ASL-Shower","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-27.mp4","0",""},
new string[]{"Bathe","ASL-Bathe","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-28.mp4","0",""},
new string[]{"Socialize","ASL-Socialize","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-29.mp4","0",""},
new string[]{"Help","ASL-Help","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-30.mp4","0",""},
new string[]{"Support","ASL-Support","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-31.mp4","0",""},
new string[]{"Take Care","ASL-Take Care","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-32.mp4","0",""},
new string[]{"Drive","ASL-Drive","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-33.mp4","0",""},
new string[]{"Travel","ASL-Travel","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-34.mp4","0",""},
new string[]{"Trip","ASL-Trip","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-35.mp4","0",""},
new string[]{"Fiction","ASL-Fiction","No Data Yet.","https://vrsignlanguage.net/ASL_videos/sheet17/17-36.mp4","0",""},

}}};

public string [] lessonnames = new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language. 
	"Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Alphabet/Numbers (Fingerspelling)","Verbs & Actions p1","Verbs & Actions p2: Ben-Cor",
	"Verbs & Actions p3: Cou-Esc","Verbs & Actions p4: Exc-Ins","Verbs & Actions p5: Int-Pas","Verbs & Actions p6: Pat-Sav","Verbs & Actions p7: Say-Try","Verbs & Actions p8","Food",
	"Animals / Machines","Places","Stuff / Weather","Clothes / Equipment","Fantasy / Characters", "Holidays / Special Days","Home stuff","Nature / Environment","Talk / Asking exercises",
	"Name sign users","Countries","Colors","Medical"};
    public string[] languages={"American Sign Language"};
    public string[] langshort={"ASL"};
    public string signnumber = "00000";
    //public string langnum = "0";
    public string prevsign="00000";
    //public int langnumber = 0;
    //public int lessonnumber=0;
    public Animator nana = GameObject.Find ("/Nana Avatar").GetComponent<Animator>();
    public Text currentsigntext = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>();
    public Text speechbubbletext = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text").GetComponent<Text>();
    public Text signcredittext = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text").GetComponent<Text>();
    public Text descriptiontext = GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text").GetComponent<Text>();

    GameObject[] buttons = new GameObject[56];
    GameObject[] backbuttons = new GameObject[2];
    
    GameObject[] indexicons = new GameObject[56];
    GameObject[] regvricons = new GameObject[56];
    GameObject[] bothvricons = new GameObject[56];
    Text[] buttontext = new Text[56];
    

public Text menuheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header").GetComponent<Text>();
public GameObject menuheader = GameObject.Find("/Udon Menu System/Root Canvas/Menu Header");

//public GameObject videotest;
    void Start()
    {

        DisplayLanguageSelectMenu();
    }
    void DisplayLanguageSelectMenu(){
        menuheadertext.text="VR Sign Language Select Menu";
        for(int x=0;x<56;x++){
            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");
            
            if(languages.Length>x){
                buttontext[x].text=languages[x];
                indexicons[x].SetActive(false);
                regvricons[x].SetActive(false);
                bothvricons[x].SetActive(false);
            }else{
                buttons[x].SetActive(false);
            }
        }

backbuttons[0]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Left Back Button");
backbuttons[1]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Left Back Button");


backbuttons[0].SetActive(false);
backbuttons[1].SetActive(false);
        
    }
    void buttonpushed(int x) {
	//figure out what the current signnumber is based on x and prevsign (figure out previous screen first)
	signnumber = figureoutcurrentsignnumber(figureoutpreviousboard(), x);

	if (signnumber == prevsign) {
		Debug.Log("The sign didn't change" + prevsign);
		return;
	}
	else {
		if (signnumber.Substring(0, 1) != prevsign.Substring(0, 1)) {
			Debug.Log("The language changed. Signnumber:"+signnumber+"  prevsign:"+prevsign);
			if (signnumber.Substring(0, 1) == "0") {
                Debug.Log("Language changed to 0 = back to lang select menu");
				DisplayLanguageSelectMenu();
			}else{
                Debug.Log("language is now"+signnumber.Substring(0, 1));
                DisplayLessonSelectMenu((int.Parse(signnumber.Substring(0, 1))));
            }
            prevsign = signnumber;
            Debug.Log("Signnumber:"+signnumber+"  prevsign:"+prevsign);
		} else if (signnumber.Substring(1, 2) != prevsign.Substring(1, 2)) { //if the language didn't change, did the lesson change?
            Debug.Log("The lesson changed. Signnumber:"+signnumber+"  prevsign:"+prevsign);
			//the lesson changed, disable video and parse + load the buttons for the next thing based on what the button was set to.
			if (signnumber.Substring(1, 2) == "00") { //if the lesson is 00 change to lesson select. the word should always be reset to 00 if changing lessons.
				if (signnumber.Substring(3, 2) != "00") {
					Debug.Log("why the fuck is the word not 00 when the lesson is 00");
				} else { //wordnumb is zero
					DisplayLessonSelectMenu((int.Parse(signnumber.Substring(0, 1))));
					prevsign = signnumber;
                    Debug.Log("Signnumber:"+signnumber+"  prevsign:"+prevsign);
				}
			}else{//lesson is not 00
            if (signnumber.Substring(3, 2) == "00") {
            DisplaySignSelectMenu((int.Parse(signnumber.Substring(0, 1))),(int.Parse(signnumber.Substring(1, 2))));
            prevsign = signnumber;
            Debug.Log("Signnumber:"+signnumber+"  prevsign:"+prevsign);
            }else{
                Debug.Log("How did the lesson change, but word is not 00?");
            }
            }
            //the lesson is not 00, so a word should be something
		} else if (signnumber.Substring(3, 2) != prevsign.Substring(3, 2)) //did the word change?
        { 
            if (prevsign.Substring(3, 2) != "00") { //if word changed and PREVIOUS word might have had a video turn it off.
TurnOffVideo();//this should also handle it if the url was blank.
            changeword(x); 
            prevsign = signnumber;
            Debug.Log("Signnumber:"+signnumber+"  prevsign:"+prevsign);
            }

            if (signnumber.Substring(3, 2) != "00") { //if the new sign is a word selection 
            changeword(x);
            prevsign = signnumber;
            Debug.Log("Signnumber:"+signnumber+"  prevsign:"+prevsign);
            }else{//the sign number is also 00's
            DisplaySignSelectMenu((int.Parse(signnumber.Substring(0, 1))),(int.Parse(signnumber.Substring(1, 2))));
					//DisplayLessonSelectMenu((int.Parse(signnumber.Substring(1, 2)))-1);
					prevsign = signnumber;
                    Debug.Log("Signnumber:"+signnumber+"  prevsign:"+prevsign);
                //display lesson select.


            }


		}
	}
}
void TurnOffVideo(){
            Debug.Log("Entering TurnOffVideo");
        if(prevsign.Substring(3,2)=="00"){
            Debug.Log("Why am I turning off a video when it shouldn't be on?");
        }else{
        int langnum;
        int lessonnum;
        int wordnum;
        if (int.TryParse(prevsign.Substring(0,1), out langnum)){
            if (int.TryParse(prevsign.Substring(1,2), out lessonnum)){
                if (int.TryParse(prevsign.Substring(3,2), out wordnum)){
      //  string[][][] AllLessons = new string[1][][];
     //   AllLessons[0]=ASLlessons;
                    
                    if(Alllessons[langnum-1][lessonnum-1][wordnum-1][4]==""){
//do nothing because there was no video
                    }else
                    {
                    GameObject.Find("/Udon Menu System/Video Container/"+langshort[langnum-1]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video").SetActive(false);    
                    }
                }
                else
                {
                    Debug.Log ("Not a valid wordnumber int inputted into turnoffvideo"+prevsign.Substring(3,2));
                }
            }
            else
            {
                Debug.Log ("Not a valid lessonnumber int inputted into turnoffvideo"+prevsign.Substring(1,2));
            }
        }
        else
        {
            Debug.Log ("Not a valid langnumber int inputted into turnoffvideo"+prevsign.Substring(0,1));
        }
    }
    }
    void changeword(int buttonnumber){//wordnum must not be 00.
Debug.Log("Entering changeword with buttonbumber of: "+buttonnumber);
    //        string[][][] AllLessons = new string[1][][];
      //  AllLessons[0]=ASLlessons;
        int langnum;
        int lessonnum;
        int wordnum;
        if (int.TryParse(signnumber.Substring(0,1), out langnum)){
            if (int.TryParse(signnumber.Substring(1,2), out lessonnum)){
                if (int.TryParse(signnumber.Substring(3,2), out wordnum)){
                    Debug.Log("langnum: "+langnum+" lessonnum: "+ lessonnum+" wordnum: "+wordnum);
                    //string[][][] AllLessons = new string[1][][];
                    //AllLessons[0]=ASLlessons;
                    //string [][][] AllLessons = { ASLlessons}; 
                    //char seperator = ',';
                    //string[] wordparameters = Alllessons[langnum-1][lessonnum-1][wordnum-1].Split(seperator);
                    //string[] wordparameters = new string[split1.Length];
                     Debug.Log("wordparameters[0]="+Alllessons[langnum-1][lessonnum-1][wordnum-1][0]+" wordparameters[1]=" +Alllessons[langnum-1][lessonnum-1][wordnum-1][1] + " wordparameters[2]="+Alllessons[langnum-1][lessonnum-1][wordnum-1][2] +" wordparameters[3]="+Alllessons[langnum-1][lessonnum-1][wordnum-1][3]+" wordparameters[4]="+Alllessons[langnum-1][lessonnum-1][wordnum-1][4]+
                     " wordparameters[5]"+Alllessons[langnum-1][lessonnum-1][wordnum-1][5]+" wordparameters[6]=" +Alllessons[langnum-1][lessonnum-1][wordnum-1][6]);

                    //AllLessons[langnum][lessonnum][wordnum]
                    if(Alllessons[langnum-1][lessonnum-1][wordnum-1][4]==""){
                        Debug.Log("Video is empty");
                    }else
                    {
                        Debug.Log("Looking for /Udon Menu System/Video Container/"+langshort[langnum-1]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video");
                        GameObject.Find("/Udon Menu System/Video Container/"+langshort[langnum-1]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video").SetActive(true);

                    }
                    Debug.Log("Setting animationint to: "+int.Parse(langnum+string.Format("{0:D2}",lessonnum)+string.Format("{0:D2}",wordnum)));
                        nana.SetInteger("sign",int.Parse(langnum+string.Format("{0:D2}",lessonnum)+string.Format("{0:D2}",wordnum))); 
                        speechbubbletext.text=Alllessons[langnum-1][lessonnum-1][wordnum-1][0];
                        currentsigntext.text=Alllessons[langnum-1][lessonnum-1][wordnum-1][0];
                        signcredittext.text=Alllessons[langnum-1][lessonnum-1][wordnum-1][2];
                        descriptiontext.text=Alllessons[langnum-1][lessonnum-1][wordnum-1][6];

        //0th value is the word 
        //1st value is the name of the animation state (Used in the animation controller populator script to generate transitions - needed to support multiple languages, and handle cases of multiple "words" with the same sign.)
        //2nd value is mocap credits. 
        //3rd value is video URL.
        //4th value is home sign indicator 0 = used in real world ASL, 1= vr only homesign
        //5th value is VR index or regular 0=indexonly , 1=generalvr,2=both
        //6th value is Sign description string
                }
                else
                {
                    Debug.Log ("Not a valid wordnumber int inputted into turnoffvideo"+prevsign.Substring(3,2));
                }
            }
            else
            {
                Debug.Log ("Not a valid lessonnumber int inputted into turnoffvideo"+prevsign.Substring(1,2));
            }
        }
        else
        {
            Debug.Log ("Not a valid langnumber int inputted into turnoffvideo"+prevsign.Substring(0,1));
        }
    
    }
        string figureoutcurrentsignnumber(int board, int buttonnumber){ //returns 00000 
        switch (board)
        {
            case 0:
            return (buttonnumber+1)+"0000"; 
            case 1:
            Debug.Log("Board: "+board+"Returning: "+prevsign.Substring(0,1)+string.Format("{0:D2}",buttonnumber+1)+"00");
            return prevsign.Substring(0,1)+string.Format("{0:D2}",buttonnumber+1)+"00";
            case 2:
            Debug.Log("Board: "+board+"Returning: "+prevsign.Substring(0,3)+string.Format("{0:D2}",buttonnumber+1));
            return prevsign.Substring(0,3)+string.Format("{0:D2}",buttonnumber+1);
            default:
            Debug.Log("How is boardnum this value"+board);
            return "0";
        }

    }
    int figureoutpreviousboard(){ //assuming prevsign is accessible, return which board we were on
        
        if(prevsign.Substring(0,1)=="0"){
            //we're on a lesson select board if we don't have a current lang selected
            //DisplayLanguageSelectMenu();?
            return 0;
        }else 
        if(prevsign.Substring(1,2)=="00"){
            //we're on a lesson select board if we have a lang selected (not 0) and lesson select is unknown (00's)
            return 1;
        }else//if(prevsign.Substring(3,2)=="00"){//is wordnum00?
        {
        //we're on a word select board since it can't be the other two.
        return 2;
        }
        //Debug.Log("Function 'figureoutpreviousboard' isn't sure what board we're on for some reason"+prevsign);
        //return 0;
    }
    void DisplayLessonSelectMenu(int languagenumber){ //I don't need the lesson number here because I'm displaying all lessons.
        Debug.Log("Now entering DisplayLessonSelectMenu with a language number of "+languagenumber);
        menuheadertext.text=langshort[languagenumber-1]+" Lesson Menu";
        Debug.Log("header set?");
        
        for(int x=0;x<56;x++){
            if(x<Alllessons[languagenumber-1].Length){

            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");

            if(lessonnames.Length>x){
                buttontext[x].text=(x+1)+") "+lessonnames[x];
                buttons[x].SetActive(true);
                indexicons[x].SetActive(false);
                regvricons[x].SetActive(false);
                bothvricons[x].SetActive(false);
            }else{
                buttons[x].SetActive(false);
            }
            }
        }
        backbuttons[0].SetActive(true);
        backbuttons[1].SetActive(true);
        //also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function...
    }

    void resetword(){
        nana.SetInteger("sign",0); //reset animator to animationint 0, which should be idle 
speechbubbletext.text="";
currentsigntext.text="";
signcredittext.text="";
descriptiontext.text="";
    }
    public void BackButtonClicked(){//figure out previous sign and set word/lesson to 00's and then update the menu/reset animationint/text
    Debug.Log("back button pushed");
        int board = figureoutpreviousboard();
        
            switch (board)
        {
            case 0:
            Debug.Log("There shouldn't be any back button enabled on the main language menu. Wtf");
            prevsign="00000";
            break;
            case 1: //we're currently on the lang select menu. switch to lang select menu.
            prevsign="00000";
            DisplayLanguageSelectMenu();
            //resetword();
            break; //set new sign =
            case 2: //we're on the word select, go back to lesson select
            if(prevsign.Substring(3, 2) != "00"){
                TurnOffVideo();
            } 
            resetword();
            prevsign=prevsign.Substring(0,2)+"0000";
            DisplayLessonSelectMenu(int.Parse(prevsign.Substring(0,1)));
            break;
            default:
            Debug.Log("How is boardnum this value"+board);
            break;
        }
    }

    

    
    void DisplaySignSelectMenu(int langnum, int lessonnum){
        Debug.Log("Now entering DisplaySignSelectMenu with a language number of "+langnum+" and a lessonnum of "+lessonnum);
      //  string[][][] AllLessons = new string[1][][];
     //   AllLessons[0]=ASLlessons;
        menuheadertext.text=langshort[langnum-1]+" Lesson Menu";
        
        for(int x=0;x<56;x++){
            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");
            
            if(Alllessons[langnum-1][lessonnum-1].Length>x){
                buttontext[x].text="          "+(x+1)+") "+Alllessons[langnum-1][lessonnum-1][x][0];
                switch (Alllessons[langnum-1][lessonnum-1][x][5]){//vr type
                    case "0":
                    indexicons[x].SetActive(true);
                    break;
                    case "1":
                    regvricons[x].SetActive(true);
                    break;
                    case "2":
                    bothvricons[x].SetActive(true);
                    break;
                    default:
                indexicons[x].SetActive(false);
                regvricons[x].SetActive(false);
                bothvricons[x].SetActive(false);
                    break;
                }

            }else{
                buttons[x].SetActive(false);
            }
        }
backbuttons[0].SetActive(true);
backbuttons[1].SetActive(true);
        //also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function... 
    }



public void B0()
{
//Debug.Log("button0 pushed");
buttonpushed(0);

}
public void B1()
{        
//Debug.Log("button1 pushed");
buttonpushed(1);
}
public void B2()
{
buttonpushed(2);
}
public void B3()
{
buttonpushed(3);
}
public void B4()
{
buttonpushed(4);
}
public void B5()
{
buttonpushed(5);
}
public void B6()
{
buttonpushed(6);
}
public void B7()
{
buttonpushed(7);
}
public void B8()
{
buttonpushed(8);
}
public void B9()
{
buttonpushed(9);
}
public void B10()
{
buttonpushed(10);
}
public void B11()
{
buttonpushed(11);
}
public void B12()
{
buttonpushed(12);
}
public void B13()
{
buttonpushed(13);
}
public void B14()
{
buttonpushed(14);
}
public void B15()
{
buttonpushed(15);
}
public void B16()
{
buttonpushed(16);
}
public void B17()
{
buttonpushed(17);
}
public void B18()
{
buttonpushed(18);
}
public void B19()
{
buttonpushed(19);
}
public void B20()
{
buttonpushed(20);
}
public void B21()
{
buttonpushed(21);
}
public void B22()
{
buttonpushed(22);
}
public void B23()
{
buttonpushed(23);
}
public void B24()
{
buttonpushed(24);
}
public void B25()
{
buttonpushed(25);
}
public void B26()
{
buttonpushed(26);
}
public void B27()
{
buttonpushed(27);
}
public void B28()
{
buttonpushed(28);
}
public void B29()
{
buttonpushed(29);
}
public void B30()
{
buttonpushed(30);
}
public void B31()
{
buttonpushed(31);
}
public void B32()
{
buttonpushed(32);
}
public void B33()
{
buttonpushed(33);
}
public void B34()
{
buttonpushed(34);
}
public void B35()
{
buttonpushed(35);
}
public void B36()
{
buttonpushed(36);
}
public void B37()
{
buttonpushed(37);
}
public void B38()
{
buttonpushed(38);
}
public void B39()
{
buttonpushed(39);
}
public void B40()
{
buttonpushed(40);
}
public void B41()
{
buttonpushed(41);
}
public void B42()
{
buttonpushed(42);
}
public void B43()
{
buttonpushed(43);
}
public void B44()
{
buttonpushed(44);
}
public void B45()
{
buttonpushed(45);
}
public void B46()
{
buttonpushed(46);
}
public void B47()
{
buttonpushed(47);
}
public void B48()
{
buttonpushed(48);
}
public void B49()
{
buttonpushed(49);
}
public void B50()
{
buttonpushed(50);
}
public void B51()
{
buttonpushed(51);
}
public void B52()
{
buttonpushed(52);
}
public void B53()
{
buttonpushed(53);
}
public void B54()
{
buttonpushed(54);
}
public void B55()
{
buttonpushed(55);
}



}
