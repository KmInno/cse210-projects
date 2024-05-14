using System;

class program
{
    static void Main(string[] args)
    {
        Console.Write("what is the numerator: ");
        int Numerator = Convert.ToInt32(Console.ReadLine());
        Console.Write("what is the denominator: ");
        int Denominator = Convert.ToInt32(Console.ReadLine());

        Fraction Fraction = new Fraction(Numerator, Denominator);
        Fraction.print();

        //Console.WriteLine(Numerator + "/" + Denominator);
        Console.ReadLine();
    }
}

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public int Numerator
    {
        get { return _numerator; }
    }

    public int Denominator
    {
        get { return _denominator; }
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }
}
