using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSection : MonoBehaviour
{
    public Transform End;

    public GameObject Straight;
    public GameObject Curve30;
    public GameObject Y30;
    
    public void BuildStraightLine() => Instantiate(Straight, End.position, End.rotation);

    public void Build30Curve() => Instantiate(Curve30, End.position, End.rotation);

    public void Build30Y() => Instantiate(Y30, End.position, End.rotation);
}
