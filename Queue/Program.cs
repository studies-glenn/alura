public class Queues
{
	static Queue<string> pedagio = new Queue<string>();
	/*
	* Queues implement the "First in First out" methodology
	* Enqueue ::  Add a new item to queue
	* Dequeue ::  Remove the first item from queue
	* Peek	  ::  Take a look into the next item to remove from queue
	* https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-6.0
	*/
	static void Main()
	{
		AddToQueue("van");
		AddToQueue("kombi");
		AddToQueue("fusca");
		RemoveFromQueue();
		RemoveFromQueue();
		RemoveFromQueue();
	}

	static void AddToQueue(string vehicle)
	{
		pedagio.Enqueue(vehicle);
		System.Console.WriteLine(string.Join("-", pedagio));
	}

	static void RemoveFromQueue()
	{
		if (pedagio.Any())
		{
			pedagio.Dequeue();
			System.Console.WriteLine(string.Join("-", pedagio));
		}
	}
}