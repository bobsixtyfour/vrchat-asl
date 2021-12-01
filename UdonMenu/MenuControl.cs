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
new string[]{"How to Sign Example","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowtoSignExample.mp4","Tenri","","","2","","","1"},
new string[]{"Your Avatar Cute Thanks","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/YourAvatarCuteThanks.mp4","Tenri","","","2","","","1"},
new string[]{"Dancetest","","https://bob64.vrsignlanguage.net/ShaderMotion/2021-10-24%2021-05-52.mp4","DmTheMechanic","","","2","","",""},
new string[]{"2 avatar test","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/2avatartest.mp4","Tenri","","","2","","","2"},
new string[]{"4 avatar test","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4avatartest.mp4","Tenri","","","2","","","4"},
},


new string[][]{//Alphabet
new string[]{"Spell / Fingerspell","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpellFingerspell-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Spell / Fingerspell","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpellFingerspell-v2.mp4","ShadeAxas","G","","2","","","1"},
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
new string[]{"Q","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Q.mp4","Tenri","B","","2","","needs to point straight down","1"},
new string[]{"R","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R-v1.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"R","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/R-v2.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"S","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/S-v1.mp4","Tenri","B","","2","","S movement should be more defined/clear","1"},
new string[]{"S","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/S-v2.mp4","Tenri","B","","2","","S movement should be more defined/clear","1"},
new string[]{"T","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/T.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"U","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/U.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"V","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/V-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"W","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W-v1.mp4","Tenri","I","Same handshape as '6'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"W","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/W-v2.mp4","Tenri","G","Same handshape as '6'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"X","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"X","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/X-v2.mp4","Tenri","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Y","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Y","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Y-v2.mp4","Tenri","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Z","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Z.mp4","Tenri","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
},
new string[][]{//Numbers
new string[]{"Number","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Number.mp4","Tenri","","Flat O handshape, if signed with 'C' handshapes, it can be mistaken as 'City'","1","CODAPop, DmTheMechanic, ShadeAxas","Flat o handshape","1"},
new string[]{"0","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/0.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"1","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"2","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/2.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"3","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/3-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"3","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/3-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"4","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"4","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/4-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"5","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/5.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"6","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/6-v1.mp4","Tenri","I","Same handshape as 'W'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"6","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/6-v2.mp4","ShadeAxas","G","Same handshape as 'W'","2","","","1"},
new string[]{"7","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/7-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"7","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/7-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"8","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/8-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"8","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/8-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"9","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/9-v1.mp4","Tenri","I","Same handshape as 'F'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"9","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/9-v2.mp4","ShadeAxas","G","Same handshape as 'F'","2","","","1"},
new string[]{"10","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/10.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"11","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/11.mp4","Tenri","B","Keep inside fingerspelling space, placing it near head could be misunderstood as 'Understand'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"12","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/12.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"13","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/13-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"13","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/13-v2.mp4","ShadeAxas","G","","2","","I have no idea how to sign this in general VR","1"},
new string[]{"14","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/14-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"15","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/15.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"16","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/16-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"16","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/16-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"17","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/17-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"17","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/17-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"18","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/18-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"18","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/18-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"19","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/19-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"19","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/19-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"20","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/20.mp4","Tenri","B","Don't sign near your mouth or it means 'Bird'","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"21","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/21.mp4","Tenri","B","","2","","","1"},
new string[]{"22","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/22.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"23","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/23-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"23","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/23-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"24","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/24-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"24","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/24-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"25","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/25.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"26","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/26-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"26","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/26-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"27","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/27-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"27","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/27-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"28","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/28-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"28","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/28-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"29","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/29-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"29","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/29-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"30","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/30-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"30","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/30-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"100","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/100.mp4","Tenri","B","","2","","","1"},
new string[]{"1000","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1000.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"1337","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1337.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"1000000","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/1000000.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
},
new string[][]{//Daily Use
new string[]{"Meaning","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meaning.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"(What Does That) Mean?","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/(WhatDoesThat)Mean.mp4","Tenri","B","Meaning with body language to change it into a question","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Hello","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hello.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"How (are) You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/How(are)You.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"What's Up?","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WhatsUp.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Nice (to) Meet You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice(to)MeetYou.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Nice (to) Meet (You)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice(to)Meet(You).mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Good","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Good.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Bad","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bad-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Bad","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bad-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Yes","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yes.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"No","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/No.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"So-So","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/So-So.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sick","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sick-v1.mp4","Tenri","I","","2","","","1"},

new string[]{"Hurt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hurt.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Welcome","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Welcome.mp4","Melwil","B","","2","","","1"},
new string[]{"Goodbye","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Goodbye.mp4","Tenri","B","","2","","","1"},
new string[]{"Good Morning","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodMorning.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Good Afternoon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodAfternoon.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Good Night","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoodNight.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"See (You) Later","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/See(You)Later.mp4","Tenri","B","","2","","","1"},
new string[]{"Please","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Please.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sorry","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sorry.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Forget","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forget-v1.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Bed","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bed.mp4","Tenri","","","2","","","1"},
new string[]{"Go (to) Portal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Go(to)Portal.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Change World","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ChangeWorld-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Thank You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ThankYou.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"I Love You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ILoveYou.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Love It","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LoveIt-v1.mp4","Tenri","","Also known as 'Kiss Fist'. Used when you love something. eg: Coffee, love it.","2","","","1"},
new string[]{"Love It","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LoveIt-v2.mp4","Tenri","","Also known as 'Kiss Fist'. Used when you love something. eg: Coffee, love it.","2","","","1"},
new string[]{"ILY (I Love You)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ILY(ILoveYou).mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Go Away","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GoAway.mp4","Melwil","","","2","","","1"},
new string[]{"Go","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Go.mp4","Melwil","","","2","","","1"},
new string[]{"Follow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Follow.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Come","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Come.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hearing (Person)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hearing(Person).mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Deaf","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deaf.mp4","Melwil","","Can be done in either order","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Hard of Hearing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HardofHearing.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},




},
new string[][]{ //Pointing use Question / Answer
new string[]{"I (Me)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/I(Me).mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"You","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/You.mp4","Melwil","","This is specifically the person you're talking to.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Him/Her/He/She/It/They","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HimHerHeSheItThey.mp4","Tenri","","Point at the person you're referring to","2","","","2"},
new string[]{"My","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/My.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Your","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Your.mp4","Melwil","","","2","","","1"},
new string[]{"It's","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Its.mp4","Melwil","","This sign is considered Signed Exact English.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"His/Hers/Its/Their","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HisHersItsTheir.mp4","Tenri","","","2","","","2"},
new string[]{"We","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/We.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"They/Them (Plural)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TheyThem(Plural).mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Their (Plural Possessive)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Their(PluralPossessive).mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Our","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Our.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"There","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/There.mp4","DarkEternal","","This sign is considered Signed Exact English. Depending on how far, you can emphasise the arc to convey how far it is.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"In","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/In.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Out","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Out.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Outside (Outdoors)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Outside(Outdoors).mp4","Tenri","","","2","","","1"},
new string[]{"Under","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Under.mp4","Melwil","","","2","","",""},

new string[]{"Behind","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behind.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},

new string[]{"Below","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Below.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Left (Direction)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Left(Direction).mp4","Melwil","","","2","","",""},
new string[]{"Right (Direction)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Right(Direction).mp4","Melwil","","","2","","",""},
new string[]{"Here","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Here.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Beside","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beside.mp4","Melwil","","","1","","Wierd that it goes back","1"},
new string[]{"Back (To Return)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back(ToReturn)-v1.mp4","Melwil","I","Lexical/Loan Sign (where it fingerspelling becomes its own sign)","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Back (To Return)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back(ToReturn)-v2.mp4","ShadeAxas","G","Lexical/Loan Sign (where it fingerspelling becomes its own sign)","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Back (Of Something)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Back(OfSomething).mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Front","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Front.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Who","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Who.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"What","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What-v1.mp4","Tenri","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"What","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/What-v2.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"When","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/When.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Where","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Where.mp4","Tenri","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Why","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Why-v1.mp4","Tenri","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},



new string[]{"How Many","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowMany.mp4","Tenri","","","1","","Too fast","1"},
new string[]{"How Long","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HowLong.mp4","Tenri","","","2","","","1"},
new string[]{"Which","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Which.mp4","Tenri","","Similar to the sign 'bath', the difference is 'which' is signed further away from the body","2","","","1"},
new string[]{"Can","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Can.mp4","Tenri","","","2","","","1"},
new string[]{"Possibly","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Possibly.mp4","Melwil","","","1","","Needs more clarity, too far apart","1"},
new string[]{"Can't","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cant.mp4","Tenri","","","2","","","1"},

new string[]{"Have","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Have.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Get / Recieve","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GetRecieve.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},


new string[]{"Need / Should","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NeedShould.mp4","Melwil","","","2","","","1"},
new string[]{"Must","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Must-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Must","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Must-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Not","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Not.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Or","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Or-v1.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"And","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/And.mp4","Melwil","","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"For","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/For.mp4","Melwil","","","1","","Record both version","1"},
},
new string[][]{ //Common
new string[]{"Accept","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Accept.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Again / Repeat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AgainRepeat.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"All Right","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllRight.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Be Right Back (BRB)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BeRightBack(BRB).mp4","Tenri","B","","2","","","1"},
new string[]{"Internet","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Internet.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Browsing (the) Internet","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Browsing(the)Internet.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
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
new string[]{"Joke / Joking","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/JokeJoking-v1.mp4","Melwil","I","","3","","","1"},
new string[]{"Joke / Joking","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/JokeJoking-v2.mp4","ShadeAxas","G","","3","","","1"},
new string[]{"Know","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Know.mp4","Melwil","B","","3","","","1"},
new string[]{"Language","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Language.mp4","Melwil","B","","3","","","1"},
new string[]{"Learn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Learn.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Live","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Live-v1.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Live","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Live-v2.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Make (Create)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Make(Create).mp4","Tenri","B","","2","","","1"},
new string[]{"Movie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Movie.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Name","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Name.mp4","Tenri","B","","2","","","1"},
new string[]{"New","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/New.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Old","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Old.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"People","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/People-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"People","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/People-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Person","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Person.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Play","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Play-v1.mp4","Melwil","I","This is the verb 'Play', not the noun.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Play","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Play-v2.mp4","ShadeAxas","G","This is the verb 'Play', not the noun.","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Read","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Read.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Rude","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rude-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Rude","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rude-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Same","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Same-v1.mp4","Melwil","I","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Same","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Same-v2.mp4","ShadeAxas","G","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Sign / Sign Language","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SignSignLanguage.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Slow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Slow.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","If possible, re-record so it moves along the arm better","1"},
new string[]{"Stop","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stop.mp4","Tenri","B","","2","","","1"},
new string[]{"Student","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Student.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Teach","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teach.mp4","Tenri","B","","2","","","1"},
new string[]{"Teacher","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teacher.mp4","Melwil","B","","3","CODAPop, DmTheMechanic, ShadeAxas","","1"},
new string[]{"Understand","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Understand.mp4","Melwil","B","","3","CODAPop, DmTheMechanic","","1"},
new string[]{"Very","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Very.mp4","Melwil","B","","3","CODAPop, DmTheMechanic","","1"},
new string[]{"Work","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Work.mp4","Melwil","B","","3","CODAPop, DmTheMechanic","","1"},
new string[]{"Write","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Write.mp4","ShadeAxas","B","","2","","","1"},
},
new string[][]{//People
new string[]{"Acquaintance","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Acquaintance.mp4","Melwil","","","2","","","1"},
new string[]{"Adult","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Adult.mp4","Melwil","","","1","","This should be an 'A' handshape according to ray","1"},

new string[]{"Anyone","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Anyone.mp4","Melwil","","","2","","","1"},
new string[]{"Aunt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Aunt.mp4","Melwil","","","2","","using s hand, not an a hand - ray","1"},
new string[]{"Baby","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Baby.mp4","Melwil","","","2","","","1"},
new string[]{"Birthday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Birthday-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Birthday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Birthday-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Born","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Born.mp4","Melwil","","","2","","","1"},
new string[]{"Boy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Boy.mp4","Melwil","","","2","","","1"},
new string[]{"Brother","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brother.mp4","Melwil","","","2","","","1"},
new string[]{"Brother-in-law","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Brother-in-law.mp4","Melwil","","","2","","","1"},
new string[]{"Celebrate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Celebrate.mp4","Melwil","","","2","","","1"},
new string[]{"Child","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Child-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Child","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Child-v2.mp4","DarkEternal","","","2","","","1"},
new string[]{"Children","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Children.mp4","Melwil","","","2","","","1"},
new string[]{"Dead","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dead.mp4","Melwil","","","2","","","1"},
new string[]{"Divorce","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Divorce.mp4","Melwil","","","2","","","1"},
new string[]{"Enemy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Enemy.mp4","Melwil","","","2","","","1"},
new string[]{"Everyone","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everyone.mp4","Melwil","","","2","","","1"},
new string[]{"Family","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Family-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Family","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Family-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Father","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Father-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Father","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Father-v2.mp4","Melwil","","","2","","","1"},
new string[]{"Girl","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Girl.mp4","Melwil","","","2","","","1"},
new string[]{"Grandma","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grandma.mp4","Melwil","","","2","","","1"},
new string[]{"Grandpa","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grandpa.mp4","Melwil","","","2","","","1"},
new string[]{"Interpreter","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interpreter-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Interpreter","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interpreter-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Kid","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kid.mp4","Melwil","","","2","","","1"},
new string[]{"Marriage","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Marriage.mp4","Melwil","","","2","","","1"},
new string[]{"Mother","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mother.mp4","Melwil","","","2","","","1"},
new string[]{"No One","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne-v1.mp4","Melwil","","","2","","","1"},
new string[]{"No One","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne-v2.mp4","Melwil","","","2","","","1"},
new string[]{"No One","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NoOne-v3.mp4","Melwil","","","2","","","1"},
new string[]{"Parents","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Parents.mp4","Melwil","","","2","","","1"},
new string[]{"Single","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Single.mp4","Melwil","","","2","","","1"},
new string[]{"Sister","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sister.mp4","Melwil","","","2","","","1"},
new string[]{"Sister-in-law","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sister-in-law.mp4","Melwil","","","2","","","1"},
new string[]{"Someone","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Someone-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Someone","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Someone-v2.mp4","Melwil","","","2","","","1"},
new string[]{"Stranger","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stranger.mp4","Melwil","","","2","","","1"},
new string[]{"Teen","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Teen.mp4","Melwil","","","2","","","1"},
new string[]{"Uncle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Uncle.mp4","Melwil","","","2","","","1"},
new string[]{"Young","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Young-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Young","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Young-v2.mp4","Melwil","","","2","","","1"},
new string[]{"Young","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Young-v3.mp4","Melwil","","","2","","","1"},
},
new string[][]{//Feelings / Reactions
new string[]{"Alive","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Alive-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Alive","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Alive-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Angry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Angry-v1.mp4","DmTheMechanic","I","","2","","Rename to Mad?","1"},
new string[]{"Angry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Angry-v2.mp4","ShadeAxas","","","2","","Rename to Mad?","1"},
new string[]{"Attention","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attention-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Attention","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attention-v2.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Bored","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bored.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Care / Precious","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CarePrecious.mp4","DmTheMechanic","","This sign has two different meanings","2","","","1"},
new string[]{"Careful","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Careful-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Careful","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Careful-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Confused","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Confused-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Confused","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Confused-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cry-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Cry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cry-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Curious","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Curious-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Curious","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Curious-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cute","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cute-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Cute","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cute-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Disgusted / Disgusting","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DisgustedDisgusting-v1.mp4","Tenri","B","Also means Gross/Nauseous","2","","","1"},
new string[]{"Disgusted / Disgusting","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/DisgustedDisgusting-v2.mp4","ShadeAxas","B","Also means Gross/Nauseous","2","","","1"},
new string[]{"Dislike","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dislike.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Embarrassed","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Embarrassed-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Embarrassed","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Embarrassed-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Enjoy / Appreciate ","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/EnjoyAppreciate.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Envy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Envy-v1.mp4","DmTheMechanic","I","Looks similar to the sign 'Drool', however the palm is pointed outwards with 'Envy', and towards the mouth/chin with 'Drool'.","2","","","1"},
new string[]{"Envy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Envy-v2.mp4","ShadeAxas","","Looks similar to the sign 'Drool', however the palm is pointed outwards with 'Envy', and towards the mouth/chin with 'Drool'.","2","","","1"},
new string[]{"Excited","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excited-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Excited","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excited-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fall In Love","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FallInLove-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Fall In Love","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/FallInLove-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Feel","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Feel-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Feel","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Feel-v2.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Focus","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Focus.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Friendly","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friendly-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Friendly","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friendly-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Great","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Great.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Happy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Happy.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Hate","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Hate","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v2.mp4","DmTheMechanic","","Don't mistake this sign for 'Puke'","2","","","1"},
new string[]{"Hate","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Hate","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hate-v4.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hungry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hungry-v1.mp4","DmTheMechanic","","Same sign for 'Wish'","2","","","1"},
new string[]{"Hungry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hungry-v2.mp4","ShadeAxas","","Same sign for 'Wish'","2","","","1"},
new string[]{"In-Love","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/In-Love.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Jealous","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jealous.mp4","DarkEternal","I","","1","","ray fails this one","1"},
new string[]{"Laughing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Laughing.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Like","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Like-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Like","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Like-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"LOL","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LOL.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Lonely","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lonely.mp4","DarkEternal","","","2","","","1"},
new string[]{"Mean (Unkind)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mean(Unkind)-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Mean (Unkind)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mean(Unkind)-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Nevermind","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nevermind.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Nice","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nice.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Pity","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pity-v1.mp4","DmTheMechanic","","Easily mistaken as 'poor'","2","","","1"},
new string[]{"Pity","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pity-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sad","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sad.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Scared","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Scared-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Scared","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Scared-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Shame","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shame.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Shy","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shy-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Shy","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shy-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sleep","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleep-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Sleep","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleep-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Sleepy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sleepy.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Smart","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smart-v1.mp4","Tenri","I","","1","","Ray uses the other variant of smart","1"},
new string[]{"Smart","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smart-v2.mp4","ShadeAxas","B","","1","","Ray uses the other variant of smart","1"},
new string[]{"Stressed","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stressed-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Stressed","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stressed-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Struggle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Struggle.mp4","DmTheMechanic","","","2","","Repeats 3 times?","1"},

new string[]{"Surprised","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Surprised-v1.mp4","DmTheMechanic","","Same sign for 'awake/woke'","2","","","1"},
new string[]{"Surprised","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Surprised-v2.mp4","ShadeAxas","","Same sign for 'awake/woke'","2","","","1"},
new string[]{"Tired","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tired.mp4","DmTheMechanic","","","2","","","1"},
},
new string[][]{ //Value

new string[]{"All","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v1.mp4","Melwil","","","2","","","1"},
new string[]{"All","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/All-v2.mp4","Melwil","","","2","","","1"},
new string[]{"Always","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Always.mp4","Melwil","","","2","","","1"},


new string[]{"Early","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Early.mp4","Melwil","","","2","","","1"},
new string[]{"Empty","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Empty-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Empty","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Empty-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Ever","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ever-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Ever","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ever-v2.mp4","DarkEternal","","","2","","","1"},

new string[]{"Everytime","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Everytime.mp4","Melwil","","","2","","","1"},



new string[]{"Free","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Free-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Full","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Full.mp4","Melwil","","","2","","","1"},
new string[]{"Half","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Half.mp4","Melwil","","","2","","","1"},

new string[]{"Hard","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hard-v2.mp4","DarkEternal","","","2","","","1"},
new string[]{"Heavy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Heavy.mp4","Melwil","","","2","","","1"},

new string[]{"Large / Big","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/LargeBig.mp4","Melwil","","","2","","","1"},
new string[]{"Last","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Last.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Lightweight","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lightweight-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Lightweight","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lightweight-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Limited","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Limited.mp4","Melwil","","","2","","","1"},
new string[]{"Long","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Long.mp4","Melwil","","","2","","","1"},

new string[]{"More","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/More-v1.mp4","Melwil","","","2","","","1"},
new string[]{"More","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/More-v2.mp4","DarkEternal","","","2","","","1"},
new string[]{"Much / A Lot","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/MuchALot.mp4","Melwil","","","2","","","1"},

new string[]{"Nothing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nothing.mp4","Melwil","","","2","","","1"},
new string[]{"Often","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Often.mp4","Melwil","","","2","","","1"},
new string[]{"Quarter","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quarter.mp4","Melwil","","","2","","","1"},

new string[]{"Short (Time)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Short(Time).mp4","Melwil","B","","2","","","1"},
new string[]{"Small","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Small.mp4","Tenri","B","","2","","","1"},

new string[]{"Sometimes","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sometimes-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Sometimes","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sometimes-v2.mp4","Melwil","","","2","","","1"},



new string[]{"Third","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Third-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Tiny","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tiny.mp4","Melwil","I","","2","","","1"},
new string[]{"Unlimited","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Unlimited.mp4","Melwil","","","2","","","1"},


},
new string[][]{ //Time
new string[]{"Time","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Time.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Year","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Year-v1.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Year","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Year-v2.mp4","Tenri","","","2","","","1"},
new string[]{"Season","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Season.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Month","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Month.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Week","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Week.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Day","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Day.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Weekend","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Weekend-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"Weekend","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Weekend-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Hour","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hour.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Minute","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Minute.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Second (Time)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Second(Time).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Today","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Today","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Today","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v3.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Today","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Today-v4.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Tomorrow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tomorrow.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Yesterday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Yesterday.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Morning","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Morning.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Afternoon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Afternoon.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Evening","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Evening.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Night","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Night.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sunrise","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunrise-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Sunrise","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunrise-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Sunset","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunset-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Sunset","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunset-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"All Day","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllDay.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"All Night","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllNight-v1.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"All Night","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllNight-v2.mp4","DmTheMechanic","B","","2","","","1"},
new string[]{"All Night","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AllNight-v3.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Sunday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sunday.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Monday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Monday.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Tuesday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tuesday.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Wednesday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Wednesday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Wednesday","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-v3.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Wednesday","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wednesday-v4.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Thursday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Thursday.mp4","ShadeAxas","","","2","","Ray likes the H hand version","1"},
new string[]{"Friday","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friday-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Friday","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Friday-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Saturday","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Saturday.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Autumn / Fall","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AutumnFall.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Winter","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Winter.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Spring (Season)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Spring(Season).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Summer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Summer.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Now","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Now","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Now","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-v3.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Now","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Now-v4.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Never","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Never.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Soon","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soon-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Soon","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soon-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Soon","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soon-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Later","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Later","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Later","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Later","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v4.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Later","5","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Later-v5.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Past","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Past.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Will / Future","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WillFuture-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Will / Future","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WillFuture-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Will / Future","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WillFuture-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Future (Initialized)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Future(Initialized).mp4","ShadeAxas","","","2","","","1"},

new string[]{"Midweek","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Midweek.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Next Week","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NextWeek-v1.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Next Week","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/NextWeek-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Break (Rest)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Break(Rest).mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Lesson 9 (VRChat)
new string[]{"Gestures","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Gestures.mp4","ShadeAxas","","","2","","Don't remember what ray says","1"},
new string[]{"World","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/World.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Record","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Record.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Discord","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Discord.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Streaming","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Streaming.mp4","ShadeAxas","","","2","","","1"},
new string[]{"VR Headset","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/VRHeadset.mp4","ShadeAxas","","","2","","","1"},


new string[]{"Computer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Computer.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Public","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Public.mp4","ShadeAxas","","","2","","","1"},


new string[]{"Add Friend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/AddFriend.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Recharge","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Recharge.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Visit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Visit.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Request","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Request.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Login","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Login.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Logout","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Logout.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Schedule","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Schedule.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Event","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Event.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Online","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Online","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v2.mp4","Tenri","I","","2","","","1"},
new string[]{"Online","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Online-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Offline","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offline-v1.mp4","Tenri","I","","2","","","1"},
new string[]{"Offline","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offline-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Offline","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offline-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cancel","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cancel.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Portal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Portal.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Camera","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Camera.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Avatar","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Avatar.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Photo","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Photo.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Join","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Join.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Leave","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Leave.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Climbing","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Climbing.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Falling","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Falling.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Walk","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Walk.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hide","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hide.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Block","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Block.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Crash","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Crash.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Lagging","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lagging.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Restart","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Restart.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Send","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Send.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Receive","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Receive.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Donation","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Donation.mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Lesson 10 (Verbs & Actions p1)
new string[]{"Add","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Add.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Admit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Admit.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Agree","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Agree-v1.mp4","Tenri","B","","2","","","1"},
new string[]{"Agree","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Agree-v2.mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Allow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Allow.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Argue","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Argue-v1.mp4","Melwil","","","2","","",""},
new string[]{"Argue","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Argue-v2.mp4","Melwil","","","2","","",""},
new string[]{"Ask","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ask.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Assist","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Assist.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Assistant","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Assistant.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Attach","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attach.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Attack","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Attack.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Battle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Battle.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Beat (Overcome)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beat(Overcome).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Become","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Become.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Beg","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Beg.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Begin / Start","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BeginStart.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Behave","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behave-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Behave","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Behave-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Believe","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Believe.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Blame","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blame.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Blow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blow.mp4","","","","","","","1"},
new string[]{"Blush","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Blush.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Bother / Harass","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BotherHarass.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Defeat (Overcome)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defeat(Overcome).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Defend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Defend.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Disagree","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disagree.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Draw (Tie)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Draw(Tie).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Edit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Edit.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Erase","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Erase.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fight","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fight.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Give Up","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/GiveUp.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Increase","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Increase.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Lose","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lose.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Overlook","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Overlook.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Proposal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Proposal.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Punish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Punish.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Remove","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remove.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Skip","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Skip-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Skip","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Skip-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Win","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Win.mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Lesson 11 (Verbs & Actions p2)
new string[]{"Bend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bend.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Bow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bow.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Break (Damage)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Break(Damage).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Breathe","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Breathe.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Bring","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bring.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Build / Construct","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BuildConstruct-v1.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Build / Construct","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BuildConstruct-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Bully","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bully.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Burn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Burn.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Buy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Buy.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Call (Phone)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Call(Phone)-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Call (Phone)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Call(Phone)-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Call (Summon)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Call(Summon).mp4","ShadeAxas","B","","2","","","1"},
new string[]{"Care","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Care.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Carry","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Carry.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Catch","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Catch.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cause","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cause.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Challenge","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Challenge.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Chance","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Chance.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cheat","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheat-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Cheat","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheat-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Cheat","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheat-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Check","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Check.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Choose","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Choose-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Choose","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Choose-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Claim","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Claim.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Clean","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Clean.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Clear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Clear.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Close (Shut)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Close(Shut).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Comfort","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Comfort.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Command","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Command.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Communicate","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Communicate-v1.mp4","Melwil","I","","2","","","1"},
new string[]{"Communicate","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Communicate-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Compare","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Compare.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Complain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Complain.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Compliment","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Compliment.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Concentrate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Concentrate.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Control","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Control-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Control","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Control-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cook","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cook.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Copy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Copy.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Correct (Fix)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Correct(Fix).mp4","ShadeAxas","","Correct as in 'I'm gonna correct that issue.'","2","","","1"},
},
new string[][]{//Verbs & Actions p3
new string[]{"Cough","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cough.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Count","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Count-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Count","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Count-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Create / Make","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/CreateMake.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cuddle","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cuddle.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cut","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cut.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dab","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dab.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dance","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dance.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Date","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Date.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Deal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deal.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Deliver","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Deliver.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Depend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Depend.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Describe (Explain)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Describe(Explain)-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Describe (Explain)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Describe(Explain)-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dirty","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dirty-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Dirty","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dirty-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Disappear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disappear.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Disappoint","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disappoint.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Disapprove","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disapprove.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Discuss","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Discuss.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Disguise","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Disguise.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dismiss","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dismiss.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Doubt","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Doubt-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Doubt","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Doubt-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Doubt","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Doubt-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dream","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dream.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dress (Verb)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dress(Verb).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Drop","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drop.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Drown","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drown.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dry","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dry.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Dump","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dump.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Earn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Earn.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Effect","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Effect.mp4","ShadeAxas","","","2","","","1"},
new string[]{"End","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/End.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Escape","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Escape.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Escort","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Escort.mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Verbs & Actions p4
new string[]{"Excuse (Verb)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Excuse(Verb).mp4","ShadeAxas","","","2","","","1"},

new string[]{"Expose","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Expose.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fail","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fail.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Faint","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Faint.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fake","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fake.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fart","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fart.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fear","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fear.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fill","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fill.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Find","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Find-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Find","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Find-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Find","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Find-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Finish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Finish.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fix","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fix.mp4","ShadeAxas","","","2","","","1"},


new string[]{"Flirt","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Flirt-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Flirt","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Flirt-v2.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Fly","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fly.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Forbid","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forbid.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Forgive","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Forgive.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Gain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Gain.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Give","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Give-v1.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Give","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Give-v2.mp4","DmTheMechanic","I","","2","","","1"},
new string[]{"Give","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Give-v3.mp4","ShadeAxas","G","","2","","","1"},
new string[]{"Glow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Glow.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Grab","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grab.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Grow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grow.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Guard","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guard.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Guess","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guess.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Guide","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Guide.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Harass / Bother","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HarassBother.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Harm","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Harm.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hit.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hold","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hold.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hop","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hop.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hope","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hope.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hunt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hunt.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Ignore","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ignore.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Imagine","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Imagine","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Imagine","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Imagine","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v4.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Imagine","5","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imagine-v5.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Imitate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Imitate.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Insult","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Insult.mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Verbs & Actions p5
new string[]{"Interact","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interact.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Interfere","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Interfere.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Judge","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Judge-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Judge","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Judge-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Judge","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Judge-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Jump","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Jump.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Kidding","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kidding-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kidding","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kidding-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kidding","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kidding-v3.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Keep","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Keep","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Keep","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Keep","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Keep-v4.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Kick","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kick-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kick","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kick-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kick","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kick-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Kill","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kill.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Knock","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Knock.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Lead","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lead.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Lick","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lick.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Lock","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lock.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Manipulate","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Manipulate-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Manipulate","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Manipulate-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Melt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Melt.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Mess","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mess.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Miss (Didn't Get It)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Miss(DidntGetIt).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Mistake","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mistake-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Mistake","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mistake-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Mount","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Mount.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Move","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Move.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Nod","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nod.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Note","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Note.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Notice","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Notice.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Obey","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obey.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Obsess","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obsess-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Obsess","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obsess-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Obsess","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obsess-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Obtain","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Obtain.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Occupy","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Occupy.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Offend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offend.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Offer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Offer.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Okay (Approve)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Okay(Approve).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Open","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Open.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Order","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Order.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Owe","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Owe.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Own","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Own.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pass","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pass.mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Verbs & Actions p6
new string[]{"Party","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Party.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pat.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pet","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pet.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pick","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pick-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Pick","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pick-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Pick","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pick-v3.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Plug","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Plug.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Point","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Point.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Poke","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Poke.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pray","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pray.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Prepare","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prepare.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Present (Lecture)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Present(Lecture).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pretend","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pretend.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Protect","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Protect.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Prove","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Prove.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Publish","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Publish.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Puke","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Puke.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pull","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pull.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Punch","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Punch.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Push","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Push.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Put","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Put.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Question","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Question.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Questions","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Questions.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Quit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quit.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Quote","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Quote.mp4","ShadeAxas","","","2","","","1"},

new string[]{"React","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/React.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Recommended","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Recommended.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Refuse","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Refuse.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Regret","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Regret.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Remember","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Remember.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Replace","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Replace-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Replace","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Replace-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Report","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Report.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Reset","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Reset.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Ride","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Ride.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Rub","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rub.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Rule (Rules)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Rule(Rules).mp4","ShadeAxas","","","2","","","1"},
new string[]{"Run","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Run.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Save","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Save-v1.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Save","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Save-v2.mp4","ShadeAxas","","","2","","","1"},
},
new string[][]{//Verbs & Actions p7
new string[]{"Say","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Say.mp4","Melwil","","","2","","","1"},
new string[]{"Search","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Search.mp4","Melwil","","","2","","","1"},
new string[]{"See","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/See.mp4","Melwil","","","2","","","1"},
new string[]{"Share","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Share.mp4","Melwil","","","2","","","1"},
new string[]{"Shock","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shock.mp4","Melwil","","","2","","","1"},
new string[]{"Shop (Store)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shop(Store).mp4","Melwil","","","2","","","1"},
new string[]{"Show","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Show.mp4","Melwil","","","2","","","1"},
new string[]{"Shut Down","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ShutDown-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Shut Down","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ShutDown-v2.mp4","Melwil","","","2","","","1"},
new string[]{"Shut Up","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/ShutUp.mp4","Melwil","","","2","","","1"},




new string[]{"Smoke (Airborn)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smoke(Airborn)-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Smoke (Airborn)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Smoke(Airborn)-v2.mp4","Melwil","","","2","","","1"},
new string[]{"Speak / Talk","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpeakTalk-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Speak / Talk","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/SpeakTalk-v2.mp4","Melwil","","","2","","","1"},

new string[]{"Stand","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stand.mp4","Melwil","","","2","","","1"},
new string[]{"Stay","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stay-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Stay","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Stay-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Steal","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Steal.mp4","Melwil","","","2","","","1"},
new string[]{"Study","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Study-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Study","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Study-v2.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Suffer","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Suffer.mp4","Melwil","","","2","","","1"},
new string[]{"Swim","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Swim.mp4","Melwil","","","2","","","1"},
new string[]{"Switch","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Switch.mp4","Melwil","","","2","","","1"},
new string[]{"Take (From)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Take(From).mp4","Melwil","","","2","","","1"},
new string[]{"Tell","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tell.mp4","Melwil","","","2","","","1"},
new string[]{"Test","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Test.mp4","Melwil","","","2","","","1"},
new string[]{"Text","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Text.mp4","Melwil","","","2","","","1"},
new string[]{"Think","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Think.mp4","Melwil","","","2","","","1"},
new string[]{"Throw","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Throw-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Throw","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Throw-v2.mp4","Melwil","","","2","","","1"},


new string[]{"Try","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Try-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Try","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Try-v2.mp4","Melwil","","Signed Exact English Variant","2","","","1"},





},
new string[][]{//Verbs & Actions p8
new string[]{"Bath / Bathe / Bathing","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v1.mp4","DmTheMechanic","","Looks similar to 'which' but is this sign is done against your chest. 'Which' is done in midair.","2","","","1"},
new string[]{"Bath / Bathe / Bathing","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v2.mp4","DmTheMechanic","","Looks similar to 'which' but is this sign is done against your chest. 'Which' is done in midair.","2","","","1"},
new string[]{"Bath / Bathe / Bathing","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BathBatheBathing-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Calculator","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculator.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Calculate","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Calculate.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Thinking","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Thinking.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Drive","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drive.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Fiction","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fiction.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Help","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Help.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Hug","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hug-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Hug","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hug-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kiss","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v1.mp4","DmTheMechanic","","","2","","Initialized K hand version might be best","1"},
new string[]{"Kiss","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kiss","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Kiss","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Kiss-v4.mp4","Tenri","","","2","","","1"},
new string[]{"Lie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lie.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Serve","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Serve.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Shower","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Shower.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Socialize","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Socialize.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Sting","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sting.mp4","Melwil","","","2","","",""},
new string[]{"Support","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Support.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Take Care","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/TakeCare.mp4","DmTheMechanic","","Note: this is actually two signs: Take (up) + Care","2","","","1"},
new string[]{"Touch","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Touch-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Touch","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Touch-v2.mp4","DmTheMechanic","","","2","","","1"},

new string[]{"Trip (Fall Over)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip(FallOver)-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Trip (Fall Over)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip(FallOver)-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Trip","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Trip","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trip-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"True","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/True.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"True","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/True.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Trust","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trust-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Trust","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Trust-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Turn","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turn-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Turn","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Turn-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Type","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Type.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Upset","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Upset.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Use","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Use.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"View","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/View-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"View","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/View-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Vomit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Vomit.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wait","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wait.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wake Up","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/WakeUp.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"War","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/War-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"War","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/War-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Warn","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Warn-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Warn","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Warn-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wash","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wash","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wash","3","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v3.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wash","4","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wash-v4.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Waste","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Waste-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Waste","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Waste-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Watch (Look)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v1.mp4","Melwil","","","2","","","1"},
new string[]{"Watch (Look)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Watch (Look)","0","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Watch(Look)-v0.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wear","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wear","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wear (Clothes)","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear(Clothes)-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wear (Clothes)","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wear(Clothes)-v2.mp4","DmTheMechanic","","","2","","","1"},

new string[]{"Wonder","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wonder.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Worry","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Worry-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Worry","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Worry-v2.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wristwatch","1","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wristwatch-v1.mp4","DmTheMechanic","","","2","","","1"},
new string[]{"Wristwatch","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wristwatch-v2.mp4","DmTheMechanic","","","2","","","1"},
},//end of lesson
new string[][]{//Food
new string[]{"Drunk","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Drunk.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hungover","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hungover.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Corn","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Corn.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Vegetable","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Vegetable.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cookie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cookie.mp4","ShadeAxas","","","2","","","1"},


new string[]{"Lemon","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Lemon.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Nuts","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Nuts.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Grapes","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Grapes.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Icecream","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Icecream.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Butter","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Butter.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Banana","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Banana.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pumpkin","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pumpkin.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fruit","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fruit.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Apple","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Apple.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Tomato","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tomato.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Bread","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Bread.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cheese","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cheese.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Water","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Water.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hamburger","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Hamburger.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Hot Dog","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/HotDog.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sandwich","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sandwich.mp4","ShadeAxas","","","2","","","1"},


new string[]{"Egg","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Egg.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Salt","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Salt.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Meat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Meat.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Carrot","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Carrot.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cabbage","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cabbage.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Spaghetti","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Spaghetti.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Pizza","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Pizza.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sushi","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sushi.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Potato","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Potato.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Juice","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Juice.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Soda","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Soda.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Wine","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Wine.mp4","ShadeAxas","","","2","","","1"},

new string[]{"Milk","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Milk.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sugar","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sugar.mp4","ShadeAxas","","","2","","","1"},
},//end of lesson
new string[][]{//Animals 
new string[]{"Dog","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Dog.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cat","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cat.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Fox","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Fox.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Cow","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Cow.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Sheep","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Sheep.mp4","ShadeAxas","","","2","","","1"},
new string[]{"Duck","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Duck.mp4","ShadeAxas","","","2","","","1"},
















},//end of lesson
new string[][]{//Machines





















},//end of lesson
new string[][]{//Places









































},//end of lesson
new string[][]{//Stuff






















},//end of lesson
new string[][]{//Weather

















},//end of lesson
new string[][]{//Clothing


















},//end of lesson
new string[][]{//Accessories













new string[]{"Tie (Necktie)","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Tie(Necktie).mp4","Melwil","","","","","",""},
new string[]{"Bow Tie","","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/BowTie.mp4","Melwil","","","","","",""},



},//end of lesson
new string[][]{//Fantasy / Characters

















},//end of lesson
new string[][]{//Non Manual Markers
new string[]{"Or","2","https://bob64.vrsignlanguage.net/ShaderMotion/ASL/Or-v2.mp4","Melwil","B","","","","",""},


},//end of lesson










},//end of asl
new string[][][]{//BSL
new string[][]{//BSL Lesson 1 - Daily Use
new string[]{"Hello","","https://vrsignlanguage.net/BSL_videos/sheet01/01-01.mp4","CathDeafGamer","","","3","",""},
new string[]{"How are you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-02.mp4","CathDeafGamer","","","3","",""},
new string[]{"What’s up?","","https://vrsignlanguage.net/BSL_videos/sheet01/01-03.mp4","CathDeafGamer","","","3","",""},
new string[]{"Nice to meet you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-04.mp4","CathDeafGamer","","","3","",""},
new string[]{"Good","","https://vrsignlanguage.net/BSL_videos/sheet01/01-05.mp4","CathDeafGamer","","","3","",""},
new string[]{"Bad","","https://vrsignlanguage.net/BSL_videos/sheet01/01-06.mp4","CathDeafGamer","","","3","",""},
new string[]{"Yes","","https://vrsignlanguage.net/BSL_videos/sheet01/01-07.mp4","CathDeafGamer","","","3","",""},
new string[]{"No","","https://vrsignlanguage.net/BSL_videos/sheet01/01-08.mp4","CathDeafGamer","","","3","",""},
new string[]{"So-So","","https://vrsignlanguage.net/BSL_videos/sheet01/01-09.mp4","CathDeafGamer","","","3","",""},
new string[]{"Sick","","https://vrsignlanguage.net/BSL_videos/sheet01/01-10.mp4","CathDeafGamer","","","3","",""},
new string[]{"Hurt","","https://vrsignlanguage.net/BSL_videos/sheet01/01-11.mp4","CathDeafGamer","","","3","",""},
new string[]{"You’re welcome","","https://vrsignlanguage.net/BSL_videos/sheet01/01-12.mp4","CathDeafGamer","","","3","",""},
new string[]{"Good bye","","https://vrsignlanguage.net/BSL_videos/sheet01/01-13.mp4","CathDeafGamer","","","3","",""},
new string[]{"Good morning","","https://vrsignlanguage.net/BSL_videos/sheet01/01-14.mp4","CathDeafGamer","","","3","",""},
new string[]{"Good afternoon","","https://vrsignlanguage.net/BSL_videos/sheet01/01-15.mp4","CathDeafGamer","","","3","",""},
new string[]{"Good evening","","https://vrsignlanguage.net/BSL_videos/sheet01/01-16.mp4","CathDeafGamer","","","3","",""},
new string[]{"Good night","","https://vrsignlanguage.net/BSL_videos/sheet01/01-17.mp4","CathDeafGamer","","","3","",""},
new string[]{"See you later","","https://vrsignlanguage.net/BSL_videos/sheet01/01-18.mp4","CathDeafGamer","","","3","",""},
new string[]{"Please","","https://vrsignlanguage.net/BSL_videos/sheet01/01-19.mp4","CathDeafGamer","","","3","",""},
new string[]{"Sorry","","https://vrsignlanguage.net/BSL_videos/sheet01/01-20.mp4","CathDeafGamer","","","3","",""},
new string[]{"Forgotten","","https://vrsignlanguage.net/BSL_videos/sheet01/01-21.mp4","CathDeafGamer","","","3","",""},
new string[]{"Sleep","","https://vrsignlanguage.net/BSL_videos/sheet01/01-22.mp4","CathDeafGamer","","","3","",""},
new string[]{"Bed","","https://vrsignlanguage.net/BSL_videos/sheet01/01-23.mp4","CathDeafGamer","","","3","",""},
new string[]{"Jump / Change world","","https://vrsignlanguage.net/BSL_videos/sheet01/01-24.mp4","CathDeafGamer","","","3","",""},
new string[]{"Thank you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-25.mp4","CathDeafGamer","","","3","",""},
new string[]{"I love you","","https://vrsignlanguage.net/BSL_videos/sheet01/01-26.mp4","CathDeafGamer","","","3","",""},
new string[]{"Go away","","https://vrsignlanguage.net/BSL_videos/sheet01/01-27.mp4","CathDeafGamer","","","3","",""},
new string[]{"Going to","","https://vrsignlanguage.net/BSL_videos/sheet01/01-28.mp4","CathDeafGamer","","","3","",""},
new string[]{"Follow","","https://vrsignlanguage.net/BSL_videos/sheet01/01-29.mp4","CathDeafGamer","","","3","",""},
new string[]{"Come","","https://vrsignlanguage.net/BSL_videos/sheet01/01-30.mp4","CathDeafGamer","","","3","",""},
new string[]{"Hearing","","https://vrsignlanguage.net/BSL_videos/sheet01/01-31.mp4","CathDeafGamer","","","3","",""},
new string[]{"Deaf","","https://vrsignlanguage.net/BSL_videos/sheet01/01-32.mp4","CathDeafGamer","","","3","",""},
new string[]{"Hard to Hear","","https://vrsignlanguage.net/BSL_videos/sheet01/01-33.mp4","CathDeafGamer","","","3","",""},
new string[]{"Mute","","https://vrsignlanguage.net/BSL_videos/sheet01/01-34.mp4","CathDeafGamer","","","3","",""},
new string[]{"Write slow","","https://vrsignlanguage.net/BSL_videos/sheet01/01-35.mp4","CathDeafGamer","","","3","",""},
new string[]{"Cannot read","","https://vrsignlanguage.net/BSL_videos/sheet01/01-36.mp4","CathDeafGamer","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 2 - Pointing use Question / Answer
new string[]{"I (Me)","","https://vrsignlanguage.net/BSL_videos/sheet02/02-01_Me.mp4","Sheezy93","","","3","",""},
new string[]{"My","","https://vrsignlanguage.net/BSL_videos/sheet02/02-02_My.mp4","Sheezy93","","","3","",""},
new string[]{"Your","","https://vrsignlanguage.net/BSL_videos/sheet02/02-03_Your.mp4","Sheezy93","","","3","",""},
new string[]{"Him / His / Her","","https://vrsignlanguage.net/BSL_videos/sheet02/02-04_His.mp4","Sheezy93","","","3","",""},
new string[]{"We","","https://vrsignlanguage.net/BSL_videos/sheet02/02-06_We.mp4","Sheezy93","","","3","",""},
new string[]{"They","","https://vrsignlanguage.net/BSL_videos/sheet02/02-07_They.mp4","Sheezy93","","","3","",""},
new string[]{"Their","","https://vrsignlanguage.net/BSL_videos/sheet02/02-08_Their.mp4","Sheezy93","","","3","",""},
new string[]{"Over there","","https://vrsignlanguage.net/BSL_videos/sheet02/02-09_OverThere.mp4","Sheezy93","","","3","",""},
new string[]{"Our","","https://vrsignlanguage.net/BSL_videos/sheet02/02-10_Our.mp4","Sheezy93","","","3","",""},
new string[]{"Inside","","https://vrsignlanguage.net/BSL_videos/sheet02/02-12_Inside.mp4","Sheezy93","","","3","",""},
new string[]{"Outside","","https://vrsignlanguage.net/BSL_videos/sheet02/02-13_Outside.mp4","Sheezy93","","","3","",""},
new string[]{"Hidden","","https://vrsignlanguage.net/BSL_videos/sheet02/02-14_Hidden.mp4","Sheezy93","","","3","",""},
new string[]{"Behind ","","https://vrsignlanguage.net/BSL_videos/sheet02/02-15_behind.mp4","Sheezy93","","","3","",""},
new string[]{"Above","","https://vrsignlanguage.net/BSL_videos/sheet02/02-16_above.mp4","Sheezy93","","","3","",""},
new string[]{"Below","","https://vrsignlanguage.net/BSL_videos/sheet02/02-17_below.mp4","Sheezy93","","","3","",""},
new string[]{"Here","","https://vrsignlanguage.net/BSL_videos/sheet02/02-18_here.mp4","Sheezy93","","","3","",""},
new string[]{"Beside","","https://vrsignlanguage.net/BSL_videos/sheet02/02-19_beside.mp4","Sheezy93","","","3","",""},
new string[]{"Back ","","https://vrsignlanguage.net/BSL_videos/sheet02/02-20_back.mp4","Sheezy93","","","3","",""},
new string[]{"Front","","https://vrsignlanguage.net/BSL_videos/sheet02/02-21_front.mp4","Sheezy93","","","3","",""},
new string[]{"Who","","https://vrsignlanguage.net/BSL_videos/sheet02/02-22_who.mp4","Sheezy93","","","3","",""},
new string[]{"Where","","https://vrsignlanguage.net/BSL_videos/sheet02/02-23_where.mp4","Sheezy93","","","3","",""},
new string[]{"When","","https://vrsignlanguage.net/BSL_videos/sheet02/02-24_when.mp4","Sheezy93","","","3","",""},
new string[]{"Why","","https://vrsignlanguage.net/BSL_videos/sheet02/02-25_why.mp4","Sheezy93","","","3","",""},
new string[]{"Which","","https://vrsignlanguage.net/BSL_videos/sheet02/02-26_which.mp4","Sheezy93","","","3","",""},
new string[]{"What","","https://vrsignlanguage.net/BSL_videos/sheet02/02-27_what.mp4","Sheezy93","","","3","",""},
new string[]{"How","","https://vrsignlanguage.net/BSL_videos/sheet02/02-28_how.mp4","Sheezy93","","","3","",""},
new string[]{"How many","","https://vrsignlanguage.net/BSL_videos/sheet02/02-29_howmany.mp4","Sheezy93","","","3","",""},
new string[]{"Can","","https://vrsignlanguage.net/BSL_videos/sheet02/02-30_can.mp4","Sheezy93","","","3","",""},
new string[]{"Can’t","","https://vrsignlanguage.net/BSL_videos/sheet02/02-31_cant.mp4","Sheezy93","","","3","",""},
new string[]{"Want","","https://vrsignlanguage.net/BSL_videos/sheet02/02-32_want.mp4","Sheezy93","","","3","",""},
new string[]{"Have","","https://vrsignlanguage.net/BSL_videos/sheet02/02-33_have.mp4","Sheezy93","","","3","",""},
new string[]{"Get","","https://vrsignlanguage.net/BSL_videos/sheet02/02-34_get.mp4","Sheezy93","","","3","",""},
new string[]{"Will","","https://vrsignlanguage.net/BSL_videos/sheet02/02-35_will.mp4","Sheezy93","","","3","",""},
new string[]{"Take","","https://vrsignlanguage.net/BSL_videos/sheet02/02-36_take.mp4","Sheezy93","","","3","",""},
new string[]{"Need","","https://vrsignlanguage.net/BSL_videos/sheet02/02-37_need.mp4","Sheezy93","","","3","",""},
new string[]{"Not","","https://vrsignlanguage.net/BSL_videos/sheet02/02-38_not.mp4","Sheezy93","","","3","",""},
new string[]{"Or","","https://vrsignlanguage.net/BSL_videos/sheet02/02-39-or.mp4","Sheezy93","","","3","",""},
new string[]{"And","","https://vrsignlanguage.net/BSL_videos/sheet02/02-40_and.mp4","Sheezy93","","","3","",""},
new string[]{"For","","https://vrsignlanguage.net/BSL_videos/sheet02/02-41_for.mp4","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 3 - Common
new string[]{"Accept","","https://bob64.vrsignlanguage.net/BSL/L3/Accept.m4v","Sheezy93","","","3","",""},
new string[]{"Again","","https://bob64.vrsignlanguage.net/BSL/L3/Again.m4v","Sheezy93","","","3","",""},
new string[]{"All right","","https://bob64.vrsignlanguage.net/BSL/L3/All_right.m4v","Sheezy93","","","3","",""},
new string[]{"Brb","","https://bob64.vrsignlanguage.net/BSL/L3/Brb.m4v","Sheezy93","","","3","",""},
new string[]{"Denied","","https://bob64.vrsignlanguage.net/BSL/L3/Denied.m4v","Sheezy93","","","3","",""},
new string[]{"Dont know (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L3/Dont_know_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Dont know (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L3/Dont_know_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Draw (game)","","https://bob64.vrsignlanguage.net/BSL/L3/Draw_(game).m4v","Sheezy93","","","3","",""},
new string[]{"Drink","","https://bob64.vrsignlanguage.net/BSL/L3/Drink.m4v","Sheezy93","","","3","",""},
new string[]{"Eat","","https://bob64.vrsignlanguage.net/BSL/L3/Eat.m4v","Sheezy93","","","3","",""},
new string[]{"Fast","","https://bob64.vrsignlanguage.net/BSL/L3/Fast.m4v","Sheezy93","","","3","",""},
new string[]{"Favorite","","https://bob64.vrsignlanguage.net/BSL/L3/Favorite.m4v","Sheezy93","","","3","",""},
new string[]{"Friend (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L3/Friend_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Friend (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L3/Friend_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Friend (3)","","https://bob64.vrsignlanguage.net/BSL/L3/Friend_(3).m4v","Sheezy93","","","3","",""},
new string[]{"Funny","","https://bob64.vrsignlanguage.net/BSL/L3/Funny.m4v","Sheezy93","","","3","",""},
new string[]{"Internet","","https://bob64.vrsignlanguage.net/BSL/L3/Internet.m4v","Sheezy93","","","3","",""},
new string[]{"Jokes","","https://bob64.vrsignlanguage.net/BSL/L3/Jokes.m4v","Sheezy93","","","3","",""},
new string[]{"Know","","https://bob64.vrsignlanguage.net/BSL/L3/Know.m4v","Sheezy93","","","3","",""},
new string[]{"Language","","https://bob64.vrsignlanguage.net/BSL/L3/Language.m4v","Sheezy93","","","3","",""},
new string[]{"Learn","","https://bob64.vrsignlanguage.net/BSL/L3/Learn.m4v","Sheezy93","","","3","",""},
new string[]{"Live","","https://bob64.vrsignlanguage.net/BSL/L3/Live.m4v","Sheezy93","","","3","",""},
new string[]{"Make","","https://bob64.vrsignlanguage.net/BSL/L3/Make.m4v","Sheezy93","","","3","",""},
new string[]{"Movie","","https://bob64.vrsignlanguage.net/BSL/L3/Movie.m4v","Sheezy93","","","3","",""},
new string[]{"Name","","https://bob64.vrsignlanguage.net/BSL/L3/Name.m4v","Sheezy93","","","3","",""},
new string[]{"New","","https://bob64.vrsignlanguage.net/BSL/L3/New.m4v","Sheezy93","","","3","",""},
new string[]{"Old","","https://bob64.vrsignlanguage.net/BSL/L3/Old.m4v","Sheezy93","","","3","",""},
new string[]{"People","","https://bob64.vrsignlanguage.net/BSL/L3/People.m4v","Sheezy93","","","3","",""},
new string[]{"Person","","https://bob64.vrsignlanguage.net/BSL/L3/Person.m4v","Sheezy93","","","3","",""},
new string[]{"Play","","https://bob64.vrsignlanguage.net/BSL/L3/Play.m4v","Sheezy93","","","3","",""},
new string[]{"Play game","","https://bob64.vrsignlanguage.net/BSL/L3/Play_game.m4v","Sheezy93","","","3","",""},
new string[]{"Read","","https://bob64.vrsignlanguage.net/BSL/L3/Read.m4v","Sheezy93","","","3","",""},
new string[]{"Repeat","","https://bob64.vrsignlanguage.net/BSL/L3/Repeat.m4v","Sheezy93","","","3","",""},
new string[]{"Rude","","https://bob64.vrsignlanguage.net/BSL/L3/Rude.m4v","Sheezy93","","","3","",""},
new string[]{"Same (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L3/Same_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Same (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L3/Same_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Sign","","https://bob64.vrsignlanguage.net/BSL/L3/Sign.m4v","Sheezy93","","","3","",""},
new string[]{"Slow","","https://bob64.vrsignlanguage.net/BSL/L3/Slow.m4v","Sheezy93","","","3","",""},
new string[]{"Stop (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L3/Stop_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Stop (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L3/Stop_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Student","","https://bob64.vrsignlanguage.net/BSL/L3/Student.m4v","Sheezy93","","","3","",""},
new string[]{"Teach","","https://bob64.vrsignlanguage.net/BSL/L3/Teach.m4v","Sheezy93","","","3","",""},
new string[]{"Teacher","","https://bob64.vrsignlanguage.net/BSL/L3/Teacher.m4v","Sheezy93","","","3","",""},
new string[]{"Understand","","https://bob64.vrsignlanguage.net/BSL/L3/Understand.m4v","Sheezy93","","","3","",""},
new string[]{"Very","","https://bob64.vrsignlanguage.net/BSL/L3/Very.m4v","Sheezy93","","","3","",""},
new string[]{"Watch","","https://bob64.vrsignlanguage.net/BSL/L3/Watch.m4v","Sheezy93","","","3","",""},
new string[]{"Work","","https://bob64.vrsignlanguage.net/BSL/L3/Work.m4v","Sheezy93","","","3","",""},
new string[]{"Write","","https://bob64.vrsignlanguage.net/BSL/L3/Write.m4v","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 4 - People
new string[]{"Adult","","https://bob64.vrsignlanguage.net/BSL/L4/Adult.m4v","Sheezy93","","","3","",""},
new string[]{"Age","","https://bob64.vrsignlanguage.net/BSL/L4/Age.m4v","Sheezy93","","","3","",""},
new string[]{"Anyone","","https://bob64.vrsignlanguage.net/BSL/L4/Anyone.m4v","Sheezy93","","","3","",""},
new string[]{"Aunt","","https://bob64.vrsignlanguage.net/BSL/L4/Aunt.m4v","Sheezy93","","","3","",""},
new string[]{"Baby","","https://bob64.vrsignlanguage.net/BSL/L4/Baby.m4v","Sheezy93","","","3","",""},
new string[]{"Birthday","","https://bob64.vrsignlanguage.net/BSL/L4/Birthday.m4v","Sheezy93","","","3","",""},
new string[]{"Born","","https://bob64.vrsignlanguage.net/BSL/L4/Born.m4v","Sheezy93","","","3","",""},
new string[]{"Boy","","https://bob64.vrsignlanguage.net/BSL/L4/Boy.m4v","Sheezy93","","","3","",""},
new string[]{"Brother-in-law","","https://bob64.vrsignlanguage.net/BSL/L4/Brother-in-law.m4v","Sheezy93","","","3","",""},
new string[]{"Brother","","https://bob64.vrsignlanguage.net/BSL/L4/Brother.m4v","Sheezy93","","","3","",""},
new string[]{"Celebrate","","https://bob64.vrsignlanguage.net/BSL/L4/Celebrate.m4v","Sheezy93","","","3","",""},
new string[]{"Child","","https://bob64.vrsignlanguage.net/BSL/L4/Child.m4v","Sheezy93","","","3","",""},
new string[]{"Dead","","https://bob64.vrsignlanguage.net/BSL/L4/Dead.m4v","Sheezy93","","","3","",""},
new string[]{"Divorce","","https://bob64.vrsignlanguage.net/BSL/L4/Divorce.m4v","Sheezy93","","","3","",""},
new string[]{"Enemy","","https://bob64.vrsignlanguage.net/BSL/L4/Enemy.m4v","Sheezy93","","","3","",""},
new string[]{"Everyone","","https://bob64.vrsignlanguage.net/BSL/L4/Everyone.m4v","Sheezy93","","","3","",""},
new string[]{"Family","","https://bob64.vrsignlanguage.net/BSL/L4/Family.m4v","Sheezy93","","","3","",""},
new string[]{"Father","","https://bob64.vrsignlanguage.net/BSL/L4/Father.m4v","Sheezy93","","","3","",""},
new string[]{"Girl","","https://bob64.vrsignlanguage.net/BSL/L4/Girl.m4v","Sheezy93","","","3","",""},
new string[]{"Grandma","","https://bob64.vrsignlanguage.net/BSL/L4/Grandma.m4v","Sheezy93","","","3","",""},
new string[]{"Grandpa","","https://bob64.vrsignlanguage.net/BSL/L4/Grandpa.m4v","Sheezy93","","","3","",""},
new string[]{"Interpreter","","https://bob64.vrsignlanguage.net/BSL/L4/Interpreter.m4v","Sheezy93","","","3","",""},
new string[]{"Marriage","","https://bob64.vrsignlanguage.net/BSL/L4/Marriage.m4v","Sheezy93","","","3","",""},
new string[]{"Mum (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L4/Mum_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Mum (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L4/Mum_(2).m4v","Sheezy93","","","3","",""},
new string[]{"No one","","https://bob64.vrsignlanguage.net/BSL/L4/No_one.m4v","Sheezy93","","","3","",""},
new string[]{"Old","","https://bob64.vrsignlanguage.net/BSL/L4/Old.m4v","Sheezy93","","","3","",""},
new string[]{"Parents","","https://bob64.vrsignlanguage.net/BSL/L4/Parents.m4v","Sheezy93","","","3","",""},
new string[]{"Single","","https://bob64.vrsignlanguage.net/BSL/L4/Single.m4v","Sheezy93","","","3","",""},
new string[]{"Sister-in-law","","https://bob64.vrsignlanguage.net/BSL/L4/Sister-in-law.m4v","Sheezy93","","","3","",""},
new string[]{"Sister","","https://bob64.vrsignlanguage.net/BSL/L4/Sister.m4v","Sheezy93","","","3","",""},
new string[]{"Someone","","https://bob64.vrsignlanguage.net/BSL/L4/Someone.m4v","Sheezy93","","","3","",""},
new string[]{"Teen","","https://bob64.vrsignlanguage.net/BSL/L4/Teen.m4v","Sheezy93","","","3","",""},
new string[]{"Uncle","","https://bob64.vrsignlanguage.net/BSL/L4/Uncle.m4v","Sheezy93","","","3","",""},
new string[]{"Young","","https://bob64.vrsignlanguage.net/BSL/L4/Young.m4v","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 5 - Feelings / Reactions
new string[]{"Alive","","https://bob64.vrsignlanguage.net/BSL/L5/Alive.m4v","Sheezy93","","","3","",""},
new string[]{"Angry","","https://bob64.vrsignlanguage.net/BSL/L5/Angry.m4v","Sheezy93","","","3","",""},
new string[]{"Attention","","https://bob64.vrsignlanguage.net/BSL/L5/Attention.m4v","Sheezy93","","","3","",""},
new string[]{"Awesome","","https://bob64.vrsignlanguage.net/BSL/L5/Awesome.m4v","Sheezy93","","","3","",""},
new string[]{"Bored","","https://bob64.vrsignlanguage.net/BSL/L5/Bored.m4v","Sheezy93","","","3","",""},
new string[]{"Careful","","https://bob64.vrsignlanguage.net/BSL/L5/Careful.m4v","Sheezy93","","","3","",""},
new string[]{"Confused","","https://bob64.vrsignlanguage.net/BSL/L5/Confused.m4v","Sheezy93","","","3","",""},
new string[]{"Cry","","https://bob64.vrsignlanguage.net/BSL/L5/Cry.m4v","Sheezy93","","","3","",""},
new string[]{"Curious","","https://bob64.vrsignlanguage.net/BSL/L5/Curious.m4v","Sheezy93","","","3","",""},
new string[]{"Cute","","https://bob64.vrsignlanguage.net/BSL/L5/Cute.m4v","Sheezy93","","","3","",""},
new string[]{"Disgusted","","https://bob64.vrsignlanguage.net/BSL/L5/Disgusted.m4v","Sheezy93","","","3","",""},
new string[]{"Embarassed","","https://bob64.vrsignlanguage.net/BSL/L5/Embarassed.m4v","Sheezy93","","","3","",""},
new string[]{"Enjoy","","https://bob64.vrsignlanguage.net/BSL/L5/Enjoy.m4v","Sheezy93","","","3","",""},
new string[]{"Envy","","https://bob64.vrsignlanguage.net/BSL/L5/Envy.m4v","Sheezy93","","","3","",""},
new string[]{"Excited","","https://bob64.vrsignlanguage.net/BSL/L5/Excited.m4v","Sheezy93","","","3","",""},
new string[]{"Feel","","https://bob64.vrsignlanguage.net/BSL/L5/Feel.m4v","Sheezy93","","","3","",""},
new string[]{"Fine","","https://bob64.vrsignlanguage.net/BSL/L5/Fine.m4v","Sheezy93","","","3","",""},
new string[]{"Focus","","https://bob64.vrsignlanguage.net/BSL/L5/Focus.m4v","Sheezy93","","","3","",""},
new string[]{"Friendly","","https://bob64.vrsignlanguage.net/BSL/L5/Friendly.m4v","Sheezy93","","","3","",""},
new string[]{"Great","","https://bob64.vrsignlanguage.net/BSL/L5/Great.m4v","Sheezy93","","","3","",""},
new string[]{"Happy","","https://bob64.vrsignlanguage.net/BSL/L5/Happy.m4v","Sheezy93","","","3","",""},
new string[]{"Hate (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L5/Hate_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Hate (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L5/Hate_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Hungry","","https://bob64.vrsignlanguage.net/BSL/L5/Hungry.m4v","Sheezy93","","","3","",""},
new string[]{"In love","","https://bob64.vrsignlanguage.net/BSL/L5/In_love.m4v","Sheezy93","","","3","",""},
new string[]{"Laughing","","https://bob64.vrsignlanguage.net/BSL/L5/Laughing.m4v","Sheezy93","","","3","",""},
new string[]{"Like","","https://bob64.vrsignlanguage.net/BSL/L5/Like.m4v","Sheezy93","","","3","",""},
new string[]{"Lol (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L5/Lol_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Lol (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L5/Lol_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Lonely","","https://bob64.vrsignlanguage.net/BSL/L5/Lonely.m4v","Sheezy93","","","3","",""},
new string[]{"Mean","","https://bob64.vrsignlanguage.net/BSL/L5/Mean.m4v","Sheezy93","","","3","",""},
new string[]{"Nevermind","","https://bob64.vrsignlanguage.net/BSL/L5/Nevermind.m4v","Sheezy93","","","3","",""},
new string[]{"Nice","","https://bob64.vrsignlanguage.net/BSL/L5/Nice.m4v","Sheezy93","","","3","",""},
new string[]{"Pity","","https://bob64.vrsignlanguage.net/BSL/L5/Pity.m4v","Sheezy93","","","3","",""},
new string[]{"Sad","","https://bob64.vrsignlanguage.net/BSL/L5/Sad.m4v","Sheezy93","","","3","",""},
new string[]{"Scared","","https://bob64.vrsignlanguage.net/BSL/L5/Scared.m4v","Sheezy93","","","3","",""},
new string[]{"Shame","","https://bob64.vrsignlanguage.net/BSL/L5/Shame.m4v","Sheezy93","","","3","",""},
new string[]{"Shy","","https://bob64.vrsignlanguage.net/BSL/L5/Shy.m4v","Sheezy93","","","3","",""},
new string[]{"Sleepy","","https://bob64.vrsignlanguage.net/BSL/L5/Sleepy.m4v","Sheezy93","","","3","",""},
new string[]{"Smart","","https://bob64.vrsignlanguage.net/BSL/L5/Smart.m4v","Sheezy93","","","3","",""},
new string[]{"Stressed (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L5/Stressed_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Stressed (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L5/Stressed_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Struggle","","https://bob64.vrsignlanguage.net/BSL/L5/Struggle.m4v","Sheezy93","","","3","",""},
new string[]{"Suffering","","https://bob64.vrsignlanguage.net/BSL/L5/Suffering.m4v","Sheezy93","","","3","",""},
new string[]{"Surprised","","https://bob64.vrsignlanguage.net/BSL/L5/Surprised.m4v","Sheezy93","","","3","",""},
new string[]{"Tired","","https://bob64.vrsignlanguage.net/BSL/L5/Tired.m4v","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 6 - Value
new string[]{"After","","https://bob64.vrsignlanguage.net/BSL/L6/After.m4v","Sheezy93","","","3","",""},
new string[]{"All","","https://bob64.vrsignlanguage.net/BSL/L6/All.m4v","Sheezy93","","","3","",""},
new string[]{"Always (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L6/Always_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Always (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L6/Always_(2).m4v","Sheezy93","","","3","",""},
new string[]{"A little","","https://bob64.vrsignlanguage.net/BSL/L6/A_little.m4v","Sheezy93","","","3","",""},
new string[]{"A lot","","https://bob64.vrsignlanguage.net/BSL/L6/A_lot.m4v","Sheezy93","","","3","",""},
new string[]{"Before (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L6/Before_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Before (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L6/Before_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Big","","https://bob64.vrsignlanguage.net/BSL/L6/Big.m4v","Sheezy93","","","3","",""},
new string[]{"Busy","","https://bob64.vrsignlanguage.net/BSL/L6/Busy.m4v","Sheezy93","","","3","",""},
new string[]{"Empty","","https://bob64.vrsignlanguage.net/BSL/L6/Empty.m4v","Sheezy93","","","3","",""},
new string[]{"Ever","","https://bob64.vrsignlanguage.net/BSL/L6/Ever.m4v","Sheezy93","","","3","",""},
new string[]{"Everything","","https://bob64.vrsignlanguage.net/BSL/L6/Everything.m4v","Sheezy93","","","3","",""},
new string[]{"Everytime","","https://bob64.vrsignlanguage.net/BSL/L6/Everytime.m4v","Sheezy93","","","3","",""},
new string[]{"Fat","","https://bob64.vrsignlanguage.net/BSL/L6/Fat.m4v","Sheezy93","","","3","",""},
new string[]{"First","","https://bob64.vrsignlanguage.net/BSL/L6/First.m4v","Sheezy93","","","3","",""},
new string[]{"Free","","https://bob64.vrsignlanguage.net/BSL/L6/Free.m4v","Sheezy93","","","3","",""},
new string[]{"Full (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L6/Full_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Full (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L6/Full_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Half","","https://bob64.vrsignlanguage.net/BSL/L6/Half.m4v","Sheezy93","","","3","",""},
new string[]{"Hard","","https://bob64.vrsignlanguage.net/BSL/L6/Hard.m4v","Sheezy93","","","3","",""},
new string[]{"Heavy","","https://bob64.vrsignlanguage.net/BSL/L6/Heavy.m4v","Sheezy93","","","3","",""},
new string[]{"High","","https://bob64.vrsignlanguage.net/BSL/L6/High.m4v","Sheezy93","","","3","",""},
new string[]{"Last","","https://bob64.vrsignlanguage.net/BSL/L6/Last.m4v","Sheezy93","","","3","",""},
new string[]{"Less","","https://bob64.vrsignlanguage.net/BSL/L6/Less.m4v","Sheezy93","","","3","",""},
new string[]{"Lightweight","","https://bob64.vrsignlanguage.net/BSL/L6/Lightweight.m4v","Sheezy93","","","3","",""},
new string[]{"Limited","","https://bob64.vrsignlanguage.net/BSL/L6/Limited.m4v","Sheezy93","","","3","",""},
new string[]{"Long","","https://bob64.vrsignlanguage.net/BSL/L6/Long.m4v","Sheezy93","","","3","",""},
new string[]{"Low","","https://bob64.vrsignlanguage.net/BSL/L6/Low.m4v","Sheezy93","","","3","",""},
new string[]{"Many","","https://bob64.vrsignlanguage.net/BSL/L6/Many.m4v","Sheezy93","","","3","",""},
new string[]{"More","","https://bob64.vrsignlanguage.net/BSL/L6/More.m4v","Sheezy93","","","3","",""},
new string[]{"Next","","https://bob64.vrsignlanguage.net/BSL/L6/Next.m4v","Sheezy93","","","3","",""},
new string[]{"Nothing (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L6/Nothing_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Nothing (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L6/Nothing_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Often","","https://bob64.vrsignlanguage.net/BSL/L6/Often.m4v","Sheezy93","","","3","",""},
new string[]{"Quarter","","https://bob64.vrsignlanguage.net/BSL/L6/Quarter.m4v","Sheezy93","","","3","",""},
new string[]{"Second","","https://bob64.vrsignlanguage.net/BSL/L6/Second.m4v","Sheezy93","","","3","",""},
new string[]{"Short","","https://bob64.vrsignlanguage.net/BSL/L6/Short.m4v","Sheezy93","","","3","",""},
new string[]{"Small","","https://bob64.vrsignlanguage.net/BSL/L6/Small.m4v","Sheezy93","","","3","",""},
new string[]{"Soft","","https://bob64.vrsignlanguage.net/BSL/L6/Soft.m4v","Sheezy93","","","3","",""},
new string[]{"Sometimes (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L6/Sometimes_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Sometimes (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L6/Sometimes_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Strong (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L6/Strong_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Strong (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L6/Strong_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Thin","","https://bob64.vrsignlanguage.net/BSL/L6/Thin.m4v","Sheezy93","","","3","",""},
new string[]{"Third","","https://bob64.vrsignlanguage.net/BSL/L6/Third.m4v","Sheezy93","","","3","",""},
new string[]{"Unlimited","","https://bob64.vrsignlanguage.net/BSL/L6/Unlimited.m4v","Sheezy93","","","3","",""},
new string[]{"Value","","https://bob64.vrsignlanguage.net/BSL/L6/Value.m4v","Sheezy93","","","3","",""},
new string[]{"Weak","","https://bob64.vrsignlanguage.net/BSL/L6/Weak.m4v","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 7 - Time
new string[]{"Afternoon","","https://bob64.vrsignlanguage.net/BSL/L7/Afternoon.m4v","Sheezy93","","","3","",""},
new string[]{"All day","","https://bob64.vrsignlanguage.net/BSL/L7/All_day.m4v","Sheezy93","","","3","",""},
new string[]{"All night","","https://bob64.vrsignlanguage.net/BSL/L7/All_night.m4v","Sheezy93","","","3","",""},
new string[]{"Autumn (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L7/Autumn_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Autumn (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L7/Autumn_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Break (time) (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L7/Break_(time)_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Break (time) (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L7/Break_(time)_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Day","","https://bob64.vrsignlanguage.net/BSL/L7/Day.m4v","Sheezy93","","","3","",""},
new string[]{"Evening (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L7/Evening_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Evening (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L7/Evening_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Friday","","https://bob64.vrsignlanguage.net/BSL/L7/Friday.m4v","Sheezy93","","","3","",""},
new string[]{"Hours (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L7/Hours_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Hours (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L7/Hours_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Later","","https://bob64.vrsignlanguage.net/BSL/L7/Later.m4v","Sheezy93","","","3","",""},
new string[]{"Late afternoon","","https://bob64.vrsignlanguage.net/BSL/L7/Late_afternoon.m4v","Sheezy93","","","3","",""},
new string[]{"Midweek","","https://bob64.vrsignlanguage.net/BSL/L7/Midweek.m4v","Sheezy93","","","3","",""},
new string[]{"Minutes","","https://bob64.vrsignlanguage.net/BSL/L7/Minutes.m4v","Sheezy93","","","3","",""},
new string[]{"Monday","","https://bob64.vrsignlanguage.net/BSL/L7/Monday.m4v","Sheezy93","","","3","",""},
new string[]{"Month","","https://bob64.vrsignlanguage.net/BSL/L7/Month.m4v","Sheezy93","","","3","",""},
new string[]{"Morning","","https://bob64.vrsignlanguage.net/BSL/L7/Morning.m4v","Sheezy93","","","3","",""},
new string[]{"Never","","https://bob64.vrsignlanguage.net/BSL/L7/Never.m4v","Sheezy93","","","3","",""},
new string[]{"Next week","","https://bob64.vrsignlanguage.net/BSL/L7/Next_week.m4v","Sheezy93","","","3","",""},
new string[]{"Night","","https://bob64.vrsignlanguage.net/BSL/L7/Night.m4v","Sheezy93","","","3","",""},
new string[]{"Now","","https://bob64.vrsignlanguage.net/BSL/L7/Now.m4v","Sheezy93","","","3","",""},
new string[]{"Saturday","","https://bob64.vrsignlanguage.net/BSL/L7/Saturday.m4v","Sheezy93","","","3","",""},
new string[]{"Season","","https://bob64.vrsignlanguage.net/BSL/L7/Season.m4v","Sheezy93","","","3","",""},
new string[]{"Seconds","","https://bob64.vrsignlanguage.net/BSL/L7/Seconds.m4v","Sheezy93","","","3","",""},
new string[]{"Soon","","https://bob64.vrsignlanguage.net/BSL/L7/Soon.m4v","Sheezy93","","","3","",""},
new string[]{"Spring","","https://bob64.vrsignlanguage.net/BSL/L7/Spring.m4v","Sheezy93","","","3","",""},
new string[]{"Summer","","https://bob64.vrsignlanguage.net/BSL/L7/Summer.m4v","Sheezy93","","","3","",""},
new string[]{"Sunday","","https://bob64.vrsignlanguage.net/BSL/L7/Sunday.m4v","Sheezy93","","","3","",""},
new string[]{"Sunrise","","https://bob64.vrsignlanguage.net/BSL/L7/Sunrise.m4v","Sheezy93","","","3","",""},
new string[]{"Sunset","","https://bob64.vrsignlanguage.net/BSL/L7/Sunset.m4v","Sheezy93","","","3","",""},
new string[]{"Thursday","","https://bob64.vrsignlanguage.net/BSL/L7/Thursday.m4v","Sheezy93","","","3","",""},
new string[]{"Time","","https://bob64.vrsignlanguage.net/BSL/L7/Time.m4v","Sheezy93","","","3","",""},
new string[]{"Today","","https://bob64.vrsignlanguage.net/BSL/L7/Today.m4v","Sheezy93","","","3","",""},
new string[]{"Tomorrow","","https://bob64.vrsignlanguage.net/BSL/L7/Tomorrow.m4v","Sheezy93","","","3","",""},
new string[]{"Tuesday","","https://bob64.vrsignlanguage.net/BSL/L7/Tuesday.m4v","Sheezy93","","","3","",""},
new string[]{"Wednesday","","https://bob64.vrsignlanguage.net/BSL/L7/Wednesday.m4v","Sheezy93","","","3","",""},
new string[]{"Weekend","","https://bob64.vrsignlanguage.net/BSL/L7/Weekend.m4v","Sheezy93","","","3","",""},
new string[]{"Week (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L7/Week_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Week (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L7/Week_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Winter","","https://bob64.vrsignlanguage.net/BSL/L7/Winter.m4v","Sheezy93","","","3","",""},
new string[]{"Year","","https://bob64.vrsignlanguage.net/BSL/L7/Year.m4v","Sheezy93","","","3","",""},
new string[]{"Yesterday","","https://bob64.vrsignlanguage.net/BSL/L7/Yesterday.m4v","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 8 - VRChat
new string[]{"Add friend","","https://bob64.vrsignlanguage.net/BSL/L8/Add_friend.m4v","Sheezy93","","","3","",""},
new string[]{"Add friend (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Add_friend_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Avatar","","https://bob64.vrsignlanguage.net/BSL/L8/Avatar.m4v","Sheezy93","","","3","",""},
new string[]{"Block","","https://bob64.vrsignlanguage.net/BSL/L8/Block.m4v","Sheezy93","","","3","",""},
new string[]{"Camera (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Camera_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Camera (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Camera_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Cancel","","https://bob64.vrsignlanguage.net/BSL/L8/Cancel.m4v","Sheezy93","","","3","",""},
new string[]{"Climbing","","https://bob64.vrsignlanguage.net/BSL/L8/Climbing.m4v","Sheezy93","","","3","",""},
new string[]{"Computer","","https://bob64.vrsignlanguage.net/BSL/L8/Computer.m4v","Sheezy93","","","3","",""},
new string[]{"Crash","","https://bob64.vrsignlanguage.net/BSL/L8/Crash.m4v","Sheezy93","","","3","",""},
new string[]{"Desktop (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Desktop_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Desktop (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Desktop_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Discord","","https://bob64.vrsignlanguage.net/BSL/L8/Discord.m4v","Sheezy93","","","3","",""},
new string[]{"Donation (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Donation_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Donation (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Donation_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Event","","https://bob64.vrsignlanguage.net/BSL/L8/Event.m4v","Sheezy93","","","3","",""},
new string[]{"Falling","","https://bob64.vrsignlanguage.net/BSL/L8/Falling.m4v","Sheezy93","","","3","",""},
new string[]{"Gestures","","https://bob64.vrsignlanguage.net/BSL/L8/Gestures.m4v","Sheezy93","","","3","",""},
new string[]{"Headset (VR)","","https://bob64.vrsignlanguage.net/BSL/L8/Headset_(VR).m4v","Sheezy93","","","3","",""},
new string[]{"Hide","","https://bob64.vrsignlanguage.net/BSL/L8/Hide.m4v","Sheezy93","","","3","",""},
new string[]{"Invite","","https://bob64.vrsignlanguage.net/BSL/L8/Invite.m4v","Sheezy93","","","3","",""},
new string[]{"Join (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Join_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Join (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Join_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Lagging (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Lagging_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Lagging (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Lagging_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Leave (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Leave_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Leave (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Leave_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Login (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Login_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Login (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Login_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Logout","","https://bob64.vrsignlanguage.net/BSL/L8/Logout.m4v","Sheezy93","","","3","",""},
new string[]{"Menu","","https://bob64.vrsignlanguage.net/BSL/L8/Menu.m4v","Sheezy93","","","3","",""},
new string[]{"Offline","","https://bob64.vrsignlanguage.net/BSL/L8/Offline.m4v","Sheezy93","","","3","",""},
new string[]{"Online","","https://bob64.vrsignlanguage.net/BSL/L8/Online.m4v","Sheezy93","","","3","",""},
new string[]{"Photo (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Photo_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Photo (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Photo_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Portal","","https://bob64.vrsignlanguage.net/BSL/L8/Portal.m4v","Sheezy93","","","3","",""},
new string[]{"Private","","https://bob64.vrsignlanguage.net/BSL/L8/Private.m4v","Sheezy93","","","3","",""},
new string[]{"Public","","https://bob64.vrsignlanguage.net/BSL/L8/Public.m4v","Sheezy93","","","3","",""},
new string[]{"Receive (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Receive_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Receive (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Receive_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Recharge","","https://bob64.vrsignlanguage.net/BSL/L8/Recharge.m4v","Sheezy93","","","3","",""},
new string[]{"Record","","https://bob64.vrsignlanguage.net/BSL/L8/Record.m4v","Sheezy93","","","3","",""},
new string[]{"Restart","","https://bob64.vrsignlanguage.net/BSL/L8/Restart.m4v","Sheezy93","","","3","",""},
new string[]{"Schedule","","https://bob64.vrsignlanguage.net/BSL/L8/Schedule.m4v","Sheezy93","","","3","",""},
new string[]{"Security","","https://bob64.vrsignlanguage.net/BSL/L8/Security.m4v","Sheezy93","","","3","",""},
new string[]{"Send","","https://bob64.vrsignlanguage.net/BSL/L8/Send.m4v","Sheezy93","","","3","",""},
new string[]{"Streaming","","https://bob64.vrsignlanguage.net/BSL/L8/Streaming.m4v","Sheezy93","","","3","",""},
new string[]{"Visit (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Visit_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Visit (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Visit_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Walk (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L8/Walk_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Walk (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L8/Walk_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Walk (Variant 3)","","https://bob64.vrsignlanguage.net/BSL/L8/Walk_(3).m4v","Sheezy93","","","3","",""},
new string[]{"Walk (Variant 4)","","https://bob64.vrsignlanguage.net/BSL/L8/Walk_(4).m4v","Sheezy93","","","3","",""},
new string[]{"World","","https://bob64.vrsignlanguage.net/BSL/L8/World.m4v","Sheezy93","","","3","",""},
},//end of lesson
new string[][]{//BSL Lesson 9 - Alphabet / Numbers
new string[]{"A","","https://bob64.vrsignlanguage.net/BSL/L9/A.m4v","Sheezy93","","","3","",""},
new string[]{"B","","https://bob64.vrsignlanguage.net/BSL/L9/B.m4v","Sheezy93","","","3","",""},
new string[]{"C (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L9/C_(1).m4v","Sheezy93","","","3","",""},
new string[]{"C (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L9/C_(2).m4v","Sheezy93","","","3","",""},
new string[]{"D (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L9/D_(1).m4v","Sheezy93","","","3","",""},
new string[]{"D (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L9/D_(2).m4v","Sheezy93","","","3","",""},
new string[]{"E","","https://bob64.vrsignlanguage.net/BSL/L9/E.m4v","Sheezy93","","","3","",""},
new string[]{"F","","https://bob64.vrsignlanguage.net/BSL/L9/F.m4v","Sheezy93","","","3","",""},
new string[]{"G","","https://bob64.vrsignlanguage.net/BSL/L9/G.m4v","Sheezy93","","","3","",""},
new string[]{"H","","https://bob64.vrsignlanguage.net/BSL/L9/H.m4v","Sheezy93","","","3","",""},
new string[]{"I","","https://bob64.vrsignlanguage.net/BSL/L9/I.m4v","Sheezy93","","","3","",""},
new string[]{"J","","https://bob64.vrsignlanguage.net/BSL/L9/J.m4v","Sheezy93","","","3","",""},
new string[]{"K","","https://bob64.vrsignlanguage.net/BSL/L9/K.m4v","Sheezy93","","","3","",""},
new string[]{"L","","https://bob64.vrsignlanguage.net/BSL/L9/L.m4v","Sheezy93","","","3","",""},
new string[]{"M (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L9/M_(1).m4v","Sheezy93","","","3","",""},
new string[]{"M (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L9/M_(2).m4v","Sheezy93","","","3","",""},
new string[]{"N","","https://bob64.vrsignlanguage.net/BSL/L9/N.m4v","Sheezy93","","","3","",""},
new string[]{"O","","https://bob64.vrsignlanguage.net/BSL/L9/O.m4v","Sheezy93","","","3","",""},
new string[]{"P","","https://bob64.vrsignlanguage.net/BSL/L9/P.m4v","Sheezy93","","","3","",""},
new string[]{"Q","","https://bob64.vrsignlanguage.net/BSL/L9/Q.m4v","Sheezy93","","","3","",""},
new string[]{"R","","https://bob64.vrsignlanguage.net/BSL/L9/R.m4v","Sheezy93","","","3","",""},
new string[]{"S","","https://bob64.vrsignlanguage.net/BSL/L9/S.m4v","Sheezy93","","","3","",""},
new string[]{"T","","https://bob64.vrsignlanguage.net/BSL/L9/T.m4v","Sheezy93","","","3","",""},
new string[]{"U","","https://bob64.vrsignlanguage.net/BSL/L9/U.m4v","Sheezy93","","","3","",""},
new string[]{"V","","https://bob64.vrsignlanguage.net/BSL/L9/V.m4v","Sheezy93","","","3","",""},
new string[]{"W","","https://bob64.vrsignlanguage.net/BSL/L9/W.m4v","Sheezy93","","","3","",""},
new string[]{"X","","https://bob64.vrsignlanguage.net/BSL/L9/X.m4v","Sheezy93","","","3","",""},
new string[]{"Y","","https://bob64.vrsignlanguage.net/BSL/L9/Y.m4v","Sheezy93","","","3","",""},
new string[]{"Z","","https://bob64.vrsignlanguage.net/BSL/L9/Z.m4v","Sheezy93","","","3","",""},
new string[]{"Comma","","https://bob64.vrsignlanguage.net/BSL/L9/Comma.m4v","Sheezy93","","","3","",""},
new string[]{"Exclamation mark","","https://bob64.vrsignlanguage.net/BSL/L9/Exclamation_mark.m4v","Sheezy93","","","3","",""},
new string[]{"Question mark (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L9/Question_mark_(1).m4v","Sheezy93","","","3","",""},
new string[]{"Question mark (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L9/Question_mark_(2).m4v","Sheezy93","","","3","",""},
new string[]{"Space","","https://bob64.vrsignlanguage.net/BSL/L9/Space.m4v","Sheezy93","","","3","",""},
new string[]{"0","","https://bob64.vrsignlanguage.net/BSL/L9/0.m4v","Sheezy93","","","3","",""},
new string[]{"1","","https://bob64.vrsignlanguage.net/BSL/L9/1.m4v","Sheezy93","","","3","",""},
new string[]{"2","","https://bob64.vrsignlanguage.net/BSL/L9/2.m4v","Sheezy93","","","3","",""},
new string[]{"3","","https://bob64.vrsignlanguage.net/BSL/L9/3.m4v","Sheezy93","","","3","",""},
new string[]{"4","","https://bob64.vrsignlanguage.net/BSL/L9/4.m4v","Sheezy93","","","3","",""},
new string[]{"5","","https://bob64.vrsignlanguage.net/BSL/L9/5.m4v","Sheezy93","","","3","",""},
new string[]{"6","","https://bob64.vrsignlanguage.net/BSL/L9/6.m4v","Sheezy93","","","3","",""},
new string[]{"7","","https://bob64.vrsignlanguage.net/BSL/L9/7.m4v","Sheezy93","","","3","",""},
new string[]{"8","","https://bob64.vrsignlanguage.net/BSL/L9/8.m4v","Sheezy93","","","3","",""},
new string[]{"9 (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L9/9_(1).m4v","Sheezy93","","","3","",""},
new string[]{"9 (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L9/9_(2).m4v","Sheezy93","","","3","",""},
new string[]{"10","","https://bob64.vrsignlanguage.net/BSL/L9/10.m4v","Sheezy93","","","3","",""},
new string[]{"100","","https://bob64.vrsignlanguage.net/BSL/L9/100.m4v","Sheezy93","","","3","",""},
new string[]{"1000000","","https://bob64.vrsignlanguage.net/BSL/L9/1000000.m4v","Sheezy93","","","3","",""},
new string[]{"1000 (Variant 1)","","https://bob64.vrsignlanguage.net/BSL/L9/1000_(1).m4v","Sheezy93","","","3","",""},
new string[]{"1000 (Variant 2)","","https://bob64.vrsignlanguage.net/BSL/L9/1000_(2).m4v","Sheezy93","","","3","",""},





},//end of lesson
},//end of lang
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
},//end of lang 
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

        Color COLORBLIND_BLUE = new Color32(109, 158, 235, 1);
        Color COLORBLIND_RED = new Color32(235, 36, 6, 1);
        Color COLORBLIND_GREEN = new Color32(191, 235, 66, 1);
        Color COLORBLIND_PURPLE = new Color32(179, 36, 240, 1);

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
            Debug.Log("floatnormnalizedtohext:" + Mathf.RoundToInt(value * 255f));
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
	Update Menu Variables used to control displays.
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
        //Debug.Log("Entered _BackButtonPushed");
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
            quizanswer = UnityEngine.Random.Range(0, 4);//pick one of the 4 boxes to have the answer 0-3
            int quizwrong1 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            int quizwrong2 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            int quizwrong3 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            //prevent the same answer on multiple boxes.
            while (
                quizwrong1 == quizcounter | //don't be the same as the answer
                AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayvariant] != ""| //todo, add "base word" for script to check against to avoid pulling variants.
                AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword].Contains("/") |
                AllLessons[quizwordmapping[quizwrong1][0]][quizwordmapping[quizwrong1][1]][quizwordmapping[quizwrong1][2]][arrayword] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] //prevent the same answer on multiple boxes.
                )
            {
                quizwrong1 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            }
            while (quizwrong2 == quizcounter | //don't be the same as the answer
                quizwrong2 == quizwrong1 | //don't be the same as box 1
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayvariant] != "" |
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword].Contains("/") |
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword] //prevent the same answer on multiple boxes.
                )
            {
                quizwrong2 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            }
            while (quizwrong3 == quizcounter | //don't be the same as the answer
                quizwrong3 == quizwrong1 | //don't be the same as box 1
                quizwrong3 == quizwrong2 | //don't be the same as box 2
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayvariant] != "" |
                AllLessons[quizwordmapping[quizwrong2][0]][quizwordmapping[quizwrong2][1]][quizwordmapping[quizwrong2][2]][arrayword].Contains("/") |
                AllLessons[quizwordmapping[quizwrong3][0]][quizwordmapping[quizwrong3][1]][quizwordmapping[quizwrong3][2]][arrayword] == AllLessons[quizwordmapping[quizcounter][0]][quizwordmapping[quizcounter][1]][quizwordmapping[quizcounter][2]][arrayword]  //prevent the same answer on multiple boxes.
                )
            {
                quizwrong3 = UnityEngine.Random.Range(0, quizwordmapping.Length);
            }
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
                }
            

        }

    }


    /***************************************************************************************************************************
	Figures out what the button does, and sends to the approperate functions to update the menu.
	***************************************************************************************************************************/
    private void _buttonpushed(int buttonIndex)
    {
        //Debug.Log("Entered _buttonpushed(" + buttonIndex + ")");

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
            signingavatars.transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(1, 1, 1));

        }
        else
        {
            signingavatars.transform.localScale = Vector3.Scale(new Vector3(avatarscaleslider.value, avatarscaleslider.value, avatarscaleslider.value), new Vector3(-1, 1, 1));
        }


    }

    /***************************************************************************************************************************
	Called to switch the board to global mode and set the toggle box state
	***************************************************************************************************************************/
    public void _ToggleGlobal()
    {
        globalmode = !globalmode;
        _UpdateMenuVariables(NOT_SELECTED);
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
                            wordurls[z] = new VRCUrl(inspectorBehaviour.AllLessons[x][y][z][arrayurl]);
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
                            worddata.Add(inspectorBehaviour.AllLessons[0][x][y][arrayword]);
                            //Debug.Log(inspectorBehaviour.AllLessons[0][x][y][0]  + " L" + (x+1) + "-" + (y+1));
                            worddata.Add("L" + (x + 1) + "-" + (y + 1));
                            listofallwords.Add(worddata);

                            //add errata data
                            if (inspectorBehaviour.AllLessons[0][x][y][8] != "")
                            {
                                erratatext = erratatext + "\nL" + (x + 1) + "-" + (y + 1) + " [" + inspectorBehaviour.AllLessons[0][x][y][arrayword] + "]: " + inspectorBehaviour.AllLessons[0][x][y][arrayvalidationcomment] +"\n";
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