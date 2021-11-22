package util;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

// This game is designed and implement by Jiwei Zhang 17200334
import static java.lang.Integer.parseInt;

public class Player extends GameObject{
    // The exp needed to level up
    private int exp;
    private int expMax;

    public Player() {

    }

    public Player(String textureLocation, int width, int height, Point3f centre) {
        super(textureLocation, width, height, centre);
        String data = null;
        try {
            File myObj = new File("data/saveData.txt");
            Scanner myReader = new Scanner(myObj);
            while (myReader.hasNextLine()) {
                data = myReader.nextLine();
            }
            myReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }

        if( data != null) {
            String[] datas = data.split(",");
            for(int i = 0; i <datas.length; i++){
                datas[i] = datas[i].replaceAll("[^\\d.]", "");
            }
            super.setInfo( new Information("Hero",
                    parseInt(datas[1]),
                    parseInt(datas[2]),
                    parseInt(datas[3]),
                    parseInt(datas[4]),
                    parseInt(datas[5]),
                    parseInt(datas[6]),
                    parseInt(datas[7]),
                    parseInt(datas[8]),
                    parseInt(datas[9])));
            this.getInfo().resetHPMP();
        } else {
            super.setInfo( new Information("Hero", 1, 200, 100, 200, 100, 20, 20, 20, 20 ) );
        }
        this.setExp(0);
        this.setExpMax(this.getInfo().getLV() * 100);
    }

    public int getExp() {
        return exp;
    }

    public void setExp(int exp) {
        this.exp = exp;
    }

    public int getExpMax() {
        return expMax;
    }

    public void setExpMax(int expMax) {
        this.expMax = expMax;
    }

    public boolean levelUpCheck() {
        return this.getExp() >= this.getExpMax();
    }

    public void levelUp() {
        Information temp = this.getInfo();
        temp.setLV(temp.getLV() + 1);
        temp.setHPMAX(temp.getHPMAX() + 20);
        temp.setMPMAX(temp.getMPMAX() + 10);
        temp.setAD(temp.getAD() + 2);
        temp.setAP(temp.getAP() + 2);
        temp.setAR(temp.getAR() + 2);
        temp.setMR(temp.getMR() + 2);
        temp.resetHPMP();
        this.setExp(0);
        this.setExpMax(temp.getLV() * 100);
    }

    @Override
    public String toString() {
        return "Player{" +
                "exp=" + exp +
                ", expMax=" + expMax +
                '}' +
                this.getInfo().toString();
    }
}
