namespace TSOGD.PREFABS { public interface ITransition
{
    //################################################################################################################################
    void Play();
    void Stop();
    bool IsPlayed();
    bool IsStoped();
    bool IsWaitingRestart();
	//################################################################################################################################
}}