using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Video.Components;
using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components.Base;
using TMPro;

namespace Bob64
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class VideoPlayerControl : UdonSharpBehaviour
    {
        VRCUnityVideoPlayer vrcplayercomponent;
        //TextMeshProUGUI videostatus;
        VRCUrl currenturl;

        void Start()
        {
            
            vrcplayercomponent = ((VRCUnityVideoPlayer)GameObject.Find("/Video Container/Video").GetComponent(typeof(VRCUnityVideoPlayer)));
        }

        public void _SetStatusText(string text)
        {
            GameObject.Find("/Video Text/StatusPanel/Text (TMP)").GetComponent<TextMeshProUGUI>().text=text;
            
        }

        public void _LoadURL(VRCUrl url)
        {
            _SetStatusText("");
            vrcplayercomponent.PlayURL(url);
            currenturl = url;
        }

        public override void OnVideoStart()
        {
            //_SetStatusText("Video should be playing now...");
        }

        public void _ReloadButtonPushed()
        {
            _SetStatusText("");
            if (currenturl != null)
            {
                vrcplayercomponent.PlayURL(currenturl);
            }
            
        }

        /***************************************************************************************************************************
Called to change video speed
***************************************************************************************************************************/
        public void VideoSpeedSliderValueChanged()
        {
            //GameObject.Find("/Video Container/Video/").GetComponent<UnityEngine.Video.VideoPlayer>().playbackSpeed = videospeedslider.value;

        }


        public override void OnVideoError(VideoError videoError)
        {
            switch (videoError)
            {
                case VideoError.RateLimited:
                    _SetStatusText("Rate limited, Push the reload button in a few seconds ==>");
                    break;
                case VideoError.PlayerError:
                    _SetStatusText("Video player error or broken video link");
                    break;
                case VideoError.InvalidURL:
                    _SetStatusText("Invalid URL");
                    break;
                case VideoError.AccessDenied:
                    _SetStatusText("Videos blocked, Please enable untrusted URLs under Settings > Comfort and Safety");
                    break;
                default:
                    _SetStatusText("Failed to load video");
                    break;
            }
        }



    }
}