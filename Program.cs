
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
var distance = 0;

var countList1 = new Dictionary<int, int>();
var countList2 = new Dictionary<int, int>();

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");


foreach (var line in File.ReadLines(path))
{
    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

  
        if (int.TryParse(parts[0], out var number1))
        {
            list1.Add(number1);
            if (countList1.ContainsKey(number1))
            {
                countList1[number1]++;
            }
            else
            {
                countList1[number1] = 1;
            }
        }

        if (int.TryParse(parts[1], out var number2))
        {
            list2.Add(number2);
            if (countList2.ContainsKey(number2))
            {
                countList2[number2]++;
            }
            else
            {
                countList2[number2] = 1;
            }
    }
}

list1.Sort();
list2.Sort();

for (int i = 0; i < list1.Count; i++)
{
    distance += Math.Abs(list1[i] - list2[i]);
}

Console.WriteLine(distance);

var valuesIntersecting = list1.Intersect(list2);
var total = 0;
for (int i = 0; i < list1.Count; i++)
{
    if (countList2.ContainsKey(list1[i]))
    {
        total += list1[i] * countList2[list1[i]];
    }
}


Console.WriteLine("Result: " + total);
Console.ReadLine();
