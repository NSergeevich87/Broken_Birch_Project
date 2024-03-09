using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneHealthCircle : MonoBehaviour
{
    public Image Green_H;
    public Image Yellow_H;
    public Image Red_H;
    private float MaxHealth = 0;
    private float CurrentHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        Green_H.enabled = true;
        Yellow_H.enabled = false;
        Red_H.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthSet(MaxHealth, CurrentHealth);
    }

    void HealthSet(float MaxHealth, float CurrentHealth)
    {
        if (CurrentHealth >= 80) 
        {
            Green_H.enabled = true;
            Yellow_H.enabled = false;
            Red_H.enabled = false;
        }
        else if (CurrentHealth >= 30 && CurrentHealth < 80)
        {
            Green_H.enabled = false;
            Yellow_H.enabled = true;
            Red_H.enabled = false;
        }
        else
        {
            Green_H.enabled = false;
            Yellow_H.enabled = false;
            Red_H.enabled = true;
        }
    }

    public void SetHealth(float CurrentHealth)
    {
        this.CurrentHealth = CurrentHealth;
    }

    public void SetMaxHealth(float MaxHealth)
    {
        this.MaxHealth = MaxHealth;
    }
}
