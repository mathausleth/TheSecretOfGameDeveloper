using UnityEngine;
using UnityEngine.Events;
namespace TSOGD.PREFABS { public class Chrono : MonoBehaviour
{
    //##### SERIALIZE FIELD PARAMETERS ###############################################################################################
    
    //##### SERIALIZE FIELD REFERENCES ###############################################################################################
    
    //##### SERIALIZE FIELD ARRAYS ###################################################################################################
    
    //##### TIMERS ###################################################################################################################
    private float _timerTime;
    //##### SINGLETON ################################################################################################################
    
    //##### OBJECTS ##################################################################################################################
    private UnityEvent _eventFunction;
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
        ChronoMecanism();
    }
    #endregion
	//################################################################################################################################
    #region FONCTIONS D'INITIALISATION
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    private void InitializeAwakeReferences()
    {
        _timerTime = float.PositiveInfinity;
    }
    private void InitializeStartReferences()
    {
    
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    private bool _isRunning;
    //################################################################################################################################
    private void ChronoMecanism()
    {
        if (_isRunning && Time.time >= _timerTime) {
            _isRunning = false;
            _timerTime = float.PositiveInfinity;
            if (_eventFunction != null) _eventFunction.Invoke();
        }
    }
    /// <summary>
    /// Assigne le comportement a executer a la fin du timer Wait.
    /// </summary>
    /// <param name="unityAction"></param>
    public void SetEventAction(UnityAction unityAction)
    {
        UnityEvent unityEvent = new UnityEvent();
        unityEvent.AddListener(unityAction);
        _eventFunction = unityEvent;
    }
    /// <summary>
    /// Declenche le timer permettant d'executer l'action prealablement assignee.
    /// </summary>
    /// <param name="seconds">[float] secondes avant execution</param>
    public void Wait(float seconds)
    {
        _timerTime = Time.time + seconds;
        _isRunning = true;
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}