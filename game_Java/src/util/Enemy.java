package util;

// This game is designed and implement by Jiwei Zhang 17200334
public class Enemy extends GameObject{

    private int exp = 0; //The experience player can gain by killing this enemy

    public Enemy() {
        super();
    }

    public Enemy(String textureLocation, int width, int height, Point3f centre, int exp, Information info) {
        super(textureLocation, width, height, centre);
        super.setInfo( new Information(info) );
        this.setExp(exp);
    }

    public Enemy(Enemy enemyTemplate, Point3f p3f){
        this(enemyTemplate.getTexture(), enemyTemplate.getWidth(), enemyTemplate.getHeight(), p3f, enemyTemplate.getExp(), enemyTemplate.getInfo());
    }

    public int getExp() {
        return exp;
    }

    public void setExp(int exp) {
        this.exp = exp;
    }

    @Override
    public String toString() {
        return "Enemy{" +
                "exp=" + exp +
                '}' +
                this.getInfo().toString();
    }
}