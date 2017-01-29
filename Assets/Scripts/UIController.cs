﻿//using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ARTCards;

/// <summary>
/// Main class to control the UI.
/// Contains references to the different process of
/// applying a att card, effect card, selecting a unit, etc
/// </summary>

public class UIController : MonoBehaviour {

    #region General Use Variables
    //General use variables

    public GameObject[] portraitButtons;

    //public GameObject portraitButton1;
    //public GameObject portraitButton2;
    //public GameObject portraitButton3;

    public GameObject actionBarButtonAttributeCards;
    public GameObject actionBarButtonEffectCards;

    public Animator topinfo;
    public Animator actionBarButtonAttributeCardsAnimator;
    public Animator actionBarButtonEffectCardsAnimator;
    public Animator charsheetAttributeCards;
    public Animator charsheetEffectCards;
    public Animator actionPlusAttributeCard;
    public Animator actionPlusEffectCard;

    public bool animationStateActionBarAttributeCard;
    public bool animationStateActionBarEffectCard;
    public bool animationStateCharSheetAttributeCard;
    public bool animationStateCharSheetEffectCard;

    //used as a parameter for showCHangesOnthiscRad and ApplyChanges functions
    public int unitSelected;

    #endregion

    #region Attribute Card variables

    //one injection of attribute cards per turn
    public bool injectionPerTurn = false;

    public GameObject injectButton;
    public GameObject abortInjectionButton;

    public GameObject activateChangesButtonAttributeCard;
    //public GameObject declineInjectionButtonAttributeCard;

    public GameObject finishInjectionButton;

    public GameObject cardImageAttributeCard;
    public Text cardStatsPreviewAttributeCard;
    public Text unitStatsPreviewAttributeCard;
   // public string[] textID;

    public GameObject minimizeProcessButtonAttributeCard;
    public GameObject showInjectionProcessButtonAttributeCard;

    //comment this as we have set up a serialized class to help
    public Sprite[] spriteArray;

    public CardImage[] cardImageArray;
    // public Player player1;
    // public Player player2;

    public Player player;

    public ScannedCardActivator scannedCardActivator;

    #endregion

    #region Effect Card variables

    public bool effectCardPerTurn;

    //public EffectCardInjector effectCardInjector;

    //need in case to apply an effect to a unit
    public GameObject effectCardPannel;

    public GameObject effectCardImage;
    public Text effectCardInfo;
    public Text unitStatsPreviewEffectCard;

    //to continue the proces of using a card
    public GameObject activateEffectCardButton;
    //public GameObject declineUseEffectCardButton;

    //to end the process
    public GameObject exitEffectCardButton;

    //to apply boost on units
    public GameObject activateChangesEffectCardButton;
    //public GameObject declineChangesEffectCardButton;

    public GameObject minimizeEffectCardButton;
    public GameObject showEffectCardProcessButton;

    //sprite array for the images of the effect cards
    public Sprite[] spriteArrayEffectCards;



    #endregion

    // Use this for initialization
    void Start()
    {
        #region General variable Initialization

        player = new Player();

        animationStateCharSheetAttributeCard = false;
        animationStateCharSheetEffectCard = false;
 
        //actionBarButtonAttributeCards = GameObject.Find("actionBarButtonAttributeCards");
        //actionBarButtonEffectCards = GameObject.Find("actionBarButtonEffectCards");

    #endregion



    #region Attribute Card Initialization

        //injectButton = GameObject.Find("InjectButton");
        //activateChangesButtonAttributeCard = GameObject.Find("ActivateChangesButton");
        //declineInjectionButtonAttributeCard = GameObject.Find("DeclineInjectionButton");
        //abortInjectionButton = GameObject.Find("AbortInjectionButton");
        //finishInjectionButton = GameObject.Find("FinishInjectionButton");
        //cardImageAttributeCard = GameObject.Find("CardImage");
        ////cardImage = GetComponent<Image>();
        //minimizeProcessButtonAttributeCard = GameObject.Find("MinimizeProcessButton");
        //showInjectionProcessButtonAttributeCard = GameObject.Find("ShowInjectionProcessButton");
        ////unitStatsPreviewAttributeCard = GameObject.Find("UnitStatsPreviewAttributeCards");
        //unitStatsPreviewAttributeCard = GameObject.Find("UnitStatsPreviewAttributeCards").GetComponent<Text>();
        //cardStatsPreviewAttributeCard = GameObject.Find("CardStatsPreview").GetComponent<Text>();

        activateChangesButtonAttributeCard.SetActive(false);
        //declineInjectionButtonAttributeCard.SetActive(false);
        abortInjectionButton.SetActive(false);
        showInjectionProcessButtonAttributeCard.SetActive(false);
        finishInjectionButton.SetActive(false);
        minimizeProcessButtonAttributeCard.SetActive(false);

        actionBarButtonAttributeCards.SetActive(false);
        Debug.Assert(actionBarButtonEffectCards != null, "Effect card button not set!");
        actionBarButtonEffectCards.SetActive(false);

        //ShowInjectionButton();
        //ActivatePannel();

        // unit1 = new ARTCards.Unit();

        //player = new Player[2];
        //player = new Player();
        
    #endregion


    #region Effect Card Initialization

    //activateEffectCardButton = GameObject.Find("activateEffectCardButton");
    //    activateChangesEffectCardButton = GameObject.Find("activateChangesEffectCardButton");
    //    declineUseEffectCardButton = GameObject.Find("declineUseEffectCardButton ");
    //    declineChangesEffectCardButton = GameObject.Find("declineChangesEffectCardButton");
    //    exitEffectCardButton = GameObject.Find("ExitEffectCardButton");
    //    effectCardImage = GameObject.Find("effectCardImage");
    //    //unitStatsPreviewEffectCard = GameObject.Find("unitStatsPreviewEffectCard").GetComponent<Text>();

    //    minimizeEffectCardButton = GameObject.Find("MinimizeEffectCardButton");
    //    showEffectCardProcessButton = GameObject.Find("ShowInjectionProcessButton");

        #endregion
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    #region General Functions

    /// <summary>
    /// Loads the UI needed to make an injection of an
    /// attribute card
    /// </summary>
    public void LoadAttributeCardsActionBar()
    {
        actionBarButtonAttributeCards.SetActive(true);
        injectButton.SetActive(true);
    }

    /// <summary>
    /// Loads the UI needed to make an injection of an
    /// attribute card
    /// </summary>
    public void LoadEffectCardsActionBar()
    {
        actionBarButtonEffectCards.SetActive(true);
    }

    public void SwitchActionBarAttributeCard()
    {
        animationStateCharSheetAttributeCard = actionBarButtonAttributeCardsAnimator.GetBool("actionbar_open");
        if (animationStateCharSheetAttributeCard == false)
        {
            actionBarButtonAttributeCardsAnimator.SetBool("actionbar_open", true);
            //actionBarButtonAttributeCardsAnimator.SetBool("action_closed", true);
            ActivateAttributeCardButtons();
            //Debug.Log ("open");
        }
        else
        {
            actionBarButtonAttributeCardsAnimator.SetBool("actionbar_open", false);
            //actionBarButtonAttributeCardsAnimator.SetBool("action_closed", false);
            DesactivateAttributeCardButtons();
            //Debug.Log ("close");

        }
    }

    public void SwitchActionBarEffectCard()
    {
        animationStateCharSheetEffectCard = actionBarButtonEffectCardsAnimator.GetBool("actionbar_open");
        if (animationStateCharSheetEffectCard == false)
        {
            actionBarButtonEffectCardsAnimator.SetBool("actionbar_open", true);
            //actionBarButtonEffectCardsAnimator.SetBool("action_closed", true);
            ActivateEffectCardButtons();
            //Debug.Log ("open");
        }
        else
        {
            actionBarButtonEffectCardsAnimator.SetBool("actionbar_open", false);
            //actionBarButtonEffectCardsAnimator.SetBool("action_closed", false);
            DesactivateEffectCardButtons();
            //Debug.Log ("close");

        }
    }

    public void SwitchCharSheetAttributeCard()
    {
        animationStateCharSheetAttributeCard = charsheetAttributeCards.GetBool("isopen");
        if (animationStateCharSheetAttributeCard == false)
        {
            charsheetAttributeCards.SetBool("isopen", false);
        }
        else
        {
            charsheetAttributeCards.SetBool("isopen", true);
        }
    }

    public void SwitchCharSheetEffectCard()
    {
        animationStateCharSheetEffectCard = charsheetEffectCards.GetBool("isopen");
        if (animationStateCharSheetEffectCard == false)
        {
            charsheetEffectCards.SetBool("isopen", true);
        }
        else
        {
            charsheetEffectCards.SetBool("isopen", false);
        }
    }

    public void ActivateAttributeCardButtons()
    {
        //injectButton.SetActive(true);
        //abortInjectionButton.SetActive(true);
        activateChangesButtonAttributeCard.SetActive(true);
        //declineInjectionButtonAttributeCard.SetActive(true);
        minimizeProcessButtonAttributeCard.SetActive(true);
        showInjectionProcessButtonAttributeCard.SetActive(true);
        finishInjectionButton.SetActive(true);
    }

    public void DesactivateAttributeCardButtons()
    {
        //injectButton.SetActive(false);
        //abortInjectionButton.SetActive(false);
        activateChangesButtonAttributeCard.SetActive(false);
        //declineInjectionButtonAttributeCard.SetActive(false);
        minimizeProcessButtonAttributeCard.SetActive(false);
        showInjectionProcessButtonAttributeCard.SetActive(false);
        finishInjectionButton.SetActive(false);
    }

    public void ActivateEffectCardButtons()
    {
        activateEffectCardButton.SetActive(true);
        //activateChangesEffectCardButton.SetActive(true);
        //declineChangesEffectCardButton.SetActive(true);
        minimizeEffectCardButton.SetActive(true);
        showEffectCardProcessButton.SetActive(true);
        exitEffectCardButton.SetActive(true);
    }

    public void DesactivateEffectCardButtons()
    {
        //activateEffectCardButton.SetActive(false);
        activateChangesEffectCardButton.SetActive(false);
        //declineChangesEffectCardButton.SetActive(false);
        minimizeEffectCardButton.SetActive(false);
        showEffectCardProcessButton.SetActive(false);
        exitEffectCardButton.SetActive(false);
    }

    #endregion


    #region Attribute Card Functions

    public void ResetAttributeCardInjection()
    {
        activateChangesButtonAttributeCard.SetActive(false);
        //declineInjectionButtonAttributeCard.SetActive(false);
        abortInjectionButton.SetActive(false);
        showInjectionProcessButtonAttributeCard.SetActive(false);
        finishInjectionButton.SetActive(false);
        minimizeProcessButtonAttributeCard.SetActive(false);

        actionBarButtonAttributeCards.SetActive(false);
        Debug.Assert(actionBarButtonEffectCards != null, "Effect card button not set!");
        actionBarButtonEffectCards.SetActive(false);
    }

    void DisableOverflowingUnitsAttributeCard()
    {
        //first, we activate them as this function is called when
        //a new injection of att card has started
        for (int i = 0; i < player.units.Length; i++)
        {
            portraitButtons[i].GetComponent<Button>().interactable = true;
            Debug.Log("activating portrait button " + portraitButtons[i]);
        }

        for (int i = 0; i < player.units.Length; i++)
        {
            Attribute[] unitAttrArray = new Attribute[player.units[i].attrs.Count];
            player.units[i].attrs.Values.CopyTo(unitAttrArray, 0);

            if (!player.activeCard.isNotOverflowing(unitAttrArray))
            {
                portraitButtons[i].GetComponent<Button>().interactable = false;
                Debug.Log("Disable portrait button" + portraitButtons[i]);
            }
        }
       
    }

    /// <summary>
    /// If you press this button, the procces of injection
    /// of the card scanned begins
    /// It cannot be pressed if another injection has been done on this turn
    /// by the same player
    /// </summary>
    public void ActivateInjectionButton()
    {
        if (injectionPerTurn == false) //&& this button is pressed
        {
            //HighlightPortrait();
            injectButton.SetActive(false);
            cardImageAttributeCard.SetActive(false);
            //abortInjectionButton.SetActive(false);
            //minimizeProcessButtonAttributeCard.SetActive(true);
            //showInjectionProcessButtonAttributeCard.SetActive(true);
            //exitEffectCardButton.SetActive(true);

            SwitchActionBarAttributeCard();

            DisableOverflowingUnitsAttributeCard();
        }
        else
            Debug.Log("You cannot inject another card on the same turn.");


        //needes to be false at the beginnign fo the new turn
        injectionPerTurn = true;
    }

    /// <summary>
    /// Desactivates the process of injection
    /// </summary>
    public void AbortInjectionButton()
    {
        actionBarButtonAttributeCards.SetActive(false);
    }

    public void ActivateDeclineInjectionButton()
    {
        //declineInjectionButtonAttributeCard.SetActive(false);
        //HighlightPortrait();
        injectButton.SetActive(true);
        cardImageAttributeCard.SetActive(true);
        abortInjectionButton.SetActive(false);
        activateChangesButtonAttributeCard.SetActive(false);
    }

    /// <summary>
    /// Loads the source image preview.
    /// </summary>
    /// <param name="imgID">Source image.</param>
    public void LoadSourceImagePreview(int imgID)
    {
        //players[]
        Debug.Log("Source image: " + imgID);
        cardImageAttributeCard.GetComponent<Image>().sprite = cardImageArray[imgID].cardSprite;

        //for (int i = 0; i < 16; i++)
        //{

        //    cardImages[i].SetActive(false);
        //}

        //cardImages[sourceImage].SetActive(true);

        int[] cardAttrs = player.activeCard.attributes;

        cardStatsPreviewAttributeCard.text = "CardStatsPreview " +
                "\nStrenght:" + cardAttrs[0]
                + "\nAgility:" + cardAttrs[1]
                + "\nRange:" + cardAttrs[2];
    }

    /// <summary>
    /// This function will be called when the playes has pressed
    /// a portrait
    /// The unit portrait on the UI will need to have a
    /// call to this function
    /// Thhis funcion will show the changes provides on the card choosed
    /// </summary>

    public void ShowChangesOnThisCard(int unitID)
    {
        SwitchActionBarAttributeCard();
        //declineInjectionButtonAttributeCard.SetActive(true);
        this.unitSelected = unitID;
        ShowUnitStatsPreview(this.unitSelected);
    }

    /// <summary>
    /// Takes the unit stats and show them with the changes of the card
    /// on the UI as a text
    /// </summary>
    public void ShowUnitStatsPreview(int unitID)
    {
        this.unitSelected = unitID;
        Debug.Log("Unit numberrrr: " + unitID);
        //Debug.Log("Player " + player);
        //Debug.Log("Units " + player.units[0]);

        Attribute[] arr_attributesUnit = new Attribute[player.units[this.unitSelected].attrs.Count];
        //player.units[unitID].attrs.Values.CopyTo(arr_attributesUnit, 0);
        player.units[this.unitSelected].attrs.Values.CopyTo(arr_attributesUnit, 0);

        // Attribute[] arr_attributesActiveCard = new Attribute[player1.activeCard.attributes.GetLength(0)];
        //  player1.activeCard.attributes.CopyTo(arr_attributesActiveCard, 0);
        //if (player.activeCard == null){
        if (player.activeCard == null)
        {
            Debug.LogError("Active card is not setup! Aborting");
            return;
        }
        //int[] cardAttrs = player.activeCard.attributes;
        int[] cardAttrs = player.activeCard.attributes;


        string[] statBonus = new string[cardAttrs.Length];
        for (int i = 0; i < statBonus.Length; i++)
        {
            if (cardAttrs[i] < 0)
            {
                statBonus[i] = "<color=#ff0000ff> " + cardAttrs[i] + " </color>";
            }
            else
            {

                statBonus[i] = "<color=#00ff00ff> +" + cardAttrs[i] + " </color>";
            }
        }

        //here we are checking if the card can be applied
        //if not, we will design a function to finish the injection process
        //if (!player.activeCard.isNotOverflowing(arr_attributesUnit))//if is false
        if (!player.activeCard.isNotOverflowing(arr_attributesUnit))
        {
            Debug.LogError("The card overflows unit stats");
            return;
        }

        //we need to make calculations of the attributes to show then on the
        //following text value, which belongs to the UI

        Debug.Log("debug for unit stats" + unitStatsPreviewAttributeCard);

        ////Here we upload the unit stats preview with the 
        //values calculated with card functions
        //One this has been done, the player can press Activate Injection
        //Activate Injection button will call the funcion ApplyChangesInjection
        //unitStatsPreview = GameObject.Find("UnitStatsPreview").GetComponent<Text>();
        //unitStatsPreview.text = "StatsChangedPreview\n Unit-> " + player.units[unitID].name +
        unitStatsPreviewAttributeCard.text = "StatsChangedPreview\n Unit-> " + player.units[this.unitSelected].name +
                "\nStrenght:" + arr_attributesUnit[0].Value + statBonus[0]
                + "\nAgility:" + arr_attributesUnit[1].Value + statBonus[1]
                + "\nRange:" + arr_attributesUnit[2].Value + statBonus[2];

        Debug.Log("Strenght: " + arr_attributesUnit[0].Value + statBonus[0]);
    }


    /// <summary>
    /// Apply the changes of the injection of the card selected on the character
    /// </summary>
    public void ApplyChangesInjection()
    {
        //Attribute[] arr = new Attribute[player.units[unitID].attrs.Count];
        //player.units[unitID].attrs.Values.CopyTo(arr, 0);

        Attribute[] arr_attributesUnit = new Attribute[player.units[this.unitSelected].attrs.Count];
        //player.units[unitID].attrs.Values.CopyTo(arr_attributesUnit, 0);
        player.units[this.unitSelected].attrs.Values.CopyTo(arr_attributesUnit, 0);
        //if (player.activeCard.isNotOverflowing(arr_attributesUnit))
        if (player.activeCard.isNotOverflowing(arr_attributesUnit))
        {
            //player.units[unitID].Buff(player.activeCard.attributes);
            player.units[this.unitSelected].Buff(player.activeCard.attributes);
            // player[i].deck.Bury(player[i].activeCard);
            // player[i].activeCard = null;
            //    // holdingCard = false;
            //}
        }
        //Once the changes had been applied to the unit, we desactivate the process of injection
        Debug.Log("Finishing the process of injection of the card selected");
        //injectionPannel.SetActive(false);

        AbortInjectionButton();
    }

    //------------------------------------------------------------------------------

    /// <summary>
    /// hides the pannel with the procces of injection
    /// lets the player see whats happening on the field
    /// </summary>
    public void ActivateMinimizeButton()
    {
        // injectionPannelAttributeCard.SetActive(false);
        SwitchActionBarAttributeCard();
        cardImageAttributeCard.SetActive(false);
        //showInjectionProcessButtonAttributeCard.SetActive(true);
    }


    /// <summary>
    /// Activates again the pannel which contains the info and about
    /// related to the injection of cards
    /// Called by the ShowInjectionProcessButton button button
    /// </summary>
    //public void ActivatePannel()
    //{
    //    injectionPannelAttributeCard.SetActive(true);
    //}


    public void ActivateShowInjectionProcessButton()
    {
        showInjectionProcessButtonAttributeCard.SetActive(false);
        SwitchActionBarAttributeCard();
    }

    #endregion


    #region Effect Card Functions

    void DisableOverflowingUnitsEffectCard()
    {
        //first, we activate them as this function is called when
        //a new injection of att card has started
        for (int i = 0; i < player.units.Length; i++)
        {
            portraitButtons[i].GetComponent<Button>().interactable = true;
            Debug.Log("activating portrait button " + portraitButtons[i]);
        }

        for (int i = 0; i < player.units.Length; i++)
        {
            Attribute[] unitAttrArray = new Attribute[player.units[i].attrs.Count];
            player.units[i].attrs.Values.CopyTo(unitAttrArray, 0);

            if (!player.activeCard.isNotOverflowing(unitAttrArray))
            {
                portraitButtons[i].GetComponent<Button>().interactable = false;
                Debug.Log("Disable portrait button" + portraitButtons[i]);
            }
        }

    }

    //needs to contain code related to effect cards
    public void ActivateEffectCard()
    {
        if (effectCardPerTurn == false) //&& this button is pressed
        {
            //HighlightPortrait();
            //HideInjectionButton();
            //HideCardImage();
            //ShowAbortInjectionButton();
        }
        else
            Debug.Log("You cannot inject another card on the same turn.");

    }


    /// <summary>
    /// Desactivates the process of injection
    /// </summary>
    public void ExitEffectCard()
    {
        actionBarButtonEffectCards.SetActive(false);
    }

    /// <summary>
    /// Needed if the player is injecting some behaviour/boost
    /// on a unit. We need to go back to select another unit
    /// </summary>
    public void ActivateDeclineEffectCardButton()
    {
        //declineUseEffectCardButton.SetActive(false);
        //HighlightPortrait();
        activateEffectCardButton.SetActive(false);
        effectCardImage.SetActive(false);
        exitEffectCardButton.SetActive(false);
        activateChangesEffectCardButton.SetActive(false);
    }

    /// <summary>
    /// Loads the source image preview.
    /// </summary>
    /// <param name="sourceImage">Source image.</param>
    public void LoadSourceImagePreviewEffectCard(int sourceImage)
    {
        //players[]
        Debug.Log("Source image: " + sourceImage);
        effectCardImage.GetComponent<Image>().sprite = spriteArrayEffectCards[sourceImage];

        //for (int i = 0; i < 16; i++)
        //{

        //    cardImages[i].SetActive(false);
        //}

        //cardImages[sourceImage].SetActive(true);

        int[] cardAttrs = player.activeCard.attributes;

        effectCardInfo.text = "Info about the effect card activated";
    }

    /// <summary>
    /// This function will be called when the playes has pressed
    /// a portrait
    /// The unit portrait on the UI will need to have a
    /// call to this function
    /// Thhis funcion will show the changes provides on the card choosed
    /// </summary>

    public void ShowChangesOnThisCardEffectCard(int unitID)
    {
        SwitchActionBarEffectCard();
        //declineInjectionButtonAttributeCard.SetActive(true);
        this.unitSelected = unitID;
        ShowUnitStatsPreview(this.unitSelected);
    }

    /// <summary>
    /// Needed for effect cards that boost the units
    /// </summary>
    public void ShowUnitStatsPreviewEffectCard(int unitID)
    {
        this.unitSelected = unitID;
        //Debug.Log("Unit name: " + player.units[unitID]);
        //Debug.Log("Player " + player);
        //Debug.Log("Units " + player.units[0]);

        Attribute[] arr_attributesUnit = new Attribute[player.units[this.unitSelected].attrs.Count];
        //player.units[unitID].attrs.Values.CopyTo(arr_attributesUnit, 0);
        player.units[this.unitSelected].attrs.Values.CopyTo(arr_attributesUnit, 0);

        // Attribute[] arr_attributesActiveCard = new Attribute[player1.activeCard.attributes.GetLength(0)];
        //  player1.activeCard.attributes.CopyTo(arr_attributesActiveCard, 0);
        //if (player.activeCard == null){
        if (player.activeCard == null)
        {
            Debug.LogError("Active card is not setup! Aborting");
            return;
        }
        //int[] cardAttrs = player.activeCard.attributes;
        int[] cardAttrs = player.activeCard.attributes;


        string[] statBonus = new string[cardAttrs.Length];
        for (int i = 0; i < statBonus.Length; i++)
        {
            if (cardAttrs[i] < 0)
            {
                statBonus[i] = "<color=#ff0000ff> " + cardAttrs[i] + " </color>";
            }
            else
            {

                statBonus[i] = "<color=#00ff00ff> +" + cardAttrs[i] + " </color>";
            }
        }

        //here we are checking if the card can be applied
        //if not, we will design a function to finish the injection process
        //if (!player.activeCard.isNotOverflowing(arr_attributesUnit))//if is false
        if (!player.activeCard.isNotOverflowing(arr_attributesUnit))
        {
            Debug.LogError("The card overflows unit stats");
            return;
        }

        //we need to make calculations of the attributes to show then on the
        //following text value, which belongs to the UI

        Debug.Log("debug for unit stats" + unitStatsPreviewEffectCard);

        ////Here we upload the unit stats preview with the 
        //values calculated with card functions
        //One this has been done, the player can press Activate Injection
        //Activate Injection button will call the funcion ApplyChangesInjection
        //unitStatsPreview = GameObject.Find("UnitStatsPreview").GetComponent<Text>();
        //unitStatsPreview.text = "StatsChangedPreview\n Unit-> " + player.units[unitID].name +
        unitStatsPreviewEffectCard.text = "StatsChangedPreview\n Unit-> " + player.units[this.unitSelected].name +
                "\nStrenght:" + arr_attributesUnit[0].Value + statBonus[0]
                + "\nAgility:" + arr_attributesUnit[1].Value + statBonus[1]
                + "\nRange:" + arr_attributesUnit[2].Value + statBonus[2];

        Debug.Log("wbiwbv");
    }


    /// <summary>
    /// Apply the changes of the injection of the card selected on the character
    /// </summary>
    public void ApplyChangesInjectionEffectCard(int unitID)
    {
        //Attribute[] arr = new Attribute[player.units[unitID].attrs.Count];
        //player.units[unitID].attrs.Values.CopyTo(arr, 0);

        Attribute[] arr_attributesUnit = new Attribute[player.units[unitID].attrs.Count];
        //player.units[unitID].attrs.Values.CopyTo(arr_attributesUnit, 0);
        player.units[unitID].attrs.Values.CopyTo(arr_attributesUnit, 0);
        //if (player.activeCard.isNotOverflowing(arr_attributesUnit))
        if (player.activeCard.isNotOverflowing(arr_attributesUnit))
        {
            //player.units[unitID].Buff(player.activeCard.attributes);
            player.units[unitID].Buff(player.activeCard.attributes);
            // player[i].deck.Bury(player[i].activeCard);
            // player[i].activeCard = null;
            //    // holdingCard = false;
            //}
        }
        //Once the changes had been applied to the unit, we desactivate the process of injection
        Debug.Log("Finishing the process of injection of the card selected");

        actionBarButtonEffectCards.SetActive(false);
    }

    //here we place some effect card needed behaviours

    public void UseEffectOnGridPosition()
    {

    }

    public void ChooseEnemyUnit()
    {

    }


    //------------------------------------------------------------------------------

    /// <summary>
    /// hides the pannel with the procces of injection
    /// lets the player see whats happening on the field
    /// </summary>
    public void ActivateMinimizeEffectCardProcess()
    {
        SwitchActionBarEffectCard();
        effectCardInfo.enabled = false;

        //showEffectCardProcessButton.SetActive(true);
    }

    /// <summary>
    /// Activates again the pannel which contains the info and about
    /// related to the injection of cards
    /// Called by the ShowInjectionProcessButton button button
    /// </summary>
    //public void ActivateEffectCardPannel()
    //{
    //    effectCardPannel.SetActive(true);
    //}

    public void ActivateShowEffectCardProcessButton()
    {
        SwitchActionBarEffectCard();
        //ActivateEffectCardPannel();
        effectCardImage.SetActive(false);
    }

    #endregion

}

[System.Serializable]
public class CardImage {
    public string textId;
    public Sprite cardSprite;
}