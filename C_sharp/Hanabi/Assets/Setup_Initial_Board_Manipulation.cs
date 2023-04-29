using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup_Initial_Board_Manipulation : MonoBehaviour
{
    Card_Display_Manipulation card_manipulator;

    GameObject ai_cards;
    GameObject board_cards;
    GameObject player_cards;

    // Start is called before the first frame update
    void Start()
    {
        card_manipulator = this.gameObject.AddComponent<Card_Display_Manipulation>();
        ai_cards = GameObject.FindGameObjectWithTag("AI_Cards");
        board_cards = GameObject.FindGameObjectWithTag("Board_Cards");
        player_cards = GameObject.FindGameObjectWithTag("Player_Cards");


    }

    // Update is called once per frame
    void Update()
    {
        initial_game_set_visual_setup();
    }

    void initial_game_set_visual_setup()
    {
        card_manipulator.SET_CARD_NUMBER(board_cards, "red", "9");

        card_manipulator.SET_CARD_COLOR(player_cards, "green", "purple");
        card_manipulator.SET_CARD_COLOR(player_cards, "yellow", "purple");
        card_manipulator.SET_CARD_COLOR(player_cards, "white", "purple");
        card_manipulator.SET_CARD_COLOR(player_cards, "blue", "purple");
        card_manipulator.SET_CARD_COLOR(player_cards, "red", "purple");


    }
}
