using MyMonkeyApp;

namespace MyMonkeyApp;

class Program
{
	private static readonly string[] AsciiArts =
	[
		@"
		 w  c( .. )o   (
		  \__(- )    __)
			  /\   (
			 /(_)___)
			w  / |
			 |  \
		",
		@"
		(\__/)
		(•ㅅ•)
		/ 　 づ
		",
		@"
		 _     _
		(o)---(o)
		/       \
		\_/| |\_/
		  /_\
		",
		@"
		 //\   /\\
		( o.o ) 
		 > ^ <
		"
	];

	static void Main()
	{
		var random = new Random();
		bool running = true;

		while (running)
		{
			Console.Clear();
			// 랜덤 ASCII 아트 출력
			Console.WriteLine(AsciiArts[random.Next(AsciiArts.Length)]);
			Console.WriteLine("==== Monkey Console App ====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();

			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyDetails();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					running = false;
					Console.WriteLine("Bye! 🐒");
					break;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}

			if (running)
			{
				Console.WriteLine("\nPress Enter to continue...");
				Console.ReadLine();
			}
		}
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("\n--- All Monkeys ---");
		foreach (var m in monkeys)
		{
			Console.WriteLine($"- {m.Name} ({m.Location})");
		}
	}

	static void GetMonkeyDetails()
	{
		Console.Write("\nEnter monkey name: ");
		var name = Console.ReadLine() ?? "";
		var monkey = MonkeyHelper.GetMonkeyByName(name);
		if (monkey is not null)
		{
			Console.WriteLine($"\nName: {monkey.Name}");
			Console.WriteLine($"Location: {monkey.Location}");
			Console.WriteLine($"Population: {monkey.Population}");
			Console.WriteLine($"Details: {monkey.Details}");
			Console.WriteLine($"Image: {monkey.Image}");
			Console.WriteLine($"Coordinates: {monkey.Latitude}, {monkey.Longitude}");
		}
		else
		{
			Console.WriteLine("Monkey not found!");
		}
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		Console.WriteLine("\n--- Random Monkey ---");
		Console.WriteLine($"Name: {monkey.Name}");
		Console.WriteLine($"Location: {monkey.Location}");
		Console.WriteLine($"Population: {monkey.Population}");
		Console.WriteLine($"Details: {monkey.Details}");
		Console.WriteLine($"Image: {monkey.Image}");
		Console.WriteLine($"Coordinates: {monkey.Latitude}, {monkey.Longitude}");
		Console.WriteLine($"\nRandom monkey picked {MonkeyHelper.GetRandomPickCount()} times.");
	}
}
