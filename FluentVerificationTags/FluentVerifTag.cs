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
        //Debug.Log("String Loaded");
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
                //Debug.Log(message: $"Successfully deserialized as a list with {datatokens.DataList.Count} count");
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
                        jsontags[i] = new string[] { Name, Tag, Color, Community };
                    }
                    else
                    {
                        //Debug.Log(message: $"Failed to get value from element {i}.");
                    }
                }
                if (datatokens.DataList.Count > 0)
                {
                    //Debug.Log("JSON events loaded.");
                }
                else
                {
                    //Debug.Log("Json deserialized with 0 count");
                }
            }
            else
            {
                //This should not be possible. If DeserializeFromJson returns true, then it *must* be either a dictionary or a list
            }
        }
        else //failed to deserialize
        {
            //Debug.Log(message: $"Failed to Deserialize json {jsonStr} - {datatokens.ToString()}");
        }
        UpdatePlayerList(null);
    }

    public override void OnStringLoadError(IVRCStringDownload result)
    {
        //Debug.Log("String Failed to load");
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
