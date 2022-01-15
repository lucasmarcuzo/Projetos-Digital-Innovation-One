namespace JogoRPGcomPOO.src.Entities
{
    public class Knight : Hero
    {
        public Knight(string Name, int Level, string HeroType, int HP, int MP) : base(Name, Level, HeroType, HP, MP)
        {
            base.Name = Name;
            base.Level = Level;
            base.HeroType = HeroType; 
            base.HP = HP;
            base.MP = MP;
        }

        public override string Attack()
        {
            return this.Name + " Atacou com a Espada!";
        }

        public string Attack(int Bonus)
        {
            if(Bonus > 0 && Bonus <= 4) return this.Name + " Atacou com a Espada com Bônus de " + Bonus;
            else if(Bonus >= 5 && Bonus <= 6) return this.Name + " Atacou com a Espada e o Escudo com Bônus de " + Bonus;
            else return this.Name + " Atacou em um Cavalo com a Espada e o Escudo com Bônus de " + Bonus;
        }


    }
}