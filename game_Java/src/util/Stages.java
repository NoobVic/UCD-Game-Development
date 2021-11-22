package util;

// This game is designed and implement by Jiwei Zhang 17200334
public class Stages {
    private Stage[] stages = new Stage[5];
    public Stages(){
        for(int i = 0; i < stages.length; i++) {
            stages[i] = new Stage();
        }
        //Stage 0:
        stages[0].addEnemy(0, new Enemy(EnemyTypes.slime, new Point3f(900,150,0)));
        stages[0].addEnemy(1, new Enemy(EnemyTypes.slime, new Point3f(900,300,0)));
        stages[0].addEnemy(2, new Enemy(EnemyTypes.slime, new Point3f(900,450,0)));
        stages[0].addEnemy(3, new Enemy(EnemyTypes.slime, new Point3f(900,600,0)));
        //Stage 1:
        stages[1].addEnemy(0, new Enemy(EnemyTypes.slimeCap, new Point3f(900,150,0)));
        stages[1].addEnemy(1, new Enemy(EnemyTypes.slime, new Point3f(900,300,0)));
        stages[1].addEnemy(2, new Enemy(EnemyTypes.slime, new Point3f(900,450,0)));
        stages[1].addEnemy(3, new Enemy(EnemyTypes.slime, new Point3f(900,600,0)));
        //Stage 2:
        stages[2].addEnemy(0, new Enemy(EnemyTypes.slimeCap, new Point3f(900,150,0)));
        stages[2].addEnemy(1, new Enemy(EnemyTypes.slime, new Point3f(900,300,0)));
        stages[2].addEnemy(2, new Enemy(EnemyTypes.slime, new Point3f(900,450,0)));
        stages[2].addEnemy(3, new Enemy(EnemyTypes.slimeCap, new Point3f(900,600,0)));
        //Stage 3:
        stages[3].addEnemy(0, new Enemy(EnemyTypes.slimeCap, new Point3f(900,150,0)));
        stages[3].addEnemy(1, new Enemy(EnemyTypes.slimeCap, new Point3f(900,300,0)));
        stages[3].addEnemy(2, new Enemy(EnemyTypes.slimeCap, new Point3f(900,450,0)));
        stages[3].addEnemy(3, new Enemy(EnemyTypes.slimeCap, new Point3f(900,600,0)));
        //Stage 4:
        stages[4].addEnemy(0, new Enemy(EnemyTypes.slimeCap, new Point3f(900,150,0)));
        stages[4].addEnemy(1, new Enemy(EnemyTypes.slimeCap, new Point3f(900,300,0)));
        stages[4].addEnemy(2, new Enemy(EnemyTypes.slimeCap, new Point3f(900,450,0)));
        stages[4].addEnemy(3, new Enemy(EnemyTypes.slimeCap, new Point3f(900,600,0)));
        stages[4].addEnemy(4, new Enemy(EnemyTypes.slime, new Point3f(600,300,0)));
        stages[4].addEnemy(5, new Enemy(EnemyTypes.slime, new Point3f(600,450,0)));

    }

    public Stage[] getStages() {
        return stages;
    }

    public void setStages(Stage[] stages) {
        this.stages = stages;
    }
}