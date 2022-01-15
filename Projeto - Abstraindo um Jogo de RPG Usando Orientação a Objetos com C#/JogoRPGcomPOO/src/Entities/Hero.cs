namespace JogoRPGcomPOO.src.Entities
{
    public abstract class Hero
    {
        public string Name { get; set; }
        
        public int Level { get; set; }
        
        public string HeroType { get; set; }

        public int HP { get; set; }
        public int MP { get; set; }

        public Hero(string Name, int Level, string HeroType, int HP, int MP)
        {
            this.Name = Name;
            this.Level = Level;
            this.HeroType = HeroType; 
            this.HP = HP;
            this.MP = MP;
        }

        public override string ToString(){
            return $@"Personagem: {this.Name} \nLevel: {this.Level} \nHerói do Tipo:{this.HeroType} \nHP:{this.HP} \n{this.MP}";
        }

        public virtual string Attack(){
            return this.Name + " Atacou com soco!";
        }
        
        
        
    }
}