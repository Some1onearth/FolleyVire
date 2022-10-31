using UnityEngine;

public class ArcadeInput
{
    public string hori, verti, R1, R2, R3, B1, B2, B3, start;
    private int playerNum = 1;
    public int PlayerNum
    {
        set {
            playerNum = value;
            SetupInput();
        }
        get {
            return playerNum;
        }
    }

    public ArcadeInput()
    {
        SetupInput();
    }

    void SetupInput()
    {
        string prefix = "P" + playerNum + " ";
        hori = prefix + "Hori";
        verti = prefix + "Verti";

        R1 = prefix + "R1";
        R2 = prefix + "R2";
        R3 = prefix + "R3";

        B1 = prefix + "B1";
        B2 = prefix + "B2";
        B3 = prefix + "B3";

        start = prefix + "Start";
    }
}
