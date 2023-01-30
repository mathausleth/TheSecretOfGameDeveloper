using UnityEngine;
namespace TSOGD.SCRIPTS { public class Title : MonoBehaviour
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    [SerializeField] private float _cloudsStartPosition = 600f;
    [SerializeField] private float _cloudsEndPosition = -590f;
    [SerializeField] private float _cloudsSpeedTransition = 2f;
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    [SerializeField] private RectTransform _cloudsRectTransform;
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    
    //##### SINGLETON ################################################################################################################
    
    //##### OBJECTS ##################################################################################################################
    private Vector3 _initialCloudsPosition;
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
    
    }
    private void InitializeStartReferences()
    {
        InitializeCloudsPosition();
    }
    private void InitializeCloudsPosition()
    {
        if (_cloudsRectTransform) {
            _initialCloudsPosition = _cloudsRectTransform.localPosition;
            _initialCloudsPosition.x = _cloudsStartPosition;
        }
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
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}