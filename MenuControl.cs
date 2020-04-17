using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;


public class test : UdonSharpBehaviour
{
    public string ASLL1 = "Hello,ASL-Hello,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4,0,2|How (are) You,ASL-How Are You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4,0,2|What's Up?,ASL-What's Up?,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4,0,0|What's Up? (Variant 2),ASL-What's Up?2,Bob64,https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4,1,2|Nice (to) Meet You,ASL-Nice (to) Meet You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4,0,2|Good,ASL-Good,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4,0,2|Bad,ASL-Bad,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4,0,2|Yes,ASL-Yes,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4,0,2|No,ASL-No,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4,0,2|So-So,ASL-So-So,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4,0,2|Sick,ASL-Sick,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4,0,0|Sick,ASL-Sick2,Bob64,https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4,1,2|Hurt,ASL-Hurt,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4,0,2|You're Welcome,ASL-You're Welcome,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4,0,2|Goodbye,ASL-Goodbye,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4,0,2|Good Morning,ASL-Good Morning,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4,0,2|Good Afternoon,ASL-Good Afternoon,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4,0,2|Good Evening,ASL-Good Evening,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4,0,2|Good Night,ASL-Good Night,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4,0,2|See You Later,ASL-See You Later,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4,0,2|Please,ASL-Please,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4,0,2|Sorry,ASL-Sorry,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4,0,2|Forget,ASL-Forget,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4,0,2|Sleep,ASL-Sleep,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4,0,2|Bed,ASL-Bed,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4,0,2|Jump/Change World,ASL-Jump/Change World,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4,0,2|Thank You,ASL-Thank You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4,0,2|I Love You,ASL-I Love You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4,0,2|ILK (I Love You),ASL-ILY,No Data Yet.,,0,0,This sign is the combinations of the letters I, L, and Y. It's the compact version of I Love You.|Go Away,ASL-Go Away,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4,0,2|Going To,ASL-Going To,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4,0,2,Directional Sign, you point to where you're going.|Follow,ASL-Follow,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4,0,2|Come,ASL-Come,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4,0,2|Hearing (Person),ASL-Hearing (Person),GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4,0,2,Use this when discussing a person that can hear.|Deaf,ASL-Deaf,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4,0,2|Deaf (Variant 2),ASL-Deaf2,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4,0,2|Hard of Hearing,ASL-Hard of Hearing,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4,0,2|Mute,ASL-Mute,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4,0,2|Write Slow,ASL-Write Slow,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4,0,2|Can't Read,ASL-Can't Read,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4,0,2";
public string [][] ASLlessons = {
new string[]{//Lesson 1 (Daily Use)
"Hello,ASL-Hello,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-01.mp4,0,2,","How (are) You,ASL-How Are You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-02.mp4,0,2,","What's Up?,ASL-What's Up?,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4,0,0,","What's Up? (Variant 2),ASL-What's Up?2,Bob64,https://vrsignlanguage.net/ASL_videos/sheet01/01-03.mp4,1,2,","Nice (to) Meet You,ASL-Nice (to) Meet You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-04.mp4,0,2,","Good,ASL-Good,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-05.mp4,0,2,","Bad,ASL-Bad,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-06.mp4,0,2,","Yes,ASL-Yes,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-07.mp4,0,2,","No,ASL-No,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-08.mp4,0,2,","So-So,ASL-So-So,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-09.mp4,0,2,","Sick,ASL-Sick,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4,0,0,","Sick,ASL-Sick2,Bob64,https://vrsignlanguage.net/ASL_videos/sheet01/01-10.mp4,1,2,","Hurt,ASL-Hurt,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-11.mp4,0,2,","You're Welcome,ASL-You're Welcome,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-12.mp4,0,2,","Goodbye,ASL-Goodbye,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-13.mp4,0,2,","Good Morning,ASL-Good Morning,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-14.mp4,0,2,","Good Afternoon,ASL-Good Afternoon,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-15.mp4,0,2,","Good Evening,ASL-Good Evening,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-16.mp4,0,2,","Good Night,ASL-Good Night,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-17.mp4,0,2,","See You Later,ASL-See You Later,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-18.mp4,0,2,","Please,ASL-Please,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-19.mp4,0,2,","Sorry,ASL-Sorry,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-20.mp4,0,2,","Forget,ASL-Forget,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-21.mp4,0,2,","Sleep,ASL-Sleep,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-22.mp4,0,2,","Bed,ASL-Bed,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-23.mp4,0,2,","Jump/Change World,ASL-Jump/Change World,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-24.mp4,0,2,","Thank You,ASL-Thank You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-25.mp4,0,2,","I Love You,ASL-I Love You,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-26.mp4,0,2,","ILK (I Love You),ASL-ILY,No Data Yet.,,0,0,This sign is the combinations of the letters I, L, and Y. It's the compact version of I Love You.","Go Away,ASL-Go Away,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-27.mp4,0,2,","Going To,ASL-Going To,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-28.mp4,0,2,Directional Sign, you point to where you're going.","Follow,ASL-Follow,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-29.mp4,0,2,","Come,ASL-Come,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-30.mp4,0,2,","Hearing (Person),ASL-Hearing (Person),GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-31.mp4,0,2,Use this when discussing a person that can hear.","Deaf,ASL-Deaf,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4,0,2,","Deaf (Variant 2),ASL-Deaf2,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-32.mp4,0,2,","Hard of Hearing,ASL-Hard of Hearing,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-33.mp4,0,2,","Mute,ASL-Mute,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-34.mp4,0,2,","Write Slow,ASL-Write Slow,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-35.mp4,0,2,","Can't Read,ASL-Can't Read,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet01/01-36.mp4,0,2,"},
new string[]{//Lesson 2 (Pointing use Question/Answer)
"I (Me),ASL-I (Me),GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-01.mp4,0,2,","My,ASL-My,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-02.mp4,0,2,Open palm implies possessive. eg: That wallet is mine.","Your,ASL-Your,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-03.mp4,0,2,A possessive form of 'you'. eg: That's your wallet.","His,ASL-His,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-04.mp4,0,2,","Her,ASL-Her,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-05.mp4,0,2,","We,ASL-We,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-06.mp4,0,2,","They,ASL-They,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-07.mp4,0,2,You sweep your pointer over the people you're referring to.","Their,ASL-Their,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-08.mp4,0,2,Possessive form of they. eg: This is their house.","Over There,ASL-Over There,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-09.mp4,0,2,","Our,ASL-Our,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-10.mp4,0,2,","It's,ASL-It's,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-11.mp4,0,1,","Inside,ASL-Inside,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-12.mp4,0,2,","Outside,ASL-Outside,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-13.mp4,0,2,","Hidden,ASL-Hidden,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-14.mp4,0,2,","Behind,ASL-Behind,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-15.mp4,0,2,","Above,ASL-Above,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-16.mp4,0,2,","Below,ASL-Below,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-17.mp4,0,2,","Here,ASL-Here,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-18.mp4,0,2,","Beside,ASL-Beside,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-19.mp4,0,2,","Back,ASL-Back,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-20.mp4,0,2,","Front,ASL-Front,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-21.mp4,0,2,","Who,ASL-Who,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-22.mp4,0,2,","Where,ASL-Where,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-23.mp4,0,2,","When,ASL-When,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-24.mp4,0,2,","Why,ASL-Why,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-25.mp4,0,2,","Which,ASL-Which,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-26.mp4,0,2,","What,ASL-What,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4,0,1,This variant is perferred over variant 2, as variant 2 is a Signed Exact English Variant","What (Variant 2),ASL-What2,Bob64,https://vrsignlanguage.net/ASL_videos/sheet02/02-27.mp4,0,0,A Signed Exact English variant of What.","How,ASL-How,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-28.mp4,0,2,","How (Variant 2),ASL-How2,No Data Yet.,,0,2,This version is done with two A-hands next to each other and a twisting motion of your dominate hand.","How Many,ASL-How Many,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-29.mp4,0,2,","Can,ASL-Can,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-30.mp4,0,2,","Can't,ASL-Can't,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-31.mp4,0,2,","Want,ASL-Want,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-32.mp4,0,2,","Have,ASL-Have,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-33.mp4,0,2,","Get,ASL-Get,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-34.mp4,0,2,","Will/Future,ASL-Will,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-35.mp4,0,2,This is also the sign for Future","Take (Up),ASL-Take,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-36.mp4,0,2,Take as in 'take-up a class' or 'take-up a child (like you're adopting one)'","Need,ASL-Need,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-37.mp4,0,2,","Not,ASL-Not,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-38.mp4,0,0,","Or,ASL-Or,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-39.mp4,0,0,This is just O and R fingerspelled.","And,ASL-And,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-40.mp4,0,0,","For,ASL-For,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-41.mp4,0,0,","At,ASL-At,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4,0,0,","At (Variant 2),ASL-At2,GT4tube,https://vrsignlanguage.net/ASL_videos/sheet02/02-42.mp4,0,0,"},
new string[]{//Lesson 3 (Common)
"Teach,ASL-Teach,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-01.mp4,0,0,","Learn,ASL-Learn,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-02.mp4,0,0,","Person,ASL-Person,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-03.mp4,0,0,","Student,ASL-Student,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-04.mp4,0,0,","Teacher,ASL-Teacher,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-05.mp4,0,0,","Friend,ASL-Friend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-06.mp4,0,0,","Sign,ASL-Sign,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-07.mp4,0,0,","Language,ASL-Language,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-08.mp4,0,0,","Understand,ASL-Understand,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-09.mp4,0,0,","Know,ASL-Know,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-10.mp4,0,0,","Don't Know,ASL-Don't Know,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-11.mp4,0,0,","Be Right Back (BRB),ASL-Be Right Back (BRB),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-12.mp4,0,0,","Accept,ASL-Accept,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-13.mp4,0,0,","Denied,ASL-Denied,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-14.mp4,0,0,","Name,ASL-Name,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-15.mp4,0,0,","New,ASL-New,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-16.mp4,0,0,","Old,ASL-Old2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-17.mp4,0,0,","Very,ASL-Very,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-18.mp4,0,0,","Jokes,ASL-Jokes,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-19.mp4,0,0,","Funny,ASL-Funny,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-20.mp4,0,0,","Play,ASL-Play,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-21.mp4,0,0,","Favorite,ASL-Favorite,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-22.mp4,0,0,","Draw (Pencil),ASL-Draw (Pencil),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-23.mp4,0,0,","Stop,ASL-Stop,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-24.mp4,0,0,","Read,ASL-Read,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-25.mp4,0,0,","Make,ASL-Make,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-26.mp4,0,0,","Write,ASL-Write2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-27.mp4,0,0,","Again / Repeat,ASL-Again / Repeat,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-28.mp4,0,0,","Slow,ASL-Slow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-29.mp4,0,0,","Fast,ASL-Fast,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-30.mp4,0,0,","Rude,ASL-Rude,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-31.mp4,0,0,","Eat,ASL-Eat,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-32.mp4,0,0,","Drink,ASL-Drink,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-33.mp4,0,0,","Watch,ASL-Watch,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-34.mp4,0,0,","Work,ASL-Work,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-35.mp4,0,0,","Live,ASL-Live,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-36.mp4,0,0,","Play Game,ASL-Play Game,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-37.mp4,0,0,","Same,ASL-Same,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-38.mp4,0,0,","Alright,ASL-Alright,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-39.mp4,0,0,","People,ASL-People,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-40.mp4,0,0,","Browsing the Internet,ASL-Browsing the Internet,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-41.mp4,0,0,","Movie,ASL-Movie,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet03/03-42.mp4,0,0,"},
new string[]{//Lesson 4 (People)
"Family,ASL-Family,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-01.mp4,0,0,","Boy,ASL-Boy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-02.mp4,0,0,","Girl,ASL-Girl,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-03.mp4,0,0,","Brother,ASL-Brother,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-04.mp4,0,0,","Sister,ASL-Sister,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-05.mp4,0,0,","Brother-in-law,ASL-Brother-in-law,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-06.mp4,0,0,","Sister-in-law,ASL-Sister-in-law,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-07.mp4,0,0,","Father,ASL-Father,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-08.mp4,0,0,","Grandpa,ASL-Grandpa,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-09.mp4,0,0,","Mother,ASL-Mother,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-10.mp4,0,0,","Grandma,ASL-Grandma,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-11.mp4,0,0,","Baby,ASL-Baby,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-12.mp4,0,0,","Child,ASL-Child,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-13.mp4,0,0,","Teen,ASL-Teen,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-14.mp4,0,0,","Adult,ASL-Adult,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-15.mp4,0,0,","Aunt,ASL-Aunt,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-16.mp4,0,0,","Uncle,ASL-Uncle,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-17.mp4,0,0,","Stranger,ASL-Stranger,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-18.mp4,0,0,","Acquaintance,ASL-Acquaintance,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-19.mp4,0,0,","Parents,ASL-Parents,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-20.mp4,0,0,","Born,ASL-Born,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-21.mp4,0,0,","Dead,ASL-Dead,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-22.mp4,0,0,","Marriage,ASL-Marriage,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-23.mp4,0,0,","Divorce,ASL-Divorce,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-24.mp4,0,0,","Single,ASL-Single,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-25.mp4,0,0,","Young,ASL-Young,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-26.mp4,0,0,","Old,ASL-Old,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-27.mp4,0,0,","Age,ASL-Age,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-28.mp4,0,0,","Birthday,ASL-Birthday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-29.mp4,0,0,","Celebrate,ASL-Celebrate,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-30.mp4,0,0,","Enemy,ASL-Enemy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-31.mp4,0,0,","Interpreter,ASL-Interpreter,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-32.mp4,0,0,","No One,ASL-No One,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-33.mp4,0,0,","Anyone,ASL-Anyone,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-34.mp4,0,0,","Someone,ASL-Someone,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-35.mp4,0,0,","Everyone,ASL-Everyone,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet04/04-36.mp4,0,0,"},
new string[]{//Lesson 5 (Feelings / Reactions)
"Like,ASL-Like,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-01.mp4,0,0,","Hate,ASL-Hate,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-02.mp4,0,0,","Fine,ASL-Fine,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-03.mp4,0,0,","Tired,ASL-Tired,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-04.mp4,0,0,","Sleepy,ASL-Sleep2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-05.mp4,0,0,","Confused,ASL-Confused,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-06.mp4,0,0,","Smart,ASL-Smart,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-07.mp4,0,0,","Attention / Focus,ASL-Attention / Focus,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-08.mp4,0,0,","Nevermind,ASL-Nevermind,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-09.mp4,0,0,","Angry,ASL-Angry,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-10.mp4,0,0,","Laughing,ASL-Laughing,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-11.mp4,0,0,","LOL,ASL-LOL,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-12.mp4,0,0,","Curious,ASL-Curious,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-13.mp4,0,0,","In Love,ASL-In Love,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-14.mp4,0,0,","Awesome,ASL-Awesome,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-15.mp4,0,0,","Great,ASL-Great,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-16.mp4,0,0,","Nice,ASL-Nice,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-17.mp4,0,0,","Cute,ASL-Cute,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-18.mp4,0,0,","Feel,ASL-Feel,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-19.mp4,0,0,","Pity,ASL-Pity,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-20.mp4,0,0,","Envy,ASL-Envy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-21.mp4,0,0,","Hungry,ASL-Hungry,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-22.mp4,0,0,","Alive,ASL-Alive,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-23.mp4,0,0,","Bored,ASL-Bored,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-24.mp4,0,0,","Cry,ASL-Cry,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-25.mp4,0,0,","Happy,ASL-Happy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-26.mp4,0,0,","Sad,ASL-Sad,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-27.mp4,0,0,","Suffering,ASL-Suffering,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-28.mp4,0,0,","Surprised,ASL-Surprised,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-29.mp4,0,0,","Careful,ASL-Careful,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-30.mp4,0,0,","Enjoy,ASL-Enjoy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-31.mp4,0,0,","Disgusted,ASL-Disgusted,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-32.mp4,0,0,","Embarassed,ASL-Embarassed,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-33.mp4,0,0,","Shy,ASL-Shy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-34.mp4,0,0,","Lonely,ASL-Lonely,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-35.mp4,0,0,","Stressed,ASL-Stressed,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-36.mp4,0,0,","Scared,ASL-Scared,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-37.mp4,0,0,","Excited,ASL-Excited,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-38.mp4,0,0,","Shame,ASL-Shame,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-39.mp4,0,0,","Struggle,ASL-Struggle,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-40.mp4,0,0,","Friendly,ASL-Friendly,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-41.mp4,0,0,","Mean,ASL-Mean,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet05/05-42.mp4,0,0,"},
new string[]{//Lesson 6 (Value) 
"More,ASL-More,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-01.mp4,0,0,","Less,ASL-Less,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-02.mp4,0,0,","Big,ASL-Big,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-03.mp4,0,0,","Small/A Little,ASL-Small,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-04.mp4,0,0,","Full,ASL-Full,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-05.mp4,0,0,","Empty,ASL-Empty,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-06.mp4,0,0,","Half,ASL-Half,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-07.mp4,0,0,","Quarter,ASL-Quarter,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-08.mp4,0,0,","Long,ASL-Long,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-09.mp4,0,0,","Short (Time),ASL-Short (Time),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-10.mp4,0,0,","A Lot/Many,ASL-A Lot/Many,Placeholder.,,0,0,","Unlimited,ASL-Unlimited,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-13.mp4,0,0,","Limited,ASL-Limited,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-14.mp4,0,0,","All,ASL-All,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-15.mp4,0,0,","Nothing,ASL-Nothing,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-16.mp4,0,0,","Ever,ASL-Ever,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-17.mp4,0,0,","Everything,ASL-Everything,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-18.mp4,0,0,","Everytime,ASL-Everytime,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-19.mp4,0,0,","Always,ASL-Always,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-20.mp4,0,0,","Often,ASL-Often,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-21.mp4,0,0,","Sometimes,ASL-Sometimes,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-22.mp4,0,0,","Heavy,ASL-Heavy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-23.mp4,0,0,","Lightweight,ASL-Lightweight,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-24.mp4,0,0,","Hard,ASL-Hard,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-25.mp4,0,0,","Soft,ASL-Soft,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-26.mp4,0,0,","Strong,ASL-Strong,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-27.mp4,0,0,","Weak,ASL-Weak,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-28.mp4,0,0,","First,ASL-First,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-29.mp4,0,0,","Second,ASL-Second,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-30.mp4,0,0,","Third,ASL-Third,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-31.mp4,0,0,","Next,ASL-Next,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-32.mp4,0,0,","Last,ASL-Last,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-33.mp4,0,0,","Before,ASL-Before,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-34.mp4,0,0,","After,ASL-After,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-35.mp4,0,0,","Busy,ASL-Busy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-36.mp4,0,0,","Free,ASL-Free,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-37.mp4,0,0,Signed Exact English variant","High,ASL-High,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-38.mp4,0,0,","Low,ASL-Low,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-39.mp4,0,0,","Fat,ASL-Fat,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-40.mp4,0,0,","Thin,ASL-Thin,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-41.mp4,0,0,","Value,ASL-Value,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet06/06-42.mp4,0,0,"},
new string[]{//Lesson 7 (Time)
"Time,ASL-Time,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-01.mp4,0,0,","Year,ASL-Year,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-02.mp4,0,0,","Season,ASL-Season,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-03.mp4,0,0,","Month,ASL-Month,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-04.mp4,0,0,","Week,ASL-Week,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-05.mp4,0,0,","Day,ASL-Day,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-06.mp4,0,0,","Weekend,ASL-Weekend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-07.mp4,0,0,","Hours,ASL-Hours,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-08.mp4,0,0,","Minutes,ASL-Minutes,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-09.mp4,0,0,","Seconds,ASL-Seconds,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-10.mp4,0,0,","Today,ASL-Today,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-11.mp4,0,0,","Tomorrow,ASL-Tomorrow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-12.mp4,0,0,","Yesterday,ASL-Yesterday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-13.mp4,0,0,","Morning,ASL-Morning,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-14.mp4,0,0,","Afternoon,ASL-Afternoon,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-15.mp4,0,0,","Evening,ASL-Evening,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-16.mp4,0,0,","Night,ASL-Night,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-17.mp4,0,0,","Sunrise,ASL-Sunrise,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-18.mp4,0,0,","Sunset,ASL-Sunset,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-19.mp4,0,0,","All Night,ASL-All Night,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-20.mp4,0,0,","All Day,ASL-All Day,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-21.mp4,0,0,","Sunday,ASL-Sunday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-22.mp4,0,0,","Monday,ASL-Monday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-23.mp4,0,0,","Tuesday,ASL-Tuesday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-24.mp4,0,0,","Wednesday,ASL-Wednesday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-25.mp4,0,0,","Thursday,ASL-Thursday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-26.mp4,0,0,","Friday,ASL-Friday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-27.mp4,0,0,","Saturday,ASL-Saturday,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-28.mp4,0,0,","Autumn,ASL-Autumn,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-29.mp4,0,0,","Winter,ASL-Winter,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-30.mp4,0,0,","Spring,ASL-Spring,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-31.mp4,0,0,","Summer,ASL-Summer,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-32.mp4,0,0,","Now,ASL-Now,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-33.mp4,0,0,","Never,ASL-Never,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-34.mp4,0,0,","Soon,ASL-Soon,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-35.mp4,0,0,","Later,ASL-Later,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-36.mp4,0,0,","Past,ASL-Past,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-37.mp4,0,0,","Future,ASL-Future,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-38.mp4,0,0,","Earlier,ASL-Earlier,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-39.mp4,0,0,","Midweek,ASL-Midweek,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-40.mp4,0,0,","Next Week,ASL-Next Week,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet07/07-41.mp4,0,0,"},
new string[]{//Lesson 8 (VRChat)
"Gestures,ASL-Gestures,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-01.mp4,0,0,","World,ASL-World,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-02.mp4,1,2,","Record,ASL-Record,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-03.mp4,0,0,","Discord,ASL-Discord,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-04.mp4,1,0,","Streaming,ASL-Streaming,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-05.mp4,0,0,","Headset (VR),ASL-Headset (VR),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-06.mp4,1,2,","Desktop,ASL-Desktop,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-07.mp4,0,0,","Computer,ASL-Computer,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-08.mp4,0,0,","Instance,ASL-Instance,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-09.mp4,0,0,","Public,ASL-Public,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-10.mp4,0,0,","Invite,ASL-Invite,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-11.mp4,0,0,","Private,ASL-Private,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-12.mp4,0,0,","Add Friend,ASL-Add Friend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-13.mp4,0,0,","Menu,ASL-Menu,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-14.mp4,0,0,","Recharge,ASL-Recharge,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-15.mp4,0,0,","Visit,ASL-Visit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-16.mp4,0,0,","Request,ASL-Request,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-17.mp4,0,0,","Login,ASL-Login,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-18.mp4,0,0,","Logout,ASL-Logout,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-19.mp4,0,0,","Schedule,ASL-Schedule,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-20.mp4,0,0,","Event,ASL-Event,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-21.mp4,0,0,","Online,ASL-Online,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-22.mp4,0,0,","Offline,ASL-Offline,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-23.mp4,0,0,","Cancel,ASL-Cancel,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-24.mp4,0,0,","Portal,ASL-Portal,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-25.mp4,1,2,","Camera,ASL-Camera,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-26.mp4,0,0,","Avatar,ASL-Avatar,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-27.mp4,1,2,","Photo,ASL-Photo,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-28.mp4,0,0,","Join,ASL-Join,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-29.mp4,0,0,","Leave,ASL-Leave,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-30.mp4,0,0,","Climbing,ASL-Climbing,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-31.mp4,0,0,","Falling,ASL-Falling,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-32.mp4,0,0,","Walk,ASL-Walk,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-33.mp4,0,0,","Hide,ASL-Hide,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-34.mp4,0,0,","Block,ASL-Block,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-35.mp4,0,0,","Crash,ASL-Crash,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-36.mp4,0,0,","Lagging,ASL-Lagging,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-37.mp4,1,2,","Restart,ASL-Restart,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-38.mp4,0,0,","Send,ASL-Send,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-39.mp4,0,0,","Receive,ASL-Receive,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-40.mp4,0,0,","Security,ASL-Security,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-41.mp4,0,0,","Donation,ASL-Donation,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet08/08-42.mp4,0,0,"},
new string[]{//Alphabet / Numbers (fingerspelling) (lesson9)
"Fingerspell,ASL-Fingerspell,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4,0,0,","Fingerspell (Variant 2),ASL-Fingerspell2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4,0,1,","A,ASL-A,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-01.mp4,1,2,","B,ASL-B,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4,0,0,","B (Variant 2),ASL-B2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-02.mp4,1,1,","C,ASL-C,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-03.mp4,0,2,","D,ASL-D,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-04.mp4,0,2,","E,ASL-E,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-05.mp4,1,2,","F,ASL-F,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4,0,0,","F (Variant 2),ASL-F2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-06.mp4,1,1,","G,ASL-G,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-07.mp4,0,2,","H,ASL-H,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-08.mp4,0,2,","I,ASL-I,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4,0,0,","I (Variant 2),ASL-I2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-09.mp4,1,1,","J,ASL-J,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4,0,0,Trace out a 'J' midair with your pinky using a rotation of your wrist","J (Variant 2),ASL-J2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-10.mp4,1,1,Indicate your pinky is out, then trace out a 'J' midair with your pinky using a rotation of your wrist","K,ASL-K,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4,1,0,","K (Variant 2),ASL-K2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-11.mp4,1,2,","L,ASL-L,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-12.mp4,0,2,","M,ASL-M,Placeholder.,,1,2,","M (Variant 2),ASL-M2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-13.mp4,1,2,","N,ASL-N,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4,1,2,","N,ASL-N2,No Data Yet.d,https://vrsignlanguage.net/ASL_videos/sheet09/09-14.mp4,1,2,","O,ASL-O,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-15.mp4,0,2,","P,ASL-P,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-16.mp4,0,2,","Q,ASL-Q,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-17.mp4,0,2,","R,ASL-R,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-18.mp4,1,2,","S,ASL-S,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-19.mp4,0,2,","T,ASL-T,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-20.mp4,1,2,","U,ASL-U,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4,0,0,","U (Variant 2),ASL-U2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-21.mp4,1,1,The 'Peace Sign' on Regular VR looks like a V, so emphasise U shape by moving it in the shape of a U.","V,ASL-V,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4,1,0,The 'Peace Sign' on the Index looks like a U, so emphhasise a V shape by moving it in the shape of a V.","V (Variant 2),ASL-V2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-22.mp4,0,1,","W,ASL-W,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4,0,0,","W (Variant 2),ASL-W2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-23.mp4,1,2,","X,ASL-X,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4,0,0,","X (Variant 2),ASL-X2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-24.mp4,1,2,","Y,ASL-Y,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4,0,0,","Y (Variant 2),ASL-Y2,No Data Yet.,https://vrsignlanguage.net/ASL_videos/sheet09/09-25.mp4,1,1,","Z,ASL-Z,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-26.mp4,0,0,","Comma,ASL-Comma,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-41.mp4,0,0,","Space,ASL-Space,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-42.mp4,0,0,To indicate a space between fingerspelled words, you simply insert a very small pause between letters.","@,ASL-@,Placeholder.,,0,2,Use for the symbol @, like in an email address.","Number,ASL-Number,Placeholder.,,0,2,Pinch fingers together","0,ASL-0,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-27.mp4,0,0,","1,ASL-1,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-28.mp4,0,0,","2,ASL-2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-29.mp4,0,0,","3,ASL-3,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-30.mp4,0,0,","4,ASL-4,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-31.mp4,0,0,","5,ASL-5,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-32.mp4,0,0,","6,ASL-6,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-33.mp4,0,0,","7,ASL-7,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-34.mp4,0,0,","8,ASL-8,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-35.mp4,0,0,","9,ASL-9,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-36.mp4,0,0,","10,ASL-10,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-37.mp4,0,0,","100,ASL-100,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-38.mp4,0,0,","1000,ASL-1000,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-39.mp4,0,0,","1000000,ASL-1000000,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet09/09-40.mp4,0,0,"},
new string[]{//Lesson 10 (Verbs & Actions p1)
"Overlook,ASL-Overlook,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-01.mp4,0,0,","Punish,ASL-Punish,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-02.mp4,0,0,","Edit,ASL-Edit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-03.mp4,0,0,","Erase,ASL-Erase,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-04.mp4,0,0,","Write,ASL-Write,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-05.mp4,0,0,","Proposal,ASL-Proposal,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-06.mp4,0,0,","Add,ASL-Add,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-07.mp4,0,0,","Remove,ASL-Remove,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-08.mp4,0,0,","Agree,ASL-Agree,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-09.mp4,0,0,","Disagree,ASL-Disagree,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-10.mp4,0,0,","Admit,ASL-Admit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-11.mp4,0,0,","Allow,ASL-Allow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-12.mp4,0,0,","Attack,ASL-Attack,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-13.mp4,0,0,","Fight,ASL-Fight,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-14.mp4,0,0,","Defend,ASL-Defend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-15.mp4,0,0,","Defeat (Overcome),ASL-Defeat (Overcome),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-16.mp4,0,0,","Win,ASL-Win,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-17.mp4,0,0,","Lose,ASL-Lose,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-18.mp4,0,0,","Draw (Game),ASL-Draw (Game),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-19.mp4,0,0,","Give Up,ASL-Give Up,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-20.mp4,0,0,","Skip,ASL-Skip,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-21.mp4,0,0,","Ask,ASL-Ask,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-22.mp4,0,0,","Attach,ASL-Attach,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-23.mp4,0,0,","Assist,ASL-Assist,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-24.mp4,0,0,","Bait,ASL-Bait,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-25.mp4,0,0,","Battle,ASL-Battle,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-26.mp4,0,0,","Beat (Overcome),ASL-Beat (Overcome),Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-27.mp4,0,0,","Become,ASL-Become,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-28.mp4,0,0,","Beg,ASL-Beg,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-29.mp4,0,0,","Begin,ASL-Begin,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-30.mp4,0,0,","Behave,ASL-Behave,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-31.mp4,0,0,","Believe,ASL-Believe,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-32.mp4,0,0,","Blame,ASL-Blame,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-33.mp4,0,0,","Blow,ASL-Blow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-34.mp4,0,0,","Blush,ASL-Blush,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-35.mp4,0,0,","Bother/Harass,ASL-Bother/Harass,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet10/10-36.mp4,0,0,"},
new string[]{//Lesson 11 (Verbs & Actions p2)
"Bend,ASL-Bend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-01.mp4,0,0,","Bow,ASL-Bow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-02.mp4,0,0,","Break,ASL-Break,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-03.mp4,0,0,","Breathe,ASL-Breathe,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-04.mp4,0,0,","Bring,ASL-Bring,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-05.mp4,0,0,(Directional Sign)","Build/Construct,ASL-Build/Construct,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-06.mp4,0,0,","Bully,ASL-Bully,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-07.mp4,0,0,","Burn,ASL-Burn,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-08.mp4,0,0,","Buy,ASL-Buy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-09.mp4,0,0,","Call,ASL-Call,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-10.mp4,0,0,","Cancel,ASL-Cancel2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-11.mp4,0,0,","Care,ASL-Care,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-12.mp4,0,0,","Carry,ASL-Carry,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-13.mp4,0,0,","Catch,ASL-Catch,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-14.mp4,0,0,","Cause,ASL-Cause,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-15.mp4,0,0,","Challenge,ASL-Challenge,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-16.mp4,0,0,","Chance,ASL-Chance,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-17.mp4,0,0,C Handshape. This sign is the Signed Exact English variant.","Cheat,ASL-Cheat,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-18.mp4,0,0,","Check,ASL-Check,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-19.mp4,0,0,","Choose,ASL-Choose,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-20.mp4,0,0,","Claim,ASL-Claim,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-21.mp4,0,0,","Clean,ASL-Clean,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-22.mp4,0,0,","Clear,ASL-Clear,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-23.mp4,0,0,","Close,ASL-Close,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-24.mp4,0,0,Close as in 'near'","Comfort,ASL-Comfort,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-25.mp4,0,0,","Command,ASL-Command,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-26.mp4,0,0,","Communicate,ASL-Communicate,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-27.mp4,0,0,This sign is the Signed Exact English variant.","Compare,ASL-Compare,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-28.mp4,0,0,","Complain,ASL-Complain,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-29.mp4,0,0,","Compliment,ASL-Compliment,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-30.mp4,0,0,","Concentrate,ASL-Concentrate,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-31.mp4,0,0,","Construct/Build,ASL-Construct/Build,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-32.mp4,0,0,","Control,ASL-Control,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-33.mp4,0,0,","Cook,ASL-Cook,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-34.mp4,0,0,","Copy,ASL-Copy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-35.mp4,0,0,","Correct,ASL-Correct,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet11/11-36.mp4,0,0,"},
new string[]{//Lesson 12 (Verbs & Actions p3)
"Cough,ASL-Cough,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-01.mp4,0,0,","Count,ASL-Count,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-02.mp4,0,0,","Create,ASL-Create,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-03.mp4,0,0,","Cuddle,ASL-Cuddle,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-04.mp4,0,0,","Cut,ASL-Cut,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-05.mp4,0,0,","Dab,ASL-Dab,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-06.mp4,0,0,","Dance,ASL-Dance,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-07.mp4,0,0,","Dare,ASL-Dare,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-08.mp4,0,0,","Date,ASL-Date,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-09.mp4,0,0,","Deal,ASL-Deal,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-10.mp4,0,0,","Deliver,ASL-Deliver,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-11.mp4,0,0,","Depend,ASL-Depend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-12.mp4,0,0,","Describe,ASL-Describe,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-13.mp4,0,0,","Dirty,ASL-Dirty,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-14.mp4,0,0,","Disappear,ASL-Disappear,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-15.mp4,0,0,","Disappoint,ASL-Disappoint,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-16.mp4,0,0,","Disapprove,ASL-Disapprove,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-17.mp4,0,0,","Discuss,ASL-Discuss,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-18.mp4,0,0,","Disguise,ASL-Disguise,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-19.mp4,0,0,","Disgust,ASL-Disgust,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-20.mp4,0,0,","Dismiss,ASL-Dismiss,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-21.mp4,0,0,","Disturb,ASL-Disturb,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-22.mp4,0,0,","Doubt,ASL-Doubt,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-23.mp4,0,0,","Dream,ASL-Dream,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-24.mp4,0,0,","Dress,ASL-Dress,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-25.mp4,0,0,","Drunk,ASL-Drunk,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-26.mp4,0,0,","Drop,ASL-Drop,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-27.mp4,0,0,","Drown,ASL-Drown,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-28.mp4,0,0,","Dry,ASL-Dry,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-29.mp4,0,0,","Dump,ASL-Dump,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-30.mp4,0,0,","Dust,ASL-Dust,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-31.mp4,0,0,","Earn,ASL-Earn,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-32.mp4,0,0,","Effect,ASL-Effect,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-33.mp4,0,0,","End,ASL-End,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-34.mp4,0,0,","Escape,ASL-Escape,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-35.mp4,0,0,","Escort,ASL-Escort,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet12/12-36.mp4,0,0,"},
new string[]{//Lesson 13 (Verbs & Actions p4)
"Excuse,ASL-Excuse,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-01.mp4,0,0,","Expose,ASL-Expose,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-02.mp4,0,0,","Exist,ASL-Exist,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-03.mp4,0,0,","Fail,ASL-Fail,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-04.mp4,0,0,","Faint,ASL-Faint,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-05.mp4,0,0,","Fake,ASL-Fake,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-06.mp4,0,0,","Fart,ASL-Fart,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-07.mp4,0,0,","Fear,ASL-Fear,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-08.mp4,0,0,","Fill,ASL-Fill,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-09.mp4,0,0,","Find,ASL-Find,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-10.mp4,0,0,","Finish,ASL-Finish,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-11.mp4,0,0,","Fix,ASL-Fix,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-12.mp4,0,0,","Flip,ASL-Flip,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-13.mp4,0,0,","Flirt,ASL-Flirt,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-14.mp4,0,0,","Fly,ASL-Fly,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-15.mp4,0,0,","Forbid,ASL-Forbid,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-16.mp4,0,0,","Forgive,ASL-Forgive,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-17.mp4,0,0,","Gain,ASL-Gain,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-18.mp4,0,0,","Give,ASL-Give,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-19.mp4,0,0,","Glow,ASL-Glow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-20.mp4,0,0,","Grab,ASL-Grab,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-21.mp4,0,0,","Grow,ASL-Grow,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-22.mp4,0,0,","Guard,ASL-Guard,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-23.mp4,0,0,","Guess,ASL-Guess,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-24.mp4,0,0,","Guide,ASL-Guide,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-25.mp4,0,0,","Harass/Bother,ASL-Harass/Bother,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-26.mp4,0,0,","Harm,ASL-Harm,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-27.mp4,0,0,","Hit,ASL-Hit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-28.mp4,0,0,","Hold,ASL-Hold,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-29.mp4,0,0,","Hop,ASL-Hop,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-30.mp4,0,0,","Hope,ASL-Hope,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-31.mp4,0,0,","Hunt,ASL-Hunt,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-32.mp4,0,0,","Ignore,ASL-Ignore,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-33.mp4,0,0,","Imagine,ASL-Imagine,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-34.mp4,0,0,","Imitate,ASL-Imitate,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-35.mp4,0,0,","Insult,ASL-Insult,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet13/13-36.mp4,0,0,"},
new string[]{//Lesson 14 (Verbs & Actions p5)
"Interact,ASL-Interact,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-01.mp4,0,0,","Interfere,ASL-Interfere,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-02.mp4,0,0,","Judge,ASL-Judge,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-03.mp4,0,0,","Jump,ASL-Jump,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-04.mp4,0,0,","Justify,ASL-Justify,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-05.mp4,0,0,","Just Kidding,ASL-Just Kidding,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-06.mp4,0,0,","Keep,ASL-Keep,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-07.mp4,0,0,","Kick,ASL-Kick,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-08.mp4,0,0,","Kill,ASL-Kill,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-09.mp4,0,0,","Knock,ASL-Knock,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-10.mp4,0,0,","Lead,ASL-Lead,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-11.mp4,0,0,","Lick,ASL-Lick,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-12.mp4,0,0,","Lock,ASL-Lock,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-13.mp4,0,0,","Manipulate,ASL-Manipulate,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-14.mp4,0,0,","Melt,ASL-Melt,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-15.mp4,0,0,","Mess,ASL-Mess,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-16.mp4,0,0,","Miss,ASL-Miss,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-17.mp4,0,0,","Mistake,ASL-Mistake,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-18.mp4,0,0,","Mount,ASL-Mount,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-19.mp4,0,0,","Move,ASL-Move,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-20.mp4,0,0,","Murder,ASL-Murder,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-21.mp4,0,0,","Nod,ASL-Nod,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-22.mp4,0,0,","Note,ASL-Note,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-23.mp4,0,0,","Notice,ASL-Notice,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-24.mp4,0,0,","Obey,ASL-Obey,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-25.mp4,0,0,","Obsess,ASL-Obsess,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-26.mp4,0,0,","Obtain,ASL-Obtain,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-27.mp4,0,0,","Occupy,ASL-Occupy,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-28.mp4,0,0,","Offend,ASL-Offend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-29.mp4,0,0,","Offer,ASL-Offer,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-30.mp4,0,0,","Okay,ASL-Okay,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-31.mp4,0,0,","Open,ASL-Open,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-32.mp4,0,0,","Order,ASL-Order,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-33.mp4,0,0,","Owe,ASL-Owe,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-34.mp4,0,0,","Own,ASL-Own,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-35.mp4,0,0,","Pass,ASL-Pass,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet14/14-36.mp4,0,0,"},
new string[]{//Lesson 15 (Verbs & Actions p6)
"Pat,ASL-Pat,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-01.mp4,0,2,","Party,ASL-Party,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-02.mp4,0,0,","Pet,ASL-Pet,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-03.mp4,0,2,","Pick,ASL-Pick,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-04.mp4,0,2,","Plug,ASL-Plug,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-05.mp4,0,2,","Point,ASL-Point,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-06.mp4,0,2,","Poke,ASL-Poke,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-07.mp4,0,2,","Pray,ASL-Pray,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-08.mp4,0,2,","Prepare,ASL-Prepare,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-09.mp4,1,2,","Present,ASL-Present,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-10.mp4,0,0,","Pretend,ASL-Pretend,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-11.mp4,0,2,","Protect,ASL-Protect,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-12.mp4,0,2,","Prove,ASL-Prove,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-13.mp4,0,2,","Publish,ASL-Publish,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-14.mp4,0,2,","Puke,ASL-Puke,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-15.mp4,0,2,","Pull,ASL-Pull,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-16.mp4,0,2,","Punch,ASL-Punch,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-17.mp4,0,2,","Put,ASL-Put,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-18.mp4,0,2,","Push,ASL-Push,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-19.mp4,0,2,","Question,ASL-Question,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-20.mp4,0,2,","Quit,ASL-Quit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-21.mp4,0,2,","Quote,ASL-Quote,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-22.mp4,0,0,","Race,ASL-Race,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-23.mp4,0,2,","React,ASL-React,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-24.mp4,0,2,","Recommended,ASL-Recommended,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-25.mp4,0,0,","Refuse,ASL-Refuse,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-26.mp4,0,2,","Regret,ASL-Regret,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-27.mp4,0,2,","Remember,ASL-Remember,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-28.mp4,0,2,","Replace,ASL-Replace,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-29.mp4,0,0,","Report,ASL-Report,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-30.mp4,0,2,","Reset,ASL-Reset,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-31.mp4,0,2,","Ride,ASL-Ride,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-32.mp4,0,2,","Rub,ASL-Rub,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-33.mp4,0,2,","Rule,ASL-Rule,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-34.mp4,1,2,","Run,ASL-Run,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-35.mp4,0,0,","Save,ASL-Save,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet15/15-36.mp4,0,2,"},
new string[]{//Lesson 16 (Verbs & Actions p7)
"Say,ASL-Say,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-01.mp4,0,2,","Search,ASL-Search,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-02.mp4,0,2,","See,ASL-See,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-03.mp4,0,2,","Share,ASL-Share,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-04.mp4,0,2,","Shock,ASL-Shock,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-05.mp4,0,2,","Shop (Store),ASL-Shop,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-06.mp4,0,2,","Show,ASL-Show,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-07.mp4,0,2,Directional Sign","Shut Up,ASL-Shut Up,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-08.mp4,0,2,","Shut Down,ASL-Shut Down,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-09.mp4,0,2,","Sing,ASL-Sing,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-10.mp4,0,2,","Sit,ASL-Sit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-11.mp4,0,2,","Smell,ASL-Smell,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-12.mp4,0,2,","Smile,ASL-Smile,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-13.mp4,0,2,","Smoke (Airborn),ASL-Smoke,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-14.mp4,0,2,","Speak,ASL-Speak,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-15.mp4,0,0,","Spell (Fingerspelling),ASL-Spell,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-16.mp4,0,0,","Spit,ASL-Spit,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-17.mp4,0,0,","Stand,ASL-Stand,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-18.mp4,0,2,","Start,ASL-Start,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-19.mp4,0,2,","Stay,ASL-Stay,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-20.mp4,0,0,","Steal,ASL-Steal,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-21.mp4,0,2,","Stop,ASL-Stop2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-22.mp4,0,2,","Study,ASL-Study,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-23.mp4,0,2,","Suffer,ASL-Suffer,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-24.mp4,0,2,","Swim,ASL-Swim,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-25.mp4,0,2,","Switch,ASL-Switch,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-26.mp4,0,2,","Take (from),ASL-Take2,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-27.mp4,0,2,Like taking candy from a baby","Talk,ASL-Talk,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-28.mp4,0,2,","Tell,ASL-Tell,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-29.mp4,0,2,","Test,ASL-Test,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-30.mp4,0,2,","Text,ASL-Text,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-31.mp4,0,2,","Think,ASL-Think,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-32.mp4,0,2,","Throw,ASL-Throw,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-33.mp4,0,2,","Tie,ASL-Tie,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-34.mp4,0,2,","Truth,ASL-Truth,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-35.mp4,0,2,","Try,ASL-Try,Placeholder.,https://vrsignlanguage.net/ASL_videos/sheet16/16-36.mp4,0,2,"}
};
                    //public string[][][] AllLessons = new string[1][][];
                    
public string [] lessonnames = new string[]{//array of ASL (and possibilly other language) lesson names - can be unique per language.
	"Daily Use","Pointing use Question/Answer","Common","People","Feelings / Reactions","Value","Time","VRChat","Alphabet/Numbers (Fingerspelling)","Verbs & Actions p1","Verbs & Actions p2: Ben-Cor",
	"Verbs & Actions p3: Cou-Esc","Verbs & Actions p4: Exc-Ins","Verbs & Actions p5: Int-Pas","Verbs & Actions p6: Pat-Sav","Verbs & Actions p7: Say-Try","Verbs & Actions p8","Food",
	"Animals / Machines","Places","Stuff / Weather","Clothes / Equipment","Fantasy / Characters", "Holidays / Special Days","Home stuff","Nature / Environment","Talk / Asking exercises",
	"Name sign users","Countries","Colors","Medical"};

    public string[] languages={"American Sign Language"};
    public string[] langshort={"ASL"};
    public string signnumber = "00000";
    public string langnum = "0";
    public string prevsign="00000";
    public int langnumber = 0;
    public int lessonnumber=0;
    public GameObject nana = GameObject.Find ("/Nana Avatar");
    public Text currentsigntext = GameObject.Find ("/Nana Avatar/Canvas/Current Sign Panel/Current Sign Text").GetComponent<Text>();
    public Text speechbubbletext = GameObject.Find ("/Nana Avatar/Armature/Canvas/Bubble/text").GetComponent<Text>();
    public Text signcredittext = GameObject.Find ("/Nana Avatar/Canvas/Credit Panel/Credit Text").GetComponent<Text>();
    public Text descriptiontext = GameObject.Find ("/Nana Avatar/Canvas/Description Panel/Description Text").GetComponent<Text>();
    GameObject[] buttons = new GameObject[56];
    GameObject[] indexicons = new GameObject[56];
    GameObject[] regvricons = new GameObject[56];
    GameObject[] bothvricons = new GameObject[56];
    Text[] buttontext = new Text[56];
    


/*
        char seperator = '|';
        string[] split1 = ASLL1.Split(seperator);
        string[] signwordarray = new string[split1.Length];
        for (int wordnum = 0; wordnum < split1.Length; wordnum++){
            char seperator2 = ',';
            string[] split2 = split1[wordnum].Split(seperator2);
            //Debug.Log("wtf"+split2[0]);
            buttontext.text=
        }
*/
Text menuheadertext = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Menu Header").GetComponent<Text>();

//public GameObject videotest;
    void Start()
    {

        DisplayLanguageSelectMenu();
    }
    void resetword(){
        nana.GetComponent<Animator>().SetInteger("sign",0); //reset animator to animationint 0, which should be idle
speechbubbletext.text="";
currentsigntext.text="";
signcredittext.text="";
descriptiontext.text="";
    }
    void BackButtonClicked(){//figure out previous sign and set word/lesson to 00's and then update the menu/reset animationint/text
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
    string figureoutcurrentsignnumber(int board, int buttonnumber){ //returns 00000 
        switch (board)
        {
            case 0:
            return (buttonnumber-1)+"0000"; 
            case 1:
            return prevsign.Substring(0,1)+(buttonnumber-1)+"00";
            case 2:
            return prevsign.Substring(0,3)+(buttonnumber-1);
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
    void buttonpushed(int x) {
	//figure out what the current signnumber is based on x and prevsign (figure out previous screen first)
	signnumber = figureoutcurrentsignnumber(figureoutpreviousboard(), x);

	if (signnumber == prevsign) {
		Debug.Log("The sign didn't change" + prevsign);
		return;
	}
	else {
/*
		int langnum;
		int lessonnum;
		int wordnum;
		int prevlangnum;
		int prevlessonnum;
		int prevwordnum;
		//do nothing if the sign is the same as the previous one
		if (int.TryParse(signnumber.Substring(0, 1), out langnum)) {} else {
			Debug.Log("signnumber invalid wordnumber int inputted into buttonpushed" + signnumber.Substring(3, 2));
		}
		if (int.TryParse(signnumber.Substring(1, 2), out lessonnum)) {} else {
			Debug.Log("signnumber invalid lessonnumber int inputted into buttonpushed" + signnumber.Substring(1, 2));
		}
		if (int.TryParse(signnumber.Substring(3, 2), out wordnum)) {} else {
			Debug.Log("signnumber invalid langnumber int inputted into buttonpushed" + signnumber.Substring(0, 1));
		}
		if (int.TryParse(prevsign.Substring(0, 1), out prevlangnum)) {} else {
			Debug.Log("prevsign invalid wordnumber int inputted into buttonpushed" + prevsign.Substring(3, 2));
		}
		if (int.TryParse(prevsign.Substring(1, 2), out prevlessonnum)) {} else {
			Debug.Log("prevsign invalid lessonnumber int inputted into buttonpushed" + prevsign.Substring(1, 2));
		}
		if (int.TryParse(prevsign.Substring(3, 2), out prevwordnum)) {} else {
			Debug.Log("prevsign invalid langnumber int inputted into buttonpushed" + prevsign.Substring(0, 1));
		}*/


		if (signnumber.Substring(0, 1) != prevsign.Substring(0, 1)) {
			Debug.Log("holyshit the language changed. gotta be to the main menu");
			if (signnumber.Substring(0, 1) == "0") {
				DisplayLanguageSelectMenu();
				prevsign = signnumber;
			}
		} else if (signnumber.Substring(1, 2) != prevsign.Substring(1, 2)) { //did the lesson change?
			//the lesson changed, disable video and parse + load the buttons for the next thing based on what the button was set to.
			if (signnumber.Substring(1, 2) == "00") { //change to lesson select. the word should always be reset to 00 if changing lessons.
				if (signnumber.Substring(3, 2) != "00") {
					Debug.Log("why the fuck is the word not 00 when the lesson is 00");
				} else { //wordnumb is zero
					DisplayLessonSelectMenu(int.Parse(signnumber.Substring(1, 2)));
					prevsign = signnumber;
				}
			}
            //the lesson is not 00, so a word should be something
		} else if (signnumber.Substring(3, 2) != prevsign.Substring(3, 2)) //did the word change?
        { 
            if (prevsign.Substring(3, 2) != "00") { //if word changed and PREVIOUS word might have had a video turn it off.
TurnOffVideo();
            changeword(x); //this should also handle it if the url was blank.
            }

            if (signnumber.Substring(3, 2) != "00") { //if the new sign is a word selection 

            }else{//the sign number is also 00's
					DisplayLessonSelectMenu(int.Parse(signnumber.Substring(1, 2)));
					prevsign = signnumber;
                //display lesson select.


            }


		}
	}
}

    void changeword(int buttonnumber){//wordnum must not be 00.
            string[][][] AllLessons = new string[1][][];
        AllLessons[0]=ASLlessons;
        int langnum;
        int lessonnum;
        int wordnum;
        if (int.TryParse(signnumber.Substring(0,1), out langnum)){
            if (int.TryParse(signnumber.Substring(1,2), out lessonnum)){
                if (int.TryParse(signnumber.Substring(3,2), out wordnum)){
                    //string[][][] AllLessons = new string[1][][];
                    //AllLessons[0]=ASLlessons;
                    //string [][][] AllLessons = { ASLlessons}; 
                    char seperator = ',';
                    string[] split1 = AllLessons[langnum][lessonnum][wordnum].Split(seperator);
                    string[] wordparameters = new string[split1.Length];
                    //AllLessons[langnum][lessonnum][wordnum]
                    if(wordparameters[4]==""){
//do nothing because there was no video 
                    }else
                    {
                        GameObject.Find("/Udon Menu System/Video Container/"+langshort[langnum]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video").SetActive(false);
                        nana.GetComponent<Animator>().SetInteger("sign",langnum+lessonnum+wordnum); 
                        speechbubbletext.text=wordparameters[0];
                        currentsigntext.text=wordparameters[0];
                        signcredittext.text=wordparameters[3];
                        descriptiontext.text=wordparameters[6];
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

    void TurnOffVideo(){
        if(prevsign.Substring(3,2)=="00"){
            Debug.Log("Why am I turning off a video when it shouldn't be on?");
        }else{
        int langnum;
        int lessonnum;
        int wordnum;
        if (int.TryParse(prevsign.Substring(0,1), out langnum)){
            if (int.TryParse(prevsign.Substring(1,2), out lessonnum)){
                if (int.TryParse(prevsign.Substring(3,2), out wordnum)){
        string[][][] AllLessons = new string[1][][];
        AllLessons[0]=ASLlessons;
                    char seperator = ',';
                    string[] wordparameters = AllLessons[langnum][lessonnum][wordnum].Split(seperator);
                    //string[] wordparameters = new string[split.Length];
                    //AllLessons[langnum][lessonnum][wordnum]
                    if(wordparameters[4]==""){
//do nothing because there was no video
                    }else
                    {
                    GameObject.Find("/Udon Menu System/Video Container/"+langshort[langnum]+" Videos/L"+lessonnum+" Videos/L"+lessonnum+" S"+wordnum+" Video").SetActive(false);    
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
    void DisplaySignSelectMenu(int langnum, int lessonnum){
        string[][][] AllLessons = new string[1][][];
        AllLessons[0]=ASLlessons;
        menuheadertext.text=langshort[langnum]+" Lesson Menu";
        char seperator = ',';
        for(int x=0;x<56;x++){
            buttons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1));
            buttontext[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Text").GetComponent<Text>();
            indexicons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Index VR Icon");
            regvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Regular VR Icon");
            bothvricons[x]=GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button "+(x+1)+"/Both VR Icon");
            
            if(AllLessons[langnum][lessonnum].Length>x){
                
                string[] wordparameters = AllLessons[langnum][lessonnum][x].Split(seperator);
                //string[] wordparameters = new string[split.Length]; 
                buttontext[x].text=wordparameters[0];


                switch (wordparameters[5]){//vr type
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
        //also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function... 
    }
    void DisplayLessonSelectMenu(int langnnum){
        
        menuheadertext.text=langshort[langnnum]+" Lesson Menu";
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
        //also need to blank out avatar animationint, current sign text and so on i guess. or maybe this should be in a seperate function...
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
        
    }

void B0()       
{
buttonpushed(0);
}
void B1()
{        
buttonpushed(1);
}
void B2()
{
buttonpushed(2);
}
void B3()
{
buttonpushed(3);
}
void B4()
{
buttonpushed(4);
}
void B5()
{
buttonpushed(5);
}
void B6()
{
buttonpushed(6);
}
void B7()
{
buttonpushed(7);
}
void B8()
{
buttonpushed(8);
}
void B9()
{
buttonpushed(9);
}
void B10()
{
buttonpushed(10);
}
void B11()
{
buttonpushed(11);
}
void B12()
{
buttonpushed(12);
}
void B13()
{
buttonpushed(13);
}
void B14()
{
buttonpushed(14);
}
void B15()
{
buttonpushed(15);
}
void B16()
{
buttonpushed(16);
}
void B17()
{
buttonpushed(17);
}
void B18()
{
buttonpushed(18);
}
void B19()
{
buttonpushed(19);
}
void B20()
{
buttonpushed(20);
}
void B21()
{
buttonpushed(21);
}
void B22()
{
buttonpushed(22);
}
void B23()
{
buttonpushed(23);
}
void B24()
{
buttonpushed(24);
}
void B25()
{
buttonpushed(25);
}
void B26()
{
buttonpushed(26);
}
void B27()
{
buttonpushed(27);
}
void B28()
{
buttonpushed(28);
}
void B29()
{
buttonpushed(29);
}
void B30()
{
buttonpushed(30);
}
void B31()
{
buttonpushed(31);
}
void B32()
{
buttonpushed(32);
}
void B33()
{
buttonpushed(33);
}
void B34()
{
buttonpushed(34);
}
void B35()
{
buttonpushed(35);
}
void B36()
{
buttonpushed(36);
}
void B37()
{
buttonpushed(37);
}
void B38()
{
buttonpushed(38);
}
void B39()
{
buttonpushed(39);
}
void B40()
{
buttonpushed(40);
}
void B41()
{
buttonpushed(41);
}
void B42()
{
buttonpushed(42);
}
void B43()
{
buttonpushed(43);
}
void B44()
{
buttonpushed(44);
}
void B45()
{
buttonpushed(45);
}
void B46()
{
buttonpushed(46);
}
void B47()
{
buttonpushed(47);
}
void B48()
{
buttonpushed(48);
}
void B49()
{
buttonpushed(49);
}
void B50()
{
buttonpushed(50);
}
void B51()
{
buttonpushed(51);
}
void B52()
{
buttonpushed(52);
}
void B53()
{
buttonpushed(53);
}
void B54()
{
buttonpushed(54);
}
void B55()
{
buttonpushed(55);
}



}
