using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganManager
{
    public int numOrgans = 5;

    private Organ brain;
    private Organ heart;
    private Organ kidneys;
    private Organ lungs;
    private Organ liver;

    public OrganManager()
    {
        InitBrain();
        InitHeart();
        InitKidneys();
        InitLungs();
        InitLiver();
    }

    private void InitBrain()
    {
        brain = new Organ(
                    "Brain",
                    "1.5 kg",
                    "Contains the brainstem, the cerebellum, and the cerebral cortex, which consists of the four lobes: the frontal, parietal, temporal and occipital lobe. The brain receives input from the sensory organs and sends output to the muscles, and is responsible for processing language, memory, emotion and more.",
                    "Common Issues:");
        brain.AddDisorder("Alzherimer's Disease");
        brain.AddDisorder("Dementia");
        brain.AddDisorder("Seizures");
        brain.AddDisorder("Stroke");
    }

    private void InitHeart()
    {
        brain = new Organ(
                    "Heart",
                    "0.3 kg",
                    "Around the size of a large fist, the heart pumps blood throughout the body via the circulatory system and supplies oxygen and nutrients to tissues, and removes carbon dioxide and other wastes. It is sectioned into four chambers, the atria (upper) and the ventricles (lower).",
                    "Common Issues:");
        brain.AddDisorder("Cardiac Arrest");
        brain.AddDisorder("High Blood Pressure");
        brain.AddDisorder("Congestive Heart Failure");
        brain.AddDisorder("Stroke");
        brain.AddDisorder("Arrhythmia");
    }

    private void InitKidneys()
    {
        brain = new Organ(
                    "Kidney",
                    "0.15 kg",
                    "Known for their bean-like structure, these organs are responsible for keeping the composition of blood in the body balanced to support good health by filtering extra water and toxins from the blood. They are also responsible for producing waste to carry these toxins away, and for creating hormones to regulate blood pressure. Although these organs often come as a duo, the human body can function on one alone.",
                    "Common Issues:");
        brain.AddDisorder("Kidney Stones");
        brain.AddDisorder("Urinary Tract Infection");
        brain.AddDisorder("Polycystic Kidney Disease");
        brain.AddDisorder("Hematuria");
    }

    private void InitLungs()
    {
        brain = new Organ(
                    "Lungs",
                    "1.3 kg",
                    "A crucial part of our respiratory system and waste management, the lungs are responsible for removing oxygen from the atmosphere and transferring it to the blood, where it is transported to cells. They are also responsible for the removal of carbon dioxide. The lungs are split into two sections, the right lung, and the left lung.",
                    "Common Issues:");
        brain.AddDisorder("Asthma");
        brain.AddDisorder("Pulmonary Disease");
        brain.AddDisorder("Bronchitis");
        brain.AddDisorder("Pneumonia");
    }

    private void InitLiver()
    {
        brain = new Organ(
                    "Liver",
                    "1.5 kg",
                    "As it supports almost every other organ, the liver is a vital part of the human body's function. As the body's second-largest organ, it is responsible for detoxification, metabolism, hormone regulation, digestion, and more. The liver is also responsible for plasma generation.",
                    "Common Issues:");
        brain.AddDisorder("Hepatitis A, B, and C");
        brain.AddDisorder("Alcoholic Hepatitis");
        brain.AddDisorder("Hemochromatosis");
        brain.AddDisorder("Bile Duct Diseases");
    }

}

class Organ
{
    private string name;
    private string weight;
    private string description;
    private string disorderPrefix;
    private ArrayList disorderList;

    public Organ(string name, string weight, string description, string disorderPrefix)
    {
        this.name = name;
        this.weight = weight;
        this.description = description;
        this.disorderPrefix = disorderPrefix;
        disorderList = new ArrayList();
    }

    public void AddDisorder(string disorder)
    {
        disorderList.Add(disorder);
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public string Weight
    {
        get
        {
            return weight;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public string DisorderPrefix
    {
        get
        {
            return disorderPrefix;
        }
    }

    public ArrayList DisorderList
    {
        get
        {
            return disorderList;
        }
    }
}
