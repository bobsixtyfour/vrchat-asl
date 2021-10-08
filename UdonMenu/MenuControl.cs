using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using System;
using TMPro;
//using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDK3.Video.Components.Base;


#if !COMPILER_UDONSHARP && UNITY_EDITOR
using System.Linq; //for sorting
using System.Collections.Generic; //for lists if I ever use em.
using UnityEditor;
using UdonSharpEditor;
#endif

namespace Bob64
{


public class MenuControl : UdonSharpBehaviour
{
    /*
    // AllLessons[][][][0] = word
    // AllLessons[][][][1] = word variant #
    // AllLessons[][][][2] = mocap credits. 
    // AllLessons[][][][3] = video URL.
    // AllLessons[][][][4] = VR index icon? (Y). Blank defaults to both vr icon.
    // AllLessons[][][][5] = Sign description string
    // AllLessons[][][][6] = sign validation status 1 (red), 2 (yellow), 3 (green)
    // AllLessons[][][][7] = sign validation credits
    // AllLessons[][][][8] = sign validation comments
    */

    //if you get the bug where it doesn't recognize new array fields, make private, save/compile, make public again.
    [System.NonSerialized]
        string[][][][] AllLessons =
new string[][][][]{ //all languages
new string[][][]{//asl lessons
new string[][]{//Test
new string[]{"Example Beginner Conversation","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ExampleBeginnerConversation.mp4","","","2","",""},
new string[]{"How to Sign Example","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowtoSignExample.mp4","","","2","",""},
new string[]{"Your Avatar Cute Thanks","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/YourAvatarCuteThanks.mp4","","","2","",""},
},


new string[][]{//Alphabet
new string[]{"Spell / Fingerspell","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpellFingerspell-Index.mp4","Y","","2","",""},

new string[]{"A","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/A.mp4","","","2","",""},
new string[]{"B","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/B-Index.mp4","Y","","2","",""},
new string[]{"B","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/B.mp4","","","2","",""},
new string[]{"C","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/C.mp4","","","2","",""},
new string[]{"D","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/D.mp4","","","2","",""},
new string[]{"E","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/E.mp4","","","2","",""},
new string[]{"F","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/F-Index.mp4","Y","","2","",""},
new string[]{"F","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/F.mp4","","","2","",""},
new string[]{"G","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/G.mp4","","","2","",""},
new string[]{"H","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/H.mp4","","","2","",""},
new string[]{"I","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I-Index.mp4","Y","","2","",""},
new string[]{"I","1","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I-v1.mp4","","","2","",""},
new string[]{"I","2","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I-v2.mp4","","","2","",""},
new string[]{"J","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/J-Index.mp4","Y","","2","",""},
new string[]{"J","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/J.mp4","","","2","",""},
new string[]{"K","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/K-Index.mp4","Y","","2","",""},
new string[]{"K","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/K.mp4","","","2","",""},
new string[]{"L","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/L.mp4","","","2","",""},
new string[]{"M","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/M.mp4","","","2","",""},
new string[]{"N","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/N.mp4","","","2","",""},
new string[]{"O","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/O.mp4","","","2","",""},
new string[]{"P","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/P-Index.mp4","Y","","2","",""},
new string[]{"P","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/P.mp4","","","2","",""},
new string[]{"Q","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Q.mp4","","","2","",""},
new string[]{"R","1","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R-v1.mp4","","","2","",""},
new string[]{"R","2","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R-v2.mp4","","","2","",""},
new string[]{"S","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/S.mp4","","","2","",""},
new string[]{"T","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/T.mp4","","","2","",""},
new string[]{"U","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/U.mp4","","","2","",""},
new string[]{"V","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/V-Index.mp4","Y","","2","",""},
new string[]{"W","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W-Index.mp4","Y","","2","",""},
new string[]{"W","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W.mp4","","","2","",""},
new string[]{"X","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X-Index.mp4","Y","","2","",""},
new string[]{"X","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X.mp4","","","2","",""},
new string[]{"Y","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y-Index.mp4","Y","","2","",""},
new string[]{"Y","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y.mp4","","","2","",""},
new string[]{"Z","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Z.mp4","","","2","",""},
},
new string[][]{//Numbers
new string[]{"Number","1","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Number-v1.mp4","","","2","",""},
new string[]{"Number","2","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Number-v2.mp4","","","2","",""},
new string[]{"0","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/0.mp4","","","2","",""},
new string[]{"1","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1.mp4","","","2","",""},
new string[]{"2","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/2.mp4","","","2","",""},
new string[]{"3","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/3-Index.mp4","Y","","2","",""},
new string[]{"4","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4-Index.mp4","Y","","2","",""},
new string[]{"5","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/5.mp4","","","2","",""},
new string[]{"6","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/6-Index.mp4","Y","","2","",""},
new string[]{"7","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/7-Index.mp4","Y","","2","",""},
new string[]{"8","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/8-Index.mp4","Y","","2","",""},
new string[]{"9","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/9-Index.mp4","Y","","2","",""},
new string[]{"10","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/10.mp4","","","2","",""},
new string[]{"11","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/11.mp4","","","2","",""},
new string[]{"12","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/12.mp4","","","2","",""},
new string[]{"13","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/13-Index.mp4","Y","","2","",""},
new string[]{"14","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/14-Index.mp4","Y","","2","",""},
new string[]{"15","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/15.mp4","","","2","",""},
new string[]{"16","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/16-Index.mp4","Y","","2","",""},
new string[]{"17","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/17-Index.mp4","Y","","2","",""},
new string[]{"18","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/18-Index.mp4","Y","","2","",""},
new string[]{"19","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/19-Index.mp4","Y","","2","",""},
new string[]{"20","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/20.mp4","","","2","",""},
new string[]{"21","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/21.mp4","","","2","",""},
new string[]{"22","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/22.mp4","","","2","",""},
new string[]{"23","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/23-Index.mp4","Y","","2","",""},
new string[]{"24","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/24-Index.mp4","Y","","2","",""},
new string[]{"25","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/25.mp4","","","2","",""},
new string[]{"26","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/26-Index.mp4","Y","","2","",""},
new string[]{"27","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/27-Index.mp4","Y","","2","",""},
new string[]{"28","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/28-Index.mp4","Y","","2","",""},
new string[]{"29","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/29-Index.mp4","Y","","2","",""},
new string[]{"30","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/30-Index.mp4","Y","","2","",""},
new string[]{"100","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/100.mp4","","","2","",""},
new string[]{"1000","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1000.mp4","","","2","",""},
new string[]{"1337","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1337-Index.mp4","Y","","2","",""},
new string[]{"1000000","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1000000.mp4","","","2","",""},
},
new string[][]{//Daily Use
new string[]{"Meaning","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meaning.mp4","","","2","",""},
new string[]{"(What Does That) Mean?","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/(WhatDoesThat)Mean.mp4","","","2","",""},

new string[]{"Away","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Away.mp4","","","2","",""},
new string[]{"Hello","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hello.mp4","","","2","",""},
new string[]{"How (are) You","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How(are)You.mp4","","","2","",""},
new string[]{"What's Up?","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WhatsUp.mp4","","","2","",""},

new string[]{"Nice (to) Meet You","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice(to)MeetYou-v1.mp4","","","2","",""},
new string[]{"Nice (to) Meet You","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice(to)MeetYou-v2.mp4","","","2","",""},
new string[]{"Good","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Good.mp4","","","2","",""},

new string[]{"Yes","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yes.mp4","","","2","",""},
new string[]{"No","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/No.mp4","","","2","",""},
new string[]{"So-So","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/So-So.mp4","","","2","",""},
new string[]{"Sick","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sick.mp4","","","2","",""},

new string[]{"Hurt","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hurt.mp4","","","2","",""},
new string[]{"Welcome","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Welcome.mp4","","","2","",""},

new string[]{"Good Morning","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodMorning.mp4","","","2","",""},
new string[]{"Good Afternoon","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodAfternoon-v1.mp4","","","2","",""},
new string[]{"Good Afternoon","2","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodAfternoon-v2.mp4","","","2","",""},

new string[]{"Good Night","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodNight.mp4","","","2","",""},
new string[]{"See You Later","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SeeYouLater.mp4","","","2","",""},
new string[]{"Please","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Please.mp4","","","2","",""},
new string[]{"Sorry","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sorry.mp4","","","2","",""},
new string[]{"Forget","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forget.mp4","","","2","",""},

new string[]{"Go (to) Portal","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Go(to)Portal.mp4","","","2","",""},
new string[]{"Change World","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ChangeWorld.mp4","","","2","",""},
new string[]{"Thank You","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ThankYou.mp4","","","2","",""},
new string[]{"I Love You","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ILoveYou.mp4","","","2","",""},
new string[]{"ILY (I Love You)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ILY(ILoveYou).mp4","","","2","",""},
new string[]{"Go Away","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoAway.mp4","","","2","",""},
new string[]{"Going To","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoingTo.mp4","","","2","",""},
new string[]{"Follow","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Follow.mp4","","","2","",""},
new string[]{"Come","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Come.mp4","","","2","",""},
new string[]{"Hearing (Person)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hearing(Person).mp4","","","2","",""},
new string[]{"Deaf","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deaf.mp4","","","2","",""},

new string[]{"Hard of Hearing","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HardofHearing.mp4","","","2","",""},
new string[]{"Mute","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mute.mp4","","","2","",""},


},
new string[][]{ //Pointing use Question / Answer
new string[]{"I (Me)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I(Me).mp4","","","2","",""},
new string[]{"Him/Her/He/She/It/You/They","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HimHerHeSheItYouThey.mp4","","","2","",""},
new string[]{"Him (Gender Emphasis)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Him(GenderEmphasis).mp4","","","2","",""},
new string[]{"Her (Gender Emphasis)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Her(GenderEmphasis).mp4","","","2","",""},
new string[]{"My","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/My.mp4","","","2","",""},
new string[]{"His/Hers/Its/Your/Their","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HisHersItsYourTheir.mp4","","","2","",""},
new string[]{"We","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/We-v1.mp4","","","2","",""},
new string[]{"We","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/We-v2.mp4","","","2","",""},
new string[]{"We","3","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/We-v3.mp4","","","2","",""},


new string[]{"Our","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Our.mp4","","","2","",""},
new string[]{"Over There","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/OverThere.mp4","","","2","",""},
new string[]{"It's","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Its.mp4","","","2","",""},
new string[]{"Inside","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Inside.mp4","","","2","",""},
new string[]{"Outside","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Outside.mp4","","","2","",""},
new string[]{"Outside (Outdoors)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Outside(Outdoors).mp4","","","2","",""},
new string[]{"Hidden","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hidden.mp4","","","2","",""},
new string[]{"Behind","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behind.mp4","","","2","",""},
new string[]{"Above","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Above.mp4","","","2","",""},
new string[]{"Below","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Below.mp4","","","2","",""},
new string[]{"Here","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Here.mp4","","","2","",""},

new string[]{"Back","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back-v1.mp4","","","2","",""},
new string[]{"Back","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back-v2.mp4","","","2","",""},
new string[]{"Front","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Front.mp4","","","2","",""},
new string[]{"Who","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Who-Index.mp4","Y","","2","",""},
new string[]{"What","1","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What-v1.mp4","","","2","",""},
new string[]{"What","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What-v2.mp4","","","2","",""},
new string[]{"When","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/When.mp4","","","2","",""},
new string[]{"Where","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Where.mp4","","","2","",""},
new string[]{"Why","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Why-Index.mp4","Y","","2","",""},
new string[]{"How","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How-v1.mp4","","","2","",""},
new string[]{"How","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How-v2.mp4","","","2","",""},
new string[]{"How","3","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How-v3.mp4","","","2","",""},
new string[]{"How Many","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany-v1.mp4","","","2","",""},
new string[]{"How Many","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany-v2.mp4","","","2","",""},
new string[]{"How Many","3","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany-v3.mp4","","","2","",""},
new string[]{"How Long","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowLong.mp4","","","2","",""},
new string[]{"Which","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Which.mp4","","","2","",""},
new string[]{"Can","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Can.mp4","","","2","",""},
new string[]{"Can't","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cant.mp4","","","2","",""},

new string[]{"Have","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Have.mp4","","","2","",""},
new string[]{"Get","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Get.mp4","","","2","",""},
new string[]{"Will / Future","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WillFuture-v1.mp4","","","2","",""},

new string[]{"Need / Should","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NeedShould.mp4","","","2","",""},
new string[]{"Must","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Must.mp4","","","2","",""},
new string[]{"Not","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Not.mp4","","","2","",""},
new string[]{"Or","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Or-v1.mp4","","","2","",""},
new string[]{"Or","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Or-v2.mp4","","","2","",""},
new string[]{"And","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/And.mp4","","","2","",""},
new string[]{"For","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/For.mp4","","","2","",""},
},
new string[][]{ //Common
new string[]{"Accept","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Accept.mp4","","","2","",""},
new string[]{"Again / Repeat","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AgainRepeat.mp4","","","2","",""},
new string[]{"Alright","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Alright.mp4","","","2","",""},
new string[]{"Be Right Back (BRB)","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BeRightBack(BRB).mp4","","","2","",""},
new string[]{"Browsing (the) Internet","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Browsing(the)Internet-Index.mp4","Y","","2","",""},
new string[]{"Denial","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Denial.mp4","","","2","",""},
new string[]{"Design","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Design.mp4","","","2","",""},
new string[]{"Don't Know","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DontKnow.mp4","","","2","",""},
new string[]{"Draw (Art)","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Draw(Art)-Index.mp4","Y","","2","",""},
new string[]{"Draw / Tie / Even (Score)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DrawTieEven(Score).mp4","","Draw or Tie, as in the same score at the end of a game or a stalemate.","2","",""},
new string[]{"Drink","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drink.mp4","","","2","",""},
new string[]{"Eat","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Eat.mp4","","","2","",""},
new string[]{"Fast","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fast.mp4","","","2","",""},
new string[]{"Favorite","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Favorite-Index.mp4","Y","","2","",""},
new string[]{"Friend","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friend-Index.mp4","Y","","2","",""},
new string[]{"Funny","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Funny-Index.mp4","Y","","2","",""},
new string[]{"Jokes","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jokes-Index.mp4","Y","","2","",""},
new string[]{"Know","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Know.mp4","","","2","",""},
new string[]{"Language","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Language.mp4","","","2","",""},
new string[]{"Learn","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Learn-v1.mp4","","","2","",""},
new string[]{"Learn","2","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Learn-v2.mp4","","","2","",""},
new string[]{"Live","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Live-v1.mp4","","","2","",""},
new string[]{"Live","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Live-v2.mp4","","","2","",""},
new string[]{"Make","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Make.mp4","","","2","",""},
new string[]{"Movie","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Movie-v1.mp4","","","2","",""},
new string[]{"Movie","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Movie-v2.mp4","","","2","",""},
new string[]{"Name","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Name.mp4","","","2","",""},
new string[]{"New","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/New.mp4","","","2","",""},
new string[]{"Old","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Old.mp4","","","2","",""},
new string[]{"People","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/People-Index.mp4","Y","","2","",""},
new string[]{"Person","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Person-Index.mp4","Y","","2","",""},
new string[]{"Play","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Play-Index.mp4","Y","","2","",""},
new string[]{"Play Game","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/PlayGame-Index.mp4","Y","","2","",""},
new string[]{"Read","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Read.mp4","","","2","",""},
new string[]{"Rude","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rude-Index.mp4","Y","","2","",""},
new string[]{"Same","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Same-Index.mp4","Y","","2","",""},
new string[]{"Sign","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sign.mp4","","","2","",""},
new string[]{"Slow","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Slow.mp4","","","2","",""},
new string[]{"Stop","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stop.mp4","","","2","",""},
new string[]{"Student","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Student.mp4","","","2","",""},
new string[]{"Teach","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teach.mp4","","","2","",""},
new string[]{"Teacher","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teacher.mp4","","","2","",""},
new string[]{"Understand","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Understand.mp4","","","2","",""},
new string[]{"Very","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Very.mp4","","","2","",""},
new string[]{"Watch (Look)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look).mp4","","","2","",""},
new string[]{"Work","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Work.mp4","","","2","",""},
new string[]{"Write","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Write-v1.mp4","","","2","",""},
new string[]{"Write","2","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Write-v2.mp4","","","3","",""},
},
new string[][]{//People
new string[]{"Acquaintance","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Acquaintance.mp4","","","2","",""},
new string[]{"Adult","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Adult.mp4","","","2","",""},

new string[]{"Anyone","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Anyone.mp4","","","2","",""},
new string[]{"Aunt","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Aunt.mp4","","","2","",""},
new string[]{"Baby","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Baby.mp4","","","2","",""},
new string[]{"Birthday","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Birthday.mp4","","","2","",""},
new string[]{"Born","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Born-v1.mp4","","","2","",""},
new string[]{"Boy","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Boy.mp4","","","2","",""},
new string[]{"Brother","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brother.mp4","","","2","",""},
new string[]{"Brother-in-law","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brother-in-law.mp4","","","2","",""},
new string[]{"Celebrate","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Celebrate.mp4","","","2","",""},
new string[]{"Child","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Child-v1.mp4","","","2","",""},
new string[]{"Child","2","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Child-v2.mp4","","","2","",""},
new string[]{"Children","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Children.mp4","","","2","",""},
new string[]{"Dead","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dead.mp4","","","2","",""},
new string[]{"Divorce","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Divorce.mp4","","","2","",""},
new string[]{"Enemy","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enemy.mp4","","","2","",""},
new string[]{"Everyone","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everyone.mp4","","","2","",""},
new string[]{"Family","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Family.mp4","","","2","",""},
new string[]{"Father","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Father-v1.mp4","","","2","",""},
new string[]{"Father","2","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Father-v2.mp4","","","2","",""},
new string[]{"Girl","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Girl.mp4","","","2","",""},
new string[]{"Grandma","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grandma.mp4","","","2","",""},
new string[]{"Grandpa","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grandpa.mp4","","","2","",""},
new string[]{"Interpreter","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interpreter.mp4","","","2","",""},
new string[]{"Kid","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kid.mp4","","","2","",""},
new string[]{"Marriage","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Marriage.mp4","","","2","",""},
new string[]{"Mother","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mother-v1.mp4","","","2","",""},
new string[]{"No One","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne-v1.mp4","","","2","",""},
new string[]{"No One","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne-v2.mp4","","","2","",""},
new string[]{"No One","3","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne-v3.mp4","","","2","",""},

new string[]{"Parents","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Parents.mp4","","","2","",""},
new string[]{"Single","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Single.mp4","","","2","",""},
new string[]{"Sister","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sister.mp4","","","2","",""},
new string[]{"Sister-in-law","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sister-in-law.mp4","","","2","",""},
new string[]{"Someone","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Someone-v1.mp4","","","2","",""},
new string[]{"Someone","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Someone-v2.mp4","","","2","",""},
new string[]{"Stranger","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stranger.mp4","","","2","",""},
new string[]{"Teen","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teen-v1.mp4","","","2","",""},
new string[]{"Uncle","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Uncle.mp4","","","2","",""},
new string[]{"Young","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Young.mp4","","","2","",""},


},
new string[][]{//Feelings / Reactions
new string[]{"Alive","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Alive.mp4","","","3","",""},
new string[]{"Angry","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Angry.mp4","","","3","","Rename to Mad?"},
new string[]{"Attention","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attention.mp4","","","3","",""},

new string[]{"Bored","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bored.mp4","","","3","",""},
new string[]{"Care / Precious","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CarePrecious.mp4","","This sign has two different meanings","3","",""},
new string[]{"Careful","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Careful-Index.mp4","Y","","3","",""},
new string[]{"Confused","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Confused.mp4","","","3","",""},
new string[]{"Cry","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cry.mp4","","","3","",""},
new string[]{"Curious","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Curious.mp4","","","3","",""},
new string[]{"Cute","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cute.mp4","","","3","",""},
new string[]{"Disgusted","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disgusted.mp4","","","3","",""},

new string[]{"Embarrassed","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Embarrassed.mp4","","","3","",""},
new string[]{"Enjoy / Appreciate ","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/EnjoyAppreciate.mp4","","","3","",""},
new string[]{"Envy","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Envy-Index.mp4","Y","Looks similar to the sign 'Drool', however the palm is pointed outwards with 'Envy', and towards the mouth/chin with 'Drool'.","3","",""},
new string[]{"Excited","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excited-Index.mp4","Y","","3","",""},
new string[]{"Fall In Love","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FallInLove.mp4","","","3","",""},
new string[]{"Feel","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Feel.mp4","","","3","",""},

new string[]{"Focus","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Focus.mp4","","","3","",""},
new string[]{"Friendly","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friendly.mp4","","","3","",""},
new string[]{"Great","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Great.mp4","","","3","",""},
new string[]{"Happy","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Happy.mp4","","","3","",""},
new string[]{"Hate","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-Index-v1.mp4","Y","","3","",""},
new string[]{"Hate","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v2.mp4","","","3","",""},
new string[]{"Hate","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v3.mp4","","","3","",""},

new string[]{"In-Love","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/In-Love.mp4","","","3","",""},
new string[]{"Jealous","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jealous-Index.mp4","Y","","2","",""},
new string[]{"Laughing","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Laughing.mp4","","","3","",""},
new string[]{"Like","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Like-Index.mp4","Y","","3","",""},
new string[]{"LOL","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LOL.mp4","","","3","",""},
new string[]{"Lonely","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lonely.mp4","","","2","",""},
new string[]{"Mean (Cruel)","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mean(Cruel).mp4","","","3","",""},
new string[]{"Nevermind","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nevermind.mp4","","","3","",""},
new string[]{"Nice","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice.mp4","","","3","",""},
new string[]{"Pity","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pity.mp4","","","3","",""},
new string[]{"Sad","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sad.mp4","","","3","",""},
new string[]{"Scared","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Scared.mp4","","","3","",""},

new string[]{"Shy","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shy.mp4","","","3","",""},
new string[]{"Sleep","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleep.mp4","","","3","",""},
new string[]{"Sleepy","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleepy.mp4","","","3","",""},

new string[]{"Stressed","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stressed.mp4","","","3","",""},
new string[]{"Struggle","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Struggle.mp4","","","3","","Repeats 3 times?"},

new string[]{"Surprised","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Surprised.mp4","","","3","",""},
new string[]{"Tired","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tired.mp4","","","3","",""},
},
new string[][]{ //Value

new string[]{"All","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v1.mp4","","","2","",""},
new string[]{"All","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v2.mp4","","","2","",""},
new string[]{"Always","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Always.mp4","","","2","",""},




new string[]{"Empty","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Empty-v1.mp4","","","2","",""},

new string[]{"Ever","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ever.mp4","","","2","",""},

new string[]{"Everytime","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everytime.mp4","","","2","",""},



new string[]{"Full","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Full.mp4","","","2","",""},
new string[]{"Half","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Half.mp4","","","2","",""},

new string[]{"Hard","","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hard.mp4","","","2","",""},
new string[]{"Heavy","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Heavy.mp4","","","2","",""},

new string[]{"Large / Big","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LargeBig.mp4","","","2","",""},


new string[]{"Lightweight","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lightweight.mp4","","","2","",""},
new string[]{"Limited","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Limited.mp4","","","2","",""},
new string[]{"Long","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Long.mp4","","","2","",""},


new string[]{"More","2","DarkEternal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/More-v2.mp4","","","2","",""},
new string[]{"Much / A Lot","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/MuchALot.mp4","","","2","",""},


new string[]{"Often","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Often.mp4","","","2","",""},
new string[]{"Quarter","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quarter.mp4","","","2","",""},

new string[]{"Short (Time)","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Short(Time).mp4","","","2","",""},


new string[]{"Sometimes","1","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sometimes-v1.mp4","","","2","",""},
new string[]{"Sometimes","2","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sometimes-v2.mp4","","","2","",""},



new string[]{"Unlimited","","Melwil","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Unlimited.mp4","","","2","",""},


},
new string[][]{ //Time
new string[]{"Time","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Time.mp4","","","3","",""},
new string[]{"Year","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Year-v1.mp4","","","3","",""},
new string[]{"Year","2","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Year-v2.mp4","","","2","",""},
new string[]{"Season","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Season.mp4","","","3","",""},
new string[]{"Month","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Month.mp4","","","3","",""},
new string[]{"Week","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Week.mp4","","","3","",""},
new string[]{"Day","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Day.mp4","","","3","",""},
new string[]{"Weekend","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Weekend-v1.mp4","","","3","",""},

new string[]{"Hour","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hour.mp4","","","3","",""},
new string[]{"Minute","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Minute.mp4","","","3","",""},
new string[]{"Second (Time)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Second(Time).mp4","","","3","",""},
new string[]{"Today","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-Index.mp4","Y","","2","",""},
new string[]{"Tomorrow","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tomorrow.mp4","","","3","",""},
new string[]{"Yesterday","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yesterday.mp4","","","3","",""},
new string[]{"Morning","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Morning.mp4","","","3","",""},
new string[]{"Afternoon","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Afternoon.mp4","","","3","",""},
new string[]{"Evening","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Evening.mp4","","","3","",""},
new string[]{"Night","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Night.mp4","","","3","",""},


new string[]{"All Day","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllDay-v1.mp4","","","3","",""},

new string[]{"All Night","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllNight-v1.mp4","","","3","",""},

new string[]{"Sunday","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunday.mp4","","","3","",""},
new string[]{"Monday","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Monday.mp4","","","3","",""},
new string[]{"Tuesday","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tuesday.mp4","","","3","",""},
new string[]{"Wednesday","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-Index.mp4","Y","","2","",""},
new string[]{"Thursday","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Thursday.mp4","","","3","",""},

new string[]{"Saturday","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Saturday.mp4","","","3","",""},
new string[]{"Autumn / Fall","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AutumnFall.mp4","","","3","",""},
new string[]{"Winter","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Winter.mp4","","","3","",""},
new string[]{"Spring (Season)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Spring(Season).mp4","","","3","",""},
new string[]{"Summer","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Summer.mp4","","","3","",""},
new string[]{"Now","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-Index.mp4","Y","","2","",""},
new string[]{"Never","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Never.mp4","","","3","",""},
new string[]{"Soon","","Tenri","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soon-Index.mp4","Y","","2","",""},
new string[]{"Later","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later.mp4","","","3","",""},
new string[]{"Past","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Past.mp4","","","3","",""},
new string[]{"Will / Future","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WillFuture.mp4","","","3","",""},


new string[]{"Midweek","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Midweek.mp4","","","3","",""},
new string[]{"Next Week","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NextWeek-v1.mp4","","","3","",""},
new string[]{"Next Week","2","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NextWeek-v2.mp4","","","3","",""},
new string[]{"Break (Rest)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Break(Rest).mp4","","","3","",""},
},
new string[][]{//Lesson 9 (VRChat)
new string[]{"Gestures","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Gestures.mp4","","","3","",""},
new string[]{"World","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/World.mp4","","","3","",""},

new string[]{"Discord","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Discord.mp4","","","3","",""},
new string[]{"Streaming","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Streaming.mp4","","","3","",""},
new string[]{"VR Headset","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/VRHeadset.mp4","","","3","",""},
new string[]{"Desktop Computer","","Darketernal","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DesktopComputer.mp4","","","2","",""},

new string[]{"Computer","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Computer.mp4","","","3","",""},

new string[]{"Public","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Public.mp4","","","3","",""},


new string[]{"Add Friend","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AddFriend.mp4","","","3","",""},

new string[]{"Recharge","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Recharge.mp4","","","3","",""},
new string[]{"Visit","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Visit.mp4","","","3","",""},
new string[]{"Request","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Request.mp4","","","3","",""},
new string[]{"Login","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Login.mp4","","","3","",""},
new string[]{"Logout","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Logout.mp4","","","3","",""},
new string[]{"Schedule","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Schedule.mp4","","","3","",""},



new string[]{"Cancel","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cancel.mp4","","","3","",""},
new string[]{"Portal","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Portal.mp4","","","3","",""},
new string[]{"Camera","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Camera.mp4","","","3","",""},
new string[]{"Avatar","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Avatar.mp4","","","3","",""},
new string[]{"Photo","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Photo.mp4","","","3","",""},
new string[]{"Join","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Join.mp4","","","3","",""},
new string[]{"Leave","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Leave.mp4","","","3","",""},
new string[]{"Climbing","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Climbing.mp4","","","3","",""},
new string[]{"Falling","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Falling.mp4","","","3","",""},
new string[]{"Walk","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Walk.mp4","","","3","",""},
new string[]{"Hide","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hide.mp4","","","3","",""},
new string[]{"Block","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Block.mp4","","","3","",""},
new string[]{"Crash","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Crash.mp4","","","3","",""},
new string[]{"Lagging","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lagging.mp4","","","3","",""},
new string[]{"Restart","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Restart.mp4","","","3","",""},
new string[]{"Send","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Send.mp4","","","3","",""},
new string[]{"Receive","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Receive.mp4","","","3","",""},


},
new string[][]{//Lesson 10 (Verbs & Actions p1)
new string[]{"Overlook","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Overlook.mp4","","","3","",""},
new string[]{"Punish","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Punish.mp4","","","3","",""},
new string[]{"Edit","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Edit.mp4","","","3","",""},
new string[]{"Erase","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Erase.mp4","","","3","",""},
new string[]{"Proposal","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Proposal.mp4","","","3","",""},
new string[]{"Add","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Add.mp4","","","3","",""},
new string[]{"Increase","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Increase.mp4","","","3","",""},
new string[]{"Remove","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remove.mp4","","","3","",""},
new string[]{"Agree","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Agree.mp4","","","3","",""},
new string[]{"Disagree","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disagree.mp4","","","3","",""},
new string[]{"Admit","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Admit.mp4","","","3","",""},
new string[]{"Allow","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Allow.mp4","","","3","",""},
new string[]{"Attack","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attack.mp4","","","3","",""},
new string[]{"Fight","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fight.mp4","","","3","",""},
new string[]{"Defend","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defend.mp4","","","3","",""},
new string[]{"Defeat (Overcome)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defeat(Overcome).mp4","","","3","",""},
new string[]{"Win","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Win.mp4","","","3","",""},
new string[]{"Lose","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lose.mp4","","","3","",""},
new string[]{"Draw (Tie)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Draw(Tie).mp4","","","3","",""},
new string[]{"Give Up","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GiveUp.mp4","","","3","",""},

new string[]{"Ask","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ask.mp4","","","3","",""},
new string[]{"Attach","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attach.mp4","","","3","",""},
new string[]{"Assistant","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Assistant.mp4","","","3","",""},
new string[]{"Assist","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Assist.mp4","","","3","",""},
new string[]{"Battle","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Battle.mp4","","","3","",""},
new string[]{"Beat (Overcome)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beat(Overcome).mp4","","","3","",""},
new string[]{"Become","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Become.mp4","","","3","",""},
new string[]{"Beg","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beg.mp4","","","3","",""},
new string[]{"Begin / Start","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BeginStart.mp4","","","3","",""},

new string[]{"Believe","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Believe.mp4","","","3","",""},
new string[]{"Blame","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blame.mp4","","","3","",""},

new string[]{"Blush","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blush.mp4","","","3","",""},
new string[]{"Bother / Harass","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BotherHarass.mp4","","","3","",""},
},
new string[][]{//Lesson 11 (Verbs & Actions p2)
new string[]{"Bend","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bend.mp4","","","3","",""},
new string[]{"Bow","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bow.mp4","","","3","",""},
new string[]{"Break (Damage)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Break(Damage).mp4","","","3","",""},
new string[]{"Breathe","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Breathe.mp4","","","3","",""},
new string[]{"Bring","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bring.mp4","","","3","",""},
new string[]{"Build / Construct","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BuildConstruct-v1.mp4","","","3","",""},
new string[]{"Build / Construct","2","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BuildConstruct-v2.mp4","","","3","",""},
new string[]{"Bully","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bully.mp4","","","3","",""},
new string[]{"Burn","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Burn.mp4","","","3","",""},
new string[]{"Buy","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Buy.mp4","","","3","",""},

new string[]{"Care","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Care.mp4","","","3","",""},
new string[]{"Carry","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Carry.mp4","","","3","",""},
new string[]{"Catch","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Catch.mp4","","","3","",""},
new string[]{"Cause","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cause.mp4","","","3","",""},
new string[]{"Challenge","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Challenge.mp4","","","3","",""},
new string[]{"Chance","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Chance.mp4","","","3","",""},

new string[]{"Check","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Check.mp4","","","3","",""},

new string[]{"Claim","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Claim.mp4","","","3","",""},
new string[]{"Clean","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Clean.mp4","","","3","",""},
new string[]{"Clear","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Clear.mp4","","","3","",""},
new string[]{"Close (Shut)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Close(Shut).mp4","","","3","",""},
new string[]{"Comfort","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Comfort.mp4","","","3","",""},
new string[]{"Command","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Command.mp4","","","3","",""},
new string[]{"Communicate","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Communicate.mp4","","","3","",""},
new string[]{"Compare","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Compare.mp4","","","3","",""},
new string[]{"Complain","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Complain.mp4","","","3","",""},
new string[]{"Compliment","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Compliment.mp4","","","3","",""},
new string[]{"Concentrate","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Concentrate.mp4","","","3","",""},

new string[]{"Cook","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cook.mp4","","","3","",""},


new string[]{"Correct (Fix)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Correct(Fix).mp4","","Correct as in 'I'm gonna correct that issue.'","3","",""},
},
new string[][]{//Verbs & Actions p3
new string[]{"Cough","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cough.mp4","","","3","",""},

new string[]{"Create / Make","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CreateMake.mp4","","","3","",""},
new string[]{"Cuddle","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cuddle.mp4","","","3","",""},
new string[]{"Cut","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cut.mp4","","","3","",""},
new string[]{"Dab","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dab.mp4","","","3","",""},
new string[]{"Dance","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dance.mp4","","","3","",""},

new string[]{"Date","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Date.mp4","","","3","",""},
new string[]{"Deal","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deal.mp4","","","3","",""},
new string[]{"Deliver","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deliver.mp4","","","3","",""},
new string[]{"Depend","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Depend.mp4","","","3","",""},


new string[]{"Disappear","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disappear.mp4","","","3","",""},
new string[]{"Disappoint","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disappoint.mp4","","","3","",""},
new string[]{"Disapprove","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disapprove.mp4","","","3","",""},
new string[]{"Discuss","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Discuss.mp4","","","3","",""},
new string[]{"Disguise","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disguise.mp4","","","3","",""},
new string[]{"Disgust","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disgust.mp4","","","3","",""},
new string[]{"Dismiss","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dismiss.mp4","","","3","",""},


new string[]{"Dream","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dream.mp4","","","3","",""},
new string[]{"Dress (Verb)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dress(Verb).mp4","","","3","",""},
new string[]{"Drop","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drop.mp4","","","3","",""},
new string[]{"Drown","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drown.mp4","","","3","",""},
new string[]{"Drunk","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drunk.mp4","","","3","",""},
new string[]{"Dry","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dry.mp4","","","3","",""},
new string[]{"Dump","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dump.mp4","","","3","",""},

new string[]{"Earn","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Earn.mp4","","","3","",""},
new string[]{"Effect","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Effect.mp4","","","3","",""},
new string[]{"End","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/End.mp4","","","3","",""},
new string[]{"Escape","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Escape.mp4","","","3","",""},
new string[]{"Escort","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Escort.mp4","","","3","",""},
},
new string[][]{//Verbs & Actions p4
new string[]{"Excuse (Verb)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excuse(Verb).mp4","","","3","",""},

new string[]{"Expose","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Expose.mp4","","","3","",""},
new string[]{"Fail","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fail.mp4","","","3","",""},
new string[]{"Faint","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Faint.mp4","","","3","",""},
new string[]{"Fake","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fake.mp4","","","3","",""},
new string[]{"Fart","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fart.mp4","","","3","",""},
new string[]{"Fear","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fear.mp4","","","3","",""},
new string[]{"Fill","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fill.mp4","","","3","",""},

new string[]{"Finish","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Finish.mp4","","","3","",""},
new string[]{"Fix","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fix.mp4","","","3","",""},



new string[]{"Forbid","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forbid.mp4","","","3","",""},
new string[]{"Forgive","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forgive.mp4","","","3","",""},



new string[]{"Grab","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grab.mp4","","","3","",""},
new string[]{"Grow","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grow.mp4","","","3","",""},
new string[]{"Guard","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guard.mp4","","","3","",""},
new string[]{"Guess","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guess.mp4","","","3","",""},
new string[]{"Guide","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guide.mp4","","","3","",""},
new string[]{"Harass / Bother","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HarassBother.mp4","","","3","",""},
new string[]{"Harm","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Harm.mp4","","","3","",""},
new string[]{"Hit","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hit.mp4","","","3","",""},
new string[]{"Hold","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hold.mp4","","","3","",""},
new string[]{"Hop","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hop.mp4","","","3","",""},
new string[]{"Hope","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hope.mp4","","","3","",""},
new string[]{"Hunt","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hunt.mp4","","","3","",""},
new string[]{"Ignore","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ignore.mp4","","","3","",""},

new string[]{"Imitate","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imitate.mp4","","","3","",""},
new string[]{"Insult","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Insult.mp4","","","3","",""},
},
new string[][]{//Verbs & Actions p5
new string[]{"Interact","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interact.mp4","","","3","",""},
new string[]{"Interfere","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interfere.mp4","","","3","",""},

new string[]{"Jump","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jump.mp4","","","3","",""},




new string[]{"Kill","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kill.mp4","","","3","",""},
new string[]{"Knock","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Knock.mp4","","","3","",""},
new string[]{"Lead","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lead.mp4","","","3","",""},
new string[]{"Lick","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lick.mp4","","","3","",""},
new string[]{"Lock","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lock.mp4","","","3","",""},

new string[]{"Melt","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Melt.mp4","","","3","",""},
new string[]{"Mess","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mess.mp4","","","3","",""},
new string[]{"Miss (Didn't Get It)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Miss(DidntGetIt).mp4","","","3","",""},

new string[]{"Mount","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mount.mp4","","","3","",""},
new string[]{"Move","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Move.mp4","","","3","",""},

new string[]{"Nod","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nod.mp4","","","3","",""},
new string[]{"Note","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Note.mp4","","","3","",""},
new string[]{"Notice","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Notice.mp4","","","3","",""},
new string[]{"Obey","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obey.mp4","","","3","",""},

new string[]{"Obtain","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obtain.mp4","","","3","",""},
new string[]{"Occupy","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Occupy.mp4","","","3","",""},
new string[]{"Offend","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offend.mp4","","","3","",""},
new string[]{"Offer","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offer.mp4","","","3","",""},
new string[]{"Okay (Approve)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Okay(Approve).mp4","","","3","",""},
new string[]{"Open","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Open.mp4","","","3","",""},
new string[]{"Order","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Order.mp4","","","3","",""},
new string[]{"Owe","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Owe.mp4","","","3","",""},
new string[]{"Own","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Own.mp4","","","3","",""},
new string[]{"Pass","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pass.mp4","","","3","",""},
},
new string[][]{//Verbs & Actions p6
new string[]{"Party","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Party.mp4","","","3","",""},
new string[]{"Pat","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pat.mp4","","","3","",""},
new string[]{"Pet","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pet.mp4","","","3","",""},

new string[]{"Plug","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Plug.mp4","","","3","",""},
new string[]{"Point","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Point.mp4","","","3","",""},
new string[]{"Poke","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Poke.mp4","","","3","",""},
new string[]{"Pray","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pray.mp4","","","3","",""},
new string[]{"Prepare","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prepare.mp4","","","3","",""},
new string[]{"Present (Lecture)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Present(Lecture).mp4","","","3","",""},
new string[]{"Pretend","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pretend.mp4","","","3","",""},
new string[]{"Protect","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Protect.mp4","","","3","",""},
new string[]{"Prove","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prove.mp4","","","3","",""},
new string[]{"Publish","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Publish.mp4","","","3","",""},
new string[]{"Puke","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Puke.mp4","","","3","",""},
new string[]{"Pull","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pull.mp4","","","3","",""},
new string[]{"Punch","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Punch.mp4","","","3","",""},
new string[]{"Push","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Push.mp4","","","3","",""},
new string[]{"Put","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Put.mp4","","","3","",""},
new string[]{"Question","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Question.mp4","","","3","",""},
new string[]{"Questions","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Questions.mp4","","","3","",""},
new string[]{"Quit","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quit.mp4","","","3","",""},
new string[]{"Quote","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quote.mp4","","","3","",""},

new string[]{"React","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/React.mp4","","","3","",""},
new string[]{"Recommended","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Recommended.mp4","","","3","",""},
new string[]{"Refuse","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Refuse.mp4","","","3","",""},
new string[]{"Regret","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Regret.mp4","","","3","",""},
new string[]{"Remember","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remember.mp4","","","3","",""},

new string[]{"Report","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Report.mp4","","","3","",""},
new string[]{"Reset","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Reset.mp4","","","3","",""},
new string[]{"Ride","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ride.mp4","","","3","",""},
new string[]{"Rub","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rub.mp4","","","3","",""},
new string[]{"Rule (Rules)","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rule(Rules).mp4","","","3","",""},
new string[]{"Run","","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Run.mp4","","","3","",""},
new string[]{"Save","1","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Save-v1.mp4","","","3","",""},
new string[]{"Save","2","ShadeAxas","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Save-v2.mp4","","","3","",""},
},
new string[][]{//Verbs & Actions p7





































new string[]{"Worry","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Worry-v1.mp4","","","3","",""},
new string[]{"Worry","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Worry-v2.mp4","","","3","",""},
new string[]{"Wristwatch","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wristwatch-v1.mp4","","","3","",""},
new string[]{"Wristwatch","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wristwatch-v2.mp4","","","3","",""},
},
new string[][]{//Verbs & Actions p8
new string[]{"Bath / Bathe / Bathing","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v1.mp4","","","3","",""},
new string[]{"Bath / Bathe / Bathing","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v2.mp4","","","3","",""},
new string[]{"Calculate","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculate-v1.mp4","","","3","",""},
new string[]{"Calculate","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculate-v2.mp4","","","3","",""},
new string[]{"Calculate","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculate-v3.mp4","","","3","",""},
new string[]{"Drive","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drive.mp4","","","3","",""},
new string[]{"Fiction","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fiction.mp4","","","3","",""},
new string[]{"Help / Assist","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v1.mp4","","","3","",""},
new string[]{"Help / Assist","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v2.mp4","","","3","",""},
new string[]{"Help / Assist","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v3.mp4","","","3","",""},
new string[]{"Help / Assist","4","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v4.mp4","","","3","",""},
new string[]{"Help / Assist","5","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v5.mp4","","","3","",""},
new string[]{"Help / Assist","6","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v6.mp4","","","3","",""},
new string[]{"Help / Assist","7","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HelpAssist-v7.mp4","","","3","",""},
new string[]{"Hug","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hug-v1.mp4","","","3","",""},
new string[]{"Hug","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hug-v2.mp4","","","3","",""},
new string[]{"Kiss","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v1.mp4","","","3","",""},
new string[]{"Kiss","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v2.mp4","","","3","",""},
new string[]{"Kiss","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v3.mp4","","","3","",""},
new string[]{"Lie","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lie.mp4","","","3","",""},
new string[]{"Serve","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Serve.mp4","","","3","",""},
new string[]{"Shower","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shower.mp4","","","3","",""},
new string[]{"Socialize","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Socialize.mp4","","","3","",""},
new string[]{"Support","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Support.mp4","","","3","",""},
new string[]{"Take Care","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare-v1.mp4","","","3","",""},
new string[]{"Take Care","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare-v2.mp4","","","3","",""},
new string[]{"Take Care","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare-v3.mp4","","","3","",""},
new string[]{"Take Care","4","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare-v4.mp4","","","3","",""},
new string[]{"Touch","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Touch-v1.mp4","","","3","",""},
new string[]{"Touch","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Touch-v2.mp4","","","3","",""},
new string[]{"Travel","","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Travel.mp4","","","","",""},
new string[]{"Trip","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v1.mp4","","","3","",""},
new string[]{"Trip","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v2.mp4","","","3","",""},
new string[]{"Trip","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v3.mp4","","","3","",""},
new string[]{"Trip","4","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v4.mp4","","","3","",""},
new string[]{"Trip","5","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v5.mp4","","","3","",""},
new string[]{"True","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/True-v1.mp4","","","3","",""},
new string[]{"True","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/True-v2.mp4","","","3","",""},
new string[]{"Trust","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trust-v1.mp4","","","3","",""},
new string[]{"Trust","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trust-v2.mp4","","","3","",""},
new string[]{"Turn","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turn-v1.mp4","","","3","",""},
new string[]{"Turn","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turn-v2.mp4","","","3","",""},
new string[]{"Type","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Type.mp4","","","3","",""},
new string[]{"Upset","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Upset.mp4","","","3","",""},
new string[]{"Use","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Use.mp4","","","3","",""},
new string[]{"View","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/View-v1.mp4","","","3","",""},
new string[]{"View","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/View-v2.mp4","","","3","",""},
new string[]{"Vomit","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Vomit.mp4","","","3","",""},
new string[]{"Wait","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wait.mp4","","","3","",""},
new string[]{"Wake Up","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WakeUp.mp4","","","3","",""},
new string[]{"War","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/War-v1.mp4","","","3","",""},
new string[]{"War","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/War-v2.mp4","","","3","",""},
new string[]{"Warn","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Warn-v1.mp4","","","3","",""},
new string[]{"Warn","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Warn-v2.mp4","","","3","",""},
new string[]{"Wash","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v1.mp4","","","3","",""},
new string[]{"Wash","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v2.mp4","","","3","",""},
new string[]{"Wash","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v3.mp4","","","3","",""},
new string[]{"Wash","4","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v4.mp4","","","3","",""},
new string[]{"Waste","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Waste-v1.mp4","","","3","",""},
new string[]{"Waste","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Waste-v2.mp4","","","3","",""},
new string[]{"Watch (Look)","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v1.mp4","","","3","",""},
new string[]{"Watch (Look)","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v2.mp4","","","3","",""},
new string[]{"Watch (Look)","3","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v3.mp4","","","3","",""},
new string[]{"Wear","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear-v1.mp4","","","3","",""},
new string[]{"Wear","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear-v2.mp4","","","3","",""},
new string[]{"Wear (Clothes)","1","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear(Clothes)-v1.mp4","","","3","",""},
new string[]{"Wear (Clothes)","2","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear(Clothes)-v2.mp4","","","3","",""},
new string[]{"Wobble","","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wobble.mp4","","","","",""},
new string[]{"Wonder","","DmTheMechanic","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wonder.mp4","","","3","",""},





},
},
new string[][][]{//LSF
new string[][]{//Daily Use
new string[]{"Bonjour","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Bonjour.mp4","","","3","",""},
new string[]{"Ça Va / Comment Tu Vas","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/ÇaVaCommentTuVas.mp4","","","3","",""},
new string[]{"Tu Fais Quoi?","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/TuFaisQuoi.mp4","","","3","",""},
new string[]{"Ravi De Te Rencontrer","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/RaviDeTeRencontrer.mp4","","","3","",""},
new string[]{"Bon","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Bon.mp4","","","3","",""},
new string[]{"Mauvais","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Mauvais.mp4","","","3","",""},
new string[]{"Oui","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Oui.mp4","","","3","",""},
new string[]{"Non","1","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Non-v1.mp4","","","3","",""},
new string[]{"Non","2","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Non-v2.mp4","","","3","",""},
new string[]{"Moyen","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Moyen.mp4","","","3","",""},
new string[]{"Malade","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Malade.mp4","","","3","",""},
new string[]{"Mal","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Mal.mp4","","","3","",""},
new string[]{"De Rien","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/DeRien.mp4","","","3","",""},
new string[]{"Au Revoir","1","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/AuRevoir-v1.mp4","","","3","",""},
new string[]{"Au Revoir","2","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/AuRevoir-v2.mp4","","","3","",""},
new string[]{"Bon Après-Midi","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/BonAprès-Midi.mp4","","","3","",""},
new string[]{"Bonsoir","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Bonsoir.mp4","","","3","",""},
new string[]{"Bonne Nuit","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/BonneNuit.mp4","","","3","",""},
new string[]{"À Plus Tard","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/ÀPlusTard.mp4","","","3","",""},
new string[]{"S'il Vous Plaît","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/SilVousPlaît.mp4","","","3","",""},
new string[]{"Désolé","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Désolé.mp4","","","3","",""},
new string[]{"Oublier","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Oublier.mp4","","","3","",""},
new string[]{"Dormir","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Dormir.mp4","","","3","",""},
new string[]{"Lit","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Lit.mp4","","","3","",""},
new string[]{"Sauter / Changer De Monde","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/SauterChangerDeMonde.mp4","","","3","",""},
new string[]{"Merci","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Merci.mp4","","","3","",""},
new string[]{"Je T'aime","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/JeTaime.mp4","","","3","",""},
new string[]{"Va T'en","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/VaTen.mp4","","","3","",""},


new string[]{"Venir","1","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Venir-v1.mp4","","","3","",""},
new string[]{"Venir","2","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Venir-v2.mp4","","","3","",""},

new string[]{"Sourd","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Sourd.mp4","","","3","",""},
new string[]{"Malentendant","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Malentendant.mp4","","","3","",""},
new string[]{"Muet","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Muet.mp4","","","3","",""},

new string[]{"Ne Peut Pas Lire","","Hppedeaf","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/NePeutPasLire.mp4","","","3","",""},
},//end of lesson
},//end of lang
};//end of array




        //GameObject [][][][] videos;
        [System.NonSerialized]
    public string[][] lessonnames = { //can be unique per language, as long as they match the number of array
		new string[] { //ASL lesson names - can be unique per language.
            "Shadermotion Test",
            "Alphabet (Fingerspelling)",
            "Numbers",
            "Daily Use",
            "Pointing Use / Question / Answer",
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
            "Talk / Asking exercises (PSE)",
            "Name sign users",
            "Countries",
            "Colors",
            "Materials",
            "Medical",
        },
        new string[] {
            "Usage quotidien"
        },

    };
    [System.NonSerialized]
    public string[][] signlanguagenames = {
        new string[] {
            "ASL",
            "American Sign Language"
        },
        new string[] {
            "LSF",
            "Langue des Signes Française"
        },
		//new string[]{"DGS","Deutsche Gebärdensprache (German Sign Language)"}
	};

    //Avatar Objects/Variables
    Toggle handtoggle;
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

    // Video Player Objects/Variables
    //GameObject videocontainer;
    private VideoPlayerControl videoplayer;
    //GameObject videoplayer;
    //VRCUnityVideoPlayer vrcplayercomponent;
    //TextMeshProUGUI videostatus;
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
    Slider videospeedslider;
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
        GlobalToggle = GameObject.Find("/Preferencesv2/Canvas/Mode Panel/Global Mode").GetComponent<Toggle>();
        QuizToggle = GameObject.Find("/Preferencesv2/Canvas/Mode Panel/Quiz Mode").GetComponent<Toggle>();
        HandToggle = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Hand Toggle").GetComponent<Toggle>();
        avatarscaleslider = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Avatar Scale Slider").GetComponent<Slider>();
        //videospeedslider = GameObject.Find("/Preferencesv2/Canvas/Left Panel/Playback Speed Slider").GetComponent<Slider>();
        DarkToggle = GameObject.Find("/Preferencesv2/Canvas/Right Panel/Dark Mode").GetComponent<Toggle>();
    }

    /***************************************************************************************************************************
	Initialize Variables related to the MoCap Avatar (Nana)
	***************************************************************************************************************************/
    private void _InitializeSigningAvatar()
    {

        signingavatars = GameObject.Find("/Signing Avatars");
        //var nanamats = signingavatars.transform.Find("Nana Avatar (SM)").GetComponent<MeshRenderer>().materials;
        
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
            videoplayer = GameObject.Find("/Video Container/Video").GetComponent<VideoPlayerControl>();
            //videoplayer._SetStatusText("If the video doesn't update, wait like 5 seconds, and then push reload. ->");
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
                TakeOwnership();
                _GlobalModeVarSync();
        }

    }
    /***************************************************************************************************************************
    When updates to variables are recieved, check if globalmode is enabled
    ***************************************************************************************************************************/
    public override void OnDeserialization()
    {

        _GlobalModeVarSync();
        _UpdateAllDisplays();

        //_DebugMenuVariables();
    }

    /***************************************************************************************************************************
	Sync Global Vars
	***************************************************************************************************************************/
    private void _GlobalModeVarSync()
    {
        if (globalmode)//only do anythign if globalmode is on.
        {
            if (Networking.IsOwner(gameObject))//only request serialization if owner of object.
            {
                globalcurrentlang = currentlang;
                globalcurrentlesson = currentlesson;
                globalcurrentword = currentword;
                RequestSerialization();

            }
            else
            {//not the owner, so update board vars from global vars
                currentlang = globalcurrentlang;
                currentlesson = globalcurrentlesson;
                currentword = globalcurrentword;
            }
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
        menuheadertext.text = signlanguagenames[currentlang][0] + " - Lesson #" + (currentlesson + 1) + " " + lessonnames[currentlang][currentlesson];

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
                string variant="";
                if (AllLessons[currentlang][currentlesson][i][1] != "")
                {
                    variant = " (Variant " + AllLessons[currentlang][currentlesson][i][1]+")";
                }
                buttonText = "    " + (i + 1) + ") " + AllLessons[currentlang][currentlesson][i][0]+variant;
                isButtonSelected = currentword == i; //if the currentword is i, then assign true to isbuttonselected

                _DisplayButton(i, buttonText, isButtonSelected, true, AllLessons[currentlang][currentlesson][i][6]);
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
        
        switch (AllLessons[currentlang][currentlesson][index][4])
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
                Debug.Log("_DisplayVRIcon(" + index + ") had an invalid VR Icon setting; update AllLessons[currentlang][currentlesson][index][4]");
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
    private void _DisplayButton(int index, string text, bool isSelected, bool isColored, string colorcode)
    {

        // Handle Validation Highlighting
        if (isColored)
        {
            switch (colorcode)
            { 
                
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
            string variant = "";
            if (AllLessons[currentlang][currentlesson][currentword][1] != "")
            {
                variant = " (Variant " + AllLessons[currentlang][currentlesson][currentword][1]+")";
            }

            // Update MoCap Avatar Visuals (Nana)
            currentsigntext.text = (currentlesson + 1) + "-" + (currentword + 1) + ") " + AllLessons[currentlang][currentlesson][currentword][0] + variant;
            speechbubbletext.text = AllLessons[currentlang][currentlesson][currentword][0];
            
            signcredittext.text = "The motion data for this sign was signed by: " + AllLessons[currentlang][currentlesson][currentword][2];
            descriptiontext.text = AllLessons[currentlang][currentlesson][currentword][5];
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
            if (AllLessons[currentlang][currentlesson][currentword][3] != "")
            { // if url is blank, then don't look for the video
                if (langurls.Length > 0)
                { //don't crash the script if i forget to build langurls lol...
                        videoplayer._LoadURL(langurls[currentlang][currentlesson][currentword]);
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
        if (globalmode)
        {
            TakeOwnership();
            _GlobalModeVarSync();
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
                        AllLessons[lang][lesson][word][6] == "3" && //and if the sign is validated
                        AllLessons[lang][lesson][word][3] != "") // and if the video url exists
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
                            AllLessons[lang][lesson][word][6] == "3" && //and if the sign is validated
                            AllLessons[lang][lesson][word][3] != "") // and if the video url exists
                            {//if the lesson is selected
                             //add all words to the array if verified
                                quizwordmapping[x] = new int[4];
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

                if (AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][3] != "")
                { // if url is blank, then don't look for the video
                    if (langurls.Length > 0)
                    { //don't crash the script if i forget to build langurls lol...
                            videoplayer._LoadURL(langurls[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]]);
                    }
                }
            

        }

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
        Text debugtextbox = GameObject.Find("/Debug/Panel/Text").GetComponent<Text>();
        debugtextbox.text="Current Variable contents: " +
			"\nOwner: " + Networking.IsOwner(gameObject) + 
			//"\ncurrentmode: " + currentmode + " globalcurrentmode: " + globalcurrentmode +
			"\ncurrentlang: " + currentlang + " globalcurrentlang: " + globalcurrentlang + 
			"\ncurrentlesson: " + currentlesson + " globalcurrentlesson: " + globalcurrentlesson + 
			"\ncurrentword: " + currentword + " globalcurrentword: " + globalcurrentword;
            */
		
    
				
    }






    /***************************************************************************************************************************
	Called to scale signing avatar gameobject
	***************************************************************************************************************************/
    public void AvatarScaleSliderValueChanged()
    {
        if (HandToggle.isOn)
        {
            signingavatars.transform.localScale = Vector3.Scale(new Vector3(1, 1, 1), new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value));
        }
        else
        {
            signingavatars.transform.localScale = Vector3.Scale(new Vector3(-1, 1, 1), new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value));
        }

    }


    /***************************************************************************************************************************
	Called to switch the signing avatar's mirror animation parameter and set the toggle box state.
	***************************************************************************************************************************/
    public void ToggleHand()
    {
        Debug.Log("entered toggle hand");
        if (HandToggle.isOn)
        {
            Debug.Log("true");
            signingavatars.transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(1, 1, 1));
            Debug.Log("signingavatars.transform.localScale" + signingavatars.transform.localScale);
        }
        else
        {
            Debug.Log("false");
            signingavatars.transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(-1, 1, 1));
            Debug.Log("signingavatars.transform.localScale" + signingavatars.transform.localScale);
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
        //nana.Play("Idle");
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
                            wordurls[z] = new VRCUrl(inspectorBehaviour.AllLessons[x][y][z][3]);
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
                            if (inspectorBehaviour.AllLessons[0][x][y][8] != "")
                            {
                                erratatext = erratatext + "\nL" + (x + 1) + "-" + (y + 1) + " [" + inspectorBehaviour.AllLessons[0][x][y][0] + "]: " + inspectorBehaviour.AllLessons[0][x][y][8]+"\n";
                            }

                        }
                    }

                }

                listofallwords = listofallwords.OrderBy(l => l[0]).ToList();
                string dictionarytext = "";
                foreach (var word in listofallwords)
                {
                    dictionarytext = dictionarytext + word[0] + " " + word[1] + "\n";
                    
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
}