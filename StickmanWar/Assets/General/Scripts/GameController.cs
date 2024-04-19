public class GameController{
    private static GameController instance;
    public static GameController Instance{
        get{
            if(instance == null){
                instance = new GameController();
            }
            return instance;
        }
    }
    private float heart_Lv1 = 500;
    private float dame_Lv1 = 20;
    public int Level{ get; set; }
    // Doi cong thuc can bang
    public void SetDataCharacter(Character charac){
        if(charac.eCharacter == ECharacter.Player){
            charac.Heart = heart_Lv1;
            charac.Dame = dame_Lv1;
        }else{
            charac.Heart = heart_Lv1-100;
            charac.Dame = dame_Lv1-10;
        }
    }
}