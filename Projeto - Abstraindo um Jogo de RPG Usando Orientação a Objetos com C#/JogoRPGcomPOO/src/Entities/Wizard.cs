namespace JogoRPGcomPOO.src.Entities
{
    public class Wizard : Hero
    {
        public Wizard(string Name, int Level, string HeroType, int HP, int MP) : base(Name, Level, HeroType, HP, MP)
        {
            base.Name = Name;
            base.Level = Level;
            base.HeroType = HeroType; 
            base.HP = HP;
            base.MP = MP;
        }

        public override string Attack()
        {
            return this.Name + " Lançou a Magia!";
        }

        public string Attack(int Bonus)
        {
            if(Bonus > 0 && Bonus <= 4) return this.Name + " Lançou uma Magia Fraca com Bônus de " + Bonus;
            else if(Bonus >= 5 && Bonus <= 6) return this.Name + " Lançou uma Super Magia com Bônus de " + Bonus;
            else return this.Name + " Lançou uma Magia Branca com Bônus de " + Bonus;
        }

        
    }
}