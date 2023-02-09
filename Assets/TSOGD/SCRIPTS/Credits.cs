using TMPro;
using TSOGD.CONTROLS;
using TSOGD.DATAS.TEXTS;
using TSOGD.PREFABS;
using UnityEngine;
namespace TSOGD.SCRIPTS { public class Credits : MonoBehaviour
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    [SerializeField] private GameObject _creditsTextGameObject;
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    private Chrono _creditsTimer;
    private float _creditsDelay = 4f;
    //##### SINGLETON ################################################################################################################
    
    //##### OBJECTS ##################################################################################################################
    private TextMeshProUGUI _creditsTextTMPro;
    private Views _titleView;
    //##### OBJECTS ARRAYS ###########################################################################################################
    
    //##### REGIONS ##################################################################################################################
    #region UNITY API
    void Awake()
    {
        InitializeAwakeReferences();
    }
    void Start()
    {
        InitializeStartReferences();
    }
    void Update()
    {
            
    }
    #endregion
	//################################################################################################################################
    #region FONCTIONS D'INITIALISATION
    //##### PRIMITIVES ###############################################################################################################
    private int _textIndex;
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
        _titleView = gameObject.GetComponentInParent<Views>();
        _creditsTimer = gameObject.AddComponent<Chrono>();
        _textIndex = 0;
    }
    private void InitializeStartReferences()
    {
        if (_creditsTextGameObject) {
            _creditsTextTMPro = _creditsTextGameObject.GetComponent<TextMeshProUGUI>();
            _creditsTextGameObject.SetActive(true);
            SetText();
        }
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    /// <summary>
    /// Change le texte du TMP.
    /// </summary>
    /// <param name="text">[string] nouveau texte</param>
    private void SetText() {
        if (_textIndex < TitleCreditsTexts.AllTitleCreditsTexts.Length) {
            if (_creditsTextTMPro) _creditsTextTMPro.text = TitleCreditsTexts.AllTitleCreditsTexts[_textIndex];
            if (_creditsTimer) {
                _creditsTimer.SetEventAction(ReadNextText);
                _creditsTimer.Wait(_creditsDelay);
            }
            _textIndex++;
        } else {
            Destroy(_creditsTextTMPro.gameObject);
            if (_creditsTimer) {
                _creditsTimer.SetEventAction(GoToIntroView);
                _creditsTimer.Wait(_creditsDelay+1f);
            }
        }
    }
    /// <summary>
    /// Lit tous les textes de la classe static TitleCreditsTexts.
    /// </summary>
    private void ReadNextText() {
        Fixes.BeforeNextText(_creditsTextTMPro, _creditsTimer, SetText);
    }
    /// <summary>
    /// Assigne la valeur ChangeView de la TitleView.
    /// </summary>
    private void GoToIntroView() {
        _titleView.ChangeView = true;
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}