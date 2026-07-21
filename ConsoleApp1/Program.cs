
public class Program
{
    public static int FindMax(int[] numbers)
    {
        //Max number is the first number
        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            //If the current number is greater than the max
            if (numbers[i] > max)
            {//Set the max to the current number
                max = numbers[i];
            }
        }
        //Return the max when the loop is finished
        return max;
    }

    //Todolist
    //Creete todo array and a counter to keep track of the number of todos
    public static int counter = 0;
    public static string[] todos = new string[10];




    public static void addTodo(string todo)
    {
        //add todo to list and increment the counter


        //add the todo to the list
        todos[counter] = todo;
        //increment the counter 
        counter++;

        Console.WriteLine("Todo added");
    }

    //display all the task
    public static void displayTodos()
    {
        //display all the task using a for loop
        for (int i = 0; i < counter; i++)
        {
            Console.WriteLine(i+" "+todos[i]);
        }

        Console.WriteLine("There are " + counter + " todos");

    }

    //Marke task as completed
    public static void completeTodo(int index)
    {
        //mark the task as completed
        todos[index] = "Completed: " + todos[index];

        Console.WriteLine("Todo marked as completed");
    }

    public static void Main()
    {
        int[] myNumbers = { -5, -10, -3, -8, -2 };
        int maxNumber = FindMax(myNumbers);
        Console.WriteLine("The maximum number is: " + maxNumber);

        //call my calculator
        Calculator calc = new Calculator();
        int result = calc.Add(2, 3);
        int result2 = calc.Subtract(2, 3);
        Console.WriteLine("2 + 3 = " + result);
        Console.WriteLine("2 - 3 = " + result2);

        //Todo list app
        RunTodoList();

    }

    //Run the todo list app using while loop
    public static void RunTodoList()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add a todo");
            Console.WriteLine("2. Display all todos");
            Console.WriteLine("3. Mark a todo as completed");
            Console.WriteLine("4. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    Console.WriteLine("Please enter a todo");

                    string todo = Console.ReadLine();


                    if (todo != null)
                    {
                        addTodo(todo);
                    }
                    break;
                case 2:
                    displayTodos();
                    break;
                case 3:
                    int index = Convert.ToInt32(Console.ReadLine());
                    if (index >= 0 && index <= counter)
                    {
                        completeTodo(index);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid index");
                    }

                    break;
                case 4:
                    running = false;
                    break;
            }
        }

    }


}