public record Course(
  string Title,
  string Description,
  int Credits
);

Course course = new Course(
  Title: "Introduction to Programming",
  Description: "Learn the basics of programming using C#.",
  Credits: 3
);

System.Console.WriteLine($"Course Title: {course.Title}");