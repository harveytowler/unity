using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject Note;
    List<float> missedNotes;
    // Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        missedNotes = new List<float>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (active)
            {
                Destroy(Note);
                AddScore();
                StartCoroutine(Pressed());
            }
            else
            {
                missedNotes.Add(UnityEngine.Time.fixedTime);

            }
        }
    }

        void OnTriggerEnter2D(Collider2D col)
        {
            active = true;
            if (col.gameObject.tag == "Note")
                Note = col.gameObject;

        }


        void OnTriggerExit2D(Collider2D col)
        {
            active = false;
        }


        void AddScore()
        {
            //PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+100);
            GameObject.Find("Score").GetComponent<PPtext>().score += 100;
        }

        IEnumerator Pressed()
        {
            Color old = sr.color;
            sr.color = new Color(0, 0, 0);
            yield return new WaitForSeconds(0.2f);
            sr.color = old;
        }

    }
