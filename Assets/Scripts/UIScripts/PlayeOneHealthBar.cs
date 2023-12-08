using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeOneHealthBar : MonoBehaviour
{
    public Image _bar;
    public RectTransform button;
    public float _MaxHealth = 0;
    public float _ActualHealth = 0;
    public Gradient _gradient;


    //public Slider slider;
    //public Gradient gradient; // Делаю меняющуюся в цвете полоску ХП
    //public Image fill;        // ХП
    void Start()
    {

    }

    void Update()
    {
        HealthChange(_MaxHealth, _ActualHealth);
    }

    void HealthChange(float MaxHealth, float ActualHealth)
    {
        float amount = (ActualHealth / MaxHealth) * 360.0f / 360;
        _bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
        _bar.color = _gradient.Evaluate(amount);
    }

    public void SetMaxHealth(float health)
    {
        _MaxHealth = health;

        //slider.maxValue = health;
        //slider.value = health;
        //fill.color = gradient.Evaluate(1f); //Полоска в цвете
    }

    public void SetHealth(float health)
    {
        _ActualHealth = health;

        //slider.value = health;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
