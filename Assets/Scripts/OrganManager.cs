using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganManager
{
    public Organ brain;
    public Organ heart;
    public Organ kidneys;
    public Organ lungs;
    public Organ liver;

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
                    "    Contains the brainstem, the \ncerebellum, and the cerebral \ncortex, and four lobes.The brain \nreceives input from the sensory \norgans and sends output to the \nmuscles, and is responsible for \nprocessing language, memory, \nemotion and more.",
                    "Common Issues:");
        brain.AddDisorder("Alzherimer's Disease");
        brain.AddDisorder("Dementia");
        brain.AddDisorder("Seizures");
        brain.AddDisorder("Stroke");
    }

    private void InitHeart()
    {
        heart = new Organ(
                    "Heart",
                    "0.3 kg",
                    "Around the size of a large fist, \nthe heart pumps blood throughout \nthe body via the circulatory system, \nsupplies oxygen and nutrients \nto tissues, and removes carbon \ndioxide and other wastes. It is \nsectioned into four chambers, the \natria (upper) and the ventricles (lower).",
                    "Common Issues:");
        heart.AddDisorder("Cardiac Arrest");
        heart.AddDisorder("High Blood Pressure");
        heart.AddDisorder("Stroke");
        heart.AddDisorder("Arrhythmia");
    }

    private void InitKidneys()
    {
        kidneys = new Organ(
                    "Kidney",
                    "0.15 kg",
                    "Known for their bean-like structure, \nthese organs are responsible for \nkeeping the composition of blood in \nthe body balanced to support good \nhealth. They are also responsible for \nproducing waste to carry these toxins \naway, and for creating hormones to \nregulate blood pressure.",
                    "Common Issues:");
        kidneys.AddDisorder("Kidney Stones");
        kidneys.AddDisorder("Urinary Tract Infection");
        kidneys.AddDisorder("Polycystic Kidney Disease");
        kidneys.AddDisorder("Hematuria");
    }

    private void InitLungs()
    {
        lungs = new Organ(
                    "Lungs",
                    "1.3 kg",
                    "A crucial part of our respiratory system \nand waste management, the lungs are \nresponsible for removing oxygen from \nthe atmosphere and transferring it to \nthe blood. They are also responsible \nfor the removal of carbon dioxide. The \nlungs are split into two sections, the \nright lung, and the left lung.",
                    "Common Issues:");
        lungs.AddDisorder("Asthma");
        lungs.AddDisorder("Pulmonary Disease");
        lungs.AddDisorder("Bronchitis");
        lungs.AddDisorder("Pneumonia");
    }

    private void InitLiver()
    {
        liver = new Organ(
                    "Liver",
                    "1.5 kg",
                    "As it supports almost every other organ, \nthe liver is a vital part of the human \nbody's function. As the body's second-\nlargest organ, it is responsible for \ndetoxification, metabolism, hormone \nregulation, digestion, and more. The \nliver is also responsible for plasma \ngeneration.",
                    "Common Issues:");
        liver.AddDisorder("Hepatitis A, B, and C");
        liver.AddDisorder("Alcoholic Hepatitis");
        liver.AddDisorder("Hemochromatosis");
        liver.AddDisorder("Bile Duct Diseases");
    }

    public Organ GetOrgan(string name)
    {
        switch(name)
        {
            case "Brain":
                return brain;
            case "Heart":
                return heart;
            case "Kidney":
                return kidneys;
            case "Lungs":
                return lungs;
            case "Liver":
                return liver;
            default:
                return brain;
        }
    }

}

public class Organ
{
    public string name;
    public string weight;
    public string description;
    public string disorderPrefix;
    public ArrayList disorderList;

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
}
