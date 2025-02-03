namespace AssafFinkelshtein;

public static class Repository
{
    public static List<Kitten> Kittens = new List<Kitten>();

    static Repository()
    {
        Kittens.Add(new Kitten(1, "Mitsii", 4, "White"));
        Kittens.Add(new Kitten(2, "Oscar", 5, "Gray"));
        Kittens.Add(new Kitten(3, "Cyber", 6, "Black"));
        Kittens.Add(new Kitten(4, "Kitsi", 3, "Brown"));
    }
}
