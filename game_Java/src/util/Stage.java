package util;

// This game is designed and implement by Jiwei Zhang 17200334
import java.awt.*;
import java.util.HashMap;

public class Stage {
    private HashMap<Integer, Enemy> enemys;

    public Stage() {
        enemys = new HashMap<Integer, Enemy>();
    }

    public void addEnemy(int id, Enemy enemy) {
        enemys.put(id, enemy);
    }

    public HashMap<Integer, Enemy> getEnemies() {
        return enemys;
    }
}
