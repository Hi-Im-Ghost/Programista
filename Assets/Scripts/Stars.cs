using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stars : MonoBehaviour
{
    public ExamManager examManager;
    //referencja dla tekstury z³otej gwiazdy
    public Sprite gold;
    //referencja dla tekstury srebrnej gwiazdy
    public Sprite silver;
    //referencja dla tekstury br¹zowej gwiazdy
    public Sprite bronze;
    //referencja dla tekstury startowej gwiazdy
    private Sprite start;
    void Start()
    {
        start = GetComponent<Image>().sprite;
    }


}
