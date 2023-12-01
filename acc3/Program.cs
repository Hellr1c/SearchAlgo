using System;

class SearchAlgo {

    static void Main(string[] args) {

        String[] img = { "cat.png", "computer.png", "pizza.png", "milk tea.png", "shoes.png" };

        String[,] tags = {
            {"pet","animal","cute","mammal","furry"},
            {"gadget","technology","device","hardware","software"},
            {"food","snack","italian","bread","cheese"},
            {"drink","dessert","beverage","sweet","cold"},
            {"rubber","footware","leather","comfort","fashion"}
        };

        int[] pts = { 0, 0, 0, 0, 0 };

        bool loop = true;

        while (loop) {
            Console.Write("Enter a string to search: ");
            String input = Console.ReadLine();

            search(input, pts, tags, img);

            // Display the search results
            Console.WriteLine("\nSearch Results:");
            for (int i = 0; i < img.Length; i++)
            {
                Console.WriteLine(img[i] + " - " + pts[i] + " points");
            }

            Console.WriteLine("");
            Console.Write("Search Again? (Y/N): ");
            String choice = Console.ReadLine();
            if (choice.ToUpper() != "Y") {
                loop = false;
            }
        }

    }

    static void search(String input, int[] pts, String[,] tags, String[] img) {

        
        for (int i = 0; i < img.Length; i++)
        {
            for (int j = 0; j < tags.GetLength(1); j++)
            {
                if (tags[i, j].ToLower().Contains(input.ToLower()))
                {
                    pts[i]++;
                }
            }
        }

        // Sort images by points in descending order using insertion sort
        for (int i = 1; i < img.Length; i++)
        {
            int key = pts[i];
            int j = i - 1;

            while (j >= 0 && pts[j] < key)
            {
                pts[j + 1] = pts[j];
                j--;
            }

            pts[j + 1] = key;

            // Swap images based on sorted points
            string temp = img[i];
            img[i] = img[j + 1];
            img[j + 1] = temp;
        }

    }

}
