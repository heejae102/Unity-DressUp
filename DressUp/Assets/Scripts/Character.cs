using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    List<GameObject> myHairs = new List<GameObject>();
    List<GameObject> myUppers = new List<GameObject>();
    List<GameObject> myBottoms = new List<GameObject>();

    Transform hairGroup;
    Transform upperGroup;
    Transform bottomGroup;

    public int hairNum = 0;
    public int upperNum = 0;
    public int bottomNum = 0;
    
    private void Awake()
    {
        hairGroup = transform.Find("hairGroup");
        upperGroup = transform.Find("upbodyGroup");
        bottomGroup = transform.Find("downBodyGroup");
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeDresses(hairGroup, myHairs);
        MakeDresses(upperGroup, myUppers);
        MakeDresses(bottomGroup, myBottoms);

        if (PlayerPrefs.HasKey("hair") == true)
        {
            LoadSavedDresses();
        }
        else InitDresses();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void InitDresses()
    {
        ShowDress(myHairs, hairNum);
        ShowDress(myUppers, upperNum);
        ShowDress(myBottoms, bottomNum);
    }

    public void SaveCurrentDresses()
    {
        PlayerPrefs.SetInt("hair", hairNum);
        PlayerPrefs.SetInt("upper", upperNum);
        PlayerPrefs.SetInt("bottom", bottomNum);
    }

    void LoadSavedDresses()
    {
        hairNum = PlayerPrefs.GetInt("hair");
        upperNum = PlayerPrefs.GetInt("upper");
        bottomNum = PlayerPrefs.GetInt("bottom");

        InitDresses();
    }

    void MakeDresses(Transform dressGroup, List<GameObject> dressList)
    {
        foreach(Transform dress in dressGroup)
        {
            dressList.Add(dress.gameObject);
            dress.gameObject.SetActive(false);
        }
    }

    void ShowDress(List<GameObject> dressList, int dressNumber)
    {
        for(int i=0; i<dressList.Count; i++)
        {
            dressList[i].SetActive(false);
        }

        dressList[dressNumber].SetActive(true);
    }

    public void ChangeHair()
    {
        hairNum++;

        if (hairNum > myHairs.Count - 1) hairNum = 0;

        ShowDress(myHairs, hairNum);
    }

    public void ChangeUpper()
    {
        upperNum++;

        if (upperNum > myUppers.Count - 1) upperNum = 0;

        ShowDress(myUppers, upperNum);
    }

    public void ChangeBottom()
    {
        bottomNum++;

        if (bottomNum > myBottoms.Count - 1) bottomNum = 0;

        ShowDress(myBottoms, bottomNum);
    }
}
