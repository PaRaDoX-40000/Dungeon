using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMiniGame : MonoBehaviour
{
    [SerializeField] float standartSpeed = 5 ;
    float speed;
    [SerializeField] float a = 0.5f;
    [SerializeField] RectTransform slaider;
    [SerializeField] RectTransform square;
    [SerializeField] RectTransform space;
    [SerializeField] Image complet;
    float time;
    float completeness = 0;
    bool stop=true;
    [SerializeField] CraftEquipable craftEquipable;

    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
            {
            slaider.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (speed > 0)
            {
                speed -= a * Time.deltaTime;

              
                if (slaider.localPosition.x > (space.sizeDelta.x - 20)/2)
                {
                   
                    speed = -standartSpeed / 4;
                }
            }
            else
            {
                if(slaider.localPosition.x> -(space.sizeDelta.x - 20) / 2)
                    speed = -standartSpeed / 4;
                else
                {
                    speed = 0;
                }

            }
            if (slaider.localPosition.x >= square.localPosition.x - square.sizeDelta.x / 2 && slaider.localPosition.x <= square.localPosition.x + square.sizeDelta.x / 2)
            {
                completeness += 0.1f * Time.deltaTime;
                complet.fillAmount = completeness;
            }
            time += Time.deltaTime;
            if (completeness >= 1)
            {

                craftEquipable.Сreate(/*(int)time*/);
                stop = true;
               
                this.gameObject.SetActive(false);
            }
        }
    }
    public void StartMiniGame(int difficult)
    {
        Vector3 vector3 = new Vector3(Random.Range(-difficult, difficult), 0, 0);
        square.position += vector3;
        square.sizeDelta = new Vector2(Random.Range(80, 190)- difficult, square.sizeDelta.y);

        slaider.localPosition = new Vector3(-space.sizeDelta.x/2, 0,0);
        completeness = 0;
        complet.fillAmount = completeness;

       
        
    }
    public void Clik()
    {
        
        speed += standartSpeed;
        stop = false;
    }
}
