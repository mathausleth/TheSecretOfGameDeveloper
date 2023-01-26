using UnityEngine;
using UnityEngine.UI;
namespace TSOGD.PREFABS { public class CrossFadeAlphaTransition : MonoBehaviour, ITransition
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    [SerializeField] private float _playDelay = 0f;
    [SerializeField] private float _playDuration = 1.0f;
    [SerializeField] private float _stopDuration = 1.0f;
    [SerializeField] private bool _ignoreScalingTime;
    [SerializeField] private bool _isAscending;
    [SerializeField] private bool _disableAuto;
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    private Chrono _timer;
    //##### SINGLETON ################################################################################################################
    
    //##### OBJECTS ##################################################################################################################
    private Image _transitionImage;
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
        CrossFadeAlphaTransitionMecanism();
    }
    #endregion
	//################################################################################################################################
    #region FONCTIONS D'INITIALISATION
    //##### PRIMITIVES ###############################################################################################################
    private float _startValue;
    private float _endValue;
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
        _transitionImage = GetComponent<Image>();
        _timer = gameObject.AddComponent<Chrono>();
    }
    private void InitializeStartReferences()
    {
        _startValue = (_isAscending) ? 0.0f : 1.0f;
        _endValue = (_isAscending) ? 1.0f : 0.0f;
        InitializeTransitionImageRenderer();
    }
    private void InitializeTransitionImageRenderer()
    {
        _transitionImage.canvasRenderer.SetAlpha(_startValue);
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    private bool _isStoping;
    private bool _waitManualDisable;
    private float _transitionAlpha;
    //################################################################################################################################
    private void CrossFadeAlphaTransitionMecanism() {
        if (!_waitManualDisable && _transitionImage.enabled) {
            _transitionAlpha = _transitionImage.canvasRenderer.GetAlpha();
            FixAlpha();
            ClearTransition();
        }
    }
    /// <summary>
    /// Permet de forcer l'assignation des valeurs 0.0f et 1.0f du canal alpha. 
    /// </summary>
    private void FixAlpha() { 
        if (0.1f > _transitionAlpha) _transitionImage.canvasRenderer.SetAlpha(0.0f);
        if (0.9f < _transitionAlpha) _transitionImage.canvasRenderer.SetAlpha(1.0f);
    }
    /// <summary>
    /// Permet de desactiver ou d'attendre la desactivation du rendu d'image de la transition.
    /// </summary>
    private void ClearTransition() {
        if (_isStoping && _transitionAlpha == _startValue) {
            _isStoping = false;
            if (_disableAuto) _transitionImage.enabled = false;
            else _waitManualDisable = true;
        }
    }
    /// <summary>
    /// Desactive manuellement le rendu d'image de la transition.
    /// Si reset vaut true, reinitialise la valeur du canal alpha.
    /// </summary>
    /// <param name="reset">[bool] reinitialise la valeur du canal alpha</param>
    public void DisableTransition(bool reset = false) {
        _waitManualDisable = false;
        _transitionImage.enabled = false;
        if (reset) InitializeTransitionImageRenderer();
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region INTERFACE
    /// <summary>
    /// Declenche la transition.
    /// </summary>
    public void Play()
    {
        _transitionImage.enabled = true;
        if (_transitionImage.canvasRenderer.GetAlpha() == 1.0f && _timer != null) {
            _timer.SetEventAction(OnPlayAction);
            _timer.Wait(_playDelay);
        } else {
            OnPlayAction();
        }
    }
    private void OnPlayAction() {
        _transitionImage.CrossFadeAlpha(_endValue, _playDuration, _ignoreScalingTime);
    }
    /// <summary>
    /// Stop la transition.
    /// </summary>
    public void Stop()
    {
        _transitionImage.CrossFadeAlpha(_startValue, _stopDuration, _ignoreScalingTime);
        _isStoping = true;
    }
    /// <summary>
    /// Retourne [true] si le rendu est actif et que la transition est complete sinon [false].
    /// </summary>
    /// <returns>[bool] le rendu de la transition est actif et la transition complete</returns>
    public bool IsPlayed() {
        return _transitionImage.enabled && _transitionImage.canvasRenderer.GetAlpha() == _endValue;
    }
    /// <summary>
    /// Retourne [true] si le rendu de la transition est actif sinon [false].
    /// </summary>
    /// <returns>[bool] le rendu de la transition est actif</returns>
    public bool IsStoped() {
        return (_transitionImage) ? !_transitionImage.enabled : true;
    }
    /// <summary>
    /// Retourne [true] si la transition est complete mais en attente d'etre stoppee[false].
    /// </summary>
    /// <returns>[bool] la transition est complete mais en attente d'etre stoppee</returns>
    public bool IsWaitingRestart() {
        return _waitManualDisable;
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}