package util;

// This game is designed and implement by Jiwei Zhang 17200334
public class Bullet extends GameObject{

    private int damage;

    public Bullet() {
        super();
    }

    public Bullet(String textureLocation, int width, int height, Point3f centre, int dmg) {
        super(textureLocation, width, height, centre);
        damage = dmg;
    }

    public int getDamage() {
        return damage;
    }

    public void setDamage(int damage) {
        this.damage = damage;
    }
}
