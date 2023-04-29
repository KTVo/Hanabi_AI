using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanabi : MonoBehaviour
{
    const int GREEN = 0;
    const int YELLOW = 1;
    const int WHITE = 3;
    const int BLUE = 3;
    const int RED = 4;

    int[] ALL_COLORS = {GREEN, YELLOW, WHITE, BLUE, RED};

    int[] COUNTS = {3, 2, 2, 2, 1};

    string[] COLORNAMES = {"green", "yellow", "white", "blue", "red"};

    static int TOTAL_NUM_CARDS = (3+2+2+2+1)*5;
    Card[] deck = new Card[TOTAL_NUM_CARDS];


    private class Card {
        int color;
        int number;

        public Card(int color, int number)
        {
            this.color = color;
            this.number = number;
        }

        void set_number(int num)
        {
            number = num;
        }

        void set_color(int color)
        {
            this.color = color;
        }

        public int get_card_number()
        {
            return number;
        }

        public int get_card_color()
        {
            return color;
        }
    };

    void shuffle_deck()
    {
        for(int i = 0; i < TOTAL_NUM_CARDS; i++)
        {
            int random_num = Random.Range(0, TOTAL_NUM_CARDS);

            Card temp = deck[i];
            deck[i] = deck[random_num];
            deck[random_num] = temp;

        }
    }
    void make_deck()
    {
        
        int card_index = 0;

        int num_of_colors = COLORNAMES.Length;

        for(int i = 0; i < num_of_colors; i++)
        {
            int current_color = ALL_COLORS[i];

            int card_number = 1;

            for(int ii = 0; ii < COUNTS.Length; ii++)
            {
                for(int iii = 0; iii < COUNTS[ii]; iii++)
                {
                    deck[card_index++] = new Card(current_color, card_number);
                }
                card_number++;
            }
        }

        shuffle_deck();
    }

    private void print()
    {
        for(int i = 0; i < TOTAL_NUM_CARDS; i++)
            Debug.Log(COLORNAMES[deck[i].get_card_color()] + " -- " + deck[i].get_card_number());
    }

    private void print_knowledge()
    {
        int[][] k = initial_knowledge();

        for(int i = 0; i < k.Length; i++)
            for(int ii = 0; i < k[i].Length; ii++)
                Debug.Log("k = " + k[i][ii]);
    }

    public int[][] initial_knowledge()
    {
        int[][] knowledge = new int [ALL_COLORS.Length][];

        // Debug.Log("ALL_COLORS.Length * COUNTS.Length = " + ALL_COLORS.Length * COUNTS.Length);
        
        int knowledge_index = 0;
        foreach(int color in ALL_COLORS)
        {
            knowledge[knowledge_index] = new int[COUNTS.Length];
            for(int i = 0; i < COUNTS.Length; i++)
            {
                knowledge[knowledge_index][i] = COUNTS[i];
            }
            knowledge_index++;
        }

        return knowledge;
    }


    public int[][] hint_color(int[][] knowledge, int color, bool truth)
    {
        int[][] result = new int[knowledge.Length][];

        int index_result = 0;

        for(int i = 0; i < ALL_COLORS.Length; i++)
        {
            int col = ALL_COLORS[i];

            if (truth == (col == color))
            {
                for(int ii = 0; ii < knowledge[col].Length; ii++)
                    result[index_result][ii] = knowledge[col][ii];
            }
            else
            {
                for(int ii = 0; ii < knowledge[col].Length; ii++)
                    result[index_result][ii] = 0;
            }
            index_result++;
        }

        
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        make_deck();
        // print();
        print_knowledge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
