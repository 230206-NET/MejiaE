Console.WriteLine("ToDo App: helping you stay organized.");

List<string> tasks = new List<string>();

while (true) { //infinite loop to continously prompt an user for a task
    Console.WriteLine("Please input a task and press enter to add it to your 'TO-DO'. Alternatively, you may leave it blank to finish.");
    string userInput = Console.ReadLine(); //grabbing the user's input

    if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput)) { //if the input is null, empty, or whitespace, then we break out of the loop to stop prompting the user
        break;
    } else { //if the input isn't null, whitespace, or empty, then we add it to our list
        tasks.Add(userInput);
    } 
}

Console.WriteLine("Your tasks:");

foreach (string task in tasks) { //loop through the list and print everything  inside
    Console.WriteLine(task);
}