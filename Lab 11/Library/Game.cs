using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Game : IInit
    {
        static Random rnd = new Random();
        protected int gameDate;
        public string GameName { get; set; }
        public SeriesNumber sr;


        static string[] Games = { "Elden ring", "Dark souls", "Mortal kombat", "Star wars", "Bloodborn", "Horizen zero dawn", "Assasins creed", "Catlevania", "Splinter cell", "Enter the gungeon", "Just cause", "Halo", "Dota", "Rust" };

        public int GameDate
        {
            get => gameDate;
            set
            {
                if (value >= 1990 && value <= 2022)
                {
                    gameDate = value;
                }
                if (value > 2022 || value < 1990)
                {
                    //Console.WriteLine("Невозможный год выпуска");
                    gameDate = 404;
                }
            }
        }

        public Game()
        {
            GameName = "Неизвестное название игры";
            GameDate = 404;
            sr = new SeriesNumber (10000);
        }

        public Game(string name, int year, int serie)
        {
            GameName = name;
            GameDate = year;
            sr = new SeriesNumber (serie);
        }

        public override string ToString()
        {
            return $"Название игры: {GameName}, дата выхода игры: {GameDate}, серия игры: {sr}";
        }


        public virtual void Init()
        {
            GameName = Games[rnd.Next(Games.Length)];
            GameDate = rnd.Next(1990, 2022);
            sr = new SeriesNumber (rnd.Next(10000, 19999));
        }
    }
}
