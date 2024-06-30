using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemTurtle : MonoBehaviour
{
    public Transform currTrans;
    public Vector3 savedPos;
    public Quaternion savedRot;
    public Quaternion currentRot;
    public GameObject Line;


    private Stack<TransformInfo> transformStack;

    [Header("Settings")]
    [Range(0,360)]
    public int Angle;

    private List<GameObject> Lines = new List<GameObject>();
    public void Draw(string sentence, bool reset, float length)
    {
        //SETUP
        if (reset)
        {
            transformStack = new Stack<TransformInfo>();

            if (currTrans == null) { return; }
            currTrans.position = Vector3.zero;
            Quaternion q = currTrans.rotation;
            q.eulerAngles = Vector3.zero;
            currTrans.rotation = q;
            for (int i = 0; i < Lines.Count; i++)
            {
                DestroyImmediate(Lines[i]);
            }
            Lines.Clear();
        }
        //LineRenderer l = Line.GetComponent<LineRenderer>();
        //l.startWidth *= 0.5f;
        //l.endWidth *= 0.5f;

       
        for (int i = 0; i < sentence.Length; i++)
        {
            string current = sentence[i].ToString();

            if (current == "F")
            {
                var LR = Instantiate(Line, currTrans.position, transform.rotation, transform).GetComponent<LineRenderer>();
                Lines.Add(LR.gameObject);
                Vector3[] pos = { currTrans.position, currTrans.position + currTrans.up * length };
                LR.SetPositions(pos);
                currTrans.position = pos[1];
            }
            else if(current == "V")
            {
                var LR = Instantiate(Line, currTrans.position, transform.rotation, transform).GetComponent<LineRenderer>();
                Lines.Add(LR.gameObject);
                Vector3[] pos = { currTrans.position, currTrans.position + currTrans.up * length };
                LR.SetPositions(pos);
                currTrans.position = pos[1];
            }
            else if (current == "X")
            {
                
            }
            else if (current == "+")
            {
                //Quaternion q = currTrans.rotation;
                //q = Quaternion.Euler(currTrans.rotation.x + Angle, 0, 0);
                //q.eulerAngles = new Vector3(q.eulerAngles.x, 0, 0);
                //currTrans.rotation = q;

                currTrans.Rotate(Vector3.right, Angle);
            }
            else if (current == "-")
            {
                //Quaternion q = currTrans.rotation;
                //q = Quaternion.Euler(currTrans.rotation.x - Angle, 0, 0);
                //q.eulerAngles = new Vector3(q.eulerAngles.x, 0, 0);
                //currTrans.rotation = q;

                currTrans.Rotate(Vector3.left, Angle);
            }
            else if (current == "[")
            {
                //savedPos = currTrans.position;
                //savedRot = currTrans.rotation;
                //Debug.Log(savedRot + "zzz");
                transformStack.Push(new TransformInfo()
                {
                    Position = currTrans.position,
                    rotation = currTrans.rotation
                });
            }
            else if (current == "]")
            {
                //currTrans.position = savedPos;
                //currTrans.rotation = savedRot;
                TransformInfo ti = transformStack.Pop();
                currTrans.position = ti.Position;
                currTrans.rotation = ti.rotation;
            }
            
        }
    }   
    
}
