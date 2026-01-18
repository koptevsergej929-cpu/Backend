namespace ур_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
        }


        public class Thermometer
        {
            private int _terperatureCelsius;

            public int TerperatureCelsius
            {
                get { return _terperatureCelsius; }
                set
                {
                    if (value >= -273)
                    {
                        _terperatureCelsius = value;
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }

            public int TerperatureFahreheit
            {
                get
                {
                    return (_terperatureCelsius * 9 / 5) + 32;
                }
            }
        }



        public class Banckaccount
        {
            public string _balance;

            public void Deposit(double amount)
            {
                _balance += amount;
            }

            public void WithDraw(double amount)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                }
                else
                {
                    Console.WriteLine("Недостаточно средств.");
                }
            }

            public void ShowBalance()
            {
                Console.WriteLine(_balance);
            }
        }


        public class Person
        {
            private string _name;
            private int _age;

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _name = value;
                    }
                    else
                    {
                        Console.WriteLine("Имя не может быть пустым");
                    }
                        
                }
            }

            public int Age
            {
                get { return _age; }
                set
                {
                    if (value >= 0)
                    {
                        _age = value;
                    }
                    else
                    {
                        Console.WriteLine("Возраст н еможет быть отрицательным");
                    }
                }
            }
                
        }
    }
}
