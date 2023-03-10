using TSOGD.PREFABS;
using UnityEngine;
namespace TSOGD.MANAGERS { public class ViewsManager : MonoBehaviour
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    
    //##### SINGLETON ################################################################################################################
    private static ViewsManager _instance;
    public static ViewsManager Instance { get => _instance; }
    //##### OBJECTS ##################################################################################################################
    private Views _exitView;
    private Views _currentView;
    private Views _nextView;
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
        ViewsManagerMecanism();
    }
    #endregion
	//################################################################################################################################
    #region FONCTIONS D'INITIALISATION
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
        InitializeSingleton();
    }
    private void InitializeStartReferences()
    {
    
    }
    private void InitializeSingleton()
    {
        if (_instance && _instance != this) {
            Destroy(this);
            return;
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(_instance);
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    private void ViewsManagerMecanism()
    {
        if (_currentView && _currentView.ChangeView) {
            _currentView.CloseView();
            LoadNextView();
        }
    }
    /// <summary>
    /// Charge la vue suivante.
    /// Sinon, la vue finale.
    /// </summary>
    private void LoadNextView()
    {
        if (_nextView) {
            _currentView = _nextView;
            _nextView = null;
            _currentView.OpenView();
        } else {
            _exitView.OpenView();
        }
    }
    /// <summary>
    /// Assigne la vue finale permetant de quitter le jeu.
    /// </summary>
    /// <param name="exitView">[Views] la vue finale</param>
    public void SetExitView(Views exitView)
    {
        _exitView = exitView;
    }
    /// <summary>
    /// Assigne la vue courante.
    /// </summary>
    /// <param name="currentView">[Views] la vue courante</param>
    public void SetCurrentView(Views currentView)
    {
        _currentView = currentView;
        _nextView = null;
        _currentView.OpenView();
    }
    /// <summary>
    /// Assigne la vue suivante.
    /// </summary>
    /// <param name="nextView">[Views] la vue suivante</param>
    public void SetNextView(Views nextView)
    {
        _nextView = nextView;
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}