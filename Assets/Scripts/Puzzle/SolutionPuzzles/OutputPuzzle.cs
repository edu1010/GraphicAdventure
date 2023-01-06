
using UnityEngine;

[CreateAssetMenu(fileName = "Drinks", menuName = "ScriptableObjects/newDrink", order = 1)]
public class OutputPuzzle : ScriptableObject
{
    public BlackBoardPuzzle1.DrinkBase drinkBase;
    public BlackBoardPuzzle1.DrinkExtra drinkExtra;
    public Sprite image;
    public int cantidad = 1;
    public string resultadoPositivo;
    public string resultadoNegativo;

}
