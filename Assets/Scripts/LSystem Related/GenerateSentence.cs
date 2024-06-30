using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GenerateSentence : MonoBehaviour
{
    public string Axiom = "A";

    public Rule[] rules;

    public string sentence = "";

    [Range(1, 10)]
    public int Generations = 1;

    public float Length;
    public float LengthMult;
    public void Generate()
    {

        //string newSentence = "";
        //if (sentence.Length == 0) { sentence = Axiom; }
        //
        //Debug.Log("Generating using: " + sentence);
        //for (int g = 0; g < Generations; g++)
        //{
        //    if (g == 0) { sentence = Axiom; }
        //    for (int i = 0; i < sentence.Length; i++)
        //    {
        //        bool found = false;
        //        string current = sentence[i].ToString();
        //        for (int h = 0; h < rules.Length; h++)
        //        {
        //            if (current == rules[h].ToReplace)
        //            {
        //                found = true;
        //                newSentence += rules[h].Replacer;
        //                break;
        //            }
        //        }
        //
        //        if (!found)
        //        {
        //            Debug.Log("not found");
        //            newSentence += current;
        //        }
        //    }
        //    sentence = newSentence;
        //    GetComponent<LSystemTurtle>().Draw(sentence, g == 0, Length);
        //}

        string nextsentence = Axiom;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Generations; i++)
        {
            foreach (char c in nextsentence)
            {
                bool found = false;

                for (int h = 0; h < rules.Length; h++)
                {

                    if (c.ToString() == rules[h].ToReplace)
                    {
                        found = true;
                        sb.Append(rules[h].Replacer);
                        break;
                    }
                
                }

                if (!found)
                {
                    sb.Append(c);
                }

            }

            sentence = sb.ToString();
            nextsentence = sb.ToString();
            sb = new StringBuilder();

            GetComponent<LSystemTurtle>().Draw(sentence, i == 0, Length * Mathf.Pow(LengthMult, i));
        }
       
    }
}
            

        

