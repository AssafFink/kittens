namespace AssafFinkelshtein;

public class Kitten
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }

    public Kitten(int id, string name, int age, string color)
    {
        ID = id;
        Name = name;
        Age = age;
        Color = color;
    }
}
