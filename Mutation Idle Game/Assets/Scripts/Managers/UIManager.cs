using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text foodText;
    public TMP_Text numberCultistText;
    public TMP_Text numberFarmerText;
    public TMP_Text numberArcheologistText;
    public TMP_Text amountMaterialsText;
    public TMP_Text amountRelicsText;
    

    [Header("GameObjects")]
    public GameObject numberFarmer;
    public GameObject numberArcheologist;
    public GameObject amountMaterials;
    public GameObject amountRelics;
    public GameObject titleCorruption;

    [Header("Buttons")]
    public GameObject addOneFarmer;
    public GameObject removeOneFarmer;
    public GameObject addOneArcheologist;
    public GameObject removeOneArcheologist;

    [Header("Misc")]
    public Slider corruptionSlider;

    private int _foodCount;

    private void Start()
    {
        _foodCount = Food.totalFood;
        foodText.text = $"Food - {_foodCount}";
    }

    private void OnEnable()
    {
        _foodCount = Food.totalFood;
        Cultist.OnEating += FoodChanged;
        Food.OnFoodChanged += FoodChanged;
        Food.OnEmpty += EmptyFoodStoreAlert;
        CultManager.OnChangingFarmers += UpdateFarmersText;
        CultManager.OnChangingCultists += UpdateCultistText;
    }

    private void OnDisable()
    {
        Cultist.OnEating -= FoodChanged;
        Food.OnFoodChanged -= FoodChanged;
        Food.OnEmpty -= EmptyFoodStoreAlert;
        CultManager.OnChangingFarmers -= UpdateFarmersText;
        CultManager.OnChangingCultists -= UpdateCultistText;
    }

    private void FoodChanged(object sender, IntegerArgs args)
    {
        _foodCount = Food.totalFood;
        foodText.text = $"Food - {_foodCount}";
    }

    private void EmptyFoodStoreAlert()
    {
        Debug.Log("There is no food left! Please assign more cultists to farming!");
    }

    private void UpdateFarmersText()
    {
        numberFarmerText.text = $"Farmers - {CultManager.NumberOfFarmers}";
    }

    private void UpdateCultistText()
    {
        numberCultistText.text = $"Cultists - {CultManager.NumberOfCultists}";
    }
}
