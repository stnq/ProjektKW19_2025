
using ProjektKW19_2025;

public class BossEnemy : Enemy
{
	public string SpecialAttack { get; set; }
	public string UsbDrop { get; set; }
	public bool UnlocksCompanion { get; set; }

	public BossEnemy(string name, int health, int damage, string special, string usb, bool unlocks) : base(name, health, damage)
	{
		SpecialAttack = special;
		UsbDrop = usb;
		UnlocksCompanion = unlocks;
	}
}