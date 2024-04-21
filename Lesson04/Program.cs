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

		// Всички банкноти и монети на българската валута в нарастващ ред
		static readonly decimal[] denominations = { 0.01m, 0.02m, 0.05m, 0.10m, 0.20m, 0.50m, 1m, 2m, 5m, 10m, 20m, 50m, 100m };

		// Метод за намиране на минималния брой банкноти и монети за дадена стойност
		static void FindMinDenominations(decimal value)
		{
			List<decimal> results = new List<decimal>();

			// Обхождане на банкноти и монети от най-голямо към най-малко
			for (int i = denominations.Length - 1; i >= 0; i--)
			{
				// Добавяне на банкноти и монети докато стойността е поне толкова голяма колкото номиналът
				while (value >= denominations[i])
				{
					value -= denominations[i];
					results.Add(denominations[i]);
				}
			}

			// Отпечатване на резултатите
			Console.WriteLine($"Минималният брой банкноти и монети е: {string.Join(", ", results)}");
		}

		static void Main()
		{
			//Console.Write("Въведете число за преобразуване в римски цифри: ");
			//int number = int.Parse(Console.ReadLine());

			//string romanNumeral = IntToRoman(number);
			//Console.WriteLine($"Римско число: {romanNumeral}");

			//Console.Write("Въведете римско число за преобразуване в десетично число: ");
			//string roman = Console.ReadLine();

			//int decimalValue = RomanToInt(roman);
			//Console.WriteLine($"Десетична стойност: {decimalValue}");

			decimal amount = 93.57m;  // Пример с монети и банкноти
			Console.WriteLine($"Изчисляване на минималния брой банкноти и монети за сумата: {amount}");
			FindMinDenominations(amount);
		}
	}
}
