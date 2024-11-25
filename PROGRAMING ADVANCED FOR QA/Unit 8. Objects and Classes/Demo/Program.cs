
Dog smallDog = new Dog();
smallDog.Name = "Ricky";
smallDog.Breed = "Pincher";
smallDog.Age = 1;

Dog middleDog = new Dog("Bobo", "Corgi", 3);

Console.WriteLine(smallDog.Bark());
Console.WriteLine(middleDog.Bark() + " as well!");


class Dog
{
    public Dog()
    {
        
    }
    public Dog(string name, string breed, int age)
    {
        Name = name;
        Breed = breed;
        Age = age;
    }

    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age {  get; set; }   

    public string Bark()
    {
        return $"{this.Name}, the {Breed} barks";
    }
}
