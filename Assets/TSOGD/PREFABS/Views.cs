using TSOGD.MANAGERS;
using UnityEngine;
namespace TSOGD.PREFABS { public class Views : MonoBehaviour
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    [SerializeField] private Views _nextView;
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    
    //##### SINGLETON ################################################################################################################
    
    //##### OBJECTS ##################################################################################################################
    private GameObject _addonsGameObject;
    private ViewsManager _viewsManager;
    private ITransition _viewTransition;
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
        ViewsMecanism();
    }
    #endregion
	//################################################################################################################################
    #region FONCTIONS D'INITIALISATION
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
        _viewTransition = GetComponentInChildren<ITransition>();
        _addonsGameObject = transform.GetChild(1).gameObject;
    }
    private void InitializeStartReferences()
    {
        _viewsManager = ViewsManager.Instance;
        if (_viewsManager != null) _viewsManager.SetNextView(_nextView);
        //todo: offrir une solution via la touche echap ?
        if (_viewTransition != null) _viewTransition.Play();
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    private bool _changeView;
    public bool ChangeView { get => _changeView; set => PlayEndTransition(value); }
    private bool _waitTransition;
    //################################################################################################################################
    private void ViewsMecanism(){
        if (!_addonsGameObject.activeSelf && (bool)_viewTransition?.IsPlayed()) _addonsGameObject.SetActive(true);
        if (_waitTransition && (bool)_viewTransition?.IsWaitingRestart()) {
            _waitTransition = false;
            _changeView = true;
        }
    }
    /// <summary>
    /// Active le GameObject de la View.
    /// </summary>
    public void OpenView()
    {
        gameObject.SetActive(true);
    }
    /// <summary>
    /// Desactive le GameObject de la View.
    /// Reinitialise la valeur de ChangeView.
    /// </summary>
    public void CloseView()
    {
        _changeView = false;
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Parametre l'attente de la fin de la transition si la valeur de ChangeView passe a [true].
    /// </summary>
    /// <param name="playTransition">[bool] joue la transition Close</param>
    private void PlayEndTransition(bool playTransition) {
        if (!_waitTransition) {
            _waitTransition = playTransition;
            if (_waitTransition && _viewTransition != null) _viewTransition.Stop();
            else if (_waitTransition && _viewTransition == null) {
                _waitTransition = false;
                _changeView = true;
            }
        }
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}