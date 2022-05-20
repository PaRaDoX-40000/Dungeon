using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class PeculiaritiesCollection: ScriptableObject
{
    [SerializeField] private List<Peculiarity> peculiaritiesLIst;
    public List<Peculiarity> PeculiaritiesLIst => peculiaritiesLIst;

}






