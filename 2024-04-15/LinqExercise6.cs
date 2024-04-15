public class StudentClass
{
	#region data
	protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
	protected class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int ID { get; set; }
		public GradeLevel Year;
		public List<int> ExamScores;
	}

	protected static List<Student> students = new List<Student>
	{
		new Student {FirstName = "Terry", LastName = "Adams", ID = 120,
			Year = GradeLevel.SecondYear,
			ExamScores = new List<int>{ 99, 82, 81, 79}},
		new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116,
			Year = GradeLevel.ThirdYear,
			ExamScores = new List<int>{ 99, 86, 90, 94}},
		new Student {FirstName = "Hanying", LastName = "Feng", ID = 117,
			Year = GradeLevel.FirstYear,
			ExamScores = new List<int>{ 93, 92, 80, 87}},
		new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114,
			Year = GradeLevel.FourthYear,
			ExamScores = new List<int>{ 97, 89, 85, 82}},
		new Student {FirstName = "Debra", LastName = "Garcia", ID = 115,
			Year = GradeLevel.ThirdYear,
			ExamScores = new List<int>{ 35, 72, 91, 70}},
		new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118,
			Year = GradeLevel.SecondYear,
			ExamScores = new List<int>{ 92, 90, 83, 78}},
		new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113,
			Year = GradeLevel.FirstYear,
			ExamScores = new List<int>{ 88, 94, 65, 91}},
		new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112,
			Year = GradeLevel.FourthYear,
			ExamScores = new List<int>{ 75, 84, 91, 39}},
		new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111,
			Year = GradeLevel.SecondYear,
			ExamScores = new List<int>{ 97, 92, 81, 60}},
		new Student {FirstName = "Lance", LastName = "Tucker", ID = 119,
			Year = GradeLevel.ThirdYear,
			ExamScores = new List<int>{ 68, 79, 88, 92}},
		new Student {FirstName = "Michael", LastName = "Tucker", ID = 122,
			Year = GradeLevel.FirstYear,
			ExamScores = new List<int>{ 94, 92, 91, 91}},
		new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
			Year = GradeLevel.FourthYear,
			ExamScores = new List<int>{ 96, 85, 91, 60}}
	};
	#endregion

	public void QueryHighScores(int exam, int score)
	{
		var highScores = from s in students
						 where s.ExamScores[exam] >= score
						 select new { Name = s.LastName + ", " + s.FirstName, Score = s.ExamScores[exam] };

		foreach (var item in highScores)
		{
			Console.WriteLine($"{item.Name,-15}{item.Score}");
		}
	}

	public void GroupBySingleProperty()
	{
		Console.WriteLine("Group by a single property in an object:");

		// Variable queryLastNames is an IEnumerable<IGrouping<string, 
		// DataClass.Student>>. 

		var queryLastNames = students.GroupBy(x => x.LastName);

		foreach (var nameGroup in queryLastNames)
		{
			Console.WriteLine($"Key: {nameGroup.Key}");
			foreach (var student in nameGroup)
			{
				Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
			}
		}
		/* Output:
			Group by a single property in an object:
			Key: Adams
					Adams, Terry
			Key: Fakhouri
					Fakhouri, Fadi
			Key: Feng
					Feng, Hanying
			Key: Garcia
					Garcia, Cesar
					Garcia, Debra
					Garcia, Hugo
			Key: Mortensen
					Mortensen, Sven
			Key: O'Donnell
					O'Donnell, Claire
			Key: Omelchenko
					Omelchenko, Svetlana
			Key: Tucker
					Tucker, Lance
					Tucker, Michael
			Key: Zabokritski
					Zabokritski, Eugene
		*/
	}

	public void GroupBySubstring()
	{
		Console.WriteLine("\r\nGroup by something other than a property of the object:");

		var queryFirstLetters = from s in students
								group s by s.LastName[0];
								

		foreach (var studentGroup in queryFirstLetters)
		{
			Console.WriteLine($"Key: {studentGroup.Key}");
			// Nested foreach is required to access group items.
			foreach (var student in studentGroup)
			{
				Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
			}
		}
		/* Output:
			Group by something other than a property of the object:
			Key: A
					Adams, Terry
			Key: F
					Fakhouri, Fadi
					Feng, Hanying
			Key: G
					Garcia, Cesar
					Garcia, Debra
					Garcia, Hugo
			Key: M
					Mortensen, Sven
			Key: O
					O'Donnell, Claire
					Omelchenko, Svetlana
			Key: T
					Tucker, Lance
					Tucker, Michael
			Key: Z
					Zabokritski, Eugene
		*/
	}

	//Helper method, used in GroupByRange.
	protected static int GetPercentile(Student s)
	{
		double avg = s.ExamScores.Average();
		return avg > 0 ? (int)avg / 10 : 0;
	}

	public void GroupByRange()
	{
		Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

		var queryNumericRange = from s in students
								orderby s.ExamScores.Average()
								group s by GetPercentile(s);

		// Nested foreach required to iterate over groups and group items.
		foreach (var studentGroup in queryNumericRange)
		{
			Console.WriteLine($"Key: {studentGroup.Key * 10}");
			foreach (var item in studentGroup)
			{
				Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
			}
		}
		/* Output:
			Group by numeric range and project into a new anonymous type:
			Key: 60
					Garcia, Debra
			Key: 70
					O'Donnell, Claire
			Key: 80
					Adams, Terry
					Feng, Hanying
					Garcia, Cesar
					Garcia, Hugo
					Mortensen, Sven
					Omelchenko, Svetlana
					Tucker, Lance
					Zabokritski, Eugene
			Key: 90
					Fakhouri, Fadi
					Tucker, Michael
		*/
	}

	public void GroupByBoolean()
	{
		Console.WriteLine("\r\nGroup by a Boolean into two groups with string keys");
		Console.WriteLine("\"True\" and \"False\" and project into a new anonymous type:");
		var queryGroupByAverages = from s in students
								   group s by GetPercentile(s) >= 8;
		foreach (var studentGroup in queryGroupByAverages)
		{
			Console.WriteLine($"Key: {studentGroup.Key}");
			foreach (var student in studentGroup)
				Console.WriteLine($"\t{student.FirstName} {student.LastName}");
		}

		/* Output:
			Group by a Boolean into two groups with string keys
			"True" and "False" and project into a new anonymous type:
			Key: True
					Terry Adams
					Fadi Fakhouri
					Hanying Feng
					Cesar Garcia
					Hugo Garcia
					Sven Mortensen
					Svetlana Omelchenko
					Lance Tucker
					Michael Tucker
					Eugene Zabokritski
			Key: False
					Debra Garcia
					Claire O'Donnell
		*/
	}

	public void GroupByCompositeKey()
	{
		var queryHighScoreGroups = from s in students
								   group s by new { FirstLetter = s.LastName[0], Score = s.ExamScores.Average() >= 85 };

		Console.WriteLine("\r\nGroup and order by a compound key:");
		foreach (var scoreGroup in queryHighScoreGroups)
		{
			string s = scoreGroup.Key.Score == true ? "more than" : "less than";
			Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetter} who scored {s} 85");
			foreach (var item in scoreGroup)
			{
				Console.WriteLine($"\t{item.FirstName} {item.LastName}");
			}
		}
		/* Output:
			Group and order by a compound key:
			Name starts with A who scored more than 85
					Terry Adams
			Name starts with F who scored more than 85
					Fadi Fakhouri
					Hanying Feng
			Name starts with G who scored more than 85
					Cesar Garcia
					Hugo Garcia
			Name starts with G who scored less than 85
					Debra Garcia
			Name starts with M who scored more than 85
					Sven Mortensen
			Name starts with O who scored less than 85
					Claire O'Donnell
			Name starts with O who scored more than 85
					Svetlana Omelchenko
			Name starts with T who scored less than 85
					Lance Tucker
			Name starts with T who scored more than 85
					Michael Tucker
			Name starts with Z who scored more than 85
					Eugene Zabokritski
		*/
	}
}

public class Program
{
	public static void Main()
	{
		StudentClass sc = new StudentClass();
		sc.QueryHighScores(1, 90);		// 1
		sc.GroupBySingleProperty();		// 2
		sc.GroupBySubstring();			// 3
		sc.GroupByRange();				// 4

		sc.GroupByBoolean();			// 5
		sc.GroupByCompositeKey();		// 6

		// Keep the console window open in debug mode.
		Console.WriteLine("Press any key to exit");
		Console.ReadKey();
	}
}