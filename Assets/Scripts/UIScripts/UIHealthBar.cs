using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    /*public Image _bar;
    public RectTransform button;
    public float _healthValue = 0;
    public Gradient _gradient;*/


    public Slider slider;
    public Gradient gradient; // Делаю меняющуюся в цвете полоску ХП
    public Image fill;        // ХП
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //HealthChange(_healthValue);
    }

    /*void HealthChange(float healthValue)
    {
        float amount = (healthValue / 100.0f) * 360.0f / 360;
        _bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
        _bar.color = _gradient.Evaluate(amount);
    }*/

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f); //Полоска в цвете
    }

    public void SetHealth(float health)
    {
        //_healthValue = health;

        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
