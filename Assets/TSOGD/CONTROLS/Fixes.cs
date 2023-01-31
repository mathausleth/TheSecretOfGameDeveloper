using TMPro;
using TSOGD.PREFABS;
namespace TSOGD.CONTROLS { public static class Fixes
{
    //##### OBJECTS ##################################################################################################################
    public delegate void ThenNextText();
	//################################################################################################################################
    #region MECANIQUE DE LA CLASSE
    //##### PRIMITIVES ###############################################################################################################
    
    //################################################################################################################################
    /// <summary>
    /// Permet d'�viter une surcharge visuelle lorsque les textes s'enchainent.
    /// Cela semble inutile d'un point de vue technique cependant, sans ce proc�d�, l'oeil aguerri remarquera un l�ger sautillement.
    /// </summary>
    public static void BeforeNextText(TextMeshProUGUI tmpPro, Chrono timer, ThenNextText thenNextText) {
        if (tmpPro.text.Length > 0) {
            if (tmpPro) tmpPro.text = "";
            timer.Wait(0.5f);
        } else { thenNextText(); }
    }
    //################################################################################################################################
    #endregion
	//################################################################################################################################
}}