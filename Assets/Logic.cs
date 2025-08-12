using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public bool Hardmode = false;
    public int MinumumSpawns = 1;
    public int MaximumSpawns = 1;
    public float ran;
    public bool moved;
    public GameObject grid;
    public GameObject numberfour;
    public GameObject numbertwo; 

    public GameObject[] squarelist;
    
    public List<Vector2> Emptysquarelist;
    public GameObject[] Gameobjectlist;
    public GameObject[,] Coords = new GameObject[40,40];
    public LayerMask layer = (1 << 6);
    public float testy = 0;
    public float testx = 0;
    public float newvalue;
    public ScoreDisplayScript ScoreDisplayScript;
    public NumberValues NumberValues;
    public float oldvalue = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSquares(2);
        squarelist = GameObject.FindGameObjectsWithTag("Square");
        ScoreDisplayScript = GameObject.Find("ScoreDisplay").GetComponent<ScoreDisplayScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Hardmode == false)
            {
                Hardmode = true;

                MinumumSpawns = 1;

                MaximumSpawns = 5;
            }
            else
            {
                Hardmode = false;
                MinumumSpawns = 1;

                MaximumSpawns = 1;
            }

        }



        moved = false;
      

        Gameobjectlist = GameObject.FindGameObjectsWithTag("Number");

        if (Input.GetKeyDown(KeyCode.Escape))

        {

#if UNITY_EDITOR

            EditorApplication.isPlaying = false;

#endif

            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {




    

            GameObject[,] Coords = new GameObject[40, 40];
            foreach (GameObject N in Gameobjectlist)
            {
                int Roundx = (int)Mathf.Round(N.transform.localPosition.x);
                int Roundy = (int)Mathf.Round(N.transform.localPosition.y);
                testy = Roundy + 4;
                testx = Roundx + 4;
                Coords[Roundx + 3, Roundy * - 1] = N;
              //  Debug.Log("loop");
            }

            for (int Indx = 0; Indx <= 3; Indx++)
            {
                int a = 0;
                oldvalue = 0;


                for (int Indy = 0; Indy <= 3; Indy++)
                {
                  //  Debug.Log(Coords[Indx, Indy] + " at " + Indx + "," + Indy);

                    GameObject tempobj = Coords[Indx, Indy];

                    if (tempobj != null)
                    {


                        if (tempobj.CompareTag("Number"))
                        {
                            NumberValues = tempobj.GetComponent<NumberValues>();
                            newvalue = tempobj.GetComponent<NumberValues>().value;

                            if (oldvalue == newvalue && oldvalue != 0)
                            {
                                Debug.Log("reee");
                                a--;
                                Destroy(Coords[Indx, a]);

                                Coords[Indx, a] = tempobj;
                                ScoreDisplayScript.UpdateScore(tempobj.GetComponent<NumberValues>().value * 2);
                                tempobj.GetComponent<NumberValues>().value *= 2;
                                //newvalue = tempobj.GetComponent<NumberValues>().value;
                                tempobj.transform.localPosition = new Vector3(Indx - 3, a * -1, -1);
                                moved = true;
                                
                            }
                            else
                            {
                                if (a != Indy)
                                {
                                    moved = true;
                                }

                                // Debug.Log("is Number");
                                Coords[Indx, a] = tempobj;
                                tempobj.transform.localPosition = new Vector3(Indx - 3, a * -1, -1);
                            }


                            if (Indy != a)
                            {
                                Coords[Indx, Indy] = null;

                            }
                            a++;
                            oldvalue = newvalue;
                        }

                    }
                }

            }
            oldvalue = 0;
            newvalue = 0;

        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject[,] Coords = new GameObject[40, 40];

            foreach (GameObject N in Gameobjectlist)
            {
                int Roundx = (int)Mathf.Round(N.transform.localPosition.x);
                int Roundy = (int)Mathf.Round(N.transform.localPosition.y);
                testy = Roundy + 4;
                testx = Roundx + 4;
                Coords[Roundx + 3, Roundy + 3] = N;
                //  Debug.Log("loop");
            }

            for (int Indx = 0; Indx <= 3; Indx++)
            {
                
                int a = 0;
                oldvalue = 0;


                for (int Indy = 0; Indy <= 3; Indy++)
                {
                    //  Debug.Log(Coords[Indx, Indy] + " at " + Indx + "," + Indy);

                    GameObject tempobj = Coords[Indx, Indy];
                    if (tempobj != null)
                    {


                        if (tempobj.CompareTag("Number"))
                        {
                            NumberValues = tempobj.GetComponent<NumberValues>();
                            newvalue = tempobj.GetComponent<NumberValues>().value;

                            if (oldvalue == newvalue && oldvalue != 0)
                            {
                                Debug.Log("reee");
                                a--;
                                Destroy(Coords[Indx, a]);
                                Coords[Indx, a] = tempobj;
                                ScoreDisplayScript.UpdateScore(tempobj.GetComponent<NumberValues>().value * 2);
                                tempobj.GetComponent<NumberValues>().value *= 2;
                                //newvalue = tempobj.GetComponent<NumberValues>().value;
                                moved = true;

                            }
                            else
                            {
                                if (a != Indy)
                                {
                                    moved = true;
                                }
                                // Debug.Log("is Number");
                                Coords[Indx, a] = tempobj;
                        
                            }
                            tempobj.transform.localPosition = new Vector3(Indx - 3, a - 3, -1);


                            if (Indy != a)
                            {
                                Coords[Indx, Indy] = null;

                            }
                            a++;
                            oldvalue = newvalue;
                            newvalue = 0;
                        }

                    }
                }

            }
            oldvalue = 0;
            newvalue = 0;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject[,] Coords = new GameObject[40, 40];
            
            foreach (GameObject N in Gameobjectlist)
            {
                int Roundx = (int)Mathf.Round(N.transform.localPosition.x);
                int Roundy = (int)Mathf.Round(N.transform.localPosition.y);
                testy = Roundy + 4;
                testx = Roundx + 4;
                Coords[Roundx * -1, Roundy + 3] = N;
                //  Debug.Log("loop");
            }

            for (int Indy = 0; Indy <= 3; Indy++)
            {
                oldvalue = 0;
                int a = 0;


                for (int Indx = 0; Indx <= 3; Indx++)
                {
                    //  Debug.Log(Coords[Indx, Indy] + " at " + Indx + "," + Indy);

                    GameObject tempobj = Coords[Indx, Indy];
                    if (tempobj != null)
                    {


                        if (tempobj.CompareTag("Number"))
                        {
                            NumberValues = tempobj.GetComponent<NumberValues>();
                            newvalue = tempobj.GetComponent<NumberValues>().value;

                            if (oldvalue == newvalue && oldvalue != 0)
                            {
                                Debug.Log("reee");
                                a--;
                                Destroy(Coords[a, Indy]);
                                Coords[a, Indy] = tempobj;
                                ScoreDisplayScript.UpdateScore(tempobj.GetComponent<NumberValues>().value * 2);

                                tempobj.GetComponent<NumberValues>().value *= 2;
                                //newvalue = tempobj.GetComponent<NumberValues>().value;
                                moved = true;

                            }
                            else
                            {
                                if (a != Indx)
                                {
                                    moved = true;
                                }
                                // Debug.Log("is Number");
                                Coords[a, Indy] = tempobj;

                            }
                            tempobj.transform.localPosition = new Vector3(a * -1, Indy -3, -1);


                            if (Indx != a)
                            {
                                Coords[Indx, Indy] = null;

                            }
                            a++;
                            oldvalue = newvalue;
                            newvalue = 0;
                        }

                    }
                }

            }
            oldvalue = 0;
            newvalue = 0;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject[,] Coords = new GameObject[40, 40];

            foreach (GameObject N in Gameobjectlist)
            {
                int Roundx = (int)Mathf.Round(N.transform.localPosition.x);
                int Roundy = (int)Mathf.Round(N.transform.localPosition.y);
                testy = Roundy + 4;
                testx = Roundx + 4;
                Coords[Roundx + 3, Roundy + 3] = N;
                //  Debug.Log("loop");
            }

            for (int Indy = 0; Indy <= 3; Indy++)
            {
                oldvalue = 0;
                int a = 0;


                for (int Indx = 0; Indx <= 3; Indx++)
                {
                    //  Debug.Log(Coords[Indx, Indy] + " at " + Indx + "," + Indy);

                    GameObject tempobj = Coords[Indx, Indy];
                    if (tempobj != null)
                    {


                        if (tempobj.CompareTag("Number"))
                        {
                            NumberValues = tempobj.GetComponent<NumberValues>();
                            newvalue = tempobj.GetComponent<NumberValues>().value;

                            if (oldvalue == newvalue && oldvalue != 0)
                            {
                                Debug.Log("reee");
                                a--;
                                Destroy(Coords[a, Indy]);
                                Coords[a, Indy] = tempobj;
                                ScoreDisplayScript.UpdateScore(tempobj.GetComponent<NumberValues>().value * 2);

                                tempobj.GetComponent<NumberValues>().value *= 2;
                                //newvalue = tempobj.GetComponent<NumberValues>().value;
                                moved = true;

                            }
                            else
                            {
                                if (a != Indx)
                                {
                                    moved = true;
                                }
                                // Debug.Log("is Number");
                                Coords[a, Indy] = tempobj;

                            }
                            tempobj.transform.localPosition = new Vector3(a - 3, Indy - 3, -1);


                            if (Indx != a)
                            {
                                Coords[Indx, Indy] = null;

                            }
                            a++;
                            oldvalue = newvalue;
                            newvalue = 0;
                        }

                    }
                }

            }
            oldvalue = 0;
            newvalue = 0;
        }
        // && 1 == 0
        if (moved == true)
        {
            if (MaximumSpawns < MinumumSpawns)
            {
                MaximumSpawns = MinumumSpawns;
            }
            ran = Mathf.Round(Random.Range(MinumumSpawns, MaximumSpawns));
            GenerateSquares(ran);

        }

    }
    public void GenerateSquares(float Squares)
    {
     
        for (int i = 0; i < Squares; i++)
        {


            Gameobjectlist = GameObject.FindGameObjectsWithTag("Number");
            int addednumbers = Mathf.RoundToInt(Random.Range(1, 2));
            Emptysquarelist.Clear();

            GameObject[,] Coords = new GameObject[40, 40];
            foreach (GameObject N in Gameobjectlist)
            {
                int Roundx = (int)Mathf.Round(N.transform.localPosition.x);
                int Roundy = (int)Mathf.Round(N.transform.localPosition.y);
                testy = Roundy + 4;
                testx = Roundx + 4;
                Coords[Roundx + 3, Roundy + 3] = N;
                //  Debug.Log("loop");
            }

            for (int Indy = 0; Indy <= 3; Indy++)
            {
                for (int Indx = 0; Indx <= 3; Indx++)
                {
                    // Debug.Log(Coords[Indx, Indy] + ", at " + Indx + "," + Indy);

                    if (Coords[Indx, Indy] == null)
                    {
                        // Debug.Log("null");
                        // Emptysquarelist[i] = new Vector2(Indx - 3, Indy - 3);
                        Emptysquarelist.Add(new Vector2(Indx - 3, Indy - 3));
                    }
                    else
                    {
                        //Emptysquarelist[i] = new Vector2(100, 100);
                    }


                }

            }

            int ranind = Random.Range(0, Emptysquarelist.Count);

           
            if ( Emptysquarelist.Count > 0)
            {
                Debug.Log("new square" + Emptysquarelist[ranind].x + ',' + Emptysquarelist[ranind].y);
                if (Mathf.RoundToInt(Random.Range(1, 10)) == 1)
                {

                    Instantiate(numberfour, new Vector3(Emptysquarelist[ranind].x, Emptysquarelist[ranind].y, -1), new Quaternion(0, 0, 0, 0), grid.transform);


                }
                else
                {
                    Instantiate(numbertwo, new Vector3(Emptysquarelist[ranind].x, Emptysquarelist[ranind].y, -1), new Quaternion(0, 0, 0, 0), grid.transform);



                }

            }


        }
    }

}    

    

