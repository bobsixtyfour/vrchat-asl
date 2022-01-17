#if VRC_SDK_VRCSDK3 && UDON
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

public class bobskeyboard : UdonSharpBehaviour
{
    string[][] keys=new string[][]{
new string[]{"key_A","a","A"},
new string[]{"key_B","b","B"},
new string[]{"key_C","c","C"},
new string[]{"key_D","d","D"},
new string[]{"key_E","e","E"},
new string[]{"key_F","f","F"},
new string[]{"key_G","g","G"},
new string[]{"key_H","h","H"},
new string[]{"key_I","i","I"},
new string[]{"key_J","j","J"},
new string[]{"key_K","k","K"},
new string[]{"key_L","l","L"},
new string[]{"key_M","m","M"},
new string[]{"key_N","n","N"},
new string[]{"key_O","o","O"},
new string[]{"key_P","p","P"},
new string[]{"key_Q","q","Q"},
new string[]{"key_R","r","R"},
new string[]{"key_S","s","S"},
new string[]{"key_T","t","T"},
new string[]{"key_U","u","U"},
new string[]{"key_V","v","V"},
new string[]{"key_W","w","W"},
new string[]{"key_X","x","X"},
new string[]{"key_Y","y","Y"},
new string[]{"key_Z","z","Z"},
new string[]{"key_Alpha0","0",")"},
new string[]{"key_Alpha1","1","!"},
new string[]{"key_Alpha2","2","@"},
new string[]{"key_Alpha3","3","#"},
new string[]{"key_Alpha4","4","$"},
new string[]{"key_Alpha5","5","%"},
new string[]{"key_Alpha6","6","^"},
new string[]{"key_Alpha7","7","&"},
new string[]{"key_Alpha8","8","*"},
new string[]{"key_Alpha9","9","("},
new string[]{"key_Minus","-","_"},
new string[]{"key_Equals","=","+"},
new string[]{"key_LeftBracket","[","{"},
new string[]{"key_RightBracket","]","}"},
new string[]{"key_Backslash","\\","|"},
new string[]{"key_Semicolon",";",":"},
new string[]{"key_Quote","'","\""},
new string[]{"key_Comma",",","<"},
new string[]{"key_Period",".",">"},
new string[]{"key_Slash","/","?"},
new string[]{"key_BackQuote","`","~"},
};
    public TextMeshProUGUI chatlinebuffer;
    public TextMeshProUGUI chathistory;

    //public InputField kbinput;
    private VRCPlayerApi _localPlayer;
    bool shift=false;
    bool CapsLock=false;
    [SerializeField] //this shows private fields in the inspector
    private Color _defaultColor = new Color(0x00, 0x60, 0xff, 0x00) / 0x100;
    [SerializeField]
    private Color _clickedColor = new Color(0x00, 0x60, 0xff, 0x80) / 0x100;
    public Transform _eventTriggersParent;
    public VRC.SDKBase.VRCStation station;
    [HideInInspector]
    public VRCPlayerApi seated;
    bool sitting=false;
public TextMeshProUGUI[] keyboardkeytext;


public GameObject etroot;
    void Start()
    {
        Debug.Log("length "+keys.Length);
        keyboardkeytext = new TextMeshProUGUI[keys.Length];
         etroot = GameObject.Find("/Keyboards/BobsKeyboard/Keyboard/Canvas_Input/EventTrigger");
         for (int i = 0; i < keys.Length; i++){
                keyboardkeytext[i]=etroot.transform.Find(keys[i][0]).Find("Text (TMP)").GetComponent<TextMeshProUGUI>();

            }
        _updatekeys();

    }
    void Update()
    {

        if(sitting == true){//handles keyboard input only if player is in a chair.
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){//while the buttons are held down...
                if(shift==false){//don't update if it's already updated
                    shift=true;
                    _updatekeys();
                    _eventTriggersParent.Find("key_LShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
                    _eventTriggersParent.Find("key_RShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)){//while the buttons are held down...
                if(shift==true){//don't update if it's already updated
                    shift=false;
                    _updatekeys();
                    _eventTriggersParent.Find("key_LShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
                    _eventTriggersParent.Find("key_RShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
                }
            }
            if (Input.GetKeyDown(KeyCode.CapsLock)){//capslock key pushed
                _pushed_CapsLock();
            }

if (Input.GetKeyDown(KeyCode.A)){
_pushed_A();
}

if (Input.GetKeyDown(KeyCode.B)){
_pushed_B();
}

if (Input.GetKeyDown(KeyCode.C)){
_pushed_C();
}

if (Input.GetKeyDown(KeyCode.D)){
_pushed_D();
}

if (Input.GetKeyDown(KeyCode.E)){
_pushed_E();
}

if (Input.GetKeyDown(KeyCode.F)){
_pushed_F();
}

if (Input.GetKeyDown(KeyCode.G)){
_pushed_G();
}

if (Input.GetKeyDown(KeyCode.H)){
_pushed_H();
}

if (Input.GetKeyDown(KeyCode.I)){
_pushed_I();
}

if (Input.GetKeyDown(KeyCode.J)){
_pushed_J();
}

if (Input.GetKeyDown(KeyCode.K)){
_pushed_K();
}

if (Input.GetKeyDown(KeyCode.L)){
_pushed_L();
}

if (Input.GetKeyDown(KeyCode.M)){
_pushed_M();
}

if (Input.GetKeyDown(KeyCode.N)){
_pushed_N();
}

if (Input.GetKeyDown(KeyCode.O)){
_pushed_O();
}

if (Input.GetKeyDown(KeyCode.P)){
_pushed_P();
}

if (Input.GetKeyDown(KeyCode.Q)){
_pushed_Q();
}

if (Input.GetKeyDown(KeyCode.R)){
_pushed_R();
}

if (Input.GetKeyDown(KeyCode.S)){
_pushed_S();
}

if (Input.GetKeyDown(KeyCode.T)){
_pushed_T();
}

if (Input.GetKeyDown(KeyCode.U)){
_pushed_U();
}

if (Input.GetKeyDown(KeyCode.V)){
_pushed_V();
}

if (Input.GetKeyDown(KeyCode.W)){
_pushed_W();
}

if (Input.GetKeyDown(KeyCode.X)){
_pushed_X();
}

if (Input.GetKeyDown(KeyCode.Y)){
_pushed_Y();
}

if (Input.GetKeyDown(KeyCode.Z)){
_pushed_Z();
}

if (Input.GetKeyDown(KeyCode.Alpha0)){
_pushed_Alpha0();
}

if (Input.GetKeyDown(KeyCode.Alpha1)){
_pushed_Alpha1();
}

if (Input.GetKeyDown(KeyCode.Alpha2)){
_pushed_Alpha2();
}

if (Input.GetKeyDown(KeyCode.Alpha3)){
_pushed_Alpha3();
}

if (Input.GetKeyDown(KeyCode.Alpha4)){
_pushed_Alpha4();
}

if (Input.GetKeyDown(KeyCode.Alpha5)){
_pushed_Alpha5();
}

if (Input.GetKeyDown(KeyCode.Alpha6)){
_pushed_Alpha6();
}

if (Input.GetKeyDown(KeyCode.Alpha7)){
_pushed_Alpha7();
}

if (Input.GetKeyDown(KeyCode.Alpha8)){
_pushed_Alpha8();
}

if (Input.GetKeyDown(KeyCode.Alpha9)){
_pushed_Alpha9();
}

if (Input.GetKeyDown(KeyCode.Minus)){
_pushed_Minus();
}

if (Input.GetKeyDown(KeyCode.Equals)){
_pushed_Equals();
}

if (Input.GetKeyDown(KeyCode.LeftBracket)){
_pushed_LeftBracket();
}

if (Input.GetKeyDown(KeyCode.RightBracket)){
_pushed_RightBracket();
}

if (Input.GetKeyDown(KeyCode.Backslash)){
_pushed_Backslash();
}

if (Input.GetKeyDown(KeyCode.Semicolon)){
_pushed_Semicolon();
}

if (Input.GetKeyDown(KeyCode.Quote)){
_pushed_Quote();
}

if (Input.GetKeyDown(KeyCode.Comma)){
_pushed_Comma();
}

if (Input.GetKeyDown(KeyCode.Period)){
_pushed_Period();
}

if (Input.GetKeyDown(KeyCode.Slash)){
_pushed_Slash();
}

if (Input.GetKeyDown(KeyCode.BackQuote)){
_pushed_BackQuote();
}

if (Input.GetKeyDown(KeyCode.CapsLock)){
_pushed_CapsLock();
}

if (Input.GetKeyDown(KeyCode.Tab)){
_pushed_Tab();
}

if (Input.GetKeyDown(KeyCode.Backspace)){
_pushed_Backspace();
}

if (Input.GetKeyDown(KeyCode.Space)){
_pushed_Space();
}
if (Input.GetKeyDown(KeyCode.Return)){
_pushed_Return();
}


        }

    }

    void _updatekeys(){
        //new string[]{"key_Z","z","Z"},
        for (int i = 0; i < 26; i++){
            if(CapsLock){
                keyboardkeytext[i].text=keys[i][2];
            }
            else{
                keyboardkeytext[i].text=shift ? keys[i][2] : keys[i][1];
            }
        }
        for (int i = 26; i < keys.Length; i++){
                keyboardkeytext[i].text=shift ? keys[i][2] : keys[i][1];
            }
    }
    public void _pushed_chair()
    {
        Debug.Log("entered pushed_chair");
        if (sitting==false)
        {
            sitting=true;
            //Debug.Log("seated=null");
            _eventTriggersParent.Find("key_Rchair").GetComponent<Image>().color = _clickedColor;
            _eventTriggersParent.Find("key_Lchair").GetComponent<Image>().color = _clickedColor;
            //station.seated=true;
            station.UseStation(Networking.LocalPlayer);
            //Debug.Log(station.seated);
        }
        else// if(seated == Networking.LocalPlayer)
        {
            sitting=false;
            Debug.Log("uh trying to exit station?");
            _eventTriggersParent.Find("key_Lchair").GetComponent<Image>().color = _defaultColor;
            _eventTriggersParent.Find("key_Rchair").GetComponent<Image>().color = _defaultColor;
            station.ExitStation(Networking.LocalPlayer);
        }
    }

    public override void OnStationEntered(VRC.SDKBase.VRCPlayerApi player){
        seated = player;
    }
    public override void OnStationExited(VRC.SDKBase.VRCPlayerApi player){
        if(seated == player)
        {
            seated = null;
        }
    }

    public void _pushed_Backspace(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Backspace");
    }
    public void network_pushed_Backspace(){
        if(chatlinebuffer.text.Length>0){
            chatlinebuffer.text=chatlinebuffer.text.Substring(0,chatlinebuffer.text.Length-1);
        }
    }
    public void _pushed_Return(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Return");
    }
    public void network_pushed_Return(){
        chathistory.text+="\n"+chatlinebuffer.text;
        chatlinebuffer.text="";
    }
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            _localPlayer = player;
        }
        chathistory.text+=$"\n[{DateTime.Now:HH:mm:ss}] {player.displayName} joined.";
    }
    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        chathistory.text+=$"\n[{DateTime.Now:HH:mm:ss}] {player.displayName} left.";
    }

public void _pushed_Shift(){
    shift=!shift;
    _updatekeys();
    _eventTriggersParent.Find("key_LShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
_eventTriggersParent.Find("key_RShift").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
}


public void _pushed_CapsLock(){
    CapsLock=!CapsLock;
    _updatekeys();
_eventTriggersParent.Find("key_CapsLock").GetComponent<Image>().color = CapsLock ? _clickedColor : _defaultColor;
}








public void _pushed_A(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_A");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_A");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_A");
}
}

public void network_pushed_A(){
chatlinebuffer.text+="a";
}

public void network_pushed_Upper_A(){
chatlinebuffer.text+="A";
}

public void _pushed_B(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_B");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_B");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_B");
}
}

public void network_pushed_B(){
chatlinebuffer.text+="b";
}

public void network_pushed_Upper_B(){
chatlinebuffer.text+="B";
}

public void _pushed_C(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_C");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_C");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_C");
}
}

public void network_pushed_C(){
chatlinebuffer.text+="c";
}

public void network_pushed_Upper_C(){
chatlinebuffer.text+="C";
}

public void _pushed_D(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_D");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_D");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_D");
}
}

public void network_pushed_D(){
chatlinebuffer.text+="d";
}

public void network_pushed_Upper_D(){
chatlinebuffer.text+="D";
}

public void _pushed_E(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_E");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_E");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_E");
}
}

public void network_pushed_E(){
chatlinebuffer.text+="e";
}

public void network_pushed_Upper_E(){
chatlinebuffer.text+="E";
}

public void _pushed_F(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_F");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_F");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_F");
}
}

public void network_pushed_F(){
chatlinebuffer.text+="f";
}

public void network_pushed_Upper_F(){
chatlinebuffer.text+="F";
}

public void _pushed_G(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_G");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_G");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_G");
}
}

public void network_pushed_G(){
chatlinebuffer.text+="g";
}

public void network_pushed_Upper_G(){
chatlinebuffer.text+="G";
}

public void _pushed_H(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_H");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_H");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_H");
}
}

public void network_pushed_H(){
chatlinebuffer.text+="h";
}

public void network_pushed_Upper_H(){
chatlinebuffer.text+="H";
}

public void _pushed_I(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_I");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_I");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_I");
}
}

public void network_pushed_I(){
chatlinebuffer.text+="i";
}

public void network_pushed_Upper_I(){
chatlinebuffer.text+="I";
}

public void _pushed_J(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_J");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_J");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_J");
}
}

public void network_pushed_J(){
chatlinebuffer.text+="j";
}

public void network_pushed_Upper_J(){
chatlinebuffer.text+="J";
}

public void _pushed_K(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_K");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_K");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_K");
}
}

public void network_pushed_K(){
chatlinebuffer.text+="k";
}

public void network_pushed_Upper_K(){
chatlinebuffer.text+="K";
}

public void _pushed_L(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_L");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_L");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_L");
}
}

public void network_pushed_L(){
chatlinebuffer.text+="l";
}

public void network_pushed_Upper_L(){
chatlinebuffer.text+="L";
}

public void _pushed_M(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_M");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_M");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_M");
}
}

public void network_pushed_M(){
chatlinebuffer.text+="m";
}

public void network_pushed_Upper_M(){
chatlinebuffer.text+="M";
}

public void _pushed_N(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_N");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_N");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_N");
}
}

public void network_pushed_N(){
chatlinebuffer.text+="n";
}

public void network_pushed_Upper_N(){
chatlinebuffer.text+="N";
}

public void _pushed_O(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_O");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_O");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_O");
}
}

public void network_pushed_O(){
chatlinebuffer.text+="o";
}

public void network_pushed_Upper_O(){
chatlinebuffer.text+="O";
}

public void _pushed_P(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_P");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_P");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_P");
}
}

public void network_pushed_P(){
chatlinebuffer.text+="p";
}

public void network_pushed_Upper_P(){
chatlinebuffer.text+="P";
}

public void _pushed_Q(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Q");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Q");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Q");
}
}

public void network_pushed_Q(){
chatlinebuffer.text+="q";
}

public void network_pushed_Upper_Q(){
chatlinebuffer.text+="Q";
}

public void _pushed_R(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_R");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_R");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_R");
}
}

public void network_pushed_R(){
chatlinebuffer.text+="r";
}

public void network_pushed_Upper_R(){
chatlinebuffer.text+="R";
}

public void _pushed_S(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_S");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_S");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_S");
}
}

public void network_pushed_S(){
chatlinebuffer.text+="s";
}

public void network_pushed_Upper_S(){
chatlinebuffer.text+="S";
}

public void _pushed_T(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_T");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_T");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_T");
}
}

public void network_pushed_T(){
chatlinebuffer.text+="t";
}

public void network_pushed_Upper_T(){
chatlinebuffer.text+="T";
}

public void _pushed_U(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_U");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_U");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_U");
}
}

public void network_pushed_U(){
chatlinebuffer.text+="u";
}

public void network_pushed_Upper_U(){
chatlinebuffer.text+="U";
}

public void _pushed_V(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_V");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_V");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_V");
}
}

public void network_pushed_V(){
chatlinebuffer.text+="v";
}

public void network_pushed_Upper_V(){
chatlinebuffer.text+="V";
}

public void _pushed_W(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_W");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_W");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_W");
}
}

public void network_pushed_W(){
chatlinebuffer.text+="w";
}

public void network_pushed_Upper_W(){
chatlinebuffer.text+="W";
}

public void _pushed_X(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_X");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_X");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_X");
}
}

public void network_pushed_X(){
chatlinebuffer.text+="x";
}

public void network_pushed_Upper_X(){
chatlinebuffer.text+="X";
}

public void _pushed_Y(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Y");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Y");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Y");
}
}

public void network_pushed_Y(){
chatlinebuffer.text+="y";
}

public void network_pushed_Upper_Y(){
chatlinebuffer.text+="Y";
}

public void _pushed_Z(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Z");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Upper_Z");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Z");
}
}

public void network_pushed_Z(){
chatlinebuffer.text+="z";
}

public void network_pushed_Upper_Z(){
chatlinebuffer.text+="Z";
}

public void _pushed_Alpha0(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightParen");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightParen");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha0");
}
}

public void network_pushed_Alpha0(){
chatlinebuffer.text+="0";
}

public void network_pushed_RightParen(){
chatlinebuffer.text+=")";
}

public void _pushed_Alpha1(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Exclaim");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Exclaim");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha1");
}
}

public void network_pushed_Alpha1(){
chatlinebuffer.text+="1";
}

public void network_pushed_Exclaim(){
chatlinebuffer.text+="!";
}

public void _pushed_Alpha2(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_At");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_At");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha2");
}
}

public void network_pushed_Alpha2(){
chatlinebuffer.text+="2";
}

public void network_pushed_At(){
chatlinebuffer.text+="@";
}

public void _pushed_Alpha3(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Hash");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Hash");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha3");
}
}

public void network_pushed_Alpha3(){
chatlinebuffer.text+="3";
}

public void network_pushed_Hash(){
chatlinebuffer.text+="#";
}

public void _pushed_Alpha4(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Dollar");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Dollar");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha4");
}
}

public void network_pushed_Alpha4(){
chatlinebuffer.text+="4";
}

public void network_pushed_Dollar(){
chatlinebuffer.text+="$";
}

public void _pushed_Alpha5(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Percent");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Percent");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha5");
}
}

public void network_pushed_Alpha5(){
chatlinebuffer.text+="5";
}

public void network_pushed_Percent(){
chatlinebuffer.text+="%";
}

public void _pushed_Alpha6(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Caret");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Caret");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha6");
}
}

public void network_pushed_Alpha6(){
chatlinebuffer.text+="6";
}

public void network_pushed_Caret(){
chatlinebuffer.text+="^";
}

public void _pushed_Alpha7(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Ampersand");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Ampersand");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha7");
}
}

public void network_pushed_Alpha7(){
chatlinebuffer.text+="7";
}

public void network_pushed_Ampersand(){
chatlinebuffer.text+="&";
}

public void _pushed_Alpha8(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Asterisk");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Asterisk");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha8");
}
}

public void network_pushed_Alpha8(){
chatlinebuffer.text+="8";
}

public void network_pushed_Asterisk(){
chatlinebuffer.text+="*";
}

public void _pushed_Alpha9(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftParen");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftParen");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Alpha9");
}
}

public void network_pushed_Alpha9(){
chatlinebuffer.text+="9";
}

public void network_pushed_LeftParen(){
chatlinebuffer.text+="(";
}

public void _pushed_Minus(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Underscore");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Underscore");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Minus");
}
}

public void network_pushed_Minus(){
chatlinebuffer.text+="-";
}

public void network_pushed_Underscore(){
chatlinebuffer.text+="_";
}

public void _pushed_Equals(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Plus");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Plus");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Equals");
}
}

public void network_pushed_Equals(){
chatlinebuffer.text+="=";
}

public void network_pushed_Plus(){
chatlinebuffer.text+="+";
}

public void _pushed_LeftBracket(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftCurlyBracket");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftCurlyBracket");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_LeftBracket");
}
}

public void network_pushed_LeftBracket(){
chatlinebuffer.text+="[";
}

public void network_pushed_LeftCurlyBracket(){
chatlinebuffer.text+="{";
}

public void _pushed_RightBracket(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightCurlyBracket");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightCurlyBracket");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_RightBracket");
}
}

public void network_pushed_RightBracket(){
chatlinebuffer.text+="]";
}

public void network_pushed_RightCurlyBracket(){
chatlinebuffer.text+="}";
}

public void _pushed_Backslash(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Pipe");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Pipe");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Backslash");
}
}

public void network_pushed_Backslash(){
chatlinebuffer.text+="\\";
}

public void network_pushed_Pipe(){
chatlinebuffer.text+="|";
}

public void _pushed_Semicolon(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Colon");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Colon");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Semicolon");
}
}

public void network_pushed_Semicolon(){
chatlinebuffer.text+=";";
}

public void network_pushed_Colon(){
chatlinebuffer.text+=":";
}

public void _pushed_Quote(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_DoubleQuote");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_DoubleQuote");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Quote");
}
}

public void network_pushed_Quote(){
chatlinebuffer.text+="'";
}

public void network_pushed_DoubleQuote(){
chatlinebuffer.text+="\"";
}

public void _pushed_Comma(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Less");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Less");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Comma");
}
}

public void network_pushed_Comma(){
chatlinebuffer.text+=",";
}

public void network_pushed_Less(){
chatlinebuffer.text+="<";
}

public void _pushed_Period(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Greater");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Greater");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Period");
}
}

public void network_pushed_Period(){
chatlinebuffer.text+=".";
}

public void network_pushed_Greater(){
chatlinebuffer.text+=">";
}

public void _pushed_Slash(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Question");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Question");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Slash");
}
}

public void network_pushed_Slash(){
chatlinebuffer.text+="/";
}

public void network_pushed_Question(){
chatlinebuffer.text+="?";
}

public void _pushed_BackQuote(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Tilde");
_pushed_Shift();
}else if(CapsLock){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Tilde");
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_BackQuote");
}
}

public void network_pushed_BackQuote(){
chatlinebuffer.text+="`";
}

public void network_pushed_Tilde(){
chatlinebuffer.text+="~";
}


public void _pushed_Tab(){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Tab");
}

public void network_pushed_Tab(){
chatlinebuffer.text+="     ";
}


public void _pushed_Space(){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_pushed_Space");
}

public void network_pushed_Space(){
chatlinebuffer.text+=" ";
}





}
#endif
