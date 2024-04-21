using System.Text;

namespace Lesson04
{
	class Program
	{
		// Статичен речник със съответствията между римските цифри и техните стойности
		private static readonly Dictionary<string, int> romanMap = new Dictionary<string, int>()
		{
			{"M", 1000},
			{"CM", 900},
			{"D", 500},
			{"CD", 400},
			{"C", 100},
			{"XC", 90},
			{"L", 50},
			{"XL", 40},
			{"X", 10},
			{"IX", 9},
			{"V", 5},
			{"IV", 4},
			{"I", 1}
		};

		// Метод за преобразуване на цяло число в римско число
		public static string IntToRoman(int number)
		{
			StringBuilder roman = new StringBuilder();

			// Итерация през всеки символ, започвайки от най-големия
			foreach (var item in romanMap)
			{
				// Продължаваме да добавяме съответната римска цифра, докато може да бъде извадена от числото
				while (number >= item.Value)
				{
					roman.Append(item.Key); // Добавяне на римската цифра
					number -= item.Value;  // Намаляване на числото със стойността на римската цифра
				}
			}

			return roman.ToString();
		}

		// Метод за преобразуване на римско число в цяло число
		public static int RomanToInt(string s)
		{
			// Речник с римските цифри и техните стойности
			Dictionary<char, int> romanMap = new Dictionary<char, int>()
			{
				{'I', 1},
				{'V', 5},
				{'X', 10},
				{'L', 50},
				{'C', 100},
				{'D', 500},
				{'M', 1000}
			};

			int total = 0;
			for (int i = 0; i < s.Length - 1; i++)
			{
				// Вземане стойността на текущия и следващия символ
				int current = romanMap[s[i]];
				int next = romanMap[s[i + 1]];

				// Добавяне или изваждане на текущата стойност в зависимост от стойността на следващия символ
				if (current < next)
				{
					total -= current;
				}
				else
				{
					total += current;
				}
			}

			// Добавяне на стойността на последния символ
			total += romanMap[s[s.Length - 1]];

			return total;
		}

		static void Main()
		{
			Console.Write("Въведете число за преобразуване в римски цифри: ");
			int number = int.Parse(Console.ReadLine());

			string romanNumeral = IntToRoman(number);
			Console.WriteLine($"Римско число: {romanNumeral}");

			Console.Write("Въведете римско число за преобразуване в десетично число: ");
			string roman = Console.ReadLine();

			int decimalValue = RomanToInt(roman);
			Console.WriteLine($"Десетична стойност: {decimalValue}");
		}
	}
}
