﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Racegame
{
    public class Vehicle
    {
        //Getters en Setters
        public Point Position;
        public Point Speed;
        public int CarSize { get; set; }
        public int AxisSpeed { get; set; }
        public Color kleur { get; set; }
        /// <summary>
        /// De constructor
        /// </summary>
        /// <param name="value">De locatie van de vehicle</param>
        public Vehicle(int x, int y)
        {
            this.Position = new Point(x, y);
            this.Speed = new Point(0, 0);
            this.CarSize = 30;
            this.AxisSpeed = 2;
        }
        /// <summary>
        /// Tekent het object op de juiste locatie
        /// </summary>
        /// <param name="g">De type</param>
        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, this.Position.X - this.CarSize / 2, this.Position.Y - this.CarSize / 2, this.CarSize, this.CarSize);
        }
        /// <summary>
        /// Overload van het eerdere methode
        /// </summary>
        /// <param name="g">De type</param>
        /// <param name="b">De kleur in string</param>
        public void Draw(Graphics g, String b)
        {
            if (b == "red")
                g.FillRectangle(Brushes.Red, this.Position.X - this.CarSize / 2, this.Position.Y - this.CarSize / 2, this.CarSize, this.CarSize);
            if (b == "yellow")
                g.FillRectangle(Brushes.Yellow, this.Position.X - this.CarSize / 2, this.Position.Y - this.CarSize / 2, this.CarSize, this.CarSize);
        }
        public void checklocation()
        {
            //hier check je of de autos niet van het scherm rijden/ Als de voertuig "Te verweg is van de baan" word hij op de start positie gezet
            if (Position.X < -10 | Position.Y < -10 | Position.X > 1000 | Position.Y > 710)
            {
                Position.X = 768;
                Position.Y = 70;
            }
            //Hier word gecheckt als de voertuig zich mag verplaatsen op de locatie
            if (Position.X > 0 & Position.Y > 0 & Position.X < 990 & Position.Y < 700)
            {
                Position.X += Speed.X;
                Position.Y += Speed.Y;
            }
            //Als de voertuig tegen de grens aanzit word hij gestopt
            else
            {
                Position.X -= Speed.X;
                Position.Y -= Speed.Y;
            }
        }
        public void getColor()
        {
            try
            {
                //wat is de kleur van de huidige positie
                //Checkt de kleur waar vehicle1 op positie staat(We moeten echt de GUI afschafen van Visual studio :p)
                //Controleer de juist locatie
                var image = new Bitmap(@"C:\Users\robert\Documents\GitHub\Racegame\Racegame\Racegame\Racegame\Resources\Naamloos.jpg");
                //Een if statement voor een onnodige exception
                if (Position.X < -10 | Position.Y < -10 | Position.X < 1000 | Position.Y < 710)
                {
                    Color kleur = image.GetPixel(Position.X, Position.Y);
                    //Debug geeft de code waar hij op staat
                    Console.WriteLine(kleur);
                    //Gras
                    if (kleur.A.Equals(255) && kleur.R.Equals(0) && kleur.G.Equals(128) && kleur.B.Equals(1))
                        Console.WriteLine("Gras");
                    //De weg
                    if (kleur.A.Equals(255) && kleur.R.Equals(106) && kleur.G.Equals(104) && kleur.B.Equals(105))
                        Console.WriteLine("weg");
                    //Pitstop
                    if (kleur.A.Equals(255) && kleur.R.Equals(0) && kleur.G.Equals(0) && kleur.B.Equals(206))
                        Console.WriteLine("Pitstop");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error met de bitmap: " + e);
            }
        }
    }
}
