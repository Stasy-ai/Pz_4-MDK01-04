namespace NehorohKode_Pz_4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("🌀 ChronoCrypt Activation Sequence 🌀");

			Console.Write("\nEnter temporal signature: ");
			string input = Console.ReadLine();
			    
			if (Vrf(input))
			{
				string conv = Transmute(input);
				string day = Rev(input);

				Console.WriteLine($"{conv}");
				Console.WriteLine($"{day}");
			}
			else
			{
				Console.WriteLine("Invalid");
			}

			Console.Write("\nEnter first quantum coordinates: ");
			var input1 = Console.ReadLine();
			if (string.IsNullOrEmpty(input1))
			{
				Console.WriteLine("Invalid first quantum coordinates!");
				return;
			}

			var parts1 = input1.Split(' ');

			if (parts1.Length == 3 &&
				int.TryParse(parts1[0], out int d1) &&
				int.TryParse(parts1[1], out int m1) &&
				int.TryParse(parts1[2], out int y1) &&
				Vrf($"{d1}/{m1}/{y1}"))
			{
				Quantum q1 = new Quantum(d1, m1, y1);

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

					int divergence = q1.Maasu(q2);
					Console.WriteLine($"Temporal divergence: {divergence} days");

					Console.Write("Enter temporal displacement: ");
					if (int.TryParse(Console.ReadLine(), out int shift))
					{
						Quantum q3 = q1.S(shift);
						Console.Write("Displaced quantum: ");
						q3.Disp();
					}
					else
					{
						Console.WriteLine("Invalid displacement value!");
					}

					bool leap = q1.Chk();
					Console.WriteLine($"Leap year resonance: {leap}");
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

			Console.WriteLine("\n🌀 ChronoCrypt Termination Sequence 🌀");
		}

		internal class Quantum
		{
			private DateTime _nexus;

			public Quantum(int d, int m, int y)
			{
				_nexus = new DateTime(y, m, d);
			}

			public int Maasu(Quantum o)
			{
				TimeSpan d = _nexus - o._nexus;
				return Math.Abs((int)d.TotalDays);
			}

			public Quantum S(int tem)
			{
				DateTime shif = _nexus.AddDays(tem);
				return new Quantum(shif.Day, shif.Month, shif.Year);
			}

			public bool Chk()
			{
				return DateTime.IsLeapYear(_nexus.Year);
			}

			public void Disp()
			{
				Console.WriteLine($"{_nexus:dd/MM/yyyy}");
			}
		}

		private static Dictionary<int, string> _celestial = new Dictionary<int, string>
		{
			{0, "Su"}, {1, "Mo"}, {2, "Tu"}, {3, "We"},
			{4, "Th"}, {5, "Fr"}, {6, "Sa"}
		};

		public static string Transmute(string chrono)
		{
			string[] far = chrono.Split('/');
			return far.Length == 3 ? $"{far[1]}/{far[0]}/{far[2]}" : chrono;
		}

		public static bool Vrf(string t)
		{
			if (string.IsNullOrWhiteSpace(t)) return false;

			string[] papa = t.Split('/');
			if (papa.Length != 3) return false;

			if (!int.TryParse(papa[0], out int d) ||
				!int.TryParse(papa[1], out int m) ||
				!int.TryParse(papa[2], out int y)) return false;

			if (y < 1 || y > 9999) return false;
			if (m < 1 || m > 12) return false;

			try
			{
				DateTime date = new DateTime(y, m, d);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static string Rev(string te)
		{
			if (!Vrf(te)) return "Temporal Anomaly";

			string[] parts = te.Split('/');
			var p = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
			return _celestial[(int)p.DayOfWeek];
		}
	}
}