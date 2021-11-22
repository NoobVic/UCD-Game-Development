package util;

// This game is designed and implement by Jiwei Zhang 17200334
public class EnemyTypes {
    public final static Enemy slime = new Enemy("res/slime.png", 50, 50, null, 10, new Information("Slime", 1, 100, 50,100, 50, 5, 5, 5, 5));
    public final static Enemy slimeCap = new Enemy("res/slime.png", 75, 75, null, 50, new Information("Slime", 10, 500, 50,500, 50, 20, 5, 50, 50));
    public final static Enemy slimeKing = new Enemy("res/slime.png", 100, 100, null, 100, new Information("Slime", 50, 2000, 50,2000, 50, 100, 5, 150, 150));
}
