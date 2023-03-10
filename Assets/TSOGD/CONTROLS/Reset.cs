using UnityEngine.SceneManagement;
namespace TSOGD.CONTROLS { public static class Reset
{
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    /// <summary>
    /// Charge la ManagersScene, scene d'initialisation des Managers.
    /// Cela a pour effet de reinitialiser le jeu.
    /// </summary>
    public static void LoadManagers() {
        SceneManager.LoadScene("ManagersScene");
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}