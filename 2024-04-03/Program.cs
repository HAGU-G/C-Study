D d = new D(1);

Console.WriteLine(d.y);





public class B
{
    public static int x = 1;         // Executes 3rd
    public B(int x)
    {
        B.x = x;
    }

}
public class D : B
{
    public int y = x;         // Executes 1st
    public D(int x)
      : base(x + 1)   // Executes 2nd
    {
       // y = B.x;
    }
}