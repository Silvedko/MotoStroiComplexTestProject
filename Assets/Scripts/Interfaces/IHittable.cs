public interface IHittable 
{
	float HitPoints { get; set; }
	float Armor { get; set; }
	bool IsDead { get; set; }
	void ReceiveDamage (IDamageDealer damageDealer);
}
