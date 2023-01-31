using TMPro;
using TSOGD.CONTROLS;
using TSOGD.PREFABS;
using UnityEngine;
namespace TSOGD.SCRIPTS { public class Title : MonoBehaviour
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    [SerializeField] private float _cloudsStartPosition = 600f;
    [SerializeField] private float _cloudsEndPosition = -590f;
    [SerializeField] private float _cloudsSpeedTransition = 2f;
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    [SerializeField] private GameObject _incipitGameObject;
    [SerializeField] private RectTransform _cloudsRectTransform;
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    private Chrono _incipitTimer;
    private float _incipitDelay = 2.5f;
    //##### SINGLETON ################################################################################################################
    
    //##### OBJECTS ##################################################################################################################
    private Vector3 _initialCloudsPosition;
    private TextMeshProUGUI _incipitTMPro;
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
        TitleMecanism();
    }
    #endregion
	//################################################################################################################################
    #region FONCTIONS D'INITIALISATION
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
        _incipitTimer = gameObject.AddComponent<Chrono>();
    }
    private void InitializeStartReferences()
    {
        InitializeCloudsPosition();
        InitializeIncipit();
    }
    private void InitializeCloudsPosition()
    {
        if (_cloudsRectTransform) {
            _initialCloudsPosition = _cloudsRectTransform.localPosition;
            _initialCloudsPosition.x = _cloudsStartPosition;
        }
    }
    private void InitializeIncipit()
    {
        if (_incipitTimer) {
            _incipitTimer.SetEventAction(ShowIncipit);
            _incipitTimer.Wait(_incipitDelay);
        }
        if (_incipitGameObject) _incipitTMPro = _incipitGameObject.GetComponent<TextMeshProUGUI>();
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    private void TitleMecanism() {
        CloudsTransition();
    }
    /// <summary>
    /// Effectue la transition de l'Image des nuages.
    /// </summary>
    private void CloudsTransition() {
        if (_cloudsRectTransform) {
            if (_cloudsEndPosition < _cloudsRectTransform.localPosition.x) _cloudsRectTransform.Translate(Vector3.left * Time.deltaTime * _cloudsSpeedTransition);
            else _cloudsRectTransform.localPosition = _initialCloudsPosition;
        }
    }
    /// <summary>
    /// Active le GameObject de l'incipit.
    /// Declenche un timer Wait permettant de changer le texte.
    /// </summary>
    private void ShowIncipit() {
        if (_incipitGameObject && _incipitTimer) {
            _incipitGameObject.SetActive(true);
            _incipitTimer.SetEventAction(NextIncipitText);
            _incipitTimer.Wait(_incipitDelay);
        }
    }
    /// <summary>
    /// Change le texte de l'incipit.
    /// Declenche un timer Wait permettant de supprimer l'incipit.
    /// </summary>
    private void NextIncipitText() {
            void thenNextText()
            {
                if (_incipitTMPro) _incipitTMPro.text = "L'ile des AUTODIAGZ";
                _incipitTimer.SetEventAction(DestroyIncipit);
                _incipitTimer.Wait(_incipitDelay);
            }
            Fixes.BeforeNextText(_incipitTMPro, _incipitTimer, thenNextText);
    }
    /// <summary>
    /// Detruit le GameObjet de l'incipit.
    /// Declenche un timer Wait permettant d'afficher le titre du jeu.
    /// </summary>
    private void DestroyIncipit() {
        if (_incipitTMPro) Destroy(_incipitTMPro.gameObject);
        _incipitTimer.SetEventAction(ShowTitle);
        _incipitTimer.Wait(_incipitDelay);
    }
    /// <summary>
    /// Affiche le titre du jeu et les credits.
    /// </summary>
    private void ShowTitle() {
        //todo: afficher la vue titre.
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}