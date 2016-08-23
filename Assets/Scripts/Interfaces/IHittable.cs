public interface IHittable 
{
	void ReduceHitPoints (float hp);
	void OnDead ();
	float GetHitPoints ();
}
