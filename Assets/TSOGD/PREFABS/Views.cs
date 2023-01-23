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
    private ViewsManager _viewsManager;
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
    
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
    
    }
    private void InitializeStartReferences()
    {
        _viewsManager = ViewsManager.Instance;
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    private bool _changeView;
    public bool ChangeView { get => _changeView; set => _changeView = value; }
    //################################################################################################################################
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
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}