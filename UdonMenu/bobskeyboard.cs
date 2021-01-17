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
    public Text chatlinebuffer;
    public Text chathistory;

    //public InputField kbinput;
    private VRCPlayerApi _localPlayer;
    bool shift=false;
    bool CapsLock=false;
    [SerializeField] //this shows private fields in the inspector
    private Color _defaultColor = new Color(0x00, 0x60, 0xff, 0x00) / 0x100;
    [SerializeField]
    private Color _clickedColor = new Color(0x00, 0x60, 0xff, 0x80) / 0x100;
    Transform _eventTriggersParent;
    public VRC.SDKBase.VRCStation station;
    [HideInInspector]
    public VRCPlayerApi seated;
    void Start()
    {
        
    }
    void Update()
    {
        if(seated == Networking.LocalPlayer){//handles keyboard input only if player is in a chair.
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){

            }else{//shift key is not down.

            }
        }

        
    }

    public void symbol_chair_pushed()
    {
        if (seated == null)
        {
            station.UseStation(Networking.LocalPlayer);
        }
        else if(seated == Networking.LocalPlayer)
        {
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

    public void backspace_pushed(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_backspace");
    }
    public void network_backspace_pushed(){
        if(chatlinebuffer.text.Length>0){
            chatlinebuffer.text=chatlinebuffer.text.Substring(0,chatlinebuffer.text.Length-1);
        }
    }
    public void symbol_enter_pushed(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_backspace");
    }
    public void network_enter_pushed(){
        chathistory.text+="\n"+chatlinebuffer.text;
        chatlinebuffer.text="";
    }
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            _localPlayer = player;
        }
        chathistory.text+=$"[{DateTime.Now:HH:mm:ss}] {player.displayName} joined.";
    }
    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        chathistory.text+=$"[{DateTime.Now:HH:mm:ss}] {player.displayName} left.";
    }
public void symbol_shift_pushed(){
    shift=!shift;
    _eventTriggersParent.Find("Shift" + "_L").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
_eventTriggersParent.Find("Shift" + "_R").GetComponent<Image>().color = shift ? _clickedColor : _defaultColor;
}









public void letter_a_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_a_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_a_pushed");      
}
}

public void network_letter_a_pushed(){
chatlinebuffer.text+="a";
}

public void network_shiftletter_a_pushed(){
chatlinebuffer.text+="A";
}
public void letter_b_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_b_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_b_pushed");
}
}

public void network_letter_b_pushed(){
chatlinebuffer.text+="b";
}

public void network_shiftletter_b_pushed(){
chatlinebuffer.text+="B";
}
public void letter_c_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_c_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_c_pushed");
}
}

public void network_letter_c_pushed(){
chatlinebuffer.text+="c";
}

public void network_shiftletter_c_pushed(){
chatlinebuffer.text+="C";
}
public void letter_d_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_d_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_d_pushed");
}
}

public void network_letter_d_pushed(){
chatlinebuffer.text+="d";
}

public void network_shiftletter_d_pushed(){
chatlinebuffer.text+="D";
}
public void letter_e_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_e_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_e_pushed");
}
}

public void network_letter_e_pushed(){
chatlinebuffer.text+="e";
}

public void network_shiftletter_e_pushed(){
chatlinebuffer.text+="E";
}
public void letter_f_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_f_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_f_pushed");
}
}

public void network_letter_f_pushed(){
chatlinebuffer.text+="f";
}

public void network_shiftletter_f_pushed(){
chatlinebuffer.text+="F";
}
public void letter_g_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_g_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_g_pushed");
}
}

public void network_letter_g_pushed(){
chatlinebuffer.text+="g";
}

public void network_shiftletter_g_pushed(){
chatlinebuffer.text+="G";
}
public void letter_h_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_h_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_h_pushed");
}
}

public void network_letter_h_pushed(){
chatlinebuffer.text+="h";
}

public void network_shiftletter_h_pushed(){
chatlinebuffer.text+="H";
}
public void letter_i_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_i_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_i_pushed");
}
}

public void network_letter_i_pushed(){
chatlinebuffer.text+="i";
}

public void network_shiftletter_i_pushed(){
chatlinebuffer.text+="I";
}
public void letter_j_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_j_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_j_pushed");
}
}

public void network_letter_j_pushed(){
chatlinebuffer.text+="j";
}

public void network_shiftletter_j_pushed(){
chatlinebuffer.text+="J";
}
public void letter_k_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_k_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_k_pushed");
}
}

public void network_letter_k_pushed(){
chatlinebuffer.text+="k";
}

public void network_shiftletter_k_pushed(){
chatlinebuffer.text+="K";
}
public void letter_l_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_l_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_l_pushed");
}
}

public void network_letter_l_pushed(){
chatlinebuffer.text+="l";
}

public void network_shiftletter_l_pushed(){
chatlinebuffer.text+="L";
}
public void letter_m_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_m_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_m_pushed");
}
}

public void network_letter_m_pushed(){
chatlinebuffer.text+="m";
}

public void network_shiftletter_m_pushed(){
chatlinebuffer.text+="M";
}
public void letter_n_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_n_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_n_pushed");
}
}

public void network_letter_n_pushed(){
chatlinebuffer.text+="n";
}

public void network_shiftletter_n_pushed(){
chatlinebuffer.text+="N";
}
public void letter_o_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_o_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_o_pushed");
}
}

public void network_letter_o_pushed(){
chatlinebuffer.text+="o";
}

public void network_shiftletter_o_pushed(){
chatlinebuffer.text+="O";
}
public void letter_p_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_p_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_p_pushed");
}
}

public void network_letter_p_pushed(){
chatlinebuffer.text+="p";
}

public void network_shiftletter_p_pushed(){
chatlinebuffer.text+="P";
}
public void letter_q_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_q_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_q_pushed");
}
}

public void network_letter_q_pushed(){
chatlinebuffer.text+="q";
}

public void network_shiftletter_q_pushed(){
chatlinebuffer.text+="Q";
}
public void letter_r_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_r_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_r_pushed");
}
}

public void network_letter_r_pushed(){
chatlinebuffer.text+="r";
}

public void network_shiftletter_r_pushed(){
chatlinebuffer.text+="R";
}
public void letter_s_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_s_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_s_pushed");
}
}

public void network_letter_s_pushed(){
chatlinebuffer.text+="s";
}

public void network_shiftletter_s_pushed(){
chatlinebuffer.text+="S";
}
public void letter_t_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_t_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_t_pushed");
}
}

public void network_letter_t_pushed(){
chatlinebuffer.text+="t";
}

public void network_shiftletter_t_pushed(){
chatlinebuffer.text+="T";
}
public void letter_u_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_u_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_u_pushed");
}
}

public void network_letter_u_pushed(){
chatlinebuffer.text+="u";
}

public void network_shiftletter_u_pushed(){
chatlinebuffer.text+="U";
}
public void letter_v_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_v_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_v_pushed");
}
}

public void network_letter_v_pushed(){
chatlinebuffer.text+="v";
}

public void network_shiftletter_v_pushed(){
chatlinebuffer.text+="V";
}
public void letter_w_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_w_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_w_pushed");
}
}

public void network_letter_w_pushed(){
chatlinebuffer.text+="w";
}

public void network_shiftletter_w_pushed(){
chatlinebuffer.text+="W";
}
public void letter_x_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_x_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_x_pushed");
}
}

public void network_letter_x_pushed(){
chatlinebuffer.text+="x";
}

public void network_shiftletter_x_pushed(){
chatlinebuffer.text+="X";
}
public void letter_y_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_y_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_y_pushed");
}
}

public void network_letter_y_pushed(){
chatlinebuffer.text+="y";
}

public void network_shiftletter_y_pushed(){
chatlinebuffer.text+="Y";
}
public void letter_z_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_letter_z_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_letter_z_pushed");
}
}

public void network_letter_z_pushed(){
chatlinebuffer.text+="z";
}

public void network_shiftletter_z_pushed(){
chatlinebuffer.text+="Z";
}
public void number_0_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_0_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_0_pushed");
}
}

public void network_number_0_pushed(){
chatlinebuffer.text+="0";
}

public void network_shiftnumber_0_pushed(){
chatlinebuffer.text+=")";
}
public void number_1_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_1_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_1_pushed");
}
}

public void network_number_1_pushed(){
chatlinebuffer.text+="1";
}

public void network_shiftnumber_1_pushed(){
chatlinebuffer.text+="!";
}
public void number_2_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_2_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_2_pushed");
}
}

public void network_number_2_pushed(){
chatlinebuffer.text+="2";
}

public void network_shiftnumber_2_pushed(){
chatlinebuffer.text+="@";
}
public void number_3_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_3_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_3_pushed");
}
}

public void network_number_3_pushed(){
chatlinebuffer.text+="3";
}

public void network_shiftnumber_3_pushed(){
chatlinebuffer.text+="#";
}
public void number_4_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_4_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_4_pushed");
}
}

public void network_number_4_pushed(){
chatlinebuffer.text+="4";
}

public void network_shiftnumber_4_pushed(){
chatlinebuffer.text+="$";
}
public void number_5_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_5_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_5_pushed");
}
}

public void network_number_5_pushed(){
chatlinebuffer.text+="5";
}

public void network_shiftnumber_5_pushed(){
chatlinebuffer.text+="%";
}
public void number_6_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_6_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_6_pushed");
}
}

public void network_number_6_pushed(){
chatlinebuffer.text+="5";
}

public void network_shiftnumber_6_pushed(){
chatlinebuffer.text+="^";
}
public void number_7_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_7_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_7_pushed");
}
}

public void network_number_7_pushed(){
chatlinebuffer.text+="7";
}

public void network_shiftnumber_7_pushed(){
chatlinebuffer.text+="&";
}
public void number_8_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_8_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_8_pushed");
}
}

public void network_number_8_pushed(){
chatlinebuffer.text+="8";
}

public void network_shiftnumber_8_pushed(){
chatlinebuffer.text+="*";
}
public void number_9_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_number_9_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_number_9_pushed");
}
}

public void network_number_9_pushed(){
chatlinebuffer.text+="9";
}

public void network_shiftnumber_9_pushed(){
chatlinebuffer.text+="(";
}
public void symbol_space_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_space_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_space_pushed");
}
}

public void network_symbol_space_pushed(){
chatlinebuffer.text+=" ";
}

public void network_shiftsymbol_space_pushed(){
chatlinebuffer.text+=" ";
}
public void symbol_dash_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_dash_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_dash_pushed");
}
}

public void network_symbol_dash_pushed(){
chatlinebuffer.text+="-";
}

public void network_shiftsymbol_dash_pushed(){
chatlinebuffer.text+="_";
}
public void symbol_equals_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_equals_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_equals_pushed");
}
}

public void network_symbol_equals_pushed(){
chatlinebuffer.text+="=";
}

public void network_shiftsymbol_equals_pushed(){
chatlinebuffer.text+="+";
}
public void symbol_leftsquarebracket_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_leftsquarebracket_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_leftsquarebracket_pushed");
}
}

public void network_symbol_leftsquarebracket_pushed(){
chatlinebuffer.text+="[";
}

public void network_shiftsymbol_leftsquarebracket_pushed(){
chatlinebuffer.text+="{";
}
public void symbol_rightsquarebracket_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_rightsquarebracket_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_rightsquarebracket_pushed");
}
}

public void network_symbol_rightsquarebracket_pushed(){
chatlinebuffer.text+="]";
}

public void network_shiftsymbol_rightsquarebracket_pushed(){
chatlinebuffer.text+="}";
}
public void symbol_backslash_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_backslash_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_backslash_pushed");
}
}

public void network_symbol_backslash_pushed(){
chatlinebuffer.text+="\\";
}

public void network_shiftsymbol_backslash_pushed(){
chatlinebuffer.text+="|";
}
public void symbol_semicolon_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_semicolon_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_semicolon_pushed");
}
}

public void network_symbol_semicolon_pushed(){
chatlinebuffer.text+=";";
}

public void network_shiftsymbol_semicolon_pushed(){
chatlinebuffer.text+=":";
}
public void symbol_quotation_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_quotation_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_quotation_pushed");
}
}

public void network_symbol_quotation_pushed(){
chatlinebuffer.text+="'";
}

public void network_shiftsymbol_quotation_pushed(){
chatlinebuffer.text+="\"";
}
public void symbol_comma_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_comma_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_comma_pushed");
}
}

public void network_symbol_comma_pushed(){
chatlinebuffer.text+=",";
}

public void network_shiftsymbol_comma_pushed(){
chatlinebuffer.text+="<";
}
public void symbol_period_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_period_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_period_pushed");
}
}

public void network_symbol_period_pushed(){
chatlinebuffer.text+=".";
}

public void network_shiftsymbol_period_pushed(){
chatlinebuffer.text+=">";
}
public void symbol_fowardslash_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_fowardslash_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_fowardslash_pushed");
}
}

public void network_symbol_fowardslash_pushed(){
chatlinebuffer.text+="/";
}

public void network_shiftsymbol_fowardslash_pushed(){
chatlinebuffer.text+="?";
}
public void symbol_backquote_pushed(){
if(shift){
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_shift_symbol_backquote_pushed");
symbol_shift_pushed();
}else{
SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "network_symbol_backquote_pushed");
}
}

public void network_symbol_backquote_pushed(){
chatlinebuffer.text+="`";
}

public void network_shiftsymbol_backquote_pushed(){
chatlinebuffer.text+="~";
}






}
