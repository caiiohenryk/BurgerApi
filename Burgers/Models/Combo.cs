namespace BurgerApi.Burgers.Models;

public class Combo {

    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public double Preco { get; private set; }
    public List<Burger> Burgers { get; private set; } = new List<Burger>();

    public Combo( string nome, double preco) {
        Nome = nome;
        Preco = preco;
        Id = Guid.NewGuid();
    }

    public List<Burger> AdicionarBurger(Burger addBurger) {
        Burgers.Add(addBurger);
        return Burgers;
    }

}