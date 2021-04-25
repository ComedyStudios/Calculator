namespace ConsoleApp1
{
    public class MyMath
    {
        public static float Subtract( string number1, string number2)
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 - num2;
        }
        
        public static float Add( string number1, string number2)
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 + num2;
        }
        
        public static float Mulitply(string number1, string number2)
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 * num2;
        }
        
        public static float Divide(string number1, string number2)
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 / num2;
        }
    }
}