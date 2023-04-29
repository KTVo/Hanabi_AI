using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Card_Display_Manipulation : MonoBehaviour
{
    public GameObject ai_cards;
    public GameObject board_cards;
    public GameObject player_cards;

    const int card_number_chid_index = 0;
    const int play_btn_child_index = 1;
    const int discard_btn_child_index = 2;
    
    Dictionary<string, int> get_child_index_by_get_color = new Dictionary<string, int>()
    {
        {"green", 0}, {"yellow", 1}, {"white", 2}, {"blue", 3}, {"red", 4}
    };

    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public Color GET_RGB_VALUE(string color_name)
    {
        if(color_name == "green")
        {
            return new Color(5, 255, 0, 255);
        }
        else if (color_name == "yellow")
        {
            return new Color(245, 255, 0, 255);
        }
        else if (color_name == "white")
        {
            return new Color(255, 255, 255, 255);
        }
        else if (color_name == "blue")
        {
            return new Color(0, 173, 255, 255);
        }
        else if(color_name == "red")
        {
            return new Color(255, 0, 0, 255);
        }

        // purple
        return new Color(148, 0, 211, 255);
        
        
    }

    public GameObject GET_AI_CARDS()
    {
        return ai_cards;
    }

    public GameObject GET_BOARD_CARDS()
    {
        return board_cards;
    }


    public GameObject GET_PLAYER_CARDS()
    {
        return player_cards;
    }



    public void SET_CARD_NUMBER(GameObject card_owner, string card_color, string new_number_value)
    {

        Transform chosen_card = null;


        if(get_child_index_by_get_color.ContainsKey(card_color))
            //Obtains the Card_Number child gameObject
            chosen_card = card_owner.transform.GetChild(get_child_index_by_get_color[card_color]).GetChild(card_number_chid_index);

        if(chosen_card != null)
            //Changes the card number
            chosen_card.GetComponent<TextMeshPro>().text = new_number_value;        

    }

    public void SET_CARD_COLOR(GameObject card_owner, string card_color, string new_color_value)
    {
        Transform chosen_card = null;

        if (get_child_index_by_get_color.ContainsKey(card_color))
            //Obtains the Card_Number child gameObject
            chosen_card = card_owner.transform.GetChild(get_child_index_by_get_color[card_color]);

        if (chosen_card != null)
        {
            //Changes the card number
            chosen_card.GetComponent<SpriteRenderer>().color = GET_RGB_VALUE(new_color_value);
            //Get the Play btn color
            Transform play_btn_child = card_owner.transform.GetChild(get_child_index_by_get_color[card_color]).GetChild(play_btn_child_index);
            //Get the Discard btn color
            Transform discard_btn_child = card_owner.transform.GetChild(get_child_index_by_get_color[card_color]).GetChild(discard_btn_child_index);

            play_btn_child.GetComponentInChildren<SpriteRenderer>().color = GET_RGB_VALUE(new_color_value);

            discard_btn_child.GetComponentInChildren<SpriteRenderer>().color = GET_RGB_VALUE(new_color_value);

        }
            
    }

    
}
