#if VRC_SDK_VRCSDK3 && UDON
//using VRC.SDK3.Components.Video;
using System;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDK3.Video.Components.Base;
using VRC.SDKBase;
using VRC.Udon;


#if !COMPILER_UDONSHARP && UNITY_EDITOR
using System.Collections.Generic; //for lists if I ever use em.
using System.Linq; //for sorting
using UdonSharpEditor;
using UnityEditor;
using VRC.SDKBase.Editor.BuildPipeline;
#endif

namespace Bob64
{


public class MenuControl : UdonSharpBehaviour
{
        private bool locked = false;
        private bool debug = false;
        //array accessor consts for easier upkeeping due to the array potentially getting new fields later.
        private const int arrayword = 0;
        private const int arrayvariant = 1;
        private const int arraycredit = 3;
        private const int arrayurl = 2; //not sure why anything would be using this because it should be pointed to the vrcurl array
        //private const int arrayshadermotion = 4;
        private const int arrayvricon = 4;
        private const int arraysigndescription = 5;
        private const int arrayvalidation = 6;
        private const int arrayvalidationcredit = 7;
        private const int arrayvalidationcomment = 8;
        private const int arraynumofavatars = 9;
        /*
        // AllLessons[][][][0] = word
        // AllLessons[][][][1] = word variant #
        // AllLessons[][][][3] = mocap credits.
        // AllLessons[][][][2] = video URL.
        // AllLessons[][][][4] = Shadermotion (Y)
        // AllLessons[][][][5] = VR index icon? (Y). Blank defaults to both vr icon.
        // AllLessons[][][][6] = Sign description string
        // AllLessons[][][][7] = sign validation status 1 (red), 2 (yellow), 3 (green)
        // AllLessons[][][][8] = sign validation credits
        // AllLessons[][][][9] = sign validation comments
        */

        //if you get the bug where it doesn't recognize new array fields, make private, save/compile, make public again.
        [System.NonSerialized]
        string[][][][] AllLessons =
new string[][][][]{ //all languages
new string[][][]{//asl lessons
new string[][]{//Test
new string[]{"Example Beginner Conversation","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ExampleBeginnerConversation.mp4","Tenri","I","","2","","","1"},
new string[]{"How to Sign Example","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowtoSignExample.mp4","Tenri","I","","2","","","1"},
new string[]{"Your Avatar Cute Thanks","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/YourAvatarCuteThanks.mp4","Tenri","I","","2","","","1"},
new string[]{"BSL Test","","https://bob64.vrsignlanguage.net/ShaderMotion/2021-10-24%2021-05-52.mp4","Sheezy93","","","2","","",""},
new string[]{"MorningTest.mp4","","https://bob64.vrsignlanguage.net/ShaderMotion/MorningTest.mp4","Catsgirl_nya","I","","2","","",""},
new string[]{"2 avatar test","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/2avatartest.mp4","Tenri","","","2","","","2"},
new string[]{"4 avatar test","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4avatartest.mp4","Tenri","","","2","","","4"},
},


new string[][]{//Alphabet
new string[]{"Spell / Fingerspell","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpellFingerspell-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Spell / Fingerspell","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpellFingerspell-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"A","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/A.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"B","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/B-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"B","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/B-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"C","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/C.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"D","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/D.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"E","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/E.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"F","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/F-v1.mp4","Tenri","I","Same handshape as 'F'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"F","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/F-v2.mp4","Tenri","B","Same handshape as 'F'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"G","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/G.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"H","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/H.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"I","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"I","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"I","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I-v3.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"J","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/J-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"J","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/J-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"K","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/K-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"K","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/K-v2.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"L","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/L.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"M","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/M.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"N","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/N.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"O","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/O.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"P","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/P-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"P","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/P-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Q","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Q.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"R","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R-v1.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"R","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R-v2.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"S","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/S.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"T","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/T.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"U","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/U.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"V","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/V.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"W","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W-v1.mp4","Tenri","I","Same handshape as '6'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"W","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W-v2.mp4","Tenri","G","Same handshape as '6'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"X","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"X","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Y","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Y","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Z","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Z.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
},
new string[][]{//Numbers
new string[]{"Number","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Number.mp4","DmTheMechanic","B","Flat O handshape, if signed with 'C' handshapes, it can be mistaken as 'City'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"0","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/0.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"1","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"2","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/2.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"3","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/3-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"3","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/3-v2.mp4","ShadeAxas","G","","1","","","1"},
new string[]{"4","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"4","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"5","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/5.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"6","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/6-v1.mp4","Tenri","I","Same handshape as 'W'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"6","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/6-v2.mp4","ShadeAxas","G","Same handshape as 'W'","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"7","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/7-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"7","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/7-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"8","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/8-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"8","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/8-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"9","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/9-v1.mp4","Tenri","I","Same handshape as 'F'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"9","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/9-v2.mp4","ShadeAxas","G","Same handshape as 'F'","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"10","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/10.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"11","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/11.mp4","Tenri","B","Keep inside fingerspelling space, placing it near head could be misunderstood as 'Understand'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"12","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/12.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"13","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/13-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"13","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/13-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"14","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/14.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"15","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/15.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"16","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/16-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"16","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/16-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"17","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/17-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"17","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/17-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"18","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/18-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"18","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/18-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"19","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/19-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"19","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/19-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"20","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/20.mp4","Tenri","B","Don't sign near your mouth or it means 'Bird'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"21","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/21.mp4","Tenri","B","Not to be confused with 'Gun'","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"22","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/22.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"23","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/23-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"23","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/23-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"24","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/24-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"24","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/24-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"25","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/25.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"26","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/26-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"26","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/26-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"27","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/27-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"27","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/27-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"28","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/28-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"28","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/28-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"29","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/29-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"29","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/29-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"30","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/30-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"30","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/30-v2.mp4","ShadeAxas","G","","1","","Peace Sign and index version needed","1"},
new string[]{"100","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/100.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"1000","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1000.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"1337","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1337.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"1000000","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1000000.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
},
new string[][]{//Daily Use
new string[]{"Meaning","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meaning.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"(What Does That) Mean?","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/(WhatDoesThat)Mean.mp4","Tenri","B","Meaning with body language to change it into a question","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hello","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hello.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Goodbye / Bye","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodbyeBye.mp4","Nemsi","B","","2","","","1"},
new string[]{"How (are) You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How(are)You.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"What's Up?","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WhatsUp.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Nice (to) Meet You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice(to)MeetYou.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Nice (to) Meet (You)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice(to)Meet(You).mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Good","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Good.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Bad","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bad-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Bad","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bad-v2.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Yes","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yes.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"No","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/No.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"So-So","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/So-So.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sick","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sick-v1.mp4","Tenri","I","","1","","","1"},

new string[]{"Hurt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hurt.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Welcome","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Welcome.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},

new string[]{"Good Morning","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodMorning.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Good Afternoon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodAfternoon.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Good Evening","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodEvening.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"Good Night","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodNight.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"See (You) Later","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/See(You)Later.mp4","Tenri","B","","3","","","1"},
new string[]{"Please","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Please.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sorry","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sorry.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Forget","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forget.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Bed","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bed.mp4","Tenri","B","","3","","","1"},
new string[]{"Go (to) Portal / (VRC) World","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Go(to)Portal(VRC)World.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"Change (VRC) World","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Change(VRC)World-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Thank You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ThankYou.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"I Love You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ILoveYou.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Love It","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LoveIt.mp4","Tenri","B","Also known as 'Kiss Fist'. Used when you love something. eg: Coffee, love it.","1","","Looks too much like a punch lol","1"},
new string[]{"ILY (I Love You)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ILY(ILoveYou).mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Go Away","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoAway-v1.mp4","Melwil","B","","3","","","1"},
new string[]{"Go Away","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoAway-v2.mp4","Nemsi","B","","3","","","1"},
new string[]{"Go","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Go.mp4","Melwil","B","","3","","","1"},
new string[]{"Follow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Follow.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Come","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Come.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hearing (Person)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hearing(Person).mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Blind","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blind.mp4","DmTheMechanic","I","In real life the fingers are spread","1","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Deaf","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deaf.mp4","Melwil","B","Can be done in either order","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hard of Hearing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HardofHearing.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},




},
new string[][]{ //Pointing use Question / Answer
new string[]{"I (Me)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I(Me).mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/You.mp4","Melwil","B","This is specifically the person you're talking to.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Him/Her/He/She/It/They","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HimHerHeSheItThey.mp4","Tenri","B","Point at the person you're referring to","2","","","2"},
new string[]{"My","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/My.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Your","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Your.mp4","Melwil","B","","2","","","1"},
new string[]{"It's","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Its.mp4","Melwil","I","This sign is considered Signed Exact English.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"His/Hers/Its/Their","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HisHersItsTheir.mp4","Tenri","B","","2","","","2"},
new string[]{"We","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/We.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"They/Them (Plural)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TheyThem(Plural).mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Their (Plural Possessive)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Their(PluralPossessive)-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Their (Plural Possessive)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Their(PluralPossessive)-v2.mp4","DmTheMechanic","B","","1","","Sign off to the side instead of foward","1"},
new string[]{"Our","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Our.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"There","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/There.mp4","DarkEternal","B","This sign is considered Signed Exact English. Depending on how far, you can emphasise the arc to convey how far it is.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"In","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/In.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Out","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Out.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Outside (Outdoors)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Outside(Outdoors)-v1.mp4","Tenri","B","","1","","","1"},
new string[]{"Outside (Outdoors)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Outside(Outdoors)-v2.mp4","Nemsi","B","","1","","","1"},

new string[]{"Behind","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behind.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Above","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Above.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"Below","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Below.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Left (Direction)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Left(Direction).mp4","Melwil","B","","3","","",""},
new string[]{"Right (Direction)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Right(Direction).mp4","Melwil","B","","3","","",""},
new string[]{"Here","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Here.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Beside","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beside.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"Back (To Return)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back(ToReturn)-v1.mp4","Melwil","I","Lexical/Loan Sign (where it fingerspelling becomes its own sign)","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Back (To Return)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back(ToReturn)-v2.mp4","ShadeAxas","G","Lexical/Loan Sign (where it fingerspelling becomes its own sign)","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Back (Of Something)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back(OfSomething).mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Front","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Front.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Who","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Who.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"What","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What-v1.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"What","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What-v2.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"When","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/When.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Where","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Where.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Why","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Why-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"How","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How-v1.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"How","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How-v2.mp4","Nemsi","B","","3","","","1"},
new string[]{"How Many","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany-v1.mp4","DmTheMechanic","B","","1","","","1"},
new string[]{"How Many","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"How Many","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany-v3.mp4","Nemsi","B","","2","","","1"},
new string[]{"How Long","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowLong.mp4","Tenri","B","","3","","","1"},
new string[]{"Which","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Which.mp4","Tenri","B","Similar to the sign 'bath', the difference is 'which' is signed further away from the body","3","","","1"},
new string[]{"Can","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Can.mp4","Tenri","B","","3","","","1"},
new string[]{"Possibly","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Possibly.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"Can't","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cant.mp4","Nemsi","B","","2","","","1"},

new string[]{"Have","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Have.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Get / Recieve","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GetRecieve.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Need","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Need.mp4","Melwil","I","","1","","","1"},
new string[]{"Should","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Should.mp4","Nemsi","I","","2","","",""},
new string[]{"Must","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Must-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Must","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Must-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Not","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Not.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Or","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Or-v1.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"And","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/And.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"For","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/For.mp4","DmTheMechanic","B","","3","","","1"},
new string[]{"For What","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ForWhat.mp4","DmTheMechanic","B","","3","","","1"},
},
new string[][]{ //Common
new string[]{"Accept","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Accept.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Again / Repeat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AgainRepeat.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"All Right","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllRight.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Be Right Back (BRB)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BeRightBack(BRB).mp4","Tenri","B","","2","","","1"},
new string[]{"Internet","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Internet.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Browsing (the) Internet","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Browsing(the)Internet-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Browsing (the) Internet","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Browsing(the)Internet-v2.mp4","Nemsi","I","","2","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Denial","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Denial.mp4","Melwil","B","Denial as refuse to admit to something. Dening access is a different sign.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Design","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Design.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Don't Know","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DontKnow.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Art (Draw)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Art(Draw)-v1.mp4","DarkEternal","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Art (Draw)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Art(Draw)-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Draw / Tie / Even / Equal / Fair","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DrawTieEvenEqualFair.mp4","Melwil","B","Draw or Tie, as in the same score at the end of a game or a equal score.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Drink","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drink.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Eat / Food","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/EatFood.mp4","Melwil","B","The difference between 'Eat' and 'Food' is mouthing 'E' and 'F' in real life.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Fast","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fast.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Favorite / Prefer","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FavoritePrefer-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Favorite / Prefer","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FavoritePrefer-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Friend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friend.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Funny","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Funny-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Funny","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Funny-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Game","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Game.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Joke / Joking","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/JokeJoking-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Joke / Joking","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/JokeJoking-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Know","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Know.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Language","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Language.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Learn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Learn.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Live","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Live-v1.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Live","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Live-v2.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Make (Create)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Make(Create)-v1.mp4","Tenri","B","","2","","","1"},
new string[]{"Make (Create)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Make(Create)-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Movie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Movie.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Name","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Name-v1.mp4","Tenri","B","","2","","","1"},
new string[]{"Name","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Name-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"New","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/New.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Old","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Old.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"People","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/People-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"People","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/People-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Person","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Person-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Person","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Person-v2.mp4","Nemsi","I","","2","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Play","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Play-v1.mp4","Melwil","I","This is the verb 'Play', not the noun.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Play","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Play-v2.mp4","ShadeAxas","G","This is the verb 'Play', not the noun.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Read","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Read.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Rude","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rude-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Rude","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rude-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Same","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Same-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Same","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Same-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sentence","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sentence.mp4","DmTheMechanic","B","Sentence as in group of words.","2","","","1"},
new string[]{"Sign / Sign Language","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SignSignLanguage.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Slow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Slow.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","If possible, re-record so it moves along the arm better","1"},
new string[]{"Stop","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stop.mp4","Tenri","B","","2","","","1"},
new string[]{"Student","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Student.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Teach","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teach.mp4","Tenri","B","","2","","","1"},
new string[]{"Teacher","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teacher.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Understand","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Understand.mp4","Melwil","B","","3","CODAPop, DmTheMechanic","","1"},
new string[]{"Very","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Very.mp4","Melwil","B","","3","CODAPop, DmTheMechanic","","1"},
new string[]{"Word","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Word.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Work","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Work.mp4","Melwil","B","","3","CODAPop, DmTheMechanic","","1"},
new string[]{"Write","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Write-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Write","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Write-v2.mp4","ShadeAxas","B","","2","","","1"},
},
new string[][]{//People
new string[]{"Adult","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Adult-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Adult","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Adult-v2.mp4","Nemsi","B","","2","","","1"},

new string[]{"Anyone","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Anyone.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Aunt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Aunt.mp4","Nemsi","B","","2","","","1"},
new string[]{"Baby","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Baby.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Birthday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Birthday-v1.mp4","Melwil","I","This is the more common variant of this word.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Birthday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Birthday-v2.mp4","ShadeAxas","G","This is the more common variant of this word.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Born","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Born.mp4","Nemsi","B","","2","","","1"},
new string[]{"Boy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Boy.mp4","Nemsi","B","","2","","Do the motion twice at least, not once.","1"},
new string[]{"Brother","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brother.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Brother-in-law","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brother-in-law.mp4","Nemsi","B","","2","","Law portion needs to have the L hand tap twice","1"},
new string[]{"Celebrate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Celebrate.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Child","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Child.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Children","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Children.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Dead","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dead.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Divorce","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Divorce.mp4","Nemsi","B","","2","","","1"},
new string[]{"Enemy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enemy-v1.mp4","Melwil","B","","2","","","1"},
new string[]{"Enemy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enemy-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Enemy","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enemy-v3.mp4","Nemsi","B","","2","","","1"},
new string[]{"Enemy","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enemy-v4.mp4","Nemsi","B","","2","","","1"},
new string[]{"Everyone","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everyone.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Family","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Family-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Family","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Family-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Father","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Father.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Girl","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Girl.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Grandma","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grandma.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Grandpa","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grandpa.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Interpreter","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interpreter-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Interpreter","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interpreter-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Kid","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kid.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Marriage","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Marriage.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Mother","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mother.mp4","Nemsi","B","","2","","","1"},
new string[]{"No One","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Parents","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Parents.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Single","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Single.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sister","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sister.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sister-in-law","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sister-in-law.mp4","CODApop","B","","2","","","1"},
new string[]{"Someone","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Someone.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Stranger","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stranger.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Teen","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teen.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Uncle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Uncle.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Young","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Young.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
},
new string[][]{//Feelings / Reactions
new string[]{"Alive","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Alive.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Angry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Angry-v1.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","Rename to mad?","1"},
new string[]{"Angry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Angry-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Attention","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attention-v1.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Attention","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attention-v2.mp4","Nemsi","B","","2","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Bored","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bored.mp4","DmTheMechanic","B","So bored, your picking your nose","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Care / Precious","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CarePrecious.mp4","DmTheMechanic","B","This sign has two different meanings","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Careful","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Careful-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Careful","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Careful-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Confused","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Confused-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Confused","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Confused-v2.mp4","Nemsi","I","","2","","","1"},
new string[]{"Cry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cry-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Cry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cry-v2.mp4","Nemsi","B","","2","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Cry","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cry-v3.mp4","Nemsi","B","","2","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Curious","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Curious-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Curious","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Curious-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Cute","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cute.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Disgusted / Disgusting","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DisgustedDisgusting.mp4","Tenri","B","Also means Gross/Nauseous","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Dislike","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dislike.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Embarrassed","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Embarrassed.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Enjoy / Appreciate ","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/EnjoyAppreciate.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Envy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Envy-v1.mp4","DmTheMechanic","I","Looks similar to the sign 'Drool', however the palm is pointed outwards with 'Envy', and towards the mouth/chin with 'Drool'.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Envy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Envy-v2.mp4","ShadeAxas","G","Looks similar to the sign 'Drool', however the palm is pointed outwards with 'Envy', and towards the mouth/chin with 'Drool'.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Excited","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excited-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Excited","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excited-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Fall In Love","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FallInLove-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Fall In Love","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FallInLove-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Feel","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Feel-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Feel","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Feel-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Fine","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fine.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Focus","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Focus.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Friendly","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friendly-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Friendly","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friendly-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Great","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Great.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Happy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Happy.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hate","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hate","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v2.mp4","DmTheMechanic","G","Don't mistake this sign for 'Puke'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hate","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v3.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hungry","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hungry.mp4","DmTheMechanic","B","Same sign for 'Wish'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Wish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wish.mp4","ShadeAxas","B","Same sign for 'Hungry'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Jealous","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jealous.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Laughing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Laughing.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Like","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Like-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Like","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Like-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"LOL","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LOL.mp4","DmTheMechanic","B","VRChat Home Sign. IRL you would fingerspell it.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Lonely","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lonely.mp4","DarkEternal","B","","1","","Looks too weird","1"},
new string[]{"Mean (Unkind)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mean(Unkind)-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Mean (Unkind)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mean(Unkind)-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Nevermind","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nevermind-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Nevermind","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nevermind-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Nevermind","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nevermind-v3.mp4","Nemsi","B","","2","","","1"},
new string[]{"Nice","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Pity","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pity-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Pity","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pity-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Precious","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Precious.mp4","DmTheMechanic","B","","2","","",""},
new string[]{"Sad","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sad.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Scared","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Scared-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Scared","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Scared-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Shame","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shame.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Shy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shy-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Shy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shy-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Sleep","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleep.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sleepy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleepy.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Smart","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smart-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Smart","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smart-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Smart","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smart-v3.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Stressed","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stressed.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Struggle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Struggle.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Surprised","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Surprised-v1.mp4","DmTheMechanic","B","Same sign for 'awake/woke'","2","","","1"},
new string[]{"Surprised","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Surprised-v2.mp4","ShadeAxas","B","Same sign for 'awake/woke'","2","","","1"},
new string[]{"Tired","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tired-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Tired","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tired-v2.mp4","Nemsi","B","","2","","","1"},
},
new string[][]{ //Value
new string[]{"Alphabetical Order","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AlphabeticalOrder-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Alphabetical Order","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AlphabeticalOrder-v2.mp4","DmTheMechanic","I","","2","","","1"},

new string[]{"All","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"All","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"All","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v3.mp4","Nemsi","B","","2","","","1"},
new string[]{"All","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v4.mp4","Nemsi","B","","2","","","1"},
new string[]{"Always","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Always.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Both","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Both-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Both","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Both-v2.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Early","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Early.mp4","Nemsi","I","","2","","","1"},
new string[]{"Empty","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Empty-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Empty","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Empty-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Ever","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ever.mp4","Melwil","B","This means: so far, since, up till now.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Everything","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everything-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Everything","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everything-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Everytime","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everytime.mp4","Melwil","B","","1","","Every looks strange, needs to go down instead of rotating","1"},


new string[]{"Free","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Free-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Free","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Free-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Enough","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enough.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Half","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Half.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hard","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hard.mp4","Nemsi","I","","2","","","1"},
new string[]{"Heavy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Heavy-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Heavy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Heavy-v2.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Large / Big","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LargeBig.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"Last","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Last-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Last","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Last-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Last","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Last-v3.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},

new string[]{"Light (Weight)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Light(Weight)-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Light (Weight)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Light(Weight)-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"Satisfied","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Satisfied.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},

new string[]{"Long","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Long.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},

new string[]{"More","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/More.mp4","DarkEternal","I","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"A Lot","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ALot-v1.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"A Lot","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ALot-v2.mp4","Nemsi","B","","2","","","1"},

new string[]{"Nothing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nothing.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"Often","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Often-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Often","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Often-v2.mp4","Melwil","B","","2","","","1"},
new string[]{"Quarter (Fraction)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quarter(Fraction).mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},



new string[]{"Short (Time)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Short(Time)-v1.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"Short (Time)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Short(Time)-v2.mp4","Nemsi","B","","2","","","1"},

new string[]{"Small","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Small.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},

new string[]{"Sometimes","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sometimes.mp4","Nemsi","B","","2","","","1"},


new string[]{"Third","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Third-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Third","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Third-v2.mp4","Nemsi","I","","2","","","1"},
new string[]{"Third","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Third-v3.mp4","ShadeAxas","G","","1","","Redo General VR version","1"},
new string[]{"Tiny","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tiny.mp4","Melwil","I","VRC Home sign. IRL you would use your thumb and index finger","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},
new string[]{"Unsatisfied","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Unsatisfied.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas, catsgirl_nya","","1"},



},
new string[][]{ //Time
new string[]{"Afternoon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Afternoon.mp4","Catsgirl_nya","B","","2","","","1"},
new string[]{"All Day","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllDay.mp4","Catsgirl_nya","B","","2","","","1"},
new string[]{"All Night","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllNight.mp4","Catsgirl_nya","B","","2","","","1"},
new string[]{"Autumn / Fall","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AutumnFall.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Break (Rest)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Break(Rest).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Day","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Day.mp4","ShadeAxas","B","Dominant hand's elbow rests on back of non-dominant hand","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},

new string[]{"Evening","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Evening.mp4","ShadeAxas","B","","1","","Elbow Avatar Issues","1"},
new string[]{"Friday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friday-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Friday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friday-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Future","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Future.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Future (Initialized)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Future(Initialized).mp4","ShadeAxas","G","","1","","Need Index version","1"},
new string[]{"Hour","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hour.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Later","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v1.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Later","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v2.mp4","DmTheMechanic","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Midweek","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Midweek.mp4","","I","","1","","Need Index version","1"},
new string[]{"Minute","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Minute.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Monday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Monday.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Month","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Month.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Morning","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Morning.mp4","Catsgirl_nya","B","","2","","","1"},
new string[]{"Never","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Never.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Next Week","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NextWeek.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Night","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Night.mp4","Catsgirl_nya","B","","2","","","1"},
new string[]{"Noon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Noon.mp4","Catsgirl_nya","I","","2","","","1"},
new string[]{"Now","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Now","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-v2.mp4","ShadeAxas","G","","1","","needs 'A' handshape general vr version","1"},
new string[]{"Past","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Past.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Saturday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Saturday.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Season","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Season.mp4","ShadeAxas","B","","1","","Rotate plane along palm","1"},
new string[]{"Second (Time)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Second(Time)-v1.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Soon","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soon-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Soon","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soon-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Spring (Season)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Spring(Season).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Summer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Summer.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Sunday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunday.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Sunrise","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunrise-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Sunrise","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunrise-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Sunset","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunset-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Sunset","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunset-v2.mp4","ShadeAxas","G","","1","","Elbow Avatar Issues","1"},
new string[]{"Thursday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Thursday-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Thursday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Thursday-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Time","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Time.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Today","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Today","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v2.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Today","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v3.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Tomorrow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tomorrow.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Tuesday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tuesday.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Wednesday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Wednesday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Week","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Week.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Weekend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Weekend.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Will","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Will.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Winter","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Winter-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Winter","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Winter-v2.mp4","ShadeAxas","B","","1","","Looks like cold","1"},
new string[]{"Year","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Year.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
new string[]{"Yesterday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yesterday.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi, catsgirl_nya","","1"},
},
new string[][]{//Lesson 9 (VRChat)
new string[]{"Add Friend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AddFriend.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Avatar","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Avatar.mp4","ShadeAxas","B","Same sign as clothes but on vrchat it means avatar as well","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Block","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Block-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Block","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Block-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Camera (Picture)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Camera(Picture)-v1.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Camera (Picture)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Camera(Picture)-v2.mp4","Nemsi","B","","2","","","1"},

new string[]{"Cancel","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cancel.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Climb","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Climb.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Computer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Computer.mp4","Nemsi","B","","2","","","1"},
new string[]{"Crash","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Crash-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Crash","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Crash-v2.mp4","Nemsi","B","VRChat home sign","2","","","1"},


new string[]{"Discord","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Discord.mp4","ShadeAxas","B","VRChat home sign","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Donate","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Donate-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Donate","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Donate-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Event","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Event-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Event","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Event-v2.mp4","Nemsi","I","","2","","","1"},
new string[]{"Event","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Event-v3.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Fall (Down)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fall(Down)-v1.mp4","Nemsi","B","","2","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Fall (Down)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fall(Down)-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Gestures","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Gestures.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","Don't remember what ray says","1"},
new string[]{"Hide","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hide.mp4","Nemsi","B","","2","","","1"},


new string[]{"Lag","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lag.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Leave","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Leave-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Leave","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Leave-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Login","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Login.mp4","ShadeAxas","B","VRChat home sign","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Logout","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Logout.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},

new string[]{"Offline","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offline-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Offline","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offline-v2.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Offline","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offline-v3.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Online","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v1.mp4","Nemsi","I","","2","","","1"},
new string[]{"Online","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v2.mp4","Tenri","I","","2","","","1"},
new string[]{"Online","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v3.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Online","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v4.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Photo / Picture","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/PhotoPicture-v1.mp4","Nemsi","B","","2","","",""},
new string[]{"Photo / Picture","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/PhotoPicture-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Portal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Portal.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Public / General","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/PublicGeneral.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Receive / Get / Obtain / Acquire","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ReceiveGetObtainAcquire.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Recharge","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Recharge.mp4","ShadeAxas","B","Also means plug in","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Record","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Record-v1.mp4","Nemsi","G","","2","","","1"},
new string[]{"Record","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Record-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Request","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Request.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Restart","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Restart.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Schedule","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Schedule.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},

new string[]{"Send","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Send-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Send","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Send-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Send","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Send-v3.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Streaming","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Streaming.mp4","ShadeAxas","B","VRChat home sign","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Visit","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Visit-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Visit","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Visit-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"VR Headset","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/VRHeadset.mp4","ShadeAxas","B","VRChat home sign","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"Walk","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Walk.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
new string[]{"VRChat World","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/VRChatWorld.mp4","ShadeAxas","G","VRChat home sign","3","CODAPop, DmTheMechanic, Shadeaxas","","1"},
},
new string[][]{//Lesson 10 (Verbs & Actions p1)
new string[]{"Add","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Add-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Add","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Add-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Add","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Add-v3.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Admit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Admit.mp4","ShadeAxas","B","Can be done two-handed","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Agree","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Agree-v1.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Agree","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Agree-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Agree","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Agree-v3.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Allow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Allow.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Argue","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Argue.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","",""},
new string[]{"Ask","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ask-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Ask","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ask-v2.mp4","Nemsi","I","","2","","","1"},
new string[]{"Assist","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Assist.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Assistant","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Assistant.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Attach","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attach.mp4","Nemsi","I","","2","","","1"},
new string[]{"Attack","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attack-v1.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Attack","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attack-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Battle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Battle.mp4","Nemsi","B","","2","","","1"},
new string[]{"Beat (Overcome)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beat(Overcome).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Become","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Become.mp4","Nemsi","B","","2","","","1"},
new string[]{"Beg","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beg-v1.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Beg","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beg-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Begin / Start","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BeginStart.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Behave","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behave-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Behave","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behave-v2.mp4","Nemsi","I","","2","","","1"},
new string[]{"Believe / Belief","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BelieveBelief.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Blame","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blame.mp4","Nemsi","B","","2","","","1"},

new string[]{"Blush","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blush-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Blush","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blush-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Bother / Harass / Distrub / Annoy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BotherHarassDistrubAnnoy.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Defeat (Overcome)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defeat(Overcome).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Defend","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defend-v1.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Defend","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defend-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Disagree","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disagree.mp4","Nemsi","B","","2","","","1"},
new string[]{"Draw / Tie (Same Score)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DrawTie(SameScore)-v1.mp4","Nemsi","I","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Draw / Tie (Same Score)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DrawTie(SameScore)-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Edit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Edit.mp4","ShadeAxas","B","","1","","Doesn't indicate finger bend","1"},
new string[]{"Erase","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Erase.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},

new string[]{"Fight","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fight-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Fight","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fight-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Give Up","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GiveUp.mp4","Nemsi","B","","2","","","1"},
new string[]{"Increase / Gain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/IncreaseGain.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Lose (Game)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lose(Game).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Lose (Object)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lose(Object).mp4","Nemsi","B","","2","","","1"},
new string[]{"Overlook","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Overlook.mp4","Nemsi","B","","2","","","1"},
new string[]{"Propose / Suggest","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ProposeSuggest.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Punish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Punish.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Remove","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remove-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Remove","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remove-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Skip","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Skip-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Skip","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Skip-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Win","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Win-v1.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
new string[]{"Win","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Win-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Catsgirl_nya, Nemsi","","1"},
},
new string[][]{//Lesson 11 (Verbs & Actions p2)
new string[]{"Break (Damage)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Break(Damage).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Breathe","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Breathe.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Bring","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bring.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Build","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Build.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Bully","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bully-v1.mp4","Nemsi","I","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Bully","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bully-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},

new string[]{"Fire","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fire-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Buy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Buy-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Buy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Buy-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Call (Phone)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Call(Phone)-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Call (Phone)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Call(Phone)-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Call (Summon)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Call(Summon).mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Cause","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cause.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Challenge","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Challenge.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","End pose could be better","1"},
new string[]{"Chance","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Chance.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Cheat","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheat-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Cheat","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheat-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Cheat","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheat-v3.mp4","Nemsi","I","","2","","","1"},
new string[]{"Check","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Check-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Check","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Check-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Choose","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Choose-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi","","1"},

new string[]{"Choose","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Choose-v3.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Claim","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Claim.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Clean","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Clean.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Clear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Clear.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Close (Shut)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Close(Shut)-v1.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Close (Shut)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Close(Shut)-v2.mp4","ShadeAxas","B","Close the box","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Comfort","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Comfort.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Command / Order","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CommandOrder-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Command / Order","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CommandOrder-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Command / Order","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CommandOrder-v3.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Communicate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Communicate.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Compare","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Compare.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Complain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Complain.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Compliment","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Compliment.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Concentrate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Concentrate.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Construct","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Construct.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Control","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Control-v1.mp4","DmTheMechanic","I","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Control","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Control-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Cook","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cook-v1.mp4","Nemsi","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Cook","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cook-v2.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Copy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Copy.mp4","ShadeAxas","B","","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Correct (Right)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Correct(Right).mp4","Nemsi","B","Correct as in 'You're correct that I'm playing VRChat.'","3","CODAPop, DmTheMechanic, Nemsi","","1"},
new string[]{"Correct (Fix)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Correct(Fix).mp4","ShadeAxas","B","Correct as in 'I'm gonna correct that issue.'","3","CODAPop, DmTheMechanic, Nemsi","","1"},
},
new string[][]{//Verbs & Actions p3
new string[]{"Cough","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cough.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Count","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Count-v1.mp4","DmTheMechanic","I","","3","","","1"},
new string[]{"Count","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Count-v2.mp4","ShadeAxas","G","","3","","","1"},
new string[]{"Create / Make","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CreateMake.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Cuddle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cuddle.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Cut","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cut.mp4","Nemsi","B","","2","","","1"},
new string[]{"Dance","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dance.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Date / Dating","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DateDating.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Depend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Depend.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Describe (Explain)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Describe(Explain)-v1.mp4","DmTheMechanic","I","","3","","","1"},
new string[]{"Describe (Explain)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Describe(Explain)-v2.mp4","ShadeAxas","G","","3","","","1"},
new string[]{"Dirty","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dirty-v1.mp4","DmTheMechanic","I","","3","","","1"},
new string[]{"Dirty","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dirty-v2.mp4","ShadeAxas","G","","3","","","1"},
new string[]{"Disappear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disappear.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Disappoint","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disappoint.mp4","Nemsi","B","","1","","","1"},
new string[]{"Disapprove","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disapprove.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Discuss","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Discuss.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Disguise","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disguise.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Dismiss","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dismiss.mp4","ShadeAxas","B","","3","","","1"},

new string[]{"Doubt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Doubt.mp4","Nemsi","I","","2","","","1"},

new string[]{"Dream","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dream-v2.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Dress (Verb)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dress(Verb).mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Drop","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drop.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Drown","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drown.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Dry","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dry.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Dump","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dump.mp4","ShadeAxas","B","","3","","","1"},

new string[]{"Earn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Earn.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Effect","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Effect.mp4","ShadeAxas","B","","1","","non-texas variant","1"},
new string[]{"End","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/End.mp4","ShadeAxas","B","","1","","hand start position","1"},
new string[]{"Escape","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Escape.mp4","ShadeAxas","B","","3","","","1"},
new string[]{"Escort","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Escort.mp4","ShadeAxas","B","","3","","","1"},
},
new string[][]{//Verbs & Actions p4
new string[]{"Excuse (Verb)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excuse(Verb).mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Expose","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Expose.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fail","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fail.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Faint","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Faint.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fake","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fake.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fart","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fart.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fear.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fill","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fill.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Find","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Find-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Find","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Find-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Find","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Find-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Finish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Finish.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fix","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fix.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Flirt","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Flirt-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Flirt","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Flirt-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Fly","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fly.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Forbid","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forbid.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Forgive","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forgive.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Gain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Gain.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Give","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Give-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Give","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Give-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Give","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Give-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Glow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Glow.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Grab","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grab.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Grow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grow.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Guard","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guard.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Guess","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guess.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Guide","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guide.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Harass / Bother","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HarassBother.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Harm","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Harm.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hit.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hold","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hold.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hop","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hop.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hope","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hope.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hunt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hunt.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Ignore","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ignore.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Imagine","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Imagine","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Imagine","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v3.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Imagine","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v4.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Imagine","5","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v5.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Imitate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imitate.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Insult","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Insult.mp4","ShadeAxas","B","","2","","","1"},
},
new string[][]{//Verbs & Actions p5
new string[]{"Interact","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interact.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Interfere","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interfere.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Join","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Join.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Judge","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Judge-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Judge","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Judge-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Judge","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Judge-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Jump","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jump.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Kidding","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kidding-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Kidding","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kidding-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Kidding","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kidding-v3.mp4","ShadeAxas","G","","2","","","1"},

new string[]{"Keep","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Keep","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Keep","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v3.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Keep","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v4.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Kick","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kick-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Kick","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kick-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Kick","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kick-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Kill","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kill.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Knock","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Knock.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Lead","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lead.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Lick","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lick.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Lock","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lock.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Manipulate","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Manipulate-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Manipulate","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Manipulate-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Melt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Melt.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Mess","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mess.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Miss (Didn't Get It)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Miss(DidntGetIt).mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Mistake","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mistake-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Mistake","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mistake-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Mount","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mount.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Move","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Move.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Nod","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nod.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Note","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Note.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Notice","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Notice.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Obey","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obey.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Obsess","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obsess-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Obsess","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obsess-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Obsess","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obsess-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Obtain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obtain.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Occupy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Occupy.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Offend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offend.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Offer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offer.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Okay (Approve)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Okay(Approve).mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Open","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Open.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Owe","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Owe.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Own","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Own.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pass","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pass.mp4","ShadeAxas","B","","2","","","1"},
},
new string[][]{//Verbs & Actions p6
new string[]{"Party","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Party.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pat.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pet","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pet.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pick","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pick-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Pick","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pick-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Pick","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pick-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Plug","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Plug.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Point","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Point.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Poke","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Poke.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pray","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pray.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Prepare","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prepare.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Present (Lecture)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Present(Lecture).mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pretend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pretend.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Protect","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Protect.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Prove","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prove.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Publish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Publish.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Puke","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Puke.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Pull","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pull.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Punch","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Punch.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Push","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Push.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Put","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Put.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Question","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Question-v1.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Question","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Question-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Questions","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Questions.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Quit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quit.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Quote","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quote.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"React","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/React.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Recommend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Recommend.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Refuse","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Refuse.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Regret","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Regret.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Remember","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remember.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Replace","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Replace-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Replace","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Replace-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Report","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Report.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Reset","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Reset.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Ride","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ride.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Rub","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rub.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Rule (Rules)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rule(Rules).mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Run","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Run.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Save","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Save-v1.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Save","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Save-v2.mp4","ShadeAxas","B","","2","","","1"},
},
new string[][]{//Verbs & Actions p7
new string[]{"Say","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Say.mp4","Melwil","B","","2","","","1"},
new string[]{"Search","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Search.mp4","Melwil","B","","2","","","1"},
new string[]{"See","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/See.mp4","Melwil","B","","2","","","1"},
new string[]{"Share","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Share.mp4","Melwil","B","","2","","","1"},
new string[]{"Shock","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shock.mp4","Melwil","B","","2","","","1"},
new string[]{"Shop (Store)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shop(Store).mp4","Melwil","B","","2","","","1"},
new string[]{"Show","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Show.mp4","Melwil","B","","2","","","1"},
new string[]{"Shut Down","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ShutDown-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Shut Down","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ShutDown-v2.mp4","Melwil","G","","2","","","1"},
new string[]{"Shut Up","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ShutUp.mp4","Melwil","B","","2","","","1"},




new string[]{"Smoke (Airborn)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smoke(Airborn)-v1.mp4","Melwil","B","","2","","","1"},
new string[]{"Smoke (Airborn)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smoke(Airborn)-v2.mp4","Melwil","B","","2","","","1"},
new string[]{"Speak / Talk","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpeakTalk-v1.mp4","Melwil","G","","2","","","1"},
new string[]{"Speak / Talk","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpeakTalk-v2.mp4","Melwil","I","","2","","","1"},

new string[]{"Stand","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stand.mp4","Melwil","B","","2","","","1"},
new string[]{"Stay","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stay-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Stay","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stay-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Steal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Steal.mp4","Melwil","B","","2","","","1"},
new string[]{"Study","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Study-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Study","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Study-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Suffer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Suffer.mp4","Melwil","B","","2","","","1"},
new string[]{"Swim","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Swim.mp4","Melwil","B","","2","","","1"},
new string[]{"Switch","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Switch.mp4","Melwil","I","","2","","","1"},
new string[]{"Take (From)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Take(From).mp4","Melwil","B","","2","","","1"},
new string[]{"Tell","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tell.mp4","Melwil","B","","2","","","1"},
new string[]{"Test","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Test.mp4","Melwil","B","","2","","","1"},
new string[]{"Text","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Text.mp4","Melwil","B","","2","","","1"},
new string[]{"Think","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Think.mp4","Melwil","B","","2","","","1"},
new string[]{"Throw","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Throw-v1.mp4","Melwil","B","","2","","","1"},
new string[]{"Throw","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Throw-v2.mp4","Melwil","I","","2","","","1"},


new string[]{"Try","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Try-v1.mp4","Melwil","B","","2","","","1"},
new string[]{"Try","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Try-v2.mp4","Melwil","B","Signed Exact English Variant","2","","","1"},





},
new string[][]{//Verbs & Actions p8
new string[]{"Bath / Bathe / Bathing","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v1.mp4","DmTheMechanic","B","Looks similar to 'which' but is this sign is done against your chest. 'Which' is done in midair.","2","","","1"},
new string[]{"Bath / Bathe / Bathing","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v2.mp4","DmTheMechanic","B","Looks similar to 'which' but is this sign is done against your chest. 'Which' is done in midair.","2","","","1"},
new string[]{"Bath / Bathe / Bathing","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v3.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Calculator","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculator.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Calculate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculate.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Thinking","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Thinking.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Drive","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drive.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Fiction","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fiction.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Help","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Help.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Hug","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hug-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Hug","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hug-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Kiss","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v1.mp4","DmTheMechanic","G","","2","","Initialized K hand version might be best","1"},
new string[]{"Kiss","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v2.mp4","DmTheMechanic","G","","2","","","1"},
new string[]{"Kiss","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v3.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Kiss","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v4.mp4","Tenri","I","","2","","","1"},
new string[]{"Lie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lie.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Serve","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Serve.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Shower","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shower.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Socialize","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Socialize.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Sting","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sting.mp4","Melwil","I","","2","","",""},
new string[]{"Support","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Support.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Take Care","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare-v1.mp4","Nemsi","B","","3","","","1"},
new string[]{"Take Care","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare-v2.mp4","DmTheMechanic","B","Note: this is actually two signs: Take (up) + Care","2","","","1"},
new string[]{"Touch","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Touch-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Touch","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Touch-v2.mp4","DmTheMechanic","I","","2","","","1"},

new string[]{"Trip (Fall Over)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip(FallOver)-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Trip (Fall Over)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip(FallOver)-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Trip","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Trip","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"True ","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/True-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"True ","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/True-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Trust","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trust-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Trust","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trust-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Turn","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turn-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Turn","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turn-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Type","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Type.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Upset","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Upset.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Use","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Use.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"View","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/View-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"View","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/View-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Vomit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Vomit.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Wait","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wait.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Wake Up","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WakeUp.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"War","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/War-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"War","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/War-v2.mp4","DmTheMechanic","G","","2","","","1"},
new string[]{"Warn","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Warn-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Warn","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Warn-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Wash","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Wash","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Wash","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v3.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Wash","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v4.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Waste","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Waste-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Waste","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Waste-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Watch (Look)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v1.mp4","Melwil","B","","2","","","1"},
new string[]{"Watch (Look)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Watch (Look)","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wear","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Wear","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Wear (Clothes)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear(Clothes)-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Wear (Clothes)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear(Clothes)-v2.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Wonder","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wonder.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Worry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Worry-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Worry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Worry-v2.mp4","DmTheMechanic","G","","2","","","1"},
new string[]{"Wristwatch","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wristwatch-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Wristwatch","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wristwatch-v2.mp4","DmTheMechanic","I","","2","","","1"},
},//end of lesson
new string[][]{//Food
new string[]{"Apple","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Apple-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Apple","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Apple-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Banana","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Banana.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Beer","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beer-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Beer","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beer-v2.mp4","CODApop","I","","2","","","1"},
new string[]{"Bread","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bread.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Butter","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Butter.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Cabbage","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cabbage.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Cake","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cake.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Carrot","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Carrot.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Cheese","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheese.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Coke","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Coke.mp4","CODApop","B","","2","","","1"},
new string[]{"Cookie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cookie.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Corn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Corn.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Drunk","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drunk.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Egg","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Egg.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fruit","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fruit-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Fruit","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fruit-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Grapes","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grapes.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hamburger","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hamburger.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hot Dog","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HotDog.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hungover","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hungover.mp4","Melwil","I","","2","","","1"},
new string[]{"Icecream","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Icecream.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Juice","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Juice-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Juice","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Juice-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Lemon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lemon.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Meat","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meat-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Meat","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meat-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Milk","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Milk.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Nuts","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nuts.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Orange (Fruit)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Orange(Fruit).mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Pear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pear.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Pizza","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pizza-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Pizza","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pizza-v2.mp4","CODApop","I","","2","","","1"},
new string[]{"Pizza","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pizza-v3.mp4","CODApop","I","","2","","","1"},
new string[]{"Pizza","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pizza-v4.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Potato","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Potato-v1.mp4","CODApop","B","","2","","","1"},
new string[]{"Potato","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Potato-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Pumpkin","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pumpkin-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Pumpkin","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pumpkin-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Salt","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Salt-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Salt","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Salt-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Sandwich","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sandwich.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Soda","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soda-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Soda","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soda-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Spaghetti","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Spaghetti-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Spaghetti","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Spaghetti-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Sugar","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sugar.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Sushi","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sushi-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Sushi","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sushi-v2.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Tomato","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tomato.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Vegetable","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Vegetable.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Water","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Water-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Water","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Water-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Wine","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wine-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Wine","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wine-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Yogurt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yogurt.mp4","DmTheMechanic","I","","2","","","1"},
},//end of lesson
new string[][]{//Animals 
new string[]{"Bear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bear.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Cat","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cat-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Cat","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cat-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Chicken","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Chicken.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Cow","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cow-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Cow","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cow-v2.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Dog","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dog.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Duck","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Duck.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Fish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fish.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Fox","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fox-v1.mp4","CODApop","I","","2","","","1"},
new string[]{"Fox","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fox-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Lion","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lion-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Lion","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lion-v2.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Owl","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Owl.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Pig","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pig.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Rabbit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rabbit.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Sheep","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sheep.mp4","ShadeAxas","B","","2","","","1"},

new string[]{"Turkey (Bird)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turkey(Bird).mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Turtle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turtle.mp4","DmTheMechanic","B","","2","","","1"},
},//end of lesson
new string[][]{//Machines
new string[]{"Rocket","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rocket.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Car","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Car-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Car","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Car-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Car","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Car-v3.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Truck","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Truck.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Bicycle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bicycle.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Motorcycle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Motorcycle.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Train (Vehicle)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Train(Vehicle).mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Robot","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Robot.mp4","DmTheMechanic","B","","2","","","1"},


new string[]{"Helicopter","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Helicopter.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Bus","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bus.mp4","DmTheMechanic","I","","2","","","1"},







new string[]{"Tank","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tank.mp4","DmTheMechanic","B","","2","","","1"},

},//end of lesson
new string[][]{//Places
new string[]{"Bathroom","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bathroom.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Room","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Room-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Room","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Room-v2.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"House","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/House.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Apartment","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Apartment.mp4","DmTheMechanic","B","","2","","","1"},







new string[]{"Island","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Island.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Sun","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sun.mp4","DmTheMechanic","B","Please don't mistake it as 'Shower'","2","","","1"},
new string[]{"Moon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Moon.mp4","DmTheMechanic","I","","2","","","1"},



new string[]{"Heaven","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Heaven.mp4","DmTheMechanic","B","","2","","","1"},



new string[]{"Beach","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beach.mp4","DmTheMechanic","B","","2","","","1"},




new string[]{"Church","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Church.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Store","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Store.mp4","DmTheMechanic","B","","2","","",""},

new string[]{"Prison","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prison.mp4","DmTheMechanic","B","","2","","",""},



new string[]{"Hotel","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hotel.mp4","DmTheMechanic","I","","2","","",""},





new string[]{"World","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/World.mp4","Nemsi","I","IRL sign for world","2","","","1"},
},//end of lesson
new string[][]{//Stuff
new string[]{"Liquid","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Liquid.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Electricity / Battery","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ElectricityBattery.mp4","DmTheMechanic","I","","2","","","1"},


new string[]{"Shovel","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shovel.mp4","DmTheMechanic","B","","2","","",""},


new string[]{"Box","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Box.mp4","DmTheMechanic","B","","2","","",""},

new string[]{"Paper","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Paper.mp4","DmTheMechanic","B","","2","","",""},
new string[]{"Pencil","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pencil.mp4","DmTheMechanic","B","","2","","",""},
new string[]{"Eraser","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Eraser.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Book","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Book.mp4","DmTheMechanic","B","","2","","","1"},









},//end of lesson
new string[][]{//Weather















},//end of lesson
new string[][]{//Clothing
new string[]{"Belt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Belt.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Bikini","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bikini.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Bra","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bra.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Diapers","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Diapers.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Dress","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dress.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Hat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hat.mp4","DmTheMechanic","B","","2","","","1"},



new string[]{"Pants","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pants.mp4","DmTheMechanic","B","","2","","","1"},


new string[]{"Shirt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shirt.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Shorts","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shorts.mp4","DmTheMechanic","B","","2","","","1"},

new string[]{"Swim Trunks","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SwimTrunks.mp4","DmTheMechanic","B","","2","","","1"},

},//end of lesson
new string[][]{//Accessories



new string[]{"Bow Tie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BowTie.mp4","Melwil","B","","2","","",""},











new string[]{"Tie (Necktie)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tie(Necktie).mp4","Melwil","B","","2","","",""},


},//end of lesson
new string[][]{//Fantasy / Characters







































},//end of lesson
new string[][]{//Non Manual Markers
new string[]{"Or","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Or-v2.mp4","Melwil","B","","2","","",""},


},//end of lesson
new string[][]{//Conceptual Accuracy
new string[]{"Bend","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bend-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Bend","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bend-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Carry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Carry-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Carry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Carry-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Catch","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Catch-v1.mp4","Nemsi","B","","2","","","1"},
new string[]{"Catch","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Catch-v2.mp4","Nemsi","B","","2","","","1"},
new string[]{"Catch","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Catch-v3.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Under","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Under.mp4","Melwil","B","","1","","",""},
},//end of lesson
new string[][]{//Holidays / Special Days





































},//end of lesson
new string[][]{//Home stuff









































},//end of lesson
new string[][]{//Nature / Environment










































},//end of lesson
new string[][]{//Talk / Asking exercises (SEE)




































},//end of lesson
new string[][]{//Countries / Locations








































},//end of lesson
new string[][]{//Colors
new string[]{"Black","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Black.mp4","CODApop","B","","2","","",""},
new string[]{"Blue","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blue.mp4","CODApop","I","","2","","",""},
new string[]{"Brown","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brown.mp4","CODApop","I","","2","","",""},
new string[]{"Color","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Color.mp4","CODApop","I","","2","","",""},
new string[]{"Gold","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Gold.mp4","CODApop","I","","2","","",""},
new string[]{"Green","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Green.mp4","CODApop","I","","2","","",""},
new string[]{"Orange","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Orange.mp4","CODApop","B","","2","","",""},
new string[]{"Pink","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pink.mp4","CODApop","I","","2","","",""},
new string[]{"Purple","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Purple.mp4","CODApop","I","","2","","",""},
new string[]{"Red","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Red.mp4","CODApop","B","","2","","",""},
new string[]{"Silver","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Silver.mp4","CODApop","B","","2","","",""},
new string[]{"White","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/White.mp4","CODApop","B","","2","","",""},
new string[]{"Yellow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yellow.mp4","CODApop","I","","2","","",""},

},//end of lesson













},//end of asl
new string[][][]{//BSL lessons
new string[][]{//BSL Lesson 1 - Daily Use
new string[]{"Hello","","https://vrsignlanguage.net/BSL_videos/sheet01/01-01.mp4","Sheezy93","","","3","","","0"},
new string[]{"How are you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-02.mp4","Sheezy93","","","3","","","0"},
new string[]{"What’s up?","","https://vrsignlanguage.net/BSL_videos/sheet01/01-03.mp4","Sheezy93","","","3","","","0"},
new string[]{"Nice to meet you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-04.mp4","Sheezy93","","","3","","","0"},
new string[]{"Good","","https://vrsignlanguage.net/BSL_videos/sheet01/01-05.mp4","Sheezy93","","","3","","","0"},
new string[]{"Bad","","https://vrsignlanguage.net/BSL_videos/sheet01/01-06.mp4","Sheezy93","","","3","","","0"},
new string[]{"Yes","","https://vrsignlanguage.net/BSL_videos/sheet01/01-07.mp4","Sheezy93","","","3","","","0"},
new string[]{"No","","https://vrsignlanguage.net/BSL_videos/sheet01/01-08.mp4","Sheezy93","","","3","","","0"},
new string[]{"So-So","","https://vrsignlanguage.net/BSL_videos/sheet01/01-09.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sick","","https://vrsignlanguage.net/BSL_videos/sheet01/01-10.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hurt","","https://vrsignlanguage.net/BSL_videos/sheet01/01-11.mp4","Sheezy93","","","3","","","0"},
new string[]{"You’re welcome","","https://vrsignlanguage.net/BSL_videos/sheet01/01-12.mp4","Sheezy93","","","3","","","0"},
new string[]{"Good bye","","https://vrsignlanguage.net/BSL_videos/sheet01/01-13.mp4","Sheezy93","","","3","","","0"},
new string[]{"Good morning","","https://vrsignlanguage.net/BSL_videos/sheet01/01-14.mp4","Sheezy93","","","3","","","0"},
new string[]{"Good afternoon","","https://vrsignlanguage.net/BSL_videos/sheet01/01-15.mp4","Sheezy93","","","3","","","0"},
new string[]{"Good evening","","https://vrsignlanguage.net/BSL_videos/sheet01/01-16.mp4","Sheezy93","","","3","","","0"},
new string[]{"Good night","","https://vrsignlanguage.net/BSL_videos/sheet01/01-17.mp4","Sheezy93","","","3","","","0"},
new string[]{"See you later","","https://vrsignlanguage.net/BSL_videos/sheet01/01-18.mp4","Sheezy93","","","3","","","0"},
new string[]{"Please","","https://vrsignlanguage.net/BSL_videos/sheet01/01-19.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sorry","","https://vrsignlanguage.net/BSL_videos/sheet01/01-20.mp4","Sheezy93","","","3","","","0"},
new string[]{"Forgotten","","https://vrsignlanguage.net/BSL_videos/sheet01/01-21.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sleep","","https://vrsignlanguage.net/BSL_videos/sheet01/01-22.mp4","Sheezy93","","","3","","","0"},
new string[]{"Bed","","https://vrsignlanguage.net/BSL_videos/sheet01/01-23.mp4","Sheezy93","","","3","","","0"},
new string[]{"Jump / Change world","","https://vrsignlanguage.net/BSL_videos/sheet01/01-24.mp4","Sheezy93","","","3","","","0"},
new string[]{"Thank you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-25.mp4","Sheezy93","","","3","","","0"},
new string[]{"I love you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-26.mp4","Sheezy93","","","3","","","0"},
new string[]{"Go away","","https://vrsignlanguage.net/BSL_videos/sheet01/01-27.mp4","Sheezy93","","","3","","","0"},
new string[]{"Going to","","https://vrsignlanguage.net/BSL_videos/sheet01/01-28.mp4","Sheezy93","","","3","","","0"},
new string[]{"Follow","","https://vrsignlanguage.net/BSL_videos/sheet01/01-29.mp4","Sheezy93","","","3","","","0"},
new string[]{"Come","","https://vrsignlanguage.net/BSL_videos/sheet01/01-30.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hearing","","https://vrsignlanguage.net/BSL_videos/sheet01/01-31.mp4","Sheezy93","","","3","","","0"},
new string[]{"Deaf","","https://vrsignlanguage.net/BSL_videos/sheet01/01-32.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hard to Hear","","https://vrsignlanguage.net/BSL_videos/sheet01/01-33.mp4","Sheezy93","","","3","","","0"},
new string[]{"Mute","","https://vrsignlanguage.net/BSL_videos/sheet01/01-34.mp4","Sheezy93","","","3","","","0"},
new string[]{"Write slow","","https://vrsignlanguage.net/BSL_videos/sheet01/01-35.mp4","Sheezy93","","","3","","","0"},
new string[]{"Cannot read","","https://vrsignlanguage.net/BSL_videos/sheet01/01-36.mp4","Sheezy93","","","3","","","0"},
},
new string[][]{//BSL Lesson 2 - Pointing use Question / Answer
new string[]{"I (Me)","","https://vrsignlanguage.net/BSL_videos/sheet02/02-01_Me.mp4","Sheezy93","","","3","","","0"},
new string[]{"My","","https://vrsignlanguage.net/BSL_videos/sheet02/02-02_My.mp4","Sheezy93","","","3","","","0"},
new string[]{"Your","","https://vrsignlanguage.net/BSL_videos/sheet02/02-03_Your.mp4","Sheezy93","","","3","","","0"},
new string[]{"Him / His / Her","","https://vrsignlanguage.net/BSL_videos/sheet02/02-04_His.mp4","Sheezy93","","","3","","","0"},
new string[]{"We","","https://vrsignlanguage.net/BSL_videos/sheet02/02-06_We.mp4","Sheezy93","","","3","","","0"},
new string[]{"They","","https://vrsignlanguage.net/BSL_videos/sheet02/02-07_They.mp4","Sheezy93","","","3","","","0"},
new string[]{"Their","","https://vrsignlanguage.net/BSL_videos/sheet02/02-08_Their.mp4","Sheezy93","","","3","","","0"},
new string[]{"Over there","","https://vrsignlanguage.net/BSL_videos/sheet02/02-09_OverThere.mp4","Sheezy93","","","3","","","0"},
new string[]{"Our","","https://vrsignlanguage.net/BSL_videos/sheet02/02-10_Our.mp4","Sheezy93","","","3","","","0"},
new string[]{"Inside","","https://vrsignlanguage.net/BSL_videos/sheet02/02-12_Inside.mp4","Sheezy93","","","3","","","0"},
new string[]{"Outside","","https://vrsignlanguage.net/BSL_videos/sheet02/02-13_Outside.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hidden","","https://vrsignlanguage.net/BSL_videos/sheet02/02-14_Hidden.mp4","Sheezy93","","","3","","","0"},
new string[]{"Behind ","","https://vrsignlanguage.net/BSL_videos/sheet02/02-15_behind.mp4","Sheezy93","","","3","","","0"},
new string[]{"Above","","https://vrsignlanguage.net/BSL_videos/sheet02/02-16_above.mp4","Sheezy93","","","3","","","0"},
new string[]{"Below","","https://vrsignlanguage.net/BSL_videos/sheet02/02-17_below.mp4","Sheezy93","","","3","","","0"},
new string[]{"Here","","https://vrsignlanguage.net/BSL_videos/sheet02/02-18_here.mp4","Sheezy93","","","3","","","0"},
new string[]{"Beside","","https://vrsignlanguage.net/BSL_videos/sheet02/02-19_beside.mp4","Sheezy93","","","3","","","0"},
new string[]{"Back ","","https://vrsignlanguage.net/BSL_videos/sheet02/02-20_back.mp4","Sheezy93","","","3","","","0"},
new string[]{"Front","","https://vrsignlanguage.net/BSL_videos/sheet02/02-21_front.mp4","Sheezy93","","","3","","","0"},
new string[]{"Who","","https://vrsignlanguage.net/BSL_videos/sheet02/02-22_who.mp4","Sheezy93","","","3","","","0"},
new string[]{"Where","","https://vrsignlanguage.net/BSL_videos/sheet02/02-23_where.mp4","Sheezy93","","","3","","","0"},
new string[]{"When","","https://vrsignlanguage.net/BSL_videos/sheet02/02-24_when.mp4","Sheezy93","","","3","","","0"},
new string[]{"Why","","https://vrsignlanguage.net/BSL_videos/sheet02/02-25_why.mp4","Sheezy93","","","3","","","0"},
new string[]{"Which","","https://vrsignlanguage.net/BSL_videos/sheet02/02-26_which.mp4","Sheezy93","","","3","","","0"},
new string[]{"What","","https://vrsignlanguage.net/BSL_videos/sheet02/02-27_what.mp4","Sheezy93","","","3","","","0"},
new string[]{"How","","https://vrsignlanguage.net/BSL_videos/sheet02/02-28_how.mp4","Sheezy93","","","3","","","0"},
new string[]{"How many","","https://vrsignlanguage.net/BSL_videos/sheet02/02-29_howmany.mp4","Sheezy93","","","3","","","0"},
new string[]{"Can","","https://vrsignlanguage.net/BSL_videos/sheet02/02-30_can.mp4","Sheezy93","","","3","","","0"},
new string[]{"Can’t","","https://vrsignlanguage.net/BSL_videos/sheet02/02-31_cant.mp4","Sheezy93","","","3","","","0"},
new string[]{"Want","","https://vrsignlanguage.net/BSL_videos/sheet02/02-32_want.mp4","Sheezy93","","","3","","","0"},
new string[]{"Have","","https://vrsignlanguage.net/BSL_videos/sheet02/02-33_have.mp4","Sheezy93","","","3","","","0"},
new string[]{"Get","","https://vrsignlanguage.net/BSL_videos/sheet02/02-34_get.mp4","Sheezy93","","","3","","","0"},
new string[]{"Will","","https://vrsignlanguage.net/BSL_videos/sheet02/02-35_will.mp4","Sheezy93","","","3","","","0"},
new string[]{"Take","","https://vrsignlanguage.net/BSL_videos/sheet02/02-36_take.mp4","Sheezy93","","","3","","","0"},
new string[]{"Need","","https://vrsignlanguage.net/BSL_videos/sheet02/02-37_need.mp4","Sheezy93","","","3","","","0"},
new string[]{"Not","","https://vrsignlanguage.net/BSL_videos/sheet02/02-38_not.mp4","Sheezy93","","","3","","","0"},
new string[]{"Or","","https://vrsignlanguage.net/BSL_videos/sheet02/02-39-or.mp4","Sheezy93","","","3","","","0"},
new string[]{"And","","https://vrsignlanguage.net/BSL_videos/sheet02/02-40_and.mp4","Sheezy93","","","3","","","0"},
new string[]{"For","","https://vrsignlanguage.net/BSL_videos/sheet02/02-41_for.mp4","Sheezy93","","","3","","","0"},
},
new string[][]{//BSL Lesson 3 - Common
new string[]{"Accept","","https://bob64.vrsignlanguage.net/BSL/L3/Accept.mp4","Sheezy93","","","3","","","0"},
new string[]{"Again","","https://bob64.vrsignlanguage.net/BSL/L3/Again.mp4","Sheezy93","","","3","","","0"},
new string[]{"All right","","https://bob64.vrsignlanguage.net/BSL/L3/Allright.mp4","Sheezy93","","","3","","","0"},
new string[]{"Brb","","https://bob64.vrsignlanguage.net/BSL/L3/Brb.mp4","Sheezy93","","","3","","","0"},
new string[]{"Denied","","https://bob64.vrsignlanguage.net/BSL/L3/Denied.mp4","Sheezy93","","","3","","","0"},
new string[]{"Don't Know","1","https://bob64.vrsignlanguage.net/BSL/L3/DontKnow-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Don't Know","2","https://bob64.vrsignlanguage.net/BSL/L3/DontKnow-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Draw (game)","","https://bob64.vrsignlanguage.net/BSL/L3/Draw(game).mp4","Sheezy93","","","3","","","0"},
new string[]{"Drink","","https://bob64.vrsignlanguage.net/BSL/L3/Drink.mp4","Sheezy93","","","3","","","0"},
new string[]{"Eat","","https://bob64.vrsignlanguage.net/BSL/L3/Eat.mp4","Sheezy93","","","3","","","0"},
new string[]{"Fast","","https://bob64.vrsignlanguage.net/BSL/L3/Fast.mp4","Sheezy93","","","3","","","0"},
new string[]{"Favorite","","https://bob64.vrsignlanguage.net/BSL/L3/Favorite.mp4","Sheezy93","","","3","","","0"},
new string[]{"Friend","1","https://bob64.vrsignlanguage.net/BSL/L3/Friend-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Friend","2","https://bob64.vrsignlanguage.net/BSL/L3/Friend-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Friend","3","https://bob64.vrsignlanguage.net/BSL/L3/Friend-v3.mp4","Sheezy93","","","3","","","0"},
new string[]{"Funny","","https://bob64.vrsignlanguage.net/BSL/L3/Funny.mp4","Sheezy93","","","3","","","0"},
new string[]{"Internet","","https://bob64.vrsignlanguage.net/BSL/L3/Internet.mp4","Sheezy93","","","3","","","0"},
new string[]{"Jokes","","https://bob64.vrsignlanguage.net/BSL/L3/Jokes.mp4","Sheezy93","","","3","","","0"},
new string[]{"Know","","https://bob64.vrsignlanguage.net/BSL/L3/Know.mp4","Sheezy93","","","3","","","0"},
new string[]{"Language","","https://bob64.vrsignlanguage.net/BSL/L3/Language.mp4","Sheezy93","","","3","","","0"},
new string[]{"Learn","","https://bob64.vrsignlanguage.net/BSL/L3/Learn.mp4","Sheezy93","","","3","","","0"},
new string[]{"Live","","https://bob64.vrsignlanguage.net/BSL/L3/Live.mp4","Sheezy93","","","3","","","0"},
new string[]{"Make","","https://bob64.vrsignlanguage.net/BSL/L3/Make.mp4","Sheezy93","","","3","","","0"},
new string[]{"Movie","","https://bob64.vrsignlanguage.net/BSL/L3/Movie.mp4","Sheezy93","","","3","","","0"},
new string[]{"Name","","https://bob64.vrsignlanguage.net/BSL/L3/Name.mp4","Sheezy93","","","3","","","0"},
new string[]{"New","","https://bob64.vrsignlanguage.net/BSL/L3/New.mp4","Sheezy93","","","3","","","0"},
new string[]{"Old","1","https://bob64.vrsignlanguage.net/BSL/L3/Old.mp4","Sheezy93","","","3","","","0"},
new string[]{"People","","https://bob64.vrsignlanguage.net/BSL/L3/People.mp4","Sheezy93","","","3","","","0"},
new string[]{"Person","","https://bob64.vrsignlanguage.net/BSL/L3/Person.mp4","Sheezy93","","","3","","","0"},
new string[]{"Play","","https://bob64.vrsignlanguage.net/BSL/L3/Play.mp4","Sheezy93","","","3","","","0"},
new string[]{"Play game","","https://bob64.vrsignlanguage.net/BSL/L3/Playgame.mp4","Sheezy93","","","3","","","0"},
new string[]{"Read","","https://bob64.vrsignlanguage.net/BSL/L3/Read.mp4","Sheezy93","","","3","","","0"},
new string[]{"Repeat","","https://bob64.vrsignlanguage.net/BSL/L3/Repeat.mp4","Sheezy93","","","3","","","0"},
new string[]{"Rude","","https://bob64.vrsignlanguage.net/BSL/L3/Rude.mp4","Sheezy93","","","3","","","0"},
new string[]{"Same","1","https://bob64.vrsignlanguage.net/BSL/L3/Same-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Same","2","https://bob64.vrsignlanguage.net/BSL/L3/Same-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sign","","https://bob64.vrsignlanguage.net/BSL/L3/Sign.mp4","Sheezy93","","","3","","","0"},
new string[]{"Slow","","https://bob64.vrsignlanguage.net/BSL/L3/Slow.mp4","Sheezy93","","","3","","","0"},
new string[]{"Stop","1","https://bob64.vrsignlanguage.net/BSL/L3/Stop-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Stop","2","https://bob64.vrsignlanguage.net/BSL/L3/Stop-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Student","","https://bob64.vrsignlanguage.net/BSL/L3/Student.mp4","Sheezy93","","","3","","","0"},
new string[]{"Teach","","https://bob64.vrsignlanguage.net/BSL/L3/Teach.mp4","Sheezy93","","","3","","","0"},
new string[]{"Teacher","","https://bob64.vrsignlanguage.net/BSL/L3/Teacher.mp4","Sheezy93","","","3","","","0"},
new string[]{"Understand","","https://bob64.vrsignlanguage.net/BSL/L3/Understand.mp4","Sheezy93","","","3","","","0"},
new string[]{"Very","","https://bob64.vrsignlanguage.net/BSL/L3/Very.mp4","Sheezy93","","","3","","","0"},
new string[]{"Watch","","https://bob64.vrsignlanguage.net/BSL/L3/Watch.mp4","Sheezy93","","","3","","","0"},
new string[]{"Work","","https://bob64.vrsignlanguage.net/BSL/L3/Work.mp4","Sheezy93","","","3","","","0"},
new string[]{"Write","","https://bob64.vrsignlanguage.net/BSL/L3/Write.mp4","Sheezy93","","","3","","","0"},
},
new string[][]{//BSL Lesson 4 - People
new string[]{"Adult","","https://bob64.vrsignlanguage.net/BSL/L4/Adult.mp4","Sheezy93","","","3","","","0"},
new string[]{"Age","","https://bob64.vrsignlanguage.net/BSL/L4/Age.mp4","Sheezy93","","","3","","","0"},
new string[]{"Anyone","","https://bob64.vrsignlanguage.net/BSL/L4/Anyone.mp4","Sheezy93","","","3","","","0"},
new string[]{"Aunt","","https://bob64.vrsignlanguage.net/BSL/L4/Aunt.mp4","Sheezy93","","","3","","","0"},
new string[]{"Baby","","https://bob64.vrsignlanguage.net/BSL/L4/Baby.mp4","Sheezy93","","","3","","","0"},
new string[]{"Birthday","","https://bob64.vrsignlanguage.net/BSL/L4/Birthday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Born","","https://bob64.vrsignlanguage.net/BSL/L4/Born.mp4","Sheezy93","","","3","","","0"},
new string[]{"Boy","","https://bob64.vrsignlanguage.net/BSL/L4/Boy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Brother-in-law","","https://bob64.vrsignlanguage.net/BSL/L4/Brother-in-law.mp4","Sheezy93","","","3","","","0"},
new string[]{"Brother","","https://bob64.vrsignlanguage.net/BSL/L4/Brother.mp4","Sheezy93","","","3","","","0"},
new string[]{"Celebrate","","https://bob64.vrsignlanguage.net/BSL/L4/Celebrate.mp4","Sheezy93","","","3","","","0"},
new string[]{"Child","","https://bob64.vrsignlanguage.net/BSL/L4/Child.mp4","Sheezy93","","","3","","","0"},
new string[]{"Dead","","https://bob64.vrsignlanguage.net/BSL/L4/Dead.mp4","Sheezy93","","","3","","","0"},
new string[]{"Divorce","","https://bob64.vrsignlanguage.net/BSL/L4/Divorce.mp4","Sheezy93","","","3","","","0"},
new string[]{"Enemy","","https://bob64.vrsignlanguage.net/BSL/L4/Enemy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Everyone","","https://bob64.vrsignlanguage.net/BSL/L4/Everyone.mp4","Sheezy93","","","3","","","0"},
new string[]{"Family","","https://bob64.vrsignlanguage.net/BSL/L4/Family.mp4","Sheezy93","","","3","","","0"},
new string[]{"Father","","https://bob64.vrsignlanguage.net/BSL/L4/Father.mp4","Sheezy93","","","3","","","0"},
new string[]{"Girl","","https://bob64.vrsignlanguage.net/BSL/L4/Girl.mp4","Sheezy93","","","3","","","0"},
new string[]{"Grandma","","https://bob64.vrsignlanguage.net/BSL/L4/Grandma.mp4","Sheezy93","","","3","","","0"},
new string[]{"Grandpa","","https://bob64.vrsignlanguage.net/BSL/L4/Grandpa.mp4","Sheezy93","","","3","","","0"},
new string[]{"Interpreter","","https://bob64.vrsignlanguage.net/BSL/L4/Interpreter.mp4","Sheezy93","","","3","","","0"},
new string[]{"Marriage","","https://bob64.vrsignlanguage.net/BSL/L4/Marriage.mp4","Sheezy93","","","3","","","0"},
new string[]{"Mum","1","https://bob64.vrsignlanguage.net/BSL/L4/Mum-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Mum","2","https://bob64.vrsignlanguage.net/BSL/L4/Mum-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"No one","","https://bob64.vrsignlanguage.net/BSL/L4/Noone.mp4","Sheezy93","","","3","","","0"},
new string[]{"Old","2","https://bob64.vrsignlanguage.net/BSL/L4/Old.mp4","Sheezy93","","","3","","","0"},
new string[]{"Parents","","https://bob64.vrsignlanguage.net/BSL/L4/Parents.mp4","Sheezy93","","","3","","","0"},
new string[]{"Single","","https://bob64.vrsignlanguage.net/BSL/L4/Single.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sister-in-law","","https://bob64.vrsignlanguage.net/BSL/L4/Sister-in-law.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sister","","https://bob64.vrsignlanguage.net/BSL/L4/Sister.mp4","Sheezy93","","","3","","","0"},
new string[]{"Someone","","https://bob64.vrsignlanguage.net/BSL/L4/Someone.mp4","Sheezy93","","","3","","","0"},
new string[]{"Teen","","https://bob64.vrsignlanguage.net/BSL/L4/Teen.mp4","Sheezy93","","","3","","","0"},
new string[]{"Uncle","","https://bob64.vrsignlanguage.net/BSL/L4/Uncle.mp4","Sheezy93","","","3","","","0"},
new string[]{"Young","","https://bob64.vrsignlanguage.net/BSL/L4/Young.mp4","Sheezy93","","","3","","","0"},
},
new string[][]{//BSL Lesson 5 - Feelings / Reactions
new string[]{"Alive","","https://bob64.vrsignlanguage.net/BSL/L5/Alive.mp4","Sheezy93","","","3","","","0"},
new string[]{"Angry","","https://bob64.vrsignlanguage.net/BSL/L5/Angry.mp4","Sheezy93","","","3","","","0"},
new string[]{"Attention","","https://bob64.vrsignlanguage.net/BSL/L5/Attention.mp4","Sheezy93","","","3","","","0"},
new string[]{"Awesome","","https://bob64.vrsignlanguage.net/BSL/L5/Awesome.mp4","Sheezy93","","","3","","","0"},
new string[]{"Bored","","https://bob64.vrsignlanguage.net/BSL/L5/Bored.mp4","Sheezy93","","","3","","","0"},
new string[]{"Careful","","https://bob64.vrsignlanguage.net/BSL/L5/Careful.mp4","Sheezy93","","","3","","","0"},
new string[]{"Confused","","https://bob64.vrsignlanguage.net/BSL/L5/Confused.mp4","Sheezy93","","","3","","","0"},
new string[]{"Cry","","https://bob64.vrsignlanguage.net/BSL/L5/Cry.mp4","Sheezy93","","","3","","","0"},
new string[]{"Curious","","https://bob64.vrsignlanguage.net/BSL/L5/Curious.mp4","Sheezy93","","","3","","","0"},
new string[]{"Cute","","https://bob64.vrsignlanguage.net/BSL/L5/Cute.mp4","Sheezy93","","","3","","","0"},
new string[]{"Disgusted","","https://bob64.vrsignlanguage.net/BSL/L5/Disgusted.mp4","Sheezy93","","","3","","","0"},
new string[]{"Embarassed","","https://bob64.vrsignlanguage.net/BSL/L5/Embarassed.mp4","Sheezy93","","","3","","","0"},
new string[]{"Enjoy","","https://bob64.vrsignlanguage.net/BSL/L5/Enjoy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Envy","","https://bob64.vrsignlanguage.net/BSL/L5/Envy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Excited","","https://bob64.vrsignlanguage.net/BSL/L5/Excited.mp4","Sheezy93","","","3","","","0"},
new string[]{"Feel","","https://bob64.vrsignlanguage.net/BSL/L5/Feel.mp4","Sheezy93","","","3","","","0"},
new string[]{"Fine","","https://bob64.vrsignlanguage.net/BSL/L5/Fine.mp4","Sheezy93","","","3","","","0"},
new string[]{"Focus","","https://bob64.vrsignlanguage.net/BSL/L5/Focus.mp4","Sheezy93","","","3","","","0"},
new string[]{"Friendly","","https://bob64.vrsignlanguage.net/BSL/L5/Friendly.mp4","Sheezy93","","","3","","","0"},
new string[]{"Great","","https://bob64.vrsignlanguage.net/BSL/L5/Great.mp4","Sheezy93","","","3","","","0"},
new string[]{"Happy","","https://bob64.vrsignlanguage.net/BSL/L5/Happy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hate","1","https://bob64.vrsignlanguage.net/BSL/L5/Hate-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hate","2","https://bob64.vrsignlanguage.net/BSL/L5/Hate-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hungry","","https://bob64.vrsignlanguage.net/BSL/L5/Hungry.mp4","Sheezy93","","","3","","","0"},
new string[]{"In love","","https://bob64.vrsignlanguage.net/BSL/L5/Inlove.mp4","Sheezy93","","","3","","","0"},
new string[]{"Laughing","","https://bob64.vrsignlanguage.net/BSL/L5/Laughing.mp4","Sheezy93","","","3","","","0"},
new string[]{"Like","","https://bob64.vrsignlanguage.net/BSL/L5/Like.mp4","Sheezy93","","","3","","","0"},
new string[]{"LOL","1","https://bob64.vrsignlanguage.net/BSL/L5/LOL-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"LOL","2","https://bob64.vrsignlanguage.net/BSL/L5/LOL-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Lonely","","https://bob64.vrsignlanguage.net/BSL/L5/Lonely.mp4","Sheezy93","","","3","","","0"},
new string[]{"Mean","","https://bob64.vrsignlanguage.net/BSL/L5/Mean.mp4","Sheezy93","","","3","","","0"},
new string[]{"Nevermind","","https://bob64.vrsignlanguage.net/BSL/L5/Nevermind.mp4","Sheezy93","","","3","","","0"},
new string[]{"Nice","","https://bob64.vrsignlanguage.net/BSL/L5/Nice.mp4","Sheezy93","","","3","","","0"},
new string[]{"Pity","","https://bob64.vrsignlanguage.net/BSL/L5/Pity.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sad","","https://bob64.vrsignlanguage.net/BSL/L5/Sad.mp4","Sheezy93","","","3","","","0"},
new string[]{"Scared","","https://bob64.vrsignlanguage.net/BSL/L5/Scared.mp4","Sheezy93","","","3","","","0"},
new string[]{"Shame","","https://bob64.vrsignlanguage.net/BSL/L5/Shame.mp4","Sheezy93","","","3","","","0"},
new string[]{"Shy","","https://bob64.vrsignlanguage.net/BSL/L5/Shy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sleepy","","https://bob64.vrsignlanguage.net/BSL/L5/Sleepy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Smart","","https://bob64.vrsignlanguage.net/BSL/L5/Smart.mp4","Sheezy93","","","3","","","0"},
new string[]{"Stressed","1","https://bob64.vrsignlanguage.net/BSL/L5/Stressed(Variant1).mp4","Sheezy93","","","3","","","0"},
new string[]{"Stressed","2","https://bob64.vrsignlanguage.net/BSL/L5/Stressed(Variant2).mp4","Sheezy93","","","3","","","0"},
new string[]{"Struggle","","https://bob64.vrsignlanguage.net/BSL/L5/Struggle.mp4","Sheezy93","","","3","","","0"},
new string[]{"Suffering","","https://bob64.vrsignlanguage.net/BSL/L5/Suffering.mp4","Sheezy93","","","3","","","0"},
new string[]{"Surprised","","https://bob64.vrsignlanguage.net/BSL/L5/Surprised.mp4","Sheezy93","","","3","","","0"},
new string[]{"Tired","","https://bob64.vrsignlanguage.net/BSL/L5/Tired.mp4","Sheezy93","","","3","","","0"},
},
new string[][]{//BSL Lesson 6 - Value
new string[]{"After","","https://bob64.vrsignlanguage.net/BSL/L6/After.mp4","Sheezy93","","","3","","","0"},
new string[]{"All","","https://bob64.vrsignlanguage.net/BSL/L6/All.mp4","Sheezy93","","","3","","","0"},
new string[]{"Always","1","https://bob64.vrsignlanguage.net/BSL/L6/Always-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Always","2","https://bob64.vrsignlanguage.net/BSL/L6/Always-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"A little","","https://bob64.vrsignlanguage.net/BSL/L6/Alittle.mp4","Sheezy93","","","3","","","0"},
new string[]{"A lot","","https://bob64.vrsignlanguage.net/BSL/L6/Alot.mp4","Sheezy93","","","3","","","0"},
new string[]{"Before","1","https://bob64.vrsignlanguage.net/BSL/L6/Before-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Before","2","https://bob64.vrsignlanguage.net/BSL/L6/Before-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Big","","https://bob64.vrsignlanguage.net/BSL/L6/Big.mp4","Sheezy93","","","3","","","0"},
new string[]{"Busy","","https://bob64.vrsignlanguage.net/BSL/L6/Busy.mp4","Sheezy93","","","3","","","0"},
new string[]{"Empty","","https://bob64.vrsignlanguage.net/BSL/L6/Empty.mp4","Sheezy93","","","3","","","0"},
new string[]{"Ever","","https://bob64.vrsignlanguage.net/BSL/L6/Ever.mp4","Sheezy93","","","3","","","0"},
new string[]{"Everything","","https://bob64.vrsignlanguage.net/BSL/L6/Everything.mp4","Sheezy93","","","3","","","0"},
new string[]{"Everytime","","https://bob64.vrsignlanguage.net/BSL/L6/Everytime.mp4","Sheezy93","","","3","","","0"},
new string[]{"Fat","","https://bob64.vrsignlanguage.net/BSL/L6/Fat.mp4","Sheezy93","","","3","","","0"},
new string[]{"First","","https://bob64.vrsignlanguage.net/BSL/L6/First.mp4","Sheezy93","","","3","","","0"},
new string[]{"Free","","https://bob64.vrsignlanguage.net/BSL/L6/Free.mp4","Sheezy93","","","3","","","0"},
new string[]{"Full","1","https://bob64.vrsignlanguage.net/BSL/L6/Full-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Full","2","https://bob64.vrsignlanguage.net/BSL/L6/Full-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Half","","https://bob64.vrsignlanguage.net/BSL/L6/Half.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hard","","https://bob64.vrsignlanguage.net/BSL/L6/Hard.mp4","Sheezy93","","","3","","","0"},
new string[]{"Heavy","","https://bob64.vrsignlanguage.net/BSL/L6/Heavy.mp4","Sheezy93","","","3","","","0"},
new string[]{"High","","https://bob64.vrsignlanguage.net/BSL/L6/High.mp4","Sheezy93","","","3","","","0"},
new string[]{"Last","","https://bob64.vrsignlanguage.net/BSL/L6/Last.mp4","Sheezy93","","","3","","","0"},
new string[]{"Less","","https://bob64.vrsignlanguage.net/BSL/L6/Less.mp4","Sheezy93","","","3","","","0"},
new string[]{"Lightweight","","https://bob64.vrsignlanguage.net/BSL/L6/Lightweight.mp4","Sheezy93","","","3","","","0"},
new string[]{"Limited","","https://bob64.vrsignlanguage.net/BSL/L6/Limited.mp4","Sheezy93","","","3","","","0"},
new string[]{"Long","","https://bob64.vrsignlanguage.net/BSL/L6/Long.mp4","Sheezy93","","","3","","","0"},
new string[]{"Low","","https://bob64.vrsignlanguage.net/BSL/L6/Low.mp4","Sheezy93","","","3","","","0"},
new string[]{"Many","","https://bob64.vrsignlanguage.net/BSL/L6/Many.mp4","Sheezy93","","","3","","","0"},
new string[]{"More","","https://bob64.vrsignlanguage.net/BSL/L6/More.mp4","Sheezy93","","","3","","","0"},
new string[]{"Next","","https://bob64.vrsignlanguage.net/BSL/L6/Next.mp4","Sheezy93","","","3","","","0"},
new string[]{"Nothing","1","https://bob64.vrsignlanguage.net/BSL/L6/Nothing-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Nothing","2","https://bob64.vrsignlanguage.net/BSL/L6/Nothing-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Often","","https://bob64.vrsignlanguage.net/BSL/L6/Often.mp4","Sheezy93","","","3","","","0"},
new string[]{"Quarter","","https://bob64.vrsignlanguage.net/BSL/L6/Quarter.mp4","Sheezy93","","","3","","","0"},
new string[]{"Second","","https://bob64.vrsignlanguage.net/BSL/L6/Second.mp4","Sheezy93","","","3","","","0"},
new string[]{"Short","","https://bob64.vrsignlanguage.net/BSL/L6/Short.mp4","Sheezy93","","","3","","","0"},
new string[]{"Small","","https://bob64.vrsignlanguage.net/BSL/L6/Small.mp4","Sheezy93","","","3","","","0"},
new string[]{"Soft","","https://bob64.vrsignlanguage.net/BSL/L6/Soft.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sometimes","1","https://bob64.vrsignlanguage.net/BSL/L6/Sometimes-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sometimes","2","https://bob64.vrsignlanguage.net/BSL/L6/Sometimes-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Strong","1","https://bob64.vrsignlanguage.net/BSL/L6/Strong-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Strong","2","https://bob64.vrsignlanguage.net/BSL/L6/Strong-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Thin","","https://bob64.vrsignlanguage.net/BSL/L6/Thin.mp4","Sheezy93","","","3","","","0"},
new string[]{"Third","","https://bob64.vrsignlanguage.net/BSL/L6/Third.mp4","Sheezy93","","","3","","","0"},
new string[]{"Unlimited","","https://bob64.vrsignlanguage.net/BSL/L6/Unlimited.mp4","Sheezy93","","","3","","","0"},
new string[]{"Value","","https://bob64.vrsignlanguage.net/BSL/L6/Value.mp4","Sheezy93","","","3","","","0"},
new string[]{"Weak","","https://bob64.vrsignlanguage.net/BSL/L6/Weak.mp4","Sheezy93","","","3","","","0"},
},//end of lesson
new string[][]{//BSL Lesson 7 - Time
new string[]{"Afternoon","","https://bob64.vrsignlanguage.net/BSL/L7/Afternoon.mp4","Sheezy93","","","3","","","0"},
new string[]{"All day","","https://bob64.vrsignlanguage.net/BSL/L7/Allday.mp4","Sheezy93","","","3","","","0"},
new string[]{"All night","","https://bob64.vrsignlanguage.net/BSL/L7/Allnight.mp4","Sheezy93","","","3","","","0"},
new string[]{"Autumn","1","https://bob64.vrsignlanguage.net/BSL/L7/Autumn-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Autumn","2","https://bob64.vrsignlanguage.net/BSL/L7/Autumn-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Break (time)","1","https://bob64.vrsignlanguage.net/BSL/L7/Break(time)-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Break (time)","2","https://bob64.vrsignlanguage.net/BSL/L7/Break(time)-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Day","","https://bob64.vrsignlanguage.net/BSL/L7/Day.mp4","Sheezy93","","","3","","","0"},
new string[]{"Evening","1","https://bob64.vrsignlanguage.net/BSL/L7/Evening-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Evening","2","https://bob64.vrsignlanguage.net/BSL/L7/Evening-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Friday","","https://bob64.vrsignlanguage.net/BSL/L7/Friday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hours","1","https://bob64.vrsignlanguage.net/BSL/L7/Hours-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Hours","2","https://bob64.vrsignlanguage.net/BSL/L7/Hours-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Later","","https://bob64.vrsignlanguage.net/BSL/L7/Later.mp4","Sheezy93","","","3","","","0"},
new string[]{"Late afternoon","","https://bob64.vrsignlanguage.net/BSL/L7/Lateafternoon.mp4","Sheezy93","","","3","","","0"},
new string[]{"Midweek","","https://bob64.vrsignlanguage.net/BSL/L7/Midweek.mp4","Sheezy93","","","3","","","0"},
new string[]{"Minutes","","https://bob64.vrsignlanguage.net/BSL/L7/Minutes.mp4","Sheezy93","","","3","","","0"},
new string[]{"Monday","","https://bob64.vrsignlanguage.net/BSL/L7/Monday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Month","","https://bob64.vrsignlanguage.net/BSL/L7/Month.mp4","Sheezy93","","","3","","","0"},
new string[]{"Morning","","https://bob64.vrsignlanguage.net/BSL/L7/Morning.mp4","Sheezy93","","","3","","","0"},
new string[]{"Never","","https://bob64.vrsignlanguage.net/BSL/L7/Never.mp4","Sheezy93","","","3","","","0"},
new string[]{"Next week","","https://bob64.vrsignlanguage.net/BSL/L7/Nextweek.mp4","Sheezy93","","","3","","","0"},
new string[]{"Night","","https://bob64.vrsignlanguage.net/BSL/L7/Night.mp4","Sheezy93","","","3","","","0"},
new string[]{"Now","","https://bob64.vrsignlanguage.net/BSL/L7/Now.mp4","Sheezy93","","","3","","","0"},
new string[]{"Saturday","","https://bob64.vrsignlanguage.net/BSL/L7/Saturday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Season","","https://bob64.vrsignlanguage.net/BSL/L7/Season.mp4","Sheezy93","","","3","","","0"},
new string[]{"Seconds","","https://bob64.vrsignlanguage.net/BSL/L7/Seconds.mp4","Sheezy93","","","3","","","0"},
new string[]{"Soon","","https://bob64.vrsignlanguage.net/BSL/L7/Soon.mp4","Sheezy93","","","3","","","0"},
new string[]{"Spring","","https://bob64.vrsignlanguage.net/BSL/L7/Spring.mp4","Sheezy93","","","3","","","0"},
new string[]{"Summer","","https://bob64.vrsignlanguage.net/BSL/L7/Summer.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sunday","","https://bob64.vrsignlanguage.net/BSL/L7/Sunday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sunrise","","https://bob64.vrsignlanguage.net/BSL/L7/Sunrise.mp4","Sheezy93","","","3","","","0"},
new string[]{"Sunset","","https://bob64.vrsignlanguage.net/BSL/L7/Sunset.mp4","Sheezy93","","","3","","","0"},
new string[]{"Thursday","","https://bob64.vrsignlanguage.net/BSL/L7/Thursday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Time","","https://bob64.vrsignlanguage.net/BSL/L7/Time.mp4","Sheezy93","","","3","","","0"},
new string[]{"Today","","https://bob64.vrsignlanguage.net/BSL/L7/Today.mp4","Sheezy93","","","3","","","0"},
new string[]{"Tomorrow","","https://bob64.vrsignlanguage.net/BSL/L7/Tomorrow.mp4","Sheezy93","","","3","","","0"},
new string[]{"Tuesday","","https://bob64.vrsignlanguage.net/BSL/L7/Tuesday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Wednesday","","https://bob64.vrsignlanguage.net/BSL/L7/Wednesday.mp4","Sheezy93","","","3","","","0"},
new string[]{"Weekend","","https://bob64.vrsignlanguage.net/BSL/L7/Weekend.mp4","Sheezy93","","","3","","","0"},
new string[]{"Week","1","https://bob64.vrsignlanguage.net/BSL/L7/Week-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Week","2","https://bob64.vrsignlanguage.net/BSL/L7/Week-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Winter","","https://bob64.vrsignlanguage.net/BSL/L7/Winter.mp4","Sheezy93","","","3","","","0"},
new string[]{"Year","","https://bob64.vrsignlanguage.net/BSL/L7/Year.mp4","Sheezy93","","","3","","","0"},
new string[]{"Yesterday","","https://bob64.vrsignlanguage.net/BSL/L7/Yesterday.mp4","Sheezy93","","","3","","","0"},
},//end of lesson
new string[][]{//BSL Lesson 8 - VRChat
new string[]{"Add friend","1","https://bob64.vrsignlanguage.net/BSL/L8/Addfriend-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Add friend","2","https://bob64.vrsignlanguage.net/BSL/L8/Addfriend-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Avatar","","https://bob64.vrsignlanguage.net/BSL/L8/Avatar.mp4","Sheezy93","","","3","","","0"},
new string[]{"Block","","https://bob64.vrsignlanguage.net/BSL/L8/Block.mp4","Sheezy93","","","3","","","0"},
new string[]{"Camera","1","https://bob64.vrsignlanguage.net/BSL/L8/Camera-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Camera","2","https://bob64.vrsignlanguage.net/BSL/L8/Camera-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Cancel","","https://bob64.vrsignlanguage.net/BSL/L8/Cancel.mp4","Sheezy93","","","3","","","0"},
new string[]{"Climbing","","https://bob64.vrsignlanguage.net/BSL/L8/Climbing.mp4","Sheezy93","","","3","","","0"},
new string[]{"Computer","","https://bob64.vrsignlanguage.net/BSL/L8/Computer.mp4","Sheezy93","","","3","","","0"},
new string[]{"Crash","","https://bob64.vrsignlanguage.net/BSL/L8/Crash.mp4","Sheezy93","","","3","","","0"},
new string[]{"Desktop","1","https://bob64.vrsignlanguage.net/BSL/L8/Desktop-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Desktop","2","https://bob64.vrsignlanguage.net/BSL/L8/Desktop-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Discord","","https://bob64.vrsignlanguage.net/BSL/L8/Discord.mp4","Sheezy93","","","3","","","0"},
new string[]{"Donation","1","https://bob64.vrsignlanguage.net/BSL/L8/Donation-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Donation","2","https://bob64.vrsignlanguage.net/BSL/L8/Donation-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Event","","https://bob64.vrsignlanguage.net/BSL/L8/Event.mp4","Sheezy93","","","3","","","0"},
new string[]{"Falling","","https://bob64.vrsignlanguage.net/BSL/L8/Falling.mp4","Sheezy93","","","3","","","0"},
new string[]{"Gestures","","https://bob64.vrsignlanguage.net/BSL/L8/Gestures.mp4","Sheezy93","","","3","","","0"},
new string[]{"Headset (VR)","","https://bob64.vrsignlanguage.net/BSL/L8/Headset(VR).mp4","Sheezy93","","","3","","","0"},
new string[]{"Hide","","https://bob64.vrsignlanguage.net/BSL/L8/Hide.mp4","Sheezy93","","","3","","","0"},
new string[]{"Invite","","https://bob64.vrsignlanguage.net/BSL/L8/Invite.mp4","Sheezy93","","","3","","","0"},
new string[]{"Join","1","https://bob64.vrsignlanguage.net/BSL/L8/Join-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Join","2","https://bob64.vrsignlanguage.net/BSL/L8/Join-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Lagging","1","https://bob64.vrsignlanguage.net/BSL/L8/Lagging-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Lagging","2","https://bob64.vrsignlanguage.net/BSL/L8/Lagging-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Leave","1","https://bob64.vrsignlanguage.net/BSL/L8/Leave-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Leave","2","https://bob64.vrsignlanguage.net/BSL/L8/Leave-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Login","1","https://bob64.vrsignlanguage.net/BSL/L8/Login-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Login","2","https://bob64.vrsignlanguage.net/BSL/L8/Login-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Logout","","https://bob64.vrsignlanguage.net/BSL/L8/Logout.mp4","Sheezy93","","","3","","","0"},
new string[]{"Menu","","https://bob64.vrsignlanguage.net/BSL/L8/Menu.mp4","Sheezy93","","","3","","","0"},
new string[]{"Offline","","https://bob64.vrsignlanguage.net/BSL/L8/Offline.mp4","Sheezy93","","","3","","","0"},
new string[]{"Online","","https://bob64.vrsignlanguage.net/BSL/L8/Online.mp4","Sheezy93","","","3","","","0"},
new string[]{"Photo","1","https://bob64.vrsignlanguage.net/BSL/L8/Photo-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Photo","2","https://bob64.vrsignlanguage.net/BSL/L8/Photo-v2.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Portal","","https://bob64.vrsignlanguage.net/BSL/L8/Portal.mp4","Sheezy93","","","3","","","0"},
new string[]{"Private","","https://bob64.vrsignlanguage.net/BSL/L8/Private.mp4","Sheezy93","","","3","","","0"},
new string[]{"Public","","https://bob64.vrsignlanguage.net/BSL/L8/Public.mp4","Sheezy93","","","3","","","0"},
new string[]{"Receive","1","https://bob64.vrsignlanguage.net/BSL/L8/Receive-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Receive","2","https://bob64.vrsignlanguage.net/BSL/L8/Receive-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Recharge","","https://bob64.vrsignlanguage.net/BSL/L8/Recharge.mp4","Sheezy93","","","3","","","0"},
new string[]{"Record","","https://bob64.vrsignlanguage.net/BSL/L8/Record.mp4","Sheezy93","","","3","","","0"},
new string[]{"Restart","","https://bob64.vrsignlanguage.net/BSL/L8/Restart.mp4","Sheezy93","","","3","","","0"},
new string[]{"Schedule","","https://bob64.vrsignlanguage.net/BSL/L8/Schedule.mp4","Sheezy93","","","3","","","0"},
new string[]{"Security","","https://bob64.vrsignlanguage.net/BSL/L8/Security.mp4","Sheezy93","","","3","","","0"},
new string[]{"Send","","https://bob64.vrsignlanguage.net/BSL/L8/Send.mp4","Sheezy93","","","3","","","0"},
new string[]{"Streaming","","https://bob64.vrsignlanguage.net/BSL/L8/Streaming.mp4","Sheezy93","","","3","","","0"},
new string[]{"Visit","1","https://bob64.vrsignlanguage.net/BSL/L8/Visit-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Visit","2","https://bob64.vrsignlanguage.net/BSL/L8/Visit-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Walk","1","https://bob64.vrsignlanguage.net/BSL/L8/Walk-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Walk","2","https://bob64.vrsignlanguage.net/BSL/L8/Walk-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Walk","3","https://bob64.vrsignlanguage.net/BSL/L8/Walk-v3.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"Walk","4","https://bob64.vrsignlanguage.net/BSL/L8/Walk-v4.mp4","ShaWarmachine","","","3","","","0"},
new string[]{"World","","https://bob64.vrsignlanguage.net/BSL/L8/World.mp4","Sheezy93","","","3","","","0"},
},//end of lesson
new string[][]{//BSL Lesson 9 - Alphabet / Numbers
new string[]{"A","","https://bob64.vrsignlanguage.net/BSL/L9/A.mp4","Sheezy93","","","3","","","0"},
new string[]{"B","","https://bob64.vrsignlanguage.net/BSL/L9/B.mp4","Sheezy93","","","3","","","0"},
new string[]{"C","1","https://bob64.vrsignlanguage.net/BSL/L9/C-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"C","2","https://bob64.vrsignlanguage.net/BSL/L9/C-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"D","1","https://bob64.vrsignlanguage.net/BSL/L9/D-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"D","2","https://bob64.vrsignlanguage.net/BSL/L9/D-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"E","","https://bob64.vrsignlanguage.net/BSL/L9/E.mp4","Sheezy93","","","3","","","0"},
new string[]{"F","","https://bob64.vrsignlanguage.net/BSL/L9/F.mp4","Sheezy93","","","3","","","0"},
new string[]{"G","","https://bob64.vrsignlanguage.net/BSL/L9/G.mp4","Sheezy93","","","3","","","0"},
new string[]{"H","","https://bob64.vrsignlanguage.net/BSL/L9/H.mp4","Sheezy93","","","3","","","0"},
new string[]{"I","","https://bob64.vrsignlanguage.net/BSL/L9/I.mp4","Sheezy93","","","3","","","0"},
new string[]{"J","","https://bob64.vrsignlanguage.net/BSL/L9/J.mp4","Sheezy93","","","3","","","0"},
new string[]{"K","","https://bob64.vrsignlanguage.net/BSL/L9/K.mp4","Sheezy93","","","3","","","0"},
new string[]{"L","","https://bob64.vrsignlanguage.net/BSL/L9/L.mp4","Sheezy93","","","3","","","0"},
new string[]{"M","1","https://bob64.vrsignlanguage.net/BSL/L9/M-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"M","2","https://bob64.vrsignlanguage.net/BSL/L9/M-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"N","","https://bob64.vrsignlanguage.net/BSL/L9/N.mp4","Sheezy93","","","3","","","0"},
new string[]{"O","","https://bob64.vrsignlanguage.net/BSL/L9/O.mp4","Sheezy93","","","3","","","0"},
new string[]{"P","","https://bob64.vrsignlanguage.net/BSL/L9/P.mp4","Sheezy93","","","3","","","0"},
new string[]{"Q","","https://bob64.vrsignlanguage.net/BSL/L9/Q.mp4","Sheezy93","","","3","","","0"},
new string[]{"R","","https://bob64.vrsignlanguage.net/BSL/L9/R.mp4","Sheezy93","","","3","","","0"},
new string[]{"S","","https://bob64.vrsignlanguage.net/BSL/L9/S.mp4","Sheezy93","","","3","","","0"},
new string[]{"T","","https://bob64.vrsignlanguage.net/BSL/L9/T.mp4","Sheezy93","","","3","","","0"},
new string[]{"U","","https://bob64.vrsignlanguage.net/BSL/L9/U.mp4","Sheezy93","","","3","","","0"},
new string[]{"V","","https://bob64.vrsignlanguage.net/BSL/L9/V.mp4","Sheezy93","","","3","","","0"},
new string[]{"W","","https://bob64.vrsignlanguage.net/BSL/L9/W.mp4","Sheezy93","","","3","","","0"},
new string[]{"X","","https://bob64.vrsignlanguage.net/BSL/L9/X.mp4","Sheezy93","","","3","","","0"},
new string[]{"Y","","https://bob64.vrsignlanguage.net/BSL/L9/Y.mp4","Sheezy93","","","3","","","0"},
new string[]{"Z","","https://bob64.vrsignlanguage.net/BSL/L9/Z.mp4","Sheezy93","","","3","","","0"},
new string[]{"Comma","","https://bob64.vrsignlanguage.net/BSL/L9/Comma.mp4","Sheezy93","","","3","","","0"},
new string[]{"Exclamation mark","","https://bob64.vrsignlanguage.net/BSL/L9/Exclamationmark.mp4","Sheezy93","","","3","","","0"},
new string[]{"Question mark","1","https://bob64.vrsignlanguage.net/BSL/L9/Questionmark-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"Question mark","2","https://bob64.vrsignlanguage.net/BSL/L9/Questionmark-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"Space","","https://bob64.vrsignlanguage.net/BSL/L9/Space.mp4","Sheezy93","","","3","","","0"},
new string[]{"0","","https://bob64.vrsignlanguage.net/BSL/L9/0.mp4","Sheezy93","","","3","","","0"},
new string[]{"1","","https://bob64.vrsignlanguage.net/BSL/L9/1.mp4","Sheezy93","","","3","","","0"},
new string[]{"2","","https://bob64.vrsignlanguage.net/BSL/L9/2.mp4","Sheezy93","","","3","","","0"},
new string[]{"3","","https://bob64.vrsignlanguage.net/BSL/L9/3.mp4","Sheezy93","","","3","","","0"},
new string[]{"4","","https://bob64.vrsignlanguage.net/BSL/L9/4.mp4","Sheezy93","","","3","","","0"},
new string[]{"5","","https://bob64.vrsignlanguage.net/BSL/L9/5.mp4","Sheezy93","","","3","","","0"},
new string[]{"6","","https://bob64.vrsignlanguage.net/BSL/L9/6.mp4","Sheezy93","","","3","","","0"},
new string[]{"7","","https://bob64.vrsignlanguage.net/BSL/L9/7.mp4","Sheezy93","","","3","","","0"},
new string[]{"8","","https://bob64.vrsignlanguage.net/BSL/L9/8.mp4","Sheezy93","","","3","","","0"},
new string[]{"9","1","https://bob64.vrsignlanguage.net/BSL/L9/9-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"9","2","https://bob64.vrsignlanguage.net/BSL/L9/9-v2.mp4","Sheezy93","","","3","","","0"},
new string[]{"10","","https://bob64.vrsignlanguage.net/BSL/L9/10.mp4","Sheezy93","","","3","","","0"},
new string[]{"100","","https://bob64.vrsignlanguage.net/BSL/L9/100.mp4","Sheezy93","","","3","","","0"},
new string[]{"1000000","","https://bob64.vrsignlanguage.net/BSL/L9/1000000.mp4","Sheezy93","","","3","","","0"},
new string[]{"1000","1","https://bob64.vrsignlanguage.net/BSL/L9/1000-v1.mp4","Sheezy93","","","3","","","0"},
new string[]{"1000","2","https://bob64.vrsignlanguage.net/BSL/L9/1000-v2.mp4","Sheezy93","","","3","","","0"},
},//end of lesson
},//end of bsl
new string[][][]{//LSF
new string[][]{//Daily Use
new string[]{"Bonjour","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Bonjour.mp4","Hppedeaf","","","3","",""},
new string[]{"Ça Va / Comment Tu Vas","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/ÇaVaCommentTuVas.mp4","Hppedeaf","","","3","",""},
new string[]{"Tu Fais Quoi?","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/TuFaisQuoi.mp4","Hppedeaf","","","3","",""},
new string[]{"Ravi De Te Rencontrer","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/RaviDeTeRencontrer.mp4","Hppedeaf","","","3","",""},
new string[]{"Bon","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Bon.mp4","Hppedeaf","","","3","",""},
new string[]{"Mauvais","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Mauvais.mp4","Hppedeaf","","","3","",""},
new string[]{"Oui","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Oui.mp4","Hppedeaf","","","3","",""},
new string[]{"Non","1","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Non-v1.mp4","Hppedeaf","","","3","",""},
new string[]{"Non","2","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Non-v2.mp4","Hppedeaf","","","3","",""},
new string[]{"Moyen","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Moyen.mp4","Hppedeaf","","","3","",""},
new string[]{"Malade","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Malade.mp4","Hppedeaf","","","3","",""},
new string[]{"Mal","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Mal.mp4","Hppedeaf","","","3","",""},
new string[]{"De Rien","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/DeRien.mp4","Hppedeaf","","","3","",""},
new string[]{"Au Revoir","1","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/AuRevoir-v1.mp4","Hppedeaf","","","3","",""},
new string[]{"Au Revoir","2","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/AuRevoir-v2.mp4","Hppedeaf","","","3","",""},
new string[]{"Bon Après-Midi","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/BonAprès-Midi.mp4","Hppedeaf","","","3","",""},
new string[]{"Bonsoir","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Bonsoir.mp4","Hppedeaf","","","3","",""},
new string[]{"Bonne Nuit","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/BonneNuit.mp4","Hppedeaf","","","3","",""},
new string[]{"À Plus Tard","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/ÀPlusTard.mp4","Hppedeaf","","","3","",""},
new string[]{"S'il Vous Plaît","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/SilVousPlaît.mp4","Hppedeaf","","","3","",""},
new string[]{"Désolé","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Désolé.mp4","Hppedeaf","","","3","",""},
new string[]{"Oublier","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Oublier.mp4","Hppedeaf","","","3","",""},
new string[]{"Dormir","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Dormir.mp4","Hppedeaf","","","3","",""},
new string[]{"Lit","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Lit.mp4","Hppedeaf","","","3","",""},
new string[]{"Sauter / Changer De Monde","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/SauterChangerDeMonde.mp4","Hppedeaf","","","3","",""},
new string[]{"Merci","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Merci.mp4","Hppedeaf","","","3","",""},
new string[]{"Je T'aime","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/JeTaime.mp4","Hppedeaf","","","3","",""},
new string[]{"Va T'en","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/VaTen.mp4","Hppedeaf","","","3","",""},


new string[]{"Venir","1","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Venir-v1.mp4","Hppedeaf","","","3","",""},
new string[]{"Venir","2","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Venir-v2.mp4","Hppedeaf","","","3","",""},

new string[]{"Sourd","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Sourd.mp4","Hppedeaf","","","3","",""},
new string[]{"Malentendant","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Malentendant.mp4","Hppedeaf","","","3","",""},
new string[]{"Muet","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/Muet.mp4","Hppedeaf","","","3","",""},

new string[]{"Ne Peut Pas Lire","","https://bob64.vrsignlanguage.net/ShaderMotion/LSF/NePeutPasLire.mp4","Hppedeaf","","","3","",""},
},//end of lesson
},//end of lsf
};//end of array




        //GameObject [][][][] videos;
        [System.NonSerialized]
    string[][] lessonnames = { //can be unique per language, as long as they match the number of array
new string[] { //ASL lesson names - can be unique per language.
"Shadermotion Test",
"Alphabet (Fingerspelling)",
"Numbers",
"Daily Use",
"Pointing use Question / Answer",

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
"Animals",
"Machines",
"Places",
"Stuff",
"Weather",
"Clothing",
"Accessories",
"Fantasy / Characters",
"Non Manual Markers",
"Conceptual Accuracy",
"Holidays / Special Days",
"Home stuff",
"Nature / Environment",
"Talk / Asking exercises (SEE)",
"Countries",
"Colors",
"Materials",
"Medical",

},
new string[] { //BSL
"Daily Use",
"Pointing use Question / Answer",
"Common",
"People",
"Feelings / Reactions",
"Value",
"Time",
"VRChat",
"Alphabet / Numbers",
        },
        new string[] {
            "Usage quotidien"
        },
    };
    [System.NonSerialized]
        string[][] signlanguagenames = {
new string[] {"ASL","American Sign Language","Y"},
new string[] {"BSL","British Sign Language","N"},

new string[] {"LSF","French Sign Language","Y"},
};

        //Avatar Objects/Variables
        Toggle handtoggle;
    GameObject signingavatars;
        GameObject[] nanaavatars = new GameObject[4];
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
        GameObject[] videoicons = new GameObject[70];
        GameObject[] shadermotionicons = new GameObject[70];
        TextMeshProUGUI[] buttontext = new TextMeshProUGUI[70];
    int numofbuttons = 70;
    GameObject[] backbuttons = new GameObject[2];
    GameObject nextButton;
    GameObject prevButton;
        private GameObject lockedicon;
        private GameObject unlockedicon;

        //int currentboard = 0; // current page
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
        private GameObject quizp;
        private GameObject quiza;
        private GameObject quizb;
        private GameObject quizc;
        private GameObject quizd;
        private GameObject quizbig;
        private GameObject quizreset;
        private TextMeshProUGUI quiztext;
        private TextMeshProUGUI quiztext2;
        private TextMeshProUGUI quiztext3;
        private bool[][] quizlessonselection; //stores which lessons are selected.
        private int[][] quizwordmapping;//points to the mainarray [lang]
        private bool[][][] quizwordselection;
        private bool quizinprogress = false;
        private int numofwordsselected = 0;
        private int quizcounter = 0;
        private int quizscore = 0;
        private int quizanswer = 0;

        // Preference Menu Objects/Variables - Avatar/Visual Controls
        private Slider avatarscaleslider;
        private Slider videospeedslider;
        private Toggle HandToggle;

        // Preference Menu Objects/Variables - Global/Local Mode
        private Toggle GlobalToggle;
        private bool globalmode;
        private Toggle ColorToggle;
        //        private TMP_Dropdown ColorDropdown;

        // Preference Menu Objects/Variables - Lookup/Quiz Mode
        Toggle QuizToggle;
    private const int MODE_LOOKUP = 0;
    private const int MODE_QUIZ = 1;
    private int currentmode; // Tracks current mode (Lookup, Quiz, etc.)
    [UdonSynced] int globalcurrentmode;

        // Preference Menu Objects/Variables - Dark Mode
        private Toggle DarkToggle;
        private bool darkmode;
        private ColorBlock verifieddark = new ColorBlock();
        private Color black = Color.black;
        private Color white = Color.white;
        private Color gray = Color.gray;
        private Color lightgray = new Color(.25f, .25f, .25f, 1);
        private TextMeshPro[] worldtext;
        private Image[] worldpanels;
        private Button[] worldbuttons; //every button except the 70 menu button array
        private Image[] worldcheckboxes;
        private ColorBlock darkmodebutton;
        private ColorBlock darkmodeselectedbutton;

        // General Constants
        private const int NOT_SELECTED = -1;
        private const int MENU_LANGUAGE = 0;
        private const int MENU_LESSON = 1;
        private const int MENU_WORD = 2;

        private const int FORWARDS = 1;
        private const int BACKWARDS = -1;
        private int direction = FORWARDS;

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

        Color COLORBLIND_BLUE = new Color32(109, 158, 235, 255);
        Color COLORBLIND_RED = new Color32(235, 36, 6, 255);
        Color COLORBLIND_GREEN = new Color32(191, 235, 66, 255);
        Color COLORBLIND_PURPLE = new Color32(179, 36, 240, 255);

        Color standardtextcolor;
        Color verified;
        Color pending;
        Color failed;
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
            _InitializeTextColors(false);

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
        Gets called when the preference menu changes, sends value of dropdown to helper function - workaround for not having parameters in functions.
        ***************************************************************************************************************************/
        public void _UpdateColorSettings()
        {
            Debug.Log("_UpdateColorSettings Called");
            _InitializeTextColors(ColorToggle.isOn);
        }


            /***************************************************************************************************************************
            Initialize Variables related to Text coloring. Also handles colorblind text.
            ***************************************************************************************************************************/
            private void _InitializeTextColors(bool mode)
        {
            Debug.Log("_InitializeTextColors Called with mode: " + mode);
            switch (mode)
            {
                case false: //default
                    standardtextcolor = COLOR_WHITE;
                    verified = COLOR_GREEN;
                    pending = COLOR_YELLOW;
                    failed = COLOR_RED;
                    break;
                case true:
                    standardtextcolor = COLOR_WHITE;
                    verified = COLORBLIND_GREEN;
                    pending = COLORBLIND_BLUE;
                    failed = COLORBLIND_RED;
                    break;
                default: //0 option
                    standardtextcolor = COLOR_WHITE;
                    verified = COLOR_GREEN;
                    pending = COLOR_YELLOW;
                    failed = COLOR_RED;
                    break;
            }

            _UpdateTextHelper();
        }
/***************************************************************************************************************************
Update the color on legend to match.
***************************************************************************************************************************/
        private void _UpdateTextHelper()
        {
            //Debug.Log(FloatNormalizedToHex(1f));
            //Debug.Log(DecToHex(255));
            GameObject.Find("/Legend/Legend Canvas/Color Text").GetComponent<TextMeshProUGUI>().text =
                "<color=#"+ GetStringFromColor(failed) + ">Red<color=#" + GetStringFromColor(standardtextcolor) + "> = Video Failed Verification\n" +
                "<color=#" + GetStringFromColor(pending) + ">Yellow<color=#" + GetStringFromColor(standardtextcolor) + "> = Video Pending Verification\n" +
                "<color=#" + GetStringFromColor(verified) + ">Green <color=#" + GetStringFromColor(standardtextcolor) + "> = Video Passed Verification";
            /*
            Debug.Log(GetStringFromColor(standardtextcolor));
            Debug.Log(GetStringFromColor(verified));
            Debug.Log(GetStringFromColor(pending));
            Debug.Log(GetStringFromColor(failed));*/
        }
        /***************************************************************************************************************************
helperfunction since colorutility.tohtmlstringrgb isn't in udon. urgh.
***************************************************************************************************************************/
        private string GetStringFromColor(Color color)
        {
            FloatNormalizedToHex(color.r);
            string red = FloatNormalizedToHex(color.r);

            string green = FloatNormalizedToHex(color.g);
            string blue = FloatNormalizedToHex(color.b);
            /*Debug.Log("red:"+ color.r+" normalized " + red);
            Debug.Log("green:"+color.g+" normalized " +green);
            Debug.Log("blue:" +color.b+" normalized " + blue);*/
            return red + green + blue;
        }

/***************************************************************************************************************************
helperfunction since colorutility.tohtmlstringrgb isn't in udon. urgh.
***************************************************************************************************************************/
        private string FloatNormalizedToHex(float value)
        {
            //Debug.Log("floatnormnalizedtohext:" + Mathf.RoundToInt(value * 255f));
            return DecToHex(Mathf.RoundToInt(value * 255f));
        }
        /***************************************************************************************************************************
        helperfunction since colorutility.tohtmlstringrgb isn't in udon. urgh.
        ***************************************************************************************************************************/
        private string DecToHex(int value)
        {
            return value.ToString("X2");//x2=hex with 2 digits
        }


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
            ColorToggle = GameObject.Find("/Preferencesv2/Canvas/Mode Panel/Color Toggle").GetComponent<Toggle>();
            //ColorDropdown = GameObject.Find("/Preferencesv2/Canvas/Mode Panel/Color/Dropdown").GetComponent<TMP_Dropdown>();
        }

    /***************************************************************************************************************************
	Initialize Variables related to the MoCap Avatar (Nana)
	***************************************************************************************************************************/
    private void _InitializeSigningAvatar()
    {

        signingavatars = GameObject.Find("/Signing Avatars");
            nanaavatars[0] = signingavatars.transform.Find("Nana Avatar (SM)").gameObject;
            nanaavatars[1] = signingavatars.transform.Find("Nana Avatar (SM) (1)").gameObject;
            nanaavatars[2] = signingavatars.transform.Find("Nana Avatar (SM) (2)").gameObject;
            nanaavatars[3] = signingavatars.transform.Find("Nana Avatar (SM) (3)").gameObject;



            var propBlock = new MaterialPropertyBlock();
            propBlock.SetFloat("_Layer", 0);
            nanaavatars[0].GetComponent<MeshRenderer>().SetPropertyBlock(propBlock);

            propBlock.SetFloat("_Layer", 1);
            nanaavatars[1].GetComponent<MeshRenderer>().SetPropertyBlock(propBlock);

            propBlock.SetFloat("_Layer", 2);
            nanaavatars[2].GetComponent<MeshRenderer>().SetPropertyBlock(propBlock);

            propBlock.SetFloat("_Layer", 3);
            nanaavatars[3].GetComponent<MeshRenderer>().SetPropertyBlock(propBlock);
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

            lockedicon= GameObject.Find("/Udon Menu System/Root Canvas/LockToggle/LockToggle/Icons/LockedIcon");
            unlockedicon = GameObject.Find("/Udon Menu System/Root Canvas/LockToggle/LockToggle/Icons/UnlockedIcon");
            lockedicon.SetActive(false);

            for (int x = 0; x < numofbuttons; x++)
            {
                buttons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x));
                buttontext[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Text").GetComponent<TextMeshProUGUI>();
                indexicons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Index VR Icon");
                regvricons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Regular VR Icon");
                bothvricons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Both VR Icon");
                videoicons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Video Icon");
                shadermotionicons[x] = GameObject.Find("/Udon Menu System/Root Canvas/Menu Buttons/Button " + (x) + "/Shadermotion Icon");
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
            if (debug)
            {
                Debug.Log("Entered _UpdateSigningAvatarState");
            }

        bool isActive = !(currentmode == MODE_QUIZ);
        nextButton.SetActive(isActive);
        prevButton.SetActive(isActive);
        currentsign.SetActive(isActive);
        signcredit.SetActive(isActive);
        description.SetActive(isActive);
    }

    /***************************************************************************************************************************
	Update Menu Variables used to control displays. This should only be called from button-pushes if globalmode is activated, since it takes ownership + pushes a resync.
	***************************************************************************************************************************/
    private void _UpdateMenuVariables(int buttonIndex)
    {
            if (debug)
            {
                Debug.Log("Entered _UpdateMenuVariables with direction:" + direction);
            }

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
            if (debug)
            {
                Debug.Log("Entered _UpdateAllDisplays");
            }
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
            if (debug)
            {
                Debug.Log("Entered _DisplayLanguageSelectMenu");
            }
            // Handle Menu Header (Breadcrumb)
            menuheadertext.text = "VR Sign Language Select Menu";

        // Handle Selection Buttons
        for (int i = 0; i < numofbuttons; i++)
        {
            if (i < signlanguagenames.Length)
            {
                _DisplayButton(i, "     " + (i + 1) + ") " + signlanguagenames[i][1], false, false, "");
                    _DisplayVideoOrShadermotionIcon(i);
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
            if (debug)
            {
                Debug.Log("Entered _DisplayLessonSelectMenu");
            }
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
                    _DisplayButton(i, "" + (i + 1) + ") " + lessonnames[currentlang][i], isButtonSelected, false, "");
                    _HideIcons(i);
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
            if (debug)
            {
                Debug.Log("Entered _DisplayWordSelectMenu");
            }
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
                if (AllLessons[currentlang][currentlesson][i][arrayvariant] != "")
                {
                    variant = " (Variant " + AllLessons[currentlang][currentlesson][i][arrayvariant] +")";
                }
                buttonText = "     " + (i + 1) + ") " + AllLessons[currentlang][currentlesson][i][arrayword] +variant;
                isButtonSelected = currentword == i; //if the currentword is i, then assign true to isbuttonselected

                _DisplayButton(i, buttonText, isButtonSelected, true, AllLessons[currentlang][currentlesson][i][arrayvalidation]);
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

            switch (AllLessons[currentlang][currentlesson][index][arrayvricon])
            { //populate vr icons
                case "I": // Knuckles Controller icon
                    indexicons[index].SetActive(true);
                    regvricons[index].SetActive(false);
                    bothvricons[index].SetActive(false);
                    videoicons[index].SetActive(false);
                    shadermotionicons[index].SetActive(false);
                    break;
                case "G": // Standard VR Controller icon
                    indexicons[index].SetActive(false);
                    regvricons[index].SetActive(true);
                    bothvricons[index].SetActive(false);
                    videoicons[index].SetActive(false);
                    shadermotionicons[index].SetActive(false);
                break;
                case "B": // Both Controller Types icon
                    indexicons[index].SetActive(false);
                    regvricons[index].SetActive(false);
                    bothvricons[index].SetActive(true);
                    videoicons[index].SetActive(false);
                    shadermotionicons[index].SetActive(false);
                    break;
                default: //uhh how am I here? Is it null somehow? Maybe should set to both by default...
                    //Debug.Log("_DisplayVRIcon(" + index + ") had an invalid VR Icon setting; update AllLessons[currentlang][currentlesson][index][4]");
                    indexicons[index].SetActive(false);
                    regvricons[index].SetActive(false);
                    bothvricons[index].SetActive(false);
                    videoicons[index].SetActive(false);
                    shadermotionicons[index].SetActive(false);
                    break;
            }
        }


        /***************************************************************************************************************************
        Display the Shadermotion or Video icon for the given Button/Word Index.
        ***************************************************************************************************************************/
        private void _DisplayVideoOrShadermotionIcon(int index)
        {

            switch (signlanguagenames[index][2])
            { //populate vr icons
                case "Y": // Shadermotion  icon
                    indexicons[index].SetActive(false);
                    regvricons[index].SetActive(false);
                    bothvricons[index].SetActive(false);
                    videoicons[index].SetActive(true);
                    shadermotionicons[index].SetActive(true);
                    break;

            case "N": // Video icon
                indexicons[index].SetActive(false);
                regvricons[index].SetActive(false);
                bothvricons[index].SetActive(false);
                videoicons[index].SetActive(true);
                shadermotionicons[index].SetActive(false);
                break;

                default: //uhh how am I here? Is it null somehow? Maybe should set to both by default...
                    //Debug.Log("_DisplayVRIcon(" + index + ") had an invalid VR Icon setting; update AllLessons[currentlang][currentlesson][index][4]");
                    indexicons[index].SetActive(false);
                    regvricons[index].SetActive(false);
                    bothvricons[index].SetActive(false);
                    videoicons[index].SetActive(false);
                    shadermotionicons[index].SetActive(false);
                    break;
            }
        }

        /***************************************************************************************************************************
        Hide the display for a VR icon at a specific index.
        ***************************************************************************************************************************/
        private void _HideIcons(int index)
        {
            indexicons[index].SetActive(false);
            regvricons[index].SetActive(false);
            bothvricons[index].SetActive(false);
            videoicons[index].SetActive(false);
            shadermotionicons[index].SetActive(false);
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
                    buttontext[index].color = failed;
                    break;
                case "2":
                    buttontext[index].color = pending;
                    break;
                case "3":
                    buttontext[index].color = verified;
                    break;
                default:
                    break;
            }

        }
        else
        {
            buttontext[index].color = standardtextcolor; // Standard
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
            if (AllLessons[currentlang][currentlesson][currentword][arrayvariant] != "")
            {
                variant = " (Variant " + AllLessons[currentlang][currentlesson][currentword][arrayvariant] +")";
            }

            // Update MoCap Avatar Visuals (Nana)
            currentsigntext.text = (currentlesson + 1) + "-" + (currentword + 1) + ") " + AllLessons[currentlang][currentlesson][currentword][arrayword] + variant;
            speechbubbletext.text = AllLessons[currentlang][currentlesson][currentword][arrayword];

            signcredittext.text = "The motion data for this sign was signed by: " + AllLessons[currentlang][currentlesson][currentword][arraycredit];
            descriptiontext.text = AllLessons[currentlang][currentlesson][currentword][arraysigndescription];
                if ((AllLessons[currentlang][currentlesson][currentword].Length-1) >= arraynumofavatars)//don't break if i forgot to add the numofavatars to the array for other languages
                {
                    //Debug.Log("length of array:"+ AllLessons[currentlang][currentlesson][currentword].Length);
                    switch (AllLessons[currentlang][currentlesson][currentword][arraynumofavatars])
                    {
                        case "0":
                            nanaavatars[0].SetActive(false);
                            nanaavatars[1].SetActive(false);
                            nanaavatars[2].SetActive(false);
                            nanaavatars[3].SetActive(false);
                            break;
                        case "1":
                            nanaavatars[0].SetActive(true);
                            nanaavatars[1].SetActive(false);
                            nanaavatars[2].SetActive(false);
                            nanaavatars[3].SetActive(false);
                            break;
                        case "2":
                            nanaavatars[0].SetActive(true);
                            nanaavatars[1].SetActive(true);
                            nanaavatars[2].SetActive(false);
                            nanaavatars[3].SetActive(false);
                            break;
                        case "3":
                            nanaavatars[0].SetActive(true);
                            nanaavatars[1].SetActive(true);
                            nanaavatars[2].SetActive(true);
                            nanaavatars[3].SetActive(false);
                            break;
                        case "4":
                            nanaavatars[0].SetActive(true);
                            nanaavatars[1].SetActive(true);
                            nanaavatars[2].SetActive(true);
                            nanaavatars[3].SetActive(true);
                            break;
                        default:
                            nanaavatars[0].SetActive(true);
                            nanaavatars[1].SetActive(false);
                            nanaavatars[2].SetActive(false);
                            nanaavatars[3].SetActive(false);
                            break;
                    }
                }

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
            if (AllLessons[currentlang][currentlesson][currentword][arrayurl] != "")
            { // if url is blank, then don't look for the video
                if (langurls.Length > 0)
                { //don't crash the script if i forget to build langurls lol...
                        //Debug.Log(langurls[currentlang][currentlesson][currentword]);
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
        //Debug.Log("Entered _PreviousNextWordButtonPushed");
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
            if (!locked)
            {
                //Debug.Log("Entered _BackButtonPushed");
                if (globalmode)
                {
                    //SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ChangeState");
                }
                direction = BACKWARDS;
                _UpdateMenuVariables(NOT_SELECTED);
                _UpdateAllDisplays();
            }
    }

    /***************************************************************************************************************************
	Figures out if the button pushed is the correct one. Displays corrisponding status screen if correct, or try again.
	***************************************************************************************************************************/
    public void _QuizResetButtonPushed()
    {
        //Debug.Log("Entered _QuizResetButtonPushed");
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
        //Debug.Log("Entered _QuizAnswerButtonPushed with x:" + x);
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

                quizbig.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Incorrect - the correct answer was: " + AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] + "\n✗\nClick to continue";
            }
            else
            {
                quizbig.SetActive(false);
                quizp.transform.Find("Text3 (TMP)").gameObject.SetActive(true);
                quiztext.text = "Quiz Finished. Progress: " + (quizcounter + 1) + " of " + numofwordsselected;
                quiztext2.text = "Final Score: " + quizscore + " Percent Correct:" + (int)(((decimal)quizscore / (decimal)numofwordsselected) * 100) + "%";
                quiztext3.text = "Incorrect - the correct answer was: " + AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] + "\n✗\nYou've reached the end of the quiz.\nYou can now change selected lessons and regenerate the quiz by pushing the reset quiz button.";
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
                        //AllLessons[lang][lesson][word][arrayvalidation] == "3" && //and if the sign is validated
                        AllLessons[lang][lesson][word][arrayurl] != "") // and if the video url exists
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
                            //AllLessons[lang][lesson][word][arrayvalidation] == "3" && //and if the sign is validated
                            AllLessons[lang][lesson][word][arrayurl] != "") // and if the video url exists
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


                // Pick one of the answers to be correct
                quizanswer = UnityEngine.Random.Range(0, 4);//pick one of the 4 boxes to have the answer 0-3
                int quizwrong1 = UnityEngine.Random.Range(0, quizwordmapping.Length);
                int quizwrong2 = UnityEngine.Random.Range(0, quizwordmapping.Length);
                int quizwrong3 = UnityEngine.Random.Range(0, quizwordmapping.Length);
                
                //prevent the same answer on multiple boxes.
                while (
                    AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword].Contains("/") |
                    AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] //Don't be the same baseword as the answer.
                    )
                {
                    quizwrong1 = UnityEngine.Random.Range(0, quizwordmapping.Length);

                }

                while (
                    AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword].Contains("/") |
                    AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] | //Don't be the same baseword as the answer.
                    AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword] == AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword] //Don't be the same baseword as the quizwrong1.
                    )
                {
                    quizwrong2 = UnityEngine.Random.Range(0, quizwordmapping.Length);
                }

                while (

                    AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword].Contains("/") |
                    AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] | //Don't be the same baseword as the answer.
                    AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword] == AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword] | //Don't be the same baseword as the quizwrong1.
                    AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword] == AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword]   //Don't be the same baseword as the quizwrong2.
                    )
                {
                    quizwrong3 = UnityEngine.Random.Range(0, quizwordmapping.Length);
                }
                Debug.Log("quizwrong3# " + quizwrong3 + " " + AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword]);
                switch (quizanswer)//quizanswer is the box the answer is in. The answer is stored in quizcounter.
                {
                    case 0:
                        quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword];
                        quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword];
                        quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword];
                        quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword];
                        break;
                    case 1:
                        quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword];
                        quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword];
                        quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword];
                        quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword];
                        break;
                    case 2:
                        quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword];
                        quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword];
                        quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword];
                        quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword];
                        break;
                    case 3:
                        quizd.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword];
                        quiza.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword];
                        quizb.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword];
                        quizc.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword];
                        break;
                    default:
                        //Debug.Log("How is quizanswer outside of the expected random range?");
                        break;
                }
                //nana.Play(AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][1]);
                //add something to hide the sidebar of videos here?

                if (AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayurl] != "")
                { // if url is blank, then don't look for the video
                    if (langurls.Length > 0)
                    { //don't crash the script if i forget to build langurls lol...
                        videoplayer._LoadURL(langurls[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]]);
                    }
                    else
                    {
                        Debug.Log("[Quiz] langurls empty, video not loaded");
                    }
                }
                else
                {
                    Debug.Log("[Quiz] URL was blank, video not loaded");
                }


            }

        }


        /***************************************************************************************************************************
        Figures out what the button does, and sends to the approperate functions to update the menu.
        ***************************************************************************************************************************/
        private void _buttonpushed(int buttonIndex)
    {
            //Debug.Log("Entered _buttonpushed(" + buttonIndex + ")");
            if (!locked)
            {
                // Update Data
                _UpdateMenuVariables(buttonIndex);

                // Update Display
                _UpdateAllDisplays();
            }

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
        //Debug.Log("Now entering _SelectQuizLesson with a language number of " + currentlang + " and a button number of x:" + x);
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
    public void _AvatarScaleSliderValueChanged()
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
    public void _ToggleHand()
    {
        if (HandToggle.isOn)
        {
                nanaavatars[0].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(1, 1, 1));
                nanaavatars[1].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(1, 1, 1));
                nanaavatars[2].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(1, 1, 1));
                nanaavatars[3].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(1, 1, 1));
            }
        else
        {
                nanaavatars[0].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(-1, 1, 1));
                nanaavatars[1].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(-1, 1, 1));
                nanaavatars[2].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(-1, 1, 1));
                nanaavatars[3].transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(-1, 1, 1));
            }


    }

        /***************************************************************************************************************************
        Called to lock board to prevent errant inputs when holding pens. 
        ***************************************************************************************************************************/
        public void _ToggleLock()
        {
            locked = !locked;
            lockedicon.SetActive(locked);
            unlockedicon.SetActive(!locked);

        }


        /***************************************************************************************************************************
        Called to switch the board to global mode and set the toggle box state
        ***************************************************************************************************************************/
        public void _ToggleGlobal()
    {
        globalmode = !globalmode;
            //_UpdateMenuVariables(NOT_SELECTED);
            _GlobalModeVarSync();
        _UpdateAllDisplays();
    }


    /***************************************************************************************************************************
	Called to switch the board to quiz mode
	Handles enabling/disabling ui elements
	***************************************************************************************************************************/
    public void _ToggleQuiz()
    {
        //Debug.Log("Entered ToggleQuiz with quizmode: " + (currentmode == MODE_QUIZ));
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
    #region Button Handlers
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
        #endregion

        /***************************************************************************************************************************
        Override the Inspector to populate VRC Urls and Generate a dictionary of signs/words
        ***************************************************************************************************************************/

#if !COMPILER_UDONSHARP && UNITY_EDITOR

        internal void __UpdateURLs()
        {
            // Generate VRCUrls
            langurls = AllLessons.Select(
                language => language.Select(
                    lesson => lesson.Select(
                        word => new VRCUrl(word[arrayurl])
                    ).ToArray()
                ).ToArray()
            ).ToArray();
            Debug.Log("URLs populated");

            // Format dictionary text
            string dictionaryText = string.Join("\n",
                AllLessons[0].SelectMany(
                    (lesson, lesson_index) => lesson.Select(
                        // Tuple of word & its location on the board
                        (word, word_index) => (word[arrayword], $"L{lesson_index + 1}-{word_index + 1}")
                    )
                // Sort by word and then combine
                ).OrderBy(pair => pair.Item1).Select(pair => $"{pair.Item1} {pair.Item2}")
            );

            // Format errata text
            string errataText = string.Join("",
                AllLessons[0].Select(
                    (lesson, lesson_index) =>
                        // Lesson header
                        $"<b>Lesson {lesson_index + 1} - {lessonnames[0][lesson_index]}</b>\n"
                        // & comments when they exist
                        + string.Join("", lesson.Select(
                            // Null if no array validation comment
                            (word, word_index) => word[arrayvalidationcomment] != "" ? $"\nL{lesson_index + 1}-{word_index + 1} [{word[arrayword]}]: {word[arrayvalidationcomment]}\n" : null
                        // Filter to only existing comments
                        ).Where(word => word != null))
                )
            );

            FindInActiveObjectByName("DictionaryText").GetOrAddComponent<TextMeshProUGUI>().text = dictionaryText;
            Debug.Log("Index Populated");

            FindInActiveObjectByName("ErrataText").GetOrAddComponent<TextMeshProUGUI>().text = errataText;
            Debug.Log("Errata populated");
            //todo, if parameters are supported by buttons. Instantiate buttons instead of text, to allow jumping direct to a specific word.
        }

        [CustomEditor(typeof(MenuControl))]
        public class CustomInspectorEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;
                MenuControl inspectorBehaviour = (MenuControl)target;

                if (GUILayout.Button("Force populate VRCUrls"))
                {
                    inspectorBehaviour.__UpdateURLs();
                }

                if (GUILayout.Button("Clear langurls"))
                {
                    inspectorBehaviour.langurls = new VRCUrl[][][] { };
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

#if !COMPILER_UDONSHARP && UNITY_EDITOR
    [InitializeOnLoad]
    internal class MenuControlHooks
    {
        static MenuControlHooks()
        {
            EditorApplication.playModeStateChanged += OnChangePlayMode;
        }

        // Hook for Play mode
        static void OnChangePlayMode(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                Debug.Log("Trying to update VRCUrls (Play mode)...");

                // Get the scene object
                var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

                foreach (var root in roots)
                {
                    foreach (var menuControl in root.GetUdonSharpComponentsInChildren<MenuControl>())
                    {
                        Debug.Log("Updating VRCUrls on MenuControl", menuControl);
                        menuControl.__UpdateURLs();
                        menuControl.ApplyProxyModifications();
                    }
                }
            }
        }

        // Hook for Build & Test / Build & Upload
        public class UpdateMenuControlOnWorldBuild : IVRCSDKBuildRequestedCallback
        {
            public int callbackOrder => 100;

            bool IVRCSDKBuildRequestedCallback.OnBuildRequested(VRCSDKRequestedBuildType requestedBuildType)
            {
                if (requestedBuildType == VRCSDKRequestedBuildType.Scene)
                {
                    Debug.Log("Trying to update VRCUrls (VRCSDK Build)...");

                    // Get the scene object
                    var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

                    foreach (var root in roots)
                    {
                        foreach (var menuControl in root.GetUdonSharpComponentsInChildren<MenuControl>())
                        {
                            Debug.Log("Updating VRCUrls on MenuControl", menuControl);
                            menuControl.__UpdateURLs();
                            menuControl.ApplyProxyModifications();
                        }
                    }

                }

                return true;
            }
        }
    }
#endif

}
#endif