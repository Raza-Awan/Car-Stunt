using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars_Positions : MonoBehaviour
{
    public List<GameObject> cars; // List of all the cars in the game including the player car
    public List<Text> leaderBoard_Texts = new List<Text>();
    public Car_Boost_Manager car_Boost_Manager;
    public Transform finishLine; // The finish line object
    public GameObject playerCurrentPosition_Obj;
    public Text playerCurrentPosition_Text; // The UI text to display the player's position
    public GameObject leaderBoard;

    public static bool playerFinished_1st = false;
    bool playerFinished = false;
    int playerFinalPosition;
    int car1FinalPosition;
    int car2FinalPosition;
    int car3FinalPosition;
    int car4FinalPosition;

    private Dictionary<GameObject, float> carDistances; // Dictionary to store each car's distance from finish line

    List<GameObject> finishedCars = new List<GameObject>();

    GameObject playerCar;
    GameObject Car1;
    GameObject Car2;
    GameObject Car3;
    GameObject Car4;


    public string playername_string;
    void Start()
    {
        playerFinished_1st = false;
        leaderBoard.SetActive(false);

        Car1 = cars[0];
        Car2 = cars[1];
        Car3 = cars[2];
        Car4 = cars[3];

        int current_Index = PlayerPrefs.GetInt("SelectedCar", 0);
        playerCar = car_Boost_Manager.cars[current_Index].gameObject;
        cars.Add(playerCar); // add the player car which player selected to the list

        carDistances = new Dictionary<GameObject, float>();
        
        // Initialize each car's distance from finish line to 0
        foreach (GameObject car in cars)
        {
            carDistances.Add(car, 0f);
        }
    }

    void Update()
    { 
        
        playername_string = Player_Name.playername_text;
         /*if (playername_string == null)
         {
             playername_string = "Player";
         }*/
        // Update each car's distance from finish line
        foreach (GameObject car in cars)
        {
            float distance = Vector3.Distance(car.transform.position, finishLine.position); // Distance from finish line
            carDistances[car] = distance; // Update the dictionary with new distance

            if (!finishedCars.Contains(car) && car.CompareTag("Player") && Finish_BoolChecker.player_Win)
            {
                playerFinished = true;
                finishedCars.Add(car); // Add player car to finishedCars list
                playerFinalPosition = FindPlayerFinalPosition();
                if (playerFinalPosition == 1)
                {
                    playerFinished_1st = true;
                    Race_controller.race_increment_var = true;
                }

            }
            if (!finishedCars.Contains(car) && car.CompareTag("car1") && Finish_BoolChecker.ai_1_Win)
            {
                finishedCars.Add(car); // Add non-player car to finishedCars list
                car1FinalPosition = FindCar1FinalPosition();
            }
            if (!finishedCars.Contains(car) && car.CompareTag("car2") && Finish_BoolChecker.ai_2_Win)
            {
                finishedCars.Add(car); // Add non-player car to finishedCars list
                car2FinalPosition = FindCar2FinalPosition();
            }
            if (!finishedCars.Contains(car) && car.CompareTag("car3") && Finish_BoolChecker.ai_3_Win)
            {
                finishedCars.Add(car); // Add non-player car to finishedCars list
                car3FinalPosition = FindCar3FinalPosition();
            }
            if (!finishedCars.Contains(car) && car.CompareTag("car4") && Finish_BoolChecker.ai_4_Win)
            {
                finishedCars.Add(car); // Add non-player car to finishedCars list
                car4FinalPosition = FindCar4FinalPosition();
            }
        }

        if (playerFinished || Finish_BoolChecker.player_Win)
        {
            playerCurrentPosition_Obj.SetActive(false);
            Display_LeaderBoard();
            DisplayPlayerPosition();
            DisplayCar1Position();
            DisplayCar2Position();
            DisplayCar3Position();
            DisplayCar4Position();
        }


        // Sort the cars based on their distance from finish line in ascending order
        List<GameObject> sortedCars = new List<GameObject>(cars);
        sortedCars.Sort((x, y) => carDistances[x].CompareTo(carDistances[y]));


        // Now you can iterate through the sortedCars list and get each car's position based on its index
        for (int i = 0; i < sortedCars.Count; i++)
        {
            GameObject car = sortedCars[i];
            int position = i + 1; // Position of the car in the leaderboard
                                  // You can now use this position to display the leaderboard information for each car
            if (car.CompareTag("Player"))
            {
                if (!playerFinished)
                {
                    // Display the player's current position in the UI text
                    playerCurrentPosition_Text.text = position.ToString();
                }
            }
        }
    }

    void DisplayPlayerPosition()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (playerFinalPosition == i)
            {

                Text textComponent = leaderBoard_Texts[i-1];
                textComponent.text = playerFinalPosition +"        "+playername_string;
                break; // exit the loop once the condition is met
            }
        }
    }

    private void DisplayCar4Position()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (car4FinalPosition == i)
            {
                // Get the corresponding Text component using the loop index
                Text textComponent = leaderBoard_Texts[i - 1];

                // Update the text of the Text component
                textComponent.text = car4FinalPosition +"       John";
                break; // exit the loop once the condition is met
            }
        }
    }

    private void DisplayCar3Position()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (car3FinalPosition == i)
            {
                // Get the corresponding Text component using the loop index
                Text textComponent = leaderBoard_Texts[i - 1];

                // Update the text of the Text component
                textComponent.text = car3FinalPosition +"       Jennifer" ;
                break; // exit the loop once the condition is met
            }
        }
    }

    private void DisplayCar2Position()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (car2FinalPosition == i)
            {
                // Get the corresponding Text component using the loop index
                Text textComponent = leaderBoard_Texts[i - 1];

                // Update the text of the ext component
                textComponent.text = car2FinalPosition +"       Paul";
                break; // exit the loop once the condition is met
            }
        }
    }

    private void DisplayCar1Position()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (car1FinalPosition == i)
            {
                // Get the corresponding Text component using the loop index
                Text textComponent = leaderBoard_Texts[i - 1];

                // Update the text of the Text component
                textComponent.text = car1FinalPosition +"       Lisa" ;
                break; // exit the loop once the condition is met
            }
        }
    }

    void Display_LeaderBoard()
    {
        leaderBoard.SetActive(true);
        //leaderBoard.enabled = true;
    }


    private int FindPlayerFinalPosition()
    {
        // Find the final position of the player car in the finishedCars list
        int player_position = finishedCars.IndexOf(playerCar) + 1;

        if (player_position == 0)
        {
            return 0; // Player car not found in finishedCars list
        }

        return player_position;
    }
    private int FindCar1FinalPosition()
    {
        // Find the final position of the Car1 in the finishedCars list
        int car1_position = finishedCars.IndexOf(Car1) + 1;

        if (car1_position == 0)
        {
            return 0; // Car1 not found in finishedCars list
        }

        return car1_position;
    }
    private int FindCar2FinalPosition()
    {
        // Find the final position of the Car2 in the finishedCars list
        int car2_position = finishedCars.IndexOf(Car2) + 1;

        if (car2_position == 0)
        {
            return 0; // Car2 not found in finishedCars list
        }

        return car2_position;
    }
    private int FindCar3FinalPosition()
    {
        // Find the final position of the Car3 in the finishedCars list
        int car3_position = finishedCars.IndexOf(Car3) + 1;

        if (car3_position == 0)
        {
            return 0; // Car3 not found in finishedCars list
        }

        return car3_position;
    }
    private int FindCar4FinalPosition()
    {
        // Find the final position of the Car4 in the finishedCars list
        int car4_position = finishedCars.IndexOf(Car4) + 1;

        if (car4_position == 0)
        {
            return 0; // Car4 not found in finishedCars list
        }

        return car4_position;
    }
}
