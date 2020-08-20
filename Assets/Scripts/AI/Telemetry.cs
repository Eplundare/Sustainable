﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Telemetry : MonoBehaviour
{
    // Start is called before the first frame update
    Amount[] amountItems;
    public string urlstring = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfC6kpltl-Cdk_9U_uxSIPVk9tW3qG70NUJPH40VdfIRi30fQ/formResponse";
    public float counter;
    System.Guid guid;
    void Start()
    {
        guid = System.Guid.NewGuid();
        counter = Time.time;
        amountItems = FindObjectsOfType<Amount>();
        
        //StartCoroutine(Post());
    }
    public IEnumerator Post(string clickin, string interaction, string industry, string reqs, string amount)
    {
        float total_time = Time.time - counter;
        string clickInteraction = clickin;
        string InteractionType = interaction;
        string industryType = industry;
        string requirements = reqs;
        string amounttrades = amount;
        float food = 0.0f;
        float energy = 0.0f;
        float wasteManagement = 0.0f;
        float pollution = 0.0f;
        float economy = 0.0f;
        float approval = 0.0f;
        float population = 0.0f;
        foreach (Amount item in amountItems)
        {
            if (item.name.Contains("Mile"))
            {
                continue;
            }
            else if (item.name.Contains("food"))
            {
                food = item.amountFloat;
            }
            else if (item.name.Contains("energy"))
            {
                energy = item.amountFloat;
            }
            else if (item.name.Contains("waste"))
            {
                wasteManagement = item.amountFloat;
            }
            else if (item.name.Contains("Pollution"))
            {
                pollution = item.amountFloat;
            }
            else if (item.name.Contains("Economy"))
            {
                economy = item.amountFloat;
            }
            else if (item.name.Contains("Approval"))
            {
                approval = item.amountFloat;
            }
            else if (item.name.Contains("Population"))
            {
                population = item.amountFloat;
            }
        }
        WWWForm form = new WWWForm();
        form.AddField("entry.2142384828", guid.ToString());
        form.AddField("entry.1982025961", total_time.ToString());
        form.AddField("entry.1079424068", clickInteraction);
        form.AddField("entry.416404671", InteractionType);
        form.AddField("entry.1069903528", industryType);
        form.AddField("entry.382307240", requirements);
        form.AddField("entry.1432877640", amounttrades);
        form.AddField("entry.1997210124", food.ToString());
        form.AddField("entry.1193337966", energy.ToString());
        form.AddField("entry.258792244", wasteManagement.ToString());
        form.AddField("entry.1553467135", pollution.ToString());
        form.AddField("entry.1410261082", economy.ToString());
        form.AddField("entry.1876660428", approval.ToString());
        form.AddField("entry.549131437", population.ToString());
        byte[] data = form.data;
        counter = Time.time;
        UnityWebRequest www = UnityWebRequest.Post(urlstring, form);
        yield return www.SendWebRequest();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}