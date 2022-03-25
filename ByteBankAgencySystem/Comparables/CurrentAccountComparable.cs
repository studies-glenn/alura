using Models;

namespace Comparables;

public class CurrentAccountComparable : IComparer<CurrentAccount>
{
	public int Compare(CurrentAccount? x, CurrentAccount? y)
	{
		// return -1 when 'x' precedes 'y'
		// return 0 when 'x' equals to 'y'
		// return 1 when 'y' precedes 'x' 
		if (x == y) return 0;
		if (x is null) return 1;
		if (y is null) return -1;

		return x.Agency.CompareTo(y.Agency);

		/*
		* if (x.Agency < y.Agency) return -1;  // 'x' before 'y'
		* if (x.Agency == y.Agency) return 0; // 'x' equals to 'y'
		* return 1; // 'x' after 'y'
		*/
	}
}