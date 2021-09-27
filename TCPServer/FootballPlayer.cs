using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    class FootballPlayer
    {
        
        public int Id { get; set; }
        private string _name;

        private int _price;

        private int _shirtNumber;


        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException(
                        "the name has to be atleast 4 charecters long... Sorry Asian people");
                _name = value;
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("The Price should be over 0");
                _price = value;
            }
        }
        public int ShirtNumber
        {
            get => _shirtNumber;
            set
            {
                if (value <= 0 || value > 100) throw new ArgumentOutOfRangeException("The shirtnumber should be between 1 and 100");
                _shirtNumber = value;
            }

        }

        public FootballPlayer(string name, int price, int shirtnumber, int id)
        {
            Name = name;
            Price = price;
            ShirtNumber = shirtnumber;
            Id = id;

        }


    }
}

