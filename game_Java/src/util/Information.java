package util;

// This game is designed and implement by Jiwei Zhang 17200334
public class Information {
    // Character name
    private String name;

    // Game info:
    private int LV; // level
    private int HPMAX; // health
    private int MPMAX; // mana
    private int HP; // health
    private int MP; // mana
    private int AD; // attack damage
    private int AP; // ability power
    private int AR; // armor
    private int MR; // magic resist
    // this is inspired by League of Legend.

    // constructor

    public Information() {
    }

    public Information(String name, int LV, int HPMAX, int MPMAX, int HP, int MP, int AD, int AP, int AR, int MR) {
        this.name = name;
        this.LV = LV;
        this.HPMAX = HPMAX;
        this.MPMAX = MPMAX;
        this.HP = HP;
        this.MP = MP;
        this.AD = AD;
        this.AP = AP;
        this.AR = AR;
        this.MR = MR;
    }

    public Information(Information info) {
        this(info.getName(), info.getLV(), info.getHPMAX(), info.getMPMAX(), info.getHP(), info.getMP(), info.getAD(), info.getAP(), info.getAR(), info.getMR());
    }

    public void resetHPMP() {
        this.resetHP();
        this.resetMP();
    }

    public void resetHP() {
        this.setHP(this.getHPMAX());
    }

    public void resetMP() {
        this.setMP(this.getMPMAX());
    }

    // setter and getter
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getLV() {
        return LV;
    }

    public void setLV(int LV) {
        this.LV = LV;
    }

    public int getHP() {
        return HP;
    }

    public void setHP(int HP) {
        this.HP = HP;
    }

    public int getMP() {
        return MP;
    }

    public void setMP(int MP) {
        this.MP = MP;
    }

    public int getAD() {
        return AD;
    }

    public void setAD(int AD) {
        this.AD = AD;
    }

    public int getAP() {
        return AP;
    }

    public void setAP(int AP) {
        this.AP = AP;
    }

    public int getAR() {
        return AR;
    }

    public void setAR(int AR) {
        this.AR = AR;
    }

    public int getMR() {
        return MR;
    }

    public void setMR(int MR) {
        this.MR = MR;
    }

    public int getHPMAX() {
        return HPMAX;
    }

    public void setHPMAX(int HPMAX) {
        this.HPMAX = HPMAX;
    }

    public int getMPMAX() {
        return MPMAX;
    }

    public void setMPMAX(int MPMAX) {
        this.MPMAX = MPMAX;
    }

    @Override
    public String toString() {
        return "Information{" +
                "name='" + name + '\'' +
                ", LV=" + LV +
                ", HPMAX=" + HPMAX +
                ", MPMAX=" + MPMAX +
                ", HP=" + HP +
                ", MP=" + MP +
                ", AD=" + AD +
                ", AP=" + AP +
                ", AR=" + AR +
                ", MR=" + MR +
                '}';
    }
}
