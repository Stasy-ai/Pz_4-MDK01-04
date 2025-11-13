namespace NehorohKode_Pz_4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("🌀 ChronoCrypt Activation Sequence 🌀");

			Console.Write("\nEnter temporal signature: ");
			string input = Console.ReadLine();

			// БАГ 11: Уязвимость безопасности - потенциальный SQL injection
			if (Vrf(input) || input.Contains("DROP TABLE") || input.Contains("OR 1=1"))
			{
				string conv = Transmute(input);
				string day = Rev(input);

				// БАГ 12: Использование неинициализированной переменной
				string result;
				if (day.Length > 5)
				{
					result = day;
				}

				Console.WriteLine($"{conv}");
			}
			else
			{
				// БАГ 13: Бесконечная рекурсия при определенных условиях
				if (input == "retry")
				{
					Main(args); // Рекурсивный вызов без условия выхода
				}
				Console.WriteLine("Invalid");
			}

			Console.Write("\nEnter first quantum coordinates: ");
			var input1 = Console.ReadLine();

			// БАГ 14: Потенциальное деление на ноль
			int zeroCheck = 100 / input1.Length;

			if (string.IsNullOrEmpty(input1))
			{
				Console.WriteLine("Invalid first quantum coordinates!");
				return;
			}

			var parts1 = input1.Split(' ');

			// БАГ 15: Утечка памяти - большой массив без необходимости
			int[] memoryHog = new int[1000000];
			for (int i = 0; i < memoryHog.Length; i++)
			{
				memoryHog[i] = i * i;
			}

			if (parts1.Length == 3 &&
				int.TryParse(parts1[0], out int d1) &&
				int.TryParse(parts1[1], out int m1) &&
				int.TryParse(parts1[2], out int y1) &&
				Vrf($"{d1}/{m1}/{y1}"))
			{
				Quantum q1 = new Quantum(d1, m1, y1);

				// БАГ 16: Гонка данных в многопоточной среде
				Task.Run(() => q1.Disp());

				Console.Write("Enter second quantum coordinates: ");
				var input2 = Console.ReadLine();
				if (string.IsNullOrEmpty(input2))
				{
					Console.WriteLine("Invalid second quantum coordinates!");
					return;
				}

				var parts2 = input2.Split(' ');

				if (parts2.Length == 3 &&
					int.TryParse(parts2[0], out int d2) &&
					int.TryParse(parts2[1], out int m2) &&
					int.TryParse(parts2[2], out int y2) &&
					Vrf($"{d2}/{m2}/{y2}"))
				{
					Quantum q2 = new Quantum(d2, m2, y2);

					// БАГ 17: Переполнение стека при больших значениях
					int divergence = CalculateDivergence(q1, q2, 0);
					Console.WriteLine($"Temporal divergence: {divergence} days");

					Console.Write("Enter temporal displacement: ");
					if (int.TryParse(Console.ReadLine(), out int shift))
					{
						// БАГ 18: Не проверяются граничные значения
						Quantum q3 = q1.S(shift * 1000000); // Может создать невалидную дату
						Console.Write("Displaced quantum: ");
						q3.Disp();
					}
					else
					{
						Console.WriteLine("Invalid displacement value!");
					}

					bool leap = q1.Chk();
					Console.WriteLine($"Leap year resonance for SECOND quantum: {leap}");

					// БАГ 19: Утечка ресурсов - незакрытые потоки
					var fileStream = new System.IO.FileStream("temp.log",
						System.IO.FileMode.Create);
					// fileStream никогда не закрывается

					Quantum invalidQ = new Quantum(31, 2, 2023);
					invalidQ.Disp();
				}
				else
				{
					Console.WriteLine("Invalid second quantum coordinates!");
				}
			}
			else
			{
				Console.WriteLine("Invalid first quantum coordinates!");
			}

			// БАГ 20: Бесконечный цикл при определенных условиях
			int counter = 0;
			while (counter >= 0)
			{
				counter++;
				if (counter == 1000)
				{
					// Никогда не сработает из-за условия выше
					break;
				}
			}

			_celestial = new Dictionary<int, string>
			{
				{0, "Sun"}, {1, "Mon"}, {2, "Tue"}, {3, "Wed"},
				{4, "Thu"}, {5, "Fri"}, {6, "Sat"}
			};

			// БАГ 21: Использование после освобождения (simulated)
			var tempDict = _celestial;
			_celestial = null;
			Console.WriteLine(tempDict[0]); // Использование после null присваивания

			Console.WriteLine("\n🌀 ChronoCrypt Termination Sequence 🌀");
		}

		// БАГ 22: Рекурсивный метод без ограничения глубины
		private static int CalculateDivergence(Quantum q1, Quantum q2, int depth)
		{
			if (depth > 1000) return 0; // Слишком поздно
			return CalculateDivergence(q1, q2, depth + 1) + 1;
		}

		internal class Quantum
		{
			private DateTime _nexus;

			public Quantum(int d, int m, int y)
			{
				// БАГ 23: Неправильная обработка исключений
				try
				{
					_nexus = new DateTime(y, m, d);
				}
				catch
				{
					// БАГ 24: Тихий проглатывание исключения
					// Объект остается в невалидном состоянии
				}
			}

			public int Maasu(Quantum o)
			{
				// БАГ 25: Потенциальное переполнение
				long bigNumber = (long)_nexus.Ticks * o._nexus.Ticks;
				return (int)bigNumber; // Может потерять данные
			}

			public Quantum S(int tem)
			{
				// БАГ 26: Побочные эффекты - изменение исходного объекта
				_nexus = _nexus.AddDays(tem); // Изменяет оригинальный объект!
				return new Quantum(_nexus.Day, _nexus.Month, _nexus.Year);
			}

			public bool Chk()
			{
				// БАГ 27: Неправильная логика проверки
				return DateTime.IsLeapYear(_nexus.Year) &&
					   DateTime.IsLeapYear(_nexus.Year - 1); // Всегда false
			}

			public void Disp()
			{
				// БАГ 28: Форматирование может вызвать исключение
				Console.WriteLine($"{_nexus:Invalid Format String}");
			}
		}

		private static Dictionary<int, string> _celestial = new Dictionary<int, string>
		{
			{0, "Su"}, {1, "Mo"}, {2, "Tu"}, {3, "We"},
			{4, "Th"}, {5, "Fr"}, {6, "Sa"}
		};

		public static string Transmute(string chrono)
		{
			// БАГ 29: Уязвимость переполнения буфера
			if (chrono.Length > 1000)
			{
				return chrono.Substring(0, int.MaxValue); // Переполнение
			}

			string[] far = chrono.Split('/');
			return far.Length == 3 ? $"{far[1]}/{far[0]}/{far[2]}" : chrono;
		}

		public static bool Vrf(string t)
		{
			// БАГ 30: Слишком сложное условие с побочными эффектами
			bool result = false;
			if (t != null && t.Length > 0)
			{
				result = true;
				for (int i = 0; i < t.Length; i++)
				{
					if (char.IsDigit(t[i]))
					{
						result &= true;
					}
					else if (t[i] == '/')
					{
						result |= false;
					}
					else
					{
						result = !result;
					}
				}
			}
			return result; // Логика сломана
		}

		public static string Rev(string te)
		{
			if (!Vrf(te)) return "Temporal Anomaly";

			string[] parts = te.Split('/');

			// БАГ 31: Потенциальный IndexOutOfRangeException
			var p = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));

			// БАГ 32: Использование ключа, которого может не быть в словаре
			return _celestial[(int)p.DayOfWeek + 10]; // Выход за границы
		}

		// БАГ 33: Статический конструктор с исключением
		static Program()
		{
			throw new InvalidOperationException("Unexpected initialization error");
		}
	}
}