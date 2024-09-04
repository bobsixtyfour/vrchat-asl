// -*- coding: utf-8 -*-
//
// MIT License
//
// Copyright (c) 2022 Devon (Gorialis) R
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

/*
 * ====================================================================
 * 
 * 888    888 .d88888b. 888     8888888b.    888     8888888888b.    88
 * 888    888d88P" "Y88b888     888  "Y88b   888     888888   Y88b   88
 * 888    888888     888888     888    888   888     888888    888   88
 * 8888888888888     888888     888    888   888     888888   d88P   88
 * 888    888888     888888     888    888   888     8888888888P"    88
 * 888    888888     888888     888    888   888     888888          88
 * 888    888Y88b. .d88P888     888  .d88P   Y88b. .d88P888          
 * 888    888 "Y88888P" 888888888888888P"     "Y88888P" 888          88
 * 
 * ====================================================================
 * 
 * I see you're editing this file, and that's great.
 * 
 * But for the sake of keeping worlds in sync and the tag a reliable authority,
 * I'd really prefer if you told me (devon#4089) why you feel the need to edit it.
 * 
 * If there's some user entry mistake or an error you're experiencing,
 * telling me will let me fix it for everyone.
 * 
 * As for other tweaks, I'd prefer if we talk about them, because consistency matters.
 * 
 * The tag loses a lot of its authoritative power if everyone has their own version!
 * 
 */

using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using TMPro;
using static System.Net.WebRequestMethods;
using VRC.SDK3.StringLoading;
using VRC.Udon.Common.Interfaces;
using VRC.SDK3.Data;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class FluentVerifTag : UdonSharpBehaviour
{
    Color[] colorAssignments =
    {
        //                                   | The alpha channel controls whether the color should be a gradient or standalone
        //                                   | So 0.0f means it makes a gradient with purple, 1.0f means it's entirely on its own. Gradient seems to give an "extra fancy" feel. Wonder if this should be reserved for Fluent Teachers?
        new Color(0.5179f, 0.3076f, 0.8666f, 1.0f), // Purple (Fluent Teacher)
        new Color(0.0000f, 0.5000f, 1.0000f, 0.0f), // Purple & Blue (Fluent, but not teacher)
        //new Color(1.0000f, 0.5000f, 0.0000f, 1.0f), // Orange (Organizer or other)
        new Color(0.8430f, 0.7840f, 0.1170f, 1.0f), // Yellow (Organizer or other) -Bob, let's try a darker shade of yellow.
        //new Color(0.3000f, 0.3000f, 0.7000f, 1.0f), // Blue (World Contributor or other) - I think blue might over-lap with the Fluent gradient, so let's try Green -Bob
        new Color(0.3000f, 0.7000f, 0.3000f, 1.0f), // Green (World Contributor or other) -Bob
        new Color(1.0000f, 0.7650f, 0.0430f, 0.0f), // Purple/Orange Gradient -Bob
    };

    string[][] trustedPlayerData = new string[][] {
        //           | Display name             | Label                     | Color index
        new string[] { "Ray_is_Deaf",           "Fluent ASL Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_ba08403f-f61c-4b39-8ec5-7bc35cf4c502
	    new string[] { "DmTheMechanic",         "Fluent ASL Teacher\n<size=60%>World Contributor",      "0" }, // https://vrchat.com/home/user/usr_a35f9fb9-e0d9-41af-81fc-4b5b3b808e26
        new string[] { "ShadeAxas",             "Fluent ASL Interpreter\n<size=60%>World Contributor",      "0" }, // https://vrchat.com/home/user/usr_d9441a3a-70ba-4192-b0a3-c1a3d239af3a
        new string[] { "CODApop",               "Fluent ASL Teacher\n<size=60%>World Contributor",      "0" }, // https://vrchat.com/home/user/usr_f8569f57-e216-4a6f-860a-e599121ac88c
        new string[] { "Jenny0629",             "Fluent ASL Teacher\n<size=60%>World Contributor",      "0" }, // https://vrchat.com/home/user/usr_1b646a08-1337-4477-9d2d-21f31ea294fd
        new string[] { "Starbun∗",              "Fluent ASL Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_c5ac2c37-eaf4-48f5-bc8b-a030571260d5
        new string[] { "Crow_Se7en",            "Fluent ASL Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_676c1ff7-7ee0-466f-a2a3-376e6e7c886e
        new string[] { "Amaranteアマランテ", "Fluent ASL Teacher\n<size=60%>World Contributor",          "0" }, // https://vrchat.com/home/user/usr_318faecf-b1f5-42c4-bf17-4f70c216a32d
        new string[] { "ZadeTheCheetah", "Fluent ASL Teacher\n<size=60%>World Contributor",       "0" }, // https://vrchat.com/home/user/usr_1b92ffd8-251c-42df-874b-ab8c5b0540ff
        new string[] { "Nemsi", "Fluent ASL Teacher\n<size=60%>World Contributor",        "0" },//https://vrchat.com/home/user/usr_860f160a-6a63-4e62-bc46-fdf47556c232
        new string[] { "wardragon",             "Fluent ASL Member",                                   "1" }, // https://vrchat.com/home/user/usr_64388751-f57a-448a-99b2-49d5d493e576
        

        new string[] { "Catsgirl_nya", "Fluent ASL Member\n<size=60%>World Contributor",        "1" },//https://vrchat.com/home/user/usr_a2aaa348-0c4d-45fb-a9d7-6a9982128c6d
        new string[] { "Sio",            "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_b831299d-d8d2-43d9-90fd-45627276eda9
        new string[] { "Tripleβ",            "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_5264a13f-0d13-4c15-a35a-0307abc7ad43
        new string[] { "SlyNikki14",            "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_8da843be-4145-438c-bc78-4e07afe184e1
        new string[] { "Niccitric",             "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_9d00d552-0aeb-41a6-a416-cc8cc1a3b922
        new string[] { "ChristianNar",          "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_531c03f5-a892-4688-8286-a87b32dfda1d
        new string[] { "Danyy59（Deaf）",       "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_44f3b660-6c85-4f83-9abf-7c701c76a013
        new string[] { "-SnowDeafこにちわ-",    "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_f3216b2c-9f3f-44f7-a8b7-21b14fc84e8f
        
        new string[] { "msmallrobinson",    "Fluent ASL Member",                                    "1" }, // https://vrchat.com/home/user/usr_2951a721-a2c4-4cb0-a22d-dc8712ba3e7f
        new string[] { "エリック・グローナー",       "Fluent ASL Member",        "1" },//https://vrchat.com/home/user/usr_0beac25d-01dd-41a5-831c-419d8d583624
        new string[] { "TheDeafValkyrie",       "Fluent ASL Member",        "1" },//https://vrchat.com/home/user/usr_7a0fa563-5f7b-48f7-8230-e91126f6806f

        new string[] { "arahael",               "Fluent Auslan Member",                                 "1" }, // https://vrchat.com/home/user/usr_df47851c-f24e-48e9-b654-9ea51425d9ec

        new string[] { "sheezy93",              "Fluent BSL Teacher\n<size=60%>World Contributor",      "0" }, // https://vrchat.com/home/user/usr_1ec96bae-0e8f-40e8-a708-448cf63e4e25
        new string[] { "AvinouSCAC",            "Fluent BSL Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_b8c1c0ca-f555-4ed9-9156-667b364eebd8
        new string[] { "TachDeaf",         "Fluent BSL Teacher\n<size=60%>World Contributor",      "0" }, // https://vrchat.com/home/user/usr_6d0e717b-f173-4a7e-8ac6-5e76a0428788

        new string[] { "Remmington",            "Fluent BSL Member",                                    "1" }, // https://vrchat.com/home/user/usr_fba0ee0d-140e-4c70-b6f8-ba6f059602e5
        new string[] { "SnxDemon",              "Fluent BSL Member",                                    "1" }, // https://vrchat.com/home/user/usr_f7ff8050-1837-4d0f-b7e6-68b9cb7ecb58
        new string[] { "GHOSTRXCV",             "Fluent BSL Member",                                    "1" }, // https://vrchat.com/home/user/usr_6c5e3a68-adb9-4683-8725-cb2a98e38b62
        new string[] { "MerryMeer",             "Fluent BSL Member",                                    "1" }, // https://vrchat.com/home/user/usr_51d90f0d-cac4-4b23-a224-7ffbfdf37e06

        new string[] { "deaf_danielo_89",       "Fluent DGS Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_1bc8cddf-805c-40d6-b6c1-bd33d8191289


        new string[] { "BTZN",       "Fluent DGS Member",                                   "1" }, // https://vrchat.com/home/user/usr_1bc8cddf-805c-40d6-b6c1-bd33d8191289
        new string[] { "Xx_Princess_xX",       "Fluent DGS Member",                                   "1" }, // https://vrchat.com/home/user/usr_0f40feb8-ecbf-496e-8abb-2fbd7abcdcad

        new string[] { "Hammy~",                "Fluent ISL Member",                                    "1" }, // https://vrchat.com/home/user/usr_e4cab634-c383-431a-978e-0674bb62d5da

        new string[] { "ラファエルRafael",       "Fluent JSL Teacher",                                    "0" }, // https://vrchat.com/home/user/usr_edfc606b-0ea2-48db-b761-54d709141d78



        new string[] { "Korea_Yujin",           "Fluent KSL Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_a248a89c-48b7-474c-975a-e97ffe1153d2
        //new string[] { "MintWhite¨",       "Fluent KSL Member",                                    "1" }, // https://vrchat.com/home/user/usr_b2b2b388-9379-4b47-a6f8-3de91e9453a5

        new string[] { "hppedeaf", "Fluent LSF Member\n<size=60%>World Contributor",      "1" }, // https://vrchat.com/home/user/usr_50fb54ee-487e-4d0a-9c67-faffa79a6888
        
        new string[] { "Getomeulou",            "Fluent LSF Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_836dc59f-0942-40a7-b273-9bbd9d263336
        new string[] { "xKaijo",                "Fluent LSF Teacher",                                   "0" }, // https://vrchat.com/home/user/usr_dfeaafbf-f483-482e-9d80-b175543edced

        new string[] { "Jessmus84",             "Fluent LSF Member",                                    "1" }, // https://vrchat.com/home/user/usr_49746975-184d-4353-ab42-027c2f7a0f1f
        new string[] { "MrRikuG935", "Fluent LSF Member",                                   "1" }, // https://vrchat.com/home/user/usr_881ebc1d-4e2f-435a-8029-69674ad09e94

        new string[] { "Cyberponk", "Fluent NGT Member",                                   "1" }, // https://vrchat.com/home/user/usr_50433ce0-02b4-479d-83fb-5f422f6a4526
        new string[] { "MrDummy_NL", "Fluent NGT Member\n<size=60%>HH World Creator",           "1" }, // https://vrchat.com/home/user/usr_d4d6ea8a-8ad7-4d67-af81-d58a26449cca



        new string[] { "Fazzion",               "Fluent ÖGS Member",                                    "1" }, // https://vrchat.com/home/user/usr_730c550a-736d-4204-846a-9e9ed0d63df4

        new string[] { "GT4tube", "Fluent PJM Member\n<size=60%>Sign World Creator",           "1" }, // https://vrchat.com/home/user/usr_883258b3-ab1d-47fe-a628-b8f93e523bb3
        





        //new string[] { "Bob64", "You're my friends now. \n<size=60%>We're having soft tacos later!",    "4" }, // https://vrchat.com/home/user/usr_f50fcd7f-63d3-4110-a188-5beade936a5d
        new string[] { "Shawarmachine",         "HH World Creator",                                        "2" }, // https://vrchat.com/home/user/usr_f94d7b40-d866-4e47-bccf-bbdd8d135eb5
	    new string[] { "DecentM", "HH World Creator",                                        "2" }, // https://vrchat.com/home/user/usr_5f6ffb48-16bd-4558-be2c-7396431f2b2c
        new string[] { "Gorialis",              "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_b804712f-caf4-464b-ae61-217b09e8cc3d
        new string[] { "_bou",                  "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_b14cb719-0943-4a0b-b3c7-5aabb5698512
        new string[] { "TenriGenderless",       "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_55cb89fd-512f-4e74-9707-d2b6c5164437
        new string[] { "lox9973",               "Creator of Shadermotion",                               "3" }, // https://vrchat.com/home/user/usr_4ebb39fd-bd1d-40b7-b241-094efd237639
        new string[] { "MelWil",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_3de047c7-f682-47a4-b94f-ff1424012caa
        new string[] { "Darketernal", "World Co-Founder\n<size=60%>World Contributor",                                     "3" }, // https://vrchat.com/home/user/usr_aab79276-0dc9-49ea-87cb-3945afa06baf
        new string[] { "｜Kingsy｜",            "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_86dc9460-0604-4f55-8490-a94fecccaec9
        new string[] { "Ravеn",               "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_1e0633de-30e1-46bf-b10f-57cb8819fc93
        //new string[] { "❤Akira❤",              "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_4d4e5094-afba-471b-a683-f596e409eb3f Will keep an eye; concerned due to DM's report of misbehavior from this person in the past...
        new string[] { "Millan",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_85d53d5c-2a2b-4957-9202-55b1ea13d2a7
        new string[] { "LUK003",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_a39441a3-71d0-402c-9bb7-b91c0208f057
        new string[] { "flyineko｜假飞猫",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_4127f9b7-d22b-4051-9412-932585994a24
        new string[] { "Lanowen",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_f9a3aac9-1797-4dd9-a292-f93c483227d5
        new string[] { "girl in red",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_9326ebd2-103e-46ec-8f90-b835a2a9bc50
        new string[] { "undeadsee",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_ed5ccd7d-1244-4958-9511-e6f94d93ee2c
        new string[] { "LunaAshes",                "World Contributor",                                    "3" }, // https://vrchat.com/home/user/usr_1fd98d14-72d9-466b-a3ff-7db17660751a
        
    };

    VRCPlayerApi[] trustedPlayers = new VRCPlayerApi[0];
    int trustedPlayerCount = 0;

    GameObject[] instances = new GameObject[80];

    VRCUrl tagurl = new VRCUrl("https://bobsixtyfour.github.io/vrchat-asl/json/worldtag.json");
    string[][] jsontags;
    string jsonStr = "";
    DataToken datatokens;
    bool loaded=false;

    private void Start()
    {
        VRCStringDownloader.LoadUrl(tagurl, (IUdonEventReceiver)this);
        GameObject original = transform.Find("Canvas").gameObject;
        original.SetActive(false);
        instances[0] = original;
        
        for (int i = 1; i < 80; i++)
        {
            instances[i] = Instantiate(original);
            instances[i].transform.SetParent(transform);
        }
    }

    //called when string loading is successful.
    public override void OnStringLoadSuccess(IVRCStringDownload result)
    {
        Debug.Log("String Loaded");
        loaded = true;
        jsonStr = result.Result;
        if (VRCJson.TryDeserializeFromJson(jsonStr, out datatokens))
        {
            //Debug.Log("Json deserialized");

            //Deserialization succeeded! Let's figure out what we got.
            if (datatokens.TokenType == TokenType.DataDictionary)
            {
                //Debug.Log(message: $"Successfully deserialized as a dictionary with {datatokenevents.DataDictionary.Count} count");
            }

            else if (datatokens.TokenType == TokenType.DataList)
            {
                Debug.Log(message: $"Successfully deserialized as a list with {datatokens.DataList.Count} count");
                jsontags = new string[datatokens.DataList.Count][]; //Declare jagged array

                for (int i = 0; i < datatokens.DataList.Count; i++)
                {
                    DataToken temptoken;
                    if (datatokens.DataList.TryGetValue(i, out temptoken))
                    {
                        string Name = temptoken.DataDictionary[(DataToken)"Name"].String;
                        string Tag = temptoken.DataDictionary[(DataToken)"Tag"].String;
                        string Color = temptoken.DataDictionary[(DataToken)"Color"].String;

                        string Community = temptoken.DataDictionary[(DataToken)"Community"].String;


                        //Debug.Log(message: $"From element {i}, got values for: language: {language}, presenter: {presenter}, timestamp: {UnixTimeToUtc(long.Parse(timestamp)/1000).ToString("g")}");
                        jsontags[i] = new string[] { Name, Tag, Color, Community };

                        /*
                        Debug.Log(message: $"Successfully got value from element {i}: {temptoken}");
                        //Debug.Log(temptoken["language"].String);
                        temptoken.DataDictionary.TryGetValue((DataToken)"language", out DataToken value);
                        Debug.Log(message: $"Successfully got language value: {value.String}");*/
                    }
                    else
                    {
                        Debug.Log(message: $"Failed to get value from element {i}.");
                    }
                }
                if (datatokens.DataList.Count > 0)
                {
                    Debug.Log("JSON events loaded.");
                }
                else
                {
                    Debug.Log("Json deserialized with 0 count");
                }

            }
            else
            {
                //This should not be possible. If DeserializeFromJson returns true, then it *must* be either a dictionary or a list
            }



        }
        else //failed to deserialize
        {
            Debug.Log(message: $"Failed to Deserialize json {jsonStr} - {datatokens.ToString()}");

        }


            UpdatePlayerList(null);

    }

    public override void OnStringLoadError(IVRCStringDownload result)
    {
        Debug.Log("String Failed to load");
    }

    private void Update()
    {
        Vector3 target = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position +
            (Networking.LocalPlayer.GetRotation() * Vector3.forward * 0.2f);

        for (int i = 0; i < trustedPlayerCount; i++)
        {
            if (trustedPlayers[i] == null || !Utilities.IsValid(trustedPlayers[i])) continue;

            Vector3 checkLocation = trustedPlayers[i].GetBonePosition(HumanBodyBones.Head);

            Vector3 location = checkLocation.magnitude < 0.01f ? trustedPlayers[i].GetPosition() + Vector3.up * 2.0f : checkLocation + Vector3.up * 0.35f; //moved slightly higher; prev value .30f -Bob
            instances[i].transform.position = location;
            instances[i].transform.rotation = Quaternion.Slerp(instances[i].transform.rotation, Quaternion.LookRotation(target - location, Vector3.up), Time.deltaTime);
        }
    }

    private void UpdatePlayerList(VRCPlayerApi ignore)
    {
        trustedPlayers = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
        VRCPlayerApi.GetPlayers(trustedPlayers);
        trustedPlayerCount = 0;

        // To save on allocations, when we collect together trusted players, we perform a sort of needle sort on our stored array.
        // Imagine we have a list of players like this, where only vowels are trusted:
        // -------------------------
        //  A B C D E F G H I J K L
        // -------------------------
        // By keeping an index of how many trusted players we've seen, in a single pass we can replace elements at the start.
        // -------|-----------------
        //  A E I D E F G H I J K L
        // -------|-----------------
        // The trusted player 'needle' is always guaranteed to either match or be before the iterating index.
        // Thus, we in-place sort all the trusted members to the front, and by referring to the count,
        // we can just ignore any members that aren't before the needle.
        // It still results in an O(n.m) check, but without hash or BTree sets I don't think Udon can do any better.

        for (int player_index = 0; player_index < trustedPlayers.Length; player_index++) {
            VRCPlayerApi player = trustedPlayers[player_index];

            // I'm not sure if Udon implements proper equality between VRCPlayerApis or not, so use the name
            if (ignore != null && player.displayName == ignore.displayName)
                continue;

            foreach (string[] pair in jsontags)
            {
                if (pair[0] == player.displayName)
                {
                    trustedPlayers[trustedPlayerCount] = player;
                    instances[trustedPlayerCount].SetActive(true);
                    instances[trustedPlayerCount].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = pair[1];
                    if (pair[3]== "hh")
                    {
                        instances[trustedPlayerCount].transform.Find("HHImage").gameObject.SetActive(true);
                        instances[trustedPlayerCount].transform.Find("GenericImage").gameObject.SetActive(false);
                        instances[trustedPlayerCount].transform.Find("HHImage").GetComponent<Image>().color = colorAssignments[int.Parse(pair[2])];
                    }
                    else if (pair[3] == "gs")
                    {
                        instances[trustedPlayerCount].transform.Find("HHImage").gameObject.SetActive(false);
                        instances[trustedPlayerCount].transform.Find("GenericImage").gameObject.SetActive(true);
                    }

                    trustedPlayerCount++;
                    break;
                }
            }
        }

        for (int instance_index = trustedPlayerCount; instance_index < 80; instance_index++)
        {
            instances[instance_index].SetActive(false);
        }
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (loaded)
        {
            UpdatePlayerList(null);
        }
        
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        if (loaded)
        {
            UpdatePlayerList(player);
        }
        
    }
}
